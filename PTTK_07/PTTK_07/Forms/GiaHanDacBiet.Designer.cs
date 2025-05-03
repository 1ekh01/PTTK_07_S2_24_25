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
            this.lblNgayGiaHan = new System.Windows.Forms.Label();
            this.dateTimePickerGiaHan = new System.Windows.Forms.DateTimePicker();
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

            // 
            // lblMaPDT
            // 
            this.lblMaPDT.AutoSize = true;
            this.lblMaPDT.Location = new System.Drawing.Point(30, 30);
            this.lblMaPDT.Name = "lblMaPDT";
            this.lblMaPDT.Size = new System.Drawing.Size(60, 13);
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
            this.lblMaTS.Size = new System.Drawing.Size(60, 13);
            this.lblMaTS.Text = "Mã TS:";

            // 
            // txtMaTS
            // 
            this.txtMaTS.Location = new System.Drawing.Point(120, 57);
            this.txtMaTS.Name = "txtMaTS";
            this.txtMaTS.Size = new System.Drawing.Size(200, 20);
            this.txtMaTS.TabIndex = 1;

            // 
            // lblNgayGiaHan
            // 
            this.lblNgayGiaHan.AutoSize = true;
            this.lblNgayGiaHan.Location = new System.Drawing.Point(30, 90);
            this.lblNgayGiaHan.Name = "lblNgayGiaHan";
            this.lblNgayGiaHan.Size = new System.Drawing.Size(80, 13);
            this.lblNgayGiaHan.Text = "Ngày Gia Hạn:";

            // 
            // dateTimePickerGiaHan
            // 
            this.dateTimePickerGiaHan.Location = new System.Drawing.Point(120, 87);
            this.dateTimePickerGiaHan.Name = "dateTimePickerGiaHan";
            this.dateTimePickerGiaHan.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerGiaHan.TabIndex = 2;

            // 
            // lblLyDo
            // 
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Location = new System.Drawing.Point(30, 120);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(40, 13);
            this.lblLyDo.Text = "Lý Do:";

            // 
            // txtLyDo
            // 
            this.txtLyDo.Location = new System.Drawing.Point(120, 117);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(200, 20);
            this.txtLyDo.TabIndex = 3;

            // 
            // lblPhiGiaHan
            // 
            this.lblPhiGiaHan.AutoSize = true;
            this.lblPhiGiaHan.Location = new System.Drawing.Point(30, 150);
            this.lblPhiGiaHan.Name = "lblPhiGiaHan";
            this.lblPhiGiaHan.Size = new System.Drawing.Size(70, 13);
            this.lblPhiGiaHan.Text = "Phí Gia Hạn:";

            // 
            // txtPhiGiaHan
            // 
            this.txtPhiGiaHan.Location = new System.Drawing.Point(120, 147);
            this.txtPhiGiaHan.Name = "txtPhiGiaHan";
            this.txtPhiGiaHan.Size = new System.Drawing.Size(200, 20);
            this.txtPhiGiaHan.TabIndex = 4;

            // 
            // lblNgayThi
            // 
            this.lblNgayThi.AutoSize = true;
            this.lblNgayThi.Location = new System.Drawing.Point(30, 180);
            this.lblNgayThi.Name = "lblNgayThi";
            this.lblNgayThi.Size = new System.Drawing.Size(80, 13);
            this.lblNgayThi.Text = "Ngày Thi Khả Thi:";

            // 
            // lstNgayThi
            // 
            this.lstNgayThi.FormattingEnabled = true;
            this.lstNgayThi.Location = new System.Drawing.Point(120, 180);
            this.lstNgayThi.Name = "lstNgayThi";
            this.lstNgayThi.Size = new System.Drawing.Size(200, 95);
            this.lstNgayThi.TabIndex = 5;

            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Location = new System.Drawing.Point(120, 290);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(90, 30);
            this.btnKiemTra.TabIndex = 6;
            this.btnKiemTra.Text = "Kiểm Tra";
            this.btnKiemTra.UseVisualStyleBackColor = true;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);

            // 
            // btnGiaHan
            // 
            this.btnGiaHan.Location = new System.Drawing.Point(230, 290);
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
            this.lblKiemTraHoaDon.Size = new System.Drawing.Size(80, 13);
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
            this.gridViewHoaDon.Size = new System.Drawing.Size(661, 150);
            this.gridViewHoaDon.TabIndex = 10;
            this.gridViewHoaDon.ReadOnly = true;

            // 
            // GiaHanDacBiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 540);
            this.Controls.Add(this.gridViewHoaDon);
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
            this.Controls.Add(this.dateTimePickerGiaHan);
            this.Controls.Add(this.lblNgayGiaHan);
            this.Controls.Add(this.txtMaTS);
            this.Controls.Add(this.lblMaTS);
            this.Controls.Add(this.txtMaPDT);
            this.Controls.Add(this.lblMaPDT);
            this.Name = "GiaHanDacBiet";
            this.Text = "Gia Hạn Đặc Biệt";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblMaPDT;
        private System.Windows.Forms.TextBox txtMaPDT;
        private System.Windows.Forms.Label lblMaTS;
        private System.Windows.Forms.TextBox txtMaTS;
        private System.Windows.Forms.Label lblNgayGiaHan;
        private System.Windows.Forms.DateTimePicker dateTimePickerGiaHan;
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
    }
}