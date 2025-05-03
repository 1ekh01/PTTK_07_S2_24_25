namespace PTTK_07.Forms
{
    partial class GiaHanDacBiet
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMaPDT = new System.Windows.Forms.Label();
            this.txtMaPDT = new System.Windows.Forms.TextBox();
            this.lblMaTS = new System.Windows.Forms.Label();
            this.txtMaTS = new System.Windows.Forms.TextBox();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.lblPhiGiaHan = new System.Windows.Forms.Label();
            this.txtPhiGiaHan = new System.Windows.Forms.TextBox();
            this.lblNgayThi = new System.Windows.Forms.Label();
            this.lstNgayThi = new System.Windows.Forms.ListBox();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.btnGiaHan = new System.Windows.Forms.Button();
            this.lblKiemTraHoaDon = new System.Windows.Forms.Label();
            this.txtKiemTraHoaDon = new System.Windows.Forms.TextBox();
            this.btnTimKiemHoaDon = new System.Windows.Forms.Button();
            this.gridViewHoaDon = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaPDT
            // 
            this.lblMaPDT.AutoSize = true;
            this.lblMaPDT.Location = new System.Drawing.Point(30, 30);
            this.lblMaPDT.Name = "lblMaPDT";
            this.lblMaPDT.Size = new System.Drawing.Size(50, 13);
            this.lblMaPDT.TabIndex = 17;
            this.lblMaPDT.Text = "Mã PDT:";
            // 
            // txtMaPDT
            // 
            this.txtMaPDT.Location = new System.Drawing.Point(120, 27);
            this.txtMaPDT.Name = "txtMaPDT";
            this.txtMaPDT.Size = new System.Drawing.Size(200, 20);
            this.txtMaPDT.TabIndex = 0;
            // 
            // lblMaTS
            // 
            this.lblMaTS.AutoSize = true;
            this.lblMaTS.Location = new System.Drawing.Point(30, 60);
            this.lblMaTS.Name = "lblMaTS";
            this.lblMaTS.Size = new System.Drawing.Size(42, 13);
            this.lblMaTS.TabIndex = 16;
            this.lblMaTS.Text = "Mã TS:";
            // 
            // txtMaTS
            // 
            this.txtMaTS.Location = new System.Drawing.Point(120, 57);
            this.txtMaTS.Name = "txtMaTS";
            this.txtMaTS.Size = new System.Drawing.Size(200, 20);
            this.txtMaTS.TabIndex = 1;
            // 
            // lblLyDo
            // 
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Location = new System.Drawing.Point(30, 92);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(38, 13);
            this.lblLyDo.TabIndex = 14;
            this.lblLyDo.Text = "Lý Do:";
            // 
            // txtLyDo
            // 
            this.txtLyDo.Location = new System.Drawing.Point(120, 89);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(200, 20);
            this.txtLyDo.TabIndex = 3;
            // 
            // lblPhiGiaHan
            // 
            this.lblPhiGiaHan.AutoSize = true;
            this.lblPhiGiaHan.Location = new System.Drawing.Point(30, 122);
            this.lblPhiGiaHan.Name = "lblPhiGiaHan";
            this.lblPhiGiaHan.Size = new System.Drawing.Size(69, 13);
            this.lblPhiGiaHan.TabIndex = 13;
            this.lblPhiGiaHan.Text = "Phí Gia Hạn:";
            // 
            // txtPhiGiaHan
            // 
            this.txtPhiGiaHan.Location = new System.Drawing.Point(120, 119);
            this.txtPhiGiaHan.Name = "txtPhiGiaHan";
            this.txtPhiGiaHan.Size = new System.Drawing.Size(200, 20);
            this.txtPhiGiaHan.TabIndex = 4;
            // 
            // lblNgayThi
            // 
            this.lblNgayThi.AutoSize = true;
            this.lblNgayThi.Location = new System.Drawing.Point(30, 152);
            this.lblNgayThi.Name = "lblNgayThi";
            this.lblNgayThi.Size = new System.Drawing.Size(93, 13);
            this.lblNgayThi.TabIndex = 12;
            this.lblNgayThi.Text = "Ngày Thi Khả Thi:";
            // 
            // lstNgayThi
            // 
            this.lstNgayThi.FormattingEnabled = true;
            this.lstNgayThi.Location = new System.Drawing.Point(120, 152);
            this.lstNgayThi.Name = "lstNgayThi";
            this.lstNgayThi.Size = new System.Drawing.Size(200, 95);
            this.lstNgayThi.TabIndex = 5;
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Location = new System.Drawing.Point(120, 262);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(90, 30);
            this.btnKiemTra.TabIndex = 6;
            this.btnKiemTra.Text = "Kiểm Tra";
            this.btnKiemTra.UseVisualStyleBackColor = true;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // btnGiaHan
            // 
            this.btnGiaHan.Location = new System.Drawing.Point(230, 262);
            this.btnGiaHan.Name = "btnGiaHan";
            this.btnGiaHan.Size = new System.Drawing.Size(90, 30);
            this.btnGiaHan.TabIndex = 7;
            this.btnGiaHan.Text = "Gia Hạn";
            this.btnGiaHan.UseVisualStyleBackColor = true;
            this.btnGiaHan.Click += new System.EventHandler(this.btnGiaHan_Click);
            // 
            // lblKiemTraHoaDon
            // 
            this.lblKiemTraHoaDon.AutoSize = true;
            this.lblKiemTraHoaDon.Location = new System.Drawing.Point(400, 30);
            this.lblKiemTraHoaDon.Name = "lblKiemTraHoaDon";
            this.lblKiemTraHoaDon.Size = new System.Drawing.Size(98, 13);
            this.lblKiemTraHoaDon.TabIndex = 11;
            this.lblKiemTraHoaDon.Text = "Kiểm Tra Hóa Đơn:";
            // 
            // txtKiemTraHoaDon
            // 
            this.txtKiemTraHoaDon.Location = new System.Drawing.Point(550, 30);
            this.txtKiemTraHoaDon.Name = "txtKiemTraHoaDon";
            this.txtKiemTraHoaDon.Size = new System.Drawing.Size(150, 20);
            this.txtKiemTraHoaDon.TabIndex = 8;
            // 
            // btnTimKiemHoaDon
            // 
            this.btnTimKiemHoaDon.Location = new System.Drawing.Point(505, 27);
            this.btnTimKiemHoaDon.Name = "btnTimKiemHoaDon";
            this.btnTimKiemHoaDon.Size = new System.Drawing.Size(40, 25);
            this.btnTimKiemHoaDon.TabIndex = 9;
            this.btnTimKiemHoaDon.Text = "Tìm";
            this.btnTimKiemHoaDon.UseVisualStyleBackColor = true;
            this.btnTimKiemHoaDon.Click += new System.EventHandler(this.btnTimKiemHoaDon_Click);
            // 
            // gridViewHoaDon
            // 
            this.gridViewHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewHoaDon.Location = new System.Drawing.Point(400, 60);
            this.gridViewHoaDon.Name = "gridViewHoaDon";
            this.gridViewHoaDon.ReadOnly = true;
            this.gridViewHoaDon.RowHeadersWidth = 51;
            this.gridViewHoaDon.Size = new System.Drawing.Size(661, 150);
            this.gridViewHoaDon.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Salmon;
            this.button1.Location = new System.Drawing.Point(748, 311);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 18;
            this.button1.Text = "Đăng xuất ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(748, 216);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(88, 20);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Làm mới trang";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // GiaHanDacBiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1120, 540);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gridViewHoaDon);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnTimKiemHoaDon);
            this.Controls.Add(this.txtKiemTraHoaDon);
            this.Controls.Add(this.lblKiemTraHoaDon);
            this.Controls.Add(this.btnGiaHan);
            this.Controls.Add(this.btnKiemTra);
            this.Controls.Add(this.lstNgayThi);
            this.Controls.Add(this.lblNgayThi);
            this.Controls.Add(this.txtPhiGiaHan);
            this.Controls.Add(this.lblPhiGiaHan);
            this.Controls.Add(this.txtLyDo);
            this.Controls.Add(this.lblLyDo);
            this.Controls.Add(this.txtMaTS);
            this.Controls.Add(this.lblMaTS);
            this.Controls.Add(this.txtMaPDT);
            this.Controls.Add(this.lblMaPDT);
            this.Name = "GiaHanDacBiet";
            this.Text = "Gia hạn lịch thi";
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblMaPDT;
        private System.Windows.Forms.TextBox txtMaPDT;
        private System.Windows.Forms.Label lblMaTS;
        private System.Windows.Forms.TextBox txtMaTS;
        private System.Windows.Forms.Label lblLyDo;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Label lblPhiGiaHan;
        private System.Windows.Forms.TextBox txtPhiGiaHan;
        private System.Windows.Forms.Label lblNgayThi;
        private System.Windows.Forms.ListBox lstNgayThi;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.Button btnGiaHan;
        private System.Windows.Forms.Label lblKiemTraHoaDon;
        private System.Windows.Forms.TextBox txtKiemTraHoaDon;
        private System.Windows.Forms.Button btnTimKiemHoaDon;
        private System.Windows.Forms.DataGridView gridViewHoaDon;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button button1;
    }
}