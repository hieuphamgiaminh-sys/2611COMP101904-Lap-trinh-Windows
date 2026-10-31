using System.Drawing;
using System.Windows.Forms;

namespace lab07.Forms
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            this.Text = "Giới thiệu";
            this.Size = new Size(300, 200);
            this.StartPosition = FormStartPosition.CenterParent;
            Label lblInfo = new Label
            {
                Text = "Phần mềm Quản lý Cửa hàng Mini\n\nPhát triển bởi: [Tên của bạn]\nMSSV: [Mã số SV]\nLớp: COMP1019",
                Location = new Point(30, 40),
                AutoSize = true,
                Font = new Font("Arial", 10)
            };
            this.Controls.Add(lblInfo);
        }
    }
}