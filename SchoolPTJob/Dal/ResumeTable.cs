using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Lesson3;
using Model;

namespace Dal
{
    public class ResumeTable
    {
        public int re_UserId{get;set;}
        public string re_Edu{get;set;}
        public string re_WorkTime{get;set;}
        public string re_Skill{get;set;}
        public string re_Describe{get;set;}

        public static void SetDr2Model(DataRow dr, Resume model)
        {
            if (dr["re_UserId"].ToString() != "")
            {
                model.re_UserId = int.Parse(dr["re_UserId"].ToString());
                model.Re_Student = new Student();
                StudentTable.SetDr2Model(dr, model.Re_Student);
            }
            if (dr["re_Id"].ToString() != "")
            {
                model.re_Id = int.Parse(dr["re_Id"].ToString());
            }
            model.re_Skill = dr["re_Skill"].ToString();
            model.re_Edu = dr["re_Edu"].ToString();
            model.re_Describe = dr["re_Describe"].ToString();
            model.re_WorkTime = dr["re_WorkTime"].ToString();
        }

        public static List<ResumeTable> getAll(int id)
        {
            string sql = "select * from ResumeTable where re_UserId = '"+id+"';";
            SqlParameter[] p = new SqlParameter[] { };
            DataTable dt = SqlHelper.ExecuteDataTable(sql, p);
            List<ResumeTable> l = new List<ResumeTable>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        ResumeTable re = new ResumeTable();
                        re.re_Edu = row["re_Edu"].ToString();
                        re.re_WorkTime = row["re_WorkTime"].ToString();
                        re.re_Describe = row["re_Describe"].ToString();
                        re.re_Skill = row["re_Skill"].ToString();
                        l.Add(re);
                    }
                    catch { }

                }
            }
            return l;
        }

        public static bool updateInfo(string re_Edu, string re_WorkTime, string re_Skill, string re_Describe, int id)
        {
            string sqlStr = "update ResumeTable set re_Edu = '" + re_Edu + "',re_WorkTime = '" + re_WorkTime + "',re_Skill = '" + re_Skill + "',re_Describe = '" + re_Describe + "' where re_UserId = '" + id + "'";
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
        public static int getreid(int reuserid)
        {
            string sql = "select re_Id from ResumeTable where re_UserId = @reuserid";

            return Convert.ToInt32(SqlHelper.ExecuteScalar(sql, new SqlParameter("reuserid", reuserid)));
        }
    }
}