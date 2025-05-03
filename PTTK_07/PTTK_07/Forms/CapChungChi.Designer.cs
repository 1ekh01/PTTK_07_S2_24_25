using System.Windows.Forms;

namespace PTTK_07.Forms
{
    partial class CapChungChi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbBaiThi_NVNL = new System.Windows.Forms.Label();
            this.gvKetQuaThi_NVNL = new System.Windows.Forms.DataGridView();
            this.lbLoaiChungChi_NVNL = new System.Windows.Forms.Label();
            this.gvLoaiChungChi_NVNL = new System.Windows.Forms.DataGridView();
            this.lbThiSinh_NVNL = new System.Windows.Forms.Label();
            this.gvThiSinh_NVNL = new System.Windows.Forms.DataGridView();
            this.numDiemSo_NVNL = new System.Windows.Forms.NumericUpDown();
            this.lbDiemSo_NVNL = new System.Windows.Forms.Label();
            this.btnNhapDiemSo_NVNL = new System.Windows.Forms.Button();
            this.lbMaKQT_NVNL = new System.Windows.Forms.Label();
            this.txtMaKQT_NVNL = new System.Windows.Forms.TextBox();
            this.btnTimMaKQT_NVNL = new System.Windows.Forms.Button();
            this.btnHuyTimMaKQT_NVNL = new System.Windows.Forms.Button();
            this.lbKhachHang_NVNL = new System.Windows.Forms.Label();
            this.gvKhachHang_NVNL = new System.Windows.Forms.DataGridView();
            this.lbKhachHang_NVTN = new System.Windows.Forms.Label();
            this.gvKhachHang_NVTN = new System.Windows.Forms.DataGridView();
            this.btnHuyTimMaKH_NVTN = new System.Windows.Forms.Button();
            this.btnTimMaKH_NVTN = new System.Windows.Forms.Button();
            this.txtMaKH_NVTN = new System.Windows.Forms.TextBox();
            this.lbMaKH_NVTN = new System.Windows.Forms.Label();
            this.lbChungChi_ThiSinh_NVTN = new System.Windows.Forms.Label();
            this.gvChungChi_ThiSinh_NVTN = new System.Windows.Forms.DataGridView();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnTraChungChi_NVTN = new System.Windows.Forms.Button();
            this.gbNVNL = new System.Windows.Forms.GroupBox();
            this.gbNVTN = new System.Windows.Forms.GroupBox();
            this.lbTenKH_NVTN = new System.Windows.Forms.Label();
            this.txtTenKH_NVTN = new System.Windows.Forms.TextBox();
            this.btnTimTenKH_NVTN = new System.Windows.Forms.Button();
            this.btnHuyTimTenKH_NVTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvKetQuaThi_NVNL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLoaiChungChi_NVNL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvThiSinh_NVNL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiemSo_NVNL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvKhachHang_NVNL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvKhachHang_NVTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChungChi_ThiSinh_NVTN)).BeginInit();
            this.gbNVNL.SuspendLayout();
            this.gbNVTN.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbBaiThi_NVNL
            // 
            this.lbBaiThi_NVNL.AutoSize = true;
            this.lbBaiThi_NVNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbBaiThi_NVNL.Location = new System.Drawing.Point(16, 30);
            this.lbBaiThi_NVNL.Name = "lbBaiThi_NVNL";
            this.lbBaiThi_NVNL.Size = new System.Drawing.Size(53, 20);
            this.lbBaiThi_NVNL.TabIndex = 6;
            this.lbBaiThi_NVNL.Text = "Bài thi";
            // 
            // gvKetQuaThi_NVNL
            // 
            this.gvKetQuaThi_NVNL.AllowUserToAddRows = false;
            this.gvKetQuaThi_NVNL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvKetQuaThi_NVNL.Location = new System.Drawing.Point(20, 60);
            this.gvKetQuaThi_NVNL.Name = "gvKetQuaThi_NVNL";
            this.gvKetQuaThi_NVNL.Size = new System.Drawing.Size(700, 200);
            this.gvKetQuaThi_NVNL.TabIndex = 5;
            // 
            // lbLoaiChungChi_NVNL
            // 
            this.lbLoaiChungChi_NVNL.AutoSize = true;
            this.lbLoaiChungChi_NVNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbLoaiChungChi_NVNL.Location = new System.Drawing.Point(816, 290);
            this.lbLoaiChungChi_NVNL.Name = "lbLoaiChungChi_NVNL";
            this.lbLoaiChungChi_NVNL.Size = new System.Drawing.Size(111, 20);
            this.lbLoaiChungChi_NVNL.TabIndex = 9;
            this.lbLoaiChungChi_NVNL.Text = "Loại chứng chỉ";
            // 
            // gvLoaiChungChi_NVNL
            // 
            this.gvLoaiChungChi_NVNL.AllowUserToAddRows = false;
            this.gvLoaiChungChi_NVNL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLoaiChungChi_NVNL.Location = new System.Drawing.Point(820, 320);
            this.gvLoaiChungChi_NVNL.Name = "gvLoaiChungChi_NVNL";
            this.gvLoaiChungChi_NVNL.Size = new System.Drawing.Size(700, 70);
            this.gvLoaiChungChi_NVNL.TabIndex = 8;
            // 
            // lbThiSinh_NVNL
            // 
            this.lbThiSinh_NVNL.AutoSize = true;
            this.lbThiSinh_NVNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbThiSinh_NVNL.Location = new System.Drawing.Point(816, 160);
            this.lbThiSinh_NVNL.Name = "lbThiSinh_NVNL";
            this.lbThiSinh_NVNL.Size = new System.Drawing.Size(63, 20);
            this.lbThiSinh_NVNL.TabIndex = 13;
            this.lbThiSinh_NVNL.Text = "Thí sinh";
            // 
            // gvThiSinh_NVNL
            // 
            this.gvThiSinh_NVNL.AllowUserToAddRows = false;
            this.gvThiSinh_NVNL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvThiSinh_NVNL.Location = new System.Drawing.Point(820, 190);
            this.gvThiSinh_NVNL.Name = "gvThiSinh_NVNL";
            this.gvThiSinh_NVNL.Size = new System.Drawing.Size(700, 70);
            this.gvThiSinh_NVNL.TabIndex = 11;
            // 
            // numDiemSo_NVNL
            // 
            this.numDiemSo_NVNL.DecimalPlaces = 1;
            this.numDiemSo_NVNL.Enabled = false;
            this.numDiemSo_NVNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numDiemSo_NVNL.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numDiemSo_NVNL.Location = new System.Drawing.Point(150, 358);
            this.numDiemSo_NVNL.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numDiemSo_NVNL.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numDiemSo_NVNL.Name = "numDiemSo_NVNL";
            this.numDiemSo_NVNL.Size = new System.Drawing.Size(162, 26);
            this.numDiemSo_NVNL.TabIndex = 14;
            // 
            // lbDiemSo_NVNL
            // 
            this.lbDiemSo_NVNL.AutoSize = true;
            this.lbDiemSo_NVNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbDiemSo_NVNL.Location = new System.Drawing.Point(16, 360);
            this.lbDiemSo_NVNL.Name = "lbDiemSo_NVNL";
            this.lbDiemSo_NVNL.Size = new System.Drawing.Size(106, 20);
            this.lbDiemSo_NVNL.TabIndex = 15;
            this.lbDiemSo_NVNL.Text = "Nhập điểm số";
            // 
            // btnNhapDiemSo_NVNL
            // 
            this.btnNhapDiemSo_NVNL.Enabled = false;
            this.btnNhapDiemSo_NVNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnNhapDiemSo_NVNL.Location = new System.Drawing.Point(345, 353);
            this.btnNhapDiemSo_NVNL.Name = "btnNhapDiemSo_NVNL";
            this.btnNhapDiemSo_NVNL.Size = new System.Drawing.Size(136, 34);
            this.btnNhapDiemSo_NVNL.TabIndex = 18;
            this.btnNhapDiemSo_NVNL.Text = "Nhập điểm số";
            this.btnNhapDiemSo_NVNL.UseVisualStyleBackColor = true;
            this.btnNhapDiemSo_NVNL.Click += new System.EventHandler(this.btnNhapDiemSo_NVNL_Click);
            // 
            // lbMaKQT_NVNL
            // 
            this.lbMaKQT_NVNL.AutoSize = true;
            this.lbMaKQT_NVNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbMaKQT_NVNL.Location = new System.Drawing.Point(16, 290);
            this.lbMaKQT_NVNL.Name = "lbMaKQT_NVNL";
            this.lbMaKQT_NVNL.Size = new System.Drawing.Size(109, 20);
            this.lbMaKQT_NVNL.TabIndex = 19;
            this.lbMaKQT_NVNL.Text = "Mã kết quả thi";
            // 
            // txtMaKQT_NVNL
            // 
            this.txtMaKQT_NVNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtMaKQT_NVNL.Location = new System.Drawing.Point(150, 284);
            this.txtMaKQT_NVNL.Name = "txtMaKQT_NVNL";
            this.txtMaKQT_NVNL.Size = new System.Drawing.Size(160, 26);
            this.txtMaKQT_NVNL.TabIndex = 20;
            // 
            // btnTimMaKQT_NVNL
            // 
            this.btnTimMaKQT_NVNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnTimMaKQT_NVNL.Location = new System.Drawing.Point(345, 283);
            this.btnTimMaKQT_NVNL.Name = "btnTimMaKQT_NVNL";
            this.btnTimMaKQT_NVNL.Size = new System.Drawing.Size(136, 34);
            this.btnTimMaKQT_NVNL.TabIndex = 21;
            this.btnTimMaKQT_NVNL.Text = "Tìm theo mã";
            this.btnTimMaKQT_NVNL.UseVisualStyleBackColor = true;
            this.btnTimMaKQT_NVNL.Click += new System.EventHandler(this.btnTimMaKQT_NVNL_Click);
            // 
            // btnHuyTimMaKQT_NVNL
            // 
            this.btnHuyTimMaKQT_NVNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnHuyTimMaKQT_NVNL.Location = new System.Drawing.Point(545, 283);
            this.btnHuyTimMaKQT_NVNL.Name = "btnHuyTimMaKQT_NVNL";
            this.btnHuyTimMaKQT_NVNL.Size = new System.Drawing.Size(73, 34);
            this.btnHuyTimMaKQT_NVNL.TabIndex = 22;
            this.btnHuyTimMaKQT_NVNL.Text = "Hủy tìm";
            this.btnHuyTimMaKQT_NVNL.UseVisualStyleBackColor = true;
            this.btnHuyTimMaKQT_NVNL.Click += new System.EventHandler(this.btnHuyTimMaKQT_NVNL_Click);
            // 
            // lbKhachHang_NVNL
            // 
            this.lbKhachHang_NVNL.AutoSize = true;
            this.lbKhachHang_NVNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbKhachHang_NVNL.Location = new System.Drawing.Point(816, 30);
            this.lbKhachHang_NVNL.Name = "lbKhachHang_NVNL";
            this.lbKhachHang_NVNL.Size = new System.Drawing.Size(94, 20);
            this.lbKhachHang_NVNL.TabIndex = 24;
            this.lbKhachHang_NVNL.Text = "Khách hàng";
            // 
            // gvKhachHang_NVNL
            // 
            this.gvKhachHang_NVNL.AllowUserToAddRows = false;
            this.gvKhachHang_NVNL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvKhachHang_NVNL.Location = new System.Drawing.Point(820, 60);
            this.gvKhachHang_NVNL.Name = "gvKhachHang_NVNL";
            this.gvKhachHang_NVNL.Size = new System.Drawing.Size(700, 70);
            this.gvKhachHang_NVNL.TabIndex = 23;
            // 
            // lbKhachHang_NVTN
            // 
            this.lbKhachHang_NVTN.AutoSize = true;
            this.lbKhachHang_NVTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbKhachHang_NVTN.Location = new System.Drawing.Point(16, 30);
            this.lbKhachHang_NVTN.Name = "lbKhachHang_NVTN";
            this.lbKhachHang_NVTN.Size = new System.Drawing.Size(94, 20);
            this.lbKhachHang_NVTN.TabIndex = 26;
            this.lbKhachHang_NVTN.Text = "Khách hàng";
            // 
            // gvKhachHang_NVTN
            // 
            this.gvKhachHang_NVTN.AllowUserToAddRows = false;
            this.gvKhachHang_NVTN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvKhachHang_NVTN.Location = new System.Drawing.Point(20, 60);
            this.gvKhachHang_NVTN.Name = "gvKhachHang_NVTN";
            this.gvKhachHang_NVTN.Size = new System.Drawing.Size(700, 200);
            this.gvKhachHang_NVTN.TabIndex = 25;
            // 
            // btnHuyTimMaKH_NVTN
            // 
            this.btnHuyTimMaKH_NVTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnHuyTimMaKH_NVTN.Location = new System.Drawing.Point(545, 283);
            this.btnHuyTimMaKH_NVTN.Name = "btnHuyTimMaKH_NVTN";
            this.btnHuyTimMaKH_NVTN.Size = new System.Drawing.Size(73, 34);
            this.btnHuyTimMaKH_NVTN.TabIndex = 30;
            this.btnHuyTimMaKH_NVTN.Text = "Hủy tìm";
            this.btnHuyTimMaKH_NVTN.UseVisualStyleBackColor = true;
            this.btnHuyTimMaKH_NVTN.Click += new System.EventHandler(this.btnHuyTimMaKH_ChungChi_Click);
            // 
            // btnTimMaKH_NVTN
            // 
            this.btnTimMaKH_NVTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnTimMaKH_NVTN.Location = new System.Drawing.Point(345, 283);
            this.btnTimMaKH_NVTN.Name = "btnTimMaKH_NVTN";
            this.btnTimMaKH_NVTN.Size = new System.Drawing.Size(136, 34);
            this.btnTimMaKH_NVTN.TabIndex = 29;
            this.btnTimMaKH_NVTN.Text = "Tìm theo mã";
            this.btnTimMaKH_NVTN.UseVisualStyleBackColor = true;
            this.btnTimMaKH_NVTN.Click += new System.EventHandler(this.btnTimMaKH_ChungChi_Click);
            // 
            // txtMaKH_NVTN
            // 
            this.txtMaKH_NVTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtMaKH_NVTN.Location = new System.Drawing.Point(152, 287);
            this.txtMaKH_NVTN.Name = "txtMaKH_NVTN";
            this.txtMaKH_NVTN.Size = new System.Drawing.Size(160, 26);
            this.txtMaKH_NVTN.TabIndex = 28;
            // 
            // lbMaKH_NVTN
            // 
            this.lbMaKH_NVTN.AutoSize = true;
            this.lbMaKH_NVTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbMaKH_NVTN.Location = new System.Drawing.Point(16, 293);
            this.lbMaKH_NVTN.Name = "lbMaKH_NVTN";
            this.lbMaKH_NVTN.Size = new System.Drawing.Size(118, 20);
            this.lbMaKH_NVTN.TabIndex = 27;
            this.lbMaKH_NVTN.Text = "Mã khách hàng";
            // 
            // lbChungChi_ThiSinh_NVTN
            // 
            this.lbChungChi_ThiSinh_NVTN.AutoSize = true;
            this.lbChungChi_ThiSinh_NVTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbChungChi_ThiSinh_NVTN.Location = new System.Drawing.Point(816, 30);
            this.lbChungChi_ThiSinh_NVTN.Name = "lbChungChi_ThiSinh_NVTN";
            this.lbChungChi_ThiSinh_NVTN.Size = new System.Drawing.Size(295, 20);
            this.lbChungChi_ThiSinh_NVTN.TabIndex = 32;
            this.lbChungChi_ThiSinh_NVTN.Text = "Chứng chỉ của thí sinh thuộc khách hàng";
            // 
            // gvChungChi_ThiSinh_NVTN
            // 
            this.gvChungChi_ThiSinh_NVTN.AllowUserToAddRows = false;
            this.gvChungChi_ThiSinh_NVTN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvChungChi_ThiSinh_NVTN.Location = new System.Drawing.Point(820, 60);
            this.gvChungChi_ThiSinh_NVTN.Name = "gvChungChi_ThiSinh_NVTN";
            this.gvChungChi_ThiSinh_NVTN.Size = new System.Drawing.Size(700, 200);
            this.gvChungChi_ThiSinh_NVTN.TabIndex = 31;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.Salmon;
            this.btnDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDangXuat.Location = new System.Drawing.Point(1450, 809);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(100, 40);
            this.btnDangXuat.TabIndex = 90;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnTraChungChi_NVTN
            // 
            this.btnTraChungChi_NVTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnTraChungChi_NVTN.Location = new System.Drawing.Point(1383, 283);
            this.btnTraChungChi_NVTN.Name = "btnTraChungChi_NVTN";
            this.btnTraChungChi_NVTN.Size = new System.Drawing.Size(137, 34);
            this.btnTraChungChi_NVTN.TabIndex = 91;
            this.btnTraChungChi_NVTN.Text = "Trả chứng chỉ";
            this.btnTraChungChi_NVTN.UseVisualStyleBackColor = true;
            this.btnTraChungChi_NVTN.Click += new System.EventHandler(this.btnTraChungChi_NVTN_Click);
            // 
            // gbNVNL
            // 
            this.gbNVNL.Controls.Add(this.lbBaiThi_NVNL);
            this.gbNVNL.Controls.Add(this.gvKetQuaThi_NVNL);
            this.gbNVNL.Controls.Add(this.gvKhachHang_NVNL);
            this.gbNVNL.Controls.Add(this.lbKhachHang_NVNL);
            this.gbNVNL.Controls.Add(this.lbThiSinh_NVNL);
            this.gbNVNL.Controls.Add(this.gvThiSinh_NVNL);
            this.gbNVNL.Controls.Add(this.gvLoaiChungChi_NVNL);
            this.gbNVNL.Controls.Add(this.lbLoaiChungChi_NVNL);
            this.gbNVNL.Controls.Add(this.btnHuyTimMaKQT_NVNL);
            this.gbNVNL.Controls.Add(this.btnNhapDiemSo_NVNL);
            this.gbNVNL.Controls.Add(this.btnTimMaKQT_NVNL);
            this.gbNVNL.Controls.Add(this.lbDiemSo_NVNL);
            this.gbNVNL.Controls.Add(this.lbMaKQT_NVNL);
            this.gbNVNL.Controls.Add(this.txtMaKQT_NVNL);
            this.gbNVNL.Controls.Add(this.numDiemSo_NVNL);
            this.gbNVNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.gbNVNL.Location = new System.Drawing.Point(30, 20);
            this.gbNVNL.Name = "gbNVNL";
            this.gbNVNL.Size = new System.Drawing.Size(1540, 420);
            this.gbNVNL.TabIndex = 92;
            this.gbNVNL.TabStop = false;
            this.gbNVNL.Text = "Nhân viên nhập liệu";
            // 
            // gbNVTN
            // 
            this.gbNVTN.Controls.Add(this.lbTenKH_NVTN);
            this.gbNVTN.Controls.Add(this.txtTenKH_NVTN);
            this.gbNVTN.Controls.Add(this.btnTimTenKH_NVTN);
            this.gbNVTN.Controls.Add(this.btnHuyTimTenKH_NVTN);
            this.gbNVTN.Controls.Add(this.btnTraChungChi_NVTN);
            this.gbNVTN.Controls.Add(this.gvKhachHang_NVTN);
            this.gbNVTN.Controls.Add(this.gvChungChi_ThiSinh_NVTN);
            this.gbNVTN.Controls.Add(this.lbMaKH_NVTN);
            this.gbNVTN.Controls.Add(this.txtMaKH_NVTN);
            this.gbNVTN.Controls.Add(this.btnTimMaKH_NVTN);
            this.gbNVTN.Controls.Add(this.btnHuyTimMaKH_NVTN);
            this.gbNVTN.Controls.Add(this.lbChungChi_ThiSinh_NVTN);
            this.gbNVTN.Controls.Add(this.lbKhachHang_NVTN);
            this.gbNVTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.gbNVTN.Location = new System.Drawing.Point(30, 460);
            this.gbNVTN.Name = "gbNVTN";
            this.gbNVTN.Size = new System.Drawing.Size(1540, 340);
            this.gbNVTN.TabIndex = 93;
            this.gbNVTN.TabStop = false;
            this.gbNVTN.Text = "Nhân viên tiếp nhận";
            // 
            // lbTenKH_NVTN
            // 
            this.lbTenKH_NVTN.AutoSize = true;
            this.lbTenKH_NVTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbTenKH_NVTN.Location = new System.Drawing.Point(16, 333);
            this.lbTenKH_NVTN.Name = "lbTenKH_NVTN";
            this.lbTenKH_NVTN.Size = new System.Drawing.Size(123, 20);
            this.lbTenKH_NVTN.TabIndex = 92;
            this.lbTenKH_NVTN.Text = "Tên khách hàng";
            this.lbTenKH_NVTN.Visible = false;
            // 
            // txtTenKH_NVTN
            // 
            this.txtTenKH_NVTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTenKH_NVTN.Location = new System.Drawing.Point(152, 327);
            this.txtTenKH_NVTN.Name = "txtTenKH_NVTN";
            this.txtTenKH_NVTN.Size = new System.Drawing.Size(160, 26);
            this.txtTenKH_NVTN.TabIndex = 93;
            this.txtTenKH_NVTN.Visible = false;
            // 
            // btnTimTenKH_NVTN
            // 
            this.btnTimTenKH_NVTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnTimTenKH_NVTN.Location = new System.Drawing.Point(345, 323);
            this.btnTimTenKH_NVTN.Name = "btnTimTenKH_NVTN";
            this.btnTimTenKH_NVTN.Size = new System.Drawing.Size(136, 34);
            this.btnTimTenKH_NVTN.TabIndex = 94;
            this.btnTimTenKH_NVTN.Text = "Tìm theo tên";
            this.btnTimTenKH_NVTN.UseVisualStyleBackColor = true;
            this.btnTimTenKH_NVTN.Visible = false;
            this.btnTimTenKH_NVTN.Click += new System.EventHandler(this.btnTimTenKH_NVTN_Click);
            // 
            // btnHuyTimTenKH_NVTN
            // 
            this.btnHuyTimTenKH_NVTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnHuyTimTenKH_NVTN.Location = new System.Drawing.Point(545, 323);
            this.btnHuyTimTenKH_NVTN.Name = "btnHuyTimTenKH_NVTN";
            this.btnHuyTimTenKH_NVTN.Size = new System.Drawing.Size(73, 34);
            this.btnHuyTimTenKH_NVTN.TabIndex = 95;
            this.btnHuyTimTenKH_NVTN.Text = "Hủy tìm";
            this.btnHuyTimTenKH_NVTN.UseVisualStyleBackColor = true;
            this.btnHuyTimTenKH_NVTN.Visible = false;
            this.btnHuyTimTenKH_NVTN.Click += new System.EventHandler(this.btnHuyTimTenKH_NVTN_Click);
            // 
            // CapChungChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1594, 861);
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.gbNVNL);
            this.Controls.Add(this.gbNVTN);
            this.Name = "CapChungChi";
            this.Text = "Cấp chứng chỉ";
            ((System.ComponentModel.ISupportInitialize)(this.gvKetQuaThi_NVNL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLoaiChungChi_NVNL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvThiSinh_NVNL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiemSo_NVNL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvKhachHang_NVNL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvKhachHang_NVTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChungChi_ThiSinh_NVTN)).EndInit();
            this.gbNVNL.ResumeLayout(false);
            this.gbNVNL.PerformLayout();
            this.gbNVTN.ResumeLayout(false);
            this.gbNVTN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbBaiThi_NVNL;
        private System.Windows.Forms.DataGridView gvKetQuaThi_NVNL;
        private System.Windows.Forms.Label lbLoaiChungChi_NVNL;
        private System.Windows.Forms.DataGridView gvLoaiChungChi_NVNL;
        private System.Windows.Forms.Label lbThiSinh_NVNL;
        private System.Windows.Forms.DataGridView gvThiSinh_NVNL;
        private System.Windows.Forms.NumericUpDown numDiemSo_NVNL;
        private System.Windows.Forms.Label lbDiemSo_NVNL;
        private System.Windows.Forms.Button btnNhapDiemSo_NVNL;
        private System.Windows.Forms.Label lbMaKQT_NVNL;
        private System.Windows.Forms.TextBox txtMaKQT_NVNL;
        private System.Windows.Forms.Button btnTimMaKQT_NVNL;
        private System.Windows.Forms.Button btnHuyTimMaKQT_NVNL;
        private System.Windows.Forms.Label lbKhachHang_NVNL;
        private System.Windows.Forms.DataGridView gvKhachHang_NVNL;
        private System.Windows.Forms.Label lbKhachHang_NVTN;
        private System.Windows.Forms.DataGridView gvKhachHang_NVTN;
        private System.Windows.Forms.Button btnHuyTimMaKH_NVTN;
        private System.Windows.Forms.Button btnTimMaKH_NVTN;
        private System.Windows.Forms.TextBox txtMaKH_NVTN;
        private System.Windows.Forms.Label lbMaKH_NVTN;
        private System.Windows.Forms.Label lbChungChi_ThiSinh_NVTN;
        private System.Windows.Forms.DataGridView gvChungChi_ThiSinh_NVTN;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnTraChungChi_NVTN;
        private System.Windows.Forms.GroupBox gbNVNL;
        private GroupBox gbNVTN;
        private Label lbTenKH_NVTN;
        private TextBox txtTenKH_NVTN;
        private Button btnTimTenKH_NVTN;
        private Button btnHuyTimTenKH_NVTN;
    }
}