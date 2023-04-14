using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom16
{
    public partial class frm_DoiMatKhau : Form
    {
        string ProjectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        XuLyDB db = new XuLyDB();
        App_Tools app = new App_Tools();
        public frm_DoiMatKhau()
        {
            InitializeComponent();
        }

        private void frm_DoiMatKhau_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            uC_TextBox1.setIcon = Image.FromFile(ProjectPath + "\\images16\\dienthoai.jpg");
            uC_TextBox2.setIcon = Image.FromFile(ProjectPath + "\\images16\\modify-key.png");
            uC_TextBox3.setIcon = Image.FromFile(ProjectPath + "\\images16\\modify-key.png");
            uC_TextBox4.setIcon = Image.FromFile(ProjectPath + "\\images16\\modify-key.png");
            uC_TextBox2.SetPass = '֍';
            uC_TextBox3.SetPass = '֍';
            uC_TextBox4.SetPass = '֍';
        }

        bool kTTonTaiForm(string fname)
        {
            foreach (Form f in MdiChildren)
            {
                if (f.Name == fname)
                {
                    return true;
                }

            }
            return false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mời bạn liên hệ BQT để lấy lại mật khẩu!!!\nSĐT: 09999999999\nEmail: huong32188@gmail.com");
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uC_TextBox1.Text.Trim()) || string.IsNullOrEmpty(uC_TextBox2.Text.Trim()) || string.IsNullOrEmpty(uC_TextBox3.Text.Trim()) || string.IsNullOrEmpty(uC_TextBox4.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!!!");
                return;
            }
            else if ((uC_TextBox3.Text.Trim()) ==(uC_TextBox2.Text.Trim()))
            {
                MessageBox.Show("Mật khẩu mới phải khác mật khẩu cũ!!!");
                return;
            }
            else if ((uC_TextBox4.Text.Trim()) != (uC_TextBox3.Text.Trim()))
            {
                MessageBox.Show("Nhập lại mật khẩu không chính xác!!!");
                return;
            }
            if (db.checkTonTai("SELECT*FROM NHANVIEN where SDT ='" + uC_TextBox1.Text.Trim() + "'") != true)
            {
                MessageBox.Show("Số điện thoại không tồn tại!!!");
                return;
            }
            else if (db.checkTonTai("SELECT*FROM NHANVIEN where SDT ='" + uC_TextBox1.Text.Trim() + "' and  MATKHAU =N'" + app.MaHoaMatKhau(uC_TextBox2.Text.Trim()) + "'") != true)
            {
                MessageBox.Show("Mật khẩu không chính xác!!!");
                return;
            }
            else
            {
                string sql = String.Format("UPDATE NHANVIEN " +
                    " SET MATKHAU=N'{0}' WHERE SDT={1}",
                    app.MaHoaMatKhau(uC_TextBox4.Text.Trim()),uC_TextBox1.Text.Trim());
                bool kq = db.ThemXoaSua(sql);
                if (kq == true)
                {

                    MessageBox.Show("Đổi mật khẩu thành công!!!");
                }
                else
                {

                    MessageBox.Show("Đổi mật khẩu không thành công!!!");
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
                //label1.ForeColor = label2.ForeColor = label3.ForeColor = label4.ForeColor = label5.ForeColor = label6.ForeColor = label7.ForeColor = label8.ForeColor = label9.ForeColor = label10.ForeColor =
                button1.ForeColor=
                uC_TextBox1.setColor =
                uC_TextBox2.setColor =
                uC_TextBox3.setColor =
                uC_TextBox4.setColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
            
        }
    }
}
