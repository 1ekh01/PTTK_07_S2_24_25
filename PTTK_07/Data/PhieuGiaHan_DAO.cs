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
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM PHIEU_DU_THI WHERE MaPDT = @MaPDT AND MaTS = @MaTS", conn);
                    cmd.Parameters.AddWithValue("@MaPDT", maPDT);
                    cmd.Parameters.AddWithValue("@MaTS", maTS);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        // Lấy ngày thi từ PHIEU_DU_THI
        public DateTime LayNgayThi(string maPDT)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT ThoiGianThi FROM PHIEU_DU_THI WHERE MaPDT = @MaPDT", conn);
                    cmd.Parameters.AddWithValue("@MaPDT", maPDT);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToDateTime(result) : DateTime.MinValue;
                }
                catch
                {
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
                    SqlCommand cmd = new SqlCommand("SELECT MaLT FROM PHIEU_DU_THI WHERE MaPDT = @MaPDT", conn);
                    cmd.Parameters.AddWithValue("@MaPDT", maPDT);
                    object result = cmd.ExecuteScalar();
                    return result?.ToString();
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
                        "SELECT SoLuongDaDangKy, SoLuongToiDa FROM LICH_THI WHERE MaLT = @MaLT", conn);
                    cmd.Parameters.AddWithValue("@MaLT", maLT);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int soLuongDaDangKy = reader.GetInt32(0);
                        int soLuongToiDa = reader.GetInt32(1);
                        if (soLuongDaDangKy >= soLuongToiDa)
                        {
                            return (false, "Lịch thi đã đầy!");
                        }
                        return (true, "Số lượng đăng ký hợp lệ.");
                    }
                    return (false, "Không tìm thấy lịch thi!");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error in KiemTraSoLuongDangKy: {ex.Message}");
                    return (false, $"Lỗi khi kiểm tra số lượng đăng ký: {ex.Message}");
                }
            }
        }

        // Lấy số lần gia hạn từ PHIEU_DU_THI_GIAHAN
        public int LaySoLanGiaHan(string maPDT)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT SoLanConLai FROM PHIEU_DU_THI_GIA_HAN WHERE MaPDT = @MaPDT", conn);
                    cmd.Parameters.AddWithValue("@MaPDT", maPDT);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
                catch
                {
                    return -1;
                }
            }
        }

        // Thêm yêu cầu gia hạn vào YEU_CAU_GIA_HAN
        public bool ThemYeuCauGiaHan(string maPDT, DateTime ngayGiaHan, string lyDo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Chèn bản ghi mới vào YEU_CAU_GIA_HAN
                    // Bỏ qua ID và MaYCGH vì chúng được tạo tự động
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO YEU_CAU_GIA_HAN (MaPDT, NgayYeuCauGiaHan, LyDoGiaHan, PhiGiaHan) " +
                        "VALUES (@MaPDT, @NgayGiaHan, @LyDo, 0)", conn);
                    cmd.Parameters.AddWithValue("@MaPDT", maPDT);
                    cmd.Parameters.AddWithValue("@NgayGiaHan", ngayGiaHan);
                    cmd.Parameters.AddWithValue("@LyDo", lyDo);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Thêm log lỗi để kiểm tra
                    System.Diagnostics.Debug.WriteLine($"Error in ThemYeuCauGiaHan: {ex.Message}");
                    return false;
                }
            }
        }


        public (bool, string) CapNhatSoLanGiaHan(string maPDT)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(maPDT))
            {
                System.Diagnostics.Debug.WriteLine("Error in CapNhatSoLanGiaHan: MaPDT is empty.");
                return (false, "Mã PDT không được để trống!");
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    System.Diagnostics.Debug.WriteLine("Connection successful!");

                    // Bước 1: Lấy giá trị SoLanConLai hiện tại
                    SqlCommand selectCmd = new SqlCommand(
                        "SELECT SoLanConLai FROM PHIEU_DU_THI_GIA_HAN WHERE MaPDT = @MaPDT", conn);
                    selectCmd.Parameters.AddWithValue("@MaPDT", maPDT);
                    object result = selectCmd.ExecuteScalar();

                    if (result == null)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error in CapNhatSoLanGiaHan: MaPDT = {maPDT} not found.");
                        return (false, "Không tìm thấy thông tin gia hạn của phiếu dự thi!");
                    }

                    int soLanConLai = Convert.ToInt32(result);
                    if (soLanConLai <= 0)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error in CapNhatSoLanGiaHan: SoLanConLai <= 0 for MaPDT = {maPDT}.");
                        return (false, "Số lần gia hạn đã hết!");
                    }

                    // Bước 2: Cập nhật SoLanConLai
                    SqlCommand updateCmd = new SqlCommand(
                        "UPDATE PHIEU_DU_THI_GIA_HAN SET SoLanConLai = SoLanConLai - 1 WHERE MaPDT = @MaPDT", conn);
                    updateCmd.Parameters.AddWithValue("@MaPDT", maPDT);

                    int rowsAffected = updateCmd.ExecuteNonQuery();
                    if (rowsAffected <= 0)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error in CapNhatSoLanGiaHan: No rows updated for MaPDT = {maPDT}.");
                        return (false, "Lỗi khi cập nhật số lần gia hạn!");
                    }

                    return (true, "Cập nhật số lần gia hạn thành công!");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error in CapNhatSoLanGiaHan: {ex.Message}");
                    return (false, $"Lỗi khi cập nhật số lần gia hạn: {ex.Message}");
                }
            }
        }

        public bool CapNhatNgayThi(string maPDT, DateTime ngayThiMoi, string maLT)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(maPDT))
            {
                System.Diagnostics.Debug.WriteLine("Error in CapNhatNgayThi: MaPDT is empty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(maLT))
            {
                System.Diagnostics.Debug.WriteLine("Error in CapNhatNgayThi: MaLT is empty.");
                return false;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    System.Diagnostics.Debug.WriteLine("Connection successful!");

                    SqlCommand cmd = new SqlCommand(
                        "UPDATE PHIEU_DU_THI SET ThoiGianThi = @NgayThi, MaLT = @MaLT WHERE MaPDT = @MaPDT", conn);
                    cmd.Parameters.AddWithValue("@NgayThi", ngayThiMoi);
                    cmd.Parameters.AddWithValue("@MaLT", maLT);
                    cmd.Parameters.AddWithValue("@MaPDT", maPDT);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected <= 0)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error in CapNhatNgayThi: No rows updated for MaPDT = {maPDT}.");
                    }

                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error in CapNhatNgayThi: {ex.Message}");
                    return false;
                }
            }
        }
        // Tăng số lượng đã đăng ký trong LICH_THI
        public bool TangSoLuongDaDangKy(string maLT)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE LICH_THI SET SoLuongDaDangKy = SoLuongDaDangKy + 1 WHERE MaLT = @MaLT", conn);
                    cmd.Parameters.AddWithValue("@MaLT", maLT);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}