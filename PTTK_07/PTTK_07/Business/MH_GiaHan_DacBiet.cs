using System;
using PTTK_07.Data;

namespace PTTK_07.Business
{
    public class MH_GiaHan_DacBiet
    {
        private readonly PhieuGiaHan_DAO giaHanDao;

        public MH_GiaHan_DacBiet()
        {
            giaHanDao = new PhieuGiaHan_DAO();
        }

        public bool KiemTraMaPDTvaMaTS(string maPDT, string maTS)
        {
            return giaHanDao.KiemTraMaPDTvaMaTS(maPDT, maTS);
        }

        public (bool, string) GiaHan(string maPDT, string maTS, DateTime ngayGiaHan, string lyDo, string maLT, DateTime ngayGioThiMoi, decimal phiGiaHan = 0, string maNVKeToan = null)
        {
            System.Diagnostics.Debug.WriteLine($"GiaHan called with maPDT: {maPDT}, maTS: {maTS}, ngayGiaHan: {ngayGiaHan}, lyDo: {lyDo}, phiGiaHan: {phiGiaHan}");

            // Kiểm tra mã PDT và mã TS
            if (!KiemTraMaPDTvaMaTS(maPDT, maTS))
            {
                System.Diagnostics.Debug.WriteLine("Invalid MaPDT or MaTS.");
                return (false, "Mã phiếu dự thi hoặc mã thí sinh không hợp lệ!");
            }

            // Điều kiện 1: Kiểm tra ngày gia hạn (GETDATE()) có trước ngày thi không
            DateTime ngayThiHienTai = giaHanDao.LayNgayThi(maPDT);
            if (ngayThiHienTai == DateTime.MinValue)
            {
                System.Diagnostics.Debug.WriteLine("No valid NgayThi found.");
                return (false, "Không tìm thấy ngày thi của phiếu dự thi!");
            }

            DateTime ngayHienTai = DateTime.Now;
            if (ngayHienTai.Date >= ngayThiHienTai.Date)
            {
                System.Diagnostics.Debug.WriteLine("NgayThi has passed.");
                return (false, "Không thể gia hạn vì ngày thi đã diễn ra!");
            }

            // Điều kiện 2: Kiểm tra MaLT có trùng không
            string maLTHienTai = giaHanDao.LayMaLT(maPDT);
            if (maLTHienTai == null)
            {
                System.Diagnostics.Debug.WriteLine("No MaLT found.");
                return (false, "Không tìm thấy mã lịch thi hiện tại của phiếu dự thi!");
            }
            if (maLTHienTai == maLT)
            {
                System.Diagnostics.Debug.WriteLine("MaLT is duplicated.");
                return (false, "Trùng lịch thi!");
            }

            // Điều kiện 3: Kiểm tra số lượng đăng ký
            var (soLuongHopLe, soLuongMessage) = giaHanDao.KiemTraSoLuongDangKy(maLT);
            if (!soLuongHopLe)
            {
                System.Diagnostics.Debug.WriteLine($"SoLuong check failed: {soLuongMessage}");
                return (false, soLuongMessage);
            }

            // Kiểm tra phí gia hạn hợp lệ (nếu có)
            if (phiGiaHan < 0)
            {
                System.Diagnostics.Debug.WriteLine("Invalid PhiGiaHan.");
                return (false, "Phí gia hạn không được âm!");
            }

            // 1. Thêm vào YEU_CAU_GIA_HAN và lấy MaYCGH
            var (themYeuCauSuccess, maYCGH) = giaHanDao.ThemYeuCauGiaHan(maPDT, ngayGiaHan, lyDo, phiGiaHan);
            if (!themYeuCauSuccess)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to add YEU_CAU_GIA_HAN with maPDT: {maPDT}, maYCGH: {maYCGH}");
                return (false, "Lỗi khi thêm yêu cầu gia hạn!");
            }

            // 2. Cập nhật PHIEU_DU_THI_GIAHAN (SoLanConLai - 1)
            var (capNhatSoLan, capNhatMessage) = giaHanDao.CapNhatSoLanGiaHan(maPDT);
            if (!capNhatSoLan)
            {
                System.Diagnostics.Debug.WriteLine($"CapNhatSoLan failed: {capNhatMessage}");
                return (false, capNhatMessage);
            }

            // 3. Cập nhật ngày thi và MaLT trong PHIEU_DU_THI
            bool capNhatNgayThi = giaHanDao.CapNhatNgayThi(maPDT, ngayGioThiMoi, maLT);
            if (!capNhatNgayThi)
            {
                System.Diagnostics.Debug.WriteLine("Failed to update NgayThi and MaLT.");
                return (false, "Lỗi khi cập nhật ngày thi và mã lịch thi!");
            }

            // 4. Tăng số lượng đã đăng ký trong LICH_THI
            bool tangSoLuong = giaHanDao.TangSoLuongDaDangKy(maLT);
            if (!tangSoLuong)
            {
                System.Diagnostics.Debug.WriteLine("Failed to increase SoLuongDaDangKy.");
                return (false, "Lỗi khi cập nhật số lượng đã đăng ký!");
            }

            // Nếu có phí gia hạn, thêm vào HOA_DON_GIA_HAN
            if (phiGiaHan > 0)
            {
                bool themHoaDon = giaHanDao.ThemHoaDonGiaHan(maPDT, maYCGH, phiGiaHan, maNVKeToan);
                if (!themHoaDon)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to add HoaDonGiaHan.");
                    return (true, "Gia hạn thành công nhưng lỗi khi tạo hóa đơn!");
                }
            }

            return (true, phiGiaHan > 0 ? $"Gia hạn thành công! Phí gia hạn: {phiGiaHan:C0}" : "Gia hạn thành công!");
        }
    }
}