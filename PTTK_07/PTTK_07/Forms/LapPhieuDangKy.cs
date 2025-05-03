using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using PTTK_07.Helpers;
using PTTK_07.Services;

namespace PTTK_07.Forms
{
    public partial class LapPhieuDangKy : Form
    {
        public LapPhieuDangKy()
        {
            InitializeComponent();
            this.Load += GV_LapPhieuDangKy_Load;
        }
        private void GV_LapPhieuDangKy_Load(object sender, EventArgs e)
        {
            LoadKhachHangToGrid();
            LoadThiSinhToGrid();
        }
        private void LoadKhachHangToGrid()
        {
            try
            {
                var kh = new DB().Select("SELECT MaKH, TenKH, LoaiKH, SDT, DiaChi, Email FROM KHACH_HANG");

                DataTable dt = new DataTable();
                dt.Load(kh);

                gvKhachHang.DataSource = dt;

                //gvKhachHang.Columns["MaKH"].Width = 100;
                //gvKhachHang.Columns["TenKH"].Width = 100;
                //gvKhachHang.Columns["LoaiKH"].Width = 100;
                //gvKhachHang.Columns["SDT"].Width = 100;
                //gvKhachHang.Columns["DiaChi"].Width = 100;
                //gvKhachHang.Columns["Email"].Width = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadThiSinhToGrid()
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
    }
}
