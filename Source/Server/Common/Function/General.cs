using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using FastReport;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.Service;
using static Insight.WS.Server.Common.DataAccess;
using static Insight.WS.Server.Common.Util;

namespace Insight.WS.Server.Common
{
    public class General
    {
        #region 字段

        // 最低兼容版本
        private static readonly int CompatibleVersion = Convert.ToInt32(GetAppSetting("CompatibleVersion"));

        // 更新版本
        private static readonly int UpdateVersion = Convert.ToInt32(GetAppSetting("UpdateVersion"));

        // 访问验证服务用的Binding
        private static readonly Binding Binding = new NetTcpBinding();

        // 访问验证服务用的Address
        private static readonly EndpointAddress Address = new EndpointAddress(GetAppSetting("IvsAddress"));

        #endregion

        #region 接口验证

        /// <summary>
        /// 通过Session校验是否有权限访问
        /// </summary>
        /// <returns>JsonResult</returns>
        public static JsonResult Verify()
        {
            var result = new JsonResult();
            var obj = GetAuthorization<Session>();
            if (obj == null) return result.InvalidAuth();

            if (obj.Version < CompatibleVersion || obj.Version > UpdateVersion) return result.Incompatible();

            var us = Verification(obj);
            switch (us.LoginResult)
            {
                case LoginResult.Success:
                    return result.Success();

                case LoginResult.NotExist:
                    return result.Expired();

                case LoginResult.Failure:
                    return result.InvalidAuth();

                case LoginResult.Banned:
                    return result.Disabled();

                default:
                    return result;
            }
        }

        /// <summary>
        /// 通过指定的Rule校验是否有权限访问
        /// </summary>
        /// <returns>JsonResult</returns>
        public static JsonResult Verify(string rule)
        {
            var result = new JsonResult();
            var obj = GetAuthorization<string>();
            return obj != rule ? result.InvalidAuth() : result.Success();
        }

        #endregion  

        #region 常用方法

        /// <summary>
        /// 构建用于接口返回值的Json对象
        /// </summary>
        /// <typeparam name="T">传入的对象类型</typeparam>
        /// <param name="obj">传入的对象</param>
        /// <returns>JsonResult</returns>
        public static JsonResult GetJson<T>(T obj)
        {
            var result = new JsonResult();
            return obj == null ? result.NotFound() : result.Success(Serialize(obj));
        }

        /// <summary>
        /// 保存图片到image文件夹，通过URL访问
        /// </summary>
        /// <param name="pic">图片字节流</param>
        /// <param name="catalog">分类</param>
        /// <param name="name">文件名（可选）</param>
        /// <returns>string 图片保存路径</returns>
        public static string SaveImage(byte[] pic, string catalog, string name = null)
        {
            var path = $"{GetAppSetting("ImageLocal")}\\{catalog}\\";
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (name == null)
                {
                    var img = Image.FromStream(new MemoryStream(pic));
                    name = $"{Guid.NewGuid()}.{GetImageExtension(img)}";
                }

                File.WriteAllBytes(path + name, pic);
                return $"/{catalog}/{name}";
            }
            catch (Exception ex)
            {
                LogToEvent(ex.ToString());
                LogToEvent($"文件写入路径：{path}；字节流：{pic}");
                return null;
            }
        }

        /// <summary>
        /// 获取任务、生成报表并保存
        /// </summary>
        /// <returns>bool 是否完成当前任务</returns>
        public static bool BuildReport()
        {
            var time = DateTime.Now;
            LogToEvent($"报表生成任务已经于{time}启动…", EventLogEntryType.Information);
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
            LogToEvent($"本次报表生成任务已经于{DateTime.Now}完成！共耗时：{(DateTime.Now - time).Seconds}秒。", EventLogEntryType.Information);
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

        #endregion

        #region 验证服务调用

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="type">验证类型</param>
        /// <param name="mobile">手机号</param>
        /// <param name="time">过期时间（分钟）</param>
        /// <returns>string 验证码</returns>
        public static string GetCode(int type, string mobile, int time = 30)
        {
            using (var client = new InterfaceClient(Binding, Address))
            {
                return client.GetCode(type, mobile, time);
            }
        }

        /// <summary>
        /// 验证验证码是否正确
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="code">验证码</param>
        /// <param name="type">验证码类型</param>
        /// <param name="action">是否验证成功后删除记录</param>
        /// <returns>bool 是否正确</returns>
        public static bool VerifyCode(string mobile, string code, int type, bool action = true)
        {
            using (var client = new InterfaceClient(Binding, Address))
            {
                return client.VerifyCode(mobile, code, type, action);
            }
        }

        /// <summary>
        /// 获取验证服务器上的用户会话
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>Session 用户会话</returns>
        public static Session UserLogin(Session obj)
        {
            using (var client = new InterfaceClient(Binding, Address))
            {
                return client.UserLogin(obj);
            }
        }

        /// <summary>
        /// 获取当前在线状态的全部内部用户的Session
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>全部内部用户的Session</returns>
        public static List<Session> GetSessions(Session obj)
        {
            using (var client = new InterfaceClient(Binding, Address))
            {
                return client.GetSessions(obj);
            }
        }

        /// <summary>
        /// 更新指定用户Session的签名
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <param name="signature">新的签名</param>
        public static void UpdateSignature(Session obj, string signature)
        {
            using (var client = new InterfaceClient(Binding, Address))
            {
                client.UpdateSignature(obj, signature);
            }
        }

        /// <summary>
        /// 设置指定用户Session的登录状态
        /// </summary>
        /// <param name="obj">用户会话</param>
        public static void SetOnlineStatus(Session obj)
        {
            using (var client = new InterfaceClient(Binding, Address))
            {
                client.SetOnlineStatus(obj);
            }
        }

        /// <summary>
        /// 根据用户ID设置用户状态
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <param name="uid">用户ID</param>
        /// <param name="validity">用户状态</param>
        /// <returns>bool 是否成功</returns>
        public static bool SetUserStatus(Session obj, Guid uid, bool validity)
        {
            using (var client = new InterfaceClient(Binding, Address))
            {
                return client.SetUserStatus(obj, uid, validity);
            }
        }

        /// <summary>
        /// 会话合法性验证，用于持久化客户端
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>bool 是否成功</returns>
        public static Session Verification(Session obj)
        {
            using (var client = new InterfaceClient(Binding, Address))
            {
                return client.Verification(obj);
            }
        }

        /// <summary>
        /// 简单会话合法性验证，用于非持久化客户端
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>bool 是否成功</returns>
        public static bool SimpleVerifty(Session obj)
        {
            using (var client = new InterfaceClient(Binding, Address))
            {
                return client.SimpleVerifty(obj);
            }
        }

        /// <summary>
        /// 带鉴权的会话合法性验证
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <param name="action">需要鉴权的操作ID</param>
        /// <returns>bool 是否成功</returns>
        public static bool Verification(Session obj, string action)
        {
            using (var client = new InterfaceClient(Binding, Address))
            {
                return client.Authorization(obj, action);
            }
        }

        #endregion

    }
}
