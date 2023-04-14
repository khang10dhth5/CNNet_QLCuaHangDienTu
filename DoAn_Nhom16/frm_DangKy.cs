
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
    public partial class frm_DangKy : Form
    {
        string ProjectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        XuLyDB db = new XuLyDB();
        App_Tools app =new App_Tools();
        public frm_DangKy()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void uC_TextBox2_Load(object sender, EventArgs e)
        {

        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            //Lấy value của CBO
                //MessageBox.Show("Đang chọn: " + uC_ComboBox2.selectedItem + ";Index:" + uC_ComboBox2.selectedIndex);

            //Lấy value của DATE
            //Date: 01/34/6789
            //string d, m, y;
            //Lấy từ vị trí/ đếm về sau số ký tự>>>
            //d = uC_Date1.Text.Trim().Substring(0, 2);
            //m = uC_Date1.Text.Trim().Substring(3, 2);
            //y = uC_Date1.Text.Trim().Substring(6, 4);
            //    MessageBox.Show("Ngày: '" + d+ "' Tháng: '" +m+"' Năm '"+y+"'");
            if (string.IsNullOrEmpty(uC_TextBox2.Text) || string.IsNullOrEmpty(uC_TextBox3.Text) || string.IsNullOrEmpty(uC_TextBox4.Text) || string.IsNullOrEmpty(uC_TextBox5.Text) || string.IsNullOrEmpty(uC_TextBox6.Text))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!!!");
                return;
            }
            if (uC_TextBox3.Text.Trim().Length > 15 || uC_TextBox3.Text.Trim().All(Char.IsDigit) != true)
            {
                MessageBox.Show("SĐT phải là SỐ & ít hơn 16 ký tự!!!");
                return;
            }
            if (uC_TextBox5.Text.Trim().Length < 8 || uC_TextBox6.Text.Trim().Length < 8)
            {
                MessageBox.Show("Các mật khẩu phải nhiều hơn 8 ký tự!!!");
                return;
            }
            if (uC_TextBox6.Text.Trim() != uC_TextBox5.Text.Trim())
            {
                MessageBox.Show("Nhập lại mật khẩu sai!!!");
                return;
            }
            if (db.checkTonTai("SELECT*FROM NHANVIEN where SDT ='"+uC_TextBox3.Text.Trim()+"'"))
            {
                MessageBox.Show("Số điện đã được sử dụng để đăng ký!!!");
                return;
            }
            else 
            {
                
                string d, m, y;
                //Lấy từ vị trí/ đếm về sau số ký tự>>>
                d = uC_Date1.Text.Trim().Substring(0, 2);
                m = uC_Date1.Text.Trim().Substring(3, 2);
                y = uC_Date1.Text.Trim().Substring(6, 4);
                if (db.ThemXoaSua(@"SET DATEFORMAT DMY INSERT INTO NHANVIEN(TENNV,NGAYSINH,GIOITINH,SDT,DIACHI ,MATKHAU ,MAQUYEN)
  VALUES(N'" + uC_TextBox2.Text.Trim() + "',N'" + d + "/" + m + "/" + y + "',N'" + uC_ComboBox1.selectedItem.Trim() + "',N'" + uC_TextBox3.Text.Trim() + "',N'" + uC_TextBox4.Text.Trim() + "',N'"+app.MaHoaMatKhau(uC_TextBox6.Text.Trim())+"',"+(uC_ComboBox2.selectedIndex + 1)+")"))
                {
                    MessageBox.Show("Thêm nhân viên thành công!!!");
                    return;
                }
                else MessageBox.Show("Thêm nhân viên thất bại!!!");
            }
        }

        private void uC_TextBox1_Load(object sender, EventArgs e)
        {

        }

        private void frm_DangKy_Load(object sender, EventArgs e)
        {
            //Full screen không có khung bên ngoài
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            //ẩn mã nv
            label1.Visible = uC_TextBox1.Visible =  false;//true;//
            uC_TextBox2.setIcon = Image.FromFile(ProjectPath + "\\images16\\name-card-icon.png");
            uC_TextBox3.setIcon = Image.FromFile(ProjectPath + "\\images16\\dienthoai.jpg");
            uC_TextBox4.setIcon = Image.FromFile(ProjectPath + "\\images16\\Info.png");
            uC_ComboBox2.setIcon = Image.FromFile(ProjectPath + "\\images16\\System-Security-Reader-2-icon.png");
            uC_TextBox5.setIcon = Image.FromFile(ProjectPath + "\\images16\\modify-key.png");
            uC_TextBox6.setIcon = Image.FromFile(ProjectPath + "\\images16\\modify-key.png");


            uC_TextBox5.SetPass = '❤';
            uC_TextBox6.SetPass = '❤';

            uC_ComboBox1.setListItem = new List<string> { "Nam", "Nữ", "BĐ" };
            uC_ComboBox2.setListItem = new List<string> { "Quản lý", "Bán hàng", "Bảo trì", "kế toán" };

            Random r = new Random();
            BackColor = Color.Yellow;

            //Gán cho CBO:
            //uC_ComboBox2.selectedIndex = 2;
            //uC_ComboBox1.selectedItem = "Nữ";
        }

        private void uC_Button1_Click(object sender, EventArgs e)
        {//del
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
                //label1.ForeColor = label2.ForeColor = label3.ForeColor = label4.ForeColor = label5.ForeColor = label6.ForeColor = label7.ForeColor = label8.ForeColor = label9.ForeColor = label10.ForeColor =
                button1.ForeColor=
                //uC_TextBox1.setColor =
                uC_ComboBox1.setColor =
                uC_TextBox2.setColor =
                uC_TextBox3.setColor =
                uC_TextBox4.setColor =
                uC_ComboBox2.setColor =
                uC_TextBox5.setColor =
                uC_TextBox6.setColor =
                uC_Date1.setColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
            
        }

    }
}
