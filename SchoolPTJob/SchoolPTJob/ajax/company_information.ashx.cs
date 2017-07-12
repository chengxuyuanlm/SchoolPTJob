using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Text;
using Dal;
using Bll;
using Model;

namespace SchoolPTJob.ajax
{
    /// <summary>
    /// company_information 的摘要说明
    /// </summary>
    public class company_information : IHttpHandler
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();
        StringBuilder sbLoadList = new StringBuilder();
        StringBuilder newsbLoadList = new StringBuilder();
        StringBuilder sb = new StringBuilder();
        EmployeeTableBll EmployeeBLL = new EmployeeTableBll();
        PTJobTableBll PTJobBLL = new PTJobTableBll();
        PTJob ptjobmodel = new PTJob();
        Employee employeemodel = new Employee();
        List<Object> index = new List<Object>();
        DeliveryTableBll deliverybll = new DeliveryTableBll();
        string employee = "";
        string deleteid = "";
        string changeid = "";
        string de_id = "";
        string Pt_id = "";
        public void ProcessRequest(HttpContext context)
        {
            employee = context.Request.Cookies["userName"].Value.Replace("%40", "@");
            //context.Session["userName"] = "18867804591";
            //employee = context.Session["userName"].ToString();
            if (IsLogin())
            {
                index.Add(LoadList(employee).ToString());
                index.Add(hhs(employee).ToString());
                index.Add(LoadList2(employee).ToString());
                index.Add(Employinfor(employee).ToArray());
                index.Add(LoadList3(employee).ToString());
                index.Add(GetPTJobNum(employee));
                index.Add(GetOKPTJobNum(employee));
                index.Add(GetNewMessage(employee));
                try
                {
                    if (context.Request["kk"].ToString() != "")
                    {
                        deleteid = context.Request["kk"].ToString();
                        index.Add(PTdelete(employee, deleteid).ToString());
                        //index.Add(deleteid); 
                    }


                }
                catch { }
                try
                {
                    if (context.Request["interviewOKok"].ToString() != "")
                    {
                        de_id = context.Request["interviewOKok"].ToString();
                        Pt_id = context.Request["PT_Id"].ToString();
                        ptstuupdata(Pt_id);
                        deupdata(de_id);
                        index.Add(LoadList(employee).ToString());
                        index.Add(LoadList3(employee).ToString());
                    }


                }
                catch { }


                try
                {
                    if (context.Request["interviewOKno"].ToString() != "")
                    {
                        de_id = context.Request["interviewOKno"].ToString();
                        deupdata2(de_id);
                        index.Add(LoadList(employee).ToString());
                        index.Add(LoadList3(employee).ToString());
                    }


                }
                catch { }

                try
                {
                    if (context.Request["change"].ToString() != "")
                    {
                        changeid = context.Request["change"].ToString();
                        index.Add(PTchange(changeid).ToArray());
                        //index.Add(deleteid);                    
                    }
                }
                catch { }
                try
                {
                    if (context.Request["pt_Kind"].ToString() != "")
                    {
                        string kind = context.Request["pt_Kind"].ToString();
                        string time = context.Request["pt_Time"].ToString();
                        string money = context.Request["pt_Money"].ToString();
                        string address = context.Request["pt_Address"].ToString();
                        string name = context.Request["pt_Name"].ToString();
                        string tel = context.Request["pt_Tel"].ToString();
                        string need = context.Request["pt_Need"].ToString();
                        string State = context.Request["pt_State"].ToString();
                        string id = context.Request["pt_Id"].ToString();
                        index.Add(PTchangeOK(employee, kind, time, money, address, name, tel, need, State, id).ToString());
                    }
                }
                catch { }
                try
                {
                    if (context.Request["pt_addKind"].ToString() != "")
                    {
                        string kind = context.Request["pt_addKind"].ToString();
                        string time = context.Request["pt_addTime"].ToString();
                        string money = context.Request["pt_addMoney"].ToString();
                        string address = context.Request["pt_addAddress"].ToString();
                        string name = context.Request["pt_addName"].ToString();
                        string tel = context.Request["pt_addTel"].ToString();
                        string need = context.Request["pt_addNeed"].ToString();
                        string State = context.Request["pt_addState"].ToString();
                        index.Add(PTadd(employee, kind, time, money, address, name, tel, need, State).ToString());
                    }
                }
                catch { }
                try
                {
                    if (context.Request["e_Name"].ToString() != "")
                    {
                        string e_Name = context.Request["e_Name"].ToString();
                        string e_RealName = context.Request["e_RealName"].ToString();
                        string e_industry = context.Request["e_industry"].ToString();
                        string e_ownership = context.Request["e_ownership"].ToString();
                        string e_Phone = context.Request["e_Phone"].ToString();
                        string e_Email = context.Request["e_Email"].ToString();
                        EmpchangeOK(e_Name, e_RealName, e_industry, e_ownership, e_Phone, e_Email);
                    }
                }
                catch { }
                try
                {
                    if (context.Request["newEpwd"].ToString() != "")
                    {
                        ChangeEmpPwd(context.Request["newEpwd"].ToString());
                    }
                }
                catch { }
                jss.Serialize(index, sb);
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
        public static bool IsLogin()
        {
            if (HttpContext.Current.Request.Cookies["userName"].Value != null)
                return true;
            else
                return false;
        }
        public string hhs(string employee)
        {
            return employee;
        }

        /// 正在招聘
        /// </summary>
        /// <returns></returns>
        public StringBuilder LoadList(string employee)
        {
            int i = 1;
            sbLoadList.Clear();
            List<PTJob> list = PTJobBLL.GetNoHasPTJob();
            sbLoadList.Append("<tr class='table_header'><td>兼职id</td><td>兼职时间</td><td>薪资待遇</td><td>兼职地点</td><td>兼职名称</td><td>联系电话</td><td>兼职类型</td><td>需要人数</td><td>操作</td></tr>");
            foreach (PTJob model in list)
            {
                if (model.Pt_employee.e_Name == employee)
                {
                    sbLoadList.Append("<tr class=\"login_information\"><td class=\"ptid\">" + i + "</td>");
                    sbLoadList.Append("<td>" + model.pt_Time + "</td>");
                    sbLoadList.Append("<td>" + model.pt_Money + "</td>");
                    sbLoadList.Append("<td>" + model.pt_Address + "</td>");
                    sbLoadList.Append("<td>" + model.pt_Name + "</td>");
                    sbLoadList.Append("<td>" + model.pt_Tel + "</td>");
                    sbLoadList.Append("<td>" + model.pt_Kind + "</td>");
                    sbLoadList.Append("<td>" + model.pt_Need + "</td>");
                    sbLoadList.Append("<td><div class='person_change' onclick='person_change_click(" + model.pt_Id + ")'></div><div class='person_delete' onclick='person_delete_click(" + model.pt_Id + ")'/></div></td></tr>");
                    i++;
                }

            }
            return sbLoadList;
        }

        public StringBuilder PTdelete(string employee, string ptid)
        {
            newsbLoadList.Clear();
            int id = Int32.Parse(ptid);
            if (PTJobBLL.ptdelete(id) > 0)
            {
                newsbLoadList = LoadList(employee);
            }
            return newsbLoadList;
        }
        public List<PTJob> PTchange(string ptid)
        {
            int id = Int32.Parse(ptid);
            ptjobmodel = PTJobBLL.GetPTJobById(id);
            List<PTJob> a1 = new List<PTJob>();
            a1.Add(ptjobmodel);
            return a1;
        }

        public StringBuilder PTchangeOK(string employee, string kind, string time, string money, string address, string name, string tel, string need, string State, string id)
        {
            newsbLoadList.Clear();
            int changeid = Int32.Parse(id);
            int changeneed = Int32.Parse(need);
            int changemoney = Int32.Parse(money);
            if (PTJobBLL.ptupdata(kind, time, changemoney, address, name, tel, changeneed, State, changeid) > 0)
            {
                newsbLoadList = LoadList(employee);
            }
            return newsbLoadList;
        }
        public StringBuilder PTadd(string employee, string kind, string time, string money, string address, string name, string tel, string need, string State)
        {
            newsbLoadList.Clear();
            int eid = (int)EmployeeBLL.geteId(employee);
            int changeneed = Int32.Parse(need);
            int changemoney = Int32.Parse(money);
            if (PTJobBLL.ptadd(kind, time, changemoney, address, name, tel, changeneed, State, eid) > 0)
            {
                newsbLoadList = LoadList(employee);
            }
            return newsbLoadList;
        }

        /// 招聘记录
        /// </summary>
        /// <returns></returns>
        public StringBuilder LoadList2(string employee)
        {
            sbLoadList.Clear();
            List<PTJob> list = PTJobBLL.GetHasPTJob();
            sbLoadList.Append("<tr class='table_header'><td>职位名称</td><td>学生姓名</td><td>学生电话</td><td>发布时间</td></tr>");
            foreach (PTJob model in list)
            {
                if (model.Pt_employee.e_Name == employee)
                {
                    sbLoadList.Append("<tr class=\"login_information\"><td class=\"ptid\">" + model.pt_Name + "</td>");
                    sbLoadList.Append("<td>" + model.Pt_student.s_RealName + "  等</td>");
                    sbLoadList.Append("<td>" + model.Pt_student.s_Phone + "</td>");
                    sbLoadList.Append("<td>" + DateTime.Parse(model.pt_ReleaseTime) + "</td></tr>");
                }

            }
            return sbLoadList;
        }


        /// 账户信息
        /// </summary>
        /// <returns></returns>
        public List<Employee> Employinfor(string employee)
        {
            int eid = (int)EmployeeBLL.geteId(employee);
            employeemodel = EmployeeBLL.GetEmployeeById(eid);
            List<Employee> emp = new List<Employee>();
            emp.Add(employeemodel);
            return emp;
        }
        public int EmpchangeOK(string e_Name, string e_RealName, string e_industry, string e_ownership, string e_Phone, string e_Email)
        {
            int e_Id = (int)EmployeeBLL.geteId(employee);
            employeemodel = EmployeeBLL.GetEmployeeById(e_Id);
            string e_Password = employeemodel.e_Password;
            if (e_Phone == "未验证")
            {
                e_Phone = "";
            }
            if (e_Email == "未验证")
            {
                e_Email = "";
            }
            return EmployeeBLL.empupdata(e_Name, e_RealName, e_industry, e_ownership, e_Phone, e_Email, e_Id, e_Password);
        }


        /// 安全中心
        /// </summary>
        /// <returns></returns>
        public int ChangeEmpPwd(string e_Password)
        {
            int e_Id = (int)EmployeeBLL.geteId(employee);
            employeemodel = EmployeeBLL.GetEmployeeById(e_Id);
            string e_Name = employeemodel.e_Name;
            string e_RealName = employeemodel.e_RealName;
            string e_industry = employeemodel.e_industry;
            string e_ownership = employeemodel.e_ownership;
            string e_Phone = employeemodel.e_Phone;
            string e_Email = employeemodel.e_Email;
            return EmployeeBLL.empupdata(e_Name, e_RealName, e_industry, e_ownership, e_Phone, e_Email, e_Id, e_Password);
        }

        public StringBuilder LoadList3(string employee)
        {
            sbLoadList.Clear();
            int eid = (int)EmployeeBLL.geteId(employee);
            List<Delivery> list = deliverybll.getDelivery(eid);
            foreach (Delivery model in list)
            {
                sbLoadList.Append("<div class='anews'><div class='anews_head'>应聘消息</div><ul><li><small>应聘者：</small><span class='stu_name li2span'>" + model.DE_Resume.Re_Student.s_RealName + "</span></li><li><small>应聘职位：</small><span class='stu_name li2span'>" + model.DE_PTJob.pt_Name + "</span></li><li><small><br>应聘者信息：<br>学校：<span class='stu_school stu_infor'>" + model.DE_Resume.re_Edu + "</span><br>专业：<span class='stu_major stu_infor'>" + model.DE_Resume.re_Skill + "</span><br>工作时间：<span class='stu_experience stu_infor'>" + model.DE_Resume.re_WorkTime + "</span><input type='button' class='looknow lookstu' value='查看简历' /><br></small></li><li><div class='students_resume_btn_1' onclick='interviewOK(" + model.DE_Id + "," + model.PT_Id + ")'>通过</div><div class='students_resume_btn_2'  onclick='interviewNO(" + model.DE_Id + ")'>直接拒绝</div></li></ul></div>");
            }
            return sbLoadList;
        }

        public int GetPTJobNum(string employee)
        {
            int eid = (int)EmployeeBLL.geteId(employee);
            return PTJobBLL.GetPTJobNum(eid);
        }

        public int GetOKPTJobNum(string employee)
        {
            int eid = (int)EmployeeBLL.geteId(employee);
            return PTJobBLL.GetOKPTJobNum(eid);
        }

        public int GetNewMessage(string employee)
        {
            int i = 0;
            int eid = (int)EmployeeBLL.geteId(employee);
            List<Delivery> list = deliverybll.getDelivery(eid);
            foreach (Delivery model in list)
            {
                i++;
            }
            return i;
        }

        public void ptstuupdata(string pt_id)
        {
            int id = int.Parse(pt_id);
            PTJobBLL.ptstuupdata(id);
        }

        public void deupdata(string de_id)
        {
            int id = int.Parse(de_id);
            string re_pass = "通过";
            deliverybll.deupdata(re_pass, id);
        }

        public void deupdata2(string de_id)
        {
            int id = int.Parse(de_id);
            string re_pass = "拒绝";
            deliverybll.deupdata(re_pass, id);
        }
    }
}