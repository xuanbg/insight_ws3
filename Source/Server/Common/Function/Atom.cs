using System.Linq;
using System.ServiceModel;
using Insight.WS.Server.Common.Service;
using Insight.WS.Server.Common.XFB;

namespace Insight.WS.Server.Common
{
    public class Atom
    {

        /// <summary>
        /// 接口同步
        /// </summary>
        public static void IntrefaceSync()
        {
            const string code = "0A457C39B0A81CEFE3D9E30E99A00388";
            var url = $"http://{Util.GetAppSetting("Address")}:{Util.GetAppSetting("HttpPort")}/XfbInternal";
            var address = new EndpointAddress(url);
            var binding = new BasicHttpBinding();
            using (var context = new XFBEntities())
            {
                var client = new InternalClient(binding, address);
                var list = context.t_interface_log.Where(l => !(bool) l.state).ToList();
                foreach (var r in list)
                {
                    var user = context.t_sys_user.FirstOrDefault(u => u.id == r.table_id);
                    switch (r.table_name)
                    {
                        case "Register":
                            var member = context.t_member_info.Single(m => m.user_id == user.id);
                            r.state = client.Register(code, user?.login_name, user?.pass_word, user?.real_name, member.card_number);
                            break;

                        case "SetMemberType":
                            var type = user?.type == "A1" ? -5 : (user?.type == "A2" ? -1 : -9);
                            r.state = client.SetMemberType(code, user?.login_name, type);
                            break;

                        case "SetPassword":
                            r.state = client.SetPassword(code, user?.login_name, user?.pass_word);
                            break;

                        case "SetUserStatus":
                            r.state = client.SetUserStatus(code, user?.login_name, user?.status == 0);
                            break;

                        case "AddBankCard":
                            var card = context.t_bank_card_info.Single(c => c.id == r.id);
                            var use = context.t_sys_user.Single(u => u.id == card.user_id);
                            r.state = client.AddBankCard(code, use.login_name, card.name, card.type == "A1" ? "储蓄卡" : "信用卡", card.opening_bank, card.card_no);
                            break;

                        case "SetBillStatus":
                            var bill = context.t_bill_stage.Single(b => b.id == r.id);
                            r.state = client.SetBillStatus(code, bill.bill_no, (int) bill.bill_status);
                            break;
                    }
                }

                context.SaveChanges();
                client.Close();
            }
        }
    }
}
