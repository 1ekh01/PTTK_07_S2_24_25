using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace PTTK_07.data
{
    public class Lich_DAO
    {
        //private string connectionString = "Data Source=LAPTOP-I20CCGIS;Initial Catalog=PTTK_TTLT_ACCI;Integrated Security=True";
        private string connectionString = "Data Source=PLASMAPEA;Initial Catalog=PTTK_TTLT_ACCI;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public bool KiemTraLichThi(DateTime ngayThi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM LICH_THI WHERE CAST(NgayGioThi AS DATE) = @NgayThi", conn);
                    cmd.Parameters.AddWithValue("@NgayThi", ngayThi.Date);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error in KiemTraLichThi: {ex.Message}");
                    return false;
                }
            }
        }

        public DataTable LayLichTheoNgay(DateTime ngayThi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT MaLT, NgayGioThi, SoLuongToiDa, SoLuongDaDangKy, LoaiChungChi, MaPT " +
                        "FROM LICH_THI WHERE CAST(NgayGioThi AS DATE) = @NgayThi", conn);
                    cmd.Parameters.AddWithValue("@NgayThi", ngayThi.Date);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt.Rows.Count > 0 ? dt : null;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error in LayLichTheoNgay: {ex.Message}");
                    return null;
                }
            }
        }

        public string LayLoaiChungChi(string maLT)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT LoaiChungChi FROM LICH_THI WHERE MaLT = @MaLT", conn);
                    cmd.Parameters.AddWithValue("@MaLT", maLT);

                    object result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error in LayLoaiChungChi: {ex.Message}");
                    return null;
                }
            }
        }
    }
}
