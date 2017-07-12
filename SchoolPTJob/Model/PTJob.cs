using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PTJob
    {
        public int pt_Id { get; set; }
        public string pt_Kind { get; set; }
        public string pt_Time { get; set; }
        public int pt_eId { get; set; }
        public int pt_Money { get; set; }
        public string pt_Address { get; set; }
        public string pt_Tel { get; set; }
        public string pt_State { get; set; }
        public string pt_ReleaseTime { get; set; }
        public int pt_StuId { get; set; }
        public int pt_Need { get; set; }
        public string pt_Name { get; set; }

        private Employee pt_employee;

        private Student pt_student;

        public Student Pt_student
        {
            get { return pt_student; }
            set { pt_student = value; }
        }

        public Employee Pt_employee
        {
            get { return pt_employee; }
            set { pt_employee = value; }
        }



    }
}
