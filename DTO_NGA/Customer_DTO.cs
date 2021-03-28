using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_NGA
{
    public class Customer_DTO
    {
        private String ID;
        private String Name;
        private String Gender;
        private int Phone;
        private String Address;

        public String ID1
        {
            get { return ID; }
            set { ID = value; }
        }

        public String Name1
        {
            get { return Name; }
            set { Name = value; }
        }

        public String Gender1
        {
            get { return Gender; }
            set { Gender = value; }
        }

        public int Phone1
        {
            get { return Phone; }
            set { Phone = value; }
        }

        public String Address1
        {
            get { return Address; }
            set { Address = value; }
        }

        public Customer_DTO()
        {
        }

        public Customer_DTO(String id, String name, String gender, int phone, String address)
        {
            this.ID = id;
            this.Name = name;
            this.Gender = gender;
            this.Phone = phone;
            this.Address = address;
        }
    }
}
