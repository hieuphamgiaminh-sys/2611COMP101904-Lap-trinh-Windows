namespace lab09
{
    partial class lab09 : System.Windows.Forms.Form
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

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(lab09));
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtCourse = new System.Windows.Forms.TextBox();
            this.cboClass = new System.Windows.Forms.ComboBox();
            this.cboFaculty = new System.Windows.Forms.ComboBox();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.pnlCardPreview = new System.Windows.Forms.Panel();
            this.btnChoosePhoto = new System.Windows.Forms.Button();
            this.btnPreviewPrint = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();

            System.Windows.Forms.Label label1 = new System.Windows.Forms.Label();
            System.Windows.Forms.Label label2 = new System.Windows.Forms.Label();
            System.Windows.Forms.Label label3 = new System.Windows.Forms.Label();
            System.Windows.Forms.Label label4 = new System.Windows.Forms.Label();
            System.Windows.Forms.Label label5 = new System.Windows.Forms.Label();
            System.Windows.Forms.Label label6 = new System.Windows.Forms.Label();
            System.Windows.Forms.Label label7 = new System.Windows.Forms.Label();
            System.Windows.Forms.Label label8 = new System.Windows.Forms.Label();
            System.Windows.Forms.GroupBox grpInput = new System.Windows.Forms.GroupBox();

            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            grpInput.SuspendLayout();
            this.SuspendLayout();

            // grpInput
            grpInput.Controls.Add(this.btnChoosePhoto);
            grpInput.Controls.Add(this.picAvatar);
            grpInput.Controls.Add(this.cboGender);
            grpInput.Controls.Add(this.dtpBirthDate);
            grpInput.Controls.Add(this.txtCourse);
            grpInput.Controls.Add(this.cboFaculty);
            grpInput.Controls.Add(this.cboClass);
            grpInput.Controls.Add(this.txtFullName);
            grpInput.Controls.Add(this.txtStudentId);
            grpInput.Controls.Add(label8);
            grpInput.Controls.Add(label7);
            grpInput.Controls.Add(label6);
            grpInput.Controls.Add(label5);
            grpInput.Controls.Add(label4);
            grpInput.Controls.Add(label3);
            grpInput.Controls.Add(label2);
            grpInput.Controls.Add(label1);
            grpInput.Location = new System.Drawing.Point(20, 20);
            grpInput.Name = "grpInput";
            grpInput.Size = new System.Drawing.Size(330, 480);
            grpInput.TabIndex = 0;
            grpInput.TabStop = false;
            grpInput.Text = "Nhập thông tin sinh viên";

            // Labels Configuration
            label1.AutoSize = true; label1.Location = new System.Drawing.Point(20, 40); label1.Text = "MSSV:";
            label2.AutoSize = true; label2.Location = new System.Drawing.Point(20, 80); label2.Text = "Họ tên:";
            label3.AutoSize = true; label3.Location = new System.Drawing.Point(20, 120); label3.Text = "Lớp:";
            label4.AutoSize = true; label4.Location = new System.Drawing.Point(20, 160); label4.Text = "Khoa:";
            label5.AutoSize = true; label5.Location = new System.Drawing.Point(20, 200); label5.Text = "Khóa học:";
            label6.AutoSize = true; label6.Location = new System.Drawing.Point(20, 240); label6.Text = "Ngày sinh:";
            label7.AutoSize = true; label7.Location = new System.Drawing.Point(20, 280); label7.Text = "Giới tính:";
            label8.AutoSize = true; label8.Location = new System.Drawing.Point(20, 320); label8.Text = "Ảnh đại diện:";

            this.txtStudentId.Location = new System.Drawing.Point(120, 37);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new System.Drawing.Size(180, 27);

            this.txtFullName.Location = new System.Drawing.Point(120, 77);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(180, 27);

            this.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClass.Location = new System.Drawing.Point(120, 117);
            this.cboClass.Name = "cboClass";
            this.cboClass.Size = new System.Drawing.Size(180, 28);

            this.cboFaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFaculty.Location = new System.Drawing.Point(120, 157);
            this.cboFaculty.Name = "cboFaculty";
            this.cboFaculty.Size = new System.Drawing.Size(180, 28);

            this.txtCourse.Location = new System.Drawing.Point(120, 197);
            this.txtCourse.Name = "txtCourse";
            this.txtCourse.Size = new System.Drawing.Size(180, 27);

            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(120, 237);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(180, 27);

            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.Location = new System.Drawing.Point(120, 277);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(180, 28);

            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.Location = new System.Drawing.Point(120, 320);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(95, 125);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.btnChoosePhoto.Location = new System.Drawing.Point(225, 320);
            this.btnChoosePhoto.Name = "btnChoosePhoto";
            this.btnChoosePhoto.Size = new System.Drawing.Size(75, 30);
            this.btnChoosePhoto.Text = "Chọn ảnh";

            this.pnlCardPreview.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlCardPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardPreview.Location = new System.Drawing.Point(370, 28);
            this.pnlCardPreview.Name = "pnlCardPreview";
            this.pnlCardPreview.Size = new System.Drawing.Size(560, 360);

            this.btnPreviewPrint.Location = new System.Drawing.Point(20, 520);
            this.btnPreviewPrint.Name = "btnPreviewPrint";
            this.btnPreviewPrint.Size = new System.Drawing.Size(110, 45);
            this.btnPreviewPrint.Text = "Xem trước In";

            this.btnPrint.Location = new System.Drawing.Point(140, 520);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 45);
            this.btnPrint.Text = "In Thẻ";

            this.btnClear.Location = new System.Drawing.Point(250, 520);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 45);
            this.btnClear.Text = "Làm mới";

            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Visible = false;

            this.printDialog1.UseEXDialog = true;

            // Form lab09
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 590);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPreviewPrint);
            this.Controls.Add(this.pnlCardPreview);
            this.Controls.Add(grpInput);
            this.Name = "lab09";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COMP1019 - Thiết kế thẻ sinh viên";
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtCourse;
        private System.Windows.Forms.ComboBox cboClass;
        private System.Windows.Forms.ComboBox cboFaculty;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Panel pnlCardPreview;
        private System.Windows.Forms.Button btnChoosePhoto;
        private System.Windows.Forms.Button btnPreviewPrint;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClear;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}