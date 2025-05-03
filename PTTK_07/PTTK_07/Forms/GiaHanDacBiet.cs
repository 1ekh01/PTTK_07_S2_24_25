using System;
using System.Data;
using System.Windows.Forms;
using PTTK_07.Business;
using System.Collections.Generic;

namespace PTTK_07.Forms
{
    public partial class GiaHanDacBiet : Form
    {
        private readonly MH_GiaHan_DacBiet giaHanBus;
        private readonly LichThi_BUS lichBus;
        private readonly string maNVKeToan;
        private List<(DateTime NgayGioThi, string MaLT)> ngayThiList;

        public GiaHanDacBiet(string maNVKeToan = null)
        {
            InitializeComponent();
            giaHanBus = new MH_GiaHan_DacBiet();
            lichBus = new LichThi_BUS();
            this.maNVKeToan = maNVKeToan;
            ngayThiList = new List<(DateTime, string)>();
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

                // Lưu danh sách ngày thi và MaLT
                ngayThiList = ngayThiKhaThiList;

                // Hiển thị danh sách ngày thi khả thi
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

                // Lấy ngày thi và MaLT từ lựa chọn của người dùng
                int selectedIndex = lstNgayThi.SelectedIndex;
                DateTime ngayGioThiMoi = ngayThiList[selectedIndex].NgayGioThi;
                string maLT = ngayThiList[selectedIndex].MaLT;

                var (thanhCong, message) = giaHanBus.ThucHienGiaHan(maPDT, maTS, ngayGiaHan, lyDo, maLT, ngayGioThiMoi, phiGiaHan, maNVKeToan);
                MessageBox.Show(message, thanhCong ? "Thành công" : "Thất bại", MessageBoxButtons.OK, thanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}