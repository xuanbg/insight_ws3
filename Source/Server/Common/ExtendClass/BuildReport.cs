using System.Collections.Generic;

namespace Insight.WS.Server.Common
{
    public class BuildReport
    {

        /// <summary>
        /// 获取任务、生成报表并保存
        /// </summary>
        /// <returns>bool 是否完成当前任务</returns>
        public static bool Build()
        {
            var task = ReportDAL.GetTask();
            var obj = new List<SYS_Report_Instances>();
            string temp = null;
            var i = 0;

            foreach (var s in task)
            {
                temp = temp ?? ReportDAL.GetTemplate(s.TemplateId).Content;
                obj.Add(ReportDAL.BulidReport(s.ReportId, s.StartDate, s.EndDate, s.DeptName, "Insight WS", s.DeptId, s.UserId, temp));
                i++;
                if (i < task.Count && s.SchedularId == task[i].SchedularId) continue;

                ReportDAL.SaveInstances(obj, s.NextDate, s.SchedularId);
                obj.Clear();
                temp = null;
            }
            return true;
        }

    }
}
