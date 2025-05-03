using System;
using System.Data;
using System.Windows.Forms;
using PTTK_07.Business;
using System.Collections.Generic;
using PTTK_07.data;

namespace PTTK_07.Forms
{
    public partial class GiaHanDacBiet : Form
    {
        private readonly MH_GiaHan_DacBiet giaHanBus;
        private readonly LichThi_BUS lichBus;
        private readonly PhieuGiaHan_DAO giaHanDao;
        private readonly string maNVKeToan;
        private List<(DateTime NgayGioThi, string MaLT)> ngayThiList;
        private Forms.DangNhap _dangNhapForm;

        public GiaHanDacBiet(string maNVKeToan = null)
        {
            InitializeComponent();
            giaHanBus = new MH_GiaHan_DacBiet();
            lichBus = new LichThi_BUS();
            giaHanDao = new PhieuGiaHan_DAO();
            this.maNVKeToan = maNVKeToan;
            ngayThiList = new List<(DateTime, string)>();

            // Tải toàn bộ hóa đơn khi form khởi tạo
            LoadHoaDonGiaHan();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtKiemTraHoaDon.Text = ""; // Xóa nội dung trong ô tìm kiếm
            LoadHoaDonGiaHan(); // Làm mới danh sách hóa đơn gia hạn
        }

        private void LoadHoaDonGiaHan(string maHD = null)
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
                DateTime ngayGiaHan = DateTime.Now;
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
                    MessageBox.Show("Vui lòng chọn một ngày thi từ danh sách ngày khả thi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maPDT = txtMaPDT.Text;
                string maTS = txtMaTS.Text;

                if (string.IsNullOrWhiteSpace(maPDT) || string.IsNullOrWhiteSpace(maTS))
                {
                    MessageBox.Show("Vui lòng nhập Mã PDT và Mã TS!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string lyDo = txtLyDo.Text;
                decimal phiGiaHan = decimal.TryParse(txtPhiGiaHan.Text, out decimal phi) ? phi : 0;
                DateTime ngayGiaHan = DateTime.Now;

                int selectedIndex = lstNgayThi.SelectedIndex;
                DateTime ngayGioThiMoi = ngayThiList[selectedIndex].NgayGioThi;
                string maLT = ngayThiList[selectedIndex].MaLT;

                // Bước 1: Thêm yêu cầu gia hạn trước
                var (thanhCongYCGH, messageYCGH, maYCGH) = giaHanDao.ThemYeuCauGiaHan(maPDT, ngayGiaHan, lyDo, phiGiaHan);
                if (!thanhCongYCGH || string.IsNullOrEmpty(maYCGH))
                {
                    MessageBox.Show(messageYCGH ?? "Lỗi khi tạo yêu cầu gia hạn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Bước 2: Thực hiện gia hạn
                var (thanhCong, message) = giaHanBus.ThucHienGiaHan(maPDT, maTS, ngayGiaHan, lyDo, maLT, ngayGioThiMoi, phiGiaHan, maNVKeToan, maYCGH);
                if (!thanhCong)
                {
                    MessageBox.Show(message, "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Bước 3: Nếu có phí, tạo hóa đơn sau khi gia hạn thành công
                if (phiGiaHan > 0)
                {
                    bool themHoaDon = giaHanDao.ThemHoaDonGiaHan(maPDT, maYCGH, phiGiaHan, maNVKeToan);
                    if (!themHoaDon)
                    {
                        MessageBox.Show("Lỗi khi tạo hóa đơn gia hạn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                MessageBox.Show(message + (phiGiaHan > 0 ? $" Phí gia hạn: {phiGiaHan:C0}" : ""), "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHoaDonGiaHan();
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
                LoadHoaDonGiaHan(); // Hiển thị toàn bộ hóa đơn nếu không nhập gì
            }
            else
            {
                LoadHoaDonGiaHan(maHD); // Tìm kiếm hóa đơn có chứa chuỗi maHD
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị form xác nhận tùy chỉnh
                using (var _dangXuatForm = new Forms.DangXuat("Bạn có chắc chắn muốn đăng xuất?"))
                {
                    var confirmResult = _dangXuatForm.ShowDialog();

                    if (confirmResult == DialogResult.Yes) // Nút "Có"
                    {
                        if (_dangNhapForm == null || _dangNhapForm.IsDisposed)
                        {
                            _dangNhapForm = new Forms.DangNhap();
                        }
                        _dangNhapForm.Show();
                        _dangNhapForm.FormClosed += (s, args) => Application.Exit();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đăng xuất: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}