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
    /// index 的摘要说明
    /// </summary>
    public class index : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            PTJobTableBll ptBll = new PTJobTableBll();
            PTandCompanyBll peBll = new PTandCompanyBll();
            StringBuilder sb = new StringBuilder();
            List<Object> index = new List<Object> ();
            index.Add(ptBll.getHotName());
            index.Add(peBll.getHotName());
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