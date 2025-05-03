using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PTTK_07.Data
{
    public class PhieuGiaHan_DAO
    {
        private string connectionString = "Data Source=LAPTOP-I20CCGIS;Initial Catalog=PTTK_TTLT_ACCI;Integrated Security=True";
        public List<string> LayDanhSachMaPDT()
        {
            List<string> maPDTList = new List<string>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT MaPDT FROM PHIEU_DU_THI", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        maPDTList.Add(reader["MaPDT"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error in LayDanhSachMaPDT: {ex.Message}");
                }
            }
            return maPDTList;
        }

        // Phương thức kiểm tra và thêm PHIEU_DU_THI_GIA_HAN
        public bool KiemTraVaThemPhieuDuThiGiaHan(string maPDT)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.sp_KiemTraVaThemPhieuDuThiGiaHan", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaPDT", maPDT);
                    SqlParameter resultParam = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(resultParam);
                    cmd.ExecuteNonQuery();
                    bool result = (bool)resultParam.Value;
                    return result;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error in KiemTraVaThemPhieuDuThiGiaHan: {ex.Message}");
                    return false;
                }
            }
        }

        // Phương thức xử lý vòng lặp để kiểm tra và thêm cho tất cả MaPDT
        public void KiemTraVaThemTatCaPhieuDuThiGiaHan()
        {
            List<string> maPDTList = LayDanhSachMaPDT();
            foreach (string maPDT in maPDTList)
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine($"Đang xử lý MaPDT: {maPDT}");
                    bool result = KiemTraVaThemPhieuDuThiGiaHan(maPDT);
                    System.Diagnostics.Debug.WriteLine($"Kết quả cho MaPDT {maPDT}: {(result ? "Thêm thành công" : "Đã tồn tại")}");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Lỗi khi xử lý MaPDT {maPDT}: {ex.Message}");
                }
            }
        }

        // Phương thức mới: Lấy danh sách ngày thi khả thi và MaLT dựa trên LoaiChungChi và điều kiện
        public List<(DateTime NgayGioThi, string MaLT)> LayDanhSachNgayThiKhaThi(string maPDT, DateTime ngayGiaHan)
        {
            List<(DateTime NgayGioThi, string MaLT)> ngayThiList = new List<(DateTime, string)>();
            DateTime ngayHienTai = DateTime.Now;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Lấy MaLT và LoaiChungChi từ PHIEU_DU_THI
                    string maLTHienTai = LayMaLT(maPDT);
                    if (string.IsNullOrEmpty(maLTHienTai))
                    {
                        System.Diagnostics.Debug.WriteLine("No MaLT found for MaPDT: " + maPDT);
                        return ngayThiList;
                    }

                    string loaiChungChiQuery = @"
                        SELECT lt.LoaiChungChi
                        FROM LICH_THI lt
                        JOIN PHIEU_DU_THI pdt ON pdt.MaLT = lt.MaLT
                        WHERE pdt.MaPDT = @MaPDT";
                    SqlCommand cmdLoaiCC = new SqlCommand(loaiChungChiQuery, conn);
                    cmdLoaiCC.Parameters.AddWithValue("@MaPDT", maPDT);
                    string loaiChungChi = cmdLoaiCC.ExecuteScalar()?.ToString();

                    if (string.IsNullOrEmpty(loaiChungChi))
                    {
                        System.Diagnostics.Debug.WriteLine("No LoaiChungChi found for MaPDT: " + maPDT);
                        return ngayThiList;
                    }

                    // Lấy danh sách NgayGioThi và MaLT từ LICH_THI dựa trên LoaiChungChi
                    string ngayThiQuery = @"
                        SELECT MaLT, NgayGioThi
                        FROM LICH_THI
                        WHERE LoaiChungChi = @LoaiChungChi
                        AND NgayGioThi > @NgayHienTai
                        AND SoLuongToiDa > SoLuongDaDangKy";
                    SqlCommand cmdNgayThi = new SqlCommand(ngayThiQuery, conn);
                    cmdNgayThi.Parameters.AddWithValue("@LoaiChungChi", loaiChungChi);
                    cmdNgayThi.Parameters.AddWithValue("@NgayHienTai", ngayHienTai);
                    SqlDataReader reader = cmdNgayThi.ExecuteReader();

                    while (reader.Read())
                    {
                        DateTime ngayThi = Convert.ToDateTime(reader["NgayGioThi"]);
                        string maLT = reader["MaLT"].ToString();
                        TimeSpan thoiGianChenLech = ngayThi - ngayGiaHan;
                        if (thoiGianChenLech.TotalHours >= 24) // Đáp ứng điều kiện chênh lệch 24 giờ
                        {
                            ngayThiList.Add((ngayThi, maLT));
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error in LayDanhSachNgayThiKhaThi: {ex.Message}");
                }
            }

            return ngayThiList;
        }
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

        public bool GiamSoLuongDaDangKy(string maLT)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE LICH_THI SET SoLuongDaDangKy = SoLuongDaDangKy - 1 WHERE MaLT = @MaLT AND SoLuongDaDangKy > 0", conn);
                    cmd.Parameters.AddWithValue("@MaLT", maLT);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        System.Diagnostics.Debug.WriteLine($"Failed to decrease SoLuongDaDangKy for MaLT: {maLT}. Possibly SoLuongDaDangKy is already 0 or MaLT does not exist.");
                        return false;
                    }
                    System.Diagnostics.Debug.WriteLine($"Successfully decreased SoLuongDaDangKy for MaLT: {maLT}");
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error in GiamSoLuongDaDangKy: {ex.Message}");
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
                    System.Diagnostics.Debug.WriteLine($"Attempting to add HoaDonGiaHan with maPDT: {maPDT}, maYCGH: {maYCGH}, phiGiaHan: {phiGiaHan}");

                    // Gán mặc định maNVKeToan là "NHVN000003" nếu null
                    string defaultMaNVKeToan = string.IsNullOrEmpty(maNVKeToan) ? "NHVN000003" : maNVKeToan;

                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO HOA_DON_GIA_HAN (NgayGioThanhToan, SoTienThanhToan, HinhThucThanhToan, TrangThai, MaPDT, MaYCGH, MaNVKeToan) " +
                        "OUTPUT INSERTED.MaHDGH VALUES (@NgayGioThanhToan, @SoTienThanhToan, @HinhThucThanhToan, @TrangThai, @MaPDT, @MaYCGH, @MaNVKeToan)", conn);
                    cmd.Parameters.AddWithValue("@NgayGioThanhToan", DateTime.Now);
                    cmd.Parameters.AddWithValue("@SoTienThanhToan", (double)phiGiaHan);
                    cmd.Parameters.AddWithValue("@HinhThucThanhToan", "Chuyển khoản");
                    cmd.Parameters.AddWithValue("@TrangThai", "Đã TT");
                    cmd.Parameters.AddWithValue("@MaPDT", maPDT);
                    cmd.Parameters.AddWithValue("@MaYCGH", maYCGH);
                    cmd.Parameters.AddWithValue("@MaNVKeToan", defaultMaNVKeToan);

                    string maHDGH = cmd.ExecuteScalar()?.ToString();
                    if (string.IsNullOrEmpty(maHDGH))
                    {
                        System.Diagnostics.Debug.WriteLine("Failed to retrieve MaHDGH after insert.");
                        return false;
                    }

                    System.Diagnostics.Debug.WriteLine($"Successfully added HoaDonGiaHan with MaHDGH: {maHDGH}");
                    return true;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine($"SQL Error in ThemHoaDonGiaHan: {ex.Number} - {ex.Message}");
                    return false;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"General Error in ThemHoaDonGiaHan: {ex.Message}");
                    return false;
                }
            }
        }
    }
}