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
    public class Customer_BUS
    {
        Customer_DAL customer_DAL = new Customer_DAL();
        public DataTable GetAllCustomer()
        {
            return customer_DAL.GetAllCustomer();
        }

        public DataTable GetCustomerByID(String id)
        {
            return customer_DAL.GetCustomerByID(id);
        }

        public bool AddNewCustomer(Customer_DTO customer)
        {
            return customer_DAL.AddNewCustomer(customer);
        }

        public bool UpdateCustomer(Customer_DTO customer)
        {
            return customer_DAL.UpdateCustomer(customer);
        }

        public bool DeleteCustomer(String id)
        {
            return customer_DAL.DeleteCustomer(id);
        }
    }
}
