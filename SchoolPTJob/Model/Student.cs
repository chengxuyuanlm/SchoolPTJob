using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Student
    {
        public int s_Id { get; set; }
        public string s_UserName { get; set; }
        public string s_Password { get; set; }
        public string s_PhotoPath { get; set; }
        public string s_RealName { get; set; }
        public string s_Sex { get; set; }
        public string s_Department { get; set; }
        public string s_Professional { get; set; }
        public string s_Phone { get; set; }
        public string s_Address { get; set; }
        public string s_Email { get; set; }
        public DateTime s_RegTime { get; set; }
        public string s_IdCard { get; set; }
        public bool IsReturn { get; set; }
    }
}
