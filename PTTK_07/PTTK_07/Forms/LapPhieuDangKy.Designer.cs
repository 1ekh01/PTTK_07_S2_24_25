namespace PTTK_07.Forms
{
    partial class LapPhieuDangKy
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
            this.gvKhachHang = new System.Windows.Forms.DataGridView();
            this.gvThiSinh = new System.Windows.Forms.DataGridView();
            this.gvLichThiConTrong = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvThiSinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLichThiConTrong)).BeginInit();
            this.SuspendLayout();
            // 
            // gvKhachHang
            // 
            this.gvKhachHang.AllowUserToAddRows = false;
            this.gvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvKhachHang.Location = new System.Drawing.Point(50, 50);
            this.gvKhachHang.Name = "gvKhachHang";
            this.gvKhachHang.Size = new System.Drawing.Size(500, 200);
            this.gvKhachHang.TabIndex = 0;
            // 
            // gvThiSinh
            // 
            this.gvThiSinh.AllowUserToAddRows = false;
            this.gvThiSinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvThiSinh.Location = new System.Drawing.Point(650, 50);
            this.gvThiSinh.Name = "gvThiSinh";
            this.gvThiSinh.Size = new System.Drawing.Size(500, 200);
            this.gvThiSinh.TabIndex = 1;
            // 
            // gvLichThiConTrong
            // 
            this.gvLichThiConTrong.AllowUserToAddRows = false;
            this.gvLichThiConTrong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLichThiConTrong.Location = new System.Drawing.Point(50, 300);
            this.gvLichThiConTrong.Name = "gvLichThiConTrong";
            this.gvLichThiConTrong.Size = new System.Drawing.Size(500, 200);
            this.gvLichThiConTrong.TabIndex = 2;
            // 
            // LapPhieuDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.gvLichThiConTrong);
            this.Controls.Add(this.gvThiSinh);
            this.Controls.Add(this.gvKhachHang);
            this.Name = "LapPhieuDangKy";
            this.Text = "Lập Phiếu đăng ký";
            ((System.ComponentModel.ISupportInitialize)(this.gvKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvThiSinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLichThiConTrong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvKhachHang;
        private System.Windows.Forms.DataGridView gvThiSinh;
        private System.Windows.Forms.DataGridView gvLichThiConTrong;
    }
}