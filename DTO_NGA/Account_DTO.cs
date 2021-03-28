using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_NGA
{
    public class Account_DTO
    {
        private String UserName;
        private String Password;
        private String Auth;
        private String Name;
        private String Gender;
        private int Phone;
        private String Address;

        public String UserName1
        {
            get { return UserName; }
            set { UserName = value; }
        }

        public String Password1
        {
            get { return Password; }
            set { Password = value; }
        }

        public String Auth1
        {
            get { return Auth; }
            set { Auth = value; }
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

        public Account_DTO()
        {
        }

        public Account_DTO(String username, String password, String auth, String name, String gender, int phone, String address)
        {
            this.UserName = username;
            this.Password = password;
            this.Auth = auth;
            this.Name = name;
            this.Gender = gender;
            this.Phone = phone;
            this.Address = address;
        }
    }
}
