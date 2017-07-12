using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dal;

namespace Bll
{
    public class PTandCompanyBll
    {
        /// <summary>
        /// 获取公司信息和其发布的兼职信息
        /// </summary>
        /// <returns></returns>
        public  List<PTandCompany> getHotName()
        {
            return PTandCompany.getHotName();
        }
        /// <summary>
        /// 获取查询筛选数据
        /// </summary>
        /// <param name="hotName">关键字</param>
        /// <param name="page">分页参数</param>
        /// <param name="sort">排序参数</param>
        /// <param name="money">工资筛选参数</param>
        /// <param name="num">需求筛选参数</param>
        /// <param name="type">类型筛选参数</param>
        /// <returns></returns>
        public List<PTandCompany> SearchData(string hotName, int page, int sort, int money, int num, int type)
        {
            string sql = getSearchSql(hotName, page, sort, money, num, type);
            return PTandCompany.SearchData(sql, page);
        }
        /// <summary>
        /// 获取总数据的条数
        /// </summary>
        /// <param name="hotName">关键字</param>
        /// <param name="page">分页参数</param>
        /// <param name="sort">排序参数</param>
        /// <param name="money">工资筛选参数</param>
        /// <param name="num">需求筛选参数</param>
        /// <param name="type">类型筛选参数</param>
        /// <returns></returns>
        public int rowCount(string hotName, int page, int sort, int money, int num, int type)
        {
            string sql = getSearchSql(hotName, page, sort, money, num, type);
            return PTandCompany.rowCount(sql);
        }
        /// <summary>
        /// 拼接查询筛选语句
        /// </summary>
        /// <param name="hotName">关键字</param>
        /// <param name="page">分页参数</param>
        /// <param name="sort">排序参数</param>
        /// <param name="money">工资筛选参数</param>
        /// <param name="num">需求筛选参数</param>
        /// <param name="type">类型筛选参数</param>
        /// <returns></returns>
        public string getSearchSql(string hotName, int page, int sort, int money,int num,int type)
        {
            string searchSql = "";
            string sortSql = " order by pt_State desc ,pt_ReleaseTime desc";
            if (hotName != "")
                searchSql += " and pt_Name like '%" + hotName + "%'";
            switch(money)
            {
                case 1: searchSql += ""; break;
                case 2: searchSql += " and pt.pt_Money<30"; break;
                case 3: searchSql += " and pt.pt_Money>=30 and pt.pt_Money<50"; break;
                case 4: searchSql += " and pt.pt_Money>=50 and pt.pt_Money<70"; break;
                case 5: searchSql += " and pt.pt_Money>=70 and pt.pt_Money<=100"; break;
                case 6: searchSql += " and pt.pt_Money>100"; break;
            }
            switch (num)
            {
                case 1: searchSql += ""; break;
                case 2: searchSql += " and pt.pt_Need<5"; break;
                case 3: searchSql += " and pt.pt_Need>=5 and pt.pt_Need<10"; break;
                case 4: searchSql += " and pt.pt_Need>=10 and pt.pt_Need<15"; break;
                case 5: searchSql += " and pt.pt_Need>=15 and pt.pt_Need<=20"; break;
                case 6: searchSql += " and pt.pt_Need>20"; break;
            }
            switch (type)
            {
                case 1: searchSql += ""; break;
                case 2: searchSql += " and pt.pt_Kind='专业兼职'"; break;
                case 3: searchSql += " and pt.pt_Kind='长期兼职'"; break;
                case 4: searchSql += " and pt.pt_Kind='周末兼职'"; break;
                case 5: searchSql += " and pt.pt_Kind='临时兼职'"; break;
                case 6: searchSql += " and pt.pt_Kind='其他兼职'"; break;
            }
            switch (sort)
            {
                case 0: sortSql = " order by pt_State desc ,pt_ReleaseTime desc"; break;
                case 1: sortSql = " order by pt_ReleaseTime desc"; break;
                case 2: sortSql = " order by pt_State desc"; break;
            }
            return searchSql + sortSql;
        }
        public List<PTandCompany> getPass(int userId)
        {
            return PTandCompany.getPass(userId);
        }
    }
    
}