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
    public partial class QLBHDienTu :MetroFramework.Forms.MetroForm
    {

        //private int childFormNumber = 0;
        string ProjectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

        public QLBHDienTu()
        {
            InitializeComponent();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void QLBHDienTu_Load(object sender, EventArgs e)
        {
            //Full screen không có khung bên ngoài
            this.WindowState = FormWindowState.Maximized;

            if (!kTTonTaiForm("frm_DangNhap"));//frm_SanPham"))//frm_QL_NhaCungCap"));//
            {
                frm_DangNhap dn = new frm_DangNhap();
                dn.MdiParent = this;
                dn.Show();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLapTop_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        bool kTTonTaiForm(string fname)
        {
            foreach(Form f in MdiChildren)
            {
                if (f.Name == fname)
                {
                    return true;
                }
                
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (SessionLogin.TrangThaiDangNhap == false)
            {
                if (!kTTonTaiForm("frm_DangNhap"))
                {
                    frm_DangNhap dn = new frm_DangNhap();
                    dn.MdiParent = this;
                    dn.Show();
                }
            }
            else
            {
                MessageBox.Show("Chúc bạn " + SessionLogin.Quyen + " 1 ngày tốt lành 🌹🌹🌹♥❤❤");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!kTTonTaiForm("frm_SanPhamTieuBieu"))
            {
                frm_SanPhamTieuBieu dn = new frm_SanPhamTieuBieu();
                dn.MdiParent = this;
                dn.Show();
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        int r = 255; int g = 0; int b = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (SessionLogin.TrangThaiDangNhap == true)
            {
                button1.Text = SessionLogin.SessionUsername + "\n[" + SessionLogin.Quyen + "]";
                if (SessionLogin.maQuyen == 1) { button1.ForeColor = Color.Red; button1.Image = Image.FromFile(ProjectPath + "\\images16\\NCC.png"); }
                else if (SessionLogin.maQuyen > 1) {button1.ForeColor = Color.Blue;}
                

            }
            else { button1.ForeColor = Color.Black; button1.Image = Image.FromFile(ProjectPath + "\\images16\\Profile.png"); button1.Text = "Đăng nhập";}
            //Random r = new Random();

            //Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
            label1.ForeColor=
            panel1.BackColor =
            button2.BackColor =
            button3.BackColor =
            button4.BackColor =
            button5.BackColor =
                Color.FromArgb(r, g, b);

            if (r > 0 && b == 0)
            {
                r--;
                g++;
            }
            if (g > 0 && r == 0)
            {
                g--;
                b++;
            }
            if (b > 0 && g == 0)
            {
                b--;
                r++;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SessionLogin.maQuyen != 1) { MessageBox.Show("Bạn không có quyền"); return ; }
            closeAllToolStripMenuItem_Click(sender, e);
            if (!kTTonTaiForm("frm_DangKy"))//frm_QL_NhaCungCap
            {
                frm_DangKy dn = new frm_DangKy();
                dn.MdiParent = this;
                dn.Show();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SessionLogin.TrangThaiDangNhap) { MessageBox.Show("Bạn đã đăng nhập!"); return; }
            
            if (!kTTonTaiForm("frm_DangNhap"))//frm_QL_NhaCungCap
            {
                frm_DangNhap dn = new frm_DangNhap();
                dn.MdiParent = this;
                dn.Show();
            }
        }

        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("User: " + SessionLogin.SessionUsername);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SessionLogin.TrangThaiDangNhap)
            {
                closeAllToolStripMenuItem_Click(sender, e);
                SessionLogin.maQuyen = 0;
                SessionLogin.TrangThaiDangNhap = false;
            }
            else MessageBox.Show("Bạn chưa đăng nhập!!!");
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SessionLogin.TrangThaiDangNhap==false) { MessageBox.Show("Bạn không có quyền"); return; }
            if (!kTTonTaiForm("frm_NhanVien"))//frm_QL_NhaCungCap
            {
                frm_NhanVien dn = new frm_NhanVien();
                dn.MdiParent = this;
                dn.Show();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SessionLogin.maQuyen == 3 ||SessionLogin.maQuyen==0) { MessageBox.Show("Bạn không có quyền"); return; }
            if (!kTTonTaiForm("frm_KhachHang"))//frm_QL_NhaCungCap
            {
                frm_KhachHang dn = new frm_KhachHang();
                dn.MdiParent = this;
                dn.Show();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SessionLogin.TrangThaiDangNhap == false) { MessageBox.Show("Bạn không có quyền"); return; }
            if (!kTTonTaiForm("frm_SanPham"))//frm_QL_NhaCungCap
            {
                frm_SanPham dn = new frm_SanPham();
                dn.MdiParent = this;
                dn.Show();
            }
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SessionLogin.TrangThaiDangNhap == false) { MessageBox.Show("Bạn không có quyền"); return; }
            closeAllToolStripMenuItem_Click(sender, e);
            if (!kTTonTaiForm("frm_DonHang"))//frm_QL_NhaCungCap
            {
                frm_DonHang dn = new frm_DonHang();
                dn.MdiParent = this;
                dn.Show();
            }
        }

        private void hóaĐơnNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SessionLogin.TrangThaiDangNhap == false) { MessageBox.Show("Bạn không có quyền"); return; }
            closeAllToolStripMenuItem_Click(sender, e);
            if (!kTTonTaiForm("frm_DonNhap"))//frm_QL_NhaCungCap
            {
                frm_DonNhap dn = new frm_DonNhap();
                dn.MdiParent = this;
                dn.Show();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SessionLogin.TrangThaiDangNhap == false) { MessageBox.Show("Bạn không có quyền"); return; }
            if (!kTTonTaiForm("frm_NhaCC"))//frm_QL_NhaCungCap
            {
                frm_NhaCC dn = new frm_NhaCC();
                dn.MdiParent = this;
                dn.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (SessionLogin.TrangThaiDangNhap == false)
            {
                MessageBox.Show("Bạn không có quyền"); return;
            }
            else
            {
                if (!kTTonTaiForm("frm_SanPham"))//frm_QL_NhaCungCap
                {
                    frm_SanPham dn = new frm_SanPham();
                    dn.MdiParent = this;
                    dn.Show();
                }
            }
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mời bạn liên hệ BQT để lấy lại mật khẩu!!!\nSĐT: 09999999999\nEmail: huong32188@gmail.com");
        
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeAllToolStripMenuItem_Click(sender, e);
            if (!kTTonTaiForm("frm_DoiMatKhau"))
            {
                frm_DoiMatKhau dn = new frm_DoiMatKhau();
                dn.MdiParent = this;
                dn.Show();
            }
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {

            lbNgay.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy HH:mm:ss");
        }

        private void giaoDiệnTốiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.BackColor = Color.FromArgb(122, 122, 122);
        }

        private void saoLưuKhôiphụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SessionLogin.maQuyen != 1) { MessageBox.Show("Bạn không có quyền"); return; }
            closeAllToolStripMenuItem_Click(sender, e);
            if (!kTTonTaiForm("frm_SaoLuuVaKhoiPhuc"))
            {
                frm_SaoLuuVaKhoiPhuc dn = new frm_SaoLuuVaKhoiPhuc();
                dn.MdiParent = this;
                dn.Show();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if(SessionLogin.TrangThaiDangNhap == false)
            {
                MessageBox.Show("Bạn không có quyền"); return;
            }
            else
            {
                if (!kTTonTaiForm("frm_KhachHang"))//frm_QL_NhaCungCap
                {
                    frm_KhachHang dn = new frm_KhachHang();
                    dn.MdiParent = this;
                    dn.Show();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (SessionLogin.TrangThaiDangNhap == false)
            {
                MessageBox.Show("Bạn không có quyền"); return;
            }
            else
            {
                if (!kTTonTaiForm("frm_DonHang"))//frm_QL_NhaCungCap
                {
                    frm_DonHang dn = new frm_DonHang(SessionLogin.manv);
                    dn.MdiParent = this;
                    dn.Show();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (SessionLogin.TrangThaiDangNhap == false)
            {
                MessageBox.Show("Bạn không có quyền"); return;
            }
            else
            {
                if (!kTTonTaiForm("frm_DonNhap"))//frm_QL_NhaCungCap
                {
                    frm_DonNhap dn = new frm_DonNhap(SessionLogin.manv);
                    dn.MdiParent = this;
                    dn.Show();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (SessionLogin.TrangThaiDangNhap == false)
            {
                MessageBox.Show("Bạn không có quyền"); return;
            }
            else
            {
                if (!kTTonTaiForm("frm_NhaCC"))//frm_QL_NhaCungCap
                {
                    frm_NhaCC dn = new frm_NhaCC();
                    dn.MdiParent = this;
                    dn.Show();
                }
            }
        }
    }
}
