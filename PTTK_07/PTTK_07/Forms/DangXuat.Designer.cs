namespace PTTK_07.Forms
{
    partial class DangXuat
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
            this.lbMessage = new System.Windows.Forms.Label();
            this.btnCo = new System.Windows.Forms.Button();
            this.btnKhong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbMessage
            // 
            this.lbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbMessage.Location = new System.Drawing.Point(12, 20);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(300, 40);
            this.lbMessage.TabIndex = 0;
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCo
            // 
            this.btnCo.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnCo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCo.Location = new System.Drawing.Point(80, 90);
            this.btnCo.Name = "btnCo";
            this.btnCo.Size = new System.Drawing.Size(75, 30);
            this.btnCo.TabIndex = 1;
            this.btnCo.Text = "Có";
            this.btnCo.UseVisualStyleBackColor = true;
            // 
            // btnKhong
            // 
            this.btnKhong.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnKhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnKhong.Location = new System.Drawing.Point(169, 90);
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.Size = new System.Drawing.Size(75, 30);
            this.btnKhong.TabIndex = 2;
            this.btnKhong.Text = "Không";
            this.btnKhong.UseVisualStyleBackColor = true;
            // 
            // DangXuat
            // 
            this.AcceptButton = this.btnCo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnKhong;
            this.ClientSize = new System.Drawing.Size(324, 131);
            this.Controls.Add(this.btnKhong);
            this.Controls.Add(this.btnCo);
            this.Controls.Add(this.lbMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DangXuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng xuất";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Button btnCo;
        private System.Windows.Forms.Button btnKhong;
    }
}