using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NimapInfotechMachineTest.SqlDbConnection
{
    public class Connection
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlConnection sqlcon = null;
        public static string connectionString = @"Data Source=DESKTOP-BC3BEGT;Initial Catalog=DB_Nimap_MachineTest;User ID=sa;Password=Game@123";

        public SqlConnection Connect()
        {
            try
            {

                sqlcon = new SqlConnection(connectionString);
                sqlcon.Close();
                if (sqlcon.State == ConnectionState.Open)
                    sqlcon.Close();
                sqlcon.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sqlcon;
        }
        public DataTable GetData(string query)
        {
            DataTable dt = new DataTable();

            sqlcon = Connect();
            cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            da = new SqlDataAdapter(query, sqlcon);
            da.Fill(dt);
            return dt;
        }
    }
}