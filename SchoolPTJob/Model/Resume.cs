using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Resume
    {
        public int re_Id { get; set; }
        public int re_UserId { get; set; }
        public string re_Edu { get; set; }
        public string re_WorkTime { get; set; }
        public string re_Skill { get; set; }
        public string re_Describe { get; set; }

        private Student re_Student;

        public Student Re_Student
        {
            get { return re_Student; }
            set { re_Student = value; }
        }

    }
}
