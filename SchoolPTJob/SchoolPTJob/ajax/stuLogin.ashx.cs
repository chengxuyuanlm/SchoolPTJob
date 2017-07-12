using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Text;
using Dal;
using Bll;
using System.Web.SessionState;

namespace SchoolPTJob.ajax
{
    /// <summary>
    /// stuLogin 的摘要说明
    /// </summary>
    public class stuLogin : IHttpHandler,IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string data;
            try
            {
                string phoneOrMail = context.Request["phoneOrMail"].ToString();
                string pwd = context.Request["pwd"].ToString();
                
                data = StudentTableBll.stuLogin(phoneOrMail, pwd);
                //context.Session["stuName"] = "张三";
                
                HttpCookie mycookie = new HttpCookie("stuName");
                mycookie.Value = phoneOrMail;
                mycookie.Expires = DateTime.Now.AddDays(3);
                //context.Response.Cookies.Add(mycookie);
                context.Response.AppendCookie(mycookie);
            }
            catch
            {
                data = "好像出了点问题";
            }
            context.Response.Write(data);
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