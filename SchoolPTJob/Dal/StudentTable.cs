using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Lesson3;
using Model;

namespace Dal
{
    public class StudentTable
    {
        public int s_id { get; set; }
        public string s_UserName { get; set; }
        public string s_Password { get; set; }
        public string s_PhotoPath { get; set; }
        public string s_RealName { get; set; }
        public string s_Sex { get; set; }
        public string s_Department { get; set; }
        public string s_Professional { get; set; }
        public string s_Phone { get; set; }
        public string s_Address { get; set; }
        public string s_Email { get; set; }
        public DateTime s_RegTime { get; set; }

        public int s_IdCard { get; set; }
        public bool IsReturn { get; set; }

        /// <summary>
        /// 插入用户表
        /// </summary>
        /// <param name="PhoneOrMail">用户名手机号邮箱</param>
        /// <param name="pwd">密码</param>
        /// <param name="isPhone">判断注册方式</param>
        /// <returns>是否插入成功</returns>
        public static bool insertTable(string PhoneOrMail,string pwd,bool isPhone)
        {
            string sql = isPhone ? "insert into StudentTable(s_UserName,s_Password,s_Phone) values(@PhoneOrMail,@pwd,@PhoneOrMail)" : "insert into StudentTable(s_UserName,s_Password,e_Email) values(@PhoneOrMail,@pwd,@PhoneOrMail)";
            SqlParameter[] p = new SqlParameter[] { new SqlParameter("@PhoneOrMail", PhoneOrMail), new SqlParameter("@pwd", pwd) };
            if(SqlHelper.ExecuteNonQuery(sql,p)>0)
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
        public static bool hasPhoneOrMail(string PhoneOrMail,bool isPhone)
        {
            string sql = isPhone ? "select * from StudentTable where s_Phone=@PhoneOrMail" : "select * from StudentTable where e_Email=@PhoneOrMail";
            SqlParameter[] p = new SqlParameter[] { new SqlParameter("@PhoneOrMail", PhoneOrMail)};
            DataTable dt = SqlHelper.ExecuteDataTable(sql,p);
            if (dt.Rows.Count>0)
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
            string sql = "select s_Password from StudentTable where s_Phone=@PhoneOrMail or s_Email=@PhoneOrMail";
            SqlParameter[] p = new SqlParameter[] { new SqlParameter("@PhoneOrMail", PhoneOrMail) };
            return SqlHelper.ExecuteScalar(sql, p);
        }

        public static List<StudentTable> getAll(int page)
        {
            string sql = "select * from StudentTable order by s_Id offset @page rows fetch next 5 rows only";
            SqlParameter[] p = new SqlParameter[] { new SqlParameter("@page", (page - 1) * 5) };
            DataTable dt = SqlHelper.ExecuteDataTable(sql, p);
            List<StudentTable> l = new List<StudentTable>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    StudentTable stu = new StudentTable();
                    stu.s_id = Convert.ToInt32(row["s_Id"]);
                    stu.s_UserName = row["s_UserName"].ToString();
                    stu.s_Professional = row["s_Professional"].ToString();
                    stu.s_Department = row["s_Department"].ToString();
                    stu.s_Phone = row["s_Phone"].ToString();
                    l.Add(stu);
                }
            }
            return l;
        }
        public static List<StudentTable> getAll(int page,string search)
        {
            string sql = "select * from StudentTable where s_Id = '" + search + "' or s_UserName like '%" + search + "%' or s_Professional like '%" + search + "%' or s_Department like '%" + search + "%'  or s_Phone like '%" + search + "%'  order by s_Id offset @page rows fetch next 5 rows only";
            SqlParameter[] p = new SqlParameter[] { new SqlParameter("@page", (page - 1) * 5) };
            DataTable dt = SqlHelper.ExecuteDataTable(sql, p);
            List<StudentTable> l = new List<StudentTable>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    StudentTable stu = new StudentTable();
                    stu.s_id = Convert.ToInt32(row["s_Id"]);
                    stu.s_UserName = row["s_UserName"].ToString();
                    stu.s_Professional = row["s_Professional"].ToString();
                    stu.s_Department = row["s_Department"].ToString();
                    stu.s_Phone = row["s_Phone"].ToString();
                    l.Add(stu);
                }
            }
            return l;
        }

        
        public static List<StudentTable> getInfo(string user,out int id)
        {
            string sql = "select * from StudentTable where s_UserName = '"+user +"'";
            SqlParameter[] p = new SqlParameter[] { };
            DataTable dt = SqlHelper.ExecuteDataTable(sql, p);
            List<StudentTable> l = new List<StudentTable>();
            id = 0;
            if (dt.Rows.Count > 0)
            {
                    StudentTable stu = new StudentTable();
                    stu.s_id = Convert.ToInt32(dt.Rows[0]["s_Id"]);
                    id = stu.s_id;
                    stu.s_RealName = dt.Rows[0]["s_RealName"].ToString();
                    stu.s_Professional = dt.Rows[0]["s_Professional"].ToString();
                    stu.s_Department = dt.Rows[0]["s_Department"].ToString();
                    stu.s_Phone = dt.Rows[0]["s_Phone"].ToString();
                    stu.s_Sex = dt.Rows[0]["s_Sex"].ToString();
                    stu.s_Address = dt.Rows[0]["s_Address"].ToString();
                    stu.s_Email = dt.Rows[0]["s_Email"].ToString();
                    stu.s_PhotoPath = dt.Rows[0]["s_PhotoPath"].ToString();
                    l.Add(stu);
            }
            
            return l;
        }
        public static bool updateInfo(string s_Sex,string s_Address,string s_Department,string s_Professional,string s_Phone,string s_Email,string userName)
        {
            string sqlStr = "update StudentTable set s_Sex = '" + s_Sex + "',s_Address = '" + s_Address + "',s_Department = '" + s_Department + "',s_Professional = '" + s_Professional + "' ,s_Phone = '" + s_Phone + "',s_Email = '" + s_Email + "' where s_UserName = '" + userName + "'";
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
        public static bool delOrUpTable(string sqlStr)
        {
            SqlParameter[] p = new SqlParameter[] {  };
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
            string sql = "select @@ROWCOUNT row from StudentTable";
            SqlParameter[] p = new SqlParameter[] { };
            DataTable dt = SqlHelper.ExecuteDataTable(sql, p);
            List<StudentTable> l = new List<StudentTable>();
            return dt.Rows.Count;
        }
        public static int rowCount(string search)
        {
            string sql = "select @@ROWCOUNT row from StudentTable where s_Id = '" + search + "' or s_UserName like '%" + search + "%' or s_Professional like '%" + search + "%' or s_Department like '%" + search + "%'  or s_Phone like '%" + search + "%' ";
            SqlParameter[] p = new SqlParameter[] { };
            DataTable dt = SqlHelper.ExecuteDataTable(sql, p);
            List<StudentTable> l = new List<StudentTable>();
            return dt.Rows.Count;
        }

        public static void SetDr2Model(DataRow dr, Student model)
        {
            if (dr["s_Id"].ToString() != "")
            {
                model.s_Id = int.Parse(dr["s_Id"].ToString());
            }
            model.s_UserName = dr["s_UserName"].ToString();
            model.s_Password = dr["s_Password"].ToString();
            model.s_PhotoPath = dr["s_PhotoPath"].ToString();
            model.s_RealName = dr["s_RealName"].ToString();
            model.s_Sex = dr["s_Sex"].ToString();
            model.s_Department = dr["s_Department"].ToString();
            model.s_Professional = dr["s_Professional"].ToString();
            model.s_Phone = dr["s_Phone"].ToString();
            model.s_Address = dr["s_Address"].ToString();
            model.s_Email = dr["s_Email"].ToString();
            model.s_IdCard = dr["s_IdCard"].ToString();
            if (dr["s_RegTime"].ToString() != "")
            {
                model.s_RegTime = DateTime.Parse(dr["s_RegTime"].ToString());
            }
        }
        /// <summary>
        /// 通过用户名找到学生id[cat66]
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int getstuid(string user)
        {
            string sql = "select s_Id from StudentTable where s_UserName = @user";
            
            return Convert.ToInt32(SqlHelper.ExecuteScalar(sql, new SqlParameter("user", user)));    
        }
    }
}