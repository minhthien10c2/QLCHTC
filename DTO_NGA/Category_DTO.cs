using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_NGA
{
    public class Category_DTO
    {
        private String id;
        private String categoryName;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public String CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }

        public Category_DTO()
        { }

        public Category_DTO(String id, String categoryname)
        {
            this.id = id;
            this.categoryName = categoryname;
        }
    }
}
