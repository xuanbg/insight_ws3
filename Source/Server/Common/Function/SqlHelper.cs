using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Insight.WS.Server.Common
{
    public class SqlHelper
    {
        public static readonly string ConnStr = new WSEntities().Database.Connection.ConnectionString;

        /// <summary>
        /// 返回DataTable的带可变参数组查询方法
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parms">可变长参数组</param>
        /// <returns>DataTable 查询结果集</returns>
        public static DataTable SqlQuery(string sql, params SqlParameter[] parms)
        {
            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                var table = new DataTable("DataTable");
                var cmd = new SqlCommand(sql, conn);
                foreach (var p in parms)
                {
                    if (p.Value == null || p.Value.ToString() == "")
                    {
                        p.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(p);
                }

                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                table.PrimaryKey = new[] { table.Columns["ID"] };
                return table;
            }
        }

        /// <summary>
        /// 返回受影响行数的方法
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parms">可变长参数组</param>
        /// <returns>int 受影响行数</returns>
        public static int SqlNonQuery(string sql, params SqlParameter[] parms)
        {
            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                try
                {
                    foreach (var p in parms)
                    {
                        if (p.Value == null || p.Value.ToString() == "")
                        {
                            p.Value = DBNull.Value;
                        }
                        cmd.Parameters.Add(p);
                    }
                    return cmd.ExecuteNonQuery();
                }
                catch
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 返回第一行第一列内容的方法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static object SqlScalar(string sql, params SqlParameter[] parms)
        {
            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                foreach (var p in parms)
                {
                    if (p.Value == null || p.Value.ToString() == "")
                    {
                        p.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(p);
                }
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="cmds">多条SQL语句</param>		
        public static bool SqlExecute(IEnumerable<SqlCommand> cmds)
        {
            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                var ids = new List<object>();
                var tran = conn.BeginTransaction();
                try
                {
                    foreach (var cmd in cmds)
                    {
                        if (cmd.Parameters.IndexOf("@Read") > 0 && (Guid)cmd.Parameters[0].Value == Guid.Empty)
                            cmd.Parameters[0].Value = ids[(int)cmd.Parameters["@Read"].Value];

                        if (cmd.Parameters.IndexOf("@Get") > 0 && (Guid)cmd.Parameters[1].Value == Guid.Empty)
                            cmd.Parameters[1].Value = ids[(int)cmd.Parameters["@Get"].Value];

                        cmd.Connection = conn;
                        cmd.Transaction = tran;
                        var obj = cmd.ExecuteScalar();
                        if (cmd.Parameters.IndexOf("@Write") <= 0) continue;

                        var val = (int)cmd.Parameters["@Write"].Value;
                        if (ids.Count <= val) ids.Add(obj); else ids[val] = obj;
                    }
                    tran.Commit();
                    return true;
                }
                catch
                {
                    tran.Rollback();
                    return false;
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="cmds">多条SQL语句</param>
        /// <param name="i"></param>		
        public static object SqlExecute(IEnumerable<SqlCommand> cmds, int i)
        {
            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                var ids = new List<object>();
                var tran = conn.BeginTransaction();
                try
                {
                    foreach (var cmd in cmds)
                    {
                        if (cmd.Parameters.IndexOf("@Read") > 0 && (Guid)cmd.Parameters[0].Value == Guid.Empty)
                            cmd.Parameters[0].Value = ids[(int)cmd.Parameters["@Read"].Value];

                        if (cmd.Parameters.IndexOf("@Get") > 0 && (Guid)cmd.Parameters[1].Value == Guid.Empty)
                            cmd.Parameters[1].Value = ids[(int)cmd.Parameters["@Get"].Value];

                        cmd.Connection = conn;
                        cmd.Transaction = tran;
                        var obj = cmd.ExecuteScalar();
                        if (cmd.Parameters.IndexOf("@Write") <= 0) continue;

                        var val = (int)cmd.Parameters["@Write"].Value;
                        if (ids.Count <= val) ids.Add(obj); else ids[val] = obj;
                    }
                    tran.Commit();
                    return ids[i];
                }
                catch
                {
                    tran.Rollback();
                    return null;
                }
            }
        }

        /// <summary>
        /// 组装SqlCommand对象
        /// </summary>
        /// <param name="sql">sql命令</param>
        /// <param name="parameters">可变长参数组</param>
        /// <returns>SqlCommand 组装完成的SqlCommand对象</returns>
        public static SqlCommand MakeCommand(string sql, params SqlParameter[] parameters)
        {
            var cmd = new SqlCommand(sql);
            foreach (var p in parameters)
            {
                if (p.Value == null || p.Value.ToString() == "")
                {
                    p.Value = DBNull.Value;
                }
                cmd.Parameters.Add(p);
            }
            return cmd;
        }

    }
}
