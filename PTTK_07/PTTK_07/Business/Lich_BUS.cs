using PTTK_07.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTK_07.Business
{
    public class LichThi_BUS
    {
        private readonly Lich_DAO lichThiDao;
        private readonly PhieuGiaHan_DAO phieuGiaHanDao;

        public LichThi_BUS()
        {
            lichThiDao = new Lich_DAO();
            phieuGiaHanDao = new PhieuGiaHan_DAO();
        }

        public bool KiemTraLichThi(DateTime ngayThi)
        {
            return lichThiDao.KiemTraLichThi(ngayThi);
        }

        public DataTable LayLichTheoNgay(DateTime ngayThi)
        {
            return lichThiDao.LayLichTheoNgay(ngayThi);
        }

        public DataTable LayLichTheoNgayVoiLoaiChungChi(string maPDT, DateTime ngayThi)
        {
            // Lấy loại chứng chỉ của lịch thi hiện tại từ PHIEU_DU_THI và LICH_THI
            string maLTHienTai = phieuGiaHanDao.LayMaLT(maPDT);
            if (string.IsNullOrEmpty(maLTHienTai))
            {
                System.Diagnostics.Debug.WriteLine("No MaLT found for MaPDT.");
                return null;
            }

            string loaiChungChi = lichThiDao.LayLoaiChungChi(maLTHienTai);
            if (string.IsNullOrEmpty(loaiChungChi))
            {
                System.Diagnostics.Debug.WriteLine("No LoaiChungChi found for MaLT.");
                return null;
            }

            // Lấy danh sách lịch thi theo ngày
            DataTable dtLichThi = lichThiDao.LayLichTheoNgay(ngayThi);
            if (dtLichThi == null || dtLichThi.Rows.Count == 0)
            {
                System.Diagnostics.Debug.WriteLine("No LichThi found for the given date.");
                return null;
            }

            // Lọc các lịch thi có cùng loại chứng chỉ
            DataTable dtFiltered = dtLichThi.Clone();
            foreach (DataRow row in dtLichThi.Rows)
            {
                string loaiChungChiMoi = row["LoaiChungChi"].ToString();
                if (loaiChungChiMoi == loaiChungChi)
                {
                    dtFiltered.ImportRow(row);
                }
            }

            return dtFiltered.Rows.Count > 0 ? dtFiltered : null;
        }
    }
}
