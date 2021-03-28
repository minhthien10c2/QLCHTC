using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO_NGA;

namespace DAL_NGA
{
    public class Bill_DAL
    {
        public DataTable GetAllBill()
        {
            String query = "SELECT bill.*, customer.name FROM bill, customer where bill.id_customer = customer.id";
            return DBConfig.ExecuteGetData(query);
        }

        public DataTable GetBillByID(String id)
        {
            int parameterCount = 1;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = id;

            String query = "SELECT * FROM bill WHERE id = @id";
            return DBConfig.ExecuteGetData(query, parameterName, parameterValue, parameterCount);
        }

        public bool AddNewBill(Bill_DTO bill)
        {
            int parameterCount = 4;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = bill.Id;
            parameterName[1] = "@date_create"; parameterValue[1] = bill.DateCreate;
            parameterName[2] = "@total_price"; parameterValue[2] = bill.TotalPrice;
            parameterName[3] = "@id_customer"; parameterValue[3] = bill.IdCustomer;

            String query = "INSERT INTO bill(id, date_create, total_price, id_customer) VALUES (@id, @date_create, @total_price, @id_customer)";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }

        public bool UpdateBill(Bill_DTO bill)
        {

            int parameterCount = 4;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = bill.Id;
            parameterName[1] = "@date_create"; parameterValue[1] = bill.DateCreate;
            parameterName[2] = "@total_price"; parameterValue[2] = bill.TotalPrice;
            parameterName[3] = "@id_customer"; parameterValue[3] = bill.IdCustomer;

            String query = "UPDATE bill SET total_price = @total_price, id_customer = @id_customer WHERE id = @id";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }

        public bool DeleteBill(String id)
        {
            int parameterCount = 1;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = id;

            String query = "DELETE bill WHERE id = @id";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }
    }
}
