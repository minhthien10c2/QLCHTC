using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO_NGA;

namespace DAL_NGA
{
    public class Customer_DAL
    {
        public DataTable GetAllCustomer()
        {
            String query = "SELECT * FROM customer";
            return DBConfig.ExecuteGetData(query);
        }

        public DataTable GetCustomerByID(String id)
        {
            int parameterCount = 1;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = id;

            String query = "SELECT * FROM customer WHERE id = @id";
            return DBConfig.ExecuteGetData(query, parameterName, parameterValue, parameterCount);
        }

        public bool AddNewCustomer(Customer_DTO customer)
        {
            int parameterCount = 5;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = customer.ID1;
            parameterName[1] = "@name"; parameterValue[1] = customer.Name1;
            parameterName[2] = "@gender"; parameterValue[2] = customer.Gender1;
            parameterName[3] = "@phone"; parameterValue[3] = customer.Phone1;
            parameterName[4] = "@address"; parameterValue[4] = customer.Address1;

            String query = "INSERT INTO customer(id, name, gender, phone, address) VALUES(@id, @name, @gender, @phone, @address)";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }

        public bool UpdateCustomer(Customer_DTO customer)
        {
            int parameterCount = 5;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = customer.ID1;
            parameterName[1] = "@name"; parameterValue[1] = customer.Name1;
            parameterName[2] = "@gender"; parameterValue[2] = customer.Gender1;
            parameterName[3] = "@phone"; parameterValue[3] = customer.Phone1;
            parameterName[4] = "@address"; parameterValue[4] = customer.Address1;

            String query = "UPDATE customer SET name = @name, gender = @gender, phone = @phone, address = @address WHERE id = @id";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }

        public bool DeleteCustomer(String id)
        {
            int parameterCount = 1;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = id;

            String query = "DELETE customer WHERE id = @id";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }
    }
}
