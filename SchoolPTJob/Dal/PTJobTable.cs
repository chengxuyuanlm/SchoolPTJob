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
    public class PTJobTable
    {
        public int pt_Id { get; set; }
        public string pt_Kind { get; set; }
        public string pt_Time { get; set; }
        public int pt_eId { get; set; }
        public int pt_Money { get; set; }
        public string pt_Address { get; set; }
        public string pt_Tel { get; set; }
        public string pt_State { get; set; }
        public DateTime pt_OrderMakeTime { get; set; }
        public int pt_StuId { get; set; }
        public int pt_Need { get; set; }
        public string pt_Name { get; set; }

        /// <summary>
        /// 获取热门兼职的数据
        /// </summary>
        /// <returns>兼职表的集合</returns>
        public static List<PTJobTable> getHotName()
        {
            string sql = "select top 100 pt_Id, pt_Name,pt_StuId,pt_Kind from PTJobTable order by pt_State desc ,pt_Id desc";
            SqlParameter[] p = new SqlParameter[] { };
            DataTable dt = SqlHelper.ExecuteDataTable(sql, p);
            List<PTJobTable> l = new List<PTJobTable>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        PTJobTable pt = new PTJobTable();
                        pt.pt_Id = Convert.ToInt32(row["pt_Id"]);
                        pt.pt_Name = row["pt_Name"].ToString();
                        pt.pt_StuId = Convert.ToInt32(row["pt_StuId"]);
                        pt.pt_Kind = row["pt_Kind"].ToString();
                        l.Add(pt);
                    }
                    catch { }
                    
                }
            }
            return l;
        }


        /// <summary>
        /// 取得PTJob数据，可以是很多
        /// </summary>
        /// <param name="paras"></param>
        /// <returns>兼职表的集合</returns>
        public static List<PTJob> QueryListCondiction(SqlParameter[] paras)
        {
            PTJob model = null;
            StringBuilder sbSql = new StringBuilder("select * from PTJobTable p,EmployeeTable e where p.pt_eId = e.e_Id and p.pt_StuId is null");
            if (paras != null)
            {
                for (int i = 0; i < paras.Length; i++)
                {
                    SqlParameter p = paras[i];
                    sbSql.Append(" and ");
                    sbSql.Append(p.ParameterName.Substring(1));
                    sbSql.Append(" =" + p.ParameterName);
                }
            }
            DataTable dt = (paras == null) ? SqlHelper.ExecuteDataTable(sbSql.ToString()) : SqlHelper.ExecuteDataTable(sbSql.ToString(), paras);
            List<PTJob> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<PTJob>();
                foreach (DataRow dr in dt.Rows)
                {
                    model = new PTJob();
                    SetDr2Model(dr, model);
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 将兼职表的数据行转换成model
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="model">空</param>
        public static void SetDr2Model(DataRow dr, PTJob model)
        {
            if (dr["pt_Id"].ToString() != "")
            {
                model.pt_Id = int.Parse(dr["pt_Id"].ToString());
            }
            model.pt_Kind = dr["pt_Kind"].ToString();
            model.pt_Time = dr["pt_Time"].ToString();
            model.pt_ReleaseTime = dr["pt_ReleaseTime"].ToString();
            if (dr["pt_eId"].ToString() != "")
            {
                model.pt_eId = int.Parse(dr["pt_eId"].ToString());
                model.Pt_employee = new Employee();
                EmployeeTable.SetDr2Model(dr, model.Pt_employee);
            }
            if (dr["pt_Money"].ToString() != "")
            {
                model.pt_Money = int.Parse(dr["pt_Money"].ToString());
            }
            model.pt_Address = dr["pt_Address"].ToString();
            model.pt_Tel = dr["pt_Tel"].ToString();
            model.pt_State = dr["pt_State"].ToString();
            model.pt_Name = dr["pt_Name"].ToString();
            model.pt_Kind = dr["pt_Kind"].ToString();
            if (dr["pt_StuId"].ToString() != "")
            {
                model.pt_StuId = int.Parse(dr["pt_StuId"].ToString());
                model.Pt_student = new Student();
                StudentTable.SetDr2Model(dr, model.Pt_student);
            }
            if (dr["pt_Need"].ToString() != "")
            {
                model.pt_Need = int.Parse(dr["pt_Need"].ToString());
            }
        }
        /// <summary>
        /// 删除id=所传来的参数值的记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns>受影响行数</returns>
        public static int ptdelete(int id)
        {
            return SqlHelper.ExecuteNonQuery("delete from PTJobTable where pt_Id = @pt_Id", new SqlParameter("pt_Id", id));
        }
        /// <summary>
        /// 更新兼职表
        /// </summary>
        /// <returns></returns>
        public static int ptupdata(string kind, string time, int money, string address, string name, string tel, int need, string State, int id)
        {
            return SqlHelper.ExecuteNonQuery("update PTJobTable set pt_Kind=@pt_Kind,pt_Time=@pt_Time,pt_Money=@pt_Money,pt_Address=@pt_Address,pt_Name=@pt_Name,pt_Tel=@pt_Tel,pt_Need=@pt_Need,pt_State=@pt_State where pt_Id=@pt_Id",
                new SqlParameter("pt_Kind", kind), new SqlParameter("pt_Time", time), new SqlParameter("pt_Money", money), new SqlParameter("pt_Address", address), new SqlParameter("pt_Name", name), new SqlParameter("pt_Tel", tel), new SqlParameter("pt_Need", need), new SqlParameter("pt_State", State), new SqlParameter("pt_Id", id));
        }
        /// <summary>
        /// 增加一条兼职记录
        /// </summary>
        /// <returns></returns>
        public static int ptadd(string kind, string time, int money, string address, string name, string tel, int need, string State, int eid)
        {
            return SqlHelper.ExecuteNonQuery("insert into PTJobTable (pt_Kind,pt_Time,pt_Money,pt_Address,pt_Name,pt_Tel,pt_Need,pt_State,pt_eId) values (@pt_Kind,@pt_Time,@pt_Money,@pt_Address,@pt_Name,@pt_Tel,@pt_Need,@pt_State,@pt_eId);select @@identity",
                new SqlParameter("pt_Kind", kind), new SqlParameter("pt_Time", time), new SqlParameter("pt_Money", money), new SqlParameter("pt_Address", address), new SqlParameter("pt_Name", name), new SqlParameter("pt_Tel", tel), new SqlParameter("pt_Need", need), new SqlParameter("pt_State", State), new SqlParameter("pt_eId", eid));
        }
        /// <summary>
        /// 用兼职id来获取该id所在的整条记录
        /// </summary>
        /// <param name="pt_id"></param>
        /// <returns></returns>
        public static PTJob GetPTJobById(int pt_id)
        {
            SqlParameter[] paras ={
                                     new SqlParameter("@pt_Id",pt_id)
                                 };
            return QuerySingleByCondiction(paras);
        }
        /// <summary>
        /// 取得兼职表的一条记录
        /// </summary>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static PTJob QuerySingleByCondiction(SqlParameter[] paras)
        {
            PTJob model = null;
            StringBuilder sbSql = new StringBuilder("select * from PTJobTable p,EmployeeTable e,StudentTable s where p.pt_eId = e.e_Id");
            if (paras != null)
            {
                for (int i = 0; i < paras.Length; i++)
                {
                    SqlParameter p = paras[i];
                    sbSql.Append(" and ");
                    sbSql.Append(p.ParameterName.Substring(1));
                    sbSql.Append(" = " + p.ParameterName);
                }
            }
            DataTable dt = SqlHelper.ExecuteDataTable(sbSql.ToString(), paras);

            if (dt.Rows.Count > 0)
            {
                model = new PTJob();
                foreach (DataRow dr in dt.Rows)
                {
                    model = new PTJob();
                    SetDr2Model(dr, model);
                }
            }
            return model;
        }
        /// <summary>
        /// 呵呵
        /// </summary>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static List<PTJob> QueryListCondiction2(SqlParameter[] paras)
        {
            PTJob model = null;
            StringBuilder sbSql = new StringBuilder("select * from PTJobTable p,StudentTable s,EmployeeTable e where p.pt_StuId = s.s_Id and p.pt_eId = e.e_Id");
            if (paras != null)
            {
                for (int i = 0; i < paras.Length; i++)
                {
                    SqlParameter p = paras[i];
                    sbSql.Append(" and ");
                    sbSql.Append(p.ParameterName.Substring(1));
                    sbSql.Append(" =" + p.ParameterName);
                }
            }
            DataTable dt = (paras == null) ? SqlHelper.ExecuteDataTable(sbSql.ToString()) : SqlHelper.ExecuteDataTable(sbSql.ToString(), paras);
            List<PTJob> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<PTJob>();
                foreach (DataRow dr in dt.Rows)
                {
                    model = new PTJob();
                    SetDr2Model(dr, model);
                    list.Add(model);
                }
            }
            return list;
        }

        public static int GetPTJobNum(int e_id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from PTJobTable where pt_eId =@e_id", new SqlParameter("e_id", e_id));
            return dt.Rows.Count;
        }

        public static int GetOKPTJobNum(int e_id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from PTJobTable where pt_eId =@e_id and pt_StuId is not null", new SqlParameter("e_id", e_id));
            return dt.Rows.Count;
        }


        public static int ptstuupdata(int pt_id)
        {
            return SqlHelper.ExecuteNonQuery("update PTJobTable set pt_Need=pt_Need-1 where PT_Id=@pt_id",
                new SqlParameter("pt_id", pt_id));
        }
   /// <summary>
   /// 获取PTJobTable表中content网页所需数据[cat66]
   /// </summary>
   /// <param name="empid"></param>
   /// <returns></returns>
        public static List<PTJobTable> getPtInfo(int empid,string name)
        {
     
            string sql = "select * from PTJobTable where pt_eId=@empid and pt_Name=@name";
            //SqlParameter[] p = new SqlParameter[] {  };

            DataTable dt = SqlHelper.ExecuteDataTable(sql, new SqlParameter("empid", empid), new SqlParameter("name", name));
            List<PTJobTable> l = new List<PTJobTable>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        PTJobTable pt = new PTJobTable();
                        //bg.bg_Id = Convert.ToInt32(row["bg_Id"]);
                        //bg.bg_Name = row["bg_Name"].ToString();
                        //bg.bg_Pwd = row["bg_Pwd"].ToString();
                        //l.Add(bg);
                        pt.pt_Name = row["pt_Name"].ToString();
                        pt.pt_Address = row["pt_Address"].ToString();
                        pt.pt_Money = Convert.ToInt32(row["pt_Money"]);
                        pt.pt_Time = row["pt_Time"].ToString();
                        l.Add(pt);
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