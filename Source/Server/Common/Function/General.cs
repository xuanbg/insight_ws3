﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using FastReport;
using Insight.WS.Server.Common.ORM;
using static Insight.WS.Server.Common.DataAccess;

namespace Insight.WS.Server.Common
{
    public class General
    {

        /// <summary>
        /// 验证验证码是否正确
        /// </summary>
        /// <param name="number">手机号</param>
        /// <param name="code">验证码</param>
        /// <param name="type">验证码类型</param>
        /// <param name="action">是否验证即失效</param>
        /// <returns>bool 是否正确</returns>
        public static bool CodeVerify(string number, string code, int type, bool action = true)
        {
            using (var context = new WSEntities())
            {
                var list = context.SYS_Verify_Record.Where(c => c.Mobile == number && c.Type == type && !c.Verified).ToList();
                if (list.Count == 0 || !(list.Exists(c => c.Code == code && c.FailureTime > DateTime.Now))) return false;

                if (!action) return true;

                foreach (var record in list)
                {
                    record.Verified = true;
                    record.VerifyTime = DateTime.Now;
                }
                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 获取用户登录结果
        /// </summary>
        /// <param name="obj">Session对象实体</param>
        /// <returns>Session对象实体</returns>
        public static Session UserLogin(Session obj)
        {
            if (obj == null) return null;

            var us = OnlineManage.GetSession(obj);
            obj.ID = us.ID;
            if (us.LoginStatus == LoginResult.Unauthorized || us.LoginStatus == LoginResult.NotExist) return us;

            // 用户被封禁
            if (!us.Validity)
            {
                us.LoginStatus = LoginResult.Banned;
                return us;
            }

            // 未通过签名验证
            if (!OnlineManage.Verification(obj))
            {
                us.LoginStatus = LoginResult.Failure;
                return us;
            }

            // 当前是否已登录或未正常退出
            if (us.SessionId == Guid.Empty)
            {
                OnlineManage.UpdateSession(obj);
                us.LoginStatus = LoginResult.Success;
            }
            else
            {
                us.LoginStatus = us.MachineId != obj.MachineId ? LoginResult.Online : LoginResult.Multiple;
            }

            return us;
        }

        /// <summary>
        /// 获取任务、生成报表并保存
        /// </summary>
        /// <returns>bool 是否完成当前任务</returns>
        public static bool BuildReport()
        {
            var time = DateTime.Now;
            Util.LogToEvent($"报表生成任务已经于{time}启动…", EventLogEntryType.Information);
            var task = GetTask();
            var obj = new List<SYS_Report_Instances>();
            string temp = null;
            var i = 0;

            foreach (var s in task)
            {
                temp = temp ?? GetTemplate(s.TemplateId).Content;
                obj.Add(BulidReport(s.ReportId, s.StartDate, s.EndDate, s.DeptName, "Insight WS", s.DeptId, s.UserId, temp));
                i++;
                if (i < task.Count && s.SchedularId == task[i].SchedularId) continue;

                SaveInstances(obj, s.NextDate, s.SchedularId);
                obj.Clear();
                temp = null;
            }
            Util.LogToEvent($"本次报表生成任务已经于{DateTime.Now}完成！共耗时：{(DateTime.Now - time).Seconds}秒。", EventLogEntryType.Information);
            return true;
        }

        /// <summary>
        /// 生成报表实例
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sd">开始日期</param>
        /// <param name="ed">截止日期</param>
        /// <param name="dn">会计主体名称</param>
        /// <param name="un">制表人名称</param>
        /// <param name="did">会计主体ID</param>
        /// <param name="uid">用户ID</param>
        /// <param name="templat"></param>
        /// <returns>SYS_Report_Instances 报表实例对象实体</returns>
        public static SYS_Report_Instances BulidReport(Guid id, DateTime? sd, DateTime? ed, string dn, string un, Guid did, Guid? uid, string templat = null)
        {
            var report = GetDefinition(id);
            var conStr = SqlHelper.ConStr[report.DataSource];
            var name = $"{dn}【{report.Name}】{sd?.ToShortDateString() ?? ""}—{ed?.ToShortDateString() ?? ""}";
            var fr = new Report();

            fr.LoadFromString(templat ?? GetTemplate(report.TemplateId).Content);

            if (conStr != null) fr.Dictionary.Connections[0].ConnectionString = conStr;

            fr.SetParameterValue("StartDate", sd);
            fr.SetParameterValue("EndDate", ed);
            fr.SetParameterValue("DeptName", dn);
            fr.SetParameterValue("UserName", un);
            fr.SetParameterValue("DeptId", did.ToString());
            fr.SetParameterValue("UserId", uid?.ToString());

            if (!fr.Prepare()) return null;

            var stream = new MemoryStream();
            fr.SavePrepared(stream);
            var bytes = new byte[stream.Length];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, bytes.Length);

            var instance = new SYS_Report_Instances
            {
                ReportId = id,
                Name = name.Replace("-", "/").Replace("/", "."),
                Content = bytes,
                CreatorUserId = uid
            };
            return instance;
        }

        /// <summary>
        /// 根据指定报表模板生成业务电子影像
        /// </summary>
        /// <param name="id">业务ID</param>
        /// <param name="templetId">报表模板ID</param>
        /// <param name="dn"></param>
        /// <param name="un"></param>
        /// <param name="did"></param>
        /// <param name="uid"></param>
        /// <param name="obj"></param>
        /// <returns>ImageData 电子影像对象实体</returns>
        public static ImageData BuildImage(Guid id, Guid templetId, string dn, string un, Guid? did, Guid uid, ImageData obj)
        {
            var img = obj ?? new ImageData();
            var fr = new Report();

            fr.LoadFromString(GetTemplate(templetId).Content);
            fr.Dictionary.Connections[0].ConnectionString = SqlHelper.ConStr["WSEntities"];
            fr.SetParameterValue("BusinessId", id.ToString());
            fr.SetParameterValue("DeptName", dn);
            fr.SetParameterValue("UserName", un);
            fr.SetParameterValue("DeptId", did?.ToString());
            fr.SetParameterValue("UserId", uid.ToString());
            if (!fr.Prepare()) return img;

            Stream stream = new MemoryStream();
            fr.SavePrepared(stream);
            var bytes = new byte[stream.Length];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, bytes.Length);

            img.Name = id.ToString();
            img.Expand = "fpx";
            img.Pages = fr.PreparedPages.Count;
            img.Size = stream.Length;
            img.Image = bytes;
            return img;
        }

    }
}