using System.Windows.Forms;

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
            this.lblChucNang = new System.Windows.Forms.Label();
            this.lblMaPDT = new System.Windows.Forms.Label();
            this.txtMaPDT = new System.Windows.Forms.TextBox();
            this.lblSBD = new System.Windows.Forms.Label();
            this.txtSBD = new System.Windows.Forms.TextBox();
            this.lblMaTS = new System.Windows.Forms.Label();
            this.txtMaTS = new System.Windows.Forms.TextBox();
            this.lblLyDoGH = new System.Windows.Forms.Label();
            this.txtLyDoGH = new System.Windows.Forms.TextBox();
            this.lblNgayGiaHan = new System.Windows.Forms.Label();
            this.dtpNgayGiaHan = new System.Windows.Forms.DateTimePicker();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.btnGiaHan = new System.Windows.Forms.Button();
            this.dgvLich = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLich)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChucNang
            // 
            this.lblChucNang.AutoSize = false;
            this.lblChucNang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblChucNang.Location = new System.Drawing.Point(450, 0);
            this.lblChucNang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChucNang.Name = "lbChucNang";
            this.lblChucNang.Size = new System.Drawing.Size(266, 36);
            this.lblChucNang.TabIndex = 5;
            this.lblChucNang.Text = "GIA HẠN ĐẶC BIỆT";
            // 
            // lblMaPDT
            // 
            this.lblMaPDT.AutoSize = true;
            this.lblMaPDT.Location = new System.Drawing.Point(66, 135);
            this.lblMaPDT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaPDT.Name = "lblMaPDT";
            this.lblMaPDT.Size = new System.Drawing.Size(60, 16);
            this.lblMaPDT.TabIndex = 11;
            this.lblMaPDT.Text = "Mã PDT:";
            // 
            // txtMaPDT
            // 
            this.txtMaPDT.Location = new System.Drawing.Point(159, 131);
            this.txtMaPDT.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaPDT.Name = "txtMaPDT";
            this.txtMaPDT.Size = new System.Drawing.Size(199, 22);
            this.txtMaPDT.TabIndex = 10;
            this.txtMaPDT.TextChanged += new System.EventHandler(this.txtMaPDT_TextChanged);
            // 
            // lblSBD
            // 
            this.lblSBD.AutoSize = true;
            this.lblSBD.Location = new System.Drawing.Point(66, 172);
            this.lblSBD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSBD.Name = "lblSBD";
            this.lblSBD.Size = new System.Drawing.Size(38, 16);
            this.lblSBD.TabIndex = 9;
            this.lblSBD.Text = "SBD:";
            // 
            // txtSBD
            // 
            this.txtSBD.Location = new System.Drawing.Point(159, 168);
            this.txtSBD.Margin = new System.Windows.Forms.Padding(4);
            this.txtSBD.Name = "txtSBD";
            this.txtSBD.Size = new System.Drawing.Size(199, 22);
            this.txtSBD.TabIndex = 8;
            // 
            // lblMaTS
            // 
            this.lblMaTS.AutoSize = true;
            this.lblMaTS.Location = new System.Drawing.Point(66, 209);
            this.lblMaTS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaTS.Name = "lblMaTS";
            this.lblMaTS.Size = new System.Drawing.Size(50, 16);
            this.lblMaTS.TabIndex = 7;
            this.lblMaTS.Text = "Mã TS:";
            // 
            // txtMaTS
            // 
            this.txtMaTS.Location = new System.Drawing.Point(159, 205);
            this.txtMaTS.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaTS.Name = "txtMaTS";
            this.txtMaTS.Size = new System.Drawing.Size(199, 22);
            this.txtMaTS.TabIndex = 6;
            // 
            // lblLyDoGH
            // 
            this.lblLyDoGH.AutoSize = true;
            this.lblLyDoGH.Location = new System.Drawing.Point(66, 246);
            this.lblLyDoGH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLyDoGH.Name = "lblLyDoGH";
            this.lblLyDoGH.Size = new System.Drawing.Size(66, 16);
            this.lblLyDoGH.TabIndex = 5;
            this.lblLyDoGH.Text = "Lý do GH:";
            // 
            // txtLyDoGH
            // 
            this.txtLyDoGH.Location = new System.Drawing.Point(159, 242);
            this.txtLyDoGH.Margin = new System.Windows.Forms.Padding(4);
            this.txtLyDoGH.Name = "txtLyDoGH";
            this.txtLyDoGH.Size = new System.Drawing.Size(199, 22);
            this.txtLyDoGH.TabIndex = 4;
            // 
            // lblNgayGiaHan
            // 
            this.lblNgayGiaHan.AutoSize = true;
            this.lblNgayGiaHan.Location = new System.Drawing.Point(66, 283);
            this.lblNgayGiaHan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgayGiaHan.Name = "lblNgayGiaHan";
            this.lblNgayGiaHan.Size = new System.Drawing.Size(90, 16);
            this.lblNgayGiaHan.TabIndex = 3;
            this.lblNgayGiaHan.Text = "Ngày gia hạn:";
            // 
            // dtpNgayGiaHan
            // 
            this.dtpNgayGiaHan.Location = new System.Drawing.Point(159, 279);
            this.dtpNgayGiaHan.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNgayGiaHan.Name = "dtpNgayGiaHan";
            this.dtpNgayGiaHan.Size = new System.Drawing.Size(250, 22);
            this.dtpNgayGiaHan.TabIndex = 2;
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Location = new System.Drawing.Point(159, 320);
            this.btnKiemTra.Margin = new System.Windows.Forms.Padding(4);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(100, 28);
            this.btnKiemTra.TabIndex = 1;
            this.btnKiemTra.Text = "Kiểm tra";
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // btnGiaHan
            // 
            this.btnGiaHan.Enabled = false;
            this.btnGiaHan.Location = new System.Drawing.Point(700, 356);
            this.btnGiaHan.Name = "btnGiaHan";
            this.btnGiaHan.Size = new System.Drawing.Size(75, 23);
            this.btnGiaHan.TabIndex = 12;
            this.btnGiaHan.Text = "Gia hạn";
            this.btnGiaHan.Click += new System.EventHandler(this.btnGiaHan_Click);
            // 
            // dgvLich
            // 
            this.dgvLich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLich.Location = new System.Drawing.Point(426, 135);
            this.dgvLich.Margin = new System.Windows.Forms.Padding(4);
            this.dgvLich.Name = "dgvLich";
            this.dgvLich.RowHeadersWidth = 51;
            this.dgvLich.Size = new System.Drawing.Size(600, 219);
            this.dgvLich.TabIndex = 0;
            this.dgvLich.SelectionChanged += new System.EventHandler(this.dgvLich_SelectionChanged);
            // 
            // GiaHanDacBiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.lblChucNang);
            this.Controls.Add(this.dgvLich);
            this.Controls.Add(this.btnKiemTra);
            this.Controls.Add(this.dtpNgayGiaHan);
            this.Controls.Add(this.lblNgayGiaHan);
            this.Controls.Add(this.txtLyDoGH);
            this.Controls.Add(this.lblLyDoGH);
            this.Controls.Add(this.txtMaTS);
            this.Controls.Add(this.lblMaTS);
            this.Controls.Add(this.txtSBD);
            this.Controls.Add(this.lblSBD);
            this.Controls.Add(this.txtMaPDT);
            this.Controls.Add(this.lblMaPDT);
            this.Controls.Add(this.btnGiaHan);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GiaHanDacBiet";
            this.Text = "Gia hạn Đặc biệt";
            this.Load += new System.EventHandler(this.GiaHanDacBiet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLich)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblChucNang;
        private System.Windows.Forms.Label lblMaPDT;
        private System.Windows.Forms.TextBox txtMaPDT;
        private System.Windows.Forms.Label lblSBD;
        private System.Windows.Forms.TextBox txtSBD;
        private System.Windows.Forms.Label lblMaTS;
        private System.Windows.Forms.TextBox txtMaTS;
        private System.Windows.Forms.Label lblLyDoGH;
        private System.Windows.Forms.TextBox txtLyDoGH;
        private System.Windows.Forms.Label lblNgayGiaHan;
        private System.Windows.Forms.DateTimePicker dtpNgayGiaHan;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.DataGridView dgvLich;
        private System.Windows.Forms.Button btnGiaHan;
    }
}