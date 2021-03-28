using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_NGA
{
    public class Product_DTO
    {
        private String id;
        private String productName;
        private float productPrice;
        private String idCategory;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public String ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public float ProductPrice
        {
            get { return productPrice; }
            set { productPrice = value; }
        }

        public String IdCategory
        {
            get { return idCategory; }
            set { idCategory = value; }
        }

        public Product_DTO()
        {

        }

        public Product_DTO(String id, String productname, float productprice, String idCategory)
        {
            this.id = id;
            this.productName = productname;
            this.productPrice = productprice;
            this.idCategory = idCategory;
        }
    }
}
