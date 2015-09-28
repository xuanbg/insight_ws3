using System;
using System.Collections.Generic;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.XFB;

namespace Insight.WS.Service.XinFenBao
{
    public partial class Interface
    {

        /// <summary>
        /// 获取学历数据
        /// </summary>
        /// <returns>学历数据</returns>
        public List<MasterData> GetEducate()
        {
            using (var context = new WSEntities())
            {
                return context.MasterData.Join(context.BASE_Category.Where(c => c.Alias == "Educate"), m => m.CategoryId, c => c.ID, (m, c) => m).ToList();
            }
        }

        /// <summary>
        /// 获取行业数据
        /// </summary>
        /// <returns>行业数据</returns>
        public List<MasterData> GetIndustry()
        {
            using (var context = new WSEntities())
            {
                return context.MasterData.Join(context.BASE_Category.Where(c => c.Alias == "Industry"), m => m.CategoryId, c => c.ID, (m, c) => m).ToList();
            }
        }

        /// <summary>
        /// 获取图片认证状态
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="type">认证图片类型</param>
        /// <returns></returns>
        public bool GetImageStatus(Session us, string type)
        {
            if (!OnlineManage.Verification(us)) return false;

            using (var context = new XFBEntities())
            {
                var user = context.t_sys_user.Single(u => u.login_name == us.LoginName);
                var status = context.t_image_info.FirstOrDefault(i => i.user_id == user.id && i.type == type)?.verify_state;
                return status != null && (status == "A3" || status == "A4");
            }
        }

