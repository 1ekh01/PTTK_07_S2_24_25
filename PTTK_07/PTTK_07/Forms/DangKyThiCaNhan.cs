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
        private string tenKhachHang;
        private string tenThiSinh;
        public DangKyThiCaNhan()
        {
            InitializeComponent();
            this.Load += GV_LapPhieuDangKy_Load;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
        }
        private Forms.DangNhap _dangNhapForm;
        private DataTable allLichThi;
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
            // Load loại chứng chỉ
            var lcc = new DB().Select(
            "SELECT MaLCC, MaLCC + ' - ' + TenLoaiChungChi as DisplayValue FROM LOAI_CHUNG_CHI"); /*, MaLCC + ' - ' + TenLoaiChungChi as DisplayValue*/
            DataTable dt = new DataTable();
            dt.Load(lcc);
            // Placeholder
            DataRow rowLCC = dt.NewRow();
            rowLCC["MaLCC"] = "-- Chọn --";
            rowLCC["DisplayValue"] = "-- Chọn --";
            dt.Rows.InsertAt(rowLCC, 0);
            // Thêm vào cbb
            cbbNewMaLCCPDK.DataSource = dt;
            cbbNewMaLCCPDK.DisplayMember = "DisplayValue";  // Hiển thị lên combobox
            cbbNewMaLCCPDK.ValueMember = "MaLCC";    // Dùng làm giá trị thực tế

            // Load toàn bộ lịch thi ban đầu
            var lichThi = new DB().Select("SELECT MaLT, LoaiChungChi FROM LICH_THI");
            allLichThi = new DataTable();
            allLichThi.Load(lichThi);
            // Placeholder
            DataRow rowLT = allLichThi.NewRow();
            rowLT["MaLT"] = "-- Chọn --";
            rowLT["LoaiChungChi"] = "-- Chọn --";
            allLichThi.Rows.InsertAt(rowLT, 0);
            //Thêm vào cbb
            cbbNewMaLTPDK.DataSource = allLichThi;
            cbbNewMaLTPDK.DisplayMember = "MaLT";
            cbbNewMaLTPDK.ValueMember = "MaLT";
            // Gọi func để check lịch thi tương ứng
            cbbNewMaLCCPDK.SelectedIndexChanged += cbbNewMaLCCPDK_SelectedIndexChanged;
        }
        private void cbbNewMaLCCPDK_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMaLCC = cbbNewMaLCCPDK.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(selectedMaLCC) || selectedMaLCC == "--") // Nếu đang ở placeholder
            {
                cbbNewMaLTPDK.DataSource = allLichThi;
                cbbNewMaLTPDK.DisplayMember = "MaLT";
                cbbNewMaLTPDK.ValueMember = "MaLT";
                return;
            }

            // Lọc dữ liệu lịch thi theo MaLCC
            DataView filteredView = new DataView(allLichThi);
            filteredView.RowFilter = $"LoaiChungChi = '{selectedMaLCC}'";

            cbbNewMaLTPDK.DataSource = filteredView;
            cbbNewMaLTPDK.DisplayMember = "MaLT";
            cbbNewMaLTPDK.ValueMember = "MaLT";
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
            string NewMaLTPDK = cbbNewMaLTPDK.SelectedValue?.ToString();
            string NewMaLCCPDK = cbbNewMaLCCPDK.SelectedValue?.ToString();
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

        //btnTimTenKH, btnHuyTimTenKH, txtTimTenKH
        private void btnTimTenKH_Click(object sender, EventArgs e)
        {
            tenKhachHang = txtTimTenKH.Text.Trim();
            if (!string.IsNullOrWhiteSpace(tenKhachHang))
            {
                LayKhachHangNVTN(tenKhachHang);
                txtTimTenKH.Enabled = false;
                btnTimTenKH.Enabled = false;
            }
        }
        private void btnHuyTimTenKH_Click(object sender, EventArgs e)
        {
            tenKhachHang = "";
            LayDanhSachKhachHang();
            txtTimTenKH.Enabled = true;
            btnTimTenKH.Enabled = true;
            txtTimTenKH.Text = "";
        }
        private void LayKhachHangNVTN(string tenKhachHang)
        {
            try
            {
                if (tenKhachHang == null) { tenKhachHang = "M"; }
                // Gọi phương thức SelectFunction từ DatabaseHelper để truy xuất function F_MaKH_to_KHACH_HANG_NVTN
                var kh = new DB().SelectFunction("F_TenKH_to_KHACH_HANG_NVTN", tenKhachHang);
                {
                    if (kh != null)
                    {
                        // Tạo DataTable và load dữ liệu từ SqlDataReader
                        DataTable dt = new DataTable();
                        dt.Load(kh);
                        // Gán DataTable làm nguồn dữ liệu cho GridView
                        gvKhachHang.DataSource = dt;
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

        private void btnTimTenTS_Click(object sender, EventArgs e)
        {
            tenThiSinh = txtTimTenTS.Text.Trim();
            if (!string.IsNullOrWhiteSpace(tenThiSinh))
            {
                LayThiSinhNVTN(tenThiSinh);
                txtTimTenTS.Enabled = false;
                btnTimTenTS.Enabled = false;
            }
        }

        private void btnHuyTimTenTS_Click(object sender, EventArgs e)
        {
            tenThiSinh = "";
            LayDanhSachThiSinh();
            txtTimTenTS.Enabled = true;
            btnTimTenTS.Enabled = true;
            txtTimTenTS.Text = "";
        }
        private void LayThiSinhNVTN(string tenThiSinh)
        {
            try
            {
                if (tenThiSinh == null) { tenThiSinh = "M"; }
                // Gọi phương thức SelectFunction từ DatabaseHelper để truy xuất function F_MaKH_to_KHACH_HANG_NVTN
                var kh = new DB().SelectFunction("F_TenTS_to_THI_SINH_NVTN", tenThiSinh);
                {
                    if (kh != null)
                    {
                        // Tạo DataTable và load dữ liệu từ SqlDataReader
                        DataTable dt = new DataTable();
                        dt.Load(kh);
                        // Gán DataTable làm nguồn dữ liệu cho GridView
                        gvThiSinh.DataSource = dt;
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

        private void btnInPhieuDangKy_Click(object sender, EventArgs e)
        {
            string maPDK = txtInMaPDK.Text.Trim();
            if (string.IsNullOrEmpty(maPDK))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu đăng ký.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var db = new DB();
                var reader = db.SelectFunction("F_MaPDK_to_PHIEU_DANG_KY_NVTN", maPDK);

                if (reader != null && reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    if (dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        string message = $"Phiếu đăng ký: {row["MaPDK"]}\n" +
                                         $"Khách hàng: {row["TenKH"]}\n" +
                                         $"Thí sinh: {row["TenTS"]}\n" +
                                         $"Chứng chỉ: {row["TenLoaiChungChi"]}\n" +
                                         $"Ngày giờ thi: {row["NgayGioThi"]}\n" +
                                         $"Ngày lập: {Convert.ToDateTime(row["NgayLapPDK"]).ToString("dd/MM/yyyy")}\n" +
                                         $"Hạn thanh toán: {Convert.ToDateTime(row["HanThanhToan"]).ToString("dd/MM/yyyy")}\n" +
                                         $"Trạng thái: {row["TrangThai"]}";

                        MessageBox.Show(message, "Đã in phiếu đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phiếu đăng ký với mã đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu trả về.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetFormDangKy_Click(object sender, EventArgs e)
        {
            // Xóa TextBox
            txtNewMaTSPDK.Text = "";

            // Reset ComboBox về placeholder (thường là index = 0)
            if (cbbNewMaLCCPDK.Items.Count > 0)
                cbbNewMaLCCPDK.SelectedIndex = 0;

            if (cbbNewMaLTPDK.Items.Count > 0)
                cbbNewMaLTPDK.SelectedIndex = 0;

            // (Tuỳ ý thêm các trường khác nếu có)
        }
    }
}
