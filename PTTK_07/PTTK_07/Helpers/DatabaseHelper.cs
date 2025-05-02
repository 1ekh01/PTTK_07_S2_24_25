using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
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
//            string connStr = @"Data Source=PLASMAPEA;Initial Catalog=PTTK_TTLT_ACCI;Integrated Security=True;Trust Server Certificate=True";
//            string ConnectionString = @"Data Source=LAPTOP-I0V0SQMU\MS_SQLSERVER22;Initial Catalog=PTTK_TTLT_ACCI;Integrated Security=True;Trust Server Certificate=True";
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
        public SqlDataReader SelectFunction(string functionName, string parameterValue)
        {
            try
            {
                // 3. Open connection
                con.Open();

                // 3. Prepare SQL query to call table-valued function
                string query = $"SELECT * FROM {functionName}(@param)";
                SqlCommand cmd = new SqlCommand(query, con);

                // 4. Add parameter to prevent SQL Injection
                cmd.Parameters.AddWithValue("@param", parameterValue);

                // 5. Execute query and return SqlDataReader
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public SqlDataReader SelectFunction2(string functionName, Dictionary<string, object> parameters = null)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                con.Open();

                // Xây dựng câu truy vấn động
                string paramList = parameters != null && parameters.Count > 0
                    ? "(" + string.Join(", ", parameters.Keys) + ")"
                    : "()";

                string query = $"SELECT * FROM {functionName}{paramList}";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    // Thực thi và trả về SqlDataReader
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
            catch (Exception ex)
            {
                // Đóng kết nối nếu còn mở
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                MessageBox.Show($"Lỗi khi gọi hàm SQL {functionName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public bool ExecuteProcedure(string procedureName, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(procedureName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số nếu có
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }

                        // Thực thi PROCEDURE
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public DataTable ExecuteProcedureWithResult(string procedureName, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(procedureName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số nếu có
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }

                        // Thực thi và lấy dữ liệu
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }
    }
}