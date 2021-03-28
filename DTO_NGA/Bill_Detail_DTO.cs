using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_NGA
{
    public class Bill_Detail_DTO
    {
        private String idProduct;
        private String idBill;
        private int quantity;

        public String IdProduct
        {
            get { return idProduct; }
            set { idProduct = value; }
        }

        public String IdBill
        {
            get { return idBill; }
            set { idBill = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public Bill_Detail_DTO()
        {

        }

        public Bill_Detail_DTO(String idproduct, String idbill, int quantity)
        {
            this.idProduct = idproduct;
            this.idBill = idbill;
            this.Quantity = quantity;
        }
    }
}
