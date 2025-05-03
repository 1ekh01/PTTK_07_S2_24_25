using PTTK_07.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Drawing;
namespace PTTK_07.Forms
{
    public partial class CapChungChi : Form
    {
        private string maKetQuaThi;
        private string maKhachHang_ChungChi;
        private Forms.DangNhap _dangNhapForm;
        public CapChungChi(string role)
        {
            InitializeComponent();
            if (role == "NVNL")
            {
                this.Load += UnLoad_NVTN;
                this.Load += GV_CapChungChi_Load_NVNL;
            }
            if (role == "NVTN")
            {
                this.Load += UnLoad_NVNL;
                this.Load += GV_CapChungChi_Load_NVTN;
            }
        }
        private void UnLoad_NVNL(object sender, EventArgs e)
        {
            gbNVNL.Enabled = false;
            foreach (Control control in gbNVNL.Controls)
            {
                control.Enabled = false;
            }
        }
        private void UnLoad_NVTN(object sender, EventArgs e)
        {
            gbNVTN.Enabled = false;
            foreach (Control control in gbNVTN.Controls)
            {
                control.Enabled = false;
            }
        }

        //----------------------------------------------------------------------------------------
        //Nhân viên nhập liệu
        private void GV_CapChungChi_Load_NVNL(object sender, EventArgs e)
        {
            LayDanhSachKetQuaThi_NVNL(maKetQuaThi);
            LayThiSinh_NVNL(maKetQuaThi);
            LayKhachHang_NVNL(maKetQuaThi);
            LayLoaiChungChi_NVNL(maKetQuaThi);
        }
        private void GV_CapChungChi_Load_NVTN(object sender, EventArgs e)
        {
            LayDanhSachKhachHang_NVTN(maKhachHang_ChungChi);
            LayDanhSachChungChi_ThiSinh_NVTN(maKhachHang_ChungChi);
        }
        //private void LayDanhSachKetQuaThi_NVNL(string maKetQuaThi)
        //{
        //    try
        //    {
        //        if (maKetQuaThi == null || maKetQuaThi == "M")
        //        {
        //            var kqt = new DB().SelectFunction("F_SELECT_KET_QUA_THI_NVNL", "X");
        //            {
        //                if (kqt != null)
        //                {
        //                    // Tạo DataTable và load dữ liệu từ SqlDataReader
        //                    DataTable dt = new DataTable();
        //                    dt.Load(kqt);

        //                    // Gán DataTable làm nguồn dữ liệu cho GridView
        //                    gvKetQuaThi.DataSource = dt;
        //                    if (gvKetQuaThi.Columns.Count > 0)
        //                    {
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Không tìm thấy dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //            }
        //        }
        //        // Gọi phương thức SelectFunction từ DatabaseHelper để truy xuất function F_MaKQT_to_KET_QUA_THI_NVNL
        //        else if (maKetQuaThi != null)
        //        {
        //            var kqt = new DB().SelectFunction("F_MaKQT_to_KET_QUA_THI_NVNL", maKetQuaThi);
        //            {
        //                if (kqt != null)
        //                {
        //                    // Tạo DataTable và load dữ liệu từ SqlDataReader
        //                    DataTable dt = new DataTable();
        //                    dt.Load(kqt);

