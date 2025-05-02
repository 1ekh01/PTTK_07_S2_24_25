using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTTK_07.Forms;

namespace PTTK_07.Forms
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
            btnDangNhap.Click += btnDangNhap_Click;
        }
        private Forms.DangKyThiCaNhan _dangKyThiCaNhanForm;
        private Forms.DangKyThiDonVi _dangKyThiDonViForm;
        private Forms.LapPhieuDangKy _lapPhieuForm;
        private Forms.ThanhToanCaNhan _thanhToanCaNhanForm;
        private Forms.ThanhToanDonVi _thanhToanDonViForm;
        private Forms.GiaHanDacBiet _giaHanDacBietForm;
        private Forms.GiaHanTinhPhi _giaHanTinhPhiForm;
        private Forms.CapChungChi _capChungChiForm;
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenTaiKhoan.Text.Trim();
            string password = txtMatKhau.Text.Trim();
            string usecase  = cbUseCase.Text.Trim();

            if (usecase == "Đăng ký thi Cá nhân")
            {
                if (username == "NVTN" && password == "NVTN")
                {
                    if (_dangKyThiCaNhanForm == null || _dangKyThiCaNhanForm.IsDisposed)
                    {
                        _dangKyThiCaNhanForm = new Forms.DangKyThiCaNhan();
                    }
                    _dangKyThiCaNhanForm.Show();
                    _dangKyThiCaNhanForm.FormClosed += (s, args) => Application.Exit();
                    this.Hide();
                }
            }
            else if (usecase == "Đăng ký thi Đơn vị")
            {
                if (username == "NVTN" && password == "NVTN")
                {
                    if (_dangKyThiDonViForm == null || _dangKyThiDonViForm.IsDisposed)
                    {
                        _dangKyThiDonViForm = new Forms.DangKyThiDonVi();
                    }
                    _dangKyThiDonViForm.Show();
                    _dangKyThiDonViForm.FormClosed += (s, args) => Application.Exit();
                    this.Hide();
                }
            }
            else if (usecase == "Lập Phiếu đăng ký")
            {
                if (username == "NVTN" && password == "NVTN")
                {
                    if (_lapPhieuForm == null || _lapPhieuForm.IsDisposed)
                    {
                        _lapPhieuForm = new Forms.LapPhieuDangKy();
                    }
                    _lapPhieuForm.Show();
                    _lapPhieuForm.FormClosed += (s, args) => Application.Exit();
                    this.Hide();
                }
            }
            else if (usecase == "Thanh toán Cá nhân")
            {
                if (username == "NVKT" && password == "NVKT")
                {
                    if (_thanhToanCaNhanForm == null || _thanhToanCaNhanForm.IsDisposed)
                    {
                        _thanhToanCaNhanForm = new Forms.ThanhToanCaNhan();
                    }
                    _thanhToanCaNhanForm.Show();
                    _thanhToanCaNhanForm.FormClosed += (s, args) => Application.Exit();
                    this.Hide();
                }
            }
            else if (usecase == "Thanh toán Đơn vị")
            {
                if (username == "NVKT" && password == "NVKT")
                {
                    if (_thanhToanDonViForm == null || _thanhToanDonViForm.IsDisposed)
                    {
                        _thanhToanDonViForm = new Forms.ThanhToanDonVi();
                    }
                    _thanhToanDonViForm.Show();
                    _thanhToanDonViForm.FormClosed += (s, args) => Application.Exit();
                    this.Hide();
                }
            }
            else if (usecase == "Gia hạn Đặc biệt")
            {
                if (username == "NVTN" && password == "NVTN")
                {
                    if (_giaHanDacBietForm == null || _giaHanDacBietForm.IsDisposed)
                    {
                        _giaHanDacBietForm = new Forms.GiaHanDacBiet();
                    }
                    _giaHanDacBietForm.Show();
                    _giaHanDacBietForm.FormClosed += (s, args) => Application.Exit();
                    this.Hide();
                }
                else if (username == "NVKT" && password == "NVKT")
                {
                    if (_giaHanDacBietForm == null || _giaHanDacBietForm.IsDisposed)
                    {
                        _giaHanDacBietForm = new Forms.GiaHanDacBiet();
                    }
                    _giaHanDacBietForm.Show();
                    _giaHanDacBietForm.FormClosed += (s, args) => Application.Exit();
                    this.Hide();
                }
            }
            else if (usecase == "Gia hạn Tính phí")
            {
                if (username == "NVTN" && password == "NVTN")
                {
                    if (_giaHanTinhPhiForm == null || _giaHanTinhPhiForm.IsDisposed)
                    {
                        _giaHanTinhPhiForm = new Forms.GiaHanTinhPhi();
                    }
                    _giaHanTinhPhiForm.Show();
                    _giaHanTinhPhiForm.FormClosed += (s, args) => Application.Exit();
                    this.Hide();
                }
                else if (username == "NVKT" && password == "NVKT")
                {
                    if (_giaHanTinhPhiForm == null || _giaHanTinhPhiForm.IsDisposed)
                    {
                        _giaHanTinhPhiForm = new Forms.GiaHanTinhPhi();
                    }
                    _giaHanTinhPhiForm.Show();
                    _giaHanTinhPhiForm.FormClosed += (s, args) => Application.Exit();
                    this.Hide();
                }
            }
            else if (usecase == "Cấp chứng chỉ")
            {
                if (username == "NVNL" && password == "NVNL")
                {
                    if (_capChungChiForm == null || _capChungChiForm.IsDisposed)
                    {
                        _capChungChiForm = new Forms.CapChungChi();
                    }
                    _capChungChiForm.Show();
                    _capChungChiForm.FormClosed += (s, args) => Application.Exit();
                    this.Hide();
                }
                else if (username == "NVTN" && password == "NVTN")
                {
                    if (_capChungChiForm == null || _capChungChiForm.IsDisposed)
                    {
                        _capChungChiForm = new Forms.CapChungChi();
                    }
                    _capChungChiForm.Show();
                    _capChungChiForm.FormClosed += (s, args) => Application.Exit();
                    this.Hide();
                }
            }
        }
    }
}
