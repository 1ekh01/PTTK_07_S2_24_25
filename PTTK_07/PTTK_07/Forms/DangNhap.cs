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
        private Forms.DangKyThi _dangKyThiForm;
        private Forms.LapPhieuDangKy _lapPhieuForm;
        private Forms.ThanhToan _thanhToanForm;
        private Forms.GiaHanDacBiet _giaHanDacBietForm;
        private Forms.CapChungChi _capChungChiForm;
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenTaiKhoan.Text.Trim();
            string password = txtMatKhau.Text.Trim();
            string usecase  = cbUseCase.Text.Trim();

            if (usecase == "Đăng ký thi")
            {
                if (username == "NVTN" && password == "NVTN")
                {
                    if (_dangKyThiForm == null || _dangKyThiForm.IsDisposed)
                    {
                        _dangKyThiForm = new Forms.DangKyThi();
                    }
                    _dangKyThiForm.Show();
                    _dangKyThiForm.FormClosed += (s, args) => Application.Exit();
                    this.Hide();
                }
            }
            else if (usecase == "Thanh toán")
            {
                if (username == "NVKT" && password == "NVKT")
                {
                    if (_thanhToanForm == null || _thanhToanForm.IsDisposed)
                    {
                        _thanhToanForm = new Forms.ThanhToan();
                    }
                    _thanhToanForm.Show();
                    _thanhToanForm.FormClosed += (s, args) => Application.Exit();
                    this.Hide();
                }
            }
            else if (usecase == "Gia hạn lịch thi")
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
