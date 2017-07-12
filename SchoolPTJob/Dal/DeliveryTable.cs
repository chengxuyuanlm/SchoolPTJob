using Lesson3;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace Dal
{
    public class DeliveryTable
    {
        public static void SetDr2Model(DataRow dr, Delivery model)
        {
            if (dr["PT_Id"].ToString() != "")
            {
                model.PT_Id = int.Parse(dr["PT_Id"].ToString());
                model.DE_PTJob = new PTJob();
                PTJobTable.SetDr2Model(dr, model.DE_PTJob);
            }
            if (dr["DE_Id"].ToString() != "")
            {
                model.DE_Id = int.Parse(dr["DE_Id"].ToString());
            }
            if (dr["RE_Id"].ToString() != "")
            {
                model.RE_Id = int.Parse(dr["RE_Id"].ToString());
                model.DE_Resume = new Resume();
                ResumeTable.SetDr2Model(dr, model.DE_Resume);
            }
            model.RE_Pass = dr["RE_Pass"].ToString();
            if (dr["DE_Time"].ToString() != "")
            {
                model.DE_Time = DateTime.Parse(dr["DE_Time"].ToString());
            }
        }
        public static List<Delivery> getDelivery(int e_id)
        {
            Delivery model = null;
            StringBuilder sbSql = new StringBuilder("select * from PTJobTable p,DeliveryTable d,ResumeTable r,EmployeeTable e,StudentTable s where p.pt_eId =1 and d.PT_Id = p.pt_Id and d.RE_Id = r.re_Id and r.re_UserId = s.s_Id and e.e_Id = p.pt_eId and d.RE_Pass is null");
            DataTable dt = SqlHelper.ExecuteDataTable(sbSql.ToString());
            List<Delivery> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Delivery>();
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Delivery();
                    SetDr2Model(dr, model);
                    list.Add(model);
                }
            }
            return list;
        }

        public static int deupdata(string re_pass, int de_id)
        {
            return SqlHelper.ExecuteNonQuery("update DeliveryTable set RE_Pass=@re_pass where DE_Id=@de_id",
                new SqlParameter("re_pass", re_pass), new SqlParameter("de_id", de_id));
        }
        /// <summary>
        /// 插入数据[cat66]
        /// </summary>
        /// <param name="user"></param>
        public static void insertdata(string user,int ptid)
        {
            
            //int ptid=1;          
            int sid = StudentTable.getstuid(user);
            int reid = ResumeTable.getreid(sid);
            
            string sql = "insert into DeliveryTable(RE_Id,PT_Id) values(@reid,@ptid)";
            SqlHelper.ExecuteNonQuery(sql, new SqlParameter("reid", reid), new SqlParameter("ptid", ptid));
        }

    }
}