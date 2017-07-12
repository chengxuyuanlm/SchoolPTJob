using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bll
{
    public class DeliveryTableBll
    {
        public List<Delivery> getDelivery(int e_id)
        {
            return DeliveryTable.getDelivery(e_id);
        }

        public int deupdata(string re_pass, int de_id)
        {
            return DeliveryTable.deupdata(re_pass, de_id);
        }

        public void insertDeliverybll(string user,int ptid)
        {
            DeliveryTable.insertdata(user,ptid);
        }
    }
}