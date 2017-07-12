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
    /// content1 的摘要说明
    /// </summary>
    public class content1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
           // context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            //int empid = 1;
            int empid = Convert.ToInt32(context.Request.QueryString["empId"].ToString());
            EmployeeTableBll ebll = new EmployeeTableBll();
            List<EmployeeTable> elist = ebll.GetInfoE(empid);

            JavaScriptSerializer ejs = new JavaScriptSerializer();
            string eStr = ejs.Serialize(elist);
            context.Response.Write(eStr);
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