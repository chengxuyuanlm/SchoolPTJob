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
    /// search 的摘要说明
    /// </summary>
    public class search : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            PTandCompanyBll peBll = new PTandCompanyBll();
            StringBuilder sb = new StringBuilder();
            string hotName;
            int page;
            int sort;
            int money;
            int num;
            int type;
            try { 
                hotName = context.Request.QueryString["hotName"].ToString();
            }
            catch
            {
                hotName = "";
            }
            try
            {
                page = Convert.ToInt32( context.Request.QueryString["page"].ToString());
            }
            catch
            {
                page = 1;
            }
            try
            {
                sort = Convert.ToInt32(context.Request.QueryString["sort"].ToString());
            }
            catch
            {
                sort = 0;
            }
            try
            {
                money = Convert.ToInt32(context.Request.QueryString["money"].ToString());
            }
            catch
            {
                money = 1;
            }
            try
            {
                num = Convert.ToInt32(context.Request.QueryString["num"].ToString());
            }
            catch
            {
                num = 1;
            }
            try
            {
                type = Convert.ToInt32(context.Request.QueryString["type"].ToString());
            }
            catch
            {
                type = 1;
            }
            List<Object> search = new List<Object>();
            search.Add(peBll.SearchData(hotName, page, sort, money,num,type));
            search.Add(peBll.rowCount(hotName, page, sort, money, num, type));
            
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