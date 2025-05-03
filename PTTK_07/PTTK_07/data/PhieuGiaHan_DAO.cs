using System;
using System.Data;
using System.Data.SqlClient;

namespace PTTK_07.Data
{
    public class PhieuGiaHan_DAO
    {
        private string connectionString = "Data Source=LAPTOP-I20CCGIS;Initial Catalog=PTTK_TTLT_ACCI;Integrated Security=True";

        // Kiểm tra MãPDT và MãTS có tồn tại không
        public bool KiemTraMaPDTvaMaTS(string maPDT, string maTS)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM PHIEU_DU_THI WHERE MaPDT = @MaPDT AND MaTS = @MaTS", conn);
                    cmd.Parameters.AddWithValue("@MaPDT", maPDT);
                    cmd.Parameters.AddWithValue("@MaTS", (object)maTS ?? DBNull.Value);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error in KiemTraMaPDTvaMaTS: {ex.Message}");
                    return false;
                }
            }
        }

        public DateTime LayNgayThi(string maPDT)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT ThoiGianThi FROM PHIEU_DU_THI WHERE MaPDT = @MaPDT", conn);
                    cmd.Parameters.AddWithValue("@MaPDT", maPDT);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToDateTime(result) : DateTime.MinValue;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error in LayNgayThi: {ex.Message}");
                    return DateTime.MinValue;
                }
            }
        }

        public string LayMaLT(string maPDT)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT MaLT FROM PHIEU_DU_THI WHERE MaPDT = @MaPDT", conn);
                    cmd.Parameters.AddWithValue("@MaPDT", maPDT);
                    object result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error in LayMaLT: {ex.Message}");
                    return null;
                }
            }
        }

        public (bool, string) KiemTraSoLuongDangKy(string maLT)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT SoLuongToiDa, SoLuongDaDangKy FROM LICH_THI WHERE MaLT = @MaLT", conn);
                    cmd.Parameters.AddWithValue("@MaLT", maLT);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int soLuongToiDa = reader.GetInt32(0);
                        int soLuongDaDangKy = reader.GetInt32(1);
                        if (soLuongDaDangKy >= soLuongToiDa)
                        {
                            return (false, "Số lượng đăng ký đã đạt giới hạn!");
                        }
                        return (true, "Số lượng hợp lệ.");
                    }
                    return (false, "Không tìm thấy lịch thi!");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error in KiemTraSoLuongDangKy: {ex.Message}");
                    return (false, "Lỗi khi kiểm tra số lượng!");
                }
            }
        }

        public (bool, string) ThemYeuCauGiaHan(string maPDT, DateTime ngayGiaHan, string lyDo, decimal phiGiaHan = 0)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    System.Diagnostics.Debug.WriteLine($"Connection opened successfully for maPDT: {maPDT}");

                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO YEU_CAU_GIA_HAN (MaPDT, NgayYeuCauGiaHan, LyDoGiaHan, PhiGiaHan) " +
                        "OUTPUT INSERTED.MaYCGH VALUES (@MaPDT, @NgayYeuCauGiaHan, @LyDoGiaHan, @PhiGiaHan)", conn);
                    cmd.Parameters.AddWithValue("@MaPDT", maPDT);
                    cmd.Parameters.AddWithValue("@NgayYeuCauGiaHan", ngayGiaHan.Date); // Chỉ lấy phần ngày
                    cmd.Parameters.AddWithValue("@LyDoGiaHan", (object)lyDo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PhiGiaHan", (double)phiGiaHan); // Chuyển decimal thành double vì cột là FLOAT

                    string maYCGH = cmd.ExecuteScalar()?.ToString();
                    if (string.IsNullOrEmpty(maYCGH))
                    {
                        System.Diagnostics.Debug.WriteLine("Failed to retrieve MaYCGH after insert.");
                        return (false, null);
                    }

                    System.Diagnostics.Debug.WriteLine($"Inserted YEU_CAU_GIA_HAN with MaYCGH: {maYCGH}");
                    return (true, maYCGH);
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine($"SQL Error in ThemYeuCauGiaHan: {ex.Number} - {ex.Message}");
                    return (false, null);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"General Error in ThemYeuCauGiaHan: {ex.Message}");
                    return (false, null);
                }
            }
        }

        public (bool, string) CapNhatSoLanGiaHan(string maPDT)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE PHIEU_DU_THI_GIA_HAN SET SoLanConLai = SoLanConLai - 1 WHERE MaPDT = @MaPDT AND SoLanConLai > 0", conn);
                    cmd.Parameters.AddWithValue("@MaPDT", maPDT);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        return (false, "Không thể cập nhật số lần gia hạn (số lần còn lại không đủ)!");
                    }
                    return (true, "Cập nhật số lần gia hạn thành công.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error in CapNhatSoLanGiaHan: {ex.Message}");
                    return (false, "Lỗi khi cập nhật số lần gia hạn!");
                }
            }
        }

        public bool CapNhatNgayThi(string maPDT, DateTime ngayGioThiMoi, string maLT)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE PHIEU_DU_THI SET ThoiGianThi = @ThoiGianThi, MaLT = @MaLT WHERE MaPDT = @MaPDT", conn);
                    cmd.Parameters.AddWithValue("@ThoiGianThi", ngayGioThiMoi);
                    cmd.Parameters.AddWithValue("@MaLT", maLT);
                    cmd.Parameters.AddWithValue("@MaPDT", maPDT);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error in CapNhatNgayThi: {ex.Message}");
                    return false;
                }
            }
        }

        public bool TangSoLuongDaDangKy(string maLT)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE LICH_THI SET SoLuongDaDangKy = SoLuongDaDangKy + 1 WHERE MaLT = @MaLT", conn);
                    cmd.Parameters.AddWithValue("@MaLT", maLT);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error in TangSoLuongDaDangKy: {ex.Message}");
                    return false;
                }
            }
        }

        public bool ThemHoaDonGiaHan(string maPDT, string maYCGH, decimal phiGiaHan, string maNVKeToan = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string maHDGH = GenerateMaHDGH();

                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO HOA_DON_GIA_HAN (MaHDGH, NgayGioThanhToan, SoTienThanhToan, HinhThucThanhToan, TrangThai, MaPDT, MaYCGH, MaNVKeToan) " +
                        "VALUES (@MaHDGH, GETDATE(), @SoTienThanhToan, @HinhThucThanhToan, @TrangThai, @MaPDT, @MaYCGH, @MaNVKeToan)", conn);
                    cmd.Parameters.AddWithValue("@MaHDGH", maHDGH);
                    cmd.Parameters.AddWithValue("@SoTienThanhToan", (double)phiGiaHan); // Chuyển thành double vì cột SoTienThanhToan có thể là FLOAT
                    cmd.Parameters.AddWithValue("@HinhThucThanhToan", "Chuyển khoản");
                    cmd.Parameters.AddWithValue("@TrangThai", "Chưa thanh toán");
                    cmd.Parameters.AddWithValue("@MaPDT", maPDT);
                    cmd.Parameters.AddWithValue("@MaYCGH", maYCGH);
                    cmd.Parameters.AddWithValue("@MaNVKeToan", (object)maNVKeToan ?? DBNull.Value);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error in ThemHoaDonGiaHan: {ex.Message}");
                    return false;
                }
            }
        }

        private string GenerateMaHDGH()
        {
            string prefix = $"HDGH_{DateTime.Now:yyyyMMdd}";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM HOA_DON_GIA_HAN WHERE MaHDGH LIKE @Prefix + '%'", conn);
                    cmd.Parameters.AddWithValue("@Prefix", prefix);
                    int count = (int)cmd.ExecuteScalar();
                    return $"{prefix}_{(count + 1):D3}";
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error in GenerateMaHDGH: {ex.Message}");
                    return $"{prefix}_001";
                }
            }
        }
    }
}