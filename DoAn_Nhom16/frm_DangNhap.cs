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
    public partial class frm_DangNhap : Form
    {
        string ProjectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        XuLyDB db = new XuLyDB();
        App_Tools app = new App_Tools();
        public frm_DangNhap()
        {
            InitializeComponent();
         
        }

        private void frm_DangNhap_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            uC_TextBox1.setIcon = Image.FromFile(ProjectPath + "\\images16\\dienthoai.jpg");
            uC_TextBox2.setIcon = Image.FromFile(ProjectPath + "\\images16\\modify-key.png");
            uC_TextBox2.SetPass = '֍';

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
            MessageBox.Show("Mời bạn liên hệ BQT để đăng ký!!!\nSĐT: 09999999999\nEmail: huong32188@gmail.com");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uC_TextBox1.Text.Trim()) || string.IsNullOrEmpty(uC_TextBox2.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!!!");
                return;
            }
            if (db.checkTonTai("SELECT*FROM NHANVIEN where SDT ='" + uC_TextBox1.Text.Trim() + "'")!=true)
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
                SessionLogin.SessionUsername = db.LayDL("SELECT TENNV FROM NHANVIEN where  SDT ='" + uC_TextBox1.Text.Trim() + "' And MATKHAU ='" + app.MaHoaMatKhau(uC_TextBox2.Text.Trim()) + "'");
                SessionLogin.TrangThaiDangNhap = true; 
                SessionLogin.manv = db.LayDL("SELECT MANV FROM NHANVIEN where SDT ='" + uC_TextBox1.Text.Trim() + "' And MATKHAU =N'" + app.MaHoaMatKhau(uC_TextBox2.Text.Trim()) + "'");
                
                string maQuyen = db.LayDL("SELECT MAQUYEN FROM NHANVIEN where SDT ='" + uC_TextBox1.Text.Trim() + "' And MATKHAU =N'" + app.MaHoaMatKhau(uC_TextBox2.Text.Trim()) + "'");
                if (int.Parse(maQuyen.Trim()) == 1) { SessionLogin.Quyen = "Quản lý"; SessionLogin.maQuyen = 1; }
                else if (int.Parse(maQuyen.Trim()) == 2) { SessionLogin.Quyen = "Bán hàng"; SessionLogin.maQuyen = 2; }
                else if (int.Parse(maQuyen.Trim()) == 3) { SessionLogin.Quyen = "Bảo trì"; SessionLogin.maQuyen = 3; }
                else { SessionLogin.Quyen = "Kế toán"; SessionLogin.maQuyen = 4; }
                
                MessageBox.Show("Đăng nhập thành công!!!");
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            button1.ForeColor =
            uC_TextBox2.setColor =
            uC_TextBox1.setColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
        }
    }
}
