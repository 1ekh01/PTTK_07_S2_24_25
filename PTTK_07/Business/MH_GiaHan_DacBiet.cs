using System;
using PTTK_07.Data;

namespace PTTK_07.Business
{
    public class MH_GiaHan_DacBiet
    {
        private PhieuGiaHan_DAO giaHanDao;

        public MH_GiaHan_DacBiet()
        {
            giaHanDao = new PhieuGiaHan_DAO();
        }

        public bool KiemTraMaPDTvaMaTS(string maPDT, string maTS)
        {
            return giaHanDao.KiemTraMaPDTvaMaTS(maPDT, maTS);
        }

        public (bool, string) GiaHan(string maPDT, string maTS, DateTime ngayGiaHan, string lyDo, string maLT, DateTime ngayGioThiMoi)
        {
            // Điều kiện 1: Kiểm tra ngày gia hạn (GETDATE()) có trước ngày thi không
            DateTime ngayThiHienTai = giaHanDao.LayNgayThi(maPDT);
            if (ngayThiHienTai == DateTime.MinValue)
                return (false, "Không tìm thấy ngày thi của phiếu dự thi!");

            DateTime ngayHienTai = DateTime.Now; // GETDATE()
            if (ngayHienTai.Date >= ngayThiHienTai.Date)
                return (false, "Không thể gia hạn vì ngày thi đã diễn ra!");

            // Điều kiện 2: Kiểm tra MaLT có trùng không
            string maLTHienTai = giaHanDao.LayMaLT(maPDT);
            if (maLTHienTai == null)
                return (false, "Không tìm thấy mã lịch thi hiện tại của phiếu dự thi!");
            if (maLTHienTai == maLT)
                return (false, "Trùng lịch thi!");

            // Điều kiện 3: Kiểm tra số lượng đăng ký
            var (soLuongHopLe, soLuongMessage) = giaHanDao.KiemTraSoLuongDangKy(maLT);
            if (!soLuongHopLe)
                return (false, soLuongMessage);

            // 1. Thêm vào YEU_CAU_GIA_HAN (PhiGiaHan = 0)
            bool themYeuCau = giaHanDao.ThemYeuCauGiaHan(maPDT, ngayGiaHan, lyDo);
            if (!themYeuCau)
                return (false, "Lỗi khi thêm yêu cầu gia hạn!");

            // 2. Cập nhật PHIEU_DU_THI_GIAHAN (SoLanConLai - 1)
            var (capNhatSoLan, capNhatMessage) = giaHanDao.CapNhatSoLanGiaHan(maPDT);
            if (!capNhatSoLan)
                return (false, capNhatMessage);

            // 3. Cập nhật ngày thi và MaLT trong PHIEU_DU_THI
            bool capNhatNgayThi = giaHanDao.CapNhatNgayThi(maPDT, ngayGioThiMoi, maLT);
            if (!capNhatNgayThi)
                return (false, "Lỗi khi cập nhật ngày thi và mã lịch thi!");

            // 4. Tăng số lượng đã đăng ký trong LICH_THI
            bool tangSoLuong = giaHanDao.TangSoLuongDaDangKy(maLT);
            if (!tangSoLuong)
                return (false, "Lỗi khi cập nhật số lượng đã đăng ký!");

            return (true, "Gia hạn thành công!");
        }
    }
}