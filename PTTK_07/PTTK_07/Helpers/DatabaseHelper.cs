using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
// using System.Data.SqlClient;

namespace PTTK_07.Helpers
//{
//    public static class DatabaseHelper
//    {
//        public static SqlConnection Connection { get; private set; }

//        //public static bool Connect(string username, string password)
//        public static bool Connect()
//        {
//            string connStr = @"Data Source=PLASMAPEA;Initial Catalog=PTTK_TTLT_ACCI;Integrated Security=True;Trust Server Certificate=True";

//            try
//            {
//                Connection = new SqlConnection(connStr);
//                Connection.Open();
//                return true;
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Connection failed: " + ex.Message);
//                return false;
//            }
//        }

//        public static void Disconnect()
//        {
//            if (Connection != null && Connection.State == ConnectionState.Open)
//            {
//                Connection.Close();
//                Connection.Dispose();
//            }
//        }
//    }
//}
{
    class DB
    {
        //1.Address of SQL server and database(Connection String)
        string ConnectionString = @"Data Source=LAPTOP-I0V0SQMU\MS_SQLSERVER22;Initial Catalog=PTTK_TTLT_ACCI;Integrated Security=True;Trust Server Certificate=True";
        //2.Establish connection(c# sqlconnection class)
        SqlConnection con = null;

        public DB()
        {
            con = new SqlConnection(ConnectionString);
        }

        public void Execute(string Query)
        {
            try
            {
                //3.Open connection(c# sqlconnection open)
                con.Open();

                //4.Prepare SQL query
                SqlCommand cmd = new SqlCommand(Query, con);

                //5.Execute query(c# sqlcommand class)
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                //6.Close connection(c# sqlconnection close)
                con.Close();
            }
        }

        public SqlDataReader Select(string Query)
        {
            try
            {
                //3.Open connection(c# sqlconnection open)
                con.Open();

                //4.Prepare SQL query
                SqlCommand cmd = new SqlCommand(Query, con);

                //5.Execute query(c# sqlcommand class)
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }
    }
}