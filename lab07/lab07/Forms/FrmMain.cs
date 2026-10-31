using lab07.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab07.Forms
{
    public partial class FrmMain : Form
    {
        private User _currentUser;
        private ToolStripStatusLabel lblUserInfo, lblTime;
        public FrmMain(User user)
        {
            _currentUser = user;
            this.Text = "Phần mềm Quản lý Cửa hàng Mini";
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
            MenuStrip menuStrip = new MenuStrip();
            var menuHeThong = new ToolStripMenuItem("Hệ thống");
            menuHeThong.DropDownItems.Add(new ToolStripMenuItem("Đăng xuất", null, MenuDangXuat_Click));
            menuHeThong.DropDownItems.Add(new ToolStripMenuItem("Thoát", null, (s, e) => Application.Exit()));
            var menuDanhMuc = new ToolStripMenuItem("Danh mục");
            menuDanhMuc.DropDownItems.Add(new ToolStripMenuItem("Quản lý Sản phẩm", null, (s, e) => OpenChildForm(typeof(FrmProduct))));
            menuDanhMuc.DropDownItems.Add(new ToolStripMenuItem("Quản lý Khách hàng", null, (s, e) => OpenChildForm(typeof(FrmCustomer))));
            var menuTroGiup = new ToolStripMenuItem("Trợ giúp");
            menuTroGiup.DropDownItems.Add(new ToolStripMenuItem("Giới thiệu", null, (s, e) => OpenChildForm(typeof(FrmAbout))));
            menuStrip.Items.AddRange(new ToolStripItem[] { menuHeThong, menuDanhMuc, menuTroGiup });
            StatusStrip statusStrip = new StatusStrip();
            lblUserInfo = new ToolStripStatusLabel { Text = $"Xin chào: {_currentUser.FullName} | Vai trò: {_currentUser.Role}" };
            lblTime = new ToolStripStatusLabel { Spring = true, TextAlign = ContentAlignment.MiddleRight };
            statusStrip.Items.AddRange(new ToolStripItem[] { lblUserInfo, lblTime });
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer { Interval = 1000, Enabled = true };
            timer.Tick += (s, e) => lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            this.Controls.Add(statusStrip);
            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;
            this.FormClosing += (s, e) =>
            {
                if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) e.Cancel = true;
            };
        }
        private void OpenChildForm(Type formType)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == formType) { frm.Activate(); return; }
            }
            Form newForm = (Form)Activator.CreateInstance(formType);
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void MenuDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin login = new FrmLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                _currentUser = login.LoggedInUser;
                lblUserInfo.Text = $"Xin chào: {_currentUser.FullName} | Vai trò: {_currentUser.Role}";
                this.Show();
            }
            else Application.Exit();
        }
    }
}