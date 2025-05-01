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
            FormThemKhachHang_Load();
            FormThemLCC_Load();
        }

        // Nút Log Out
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

        // Khởi tạo, hiển thị danh sách các thông tin
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

        // Khởi tạo hàm thêm thông tin cho combobox loại khách hàng
        private void FormThemKhachHang_Load()
        {
            var roles = new List<string> {"Cá nhân", "Đơn vị"};
            cbbNewLoaiKH.DataSource = roles;
        }
        private void FormThemLCC_Load()
        {
            var lcc = new DB().Select(
            "SELECT MaLCC FROM LOAI_CHUNG_CHI"); /*, MaLCC + ' - ' + TenLoaiChungChi as DisplayValue*/

            DataTable dt = new DataTable();
            dt.Load(lcc);

            cbbNewMaLCCPDK.DataSource = dt;
            cbbNewMaLCCPDK.DisplayMember = "MaLCC";  // Hiển thị lên combobox
            cbbNewMaLCCPDK.ValueMember = "MaLCC";    // Dùng làm giá trị thực tế
            //var lcc = new List<string> { "LOCC000001", "LOCC000002", "LOCC000003", "LOCC000004", "LOCC000005" };
            //cbbNewMaLCCPDK.DataSource = lcc;
        }

        // Thêm Khách hàng
        private void btnNewTaoKH_Click(object sender, EventArgs e)
        {
            string NewTenKH = txtNewTenKH.Text.Trim();
            string NewDiaChiKH = txtNewDiaChiKH.Text.Trim();
            string NewLoaiKH = cbbNewLoaiKH.SelectedItem?.ToString();
            string NewEmailKH = txtNewEmailKH.Text.Trim();
            string NewSDTKH = txtNewSDTKH.Text.Trim();
            try
            {
                // Tạo đối tượng DB và danh sách tham số
                var db = new DB();
                var parameters = new Dictionary<string, object>
                {
                    { "@v_TenKH", NewTenKH },
                    { "@v_LoaiKH", NewLoaiKH },
                    { "@v_SDT", NewSDTKH },
                    { "@v_DiaChi", NewDiaChiKH },            
                    { "@v_Email", NewEmailKH }            
                };

                // Gọi PROCEDURE
                bool success = db.ExecuteProcedure("P_INSERT_KHACH_HANG_NVTN", parameters);

                // Xử lý kết quả
                if (success)
                {
                    MessageBox.Show("Thêm Khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Làm mới GridView
                    LayDanhSachKhachHang();
                }
                else
                {
                    MessageBox.Show("Thêm Khách hàng thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewTaoTS_Click(object sender, EventArgs e)
        {
            string NewTenTS = txtNewTenTS.Text.Trim();
            DateTime NewNgaySinhTS = dtpNewNgaySinhTS.Value;
            string NewCCCDTS = txtNewCCCDTS.Text.Trim();
            string NewMaKHTS = txtNewMaKHTS.Text.Trim();

            try
            {
                var db = new DB();
                var parameters = new Dictionary<string, object>
        {
            { "@v_TenTS", NewTenTS },
            { "@v_NgaySinh", NewNgaySinhTS },
            { "@v_CCCD", NewCCCDTS },
            { "@v_MaKH", NewMaKHTS }
        };

                bool success = db.ExecuteProcedure("P_INSERT_THI_SINH_NVTN", parameters);

                if (success)
                {
                    MessageBox.Show("Thêm Thí sinh thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LayDanhSachThiSinh();
                }
                else
                {
                    MessageBox.Show("Thêm Thí sinh thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLapPhieuDangKy_Click(object sender, EventArgs e)
        {
            string NewMaTSPDK = txtNewMaTSPDK.Text.Trim();
            string NewMaLTPDK = txtNewMaLTPDK.Text.Trim();
            string NewMaLCCPDK = cbbNewMaLCCPDK.SelectedItem?.ToString();
            string NewMaNVTN = "NHVN000001";

            try
            {
                var db = new DB();
                var parameters = new Dictionary<string, object>
        {
            { "@v_MaTS", NewMaTSPDK },
            { "@v_MaLT", NewMaLTPDK },
            { "@v_MaLCC", NewMaLCCPDK },
            { "@v_MaNVTiepNhan", NewMaNVTN }
        };

                bool success = db.ExecuteProcedure("P_INSERT_PHIEU_DANG_KY_NVTN", parameters);

                if (success)
                {
                    MessageBox.Show("Thêm Phiếu đăng ký thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LayDanhSachThiSinh();
                }
                else
                {
                    MessageBox.Show("Thêm Phiếu đăng ký thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
