using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Lesson3;

namespace Dal
{
    public class PTandCompany
    {
        public int pt_Id { get; set; }
        public string pt_Kind { get; set; }
        public string pt_Time { get; set; }
        public int pt_eId { get; set; }
        public int pt_Money { get; set; }
        public string pt_Address { get; set; }
        public int pt_StuId { get; set; }
        public int pt_Need { get; set; }
        public string pt_Name { get; set; }
        public string e_Name { get; set; }
        public string e_PhotoPath { get; set; }
        public string e_RealName { get; set; }
        public string RE_Pass { get; set; }
        /// <summary>
        /// 获取公司信息和其发布的兼职信息
        /// </summary>
        /// <returns></returns>
        public static List<PTandCompany> getHotName()
        {
            string sql = "select top 6 pt.pt_Id, pt.pt_Name,pt.pt_StuId ,pt.PT_Time,pt.PT_Money,pt.PT_Address,emp.e_Name,emp.e_PhotoPath,pt.PT_eId from PTJobTable pt,EmployeeTable emp where pt.PT_eId = emp.e_Id order by pt_State desc ,pt_Id desc;";
            SqlParameter[] p = new SqlParameter[] { };
            DataTable dt = SqlHelper.ExecuteDataTable(sql, p);
            List<PTandCompany> l = new List<PTandCompany>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        PTandCompany ptEmp = new PTandCompany();
                        ptEmp.pt_Id = Convert.ToInt32(row["pt_Id"]);
                        ptEmp.pt_Name = row["pt_Name"].ToString();
                        try
                        {
                            ptEmp.pt_StuId = Convert.ToInt32(row["pt_StuId"]);
                        }
                        catch
                        {
                            ptEmp.pt_StuId = 0;
                        }
                        ptEmp.pt_eId = Convert.ToInt32(row["PT_eId"]);
                        ptEmp.pt_Time = row["PT_Time"].ToString();
                        ptEmp.pt_Money = Convert.ToInt32(row["PT_Money"]);
                        ptEmp.pt_Address = row["PT_Address"].ToString();
                        ptEmp.e_Name = row["e_Name"].ToString();
                        ptEmp.e_PhotoPath = row["e_PhotoPath"].ToString();
                        l.Add(ptEmp);
                    }
                    catch { }
                    
                }
            }
            return l;
        }
        /// <summary>
        /// 获取查询筛选数据
        /// </summary>
        /// <param name="searchSql">查询筛选的拼接语句</param>
        /// <param name="page">分页参数</param>
        /// <returns></returns>
        public static List<PTandCompany> SearchData(string searchSql,int page)
        {
            string sql = "select pt.pt_Id, pt.pt_Name,pt.pt_StuId ,pt.PT_Time,pt.PT_Money,pt.PT_Address,emp.e_Name,emp.e_PhotoPath,pt.PT_eId from PTJobTable pt,EmployeeTable emp where pt.PT_eId = emp.e_Id" + searchSql +" offset @page rows fetch next 6 rows only";
            SqlParameter[] p = new SqlParameter[] { new SqlParameter("@page", (page-1)*6) };
            DataTable dt = SqlHelper.ExecuteDataTable(sql, p);
            List<PTandCompany> l = new List<PTandCompany>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    PTandCompany ptEmp = new PTandCompany();
                    ptEmp.pt_Id = Convert.ToInt32(row["pt_Id"]);
                    ptEmp.pt_Name = row["pt_Name"].ToString();
                    try
                    {
                        ptEmp.pt_StuId = Convert.ToInt32(row["pt_StuId"]);
                    }
                    catch
                    {
                        ptEmp.pt_StuId = 0;
                    }
                    //ptEmp.pt_StuId = Convert.ToInt32(row["pt_StuId"]);
                    ptEmp.pt_eId = Convert.ToInt32(row["PT_eId"]);
                    ptEmp.pt_Time = row["PT_Time"].ToString();
                    ptEmp.pt_Money = Convert.ToInt32(row["PT_Money"]);
                    ptEmp.pt_Address = row["PT_Address"].ToString();
                    ptEmp.e_Name = row["e_Name"].ToString();
                    ptEmp.e_PhotoPath = row["e_PhotoPath"].ToString();
                    l.Add(ptEmp);
                }
            }
            return l;
        }


        /// <summary>
        /// 获取总行数
        /// </summary>
        /// <param name="searchSql">查询筛选的拼接语句</param>
        /// <returns></returns>
        public static int rowCount(string searchSql)
        {
            string sql = "select @@ROWCOUNT row from PTJobTable pt,EmployeeTable emp where pt.PT_eId = emp.e_Id" + searchSql;
            SqlParameter[] p = new SqlParameter[] { };
            DataTable dt = SqlHelper.ExecuteDataTable(sql, p);
            List<PTandCompany> l = new List<PTandCompany>();
            return dt.Rows.Count;
        }

        public static List<PTandCompany> getPass(int userId)
        {
            string sql = "select pt.pt_Name,pt.PT_Time,pt.PT_Money,pt.PT_Address,emp.e_RealName,de.RE_Pass from PTJobTable pt,EmployeeTable emp, DeliveryTable de where pt.PT_eId = emp.e_Id and pt.pt_Id = de.PT_Id and  pt.pt_StuId ='" + userId + "';";
            SqlParameter[] p = new SqlParameter[] { };
            DataTable dt = SqlHelper.ExecuteDataTable(sql, p);
            List<PTandCompany> l = new List<PTandCompany>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        PTandCompany ptEmp = new PTandCompany();
                        ptEmp.pt_Name = row["pt_Name"].ToString();
                        ptEmp.pt_Time = row["PT_Time"].ToString();
                        ptEmp.pt_Money = Convert.ToInt32(row["PT_Money"]);
                        ptEmp.pt_Address = row["PT_Address"].ToString();
                        ptEmp.e_RealName = row["e_RealName"].ToString();
                        ptEmp.RE_Pass = row["RE_Pass"].ToString();
                        l.Add(ptEmp);
                    }
                    catch { }

                }
            }
            return l;
        }

    }
}