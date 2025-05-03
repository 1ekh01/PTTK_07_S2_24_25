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
        private Forms.DangKyThiCaNhan _dangKyThiForm;
        private Forms.ThanhToanCaNhan _thanhToanForm;
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
                    if (_dangKyThiForm == null || _dangKyThiForm.IsDisposed)
                    {
                        _dangKyThiForm = new Forms.DangKyThiCaNhan();
                    }
                    _dangKyThiForm.Show();
                    _dangKyThiForm.FormClosed += (s, args) => Application.Exit();
                    this.Hide();
                }
            }
            else if (usecase == "Thanh toán Cá nhân")
            {
                if (username == "NVKT" && password == "NVKT")
                {
                    if (_thanhToanForm == null || _thanhToanForm.IsDisposed)
                    {
                        _thanhToanForm = new Forms.ThanhToanCaNhan();
                    }
                    _thanhToanForm.Show();
                    _thanhToanForm.FormClosed += (s, args) => Application.Exit();
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
                    string role = "NVNL";
                    if (_capChungChiForm == null || _capChungChiForm.IsDisposed)
                    {
                        _capChungChiForm = new Forms.CapChungChi(role);
                    }
                    _capChungChiForm.Show();
                    _capChungChiForm.FormClosed += (s, args) => Application.Exit();
                    this.Hide();
                }
                else if (username == "NVTN" && password == "NVTN")
                {
                    string role = "NVTN";
                    if (_capChungChiForm == null || _capChungChiForm.IsDisposed)
                    {
                        _capChungChiForm = new Forms.CapChungChi(role);
                    }
                    _capChungChiForm.Show();
                    _capChungChiForm.FormClosed += (s, args) => Application.Exit();
                    this.Hide();
                }
            }
        }
    }
}
