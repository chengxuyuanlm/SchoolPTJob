using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Delivery
    {
        public int RE_Id { get; set; }
        public int DE_Id { get; set; }
        public int PT_Id { get; set; }
        public string RE_Pass { get; set; }
        public DateTime DE_Time { get; set; }

        private PTJob dE_PTJob;

        public PTJob DE_PTJob
        {
            get { return dE_PTJob; }
            set { dE_PTJob = value; }
        }
        private Resume dE_Resume;

        public Resume DE_Resume
        {
            get { return dE_Resume; }
            set { dE_Resume = value; }
        }
    }
}
