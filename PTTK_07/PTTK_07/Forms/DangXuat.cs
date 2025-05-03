using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTTK_07.Forms
{
    public partial class DangXuat : Form
    {
        public DangXuat(string message)
        {
            InitializeComponent();
            lbMessage.Text = message; // Gán thông báo vào Label
        }

        private void Inside()
        {
            //// Thiết kế giao diện (thay vì dùng Designer)
            //this.Size = new Size(300, 170);
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //this.MaximizeBox = false;
            //this.MinimizeBox = false;
            //this.StartPosition = FormStartPosition.CenterParent;

            //// Label hiển thị thông báo
            //lblMessage = new Label
            //{
            //    AutoSize = false,
            //    Size = new Size(260, 40),
            //    Location = new Point(20, 20),
            //    TextAlign = ContentAlignment.MiddleCenter
            //};
            //this.Controls.Add(lblMessage);

            //// Nút "Có"
            //Button btnYes = new Button
            //{
            //    Text = "Có",
            //    Size = new Size(75, 30),
            //    Location = new Point(70, 80),
            //    DialogResult = DialogResult.Yes
            //};
            //this.Controls.Add(btnYes);

            //// Nút "Không"
            //Button btnNo = new Button
            //{
            //    Text = "Không",
            //    Size = new Size(75, 30),
            //    Location = new Point(155, 80),
            //    DialogResult = DialogResult.No
            //};
            //this.Controls.Add(btnNo);

            //this.AcceptButton = btnYes; // Enter nhấn "Có"
            //this.CancelButton = btnNo;  // Esc nhấn "Không"
        }
    }
}
