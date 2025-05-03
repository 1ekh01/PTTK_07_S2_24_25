using System;
using System.Data;
using System.Windows.Forms;
using PTTK_07.Business;

namespace PTTK_07.Forms
{
    public partial class GiaHanDacBiet : Form
    {
        private readonly MH_GiaHan_DacBiet giaHanBus;
        private readonly LichThi_BUS lichBus;
        private readonly string maNVKeToan; // Giả định lấy từ hệ thống đăng nhập

        public GiaHanDacBiet(string maNVKeToan = null)
        {
            InitializeComponent();
            giaHanBus = new MH_GiaHan_DacBiet();
            lichBus = new LichThi_BUS();
            this.maNVKeToan = maNVKeToan; // Lưu mã nhân viên kế toán
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            string maPDT = txtMaPDT.Text.Trim();
            if (string.IsNullOrWhiteSpace(maPDT))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu dự thi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime ngayGiaHan = dtpNgayGiaHan.Value;
            DataTable dtLichThi = lichBus.LayLichTheoNgayVoiLoaiChungChi(maPDT, ngayGiaHan);
            if (dtLichThi != null)
            {
                dgvLich.DataSource = dtLichThi;
            }
            else
            {
                dgvLich.DataSource = null;
                MessageBox.Show("Không có lịch thi phù hợp vào ngày này! (Loại chứng chỉ không khớp)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            if (dgvLich.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lịch thi để gia hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maPDT = txtMaPDT.Text.Trim();
            string maTS = txtMaTS.Text.Trim(); // Lấy giá trị từ txtMaTS
            DateTime ngayGiaHan = dtpNgayGiaHan.Value;
            string lyDo = txtLyDo.Text.Trim();
            decimal phiGiaHan;

            // Kiểm tra phí gia hạn
            if (string.IsNullOrWhiteSpace(txtPhiGiaHan.Text))
            {
                phiGiaHan = 0; // Gia hạn đặc biệt nếu không nhập phí
            }
            else if (!decimal.TryParse(txtPhiGiaHan.Text.Trim(), out phiGiaHan) || phiGiaHan < 0)
            {
                MessageBox.Show("Phí gia hạn không hợp lệ! Vui lòng nhập số không âm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(maPDT))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu dự thi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(maTS)) // Kiểm tra MaTS
            {
                MessageBox.Show("Vui lòng nhập mã thí sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(lyDo))
            {
                MessageBox.Show("Vui lòng nhập lý do gia hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin từ dòng được chọn trong DataGridView
            DataGridViewRow selectedRow = dgvLich.SelectedRows[0];
            string maLT = selectedRow.Cells["MaLT"].Value?.ToString();
            DateTime ngayGioThiMoi = Convert.ToDateTime(selectedRow.Cells["NgayGioThi"].Value);

            // Gọi phương thức GiaHan
            var (success, message) = giaHanBus.GiaHan(maPDT, maTS, ngayGiaHan, lyDo, maLT, ngayGioThiMoi, phiGiaHan, maNVKeToan);
            MessageBox.Show(message, success ? "Thông báo" : "Lỗi", MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (success)
            {
                // Làm mới DataGridView
                DataTable dtLichThi = lichBus.LayLichTheoNgayVoiLoaiChungChi(maPDT, ngayGiaHan);
                if (dtLichThi != null)
                {
                    dgvLich.DataSource = dtLichThi;
                }
                else
                {
                    dgvLich.DataSource = null;
                }
            }
        }
    }
}