        //                    // Gán DataTable làm nguồn dữ liệu cho GridView
        //                    gvKetQuaThi.DataSource = dt;
        //                    if (gvKetQuaThi.Columns.Count > 0)
        //                    {
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Không tìm thấy dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void LayDanhSachKetQuaThi_NVNL(string maKetQuaThi)
        {
            try
            {
                var db = new DB();
                Dictionary<string, object> parameters = null;
                string functionName;

                // Xác định hàm SQL dựa trên maKetQuaThi
                if (string.IsNullOrWhiteSpace(maKetQuaThi) || maKetQuaThi == "M")
                {
                    functionName = "F_SELECT_KET_QUA_THI_NVNL";
                    parameters = null; // Không có tham số
                }
                else
                {
                    functionName = "F_MaKQT_to_KET_QUA_THI_NVNL";
                    parameters = new Dictionary<string, object>
                        {
                            { "@v_makqt", maKetQuaThi }
                        };
                }

                // Gọi SelectFunction
                using (var kqt = db.SelectFunction2(functionName, parameters))
                {
                    // Kiểm tra reader hợp lệ
                    if (kqt != null && !kqt.IsClosed)
                    {
                        // Tạo DataTable và load dữ liệu
                        DataTable dt = new DataTable();
                        dt.Load(kqt);

                        // Gán DataTable làm nguồn dữ liệu cho GridView
                        gvKetQuaThi_NVNL.DataSource = dt;

                        // Tùy chỉnh cột
                        if (gvKetQuaThi_NVNL.Columns.Count > 0)
                        {
                            if (gvKetQuaThi_NVNL.Columns["Mã bài thi/kết quả thi"] != null)
                            {
                                gvKetQuaThi_NVNL.Columns["Mã bài thi/kết quả thi"].Width = 140;
                            }
                            if (gvKetQuaThi_NVNL.Columns["Ngày có điểm"] != null)
                            {
                                gvKetQuaThi_NVNL.Columns["Ngày có điểm"].Width = 130;
                            }
                            if (gvKetQuaThi_NVNL.Columns["Mã thí sinh"] != null)
                            {
                                gvKetQuaThi_NVNL.Columns["Mã thí sinh"].Width = 120;
                            }
                            if (gvKetQuaThi_NVNL.Columns["Mã loại chứng chỉ"] != null)
                            {
                                gvKetQuaThi_NVNL.Columns["Mã loại chứng chỉ"].Width = 170;
                            }
                            if (gvKetQuaThi_NVNL.Columns["Mã phiếu dự thi"] != null)
                            {
                                gvKetQuaThi_NVNL.Columns["Mã phiếu dự thi"].Width = 170;
                            }
                        }
                    }
                    else
                    {
                        gvKetQuaThi_NVNL.DataSource = null;
                        MessageBox.Show("Không tìm thấy dữ liệu cho Mã Kết Quả Thi này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Lỗi khi tải danh sách kết quả thi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LayKhachHang_NVNL(string maKetQuaThi)
        {
            try
            {
                if (maKetQuaThi == null)
                {
                    maKetQuaThi = "M";
                }
                // Gọi phương thức SelectFunction từ DatabaseHelper để truy xuất function F_MaKQT_to_KHACH_HANG_NVNL
                var kh = new DB().SelectFunction("F_MaKQT_to_KHACH_HANG_NVNL", maKetQuaThi);
                //using (var kh = db.SelectFunction("F_MaKQT_to_KHACH_HANG_NVNL", v_maKQT))
                {
                    if (kh != null)
                    {
                        // Tạo DataTable và load dữ liệu từ SqlDataReader
                        DataTable dt = new DataTable();
                        dt.Load(kh);

                        // Gán DataTable làm nguồn dữ liệu cho GridView
                        gvKhachHang_NVNL.DataSource = dt;
                        if (gvKhachHang_NVNL.Columns.Count > 0)
                        {
                            // Đổi độ rộng cột
                            if (gvKhachHang_NVNL.Columns["Mã khách hàng"] != null)
                            {
                                gvKhachHang_NVNL.Columns["Mã khách hàng"].Width = 150;
                            }
                            if (gvKhachHang_NVNL.Columns["Tên khách hàng"] != null)
                            {
                                gvKhachHang_NVNL.Columns["Tên khách hàng"].Width = 150;
                            }
                            if (gvKhachHang_NVNL.Columns["Loại khách hàng"] != null)
                            {
                                gvKhachHang_NVNL.Columns["Loại khách hàng"].Width = 160;
                            }
                            if (gvKhachHang_NVNL.Columns["Số điện thoại"] != null)
                            {
                                gvKhachHang_NVNL.Columns["Số điện thoại"].Width = 140;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LayThiSinh_NVNL(string maKetQuaThi)
        {
            try
            {
                if (maKetQuaThi == null)
                {
                    maKetQuaThi = "M";
                }
                // Gọi phương thức SelectFunction từ DatabaseHelper để truy xuất function F_MaKQT_to_THI_SINH_NVNL
                var ts = new DB().SelectFunction("F_MaKQT_to_THI_SINH_NVNL", maKetQuaThi);
                {
                    if (ts != null)
                    {
                        // Tạo DataTable và load dữ liệu từ SqlDataReader
                        DataTable dt = new DataTable();
                        dt.Load(ts);

                        // Gán DataTable làm nguồn dữ liệu cho GridView
                        gvThiSinh_NVNL.DataSource = dt;
                        if (gvThiSinh_NVNL.Columns.Count > 0)
                        {
                            // Đổi độ rộng cột
                            if (gvThiSinh_NVNL.Columns["Mã thí sinh"] != null)
                            {
                                gvThiSinh_NVNL.Columns["Mã thí sinh"].Width = 120;
                            }
                            if (gvThiSinh_NVNL.Columns["Tên thí sinh"] != null)
                            {
                                gvThiSinh_NVNL.Columns["Tên thí sinh"].Width = 130;
                            }
                            if (gvThiSinh_NVNL.Columns["Ngày sinh"] != null)
                            {
                                gvThiSinh_NVNL.Columns["Ngày sinh"].Width = 110;
                            }
                            if (gvThiSinh_NVNL.Columns["Căn cước công dân"] != null)
                            {
                                gvThiSinh_NVNL.Columns["Căn cước công dân"].Width = 180;
                            }
                            if (gvThiSinh_NVNL.Columns["Mã khách hàng"] != null)
                            {
                                gvThiSinh_NVNL.Columns["Mã khách hàng"].Width = 150;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LayLoaiChungChi_NVNL(string maKetQuaThi)
        {
            try
            {
                if (maKetQuaThi == null)
                {
                    maKetQuaThi = "M";
                }
                // Gọi phương thức SelectFunction từ DatabaseHelper để truy xuất function F_MaKQT_to_LOAI_CHUNG_CHI_NVNL
                var lcc = new DB().SelectFunction("F_MaKQT_to_LOAI_CHUNG_CHI_NVNL", maKetQuaThi);
                {
                    if (lcc != null)
                    {
                        // Tạo DataTable và load dữ liệu từ SqlDataReader
                        DataTable dt = new DataTable();
                        dt.Load(lcc);

                        // Gán DataTable làm nguồn dữ liệu cho GridView
                        gvLoaiChungChi_NVNL.DataSource = dt;
                        if (gvLoaiChungChi_NVNL.Columns.Count > 0)
                        {
                            // Đổi độ rộng cột
                            if (gvLoaiChungChi_NVNL.Columns["Mã loại chứng chỉ"] != null)
                            {
                                gvLoaiChungChi_NVNL.Columns["Mã loại chứng chỉ"].Width = 170;
                            }
                            if (gvLoaiChungChi_NVNL.Columns["Tên loại chứng chỉ"] != null)
                            {
                                gvLoaiChungChi_NVNL.Columns["Tên loại chứng chỉ"].Width = 190;
                            }
                            if (gvLoaiChungChi_NVNL.Columns["Lĩnh vực chứng chỉ"] != null)
                            {
                                gvLoaiChungChi_NVNL.Columns["Lĩnh vực chứng chỉ"].Width = 200;
                            }
                            if (gvLoaiChungChi_NVNL.Columns["Điểm chuẩn"] != null)
                            {
                                gvLoaiChungChi_NVNL.Columns["Điểm chuẩn"].Width = 130;
                            }
                            if (gvLoaiChungChi_NVNL.Columns["Thời hạn (tháng)"] != null)
                            {
                                gvLoaiChungChi_NVNL.Columns["Thời hạn (tháng)"].Width = 160;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimMaKQT_NVNL_Click(object sender, EventArgs e)
        {
            maKetQuaThi = txtMaKQT_NVNL.Text.Trim();
            if (!string.IsNullOrWhiteSpace(maKetQuaThi))
            {
                LayDanhSachKetQuaThi_NVNL(maKetQuaThi);
                LayThiSinh_NVNL(maKetQuaThi);
                LayKhachHang_NVNL(maKetQuaThi);
                LayLoaiChungChi_NVNL(maKetQuaThi);
                txtMaKQT_NVNL.Enabled = false;
                btnTimMaKQT_NVNL.Enabled = false;
                numDiemSo_NVNL.Enabled = true;
                btnNhapDiemSo_NVNL.Enabled = true;
            }
        }

        private void btnHuyTimMaKQT_NVNL_Click(object sender, EventArgs e)
        {
            maKetQuaThi = "M";
            LayDanhSachKetQuaThi_NVNL(maKetQuaThi);
            LayThiSinh_NVNL(maKetQuaThi);
            LayKhachHang_NVNL(maKetQuaThi);
            LayLoaiChungChi_NVNL(maKetQuaThi);
            txtMaKQT_NVNL.Enabled = true;
            txtMaKQT_NVNL.Text = "";
            btnTimMaKQT_NVNL.Enabled = true;
            numDiemSo_NVNL.Value = 0;
            numDiemSo_NVNL.Enabled = false;
            btnNhapDiemSo_NVNL.Enabled = false;
        }

        private void btnNhapDiemSo_NVNL_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ NumericUpDown hoặc TextBox
            float diemSoNum;
            try
            {
                // Giả sử numDiemSo là NumericUpDown
                diemSoNum = Convert.ToSingle(numDiemSo_NVNL.Value);
            }
            catch
            {
                // Nếu numDiemSo là TextBox, thử parse
                if (!float.TryParse(numDiemSo_NVNL.Text.Trim(), out diemSoNum))
                {
                    MessageBox.Show("Điểm số không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(maKetQuaThi))
            {
                MessageBox.Show("Vui lòng nhập Mã Kết Quả Thi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Tạo đối tượng DB và danh sách tham số
                var db = new DB();
                var parameters = new Dictionary<string, object>
                    {
                        { "@v_makqt", maKetQuaThi },
                        { "@v_diemso", diemSoNum }
                    };

                // Gọi PROCEDURE
                bool success = db.ExecuteProcedure("P_UPDATE_KET_QUA_THI_NVNL", parameters);

                // Xử lý kết quả
                if (success)
                {
                    MessageBox.Show("Cập nhật điểm số thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Làm mới GridView
                    LayDanhSachKetQuaThi_NVNL(maKetQuaThi);
                    //maKetQuaThi = "M";
                    //LayDanhSachKetQuaThi_NVNL(maKetQuaThi);
                    //LayThiSinh_NVNL(maKetQuaThi);
                    //LayKhachHang_NVNL(maKetQuaThi);
                    //LayLoaiChungChi_NVNL(maKetQuaThi);
                    //txtMaKQT_NVNL.Enabled = true;
                    //txtMaKQT_NVNL.Text = "";
                    //btnTimMaKQT_NVNL.Enabled = true;
                    //this.btnHuyTimMaKQT_NVNL.Click += new System.EventHandler(this.btnHuyTimMaKQT_Click);
                }
            }
            catch (SqlException ex)
            {
                //MessageBox.Show($"Lỗi khi cập nhật điểm số: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show($"Lỗi khi cập nhật điểm số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        //----------------------------------------------------------------------------------------
        //Nhân viên tiếp nhận
        private void LayDanhSachKhachHang_NVTN(string maKhachHang_ChungChi)
        {
            try
            {
                var db = new DB();
                Dictionary<string, object> parameters = null;
                string functionName;

                // Xác định hàm SQL dựa trên maKhachHang_ChungChi
                if (string.IsNullOrWhiteSpace(maKhachHang_ChungChi) || maKhachHang_ChungChi == "M")
                {
                    functionName = "F_SELECT_KHACH_HANG_NVTN";
                    parameters = null; // Không có tham số
                }
                else
                {
                    functionName = "F_MaKH_to_KHACH_HANG_NVTN";
                    parameters = new Dictionary<string, object>
                        {
                            { "@v_makh", maKhachHang_ChungChi }
                        };
                }

                // Gọi SelectFunction
                using (var kh = db.SelectFunction2(functionName, parameters))
                {
                    // Kiểm tra reader hợp lệ
                    if (kh != null && !kh.IsClosed)
                    {
                        // Tạo DataTable và load dữ liệu
                        DataTable dt = new DataTable();
                        dt.Load(kh);

                        // Gán DataTable làm nguồn dữ liệu cho GridView
                        gvKhachHang_NVTN.DataSource = dt;

                        // Tùy chỉnh cột
                        if (gvKhachHang_NVTN.Columns.Count > 0)
                        {
                            // Đổi độ rộng cột
                            if (gvKhachHang_NVTN.Columns["Mã khách hàng"] != null)
                            {
                                gvKhachHang_NVTN.Columns["Mã khách hàng"].Width = 150;
                            }
                            if (gvKhachHang_NVTN.Columns["Tên khách hàng"] != null)
                            {
                                gvKhachHang_NVTN.Columns["Tên khách hàng"].Width = 150;
                            }
                            if (gvKhachHang_NVTN.Columns["Loại khách hàng"] != null)
                            {
                                gvKhachHang_NVTN.Columns["Loại khách hàng"].Width = 160;
                            }
                            if (gvKhachHang_NVTN.Columns["Số điện thoại"] != null)
                            {
                                gvKhachHang_NVTN.Columns["Số điện thoại"].Width = 140;
                            }
                        }
                    }
                    else
                    {
                        gvKetQuaThi_NVNL.DataSource = null;
                        MessageBox.Show("Không tìm thấy dữ liệu cho Mã Kết Quả Thi này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Lỗi khi tải danh sách kết quả thi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LayDanhSachChungChi_ThiSinh_NVTN(string maKhachHang_ChungChi)
        {
            try
            {
                var db = new DB();
                Dictionary<string, object> parameters = null;

                // Xử lý maKhachHang_ChungChi
                if (string.IsNullOrWhiteSpace(maKhachHang_ChungChi))
                {
                    maKhachHang_ChungChi = "M";
                }

                // Thiết lập tham số cho SelectFunction2
                parameters = new Dictionary<string, object>
                    {
                        { "@v_makh", maKhachHang_ChungChi }
                    };

                // Gọi SelectFunction2
                using (var cc = db.SelectFunction2("F_MaKH_to_CHUNG_CHI_THI_SINH_NVTN", parameters))
                {
                    if (cc != null && !cc.IsClosed)
                    {
                        // Tạo DataTable và load dữ liệu
                        DataTable dt = new DataTable();
                        dt.Load(cc);

                        // Gán DataSource cho DataGridView
                        gvChungChi_ThiSinh_NVTN.DataSource = dt;

                        // Thêm cột checkbox nếu chưa tồn tại
                        if (!gvChungChi_ThiSinh_NVTN.Columns.Contains("Select"))
                        {
                            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                            {
                                Name = "Select",
                                HeaderText = "Chọn",
                                Width = 60,
                                FalseValue = false,
                                TrueValue = true
                            };
                            gvChungChi_ThiSinh_NVTN.Columns.Insert(0, checkBoxColumn); // Thêm cột checkbox ở đầu
                        }
                        // Tùy chỉnh các cột khác
                        if (gvChungChi_ThiSinh_NVTN.Columns.Count > 0)
                        {
                            if (gvChungChi_ThiSinh_NVTN.Columns["Mã chứng chỉ"] != null)
                            {
                                gvChungChi_ThiSinh_NVTN.Columns["Mã chứng chỉ"].Width = 130;
                            }
                            if (gvChungChi_ThiSinh_NVTN.Columns["Mã thí sinh"] != null)
                            {
                                gvChungChi_ThiSinh_NVTN.Columns["Mã thí sinh"].Width = 120;
                            }
                            if (gvChungChi_ThiSinh_NVTN.Columns["Tên thí sinh"] != null)
                            {
                                gvChungChi_ThiSinh_NVTN.Columns["Tên thí sinh"].Width = 130;
                            }
                            if (gvChungChi_ThiSinh_NVTN.Columns["Căn cước công dân"] != null)
                            {
                                gvChungChi_ThiSinh_NVTN.Columns["Căn cước công dân"].Width = 180;
                            }
                            if (gvChungChi_ThiSinh_NVTN.Columns["Ngày sinh"] != null)
                            {
                                gvChungChi_ThiSinh_NVTN.Columns["Ngày sinh"].Width = 110;
                            }
                            if (gvChungChi_ThiSinh_NVTN.Columns["Trạng thái"] != null)
                            {
                                gvChungChi_ThiSinh_NVTN.Columns["Trạng thái"].Width = 120;
                            }
                            if (gvChungChi_ThiSinh_NVTN.Columns["Xếp hạng"] != null)
                            {
                                gvChungChi_ThiSinh_NVTN.Columns["Xếp hạng"].Width = 110;
                            }
                            if (gvChungChi_ThiSinh_NVTN.Columns["Tên loại chứng chỉ"] != null)
                            {
                                gvChungChi_ThiSinh_NVTN.Columns["Tên loại chứng chỉ"].Width = 190;
                            }
                            if (gvChungChi_ThiSinh_NVTN.Columns["Ngày hết hạn"] != null)
                            {
                                gvChungChi_ThiSinh_NVTN.Columns["Ngày hết hạn"].Width = 130;
                            }
                        }
                        foreach (DataGridViewRow row in gvChungChi_ThiSinh_NVTN.Rows)
                        {
                            if (row.Cells["Trạng thái"].Value?.ToString() == "Đã trả")
                            {
                                DataGridViewCheckBoxCell chkCell = row.Cells["Select"] as DataGridViewCheckBoxCell;
                                chkCell.ReadOnly = true;

                                // Tô màu để báo hiệu checkbox không khả dụng
                                row.Cells["Select"].Style.BackColor = Color.LightGray;
                            }
                        }
                    }
                    else
                    {
                        gvChungChi_ThiSinh_NVTN.DataSource = null;
                        MessageBox.Show("Không tìm thấy dữ liệu cho Mã Khách Hàng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Lỗi khi tải danh sách chứng chỉ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnTimMaKH_ChungChi_Click(object sender, EventArgs e)
        {
            maKhachHang_ChungChi = txtMaKH_NVTN.Text.Trim();
            if (!string.IsNullOrWhiteSpace(maKhachHang_ChungChi))
            {
                LayDanhSachKhachHang_NVTN(maKhachHang_ChungChi);
                LayDanhSachChungChi_ThiSinh_NVTN(maKhachHang_ChungChi);
                txtMaKH_NVTN.Enabled = false;
                btnTimMaKH_NVTN.Enabled = false;
                txtTenKH_NVTN.Enabled = false;
                btnTimTenKH_NVTN.Enabled = false;
            }
        }
        private void btnHuyTimMaKH_ChungChi_Click(object sender, EventArgs e)
        {
            maKhachHang_ChungChi = "M";
            LayDanhSachKhachHang_NVTN(maKhachHang_ChungChi);
            LayDanhSachChungChi_ThiSinh_NVTN(maKhachHang_ChungChi);
            txtMaKH_NVTN.Enabled = true;
            txtMaKH_NVTN.Text = "";
            btnTimMaKH_NVTN.Enabled = true;
            txtTenKH_NVTN.Enabled = true;
            txtTenKH_NVTN.Text = "";
            btnTimTenKH_NVTN.Enabled = true;
        }
        private void btnTimTenKH_NVTN_Click(object sender, EventArgs e)
        {
            string tenKhachHang_ChungChi = txtMaKH_NVTN.Text.Trim();
            var db = new DB();
            maKhachHang_ChungChi = db.ExecuteFunctionGetReturn("F_TenKH_to_MaKH_NVNL", tenKhachHang_ChungChi);
            if (!string.IsNullOrWhiteSpace(maKhachHang_ChungChi))
            {
                LayDanhSachKhachHang_NVTN(maKhachHang_ChungChi);
                LayDanhSachChungChi_ThiSinh_NVTN(maKhachHang_ChungChi);
                txtMaKH_NVTN.Enabled = false;
                btnTimMaKH_NVTN.Enabled = false;
            }
        } 
        private void btnHuyTimTenKH_NVTN_Click(object sender, EventArgs e)
        {
            maKhachHang_ChungChi = "M";
            LayDanhSachKhachHang_NVTN(maKhachHang_ChungChi);
            LayDanhSachChungChi_ThiSinh_NVTN(maKhachHang_ChungChi);
            txtMaKH_NVTN.Enabled = true;
            txtMaKH_NVTN.Text = "";
            btnTimMaKH_NVTN.Enabled = true;
        }
        private void btnTraChungChi_NVTN_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> da_chon = new List<string>();

                // Duyệt từng dòng trong DataGridView
                foreach (DataGridViewRow row in gvChungChi_ThiSinh_NVTN.Rows)
                {
                    // Kiểm tra dòng hợp lệ và checkbox đã được chọn
                    if (Convert.ToBoolean(row.Cells["Select"].Value) == true)
                    {
                        var maCC = row.Cells["Mã chứng chỉ"].Value?.ToString();
                        if (!string.IsNullOrWhiteSpace(maCC))
                        {
                            da_chon.Add(maCC);
                        }
                    }
                }

                if (da_chon.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một chứng chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var db = new DB();
                int successCount = 0;

                // Gọi procedure cho từng mã chứng chỉ
                foreach (var maCC in da_chon)
                {
                    var parameters = new Dictionary<string, object>
                        {
                            { "@v_macc", maCC }
                        };

                    bool result = db.ExecuteProcedure("P_UPDATE_CHUNG_CHI_NVTN", parameters);

                    if (result)
                        successCount++;
                }

                MessageBox.Show($"Đã cập nhật {successCount}/{da_chon.Count} chứng chỉ thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật chứng chỉ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LayDanhSachChungChi_ThiSinh_NVTN(maKhachHang_ChungChi);
        }
        
        //----------------------------------------------------------------------------------------
        //Đăng xuất
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