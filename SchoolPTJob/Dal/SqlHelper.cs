﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
   public static class SqlHelper
    {
        //1.连接字符串
       private static readonly string constr = ConfigurationManager.ConnectionStrings["SchoolPTJob"].ConnectionString;

        //2.执行增删改的
        public static int ExecuteNonQuery(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                //创建执行Sql命令对象
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //3.执行返回单个值的
        public static object ExecuteScalar(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        //4.执行返回SqlDataReader
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] pms)
        {
            //创建链接对象
            SqlConnection con = new SqlConnection(constr);
            //创建执行命令对象
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    //打开链接
                    con.Open();
                    //指定操作
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                   //报异常时关闭数据库销毁对象
                catch (Exception)
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }
        }

        //返回DataTable
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] pms)
        {
            //创建本地数据库对象
            DataTable dt = new DataTable();
            //创建适配器对象
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, constr))
            {
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                //读取数据填充到本地数据库对象中
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}
