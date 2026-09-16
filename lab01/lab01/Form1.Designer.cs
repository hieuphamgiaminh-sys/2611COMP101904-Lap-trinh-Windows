namespace lab01
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Controls
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblNamSinh;
        private System.Windows.Forms.TextBox txtNamSinh;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.GroupBox groupBoxGender;
        private System.Windows.Forms.RadioButton radNam;
        private System.Windows.Forms.RadioButton radNu;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Button btnHienThi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblNamSinh = new Label();
            txtNamSinh = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            groupBoxGender = new GroupBox();
            radNam = new RadioButton();
            radNu = new RadioButton();
            lblKhoa = new Label();
            cboKhoa = new ComboBox();
            btnHienThi = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            txtKetQua = new TextBox();
            groupBoxGender.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(120, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(352, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "NHẬP THÔNG TIN SINH VIÊN";
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(20, 50);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(70, 25);
            lblHoTen.TabIndex = 1;
            lblHoTen.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(120, 48);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(360, 31);
            txtHoTen.TabIndex = 2;
            // 
            // lblNamSinh
            // 
            lblNamSinh.AutoSize = true;
            lblNamSinh.Location = new Point(20, 90);
            lblNamSinh.Name = "lblNamSinh";
            lblNamSinh.Size = new Size(91, 25);
            lblNamSinh.TabIndex = 3;
            lblNamSinh.Text = "Năm sinh:";
            // 
            // txtNamSinh
            // 
            txtNamSinh.Location = new Point(120, 88);
            txtNamSinh.Name = "txtNamSinh";
            txtNamSinh.Size = new Size(120, 31);
            txtNamSinh.TabIndex = 4;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(20, 130);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(58, 25);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(120, 128);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(360, 31);
            txtEmail.TabIndex = 6;
            // 
            // groupBoxGender
            // 
            groupBoxGender.Controls.Add(radNam);
            groupBoxGender.Controls.Add(radNu);
            groupBoxGender.Location = new Point(20, 170);
            groupBoxGender.Name = "groupBoxGender";
            groupBoxGender.Size = new Size(240, 60);
            groupBoxGender.TabIndex = 7;
            groupBoxGender.TabStop = false;
            groupBoxGender.Text = "Giới tính";
            // 
            // radNam
            // 
            radNam.AutoSize = true;
            radNam.Location = new Point(15, 25);
            radNam.Name = "radNam";
            radNam.Size = new Size(75, 29);
            radNam.TabIndex = 0;
            radNam.Text = "Nam";
            // 
            // radNu
            // 
            radNu.AutoSize = true;
            radNu.Location = new Point(100, 25);
            radNu.Name = "radNu";
            radNu.Size = new Size(61, 29);
            radNu.TabIndex = 1;
            radNu.Text = "Nữ";
            // 
            // lblKhoa
            // 
            lblKhoa.AutoSize = true;
            lblKhoa.Location = new Point(20, 250);
            lblKhoa.Name = "lblKhoa";
            lblKhoa.Size = new Size(93, 25);
            lblKhoa.TabIndex = 8;
            lblKhoa.Text = "Khoa/Lớp:";
            // 
            // cboKhoa
            // 
            cboKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoa.Items.AddRange(new object[] { "Công nghệ thông tin", "Kỹ thuật phần mềm", "Mạng máy tính" });
            cboKhoa.Location = new Point(120, 246);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(240, 33);
            cboKhoa.TabIndex = 9;
            // 
            // btnHienThi
            // 
            btnHienThi.Location = new Point(20, 300);
            btnHienThi.Name = "btnHienThi";
            btnHienThi.Size = new Size(100, 30);
            btnHienThi.TabIndex = 10;
            btnHienThi.Text = "Hiển thị";
            btnHienThi.Click += btnHienThi_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(140, 300);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 30);
            btnXoa.TabIndex = 11;
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(260, 300);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(100, 30);
            btnThoat.TabIndex = 12;
            btnThoat.Text = "Thoát";
            btnThoat.Click += btnThoat_Click;
            // 
            // txtKetQua
            // 
            txtKetQua.Location = new Point(20, 348);
            txtKetQua.Multiline = true;
            txtKetQua.Name = "txtKetQua";
            txtKetQua.ReadOnly = true;
            txtKetQua.Size = new Size(460, 191);
            txtKetQua.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 551);
            Controls.Add(lblTitle);
            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);
            Controls.Add(lblNamSinh);
            Controls.Add(txtNamSinh);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(groupBoxGender);
            Controls.Add(lblKhoa);
            Controls.Add(cboKhoa);
            Controls.Add(btnHienThi);
            Controls.Add(btnXoa);
            Controls.Add(btnThoat);
            Controls.Add(txtKetQua);
            Name = "Form1";
            Text = "Thông tin sinh viên";
            groupBoxGender.ResumeLayout(false);
            groupBoxGender.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtKetQua;
    }
}
