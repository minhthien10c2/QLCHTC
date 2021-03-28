using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO_NGA;

namespace DAL_NGA
{
    public class Category_DAL
    {
        public DataTable GetAllCategory()
        {
            String query = "SELECT * FROM category";
            return DBConfig.ExecuteGetData(query);
        }

        public DataTable GetCategoryByID(String id)
        {
            int parameterCount = 1;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = id;

            String query = "SELECT * FROM category WHERE id = @id";
            return DBConfig.ExecuteGetData(query, parameterName, parameterValue, parameterCount);
        }

        public bool AddNewCategory(Category_DTO category)
        {
            int parameterCount = 2;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = category.Id;
            parameterName[1] = "@name"; parameterValue[1] = category.CategoryName;

            String query = "INSERT INTO category(id, name) VALUES(@id, @name)";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }

        public bool UpdateCategory(Category_DTO category)
        {

            int parameterCount = 2;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = category.Id;
            parameterName[1] = "@name"; parameterValue[1] = category.CategoryName;

            String query = "UPDATE category SET name = @name WHERE id = @id";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }

        public bool DeleteCategory(String id)
        {
            int parameterCount = 1;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = id;

            String query = "DELETE category WHERE id = @id";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }
    }
}
