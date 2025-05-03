using System;
using System.Data;
using System.Windows.Forms;
using PTTK_07.Business;
using System.Collections.Generic;
using PTTK_07.Data;

namespace PTTK_07.Forms
{
    public partial class GiaHanDacBiet : Form
    {
        private readonly MH_GiaHan_DacBiet giaHanBus;
        private readonly LichThi_BUS lichBus;
        private readonly PhieuGiaHan_DAO giaHanDao;
        private readonly string maNVKeToan;
        private List<(DateTime NgayGioThi, string MaLT)> ngayThiList;

        public GiaHanDacBiet(string maNVKeToan = null)
        {
            InitializeComponent();
            giaHanBus = new MH_GiaHan_DacBiet();
            lichBus = new LichThi_BUS();
            giaHanDao = new PhieuGiaHan_DAO();
            this.maNVKeToan = maNVKeToan;
            ngayThiList = new List<(DateTime, string)>();

            // Tải toàn bộ hóa đơn khi form khởi tạo
            LoadHoaDon();
        }

        private void LoadHoaDon(string maHD = null)
        {
            try
            {
                DataTable dt = giaHanDao.LayDanhSachHoaDon(maHD);
                gridViewHoaDon.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            try
            {
                string maPDT = txtMaPDT.Text;
                string maTS = txtMaTS.Text;
                DateTime ngayGiaHan = dateTimePickerGiaHan.Value;
                string lyDo = txtLyDo.Text;
                decimal phiGiaHan = decimal.TryParse(txtPhiGiaHan.Text, out decimal phi) ? phi : 0;

                var (thanhCong, message, ngayThiKhaThiList) = giaHanBus.KiemTraVaLayNgayThiKhaThi(maPDT, maTS, ngayGiaHan, lyDo, phiGiaHan);

                if (!thanhCong)
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ngayThiList = ngayThiKhaThiList;
                lstNgayThi.Items.Clear();
                foreach (var (ngayThi, maLT) in ngayThiList)
                {
                    lstNgayThi.Items.Add(ngayThi.ToString("dd/MM/yyyy HH:mm"));
                }
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstNgayThi.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn một ngày thi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maPDT = txtMaPDT.Text;
                string maTS = txtMaTS.Text;
                DateTime ngayGiaHan = dateTimePickerGiaHan.Value;
                string lyDo = txtLyDo.Text;
                decimal phiGiaHan = decimal.TryParse(txtPhiGiaHan.Text, out decimal phi) ? phi : 0;

                int selectedIndex = lstNgayThi.SelectedIndex;
                DateTime ngayGioThiMoi = ngayThiList[selectedIndex].NgayGioThi;
                string maLT = ngayThiList[selectedIndex].MaLT;

                var (thanhCong, message) = giaHanBus.ThucHienGiaHan(maPDT, maTS, ngayGiaHan, lyDo, maLT, ngayGioThiMoi, phiGiaHan, maNVKeToan);
                MessageBox.Show(message, thanhCong ? "Thành công" : "Thất bại", MessageBoxButtons.OK, thanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (thanhCong)
                {
                    LoadHoaDon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemHoaDon_Click(object sender, EventArgs e)
        {
            string maHD = txtKiemTraHoaDon.Text.Trim();
            if (string.IsNullOrEmpty(maHD))
            {
                LoadHoaDon(); // Hiển thị toàn bộ hóa đơn nếu không nhập gì
            }
            else
            {
                LoadHoaDon(maHD); // Tìm kiếm hóa đơn có chứa chuỗi maHD
            }
        }
    }
}