namespace PTTK_07.Forms
{
    partial class ThanhToanCaNhan
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
            ((System.ComponentModel.ISupportInitialize)(this.gvPhieuDangKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLapHoaDon
            // 
            this.btnLapHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLapHoaDon.Location = new System.Drawing.Point(1265, 333);
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
            this.txtChietKhau.Location = new System.Drawing.Point(1211, 209);
            this.txtChietKhau.Margin = new System.Windows.Forms.Padding(4);
            this.txtChietKhau.Name = "txtChietKhau";
            this.txtChietKhau.Size = new System.Drawing.Size(212, 30);
            this.txtChietKhau.TabIndex = 59;
            // 
            // txtSoTien
            // 
            this.txtSoTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSoTien.Location = new System.Drawing.Point(1211, 138);
            this.txtSoTien.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(212, 30);
            this.txtSoTien.TabIndex = 58;
            // 
            // txtMaPDK
            // 
            this.txtMaPDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtMaPDK.Location = new System.Drawing.Point(1211, 77);
            this.txtMaPDK.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaPDK.Name = "txtMaPDK";
            this.txtMaPDK.Size = new System.Drawing.Size(212, 30);
            this.txtMaPDK.TabIndex = 57;
            // 
            // lbMaLCC
            // 
            this.lbMaLCC.AutoSize = true;
            this.lbMaLCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbMaLCC.Location = new System.Drawing.Point(1009, 209);
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
            this.lbMaLT.Location = new System.Drawing.Point(1009, 138);
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
            this.lbMaTS.Location = new System.Drawing.Point(1009, 77);
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
            this.lbLapPhieuDangKy.Location = new System.Drawing.Point(1204, 22);
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
            this.btnHuyTimMaPDK.Location = new System.Drawing.Point(588, 333);
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
            this.btnTimMaPDK.Location = new System.Drawing.Point(498, 333);
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
            this.txtPDK.Location = new System.Drawing.Point(211, 333);
            this.txtPDK.Margin = new System.Windows.Forms.Padding(4);
            this.txtPDK.Name = "txtPDK";
            this.txtPDK.Size = new System.Drawing.Size(212, 30);
            this.txtPDK.TabIndex = 50;
            // 
            // lbTenKH
            // 
            this.lbTenKH.AutoSize = true;
            this.lbTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbTenKH.Location = new System.Drawing.Point(13, 333);
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
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLogOut.Location = new System.Drawing.Point(1439, 755);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(97, 42);
            this.btnLogOut.TabIndex = 65;
            this.btnLogOut.Text = "Logout";
            this.btnLogOut.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(1009, 281);
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
            this.dtpNewNgayGioTT.Location = new System.Drawing.Point(1211, 281);
            this.dtpNewNgayGioTT.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNewNgayGioTT.Name = "dtpNewNgayGioTT";
            this.dtpNewNgayGioTT.Size = new System.Drawing.Size(212, 30);
            this.dtpNewNgayGioTT.TabIndex = 69;
            // 
            // gvHoaDon
            // 
            this.gvHoaDon.AllowUserToAddRows = false;
            this.gvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvHoaDon.Location = new System.Drawing.Point(995, 396);
            this.gvHoaDon.Margin = new System.Windows.Forms.Padding(4);
            this.gvHoaDon.Name = "gvHoaDon";
            this.gvHoaDon.RowHeadersWidth = 51;
            this.gvHoaDon.Size = new System.Drawing.Size(552, 246);
            this.gvHoaDon.TabIndex = 70;
            // 
            // ThanhToanCaNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1549, 810);
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
            this.Name = "ThanhToanCaNhan";
            this.Text = "Thanh toán Cá nhân";
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
    }
}