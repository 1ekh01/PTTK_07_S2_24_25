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
    public partial class DangKyThiCaNhan : Form
    {
        public DangKyThiCaNhan()
        {
            InitializeComponent();
            this.Load += GV_LapPhieuDangKy_Load;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
        }
        private Forms.DangNhap _dangNhapForm;
        private void GV_LapPhieuDangKy_Load(object sender, EventArgs e)
        {
            LayDanhSachKhachHang();
            LayDanhSachThiSinh();
            LayDanhSachLichThiConTrong();
            LayDanhSachLoaiChungChi();
            LayDanhSachPhieuDangKy();
        }
        private void LayDanhSachKhachHang()
        {
            try
            {
                var kh = new DB().Select("SELECT MaKH, TenKH, LoaiKH, SDT, DiaChi, Email FROM KHACH_HANG");

                DataTable dt = new DataTable();
                dt.Load(kh);

                gvKhachHang.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LayDanhSachThiSinh()
        {
            try
            {
                var ts = new DB().Select("SELECT MaTS, TenTS, NgaySinh, CCCD, MaKH FROM THI_SINH");

                DataTable dt = new DataTable();
                dt.Load(ts);

                gvThiSinh.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LayDanhSachLichThiConTrong()
        {
            try
            {
                var lt = new DB().Select(
                "SELECT MaLT, NgayGioThi, SoLuongToiDa, SoLuongDaDangKy, LoaiChungChi, MaPT FROM LICH_THI WHERE SoLuongDaDangKy < SoLuongToiDa");

                DataTable dt = new DataTable();
                dt.Load(lt);

                gvLichThiConTrong.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LayDanhSachLoaiChungChi()
        {
            try
            {
                var lcc = new DB().Select("SELECT MaLCC, TenLoaiChungChi, LinhVucChungChi, DiemChuan, ThoiHan FROM LOAI_CHUNG_CHI");

                DataTable dt = new DataTable();
                dt.Load(lcc);

                gvLoaiChungChi.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LayDanhSachPhieuDangKy()
        {
            try
            {
                var pdk = new DB().Select("SELECT MaPDK, MaPDK, TrangThai, NgayDangKyThi, HanThanhToan, MaLCC, MaLT, MaKH, MaTS, MaNVTiepNhan FROM PHIEU_DANG_KY");

                DataTable dt = new DataTable();
                dt.Load(pdk);

                gvPhieuDangKy.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
