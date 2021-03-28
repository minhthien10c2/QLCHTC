using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO_NGA;

namespace DAL_NGA
{
    public class Account_DAL
    {
        public DataTable CheckAccount(Account_DTO account)
        {
            int parameterCount = 2;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@user_name"; parameterValue[0] = account.UserName1;
            parameterName[1] = "@password"; parameterValue[1] = account.Password1;

            String query = "SELECT * FROM account WHERE user_name = @user_name and password = @password";
            return DBConfig.ExecuteGetData(query, parameterName, parameterValue, parameterCount);
        }

        public DataTable GetAllAccount()
        {
            String query = "SELECT * FROM account";
            return DBConfig.ExecuteGetData(query);
        }

        public DataTable GetAccountByUserName(String user_name)
        {
            int parameterCount = 1;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@user_name"; parameterValue[0] = user_name;

            String query = "SELECT * FROM account WHERE user_name = @user_name";
            return DBConfig.ExecuteGetData(query, parameterName, parameterValue, parameterCount);
        }

        public bool AddNewAccount(Account_DTO account)
        {
            int parameterCount = 7;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@user_name"; parameterValue[0] = account.UserName1;
            parameterName[1] = "@password"; parameterValue[1] = account.Password1;
            parameterName[2] = "@auth"; parameterValue[2] = account.Auth1;
            parameterName[3] = "@name"; parameterValue[3] = account.Name1;
            parameterName[4] = "@gender"; parameterValue[4] = account.Gender1;
            parameterName[5] = "@phone"; parameterValue[5] = account.Phone1;
            parameterName[6] = "@address"; parameterValue[6] = account.Address1;

            String query = "INSERT INTO account(user_name, password, auth, name, gender, phone, address) VALUES(@user_name, @password, @auth, @name, @gender, @phone, @address)";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }

        public bool UpdateAccount(Account_DTO account)
        {

            int parameterCount = 7;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@user_name"; parameterValue[0] = account.UserName1;
            parameterName[1] = "@password"; parameterValue[1] = account.Password1;
            parameterName[2] = "@auth"; parameterValue[2] = account.Auth1;
            parameterName[3] = "@name"; parameterValue[3] = account.Name1;
            parameterName[4] = "@gender"; parameterValue[4] = account.Gender1;
            parameterName[5] = "@phone"; parameterValue[5] = account.Phone1;
            parameterName[6] = "@address"; parameterValue[6] = account.Address1;

            String query = "UPDATE account SET name = @name, auth = @auth, gender = @gender, phone = @phone, address = @address WHERE user_name = @user_name";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }

        public bool ChangePassword(Account_DTO account)
        {
            int parameterCount = 2;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@user_name"; parameterValue[0] = account.UserName1;
            parameterName[1] = "@password"; parameterValue[1] = account.Password1;

            String query = "UPDATE account SET password = @password WHERE user_name = @user_name";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }

        public bool DeleteAccount(String id)
        {
            int parameterCount = 1;
            string[] parameterName = new string[parameterCount];
            object[] parameterValue = new object[parameterCount];

            parameterName[0] = "@id"; parameterValue[0] = id;

            String query = "DELETE account WHERE user_name = @id";
            return DBConfig.ExecuteNonData(query, parameterName, parameterValue, parameterCount);
        }
    }
}
