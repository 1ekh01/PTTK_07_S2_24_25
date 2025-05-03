using PTTK_07.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTK_07.Business
{
    public class MH_GiaHan_DacBiet
    {
        private readonly PhieuGiaHan_DAO giaHanDao;

        public MH_GiaHan_DacBiet()
        {
            giaHanDao = new PhieuGiaHan_DAO();
        }

        // Phương thức kiểm tra và lấy danh sách ngày thi khả thi
        public (bool, string, List<(DateTime NgayGioThi, string MaLT)>) KiemTraVaLayNgayThiKhaThi(string maPDT, string maTS, DateTime ngayGiaHan, string lyDo, decimal soTienThanhToan = 0)
        {
            System.Diagnostics.Debug.WriteLine($"KiemTraVaLayNgayThiKhaThi called with maPDT: {maPDT}, maTS: {maTS}, ngayGiaHan: {ngayGiaHan}, lyDo: {lyDo}, soTienThanhToan: {soTienThanhToan}");

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

            // Điều kiện 5: Kiểm tra số tiền thanh toán hợp lệ
            if (soTienThanhToan < 0)
            {
                System.Diagnostics.Debug.WriteLine("Invalid SoTienThanhToan.");
                return (false, "Số tiền thanh toán không được âm!", new List<(DateTime, string)>());
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
        public (bool, string) ThucHienGiaHan(string maPDT, string maTS, DateTime ngayGiaHan, string lyDo, string maLT, DateTime ngayGioThiMoi, decimal soTienThanhToan = 0, string maNVKeToan = null, string maYCGH = null)
        {
            System.Diagnostics.Debug.WriteLine($"ThucHienGiaHan called with maPDT: {maPDT}, maTS: {maTS}, ngayGiaHan: {ngayGiaHan}, lyDo: {lyDo}, maLT: {maLT}, ngayGioThiMoi: {ngayGioThiMoi}, soTienThanhToan: {soTienThanhToan}, maYCGH: {maYCGH}");

            if (!KiemTraMaPDTvaMaTS(maPDT, maTS))
            {
                return (false, "Mã phiếu dự thi hoặc mã thí sinh không hợp lệ!");
            }

            DateTime ngayThiHienTai = giaHanDao.LayNgayThi(maPDT);
            if (ngayThiHienTai == DateTime.MinValue)
            {
                return (false, "Không tìm thấy ngày thi của phiếu dự thi!");
            }
            if (DateTime.Now >= ngayThiHienTai)
            {
                return (false, "Không thể gia hạn vì ngày thi đã diễn ra!");
            }

            TimeSpan thoiGianChenLech = ngayThiHienTai - ngayGiaHan;
            if (thoiGianChenLech.TotalHours < 24)
            {
                return (false, "Ngày gia hạn phải trước ngày thi hiện tại ít nhất 24 giờ!");
            }

            string maLTHienTai = giaHanDao.LayMaLT(maPDT);
            if (maLTHienTai == null)
            {
                return (false, "Không tìm thấy mã lịch thi hiện tại của phiếu dự thi!");
            }
            if (maLTHienTai == maLT)
            {
                return (false, "Trùng lịch thi!");
            }

            var (soLuongHopLe, soLuongMessage) = giaHanDao.KiemTraSoLuongDangKy(maLT);
            if (!soLuongHopLe)
            {
                return (false, soLuongMessage);
            }

            if (soTienThanhToan < 0)
            {
                return (false, "Số tiền thanh toán không được âm!");
            }

            bool kiemTraPhieuGiaHan = giaHanDao.KiemTraVaThemPhieuDuThiGiaHan(maPDT);
            if (!kiemTraPhieuGiaHan)
            {
                System.Diagnostics.Debug.WriteLine($"PHIEU_DU_THI_GIA_HAN already exists for MaPDT: {maPDT} or error occurred.");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"Added new PHIEU_DU_THI_GIA_HAN for MaPDT: {maPDT}");
            }

            var (capNhatSoLan, capNhatMessage) = giaHanDao.CapNhatSoLanGiaHan(maPDT);
            if (!capNhatSoLan)
            {
                return (false, capNhatMessage);
            }

            bool capNhatNgayThi = giaHanDao.CapNhatNgayThi(maPDT, ngayGioThiMoi, maLT);
            if (!capNhatNgayThi)
            {
                return (false, "Lỗi khi cập nhật ngày thi và mã lịch thi!");
            }

            bool giamSoLuong = giaHanDao.GiamSoLuongDaDangKy(maLTHienTai);
            if (!giamSoLuong)
            {
                return (false, "Lỗi khi giảm số lượng đã đăng ký của lịch thi hiện tại!");
            }

            bool tangSoLuong = giaHanDao.TangSoLuongDaDangKy(maLT);
            if (!tangSoLuong)
            {
                return (false, "Lỗi khi cập nhật số lượng đã đăng ký của lịch thi mới!");
            }

            // Xóa phần tạo hóa đơn ở đây
            return (true, "Gia hạn thành công!");
        }


        // Phương thức kiểm tra MaPDT và MaTS
        public bool KiemTraMaPDTvaMaTS(string maPDT, string maTS)
        {
            return giaHanDao.KiemTraMaPDTvaMaTS(maPDT, maTS);
        }

        // Phương thức kiểm tra và thêm cho tất cả MaPDT
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
