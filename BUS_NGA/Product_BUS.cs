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
    public class Product_BUS
    {
        Product_DAL product_DAL = new Product_DAL();
        public DataTable GetAllProduct()
        {
            return product_DAL.GetAllProduct();
        }

        public DataTable GetProductByID(String id)
        {
            return product_DAL.GetProductByID(id);
        }

        public DataTable GetProductByIDCategory(String id)
        {
            return product_DAL.GetProductByIDCategory(id);
        }

        public bool AddNewProduct(Product_DTO product)
        {
            return product_DAL.AddNewProduct(product);
        }

        public bool UpdateProduct(Product_DTO product)
        {
            return product_DAL.UpdateProduct(product);
        }

        public bool DeleteProduct(String id)
        {
            return product_DAL.DeleteProduct(id);
        }
    }
}
