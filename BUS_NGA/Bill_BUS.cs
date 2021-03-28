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
    public class Bill_BUS
    {
        Bill_DAL bill_DAL = new Bill_DAL();
        public DataTable GetAllBill()
        {
            return bill_DAL.GetAllBill();
        }

        public DataTable GetBillByID(String id_bill)
        {
            return bill_DAL.GetBillByID(id_bill);
        }

        public bool AddNewBill(Bill_DTO bill)
        {
            return bill_DAL.AddNewBill(bill);
        }

        public bool UpdateBill(Bill_DTO bill)
        {
            return bill_DAL.UpdateBill(bill);
        }

        public bool DeleteBill(String id)
        {
            return bill_DAL.DeleteBill(id);
        }
    }
}
