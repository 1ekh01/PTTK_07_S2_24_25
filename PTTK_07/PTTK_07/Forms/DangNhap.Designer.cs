using System.Windows.Forms;

namespace PTTK_07.Forms
{
    partial class DangNhap
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
            this.lbTenTaiKhoan = new System.Windows.Forms.Label();
            this.lbMatKhau = new System.Windows.Forms.Label();
            this.txtTenTaiKhoan = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.lbUseCase = new System.Windows.Forms.Label();
            this.cbUseCase = new System.Windows.Forms.ComboBox();
            this.lbACCI = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbTenTaiKhoan
            // 
            this.lbTenTaiKhoan.AutoSize = true;
            this.lbTenTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbTenTaiKhoan.Location = new System.Drawing.Point(140, 119);
            this.lbTenTaiKhoan.Name = "lbTenTaiKhoan";
            this.lbTenTaiKhoan.Size = new System.Drawing.Size(105, 20);
            this.lbTenTaiKhoan.TabIndex = 0;
            this.lbTenTaiKhoan.Text = "Tên tài khoản";
            // 
            // lbMatKhau
            // 
            this.lbMatKhau.AutoSize = true;
            this.lbMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbMatKhau.Location = new System.Drawing.Point(168, 213);
            this.lbMatKhau.Name = "lbMatKhau";
            this.lbMatKhau.Size = new System.Drawing.Size(75, 20);
            this.lbMatKhau.TabIndex = 1;
            this.lbMatKhau.Text = "Mật khẩu";
            // 
            // txtTenTaiKhoan
            // 
            this.txtTenTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTenTaiKhoan.Location = new System.Drawing.Point(295, 116);
            this.txtTenTaiKhoan.Name = "txtTenTaiKhoan";
            this.txtTenTaiKhoan.Size = new System.Drawing.Size(325, 26);
            this.txtTenTaiKhoan.TabIndex = 2;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtMatKhau.Location = new System.Drawing.Point(295, 210);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(325, 26);
            this.txtMatKhau.TabIndex = 3;
            this.txtMatKhau.UseSystemPasswordChar = true;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDangNhap.Location = new System.Drawing.Point(339, 395);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(118, 34);
            this.btnDangNhap.TabIndex = 4;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // lbUseCase
            // 
            this.lbUseCase.AutoSize = true;
            this.lbUseCase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbUseCase.Location = new System.Drawing.Point(166, 315);
            this.lbUseCase.Name = "lbUseCase";
            this.lbUseCase.Size = new System.Drawing.Size(79, 20);
            this.lbUseCase.TabIndex = 5;
            this.lbUseCase.Text = "Use Case";
            // 
            // cbUseCase
            // 
            this.cbUseCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUseCase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbUseCase.FormattingEnabled = true;
            this.cbUseCase.Items.AddRange(new object[] {
            "Đăng ký thi Cá nhân",
            "Lập Phiếu đăng ký",
            "Thanh toán",
            "Gia hạn Đặc biệt",
            "Gia hạn Tính phí",
            "Cấp chứng chỉ"});
            this.cbUseCase.Location = new System.Drawing.Point(295, 312);
            this.cbUseCase.Name = "cbUseCase";
            this.cbUseCase.Size = new System.Drawing.Size(325, 28);
            this.cbUseCase.TabIndex = 6;
            // 
            // lbACCI
            // 
            this.lbACCI.AutoSize = true;
            this.lbACCI.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lbACCI.Location = new System.Drawing.Point(206, 32);
            this.lbACCI.Name = "lbACCI";
            this.lbACCI.Size = new System.Drawing.Size(430, 62);
            this.lbACCI.TabIndex = 7;
            this.lbACCI.Text = "Trung tâm tổ chức thi \nchứng chỉ anh ngữ và tin học ACCI";
            this.lbACCI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 467);
            this.Controls.Add(this.lbACCI);
            this.Controls.Add(this.cbUseCase);
            this.Controls.Add(this.lbUseCase);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTenTaiKhoan);
            this.Controls.Add(this.lbMatKhau);
            this.Controls.Add(this.lbTenTaiKhoan);
            this.Name = "DangNhap";
            this.Text = "Đăng nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTenTaiKhoan;
        private System.Windows.Forms.Label lbMatKhau;
        private System.Windows.Forms.TextBox txtTenTaiKhoan;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Label lbUseCase;
        private System.Windows.Forms.ComboBox cbUseCase;
        private Label lbACCI;
    }
}