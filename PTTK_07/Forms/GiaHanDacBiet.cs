using System;
using System.Windows.Forms;
using PTTK_07.Business;
using PTTK_07.Data;

namespace PTTK_07.Forms
{
    public partial class GiaHanDacBiet : Form
    {
        private MH_GiaHan_DacBiet giaHanBus;
        private Lich_BUS lichBus;

        public GiaHanDacBiet()
        {
            InitializeComponent();
            giaHanBus = new MH_GiaHan_DacBiet();
            lichBus = new Lich_BUS();
        }

        private void GiaHanDacBiet_Load(object sender, EventArgs e)
        {
            // Vô hiệu hóa nút Gia hạn khi form được tải
            btnGiaHan.Enabled = false;
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            string maPDT = txtMaPDT.Text.Trim();
            string maTS = txtMaTS.Text.Trim();
            DateTime ngayGiaHan = dtpNgayGiaHan.Value;

            if (string.IsNullOrEmpty(maPDT) || string.IsNullOrEmpty(maTS))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã PDT và Mã TS!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isValidPDTandTS = giaHanBus.KiemTraMaPDTvaMaTS(maPDT, maTS);
            if (!isValidPDTandTS)
            {
                MessageBox.Show("Mã PDT hoặc Mã TS không tồn tại hoặc không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool coLichThi = lichBus.KiemTraLichThi(ngayGiaHan);
            if (coLichThi)
            {
                dgvLich.DataSource = lichBus.LayLichTheoNgay(ngayGiaHan);
            }
            else
            {
                dgvLich.DataSource = null;
                MessageBox.Show("Không có lịch thi vào ngày này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvLich_SelectionChanged(object sender, EventArgs e)
        {
            btnGiaHan.Enabled = dgvLich.SelectedRows.Count > 0;
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn trong DataGridView không
            if (dgvLich.SelectedRows.Count == 0)
            {
                System.Diagnostics.Debug.WriteLine("No row selected in dgvLich.");
                MessageBox.Show("Vui lòng chọn một lịch thi để gia hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin từ form
            string maPDT = txtMaPDT.Text.Trim();
            string maTS = txtMaTS.Text.Trim();
            DateTime ngayGiaHan = dtpNgayGiaHan.Value;
            string lyDo = txtLyDoGH.Text.Trim();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(maPDT))
            {
                System.Diagnostics.Debug.WriteLine("MaPDT is empty.");
                MessageBox.Show("Vui lòng nhập mã phiếu dự thi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(lyDo))
            {
                System.Diagnostics.Debug.WriteLine("LyDo is empty.");
                MessageBox.Show("Vui lòng nhập lý do gia hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin từ dòng được chọn trong DataGridView
            DataGridViewRow selectedRow = dgvLich.SelectedRows[0];
            string maLT;
            DateTime ngayGioThiMoi;

            try
            {
                maLT = selectedRow.Cells["MaLT"].Value?.ToString();
                ngayGioThiMoi = Convert.ToDateTime(selectedRow.Cells["NgayGioThi"].Value);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in btnGiaHan_Click: {ex.Message}");
                MessageBox.Show("Lỗi khi lấy dữ liệu từ lịch thi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra giá trị MaLT
            if (string.IsNullOrWhiteSpace(maLT))
            {
                System.Diagnostics.Debug.WriteLine("MaLT is empty.");
                MessageBox.Show("Mã lịch thi không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hiển thị thông báo xác nhận
            System.Diagnostics.Debug.WriteLine("Showing confirmation message box.");
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn gia hạn không?", "Xác nhận gia hạn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                System.Diagnostics.Debug.WriteLine("User canceled the extension.");
                return; // Người dùng chọn "No", hủy bỏ gia hạn
            }

            // Gọi phương thức GiaHan để kiểm tra điều kiện và thực hiện gia hạn
            var (success, message) = giaHanBus.GiaHan(maPDT, maTS, ngayGiaHan, lyDo, maLT, ngayGioThiMoi);

            // Hiển thị kết quả
            if (success)
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Làm mới DataGridView sau khi gia hạn
                bool coLichThi = lichBus.KiemTraLichThi(ngayGiaHan);
                if (coLichThi)
                {
                    dgvLich.DataSource = lichBus.LayLichTheoNgay(ngayGiaHan);
                }
                else
                {
                    dgvLich.DataSource = null;
                }
            }
            else
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaPDT_TextChanged(object sender, EventArgs e)
        {
        }
    }
}