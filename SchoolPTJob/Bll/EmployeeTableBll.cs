using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dal;
using Model;

namespace Bll
{
    public class EmployeeTableBll
    {
        /// <summary>
        /// 判断用户是否被注册
        /// </summary>
        /// <param name="PhoneOrMail">手机或邮箱</param>
        /// <param name="pwd">密码</param>
        /// <param name="isPhone">注册方式</param>
        /// <returns>相关提示信息</returns>
        public static string insertTable(string PhoneOrMail, string pwd, bool isPhone)
        {
            if (EmployeeTable.hasPhoneOrMail(PhoneOrMail, isPhone))
            {
                return isPhone ? "该号码已被注册" : "该邮箱已被注册";
            }
            else
            {
                EmployeeTable.insertTable(PhoneOrMail, pwd, isPhone);
                return "注册成功";
            }
        }
        /// <summary>
        /// 判断用户是否登录成功
        /// </summary>
        /// <param name="PhoneOrMail">手机或邮箱</param>
        /// <param name="pwd">密码</param>
        /// <returns>登录信息</returns>
        public static string stuLogin(string PhoneOrMail, string pwd)
        {
            return EmployeeTable.hasUser(PhoneOrMail) == null ? "该用户不存在" : EmployeeTable.hasUser(PhoneOrMail).ToString() == pwd ? "登录成功" : "密码错误";
        }
        public List<EmployeeTable> getAll(string user, int page)
        {
            return EmployeeTable.getAll(page);
        }
        public List<EmployeeTable> getAll(string user, int page,string search)
        {
            return EmployeeTable.getAll(page, search);
        }
        public List<EmployeeTable> getAll(string user, string userId, int page)
        {
            string sqlStr = "delete EmployeeTable where e_Id = " + userId;
            EmployeeTable.delOrUpTable(sqlStr);
            return EmployeeTable.getAll(page);
        }
        public List<EmployeeTable> getAll(string user, string userId, int page, string comName, string RealName, string Address, string comPhone)
        {
            string sqlStr = "update EmployeeTable set e_Name = '" + comName + "',e_RealName = '" + RealName + "',e_Address = '" + Address + "',e_Phone = '" + comPhone + "' where e_Id = " + userId;
            EmployeeTable.delOrUpTable(sqlStr);
            return EmployeeTable.getAll(page);
        }

        public int rowCount()
        {
            return EmployeeTable.rowCount();
        }
        public int rowCount(string search)
        {
            return EmployeeTable.rowCount(search);
        }



        public object geteId(string employee)
        {
            return EmployeeTable.geteId(employee);
        }

        public Employee GetEmployeeById(int e_id)
        {
            return EmployeeTable.GetEmployeeById(e_id);
        }
        public int empupdata(string e_Name, string e_RealName, string e_industry, string e_ownership, string e_Phone, string e_Email, int e_Id, string e_Password)
        {
            return EmployeeTable.empupdata(e_Name, e_RealName, e_industry, e_ownership, e_Phone, e_Email, e_Id, e_Password);
        }

        public List<EmployeeTable> GetInfoE(int empid)
        {
            return EmployeeTable.geteInfo(empid);
        }

    }
}