
namespace DoAn_Nhom16
{
    partial class frm_KhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_KhachHang));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbo_Khac = new System.Windows.Forms.RadioButton();
            this.rbo_Nu = new System.Windows.Forms.RadioButton();
            this.rbo_Nam = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uC_SDT = new DoAn_Nhom16.UC_TextBox();
            this.uC_Ma = new DoAn_Nhom16.UC_TextBox();
            this.uC_NgaySinh = new DoAn_Nhom16.UC_TextBox();
            this.uC_DiaChi = new DoAn_Nhom16.UC_TextBox();
            this.uC_Ten = new DoAn_Nhom16.UC_TextBox();
            this.btnIN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Honeydew;
            this.groupBox1.Controls.Add(this.rbo_Khac);
            this.groupBox1.Controls.Add(this.rbo_Nu);
            this.groupBox1.Controls.Add(this.rbo_Nam);
            this.groupBox1.Location = new System.Drawing.Point(386, 455);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 100);
            this.groupBox1.TabIndex = 133;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // rbo_Khac
            // 
            this.rbo_Khac.AutoSize = true;
            this.rbo_Khac.Enabled = false;
            this.rbo_Khac.Location = new System.Drawing.Point(361, 47);
            this.rbo_Khac.Name = "rbo_Khac";
            this.rbo_Khac.Size = new System.Drawing.Size(61, 21);
            this.rbo_Khac.TabIndex = 0;
            this.rbo_Khac.TabStop = true;
            this.rbo_Khac.Text = "Khác";
            this.rbo_Khac.UseVisualStyleBackColor = true;
            // 
            // rbo_Nu
            // 
            this.rbo_Nu.AutoSize = true;
            this.rbo_Nu.Enabled = false;
            this.rbo_Nu.Location = new System.Drawing.Point(212, 47);
            this.rbo_Nu.Name = "rbo_Nu";
            this.rbo_Nu.Size = new System.Drawing.Size(47, 21);
            this.rbo_Nu.TabIndex = 0;
            this.rbo_Nu.TabStop = true;
            this.rbo_Nu.Text = "Nữ";
            this.rbo_Nu.UseVisualStyleBackColor = true;
            // 
            // rbo_Nam
            // 
            this.rbo_Nam.AutoSize = true;
            this.rbo_Nam.Enabled = false;
            this.rbo_Nam.Location = new System.Drawing.Point(43, 47);
            this.rbo_Nam.Name = "rbo_Nam";
            this.rbo_Nam.Size = new System.Drawing.Size(58, 21);
            this.rbo_Nam.TabIndex = 0;
            this.rbo_Nam.TabStop = true;
            this.rbo_Nam.Text = "Nam";
            this.rbo_Nam.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Location = new System.Drawing.Point(-3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 803);
            this.panel1.TabIndex = 14;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Firebrick;
            this.btnTimKiem.FlatAppearance.BorderSize = 3;
            this.btnTimKiem.Image = global::DoAn_Nhom16.Properties.Resources.Start_Menu_Search_icon;
            this.btnTimKiem.Location = new System.Drawing.Point(403, 57);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(140, 54);
            this.btnTimKiem.TabIndex = 69;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(17, 57);
            this.txtTimKiem.Multiline = true;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(380, 54);
            this.txtTimKiem.TabIndex = 67;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(-2, 150);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(563, 623);
            this.listView1.TabIndex = 66;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên ";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "SDT";
            this.columnHeader3.Width = 148;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(215, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 29);
            this.label1.TabIndex = 124;
            this.label1.Text = "Mã";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(228, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 29);
            this.label3.TabIndex = 124;
            this.label3.Text = "Địa chỉ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.OrangeRed;
            this.label5.Location = new System.Drawing.Point(256, 595);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 29);
            this.label5.TabIndex = 123;
            this.label5.Text = "SĐT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.OrangeRed;
            this.label6.Location = new System.Drawing.Point(227, 384);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 29);
            this.label6.TabIndex = 122;
            this.label6.Text = "Ngày sinh";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.OrangeRed;
            this.label4.Location = new System.Drawing.Point(201, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 29);
            this.label4.TabIndex = 121;
            this.label4.Text = "Họ Và Tên";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.OrangeRed;
            this.label11.Location = new System.Drawing.Point(227, 474);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 29);
            this.label11.TabIndex = 125;
            this.label11.Text = "Giới tính";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label12.Location = new System.Drawing.Point(406, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(332, 63);
            this.label12.TabIndex = 110;
            this.label12.Text = "THÔNG TIN";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.btnHuy);
            this.panel4.Controls.Add(this.btnXoa);
            this.panel4.Controls.Add(this.btnThem);
            this.panel4.Controls.Add(this.btnSua);
            this.panel4.Controls.Add(this.btnLuu);
            this.panel4.Location = new System.Drawing.Point(351, 661);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(567, 72);
            this.panel4.TabIndex = 1;
            // 
            // btnHuy
            // 
            this.btnHuy.Enabled = false;
            this.btnHuy.Image = global::DoAn_Nhom16.Properties.Resources.Close_2_icon;
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(445, -2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(117, 72);
            this.btnHuy.TabIndex = 102;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = global::DoAn_Nhom16.Properties.Resources.Delete;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(212, -2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(114, 72);
            this.btnXoa.TabIndex = 68;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Image = global::DoAn_Nhom16.Properties.Resources.Add;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(-2, -2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(111, 72);
            this.btnThem.TabIndex = 67;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Image = global::DoAn_Nhom16.Properties.Resources.Modify1;
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(100, -2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(117, 72);
            this.btnSua.TabIndex = 65;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Enabled = false;
            this.btnLuu.Image = global::DoAn_Nhom16.Properties.Resources.Save;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(322, -2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(130, 72);
            this.btnLuu.TabIndex = 66;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Location = new System.Drawing.Point(561, 14);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1283, 808);
            this.panel3.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.uC_SDT);
            this.groupBox2.Controls.Add(this.uC_Ma);
            this.groupBox2.Controls.Add(this.uC_NgaySinh);
            this.groupBox2.Controls.Add(this.uC_DiaChi);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.uC_Ten);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.btnIN);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1319, 803);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Chi Tiết";
            // 
            // uC_SDT
            // 
            this.uC_SDT.Enabled = false;
            this.uC_SDT.Location = new System.Drawing.Point(378, 570);
            this.uC_SDT.Name = "uC_SDT";
            this.uC_SDT.setColor = System.Drawing.Color.Orange;
            this.uC_SDT.setIcon = ((System.Drawing.Image)(resources.GetObject("uC_SDT.setIcon")));
            this.uC_SDT.Size = new System.Drawing.Size(545, 71);
            this.uC_SDT.TabIndex = 131;
            // 
            // uC_Ma
            // 
            this.uC_Ma.Enabled = false;
            this.uC_Ma.Location = new System.Drawing.Point(373, 84);
            this.uC_Ma.Name = "uC_Ma";
            this.uC_Ma.setColor = System.Drawing.Color.Orange;
            this.uC_Ma.setIcon = ((System.Drawing.Image)(resources.GetObject("uC_Ma.setIcon")));
            this.uC_Ma.Size = new System.Drawing.Size(545, 71);
            this.uC_Ma.TabIndex = 131;
            // 
            // uC_NgaySinh
            // 
            this.uC_NgaySinh.Enabled = false;
            this.uC_NgaySinh.Location = new System.Drawing.Point(386, 364);
            this.uC_NgaySinh.Name = "uC_NgaySinh";
            this.uC_NgaySinh.setColor = System.Drawing.Color.Orange;
            this.uC_NgaySinh.setIcon = ((System.Drawing.Image)(resources.GetObject("uC_NgaySinh.setIcon")));
            this.uC_NgaySinh.Size = new System.Drawing.Size(545, 71);
            this.uC_NgaySinh.TabIndex = 131;
            // 
            // uC_DiaChi
            // 
            this.uC_DiaChi.Enabled = false;
            this.uC_DiaChi.Location = new System.Drawing.Point(386, 265);
            this.uC_DiaChi.Name = "uC_DiaChi";
            this.uC_DiaChi.setColor = System.Drawing.Color.Orange;
            this.uC_DiaChi.setIcon = ((System.Drawing.Image)(resources.GetObject("uC_DiaChi.setIcon")));
            this.uC_DiaChi.Size = new System.Drawing.Size(545, 71);
            this.uC_DiaChi.TabIndex = 131;
            // 
            // uC_Ten
            // 
            this.uC_Ten.Enabled = false;
            this.uC_Ten.Location = new System.Drawing.Point(386, 179);
            this.uC_Ten.Name = "uC_Ten";
            this.uC_Ten.setColor = System.Drawing.Color.Orange;
            this.uC_Ten.setIcon = ((System.Drawing.Image)(resources.GetObject("uC_Ten.setIcon")));
            this.uC_Ten.Size = new System.Drawing.Size(545, 71);
            this.uC_Ten.TabIndex = 131;
            // 
            // btnIN
            // 
            this.btnIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIN.Image = global::DoAn_Nhom16.Properties.Resources.Print_icon;
            this.btnIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIN.Location = new System.Drawing.Point(1078, 680);
            this.btnIN.Name = "btnIN";
            this.btnIN.Size = new System.Drawing.Size(117, 72);
            this.btnIN.TabIndex = 102;
            this.btnIN.Text = "In";
            this.btnIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIN.UseVisualStyleBackColor = true;
            this.btnIN.Click += new System.EventHandler(this.btnIN_Click);
            // 
            // frm_KhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1841, 836);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "frm_KhachHang";
            this.Text = "frm_KhachHang";
            this.Load += new System.EventHandler(this.frm_KhachHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbo_Khac;
        private System.Windows.Forms.RadioButton rbo_Nu;
        private System.Windows.Forms.RadioButton rbo_Nam;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnSua;
        private UC_TextBox uC_SDT;
        private UC_TextBox uC_Ma;
        private UC_TextBox uC_NgaySinh;
        private UC_TextBox uC_DiaChi;
        private System.Windows.Forms.Label label1;
        private UC_TextBox uC_Ten;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnIN;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}