        /// <summary>
        /// 提交认证图片
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="type">认证图片类型</param>
        /// <param name="img">认证图片对象</param>
        /// <returns>bool 是否成功</returns>
        public bool SubmitImage(Session us, string type, byte[] img)
        {
            if (!OnlineManage.Verification(us)) return false;

            using (var context = new XFBEntities())
            {
                var user = context.t_sys_user.Single(u => u.login_name == us.LoginName);
                var path = Util.SaveImage(img, us.LoginName);
                var image = new t_image_info
                {
                    user_id = user.id,
                    image_path = path,
                    type = type,
                    verify_state = "A1",
                    submit_time = DateTime.Now
                };
                context.t_image_info.Add(image);

                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 更新会员类型
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>bool 是否成功</returns>
        public bool SetMemberType(Session us)
        {
            if (!OnlineManage.Verification(us)) return false;

            using (var context = new WSEntities())
            {
                var user = context.SYS_User.Single(u => u.ID == us.UserId);
                user.Type = us.Type;
                if (context.SaveChanges() == 0) return false;

                OnlineManage.Sessions[us.ID].Type = us.Type;
                return true;
            }
        }

        /// <summary>
        /// 获取认证状态
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>认证状态集合</returns>
        public List<string> GetCreditStatus(Session us)
        {
            //if (!OnlineManage.Verification(us)) return null;  禁用用户无法通过验证，不能正确获取认证状态。

            var list = new List<string>();
            using (var context = new XFBEntities())
            {
                var user = context.t_sys_user.FirstOrDefault(u => u.login_name == us.LoginName);
                if (user == null) return null;

                list.Add(user.verify_state);

                var member = context.t_member_info.FirstOrDefault(m => m.user_id == user.id);
                list.Add(member?.verify_state);

                switch (us.Type)
                {
                    case 0:
                        list.Add(null);
                        break;
                    case -1:
                        var student = context.t_student_info.FirstOrDefault(m => m.user_id == user.id);
                        list.Add(student?.verify_state);
                        break;
                    default:
                        var job = context.t_job_info.FirstOrDefault(m => m.user_id == user.id);
                        list.Add(job?.verify_state);
                        break;
                }

                var contact = context.t_contact_info.OrderByDescending(c => c.id).FirstOrDefault(m => m.user_id == user.id);
                list.Add(contact?.verify_state);

                var card = context.t_bank_card_info.OrderByDescending(c => c.id).FirstOrDefault(c => c.user_id == user.id && c.type == "A1");
                list.Add(card?.verify_state);

                var xyk = context.t_bank_card_info.OrderByDescending(c => c.id).FirstOrDefault(c => c.user_id == user.id && c.type == "A2");
                list.Add(xyk?.verify_state);

                var drv = context.t_image_info.OrderByDescending(i => i.id).FirstOrDefault(d => d.user_id == user.id && d.type == "A6");
                list.Add(drv?.verify_state);
            }
            return list;
        }

        /// <summary>
        /// 获取会员基本信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>t_member_info 会员基本信息对象</returns>
        public t_member_info GetMemberInfo(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new XFBEntities())
            {
                var user = context.t_sys_user.FirstOrDefault(u => u.login_name == us.LoginName);
                return user == null ? null : context.t_member_info.FirstOrDefault(m => m.user_id == user.id);
            }
        }

        /// <summary>
        /// 提交基本信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="info">基本信息对象</param>
        /// <returns>bool 是否成功</returns>
        public bool SubmitMemberInfo(Session us, t_member_info info)
        {
            if (!OnlineManage.Verification(us)) return false;

            using (var context = new XFBEntities())
            {
                var user = context.t_sys_user.Single(u => u.login_name == us.LoginName);
                user.has_verify = "A1";

                var member = context.t_member_info.Single(m => m.user_id == user.id);
                member.province = info.province;
                member.city = info.city;
                member.county = info.county;
                member.address = info.address;
                member.verify_state = "A1";
                member.submit_time = DateTime.Now;

                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 获取会员工作单位信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>t_job_info 工作单位信息对象</returns>
        public t_job_info GetJobInfo(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new XFBEntities())
            {
                var user = context.t_sys_user.FirstOrDefault(u => u.login_name == us.LoginName);
                return user == null ? null : context.t_job_info.FirstOrDefault(m => m.user_id == user.id);
            }
        }

        /// <summary>
        /// 提交工作单位信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="info">工作单位信息对象</param>
        /// <returns>bool 是否成功</returns>
        public bool SubmitJobInfo(Session us, t_job_info info)
        {
            if (!OnlineManage.Verification(us)) return false;

            using (var context = new XFBEntities())
            {
                var user = context.t_sys_user.Single(u => u.login_name == us.LoginName);
                user.has_verify = "A1";
                user.type = us.Type == -5 ? "A1" : "A3";

                var job = context.t_job_info.FirstOrDefault(j => j.user_id == user.id);
                if (job == null)
                {
                    info.user_id = user.id;
                    info.verify_state = "A1";
                    info.submit_time = DateTime.Now;
                    context.t_job_info.Add(info);
                }
                else
                {
                    job.company_name = info.company_name;
                    job.company_nature = info.company_nature;
                    job.department = info.department;
                    job.post = info.post;
                    job.tel_number = info.tel_number;
                    job.province = info.province;
                    job.city = info.city;
                    job.county = info.county;
                    job.address = info.address;
                    job.annual_income = info.annual_income;
                    job.verify_state = "A1";
                    job.submit_time = DateTime.Now;
                }

                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 获取会员学生信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>t_student_info 学生信息对象</returns>
        public t_student_info GetStudentInfo(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new XFBEntities())
            {
                var user = context.t_sys_user.FirstOrDefault(u => u.login_name == us.LoginName);
                return user == null ? null : context.t_student_info.FirstOrDefault(m => m.user_id == user.id);
            }
        }

        /// <summary>
        /// 提交学生信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="info">学生信息对象</param>
        /// <returns>bool 是否成功</returns>
        public bool SubmitStudentInfo(Session us, t_student_info info)
        {
            if (!OnlineManage.Verification(us)) return false;

            using (var context = new XFBEntities())
            {
                var user = context.t_sys_user.Single(u => u.login_name == us.LoginName);
                user.has_verify = "A1";
                user.type = "A2";

                var student = context.t_student_info.FirstOrDefault(s => s.user_id == user.id);
                if (student == null)
                {
                    info.user_id = user.id;
                    info.verify_state = "A1";
                    info.submit_time = DateTime.Now;
                    context.t_student_info.Add(info);
                }
                else
                {
                    student.school_name = info.school_name;
                    student.major = info.major;
                    student.grade = info.grade;
                    student.graduation_date = info.graduation_date;
                    student.verify_state = "A1";
                    student.submit_time = DateTime.Now;
                }

                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 获取联系人信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>联系人对象集合</returns>
        public List<t_contact_info> GetContactInfos(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new XFBEntities())
            {
                var user = context.t_sys_user.FirstOrDefault(u => u.login_name == us.LoginName);
                return user == null ? null : context.t_contact_info.Where(m => m.user_id == user.id).OrderByDescending(c => c.id).ToList();
            }
        }

        /// <summary>
        /// 提交多个联系人信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="infos">联系人对象集合</param>
        /// <returns>bool 是否成功</returns>
        public bool SubmitContactInfos(Session us, List<t_contact_info> infos)
        {
            if (!OnlineManage.Verification(us)) return false;

            using (var context = new XFBEntities())
            {
                var user = context.t_sys_user.Single(u => u.login_name == us.LoginName);
                user.has_verify = "A1";

                foreach (var info in infos)
                {
                    var contact = context.t_contact_info.FirstOrDefault(c => c.id == info.id);
                    if (contact == null)
                    {
                        info.user_id = user.id;
                        info.verify_state = "A3";
                        info.submit_time = DateTime.Now;
                        context.t_contact_info.Add(info);
                    }
                    else
                    {
                        contact.contact_name = info.contact_name;
                        contact.contact_phone = info.contact_phone;
                        contact.relationship = info.relationship;
                        contact.verify_state = "A3";
                        contact.submit_time = DateTime.Now;
                    }
                }

                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 完成基本认证信息提交
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>bool 是否成功</returns>
        public bool SubmitBaseInfo(Session us)
        {
            if (!OnlineManage.Verification(us)) return false;

            using (var context = new XFBEntities())
            {
                var user = context.t_sys_user.Single(u => u.login_name == us.LoginName);
                user.verify_state = "A1";

                var member = context.t_member_info.Single(m => m.user_id == user.id);
                if (member.verify_state == "A1") member.verify_state = "A3";

                if (us.Type == -1)
                {
                    var student = context.t_student_info.Single(s => s.user_id == user.id);
                    student.verify_state = "A3";
                }
                else
                {
                    var job = context.t_job_info.Single(j => j.user_id == user.id);
                    job.verify_state = "A3";
                }

                var list = new List<string> {"A1", "B1", "C1", "A3", "B3", "C3"};
                list.ForEach(str =>
                {
                    var img = context.t_image_info.Where(i => i.user_id == user.id && i.type == str && i.verify_state == "A1").OrderByDescending(i => i.id).FirstOrDefault();
                    if (img != null) img.verify_state = "A3";
                });

                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 获取银行卡信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="type">卡类型</param>
        /// <returns>联系人对象集合</returns>
        public t_bank_card_info GetBankCardInfo(Session us, string type)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new XFBEntities())
            {
                var user = context.t_sys_user.FirstOrDefault(u => u.login_name == us.LoginName);
                return user == null ? null : context.t_bank_card_info.Where(c => c.user_id == user.id && c.type == type).OrderByDescending(c => c.id).FirstOrDefault();
            }
        }

        /// <summary>
        /// 提交银行卡信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="info">银行卡对象</param>
        /// <returns>bool 是否成功</returns>
        public bool SubmitBankCardInfo(Session us, t_bank_card_info info)
        {
            if (!OnlineManage.Verification(us)) return false;

            using (var context = new XFBEntities())
            {
                var user = context.t_sys_user.Single(u => u.login_name == us.LoginName);
                user.has_verify = "A1";

                var card = context.t_bank_card_info.FirstOrDefault(c => c.id == info.id);
                if (card == null)
                {
                    info.user_id = user.id;
                    info.verify_state = "A3";
                    info.submit_time = DateTime.Now;
                    context.t_bank_card_info.Add(info);
                }
                else
                {
                    card.name = info.name;
                    card.card_no = info.card_no;
                    card.opening_bank = info.opening_bank;
                    card.yl_number = info.yl_number;
                    card.verify_state = "A3";
                    card.submit_time = DateTime.Now;
                }

                var obj = new MDE_Member_Card
                {
                    Name = info.name,
                    Type = info.type == "A1" ? "储蓄卡" : "信用卡",
                    BankName = info.opening_bank,
                    Number = info.card_no,
                };
                return context.SaveChanges() > 0 && AddCard(us, obj);
            }
        }

        /// <summary>
        /// 提交驾照信息
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public bool SubmitDrvInfo(Session us)
        {
            if (!OnlineManage.Verification(us)) return false;

            using (var context = new XFBEntities())
            {
                var user = context.t_sys_user.Single(u => u.login_name == us.LoginName);
                user.has_verify = "A1";

                var list = new List<string> { "A6", "B6" };
                list.ForEach(str =>
                {
                    var img = context.t_image_info.OrderByDescending(i => i.id).First(i => i.user_id == user.id && i.type == str && i.verify_state == "A1");
                    img.verify_state = "A3";
                });

                return context.SaveChanges() > 0;
            }
        }

    }
}
