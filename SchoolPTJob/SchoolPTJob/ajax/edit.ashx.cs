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
    /// edit 的摘要说明
    /// </summary>
    public class edit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            StudentTableBll StuBll = new StudentTableBll();
            ResumeTableBll reBll = new ResumeTableBll();
            StringBuilder sb = new StringBuilder();
            int id;
            List<Object> index = new List<Object>();
            string user = context.Request.Cookies["StuUserName"].Value.Replace("%40", "@");
            try
            {
                string  s_Sex = context.Request["s_Sex"].ToString();
                string  s_Address = context.Request["s_Address"].ToString();
                string  s_Department = context.Request["s_Department"].ToString();
                string  s_Professional = context.Request["s_Professional"].ToString();
                string  s_Phone = context.Request["s_Phone"].ToString();
                string  s_Email = context.Request["s_Email"].ToString();
                string  re_Edu = context.Request["re_Edu"].ToString();
                string  re_WorkTime = context.Request["re_WorkTime"].ToString();
                string  re_Skill = context.Request["re_Skill"].ToString();
                string  re_Describe = context.Request["re_Describe"].ToString();
                index.Add(StuBll.getInfo(user, out id));
                if (StuBll.updateInfo(s_Sex, s_Address, s_Department, s_Professional, s_Phone, s_Email, user) && reBll.updateInfo(re_Edu,re_WorkTime,re_Skill,re_Describe,id)) 
                    context.Response.Write("保存成功");
            }
            catch
            {
                index.Add(StuBll.getInfo(user, out id));
                index.Add(reBll.getAll(id));
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