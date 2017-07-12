using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dal;

namespace Bll
{
    public class ResumeTableBll
    {
        public  List<ResumeTable> getAll(int id)
        {
            return ResumeTable.getAll(id);
        }
        public bool updateInfo(string re_Edu, string re_WorkTime, string re_Skill, string re_Describe, int id)
        {
            return ResumeTable.updateInfo(re_Edu, re_WorkTime, re_Skill, re_Describe, id);
        }
    }
}