namespace PTTK_07.Forms
{
    partial class ThanhToan
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
            this.btnLapHoaDon = new System.Windows.Forms.Button();
            this.txtChietKhau = new System.Windows.Forms.TextBox();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.txtMaPDK = new System.Windows.Forms.TextBox();
            this.lbMaLCC = new System.Windows.Forms.Label();
            this.lbMaLT = new System.Windows.Forms.Label();
            this.lbMaTS = new System.Windows.Forms.Label();
            this.lbLapPhieuDangKy = new System.Windows.Forms.Label();
            this.btnHuyTimMaPDK = new System.Windows.Forms.Button();
            this.btnTimMaPDK = new System.Windows.Forms.Button();
            this.txtPDK = new System.Windows.Forms.TextBox();
            this.lbTenKH = new System.Windows.Forms.Label();
            this.gvPhieuDangKy = new System.Windows.Forms.DataGridView();
            this.lbKhachHang = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpNewNgayGioTT = new System.Windows.Forms.DateTimePicker();
            this.gvHoaDon = new System.Windows.Forms.DataGridView();
            this.cbbHinhThucTT = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHuyTimMaHoaDon = new System.Windows.Forms.Button();
            this.btnTimMaHoaDon = new System.Windows.Forms.Button();
            this.txtHoaDon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvPhieuDangKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLapHoaDon
            // 
            this.btnLapHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLapHoaDon.Location = new System.Drawing.Point(1183, 391);
            this.btnLapHoaDon.Margin = new System.Windows.Forms.Padding(4);
            this.btnLapHoaDon.Name = "btnLapHoaDon";
            this.btnLapHoaDon.Size = new System.Drawing.Size(97, 42);
            this.btnLapHoaDon.TabIndex = 60;
            this.btnLapHoaDon.Text = "Lập";
            this.btnLapHoaDon.UseVisualStyleBackColor = true;
            this.btnLapHoaDon.Click += new System.EventHandler(this.btnLapHoaDon_Click);
            // 
            // txtChietKhau
            // 
            this.txtChietKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtChietKhau.Location = new System.Drawing.Point(1119, 204);
            this.txtChietKhau.Margin = new System.Windows.Forms.Padding(4);
            this.txtChietKhau.Name = "txtChietKhau";
            this.txtChietKhau.Size = new System.Drawing.Size(212, 30);
            this.txtChietKhau.TabIndex = 59;
            // 
            // txtSoTien
            // 
            this.txtSoTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSoTien.Location = new System.Drawing.Point(1119, 138);
            this.txtSoTien.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(212, 30);
            this.txtSoTien.TabIndex = 58;
            // 
            // txtMaPDK
            // 
            this.txtMaPDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtMaPDK.Location = new System.Drawing.Point(1119, 77);
            this.txtMaPDK.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaPDK.Name = "txtMaPDK";
            this.txtMaPDK.Size = new System.Drawing.Size(212, 30);
            this.txtMaPDK.TabIndex = 57;
            // 
            // lbMaLCC
            // 
            this.lbMaLCC.AutoSize = true;
            this.lbMaLCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbMaLCC.Location = new System.Drawing.Point(854, 209);
            this.lbMaLCC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMaLCC.Name = "lbMaLCC";
            this.lbMaLCC.Size = new System.Drawing.Size(106, 25);
            this.lbMaLCC.TabIndex = 56;
            this.lbMaLCC.Text = "Chiết khấu";
            // 
            // lbMaLT
            // 
            this.lbMaLT.AutoSize = true;
            this.lbMaLT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbMaLT.Location = new System.Drawing.Point(854, 143);
            this.lbMaLT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMaLT.Name = "lbMaLT";
            this.lbMaLT.Size = new System.Drawing.Size(73, 25);
            this.lbMaLT.TabIndex = 55;
            this.lbMaLT.Text = "Số tiền";
            // 
            // lbMaTS
            // 
            this.lbMaTS.AutoSize = true;
            this.lbMaTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbMaTS.Location = new System.Drawing.Point(854, 82);
            this.lbMaTS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMaTS.Name = "lbMaTS";
            this.lbMaTS.Size = new System.Drawing.Size(167, 25);
            this.lbMaTS.TabIndex = 54;
            this.lbMaTS.Text = "Mã phiếu đăng ký";
            // 
            // lbLapPhieuDangKy
            // 
            this.lbLapPhieuDangKy.AutoSize = true;
            this.lbLapPhieuDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lbLapPhieuDangKy.Location = new System.Drawing.Point(1125, 11);
            this.lbLapPhieuDangKy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLapPhieuDangKy.Name = "lbLapPhieuDangKy";
            this.lbLapPhieuDangKy.Size = new System.Drawing.Size(206, 39);
            this.lbLapPhieuDangKy.TabIndex = 53;
            this.lbLapPhieuDangKy.Text = "Lập hóa đơn";
            this.lbLapPhieuDangKy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHuyTimMaPDK
            // 
            this.btnHuyTimMaPDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnHuyTimMaPDK.Location = new System.Drawing.Point(588, 330);
            this.btnHuyTimMaPDK.Margin = new System.Windows.Forms.Padding(4);
            this.btnHuyTimMaPDK.Name = "btnHuyTimMaPDK";
            this.btnHuyTimMaPDK.Size = new System.Drawing.Size(97, 37);
            this.btnHuyTimMaPDK.TabIndex = 52;
            this.btnHuyTimMaPDK.Text = "Hủy tìm";
            this.btnHuyTimMaPDK.Click += new System.EventHandler(this.btnHuyTimMaPDK_Click);
            // 
            // btnTimMaPDK
            // 
            this.btnTimMaPDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnTimMaPDK.Location = new System.Drawing.Point(505, 330);
            this.btnTimMaPDK.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimMaPDK.Name = "btnTimMaPDK";
            this.btnTimMaPDK.Size = new System.Drawing.Size(75, 36);
            this.btnTimMaPDK.TabIndex = 51;
            this.btnTimMaPDK.Text = "Tìm";
            this.btnTimMaPDK.UseVisualStyleBackColor = true;
            this.btnTimMaPDK.Click += new System.EventHandler(this.btnTimMaPDK_Click_1);
            // 
            // txtPDK
            // 
            this.txtPDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPDK.Location = new System.Drawing.Point(266, 334);
            this.txtPDK.Margin = new System.Windows.Forms.Padding(4);
            this.txtPDK.Name = "txtPDK";
            this.txtPDK.Size = new System.Drawing.Size(212, 30);
            this.txtPDK.TabIndex = 50;
            // 
            // lbTenKH
            // 
            this.lbTenKH.AutoSize = true;
            this.lbTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbTenKH.Location = new System.Drawing.Point(59, 339);
            this.lbTenKH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTenKH.Name = "lbTenKH";
            this.lbTenKH.Size = new System.Drawing.Size(167, 25);
            this.lbTenKH.TabIndex = 49;
            this.lbTenKH.Text = "Mã phiếu đăng ký";
            // 
            // gvPhieuDangKy
            // 
            this.gvPhieuDangKy.AllowUserToAddRows = false;
            this.gvPhieuDangKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPhieuDangKy.Location = new System.Drawing.Point(18, 60);
            this.gvPhieuDangKy.Margin = new System.Windows.Forms.Padding(4);
            this.gvPhieuDangKy.Name = "gvPhieuDangKy";
            this.gvPhieuDangKy.RowHeadersWidth = 51;
            this.gvPhieuDangKy.Size = new System.Drawing.Size(667, 246);
            this.gvPhieuDangKy.TabIndex = 48;
            // 
            // lbKhachHang
            // 
            this.lbKhachHang.AutoSize = true;
            this.lbKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbKhachHang.Location = new System.Drawing.Point(24, 22);
            this.lbKhachHang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbKhachHang.Name = "lbKhachHang";
            this.lbKhachHang.Size = new System.Drawing.Size(136, 25);
            this.lbKhachHang.TabIndex = 47;
            this.lbKhachHang.Text = "Phiếu đăng ký";
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.Salmon;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLogOut.Location = new System.Drawing.Point(1393, 755);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(143, 42);
            this.btnLogOut.TabIndex = 65;
            this.btnLogOut.Text = "Đăng xuất";
            this.btnLogOut.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(854, 338);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 25);
            this.label1.TabIndex = 67;
            this.label1.Text = "Ngày giờ thanh toán";
            // 
            // dtpNewNgayGioTT
            // 
            this.dtpNewNgayGioTT.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dtpNewNgayGioTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpNewNgayGioTT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNewNgayGioTT.Location = new System.Drawing.Point(1119, 339);
            this.dtpNewNgayGioTT.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNewNgayGioTT.Name = "dtpNewNgayGioTT";
            this.dtpNewNgayGioTT.Size = new System.Drawing.Size(212, 30);
            this.dtpNewNgayGioTT.TabIndex = 69;
            // 
            // gvHoaDon
            // 
            this.gvHoaDon.AllowUserToAddRows = false;
            this.gvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvHoaDon.Location = new System.Drawing.Point(859, 441);
            this.gvHoaDon.Margin = new System.Windows.Forms.Padding(4);
            this.gvHoaDon.Name = "gvHoaDon";
            this.gvHoaDon.RowHeadersWidth = 51;
            this.gvHoaDon.Size = new System.Drawing.Size(677, 246);
            this.gvHoaDon.TabIndex = 70;
            // 
            // cbbHinhThucTT
            // 
            this.cbbHinhThucTT.FormattingEnabled = true;
            this.cbbHinhThucTT.Items.AddRange(new object[] {
            "Chuyển khoản",
            "Tiền mặt"});
            this.cbbHinhThucTT.Location = new System.Drawing.Point(1119, 279);
            this.cbbHinhThucTT.Name = "cbbHinhThucTT";
            this.cbbHinhThucTT.Size = new System.Drawing.Size(212, 24);
            this.cbbHinhThucTT.TabIndex = 87;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(854, 278);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 25);
            this.label2.TabIndex = 88;
            this.label2.Text = "Hình thức thanh toán";
            // 
            // btnHuyTimMaHoaDon
            // 
            this.btnHuyTimMaHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnHuyTimMaHoaDon.Location = new System.Drawing.Point(1439, 708);
            this.btnHuyTimMaHoaDon.Margin = new System.Windows.Forms.Padding(4);
            this.btnHuyTimMaHoaDon.Name = "btnHuyTimMaHoaDon";
            this.btnHuyTimMaHoaDon.Size = new System.Drawing.Size(97, 37);
            this.btnHuyTimMaHoaDon.TabIndex = 92;
            this.btnHuyTimMaHoaDon.Text = "Hủy tìm";
            this.btnHuyTimMaHoaDon.Click += new System.EventHandler(this.btnHuyTimMaHoaDon_Click);
            // 
            // btnTimMaHoaDon
            // 
            this.btnTimMaHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnTimMaHoaDon.Location = new System.Drawing.Point(1356, 708);
            this.btnTimMaHoaDon.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimMaHoaDon.Name = "btnTimMaHoaDon";
            this.btnTimMaHoaDon.Size = new System.Drawing.Size(75, 36);
            this.btnTimMaHoaDon.TabIndex = 91;
            this.btnTimMaHoaDon.Text = "Tìm";
            this.btnTimMaHoaDon.UseVisualStyleBackColor = true;
            this.btnTimMaHoaDon.Click += new System.EventHandler(this.btnTimMaHoaDon_Click);
            // 
            // txtHoaDon
            // 
            this.txtHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtHoaDon.Location = new System.Drawing.Point(1121, 711);
            this.txtHoaDon.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoaDon.Name = "txtHoaDon";
            this.txtHoaDon.Size = new System.Drawing.Size(212, 30);
            this.txtHoaDon.TabIndex = 90;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(905, 716);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 25);
            this.label3.TabIndex = 89;
            this.label3.Text = "Mã hóa đơn";
            // 
            // ThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1549, 810);
            this.Controls.Add(this.btnHuyTimMaHoaDon);
            this.Controls.Add(this.btnTimMaHoaDon);
            this.Controls.Add(this.txtHoaDon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbHinhThucTT);
            this.Controls.Add(this.gvHoaDon);
            this.Controls.Add(this.dtpNewNgayGioTT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnLapHoaDon);
            this.Controls.Add(this.txtChietKhau);
            this.Controls.Add(this.txtSoTien);
            this.Controls.Add(this.txtMaPDK);
            this.Controls.Add(this.lbMaLCC);
            this.Controls.Add(this.lbMaLT);
            this.Controls.Add(this.lbMaTS);
            this.Controls.Add(this.lbLapPhieuDangKy);
            this.Controls.Add(this.btnHuyTimMaPDK);
            this.Controls.Add(this.btnTimMaPDK);
            this.Controls.Add(this.txtPDK);
            this.Controls.Add(this.lbTenKH);
            this.Controls.Add(this.gvPhieuDangKy);
            this.Controls.Add(this.lbKhachHang);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ThanhToan";
            ((System.ComponentModel.ISupportInitialize)(this.gvPhieuDangKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLapHoaDon;
        private System.Windows.Forms.TextBox txtChietKhau;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.TextBox txtMaPDK;
        private System.Windows.Forms.Label lbMaLCC;
        private System.Windows.Forms.Label lbMaLT;
        private System.Windows.Forms.Label lbMaTS;
        private System.Windows.Forms.Label lbLapPhieuDangKy;
        private System.Windows.Forms.Button btnHuyTimMaPDK;
        private System.Windows.Forms.Button btnTimMaPDK;
        private System.Windows.Forms.TextBox txtPDK;
        private System.Windows.Forms.Label lbTenKH;
        private System.Windows.Forms.DataGridView gvPhieuDangKy;
        private System.Windows.Forms.Label lbKhachHang;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNewNgayGioTT;
        private System.Windows.Forms.DataGridView gvHoaDon;
        private System.Windows.Forms.ComboBox cbbHinhThucTT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnHuyTimMaHoaDon;
        private System.Windows.Forms.Button btnTimMaHoaDon;
        private System.Windows.Forms.TextBox txtHoaDon;
        private System.Windows.Forms.Label label3;
    }
}