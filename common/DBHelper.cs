using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    /// <summary>
    /// 通用DBHelper类
    /// </summary>
    public class DBHelper
    {
        //数据库的链接字符串，取自Web.config文件(sql)
        private static string connString = ConfigurationManager.AppSettings["dsn"].ToString();
        private static SqlConnection conn = null;
        //返回结果集(查询结果)
        private static SqlDataReader result = null; //sql

       //返回(增删改)的更新行数
        private static int count = 0;
        #region OpenConn
        /// <summary>
        /// 打开connection
        /// </summary>
        private static void OpenConn(string whichMethod)
        {
            switch (whichMethod)
            {
                case "sql":
                    conn = new SqlConnection(connString);
                    conn.Open();
                    break;
            }
        }
        #endregion
        #region sql dbhelper
        #region sql查询
        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="sqlName">要执行的存储过程的名称或者sql语句</param>
        /// <param name="para">要执行的存储过程的参数数组,执行sql时用不到</param>
        /// <param name="whichMethod">使用的查询方法(存储过程StoredProcedure\sql语句Text)</param>
        /// <returns>得到的结果集</returns>
        public static SqlDataReader Select(string sql, SqlParameter[] para, CommandType cmdType)
        {
            try
            {
                OpenConn("sql");
                using (SqlCommand com = new SqlCommand(sql, conn))
                {
                    com.CommandType = cmdType;
                    if (para.Length != 0)
                        com.Parameters.AddRange(para);
                    result = com.ExecuteReader();//返回数据集
                };
            }
            catch (SqlException e2)
            {
                throw new Exception(e2.Message, e2);
            }
            return result;
        }
        #endregion
        #region sql增删改
        /// <summary>
        /// 增删改方法
        /// </summary>
        /// <param name="sqlName">要执行的存储过程的名称或者sql语句</param>
        /// <param name="para">要执行的存储过程的参数数组,执行sql语句时用不到</param>
        /// <param name="whichMethod">使用的更新方法(存储过程StoredProcedure\sql语句Text)</param>
        /// <returns>更新得到的行数</returns>
        public static int UpDeInstu(string sql, SqlParameter[] para, CommandType cmdType)
        {
            try
            {
                OpenConn("sql");
                using (SqlCommand com = new SqlCommand(sql, conn))
                {
                    com.CommandType = cmdType;
                    if (para.Length != 0)
                        com.Parameters.AddRange(para);
                    count = com.ExecuteNonQuery();//返回受影响的行数
                };
            }
            catch (SqlException e2)
            {
                count = 0;
                throw new Exception(e2.Message, e2);
            }
            return count;
        }
        #endregion
        #endregion
        #region 关闭连接
        /// <summary>
        /// 最后需要调用的关闭函数，关闭与数据库的链接
        /// </summary>
        public static void close()
        {
            #region sql
            if (result != null)
                result.Close();
            if (conn != null)
                conn.Close();
            #endregion
        }
        #endregion
    }
}
