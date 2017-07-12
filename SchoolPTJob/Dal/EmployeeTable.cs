using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Lesson3;
using Model;
using System.Text;

namespace Dal
{
    public class EmployeeTable
    {
        public int e_Id { get; set; }
        public string e_Name { get; set; }
        public string e_PhotoPath { get; set; }
        public string e_Tell { get; set; }
        public string e_Phone { get; set; }
        public string e_Address { get; set; }
        public string e_Email { get; set; }
        public string e_RealName { get; set; }
        public string e_Password { get; set; }
        public DateTime e_RegTime { get; set; }
        public string e_Certificate { get; set; }
        /// <summary>
        /// 插入企业表
        /// </summary>
        /// <param name="PhoneOrMail">用户名手机号邮箱</param>
        /// <param name="pwd">密码</param>
        /// <param name="isPhone">判断注册方式</param>
        /// <returns>是否插入成功</returns>
        public static bool insertTable(string PhoneOrMail, string pwd, bool isPhone)
        {
            string sql = isPhone ? "insert into EmployeeTable(e_Name,e_Password,e_Phone) values(@PhoneOrMail,@pwd,@PhoneOrMail)" : "insert into EmployeeTable(e_Name,e_Password,e_Email) values(@PhoneOrMail,@pwd,@PhoneOrMail)";
            SqlParameter[] p = new SqlParameter[] { new SqlParameter("@PhoneOrMail", PhoneOrMail), new SqlParameter("@pwd", pwd) };
            if (SqlHelper.ExecuteNonQuery(sql, p) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 判断手机或者邮箱是否注册过
        /// </summary>
        /// <param name="PhoneOrMail">手机号邮箱</param>
        /// <param name="isPhone">判断注册方式</param>
        /// <returns>是否注册过</returns>
        public static bool hasPhoneOrMail(string PhoneOrMail, bool isPhone)
        {
            string sql = isPhone ? "select * from EmployeeTable where e_Phone=@PhoneOrMail" : "select * from EmployeeTable where e_Email=@PhoneOrMail";
            SqlParameter[] p = new SqlParameter[] { new SqlParameter("@PhoneOrMail", PhoneOrMail) };
            DataTable dt = SqlHelper.ExecuteDataTable(sql, p);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 判断该用户是否存在
        /// </summary>
        /// <param name="PhoneOrMail">号码或者邮箱</param>
        /// <returns>返回数据库中的第一行第一列</returns>
        public static object hasUser(string PhoneOrMail)
        {
            string sql = "select e_Password from EmployeeTable where e_Phone=@PhoneOrMail or e_Email=@PhoneOrMail";
            SqlParameter[] p = new SqlParameter[] { new SqlParameter("@PhoneOrMail", PhoneOrMail) };
            return SqlHelper.ExecuteScalar(sql, p);
        }

        public static List<EmployeeTable> getAll(int page)
        {
            string sql = "select * from EmployeeTable order by e_Id offset @page rows fetch next 5 rows only";
            SqlParameter[] p = new SqlParameter[] { new SqlParameter("@page", (page - 1) * 5) };
            DataTable dt = SqlHelper.ExecuteDataTable(sql, p);
            List<EmployeeTable> l = new List<EmployeeTable>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    EmployeeTable com = new EmployeeTable();
                    com.e_Id = Convert.ToInt32(row["e_Id"]);
                    com.e_Name = row["e_Name"].ToString();
                    com.e_RealName = row["e_RealName"].ToString();
                    com.e_Address = row["e_Address"].ToString();
                    com.e_Phone = row["e_Phone"].ToString();
                    l.Add(com);
                }
            }
            return l;
        }
        public static List<EmployeeTable> getAll(int page, string search)
        {
            string sql = "select * from EmployeeTable where e_Id = '" + search + "' or e_Name like '%" + search + "%' or e_RealName like '%" + search + "%' or e_Address like '%" + search + "%'  or e_Phone like '%" + search + "%' order by e_Id offset @page rows fetch next 5 rows only";
            SqlParameter[] p = new SqlParameter[] { new SqlParameter("@page", (page - 1) * 5) };
            DataTable dt = SqlHelper.ExecuteDataTable(sql, p);
            List<EmployeeTable> l = new List<EmployeeTable>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    EmployeeTable com = new EmployeeTable();
                    com.e_Id = Convert.ToInt32(row["e_Id"]);
                    com.e_Name = row["e_Name"].ToString();
                    com.e_RealName = row["e_RealName"].ToString();
                    com.e_Address = row["e_Address"].ToString();
                    com.e_Phone = row["e_Phone"].ToString();
                    l.Add(com);
                }
            }
            return l;
        }

