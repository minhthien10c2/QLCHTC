using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO_NGA;

namespace DAL_NGA
{
    public class Bill_Detail_DAL
    {
        public DataTable GetAllBill_Detail()
        {
            String query = "SELECT * FROM bill_detail";
            return DBConfig.ExecuteGetData(query);
        }

        public DataTable GetBill_DetailByID(String id_bill)
        {
            int parameterCount = 1;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id_bill"; parameterValue[0] = id_bill;

            String query = "SELECT * FROM bill_detail WHERE id_bill = @id_bill";
            return DBConfig.ExecuteGetData(query, parameterName, parameterValue, parameterCount);
        }

        public bool AddNewBill_Detail(Bill_Detail_DTO bill_detail)
        {
            int parameterCount = 3;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id_bill"; parameterValue[0] = bill_detail.IdBill;
            parameterName[1] = "@id_product"; parameterValue[1] = bill_detail.IdProduct;
            parameterName[2] = "@quantity"; parameterValue[2] = bill_detail.Quantity;

            String query = "INSERT INTO bill_detail(id_bill, id_product, quantity) VALUES (@id_bill, @id_product, @quantity)";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }

        public bool UpdateBill_Detail(Bill_Detail_DTO bill_detail)
        {

            int parameterCount = 3;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id_bill"; parameterValue[0] = bill_detail.IdBill;
            parameterName[1] = "@id_product"; parameterValue[1] = bill_detail.IdProduct;
            parameterName[2] = "@quantity"; parameterValue[2] = bill_detail.Quantity;

            String query = "UPDATE bill_detail SET id_bill = @id_bill, id_product = @id_product WHERE id = @id";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }

        public bool DeleteBill_Detail(String id)
        {
            int parameterCount = 1;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = id;

            String query = "DELETE bill_detail WHERE id_bill = @id";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }
    }
}
