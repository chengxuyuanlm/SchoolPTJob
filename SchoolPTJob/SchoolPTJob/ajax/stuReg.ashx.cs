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
    /// stuReg 的摘要说明
    /// </summary>
    public class stuReg : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string data;
            try
            {
                string phoneOrMail = context.Request["phoneOrMail"].ToString();
                string pwd = context.Request["pwd"].ToString();
                bool isPhone = Convert.ToBoolean(context.Request["isPhone"].ToString());

                data = StudentTableBll.insertTable(phoneOrMail, pwd, isPhone);
                
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