        public static bool delOrUpTable(string sqlStr)
        {
            SqlParameter[] p = new SqlParameter[] { };
            if (SqlHelper.ExecuteNonQuery(sqlStr, p) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取总行数
        /// </summary>
        /// <param name="searchSql">查询筛选的拼接语句</param>
        /// <returns></returns>
        public static int rowCount()
        {
            string sql = "select @@ROWCOUNT row from EmployeeTable";
            SqlParameter[] p = new SqlParameter[] { };
            DataTable dt = SqlHelper.ExecuteDataTable(sql, p);
            List<EmployeeTable> l = new List<EmployeeTable>();
            return dt.Rows.Count;
        }
        public static int rowCount(string search)
        {
            string sql = "select @@ROWCOUNT row from EmployeeTable where e_Id = '" + search + "' or e_Name like '%" + search + "%' or e_RealName like '%" + search + "%' or e_Address like '%" + search + "%'  or e_Phone like '%" + search + "%' ";
            SqlParameter[] p = new SqlParameter[] { };
            DataTable dt = SqlHelper.ExecuteDataTable(sql, p);
            List<EmployeeTable> l = new List<EmployeeTable>();
            return dt.Rows.Count;
        }

        //钟小燕写的 从这开始 啊啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦啦
        /// <summary>
        /// 将employee的数据行转换成model
        /// </summary>
        /// <param name="dr"> 数据行 </param>
        /// <param name="model"> model层的employee </param>
        public static void SetDr2Model(DataRow dr, Employee model)
        {
            if (dr["e_Id"].ToString() != "")
            {
                model.e_Id = int.Parse(dr["e_Id"].ToString());
            }
            model.e_Name = dr["e_Name"].ToString();
            model.e_PhotoPath = dr["e_PhotoPath"].ToString();
            model.e_Tell = dr["e_Tell"].ToString();
            model.e_Phone = dr["e_Phone"].ToString();
            model.e_Address = dr["e_Address"].ToString();
            model.e_Email = dr["e_Email"].ToString();
            model.e_RealName = dr["e_RealName"].ToString();
            model.e_Password = dr["e_Password"].ToString();
            model.e_Certificate = dr["e_Certificate"].ToString();
            if (dr["e_RegTime"].ToString() != "")
            {
                model.e_RegTime = DateTime.Parse(dr["e_RegTime"].ToString());
            }
            model.e_ownership = dr["e_ownership"].ToString();
            model.e_industry = dr["e_industry"].ToString();
        }



        /// <summary>
        /// 取得用人单位的id
        /// </summary>
        /// <param name="employee">用人单位的登录名</param>
        /// <returns>返回受影响行数</returns>
        public static object geteId(string employee)
        {
            return SqlHelper.ExecuteScalar("select e_Id from EmployeeTable where e_Name = @e_Name", new SqlParameter("@e_Name", employee));
        }


        /// <summary>
        /// 根据用人单位的id取到用人单位这条记录
        /// </summary>
        /// <param name="e_id">用人单位id</param>
        /// <returns>用人单位的model</returns>
        public static Employee GetEmployeeById(int e_id)
        {
            SqlParameter[] paras ={
                                     new SqlParameter("@e_Id",e_id)
                                 };
            return QuerySingleByCondiction(paras);
        }



        /// <summary>
        /// 根据条件参数拼接数据库语句，然后到数据库中查到对应的记录（单条记录）
        /// </summary>
        /// <param name="paras">数据库语句的条件参数</param>
        /// <returns>用人单位的model</returns>
        public static Employee QuerySingleByCondiction(SqlParameter[] paras)
        {
            Employee model = null;
            StringBuilder sbSql = new StringBuilder("select * from EmployeeTable");
            if (paras != null)
            {
                for (int i = 0; i < paras.Length; i++)
                {
                    SqlParameter p = paras[i];
                    if (i == 0)
                    {
                        sbSql.Append(" where ");
                    }
                    else
                    {
                        sbSql.Append(" and ");
                    }
                    sbSql.Append(p.ParameterName.Substring(1));
                    sbSql.Append(" = " + p.ParameterName);
                }
            }
            DataTable dt = SqlHelper.ExecuteDataTable(sbSql.ToString(), paras);

            if (dt.Rows.Count > 0)
            {
                model = new Employee();
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Employee();
                    SetDr2Model(dr, model);
                }
            }
            return model;
        }




        /// <summary>
        /// 以账户信息页中的更改之后的数据更新数据库
        /// </summary>
        /// <param>账户信息页中的更改之后的数据</param>
        /// <returns>受影响行数</returns>
        public static int empupdata(string e_Name, string e_RealName, string e_industry, string e_ownership, string e_Phone, string e_Email, int e_Id, string e_Password)
        {
            return SqlHelper.ExecuteNonQuery("update EmployeeTable set e_Name=@e_Name,e_RealName=@e_RealName,e_industry=@e_industry,e_ownership=@e_ownership,e_Phone=@e_Phone,e_Email=@e_Email,e_Password=@e_Password where e_Id=@e_Id",
                new SqlParameter("e_Name", e_Name), new SqlParameter("e_RealName", e_RealName), new SqlParameter("e_industry", e_industry), new SqlParameter("e_ownership", e_ownership), new SqlParameter("e_Phone", e_Phone), new SqlParameter("e_Email", e_Email), new SqlParameter("e_Password", e_Password), new SqlParameter("e_Id", e_Id));
        }
        /// <summary>
        /// 在EmployeeTable表中获取content页面所需的数据[cat66]
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public static List<EmployeeTable> geteInfo(int empid)
        {
            string sql = "select * from EmployeeTable where e_Id = @empid";
            //SqlParameter[] p = new SqlParameter[] { };
            DataTable dt = SqlHelper.ExecuteDataTable(sql, new SqlParameter("empid", empid));
            List<EmployeeTable> l = new List<EmployeeTable>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        EmployeeTable e = new EmployeeTable();
                        //bg.bg_Id = Convert.ToInt32(row["bg_Id"]);
                        //bg.bg_Name = row["bg_Name"].ToString();
                        //bg.bg_Pwd = row["bg_Pwd"].ToString();
                        //l.Add(bg);
                        e.e_Address = row["e_Address"].ToString();
                        l.Add(e);
                    }
                    catch
                    {

                    }
                }
            }
            return l;
        }
    }
}