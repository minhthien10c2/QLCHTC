using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_NGA
{
    class DBConfig
    {
        public static SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QLCHTC;Integrated Security=True");
            conn.Open();
            return conn;
        }

        public static DataTable ExecuteGetData(string queryString)
        {
            SqlConnection conn = Connect();

            SqlDataAdapter da = new SqlDataAdapter(queryString, conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }

        public static DataTable ExecuteGetData(string queryString, string[] parameterName, object[] parameterValue, int parameterCount)
        {
            SqlConnection conn = Connect();

            SqlCommand cmd = new SqlCommand(queryString, conn);
            for (int i = 0; i < parameterCount; i++)
            {
                cmd.Parameters.AddWithValue(parameterName[i], parameterValue[i]);
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }

        public static bool ExecuteNonData(string queryString)
        {
            SqlConnection conn = Connect();

            SqlCommand cmd = new SqlCommand(queryString, conn);

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ExecuteNonData(string queryString, string[] parameterName, object[] parameterValue, int parameterCount)
        {
            SqlConnection conn = Connect();

            SqlCommand cmd = new SqlCommand(queryString, conn);
            for (int i = 0; i < parameterCount; i++)
            {
                cmd.Parameters.AddWithValue(parameterName[i], parameterValue[i]);
            }

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
