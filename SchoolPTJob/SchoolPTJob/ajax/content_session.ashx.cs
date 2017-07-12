using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Script.Serialization;
using Bll;

namespace SchoolPTJob.ajax
{
    /// <summary>
    /// content_session 的摘要说明
    /// </summary>
    public class content_session : IHttpHandler,IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            //context.Session["stuName"].ToString();
            //context.Session["stuName"] = "名字";
            
            //if(context.Session["stuName"] != null)//取到学生的用户名
            if (context.Request.Cookies["StuUserName"] != null)
            {
                int ptid = Convert.ToInt32(context.Request.QueryString["pt_Id"].ToString());
                string name = context.Request.Cookies["StuUserName"].Value.ToString();//获取cookie用户名
                DeliveryTableBll dl = new DeliveryTableBll();
                dl.insertDeliverybll(name,ptid);
                //context.Response.Write(name);
                List<object> list = new List<object>();
                list.Add(name);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string str = js.Serialize(list);
                context.Response.Write(str);
            }
            else
            {
                List<object> list = new List<object>();
                list.Add("nodata");
                JavaScriptSerializer js = new JavaScriptSerializer();
                string str = js.Serialize(list);
                context.Response.Write(str);
                //context.Response.Write("/(ㄒoㄒ)/~~");
            }
            
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