using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_NGA
{
    public class Bill_DTO
    {
        private String id;
        private double totalPrice;
        private DateTime dateCreate;
        private String idCustomer;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime DateCreate
        {
            get { return dateCreate; }
            set { dateCreate = value; }
        }

        public double TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public String IdCustomer
        {
            get { return idCustomer; }
            set { idCustomer = value; }
        }

        public Bill_DTO()
        {

        }

        public Bill_DTO(String id, DateTime datecreate, double totalprice, String idcustomer)
        {
            this.id = id;
            this.dateCreate = datecreate;
            this.totalPrice = totalprice;
            this.idCustomer = idcustomer;
        }
    }
}
