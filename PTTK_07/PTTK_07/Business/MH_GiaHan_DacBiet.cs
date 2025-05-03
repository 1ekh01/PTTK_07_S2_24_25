using System;
using System.Collections.Generic;
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

        // Phương thức mới để kiểm tra và lấy danh sách ngày thi khả thi
        public (bool, string, List<(DateTime NgayGioThi, string MaLT)>) KiemTraVaLayNgayThiKhaThi(string maPDT, string maTS, DateTime ngayGiaHan, string lyDo, decimal phiGiaHan = 0)
        {
            System.Diagnostics.Debug.WriteLine($"KiemTraVaLayNgayThiKhaThi called with maPDT: {maPDT}, maTS: {maTS}, ngayGiaHan: {ngayGiaHan}, lyDo: {lyDo}, phiGiaHan: {phiGiaHan}");

            // Điều kiện 1: Kiểm tra mã PDT và mã TS
            if (!KiemTraMaPDTvaMaTS(maPDT, maTS))
            {
                System.Diagnostics.Debug.WriteLine("Invalid MaPDT or MaTS.");
                return (false, "Mã phiếu dự thi hoặc mã thí sinh không hợp lệ!", new List<(DateTime, string)>());
            }

            // Điều kiện 2: Kiểm tra ngày thi hiện tại có tồn tại không
            DateTime ngayThiHienTai = giaHanDao.LayNgayThi(maPDT);
            if (ngayThiHienTai == DateTime.MinValue)
            {
                System.Diagnostics.Debug.WriteLine("No valid NgayThi found.");
                return (false, "Không tìm thấy ngày thi của phiếu dự thi!", new List<(DateTime, string)>());
            }

            // Điều kiện 3: Kiểm tra ngày thi đã diễn ra chưa
            DateTime ngayHienTai = DateTime.Now;
            if (ngayHienTai >= ngayThiHienTai)
            {
                System.Diagnostics.Debug.WriteLine("NgayThi has passed.");
                return (false, "Không thể gia hạn vì ngày thi đã diễn ra!", new List<(DateTime, string)>());
            }

            // Điều kiện 4: Kiểm tra ngày gia hạn có trước ngày thi hiện tại ít nhất 24 giờ không
            TimeSpan thoiGianChenLech = ngayThiHienTai - ngayGiaHan;
            if (thoiGianChenLech.TotalHours < 24)
            {
                System.Diagnostics.Debug.WriteLine($"NgayGiaHan is too close to NgayThiHienTai. Difference: {thoiGianChenLech.TotalHours} hours.");
                return (false, "Ngày gia hạn phải trước ngày thi hiện tại ít nhất 24 giờ!", new List<(DateTime, string)>());
            }

            // Điều kiện 5: Kiểm tra phí gia hạn hợp lệ
            if (phiGiaHan < 0)
            {
                System.Diagnostics.Debug.WriteLine("Invalid PhiGiaHan.");
                return (false, "Phí gia hạn không được âm!", new List<(DateTime, string)>());
            }

            // Lấy danh sách ngày thi khả thi
            List<(DateTime NgayGioThi, string MaLT)> ngayThiKhaThiList = giaHanDao.LayDanhSachNgayThiKhaThi(maPDT, ngayGiaHan);
            if (ngayThiKhaThiList.Count == 0)
            {
                System.Diagnostics.Debug.WriteLine("No suitable NgayThiKhaThi found.");
                return (false, "Không tìm thấy ngày thi khả thi phù hợp!", new List<(DateTime, string)>());
            }

            // Kiểm tra và thêm PHIEU_DU_THI_GIA_HAN nếu chưa tồn tại
            bool kiemTraPhieuGiaHan = giaHanDao.KiemTraVaThemPhieuDuThiGiaHan(maPDT);
            if (!kiemTraPhieuGiaHan)
            {
                System.Diagnostics.Debug.WriteLine($"PHIEU_DU_THI_GIA_HAN already exists for MaPDT: {maPDT} or error occurred.");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"Added new PHIEU_DU_THI_GIA_HAN for MaPDT: {maPDT}");
            }

            return (true, "Tìm thấy các ngày thi khả thi!", ngayThiKhaThiList);
        }

        // Phương thức thực hiện gia hạn với ngày thi đã chọn
        public (bool, string) ThucHienGiaHan(string maPDT, string maTS, DateTime ngayGiaHan, string lyDo, string maLT, DateTime ngayGioThiMoi, decimal phiGiaHan = 0, string maNVKeToan = null)
        {
            System.Diagnostics.Debug.WriteLine($"ThucHienGiaHan called with maPDT: {maPDT}, maTS: {maTS}, ngayGiaHan: {ngayGiaHan}, lyDo: {lyDo}, maLT: {maLT}, ngayGioThiMoi: {ngayGioThiMoi}, phiGiaHan: {phiGiaHan}");

            // Điều kiện 1: Kiểm tra mã PDT và mã TS
            if (!KiemTraMaPDTvaMaTS(maPDT, maTS))
            {
                return (false, "Mã phiếu dự thi hoặc mã thí sinh không hợp lệ!");
            }

            // Điều kiện 2: Kiểm tra ngày thi hiện tại
            DateTime ngayThiHienTai = giaHanDao.LayNgayThi(maPDT);
            if (ngayThiHienTai == DateTime.MinValue)
            {
                return (false, "Không tìm thấy ngày thi của phiếu dự thi!");
            }
            if (DateTime.Now >= ngayThiHienTai)
            {
                return (false, "Không thể gia hạn vì ngày thi đã diễn ra!");
            }

            // Điều kiện 3: Kiểm tra ngày gia hạn
            TimeSpan thoiGianChenLech = ngayThiHienTai - ngayGiaHan;
            if (thoiGianChenLech.TotalHours < 24)
            {
                return (false, "Ngày gia hạn phải trước ngày thi hiện tại ít nhất 24 giờ!");
            }

            // Điều kiện 4: Kiểm tra MaLT
            string maLTHienTai = giaHanDao.LayMaLT(maPDT);
            if (maLTHienTai == null)
            {
                return (false, "Không tìm thấy mã lịch thi hiện tại của phiếu dự thi!");
            }
            if (maLTHienTai == maLT)
            {
                return (false, "Trùng lịch thi!");
            }

            // Điều kiện 5: Kiểm tra số lượng đăng ký
            var (soLuongHopLe, soLuongMessage) = giaHanDao.KiemTraSoLuongDangKy(maLT);
            if (!soLuongHopLe)
            {
                return (false, soLuongMessage);
            }

            // Điều kiện 6: Kiểm tra phí gia hạn
            if (phiGiaHan < 0)
            {
                return (false, "Phí gia hạn không được âm!");
            }

            // 1. Kiểm tra và thêm PHIEU_DU_THI_GIA_HAN nếu chưa tồn tại
            bool kiemTraPhieuGiaHan = giaHanDao.KiemTraVaThemPhieuDuThiGiaHan(maPDT);
            if (!kiemTraPhieuGiaHan)
            {
                System.Diagnostics.Debug.WriteLine($"PHIEU_DU_THI_GIA_HAN already exists for MaPDT: {maPDT} or error occurred.");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"Added new PHIEU_DU_THI_GIA_HAN for MaPDT: {maPDT}");
            }

            // 2. Thêm vào YEU_CAU_GIA_HAN và lấy MaYCGH
            var (themYeuCauSuccess, maYCGH) = giaHanDao.ThemYeuCauGiaHan(maPDT, ngayGiaHan, lyDo, phiGiaHan);
            if (!themYeuCauSuccess || string.IsNullOrEmpty(maYCGH))
            {
                return (false, "Lỗi khi thêm yêu cầu gia hạn!");
            }

            // 3. Cập nhật PHIEU_DU_THI_GIA_HAN (SoLanConLai - 1)
            var (capNhatSoLan, capNhatMessage) = giaHanDao.CapNhatSoLanGiaHan(maPDT);
            if (!capNhatSoLan)
            {
                return (false, capNhatMessage);
            }

            // 4. Cập nhật ngày thi và MaLT trong PHIEU_DU_THI
            bool capNhatNgayThi = giaHanDao.CapNhatNgayThi(maPDT, ngayGioThiMoi, maLT);
            if (!capNhatNgayThi)
            {
                return (false, "Lỗi khi cập nhật ngày thi và mã lịch thi!");
            }

            // 5. Giảm số lượng đã đăng ký của lịch thi hiện tại (MaLT cũ)
            bool giamSoLuong = giaHanDao.GiamSoLuongDaDangKy(maLTHienTai);
            if (!giamSoLuong)
            {
                return (false, "Lỗi khi giảm số lượng đã đăng ký của lịch thi hiện tại!");
            }

            // 6. Tăng số lượng đã đăng ký của lịch thi mới (MaLT mới)
            bool tangSoLuong = giaHanDao.TangSoLuongDaDangKy(maLT);
            if (!tangSoLuong)
            {
                return (false, "Lỗi khi cập nhật số lượng đã đăng ký của lịch thi mới!");
            }

            // 7. Nếu có phí gia hạn, thêm vào HOA_DON_GIA_HAN
            if (phiGiaHan > 0)
            {
                if (string.IsNullOrEmpty(maYCGH))
                {
                    return (false, "Lỗi dữ liệu yêu cầu gia hạn, không thể tạo hóa đơn!");
                }

                bool themHoaDon = giaHanDao.ThemHoaDonGiaHan(maPDT, maYCGH, phiGiaHan, maNVKeToan);
                if (!themHoaDon)
                {
                    return (false, "Lỗi khi tạo hóa đơn gia hạn!");
                }
            }

            return (true, phiGiaHan > 0 ? $"Gia hạn thành công! Phí gia hạn: {phiGiaHan:C0}" : "Gia hạn thành công!");
        }

        // Phương thức kiểm tra MaPDT và MaTS (giữ nguyên)
        public bool KiemTraMaPDTvaMaTS(string maPDT, string maTS)
        {
            return giaHanDao.KiemTraMaPDTvaMaTS(maPDT, maTS);
        }

        // Phương thức kiểm tra và thêm cho tất cả MaPDT (giữ nguyên)
        public void KiemTraVaThemTatCaPhieuDuThiGiaHan()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Bắt đầu kiểm tra và thêm PHIEU_DU_THI_GIA_HAN cho tất cả MaPDT...");
                giaHanDao.KiemTraVaThemTatCaPhieuDuThiGiaHan();
                System.Diagnostics.Debug.WriteLine("Hoàn tất!");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi khi xử lý: {ex.Message}");
            }
        }
    }
}