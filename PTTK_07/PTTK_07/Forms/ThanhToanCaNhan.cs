using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTTK_07.Helpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PTTK_07.Forms
{
    public partial class ThanhToanCaNhan : Form
    {
        private string MaPDK;
        private string MaHoaDon;
        public ThanhToanCaNhan()
        {
            InitializeComponent();
            this.Load += GV_LapPhieuDangKy_Load;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
        }
        private Forms.DangNhap _dangNhapForm;
        private void GV_LapPhieuDangKy_Load(object sender, EventArgs e)
        {
            LayDanhSachPhieuDangKy();
            LayDanhSachHoaDon();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị hộp thoại xác nhận
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?",
                                                  "Xác nhận đăng xuất",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    //// Mở lại form đăng nhập
                    //var loginForm = new DangNhap(); // Thay LoginForm bằng tên form đăng nhập thực tế
                    //loginForm.Show();
                    if (_dangNhapForm == null || _dangNhapForm.IsDisposed)
                    {
                        _dangNhapForm = new Forms.DangNhap();
                    }
                    _dangNhapForm.Show();
                    _dangNhapForm.FormClosed += (s, args) => Application.Exit();
                    this.Hide();

                    // Đóng form hiện tại
                    //this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đăng xuất: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LayDanhSachPhieuDangKy()
        {
            try
            {
                var pdk = new DB().Select("SELECT MaPDK, TrangThai, NgayDangKyThi, HanThanhToan, MaLCC, MaLT, MaKH, MaTS, MaNVTiepNhan FROM PHIEU_DANG_KY");

                DataTable dt = new DataTable();
                dt.Load(pdk);

                gvPhieuDangKy.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LayDanhSachHoaDon()
        {
            try
            {
                var pdk = new DB().Select("SELECT MaHD, NgayGioThanhToan, SoTienThanhToan, HinhThucThanhToan, TrangThai, ChietKhau, MaPDK,  MaNVKeToan FROM HOA_DON");

                DataTable dt = new DataTable();
                dt.Load(pdk);

                gvHoaDon.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormHinhThucTT_Load()
        {
            var roles = new List<string> { "Chuyển khoản", "Tiền mặt" };
            cbbHinhThucTT.DataSource = roles;
        }

        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            string NewMaPDK = txtMaPDK.Text.Trim();
            string NewSoTien = txtSoTien.Text.Trim();
            string NewChietKhau = txtChietKhau.Text.Trim();
            string NewTrangThai = "Đã TT";
            DateTime NewNgayGioTT = dtpNewNgayGioTT.Value;
            string NewMaNVKT = "NHVN000003";
            string NewHinhThucThanhToan = cbbHinhThucTT.SelectedValue?.ToString();

            try
            {
                var db = new DB();
                var parameters = new Dictionary<string, object>
        {
            { "@v_MaPDK", NewMaPDK },
            { "@v_SoTienThanhToan", NewSoTien },
            { "@v_ChietKhau", NewChietKhau },
            { "@v_MaNVKeToan", NewMaNVKT },
            { "@v_HinhThucThanhToan", NewHinhThucThanhToan},
            { "@v_TrangThai", NewTrangThai},
            { "@v_NgayGioThanhToan", NewNgayGioTT}
        };

                bool success = db.ExecuteProcedure("P_INSERT_HOA_DON_NVKT", parameters);

                if (success)
                {
                    MessageBox.Show("Thêm hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LayDanhSachHoaDon();
                    LayDanhSachPhieuDangKy();
                }
                else
                {
                    MessageBox.Show("Thêm hóa đơn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimMaPDK_Click_1(object sender, EventArgs e)
        {
            MaPDK = txtPDK.Text.Trim();
            if (!string.IsNullOrWhiteSpace(MaPDK))
            {
                LayPDKMaPDK(MaPDK);
                txtPDK.Enabled = false;
                btnTimMaPDK.Enabled = false;
            }
        }

        private void btnHuyTimMaPDK_Click(object sender, EventArgs e)
        {
            MaPDK = "";
            LayDanhSachPhieuDangKy();
            txtPDK.Enabled = true;
            btnTimMaPDK.Enabled = true;
            txtPDK.Text = "";
        }
        private void LayPDKMaPDK(string MaPDK)
        {
            try
            {
                if (MaPDK == null) { MaPDK = "M"; }
                // Gọi phương thức SelectFunction từ DatabaseHelper để truy xuất function F_MaKH_to_KHACH_HANG_NVTN
                var kh = new DB().SelectFunction("F_MaPDK_to_HOA_DON_NVKT", MaPDK);
                {
                    if (kh != null)
                    {
                        // Tạo DataTable và load dữ liệu từ SqlDataReader
                        DataTable dt = new DataTable();
                        dt.Load(kh);
                        // Gán DataTable làm nguồn dữ liệu cho GridView
                        gvPhieuDangKy.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimMaHoaDon_Click(object sender, EventArgs e)
        {
            MaHoaDon = txtHoaDon.Text.Trim();
            if (!string.IsNullOrWhiteSpace(MaHoaDon))
            {
                LayHoaDonMaHoaDon(MaHoaDon);
                txtHoaDon.Enabled = false;
                btnTimMaHoaDon.Enabled = false;
            }
        }

        private void btnHuyTimMaHoaDon_Click(object sender, EventArgs e)
        {
            MaHoaDon = "";
            LayDanhSachHoaDon();
            txtHoaDon.Enabled = true;
            btnTimMaHoaDon.Enabled = true;
            txtHoaDon.Text = "";
        }
        private void LayHoaDonMaHoaDon(string MaHoaDon)
        {
            try
            {
                if (MaHoaDon == null) { MaHoaDon = "M"; }
                // Gọi phương thức SelectFunction từ DatabaseHelper để truy xuất function F_MaKH_to_KHACH_HANG_NVTN
                var kh = new DB().SelectFunction("F_MaHoaDon_to_HOA_DON_NVKT", MaHoaDon);
                {
                    if (kh != null)
                    {
                        // Tạo DataTable và load dữ liệu từ SqlDataReader
                        DataTable dt = new DataTable();
                        dt.Load(kh);
                        // Gán DataTable làm nguồn dữ liệu cho GridView
                        gvHoaDon.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
 }
