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
            this.lblMaPDT = new System.Windows.Forms.Label();
            this.txtMaPDT = new System.Windows.Forms.TextBox();
            this.lblNgayGiaHan = new System.Windows.Forms.Label();
            this.dtpNgayGiaHan = new System.Windows.Forms.DateTimePicker();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.lblPhiGiaHan = new System.Windows.Forms.Label();
            this.txtPhiGiaHan = new System.Windows.Forms.TextBox();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.dgvLich = new System.Windows.Forms.DataGridView();
            this.btnGiaHan = new System.Windows.Forms.Button();
            this.lblMaTS = new System.Windows.Forms.Label(); // Thêm nhãn cho MaTS
            this.txtMaTS = new System.Windows.Forms.TextBox(); // Thêm TextBox cho MaTS

            ((System.ComponentModel.ISupportInitialize)(this.dgvLich)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaPDT
            // 
            this.lblMaPDT.AutoSize = true;
            this.lblMaPDT.Location = new System.Drawing.Point(12, 12);
            this.lblMaPDT.Name = "lblMaPDT";
            this.lblMaPDT.Size = new System.Drawing.Size(50, 13);
            this.lblMaPDT.TabIndex = 0;
            this.lblMaPDT.Text = "Mã PDT:";
            // 
            // txtMaPDT
            // 
            this.txtMaPDT.Location = new System.Drawing.Point(100, 12);
            this.txtMaPDT.Name = "txtMaPDT";
            this.txtMaPDT.Size = new System.Drawing.Size(200, 20);
            this.txtMaPDT.TabIndex = 1;
            // 
            // lblNgayGiaHan
            // 
            this.lblNgayGiaHan.AutoSize = true;
            this.lblNgayGiaHan.Location = new System.Drawing.Point(12, 40);
            this.lblNgayGiaHan.Name = "lblNgayGiaHan";
            this.lblNgayGiaHan.Size = new System.Drawing.Size(75, 13);
            this.lblNgayGiaHan.TabIndex = 2;
            this.lblNgayGiaHan.Text = "Ngày gia hạn:";
            // 
            // dtpNgayGiaHan
            // 
            this.dtpNgayGiaHan.Location = new System.Drawing.Point(100, 38);
            this.dtpNgayGiaHan.Name = "dtpNgayGiaHan";
            this.dtpNgayGiaHan.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayGiaHan.TabIndex = 3;
            // 
            // lblLyDo
            // 
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Location = new System.Drawing.Point(12, 68);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(82, 13);
            this.lblLyDo.TabIndex = 4;
            this.lblLyDo.Text = "Lý do gia hạn:";
            // 
            // txtLyDo
            // 
            this.txtLyDo.Location = new System.Drawing.Point(100, 64);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(200, 20);
            this.txtLyDo.TabIndex = 5;
            // 
            // lblPhiGiaHan
            // 
            this.lblPhiGiaHan.AutoSize = true;
            this.lblPhiGiaHan.Location = new System.Drawing.Point(12, 94);
            this.lblPhiGiaHan.Name = "lblPhiGiaHan";
            this.lblPhiGiaHan.Size = new System.Drawing.Size(71, 13);
            this.lblPhiGiaHan.TabIndex = 6;
            this.lblPhiGiaHan.Text = "Phí gia hạn:";
            // 
            // txtPhiGiaHan
            // 
            this.txtPhiGiaHan.Location = new System.Drawing.Point(100, 90);
            this.txtPhiGiaHan.Name = "txtPhiGiaHan";
            this.txtPhiGiaHan.Size = new System.Drawing.Size(200, 20);
            this.txtPhiGiaHan.TabIndex = 7;
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Location = new System.Drawing.Point(320, 12);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(75, 23);
            this.btnKiemTra.TabIndex = 8;
            this.btnKiemTra.Text = "Kiểm tra";
            this.btnKiemTra.UseVisualStyleBackColor = true;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // dgvLich
            // 
            this.dgvLich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLich.Location = new System.Drawing.Point(12, 140);
            this.dgvLich.Name = "dgvLich";
            this.dgvLich.Size = new System.Drawing.Size(700, 200);
            this.dgvLich.TabIndex = 9;
            this.dgvLich.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaLT", HeaderText = "Mã Lịch Thi", Name = "MaLT" });
            this.dgvLich.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgayGioThi", HeaderText = "Ngày Giờ Thi", Name = "NgayGioThi" });
            this.dgvLich.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoLuongToiDa", HeaderText = "Số Lượng Tối Đa", Name = "SoLuongToiDa" });
            this.dgvLich.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoLuongDaDangKy", HeaderText = "Số Lượng Đã Đăng Ký", Name = "SoLuongDaDangKy" });
            this.dgvLich.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LoaiChungChi", HeaderText = "Loại Chứng Chỉ", Name = "LoaiChungChi" });
            this.dgvLich.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaPT", HeaderText = "Mã Phòng Thi", Name = "MaPT" });
            // 
            // btnGiaHan
            // 
            this.btnGiaHan.Location = new System.Drawing.Point(320, 90);
            this.btnGiaHan.Name = "btnGiaHan";
            this.btnGiaHan.Size = new System.Drawing.Size(120, 23);
            this.btnGiaHan.TabIndex = 10;
            this.btnGiaHan.Text = "Gia hạn";
            this.btnGiaHan.UseVisualStyleBackColor = true;
            this.btnGiaHan.Click += new System.EventHandler(this.btnGiaHan_Click);
            // 
            // lblMaTS
            // 
            this.lblMaTS.AutoSize = true;
            this.lblMaTS.Location = new System.Drawing.Point(12, 118); // Đặt dưới lblPhiGiaHan hoặc điều chỉnh vị trí phù hợp
            this.lblMaTS.Name = "lblMaTS";
            this.lblMaTS.Size = new System.Drawing.Size(50, 13);
            this.lblMaTS.TabIndex = 11;
            this.lblMaTS.Text = "Mã TS:";
            // 
            // txtMaTS
            // 
            this.txtMaTS.Location = new System.Drawing.Point(100, 114); // Đặt dưới txtPhiGiaHan hoặc điều chỉnh vị trí phù hợp
            this.txtMaTS.Name = "txtMaTS";
            this.txtMaTS.Size = new System.Drawing.Size(200, 20);
            this.txtMaTS.TabIndex = 12;
            // 
            // frmGiaHan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 341);
            this.Controls.Add(this.txtMaTS);
            this.Controls.Add(this.lblMaTS);
            this.Controls.Add(this.btnGiaHan);
            this.Controls.Add(this.dgvLich);
            this.Controls.Add(this.btnKiemTra);
            this.Controls.Add(this.txtPhiGiaHan);
            this.Controls.Add(this.lblPhiGiaHan);
            this.Controls.Add(this.txtLyDo);
            this.Controls.Add(this.lblLyDo);
            this.Controls.Add(this.dtpNgayGiaHan);
            this.Controls.Add(this.lblNgayGiaHan);
            this.Controls.Add(this.txtMaPDT);
            this.Controls.Add(this.lblMaPDT);
            this.Name = "frmGiaHan";
            this.Text = "Gia hạn (Nhân viên)";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLich)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblMaPDT;
        private System.Windows.Forms.TextBox txtMaPDT;
        private System.Windows.Forms.Label lblNgayGiaHan;
        private System.Windows.Forms.DateTimePicker dtpNgayGiaHan;
        private System.Windows.Forms.Label lblLyDo;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Label lblPhiGiaHan;
        private System.Windows.Forms.TextBox txtPhiGiaHan;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.DataGridView dgvLich;
        private System.Windows.Forms.Button btnGiaHan;
        private System.Windows.Forms.Label lblMaTS;
        private System.Windows.Forms.TextBox txtMaTS; 
    }
}