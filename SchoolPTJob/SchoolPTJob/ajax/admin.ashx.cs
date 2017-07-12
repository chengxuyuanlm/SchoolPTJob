using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Text;
using Dal;
using Bll;

namespace SchoolPTJob.ajax
{
    /// <summary>
    /// admin 的摘要说明
    /// </summary>
    public class admin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            StudentTableBll stuBll = new StudentTableBll();
            EmployeeTableBll comBll = new EmployeeTableBll();
            StringBuilder sb = new StringBuilder();
            List<Object> search = new List<Object>();
            
            int page;
            string user;
            string userId;
            string userName;
            string ProfessionalOrName;
            string schoolOrAddress;
            string Phone;
            string type;
            string searchstr;
            try
            {
                searchstr = context.Request.QueryString["search"].ToString();
                user = context.Request.QueryString["user"].ToString();
                try
                {
                    page = Convert.ToInt32(context.Request.QueryString["page"].ToString());
                }
                catch
                {
                    page = 1;
                }
                if (user == "stu")
                    search.Add(stuBll.getAll(user, page, searchstr));
                else
                    search.Add(comBll.getAll(user, page, searchstr));
                if (user == "stu")
                    search.Add(stuBll.rowCount(searchstr));
                else
                    search.Add(comBll.rowCount(searchstr));

            }
            catch
            {
                try
                {
                    user = context.Request["user"].ToString();
                    userId = context.Request["userId"].ToString();
                    page = Convert.ToInt32(context.Request["page"].ToString());
                    try
                    {
                        userName = context.Request["stuName"].ToString();
                        ProfessionalOrName = context.Request["Professional"].ToString();
                        schoolOrAddress = context.Request["school"].ToString();
                        Phone = context.Request["Phone"].ToString();
                        search.Add(stuBll.getAll(user, userId, page, userName, ProfessionalOrName, schoolOrAddress, Phone));
                    }
                    catch
                    {
                        userName = context.Request["comName"].ToString();
                        ProfessionalOrName = context.Request["RealName"].ToString();
                        schoolOrAddress = context.Request["Address"].ToString();
                        Phone = context.Request["comPhone"].ToString();
                        search.Add(comBll.getAll(user, userId, page, userName, ProfessionalOrName, schoolOrAddress, Phone));
                    }

                }
                catch
                {
                    try
                    {
                        user = context.Request["user"].ToString();
                    }
                    catch
                    {
                        user = context.Request.QueryString["user"].ToString();
                    }
                    try
                    {
                        page = Convert.ToInt32(context.Request.QueryString["page"].ToString());
                    }
                    catch
                    {
                        page = 1;
                    }
                    try
                    {
                        userId = context.Request["userId"].ToString();
                        type = context.Request["type"].ToString();
                        if (user == "stu" && type == "del")
                            search.Add(stuBll.getAll(user, userId, page));
                        else if (user == "com" && type == "del")
                            search.Add(comBll.getAll(user, userId, page));

                    }
                    catch
                    {
                        if (user == "stu")
                            search.Add(stuBll.getAll(user, page));
                        else
                            search.Add(comBll.getAll(user, page));
                    }
                }


                if (user == "stu")
                    search.Add(stuBll.rowCount());
                else
                    search.Add(comBll.rowCount());
            }
            
            try
            {
                jss.Serialize(search, sb);
            }
            catch
            {
                sb.Append("好像出了点错误");
            }

            context.Response.Write(sb.ToString()); 
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}