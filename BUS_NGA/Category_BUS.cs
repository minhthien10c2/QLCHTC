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
    public class Category_BUS
    {
        Category_DAL category_DAL = new Category_DAL();
        public DataTable GetAllCategory()
        {
            return category_DAL.GetAllCategory();
        }

        public DataTable GetCategoryByID(String id)
        {
            return category_DAL.GetCategoryByID(id);
        }

        public bool AddNewCategory(Category_DTO category)
        {
            return category_DAL.AddNewCategory(category);
        }

        public bool UpdateCategory(Category_DTO category)
        {
            return category_DAL.UpdateCategory(category);
        }

        public bool DeleteCategory(String id)
        {
            return category_DAL.DeleteCategory(id);
        }
    }
}
