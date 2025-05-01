using System;
using System.Data;
using System.Data.SqlClient;

namespace PTTK_07.Data
{
    public class Lich_DAO
    {
        private string connectionString = "Data Source=LAPTOP-I20CCGIS;Initial Catalog=PTTK_TTLT_ACCI;Integrated Security=True";

        public DataTable LayLichTheoNgay(DateTime ngay)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT MaLT, NgayGioThi, SoLuongToiDa, SoLuongDaDangKy, LoaiChungChi, MaPT " +
                                                    "FROM LICH_THI " +
                                                    "WHERE CAST(NgayGioThi AS DATE) = @NgayThi", conn);
                    cmd.Parameters.AddWithValue("@NgayThi", ngay.Date);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return new DataTable();
                }
            }
        }
    }
}