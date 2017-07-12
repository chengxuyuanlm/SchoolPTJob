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
    /// resume 的摘要说明
    /// </summary>
    public class resume : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            StudentTableBll StuBll = new StudentTableBll();
            PTandCompanyBll ptBll = new PTandCompanyBll();
            StringBuilder sb = new StringBuilder();
            int id;
            List<Object> index = new List<Object>();
            string user = context.Request.Cookies["StuUserName"].Value.Replace("%40","@");
            index.Add(StuBll.getInfo(user,out id));
            index.Add(ptBll.getPass(id));
            try
            {
                jss.Serialize(index, sb);
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