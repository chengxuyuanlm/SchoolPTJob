using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dal;
using Model;
using System.Data.SqlClient;

namespace Bll
{
    public class PTJobTableBll
    {
        /// <summary>
        /// 获取热门兼职的数据
        /// </summary>
        /// <returns>兼职表的集合</returns>
        public  List<PTJobTable> getHotName()
        {
            return PTJobTable.getHotName();
        }

        public List<PTJob> GetNoHasPTJob()
        {
            return QueryListCondiction(null);
        }
        public List<PTJob> GetHasPTJob()
        {
            return QueryListCondiction2(null);
        }
        private List<PTJob> QueryListCondiction(SqlParameter[] paras)
        {
            return PTJobTable.QueryListCondiction(paras);
        }
        private List<PTJob> QueryListCondiction2(SqlParameter[] paras)
        {
            return PTJobTable.QueryListCondiction2(paras);
        }

        public PTJob GetPTJobById(int pt_id)
        {
            return PTJobTable.GetPTJobById(pt_id);
        }
        public int ptdelete(int id)
        {
            return PTJobTable.ptdelete(id);
        }

        public int ptupdata(string kind, string time, int money, string address, string name, string tel, int need, string State, int id)
        {
            return PTJobTable.ptupdata(kind, time, money, address, name, tel, need, State, id);
        }
        public int ptadd(string kind, string time, int money, string address, string name, string tel, int need, string State, int eid)
        {
            return PTJobTable.ptadd(kind, time, money, address, name, tel, need, State, eid);
        }


        public int GetPTJobNum(int e_id)
        {
            return PTJobTable.GetPTJobNum(e_id);
        }
        public int GetOKPTJobNum(int e_id)
        {
            return PTJobTable.GetOKPTJobNum(e_id);
        }

        public int ptstuupdata(int pt_id)
        {
            return PTJobTable.ptstuupdata(pt_id);
        }
        public List<PTJobTable> GetInfoPT(int empid,string name)
        {
            return PTJobTable.getPtInfo(empid,name);
        }
    }
}