using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dal;

namespace Bll
{
    public class StudentTableBll
    {
        /// <summary>
        /// 判断号码或者邮箱是否被注册
        /// </summary>
        /// <param name="PhoneOrMail">手机或邮箱</param>
        /// <param name="pwd">密码</param>
        /// <param name="isPhone">是否为手机注册</param>
        /// <returns>相应提示</returns>
        public static string insertTable(string PhoneOrMail,string pwd,bool isPhone)
        {
            if(StudentTable.hasPhoneOrMail(PhoneOrMail,isPhone))
            {
                return isPhone ? "该号码已被注册" : "该邮箱已被注册";
            }
            else
            {
                StudentTable.insertTable(PhoneOrMail, pwd, isPhone);
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
           return StudentTable.hasUser(PhoneOrMail)==null? "该用户不存在":StudentTable.hasUser(PhoneOrMail).ToString()==pwd? "登录成功":"密码错误";
        }
        public  List<StudentTable> getAll(string user,int page)
        {
                return StudentTable.getAll(page);
        }
        public List<StudentTable> getAll(string user,string userId,int page)
        {
            string sqlStr = "delete StudentTable where s_Id = " + userId;
            StudentTable.delOrUpTable(sqlStr);
                return StudentTable.getAll(page);
        }
        public List<StudentTable> getAll(string user, int page,string search)
        {
            return StudentTable.getAll(page, search);
        }
        public List<StudentTable> getAll(string user, string userId, int page, string stuName, string Professional, string school, string Phone)
        {
            string sqlStr = "update StudentTable set s_UserName = '" + stuName + "',s_Professional = '" + Professional + "',s_Department = '" + school + "',s_Phone = '" + Phone + "' where s_Id = " + userId;
            StudentTable.delOrUpTable(sqlStr);
            return StudentTable.getAll(page);
        }
        public List<StudentTable> getInfo(string user,out int id)
        {
            return StudentTable.getInfo(user,out id);
        }
        public bool updateInfo(string s_Sex, string s_Address, string s_Department, string s_Professional, string s_Phone, string s_Email, string userName)
        {
            return StudentTable.updateInfo(s_Sex, s_Address, s_Department, s_Professional, s_Phone, s_Email, userName);
        }
        public int rowCount()
        {
           return StudentTable.rowCount();
        }
        public int rowCount(string searchstr)
        {
            return StudentTable.rowCount(searchstr);
        }

    }
}