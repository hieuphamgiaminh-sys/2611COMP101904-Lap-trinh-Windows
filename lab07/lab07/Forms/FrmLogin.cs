using lab07.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab07.Forms
{
    public partial class FrmLogin : Form
    {
        public User LoggedInUser { get; private set; }
        private TextBox txtUsername, txtPassword;
        private Button btnLogin, btnExit;

        public FrmLogin()
        {
            this.Text = "Đăng nhập hệ thống";
            this.Size = new Size(350, 220);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Controls.Add(new Label { Text = "Tài khoản:", Location = new Point(30, 30), AutoSize = true });
            this.Controls.Add(new Label { Text = "Mật khẩu:", Location = new Point(30, 70), AutoSize = true });
            txtUsername = new TextBox { Location = new Point(110, 27), Width = 180 };
            txtPassword = new TextBox { Location = new Point(110, 67), Width = 180, PasswordChar = '*' };
            btnLogin = new Button { Text = "Đăng nhập", Location = new Point(110, 110), Width = 85 };
            btnExit = new Button { Text = "Thoát", Location = new Point(205, 110), Width = 85 };
            btnLogin.Click += BtnLogin_Click;
            btnExit.Click += (s, e) => this.Close();
            this.Controls.AddRange(new Control[] { txtUsername, txtPassword, btnLogin, btnExit });
            this.AcceptButton = btnLogin;
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (user == "admin" && pass == "123")
            {
                LoggedInUser = new User { Username = "admin", FullName = "Quản trị viên", Role = "Admin" };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (user == "user" && pass == "123")
            {
                LoggedInUser = new User { Username = "user", FullName = "Nhân viên bán hàng", Role = "User" };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}