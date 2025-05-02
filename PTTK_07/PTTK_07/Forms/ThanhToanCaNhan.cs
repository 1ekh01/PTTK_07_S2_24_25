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

        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            string NewMaPDK = txtMaPDK.Text.Trim();
            string NewSoTien = txtSoTien.Text.Trim();
            string NewChietKhau = txtChietKhau.Text.Trim();
            string NewTrangThai = "Đã TT";
            DateTime NewNgayGioTT = dtpNewNgayGioTT.Value;
            string NewMaNVKT = "NHVN000003";
            string NewHinhThucThanhToan = "Tiền mặt";

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
            string MaPDK = txtPDK.Text.Trim();



        }

        private void btnHuyTimMaPDK_Click(object sender, EventArgs e)
        {

        }
    }
 }
