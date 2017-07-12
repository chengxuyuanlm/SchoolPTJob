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
    /// content 的摘要说明
    /// </summary>
    public class content : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
           // context.Response.ContentType = "text/plain";
            //int empid=2;
            //string name="服务员";
            //empid = 1;
            string name = context.Request.QueryString["hotName"].ToString();
            //name="送快递";
            int empid = Convert.ToInt32(context.Request.QueryString["empId"].ToString());
            PTJobTableBll ptbll = new PTJobTableBll();
            List<PTJobTable> ptlist = ptbll.GetInfoPT(empid,name);
            //context.Response.Write(ptlist);
            JavaScriptSerializer ptjs = new JavaScriptSerializer();
            string ptStr = ptjs.Serialize(ptlist);
            context.Response.Write(ptStr);

            //EmployeeTableBll ebll = new EmployeeTableBll();
            //List<EmployeeTable> elist = ebll.GetInfoE();

            //JavaScriptSerializer ejs = new JavaScriptSerializer();
            //string eStr = ejs.Serialize(elist);
            //context.Response.Write(eStr);

            //PTJobTableBll ptbll = new PTJobTableBll();
            //EmployeeTableBll ebll = new EmployeeTableBll();
            //List<object> all = new List<object>();
            //all.Add(ptbll.GetInfoPT());
            //all.Add(ebll.GetInfoE());
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //string str = js.Serialize(all);
            //context.Response.Write(str);
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