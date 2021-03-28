using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO_NGA;

namespace DAL_NGA
{
    public class Product_DAL
    {
        public DataTable GetAllProduct()
        {
            String query = "SELECT pd.*, ct.name as category_name FROM product pd, category ct WHERE pd.id_category = ct.id";
            return DBConfig.ExecuteGetData(query);
        }

        public DataTable GetProductByID(String id)
        {
            int parameterCount = 1;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = id;

            String query = "SELECT * FROM product WHERE id = @id";
            return DBConfig.ExecuteGetData(query, parameterName, parameterValue, parameterCount);
        }

        public DataTable GetProductByIDCategory(String id)
        {
            int parameterCount = 1;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = id;

            String query = "SELECT * FROM product WHERE id_category = @id";
            return DBConfig.ExecuteGetData(query, parameterName, parameterValue, parameterCount);
        }

        public bool AddNewProduct(Product_DTO product)
        {
            int parameterCount = 4;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = product.Id;
            parameterName[1] = "@name"; parameterValue[1] = product.ProductName;
            parameterName[2] = "@price"; parameterValue[2] = product.ProductPrice;
            parameterName[3] = "@id_category"; parameterValue[3] = product.IdCategory;

            String query = "INSERT INTO product(id, name, price, id_category) VALUES(@id, @name, @price, @id_category)";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }

        public bool UpdateProduct(Product_DTO product)
        {

            int parameterCount = 4;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = product.Id;
            parameterName[1] = "@name"; parameterValue[1] = product.ProductName;
            parameterName[2] = "@price"; parameterValue[2] = product.ProductPrice;
            parameterName[3] = "@id_category"; parameterValue[3] = product.IdCategory;

            String query = "UPDATE product SET name = @name, price = @price, id_category = @id_category WHERE id = @id";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }

        public bool DeleteProduct(String id)
        {
            int parameterCount = 1;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = id;

            String query = "DELETE product WHERE id = @id";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }
    }
}
