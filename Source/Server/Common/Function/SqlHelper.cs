using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Server.Common
{
    public class SqlHelper
    {
        public static readonly string WSConn = new WSEntities().Database.Connection.ConnectionString;

        #region WSEntities

        /// <summary>
        /// 返回DataTable的带可变参数组查询方法
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parms">可变长参数组</param>
        /// <returns>DataTable 查询结果集</returns>
        public static DataTable SqlQuery(string sql, params SqlParameter[] parms)
        {
            using (var conn = new SqlConnection(WSConn))
            {
                conn.Open();
                var cmd = MakeCommand(sql, parms);
                cmd.Connection = conn;

                try
                {
                    var table = new DataTable("DataTable");
                    var adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    table.PrimaryKey = new[] {table.Columns["ID"]};
                    return table;
                }
                catch (Exception ex)
                {
                    Util.LogToEvent(ex.ToString());
                    return null;
                }
            }
        }

        /// <summary>
        /// 返回DataTable的带可变参数组查询方法
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="db">数据库</param>
        /// <param name="parms">可变长参数组</param>
        /// <returns>DataTable 查询结果集</returns>
        public static DataTable SqlQuery(string sql, string db, params SqlParameter[] parms)
        {
            using (var conn = new SqlConnection(WSConn))
            {
                conn.Open();
                var cmd = MakeCommand(sql, parms);
                cmd.Connection = conn;

                try
                {
                    var table = new DataTable("DataTable");
                    var adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    table.PrimaryKey = new[] {table.Columns["ID"]};
                    return table;
                }
                catch (Exception ex)
                {
                    Util.LogToEvent(ex.ToString());
                    return null;
                }
            }
        }

        /// <summary>
        /// 返回动态类型的查询方法
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="sql">查询语句</param>
        /// <returns>dynamic 动态类型</returns>
        public static dynamic SqlQuery(Type type, string sql)
        {
            return new WSEntities().Database.SqlQuery(type, sql);
        }

        /// <summary>
        /// 返回受影响行数的方法
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parms">可变长参数组</param>
        /// <returns>int 受影响行数</returns>
        public static int SqlNonQuery(string sql, params SqlParameter[] parms)
        {
            using (var conn = new SqlConnection(WSConn))
            {
                conn.Open();
                var cmd = MakeCommand(sql, parms);
                cmd.Connection = conn;

                try
                {
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Util.LogToEvent(ex.ToString());
                    return -1;
                }
            }
        }

        /// <summary>
        /// 返回受影响行数的方法
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="db">数据库</param>
        /// <param name="parms">可变长参数组</param>
        /// <returns>int 受影响行数</returns>
        public static int SqlNonQuery(string sql, string db, params SqlParameter[] parms)
        {
            using (var conn = new SqlConnection(WSConn))
            {
                conn.Open();
                var cmd = MakeCommand(sql, parms);
                cmd.Connection = conn;

                try
                {
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Util.LogToEvent(ex.ToString());
                    return -1;
                }
            }
        }

        /// <summary>
        /// 返回第一行第一列内容的方法
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parms">可变长参数组</param>
        /// <returns>执行SQL语句后的第一行第一列内容</returns>
        public static object SqlScalar(string sql, params SqlParameter[] parms)
        {
            using (var conn = new SqlConnection(WSConn))
            {
                conn.Open();
                var cmd = MakeCommand(sql, parms);
                cmd.Connection = conn;

                try
                {
                    return cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Util.LogToEvent(ex.ToString());
                    return null;
                }
            }
        }

        /// <summary>
        /// 返回第一行第一列内容的方法
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="db">数据库</param>
        /// <param name="parms">可变长参数组</param>
        /// <returns>执行SQL语句后的第一行第一列内容</returns>
        public static object SqlScalar(string sql, string db, params SqlParameter[] parms)
        {
            using (var conn = new SqlConnection(WSConn))
            {
                conn.Open();
                var cmd = MakeCommand(sql, parms);
                cmd.Connection = conn;

                try
                {
                    return cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Util.LogToEvent(ex.ToString());
                    return null;
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="cmds">多条SQL语句</param>
        /// <param name="db">数据库</param>		
        /// <returns>bool 执行是否成功</returns>
        public static bool SqlExecute(IEnumerable<SqlCommand> cmds, string db = "WS")
        {
            using (var conn = new SqlConnection(WSConn))
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
                catch(Exception ex)
                {
                    Util.LogToEvent(ex.ToString());
                    tran.Rollback();
                    return false;
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="cmds">多条SQL语句</param>
        /// <param name="i">返回ID索引位置</param>
        /// <param name="db">数据库</param>		
        /// <returns>object 指定索引位置的ID</returns>
        public static object SqlExecute(IEnumerable<SqlCommand> cmds, int i, string db = "WS")
        {
            using (var conn = new SqlConnection(WSConn))
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
                catch (Exception ex)
                {
                    Util.LogToEvent(ex.ToString());
                    tran.Rollback();
                    return null;
                }
            }
        }

        #endregion

        #region Others

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

        #endregion

    }
}
