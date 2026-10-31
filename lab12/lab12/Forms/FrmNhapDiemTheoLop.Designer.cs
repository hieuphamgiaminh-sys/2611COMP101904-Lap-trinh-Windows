namespace lab12.Forms
{
    partial class FrmNhapDiemTheoLop
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
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.cboMonHoc = new System.Windows.Forms.ComboBox();
            this.btnTaiDanhSach = new System.Windows.Forms.Button();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.btnLuuTatCa = new System.Windows.Forms.Button();
            this.lblLop = new System.Windows.Forms.Label();
            this.lblMonHoc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.SuspendLayout();
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(53, 14);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(160, 23);
            this.cboMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonHoc.FormattingEnabled = true;
            this.cboMonHoc.Location = new System.Drawing.Point(298, 14);
            this.cboMonHoc.Name = "cboMonHoc";
            this.cboMonHoc.Size = new System.Drawing.Size(200, 23);
            this.btnTaiDanhSach.Location = new System.Drawing.Point(517, 13);
            this.btnTaiDanhSach.Name = "btnTaiDanhSach";
            this.btnTaiDanhSach.Size = new System.Drawing.Size(110, 25);
            this.btnTaiDanhSach.Text = "Tải danh sách";
            this.btnTaiDanhSach.UseVisualStyleBackColor = true;
            this.btnTaiDanhSach.Click += new System.EventHandler(this.btnTaiDanhSach_Click);
            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.AllowUserToDeleteRows = false;
            this.dgvKetQua.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKetQua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Location = new System.Drawing.Point(12, 53);
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.Size = new System.Drawing.Size(615, 340);
            this.btnLuuTatCa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuTatCa.Location = new System.Drawing.Point(517, 406);
            this.btnLuuTatCa.Name = "btnLuuTatCa";
            this.btnLuuTatCa.Size = new System.Drawing.Size(110, 30);
            this.btnLuuTatCa.Text = "Lưu tất cả";
            this.btnLuuTatCa.UseVisualStyleBackColor = true;
            this.btnLuuTatCa.Click += new System.EventHandler(this.btnLuuTatCa_Click);
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(14, 18);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(30, 15);
            this.lblLop.Text = "Lớp:";
            this.lblMonHoc.AutoSize = true;
            this.lblMonHoc.Location = new System.Drawing.Point(230, 18);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Size = new System.Drawing.Size(58, 15);
            this.lblMonHoc.Text = "Môn học:";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 448);
            this.Controls.Add(this.lblMonHoc);
            this.Controls.Add(this.lblLop);
            this.Controls.Add(this.btnLuuTatCa);
            this.Controls.Add(this.dgvKetQua);
            this.Controls.Add(this.btnTaiDanhSach);
            this.Controls.Add(this.cboMonHoc);
            this.Controls.Add(this.cboLop);
            this.Name = "FrmNhapDiemTheoLop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý kết quả học tập";
            this.Load += new System.EventHandler(this.FrmNhapDiemTheoLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.ComboBox cboMonHoc;
        private System.Windows.Forms.Button btnTaiDanhSach;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.Button btnLuuTatCa;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Label lblMonHoc;
    }
}