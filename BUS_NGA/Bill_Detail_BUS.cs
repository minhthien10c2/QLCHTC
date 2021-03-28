using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO_NGA;
using DAL_NGA;

namespace BUS_NGA
{
    public class Bill_Detail_BUS
    {
        Bill_Detail_DAL bill_detail_DAL = new Bill_Detail_DAL();
        public DataTable GetAllBill_Detail()
        {
            return bill_detail_DAL.GetAllBill_Detail();
        }

        public DataTable GetBill_DetailByID(String id)
        {
            return bill_detail_DAL.GetBill_DetailByID(id);
        }

        public bool AddNewBill_Detail(Bill_Detail_DTO bill_detail)
        {
            return bill_detail_DAL.AddNewBill_Detail(bill_detail);
        }

        public bool UpdateBill_Detail(Bill_Detail_DTO bill_detail)
        {
            return bill_detail_DAL.UpdateBill_Detail(bill_detail);
        }

        public bool DeleteBill_Detail(String id)
        {
            return bill_detail_DAL.DeleteBill_Detail(id);
        }
    }
}
