using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
namespace DoAn_Nhom16
{
    public partial class frm_SanPham : Form
    {
        string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        XuLyDB db = new XuLyDB();
        DataTable dtSanPham, dtNCC,dtLoai;
        DataColumn[] keytb = new DataColumn[1];
        bool them;
        public frm_SanPham()
        {
            InitializeComponent();
        }
        public void LuuAnh(string path)
        {
            using (var bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height))
            {
                pictureBox1.DrawToBitmap(bitmap, pictureBox1.ClientRectangle);
                ImageFormat imageFormat = null;

                var extension = Path.GetExtension(path);
                switch (extension)
                {
                    case ".bmp":
                        imageFormat = ImageFormat.Bmp;
                        break;
                    case ".png":
                        imageFormat = ImageFormat.Png;
                        break;
                    case ".jpeg":
                    case ".jpg":
                        imageFormat = ImageFormat.Jpeg;
                        break;
                    case ".gif":
                        imageFormat = ImageFormat.Gif;
                        break;
                    default:
                        throw new NotSupportedException("Định dạng file không được hỗ trợ!!!");
                }

                bitmap.Save(path, imageFormat);
            }
        }
        public Image resizeAnh(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            //pictureBox1.Image = null;
            //string aaa = projectPath + @"\HinhAnhSP\" + openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf(@"\") + 1);
            //openFileDialog1.Reset();
            //File.Delete(aaa);//@"D:\LeVanHuong_2001190104\.NET\.DoAn\DoAn_Nhom16_03\DoAn_Nhom16\HinhAnhSP\z2815346455553_4b2922ef8b7f286cd8610ed18e882466.jpg");
            //projectPath + @"\HinhAnhSP\" + openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf(@"\") + 1)); 
            //return;
            //MessageBox.Show(projectPath + @"\HinhAnhSP\" + openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf(@"\") + 1)); return;
            them = true;
            txtMa.Visible = false;
            txtTen.Text = "";
            txtGia.Text = "";
            txtSoLuong.Text = "";
            cbo_NCC.SelectedIndex = -1;
            cbo_TB.SelectedIndex = -1;
            rbo_New.Checked = true;
            txtMoTa.Text = "";
            txtTen.Enabled = true;
            txtGia.Enabled = true;
            txtSoLuong.Enabled = true;
            cbo_NCC.Enabled = true;
            cbo_TB.Enabled = true;
            rbo_New.Enabled = true;
            txtMoTa.ReadOnly = false;
            rbo_New.Enabled = true;
            rbo_99.Enabled = true;
            rbo_95.Enabled = true;
            pictureBox1.Image = null;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled= true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {

                txtMa.Text = listView1.SelectedItems[0].SubItems[0].Text;
                txtTen.Text = listView1.SelectedItems[0].SubItems[1].Text;
                //txtGia.Text= listView1.SelectedItems[0].SubItems[1].Text;
                DataRow selectedrow=null;
                foreach (DataRow row in dtSanPham.Rows)
                {
                    
                    if (row[0].ToString()==listView1.SelectedItems[0].SubItems[0].Text)
                    {
                        selectedrow = row;
                       
                    }
                }

                pictureBox1.Image = Image.FromFile(projectPath + "\\HinhAnhSP\\" + selectedrow[2].ToString());
                txtGia.Text = selectedrow[3].ToString().Substring(0,selectedrow[3].ToString().LastIndexOf('.'));
                txtSoLuong.Text = selectedrow[4].ToString();
                txtMoTa.Text = selectedrow[5].ToString();
                cbo_TB.SelectedIndex = int.Parse(selectedrow[6].ToString()) - 1;
                cbo_NCC.SelectedIndex = int.Parse(selectedrow[7].ToString()) - 1;
                //txtTinhTrang.Text = row[8].ToString();
                if (selectedrow[8].ToString() == "NEW")
                {
                    rbo_New.Checked = true;
                }
                if (selectedrow[8].ToString() == "99")
                {
                    rbo_99.Checked = true;
                }
                if (selectedrow[8].ToString() == "95")
                {
                    rbo_95.Checked = true;
                }


            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            them = false;
            txtTen.Enabled = true;
            txtGia.Enabled = true;
            txtSoLuong.Enabled = true;
            cbo_NCC.Enabled = true;
            cbo_TB.Enabled = true;
            rbo_New.Enabled = true;
            txtMoTa.ReadOnly = false;
            rbo_New.Enabled = true;
            rbo_99.Enabled = true;
            rbo_95.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool t1=db.checkTonTai("select*from CHITIETDH WHERE MATB="+ txtMa.Text);
            bool t2 = db.checkTonTai("select*from CHITIETDH WHERE MATB=" + txtMa.Text);
            if (t1 == true|| t2 == true)
            {
                MessageBox.Show("Không thể xóa do có đơn hàng/đơn nhập tham chiếu");
            }
            else
            {
                bool xoa = db.ThemXoaSua("DELETE FROM THIETBI WHERE MATB=" + txtMa.Text);
                if (xoa == true)
                {
                    File.Delete(projectPath + @"\HinhAnhSP\" + openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf(@"\") + 1));
                    //!
                    MessageBox.Show("Xóa thành công");
                    hienthi();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tt = "";
            if (rbo_New.Checked)
            {
                tt = "NEW";
            }
            if (rbo_99.Checked)
            {
                tt = "99";
            }
            if (rbo_95.Checked)
            {
                tt = "95";
            }
            if (txtTen.Text == "" || txtGia.Text == "" || txtMoTa.Text == "" || txtSoLuong.Text == "" || cbo_NCC.SelectedIndex == -1 || cbo_TB.SelectedIndex == -1)
            {

                MessageBox.Show("Vui lòng nhập đẩy đủ thông tin");



            }
            else
            {
                int so, so2;
                if (int.TryParse(txtGia.Text, out so) == false || int.TryParse(txtSoLuong.Text, out so2) == false)
                {
                    MessageBox.Show("Vui lòng nhập thông tin hợp lệ");
                }
                else
                {

                    if (them == true)
                    {
                        pictureBox1.Image.Save(projectPath+@"\HinhAnhSP\" + openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf(@"\") + 1), ImageFormat.Jpeg);
                        string sql = String.Format("Insert into THIETBI(TENTB,HINHANH ,GIA,SOLUONG,MOTA,MALOAI,MANCC,TINHTRANG)" +
                            " values(N'{0}','{1}',{2},{3},N'{4}',{5},{6},N'{7}')",
                            txtTen.Text, openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf(@"\") + 1), txtGia.Text, txtSoLuong.Text, txtMoTa.Text, cbo_TB.SelectedValue.ToString(),
                            cbo_NCC.SelectedValue.ToString(), tt);
                        bool kq = db.ThemXoaSua(sql);
                        if (kq == true)
                        {
                            MessageBox.Show("Thêm thành công");
                            txtMa.Visible = true;
                            txtTen.Text = "";
                            txtGia.Text = "";
                            txtSoLuong.Text = "";
                            cbo_NCC.SelectedIndex = -1;
                            cbo_TB.SelectedIndex = -1;
                            rbo_New.Checked = true;
                            txtMoTa.Text = "";
                            txtTen.Enabled = false;
                            txtGia.Enabled = false;
                            txtSoLuong.Enabled = false;
                            cbo_NCC.Enabled = false;
                            cbo_TB.Enabled = false;
                            rbo_New.Enabled = false;
                            txtMoTa.ReadOnly = true;
                            rbo_New.Enabled = false;
                            rbo_99.Enabled = false;
                            rbo_95.Enabled = false;
                            pictureBox1.Image = null;

                            btnThem.Enabled = true;
                            btnSua.Enabled = true;
                            btnXoa.Enabled = true;
                            btnLuu.Enabled = false;
                            btnHuy.Enabled = false;
                            hienthi();
                        }
                        else
                        {
                            MessageBox.Show("Thêm không thành công");
                        }
                    }
                    else
                    {
                        if (openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf(@"\") + 1) == "openFileDialog1")
                        {
                            string sql = String.Format("UPDATE THIETBI " +
                                " SET TENTB=N'{0}',GIA={1},SOLUONG={2},MOTA=N'{3}',MALOAI={4},MANCC={5},TINHTRANG=N'{6}' WHERE MATB={7}",
                                txtTen.Text, txtGia.Text, txtSoLuong.Text, txtMoTa.Text, cbo_TB.SelectedValue.ToString(),
                                cbo_NCC.SelectedValue.ToString(), tt, txtMa.Text);
                            bool kq = db.ThemXoaSua(sql);
                            if (kq == true)
                            {

                                MessageBox.Show("Cập nhật thành công");
                            }
                            hienthi();
                        }
                        else
                        {
                            File.Delete(projectPath + @"\HinhAnhSP\" + openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf(@"\") + 1));
                            pictureBox1.Image.Save(projectPath + @"\HinhAnhSP\" + openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf(@"\") + 1), ImageFormat.Jpeg);
                            
                            string sql = String.Format("UPDATE THIETBI " +
                                " SET TENTB=N'{0}',HINHANH='{1}',GIA={2},SOLUONG={3},MOTA=N'{4}',MALOAI={5},MANCC={6},TINHTRANG=N'{7}' WHERE MATB={8}",
                                txtTen.Text, openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf(@"\") + 1), txtGia.Text, txtSoLuong.Text, txtMoTa.Text, cbo_TB.SelectedValue.ToString(),
                                cbo_NCC.SelectedValue.ToString(), tt, txtMa.Text);
                           bool kq = db.ThemXoaSua(sql);
                            if (kq == true)
                            {


                                MessageBox.Show("Cập nhật thành công");
                            }

                            hienthi();
                        }
                        txtMa.Enabled = true;                      
                        txtTen.Enabled = false;
                        txtGia.Enabled = false;
                        txtSoLuong.Enabled = false;
                        cbo_NCC.Enabled = false;
                        cbo_TB.Enabled = false;
                        rbo_New.Enabled = false;
                        txtMoTa.ReadOnly = true;
                        rbo_New.Enabled = false;
                        rbo_99.Enabled = false;
                        rbo_95.Enabled = false;

                        btnThem.Enabled = true;
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                        btnLuu.Enabled = false;
                        btnHuy.Enabled = false;
                    }
                }
            }

         }

        private void frm_SanPham_Load_1(object sender, EventArgs e)
        {
            hienthi();
            
            
            cboTamGia.Items.Add("DƯỚI 1TR");
            cboTamGia.Items.Add("1TR-4TR");
            cboTamGia.Items.Add("4TR-7TR");
            cboTamGia.Items.Add("TRÊN 7TR");
            cboTamGia.SelectedIndex = -1;

            SetComboBoxHeight(cbo_Loai_TimKiem.Handle, 34);
            SetComboBoxHeight(cbo_NCC_TimKiem.Handle, 34);
            cbo_NCC_TimKiem.Refresh();
            SetComboBoxHeight(cboTamGia.Handle, 36);
            cboTamGia.Refresh();
            
        }
        public void hienthi()
        {
            
            listView1.Clear();
            listView1.Columns.Add("Mã TB");
            listView1.Columns.Add("Tên TB");
            listView1.Columns.Add("Gía TB");
            listView1.Columns[0].Width=60;
            listView1.Columns[1].Width =200;
            listView1.Columns[2].Width = 148;
            dtSanPham = db.LayDLDataTable("Select*from THIETBI");
            dtNCC = db.LayDLDataTable("Select*from NHACC");
            dtLoai = db.LayDLDataTable("Select*from LOAITB");
            keytb[0] = dtSanPham.Columns[0];
            dtSanPham.PrimaryKey = keytb;
            cbo_NCC.DataSource = dtNCC;
            cbo_NCC.DisplayMember = "TENNCC";
            cbo_NCC.ValueMember = "MANCC";
            cbo_TB.DataSource = dtLoai;
            cbo_TB.DisplayMember = "TENLOAI";
            cbo_TB.ValueMember = "MALOAI";
            cbo_NCC.SelectedIndex = -1;
            cbo_TB.SelectedIndex = -1;
           
            foreach(DataRow row in dtLoai.Rows)
            {
                cbo_Loai_TimKiem.Items.Add(row[1].ToString());
            }
            foreach (DataRow row in dtNCC.Rows)
            {
                cbo_NCC_TimKiem.Items.Add(row[1].ToString());
            }
            cbo_NCC_TimKiem.SelectedIndex = -1;
            cbo_Loai_TimKiem.SelectedIndex = -1;
            cboTamGia.SelectedIndex = -1;
            cbo_NCC_TimKiem.Text="TẤT CẢ";
            cbo_Loai_TimKiem.Text = "TẤT CẢ";
            cboTamGia.Text = "TẤT CẢ";
            foreach (DataRow row in dtSanPham.Rows)
            {
                ListViewItem lvi = listView1.Items.Add(row[0].ToString());
                lvi.SubItems.Add(row[1].ToString());
                lvi.SubItems.Add(row[3].ToString().Substring(0, row[3].ToString().LastIndexOf('.')));
            }
        }
        private void btnAnh_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All text files(*.jpg)|*.jpg|All rich text files(*.png)|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                 pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                 resizeAnh(pictureBox1.Image, new Size(150, 150));
                    
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (them == true)
            {
                txtMa.Visible = true;
                txtTen.Text = "";
                txtGia.Text = "";
                txtSoLuong.Text = "";
                cbo_NCC.SelectedIndex = -1;
                cbo_TB.SelectedIndex = -1;
                rbo_New.Checked = true;
                txtMoTa.Text = "";
                txtTen.Enabled = false;
                txtGia.Enabled = false;
                txtSoLuong.Enabled = false;
                cbo_NCC.Enabled = false;
                cbo_TB.Enabled = false;
                rbo_New.Enabled = false;
                txtMoTa.ReadOnly = true;
                rbo_New.Enabled = false;
                rbo_99.Enabled = false;
                rbo_95.Enabled = false;
                pictureBox1.Image = null;

                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
            }
            else
            {
                txtMa.Enabled = true;
                txtTen.Enabled = false;
                txtGia.Enabled = false;
                txtSoLuong.Enabled = false;
                cbo_NCC.Enabled = false;
                cbo_TB.Enabled = false;
                rbo_New.Enabled = false;
                txtMoTa.ReadOnly = true;
                rbo_New.Enabled = false;
                rbo_99.Enabled = false;
                rbo_95.Enabled = false;

                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
            }
        }

        private void cbo_Loai_TimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                listView1.Clear();
                listView1.Columns.Add("Mã TB");
                listView1.Columns.Add("Tên TB");
                listView1.Columns.Add("Gía TB");
                listView1.Columns[0].Width = 60;
                listView1.Columns[1].Width = 200;
                listView1.Columns[2].Width = 148;
                //===



                string sql = "Select*from THIETBI  where MATB=-1";
                if (cbo_NCC_TimKiem.SelectedIndex != -1 && cbo_Loai_TimKiem.SelectedIndex != -1 && cboTamGia.SelectedIndex != -1)
                {
                    if (cboTamGia.Text == "DƯỚI 1TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, NHACC.MANCC,TINHTRANG from THIETBI ,NHACC,LOAITB where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                    "' and THIETBI.MANCC=NHACC.MANCC and LOAITB.MALOAI=THIETBI.MALOAI AND TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' AND GIA <1000000";
                    }
                    else if (cboTamGia.Text == "1TR-4TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA,THIETBI.MALOAI, NHACC.MANCC,TINHTRANG from THIETBI ,NHACC,LOAITB where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                    "' and THIETBI.MANCC=NHACC.MANCC and LOAITB.MALOAI=THIETBI.MALOAI AND TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' AND GIA  BETWEEN 1000001 AND 4000000";
                    }
                    else if (cboTamGia.Text == "4TR-7TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA,THIETBI.MALOAI, NHACC.MANCC,TINHTRANG from THIETBI ,NHACC,LOAITB where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                    "' and THIETBI.MANCC=NHACC.MANCC and LOAITB.MALOAI=THIETBI.MALOAI AND TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' AND GIA  BETWEEN 4000001 AND 7000000";
                    }
                    else
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA,THIETBI.MALOAI, NHACC.MANCC,TINHTRANG from THIETBI ,NHACC,LOAITB where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                    "' and THIETBI.MANCC=NHACC.MANCC and LOAITB.MALOAI=THIETBI.MALOAI AND TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' AND GIA>7000000";
                    }
                    //=========================================
                }
                else if (cbo_NCC_TimKiem.SelectedIndex != -1 && cboTamGia.SelectedIndex != -1)
                {
                    if (cboTamGia.Text == "DƯỚI 1TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,NHACC where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                    "' and THIETBI.MANCC=NHACC.MANCC " +
                    " AND GIA <1000000";
                    }
                    else if (cboTamGia.Text == "1TR-4TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,NHACC where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                        "' and THIETBI.MANCC=NHACC.MANCC " +
                        " AND GIA  BETWEEN 1000001 AND 4000000";
                    }
                    else if (cboTamGia.Text == "4TR - 7TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,NHACC where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                        "' and THIETBI.MANCC=NHACC.MANCC " +
                        " AND GIA  BETWEEN 4000001 AND 7000000";
                    }
                    else
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,NHACC where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                        "' and THIETBI.MANCC=NHACC.MANCC " +
                        " AND GIA>7000000";
                    }
                    //=======================================
                }
                else if (cbo_Loai_TimKiem.SelectedIndex != -1 && cboTamGia.SelectedIndex != -1)
                {
                    if (cboTamGia.Text == "DƯỚI 1TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,LOAITB where TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' and THIETBI.MALOAI=LOAITB.MALOAI " +
                    " AND GIA <1000000";
                    }
                    else if (cboTamGia.Text == "1TR-4TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,LOAITB where TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' and THIETBI.MALOAI=LOAITB.MALOAI " +
                        " AND GIA BETWEEN 1000001 AND 4000000";
                    }
                    else if (cboTamGia.Text == "4TR - 7TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,LOAITB where TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' and THIETBI.MALOAI=LOAITB.MALOAI " +
                        " AND GIA BETWEEN 4000001 AND 7000000";
                    }
                    else
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,LOAITB where TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' and THIETBI.MALOAI=LOAITB.MALOAI " +
                        " AND GIA >7000000";
                    }
                }
                else if (cbo_NCC_TimKiem.SelectedIndex != -1 && cbo_Loai_TimKiem.SelectedIndex != -1)
                {
                    sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,NHACC,LOAITB where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                        "' and THIETBI.MANCC=NHACC.MANCC and LOAITB.MALOAI=THIETBI.MALOAI AND TENLOAI=N'" + cbo_Loai_TimKiem.Text + "'";

                }
                else if (cbo_NCC_TimKiem.SelectedIndex != -1)
                {
                    sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,NHACC where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                    "' and THIETBI.MANCC=NHACC.MANCC";
                }
                else if (cbo_Loai_TimKiem.SelectedIndex != -1)
                {
                    sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,LOAITB where TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' and THIETBI.MALOAI=LOAITB.MALOAI";
                }
                else if (cboTamGia.SelectedIndex != -1)
                {
                    if (cboTamGia.Text == "DƯỚI 1TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI where  GIA<1000000";
                    }
                    else if (cboTamGia.Text == "1TR-4TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI where  GIA BETWEEN  1000001 AND 4000000";
                    }
                    else if (cboTamGia.Text == "4TR - 7TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI where  GIA BETWEEN  4000001 AND 7000000";
                    }
                    else
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI where  GIA >7000000";
                    }
                }
                dtSanPham = db.LayDLDataTable(sql);
                keytb[0] = dtSanPham.Columns[0];
                dtSanPham.PrimaryKey = keytb;
                foreach (DataRow row in dtSanPham.Rows)
                {
                    ListViewItem lvi = listView1.Items.Add(row[0].ToString());
                    lvi.SubItems.Add(row[1].ToString());
                    lvi.SubItems.Add(row[3].ToString().Substring(0, row[3].ToString().LastIndexOf('.')));
                }
            
        }
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }

       
            
        

        private void cbo_Loai_TimKiem_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            
        }
        
        private void btnSXTang_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count-1; i++)
            {
                
                for (int j = i+1; j < listView1.Items.Count ; j++)
                {

                    if (Double.Parse(listView1.Items[i].SubItems[2].Text) > Double.Parse(listView1.Items[j].SubItems[2].Text))
                    {

                        string a = listView1.Items[i].SubItems[0].Text;
                        string b = listView1.Items[i].SubItems[1].Text;
                        string c = listView1.Items[i].SubItems[2].Text;
                        listView1.Items[i].SubItems[0].Text = listView1.Items[j].SubItems[0].Text;
                        listView1.Items[i].SubItems[1].Text = listView1.Items[j].SubItems[1].Text;
                        listView1.Items[i].SubItems[2].Text = listView1.Items[j].SubItems[2].Text;
                        listView1.Items[j].SubItems[0].Text = a;
                        listView1.Items[j].SubItems[1].Text = b;
                        listView1.Items[j].SubItems[2].Text = c;
                    }
                }
            }
        }

        private void btnSXGiam_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count - 1; i++)
            {

                for (int j = i + 1; j < listView1.Items.Count; j++)
                {

                    if (Double.Parse(listView1.Items[i].SubItems[2].Text) < Double.Parse(listView1.Items[j].SubItems[2].Text))
                    {

                        string a = listView1.Items[i].SubItems[0].Text;
                        string b = listView1.Items[i].SubItems[1].Text;
                        string c = listView1.Items[i].SubItems[2].Text;
                        listView1.Items[i].SubItems[0].Text = listView1.Items[j].SubItems[0].Text;
                        listView1.Items[i].SubItems[1].Text = listView1.Items[j].SubItems[1].Text;
                        listView1.Items[i].SubItems[2].Text = listView1.Items[j].SubItems[2].Text;
                        listView1.Items[j].SubItems[0].Text = a;
                        listView1.Items[j].SubItems[1].Text = b;
                        listView1.Items[j].SubItems[2].Text = c;
                    }
                }
            }
        }

        private void cbo_NCC_TimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                listView1.Clear();
                listView1.Columns.Add("Mã TB");
                listView1.Columns.Add("Tên TB");
                listView1.Columns.Add("Gía TB");
                listView1.Columns[0].Width = 60;
                listView1.Columns[1].Width = 200;
                listView1.Columns[2].Width = 148;
                //===
               
               
             
                string sql= "Select*from THIETBI  where MATB=-1";
                if (cbo_NCC_TimKiem.SelectedIndex != -1 && cbo_Loai_TimKiem.SelectedIndex != -1 && cboTamGia.SelectedIndex != -1)
                {
                    if(cboTamGia.Text== "DƯỚI 1TR")
                    {
                            sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, NHACC.MANCC,TINHTRANG from THIETBI ,NHACC,LOAITB where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                        "' and THIETBI.MANCC=NHACC.MANCC and LOAITB.MALOAI=THIETBI.MALOAI AND TENLOAI=N'"+cbo_Loai_TimKiem.Text+
                        "' AND GIA <1000000";
                    }
                    else if(cboTamGia.Text== "1TR-4TR")
                    {
                            sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA,THIETBI.MALOAI, NHACC.MANCC,TINHTRANG from THIETBI ,NHACC,LOAITB where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                        "' and THIETBI.MANCC=NHACC.MANCC and LOAITB.MALOAI=THIETBI.MALOAI AND TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                        "' AND GIA  BETWEEN 1000001 AND 4000000";
                    }
                    else if(cboTamGia.Text == "4TR-7TR")
                    {
                            sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA,THIETBI.MALOAI, NHACC.MANCC,TINHTRANG from THIETBI ,NHACC,LOAITB where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                        "' and THIETBI.MANCC=NHACC.MANCC and LOAITB.MALOAI=THIETBI.MALOAI AND TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                        "' AND GIA  BETWEEN 4000001 AND 7000000";
                    }
                    else
                    {
                            sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA,THIETBI.MALOAI, NHACC.MANCC,TINHTRANG from THIETBI ,NHACC,LOAITB where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                        "' and THIETBI.MANCC=NHACC.MANCC and LOAITB.MALOAI=THIETBI.MALOAI AND TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                        "' AND GIA>7000000";
                    }
                    //=========================================
                }
                else if(cbo_NCC_TimKiem.SelectedIndex != -1 && cboTamGia.SelectedIndex != -1)
                {
                    if (cboTamGia.Text == "DƯỚI 1TR")
                    {
                            sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,NHACC where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                        "' and THIETBI.MANCC=NHACC.MANCC "+
                        " AND GIA <1000000";
                    }
                    else if(cboTamGia.Text == "1TR-4TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,NHACC where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                        "' and THIETBI.MANCC=NHACC.MANCC " +
                        " AND GIA  BETWEEN 1000001 AND 4000000";
                    }
                    else if(cboTamGia.Text == "4TR - 7TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,NHACC where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                        "' and THIETBI.MANCC=NHACC.MANCC " +
                        " AND GIA  BETWEEN 4000001 AND 7000000";
                    }
                    else
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,NHACC where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                        "' and THIETBI.MANCC=NHACC.MANCC " +
                        " AND GIA>7000000";
                    }
                    //=======================================
                }
                else if(cbo_Loai_TimKiem.SelectedIndex != -1 && cboTamGia.SelectedIndex != -1)
                {
                    if (cboTamGia.Text == "DƯỚI 1TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,LOAITB where TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' and THIETBI.MALOAI=LOAITB.MALOAI " +
                    " AND GIA <1000000";
                    }
                    else if (cboTamGia.Text == "1TR-4TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,LOAITB where TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' and THIETBI.MALOAI=LOAITB.MALOAI " +
                        " AND GIA BETWEEN 1000001 AND 4000000";
                    }
                    else if (cboTamGia.Text == "4TR - 7TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,LOAITB where TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' and THIETBI.MALOAI=LOAITB.MALOAI " +
                        " AND GIA BETWEEN 4000001 AND 7000000";
                    }
                    else
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,LOAITB where TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' and THIETBI.MALOAI=LOAITB.MALOAI " +
                        " AND GIA >7000000";
                    }
                }
                else if(cbo_NCC_TimKiem.SelectedIndex != -1 && cbo_Loai_TimKiem.SelectedIndex != -1)
                {
                    sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,NHACC,LOAITB where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                        "' and THIETBI.MANCC=NHACC.MANCC and LOAITB.MALOAI=THIETBI.MALOAI AND TENLOAI=N'" + cbo_Loai_TimKiem.Text+"'";
                        
                }
                else if(cbo_NCC_TimKiem.SelectedIndex != -1)
                {
                    sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,NHACC where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                    "' and THIETBI.MANCC=NHACC.MANCC";
                }
                else if (cbo_Loai_TimKiem.SelectedIndex != -1)
                {
                    sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,LOAITB where TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' and THIETBI.MALOAI=LOAITB.MALOAI";
                }
                else if (cboTamGia.SelectedIndex != -1)
                {
                    if (cboTamGia.Text == "DƯỚI 1TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI where  GIA<1000000";
                    }
                    else if (cboTamGia.Text == "1TR-4TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI where  GIA BETWEEN  1000001 AND 4000000";
                    }
                    else if (cboTamGia.Text == "4TR - 7TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI where  GIA BETWEEN  4000001 AND 7000000";
                    }
                    else
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI where  GIA >7000000";
                    }
                }
                dtSanPham = db.LayDLDataTable(sql);
                keytb[0] = dtSanPham.Columns[0];
                dtSanPham.PrimaryKey = keytb;
                foreach (DataRow row in dtSanPham.Rows)
                {
                    ListViewItem lvi = listView1.Items.Add(row[0].ToString());
                    lvi.SubItems.Add(row[1].ToString());
                    lvi.SubItems.Add(row[3].ToString().Substring(0, row[3].ToString().LastIndexOf('.')));
                }
            
        }

        private void cboTamGia_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                listView1.Clear();
                listView1.Columns.Add("Mã TB");
                listView1.Columns.Add("Tên TB");
                listView1.Columns.Add("Gía TB");
                listView1.Columns[0].Width = 60;
                listView1.Columns[1].Width = 200;
                listView1.Columns[2].Width = 148;
                //===



                string sql = "Select*from THIETBI where MATB=-1";
                if (cbo_NCC_TimKiem.SelectedIndex != -1 && cbo_Loai_TimKiem.SelectedIndex != -1 && cboTamGia.SelectedIndex != -1)
                {
                    if (cboTamGia.Text == "DƯỚI 1TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, NHACC.MANCC,TINHTRANG from THIETBI ,NHACC,LOAITB where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                    "' and THIETBI.MANCC=NHACC.MANCC and LOAITB.MALOAI=THIETBI.MALOAI AND TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' AND GIA <1000000";
                    }
                    else if (cboTamGia.Text == "1TR-4TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA,THIETBI.MALOAI, NHACC.MANCC,TINHTRANG from THIETBI ,NHACC,LOAITB where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                    "' and THIETBI.MANCC=NHACC.MANCC and LOAITB.MALOAI=THIETBI.MALOAI AND TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' AND GIA  BETWEEN 1000001 AND 4000000";
                    }
                    else if (cboTamGia.Text == "4TR-7TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA,THIETBI.MALOAI, NHACC.MANCC,TINHTRANG from THIETBI ,NHACC,LOAITB where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                    "' and THIETBI.MANCC=NHACC.MANCC and LOAITB.MALOAI=THIETBI.MALOAI AND TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' AND GIA  BETWEEN 4000001 AND 7000000";
                    }
                    else
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA,THIETBI.MALOAI, NHACC.MANCC,TINHTRANG from THIETBI ,NHACC,LOAITB where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                    "' and THIETBI.MANCC=NHACC.MANCC and LOAITB.MALOAI=THIETBI.MALOAI AND TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' AND GIA>7000000";
                    }
                    //=========================================
                }
                else if (cbo_NCC_TimKiem.SelectedIndex != -1 && cboTamGia.SelectedIndex != -1)
                {
                    if (cboTamGia.Text == "DƯỚI 1TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,NHACC where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                    "' and THIETBI.MANCC=NHACC.MANCC " +
                    " AND GIA <1000000";
                    }
                    else if (cboTamGia.Text == "1TR-4TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,NHACC where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                        "' and THIETBI.MANCC=NHACC.MANCC " +
                        " AND GIA  BETWEEN 1000001 AND 4000000";
                    }
                    else if (cboTamGia.Text == "4TR - 7TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,NHACC where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                        "' and THIETBI.MANCC=NHACC.MANCC " +
                        " AND GIA  BETWEEN 4000001 AND 7000000";
                    }
                    else
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,NHACC where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                        "' and THIETBI.MANCC=NHACC.MANCC " +
                        " AND GIA>7000000";
                    }
                    //=======================================
                }
                else if (cbo_Loai_TimKiem.SelectedIndex != -1 && cboTamGia.SelectedIndex != -1)
                {
                    if (cboTamGia.Text == "DƯỚI 1TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,LOAITB where TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' and THIETBI.MALOAI=LOAITB.MALOAI " +
                    " AND GIA <1000000";
                    }
                    else if (cboTamGia.Text == "1TR-4TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,LOAITB where TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' and THIETBI.MALOAI=LOAITB.MALOAI " +
                        " AND GIA BETWEEN 1000001 AND 4000000";
                    }
                    else if (cboTamGia.Text == "4TR - 7TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,LOAITB where TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' and THIETBI.MALOAI=LOAITB.MALOAI " +
                        " AND GIA BETWEEN 4000001 AND 7000000";
                    }
                    else
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,LOAITB where TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' and THIETBI.MALOAI=LOAITB.MALOAI " +
                        " AND GIA >7000000";
                    }
                }
                else if (cbo_NCC_TimKiem.SelectedIndex != -1 && cbo_Loai_TimKiem.SelectedIndex != -1)
                {
                    sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,NHACC,LOAITB where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                        "' and THIETBI.MANCC=NHACC.MANCC and LOAITB.MALOAI=THIETBI.MALOAI AND TENLOAI=N'" + cbo_Loai_TimKiem.Text + "'";

                }
                else if (cbo_NCC_TimKiem.SelectedIndex != -1)
                {
                    sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,NHACC where TENNCC=N'" + cbo_NCC_TimKiem.Text +
                    "' and THIETBI.MANCC=NHACC.MANCC";
                }
                else if (cbo_Loai_TimKiem.SelectedIndex != -1)
                {
                    sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI ,LOAITB where TENLOAI=N'" + cbo_Loai_TimKiem.Text +
                    "' and THIETBI.MALOAI=LOAITB.MALOAI";
                }
                else if (cboTamGia.SelectedIndex != -1)
                {
                    if (cboTamGia.Text == "DƯỚI 1TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI where  GIA<1000000";
                    }
                    else if (cboTamGia.Text == "1TR-4TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI where  GIA BETWEEN  1000001 AND 4000000";
                    }
                    else if (cboTamGia.Text == "4TR - 7TR")
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI where  GIA BETWEEN  4000001 AND 7000000";
                    }
                    else
                    {
                        sql = "Select THIETBI.MATB,TENTB,HINHANH,GIA,SOLUONG,MOTA, THIETBI.MALOAI, THIETBI.MANCC,TINHTRANG from THIETBI where  GIA >7000000";
                    }
                }
                dtSanPham = db.LayDLDataTable(sql);
                keytb[0] = dtSanPham.Columns[0];
                dtSanPham.PrimaryKey = keytb;
                foreach (DataRow row in dtSanPham.Rows)
                {
                    ListViewItem lvi = listView1.Items.Add(row[0].ToString());
                    lvi.SubItems.Add(row[1].ToString());
                    lvi.SubItems.Add(row[3].ToString().Substring(0, row[3].ToString().LastIndexOf('.')));
                }
            
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql = "select* from THIETBI";
            listView1.Clear();
            listView1.Columns.Add("Mã TB");
            listView1.Columns.Add("Tên TB");
            listView1.Columns.Add("Gía TB");
            listView1.Columns[0].Width = 60;
            listView1.Columns[1].Width = 200;
            listView1.Columns[2].Width = 148;
            cbo_Loai_TimKiem.SelectedIndex = -1;
            cbo_NCC_TimKiem.SelectedIndex = -1;
            cboTamGia.SelectedIndex = -1;
            cboTamGia.Text = "TẤT CẢ";
            cbo_Loai_TimKiem.Text = "TẤT CẢ";
            cbo_NCC_TimKiem.Text = "TẤT CẢ";
            if (txtTimKiem.Text == "")
            {
                //sql = "select* from THIETBI";
            }
            else
            {
                sql = "select* from THIETBI where TENTB like N'%"+txtTimKiem.Text+"%'";
            }
            
            dtSanPham = db.LayDLDataTable(sql);
            keytb[0] = dtSanPham.Columns[0];
            dtSanPham.PrimaryKey = keytb;
            foreach (DataRow row in dtSanPham.Rows)
            {
                ListViewItem lvi = listView1.Items.Add(row[0].ToString());
                lvi.SubItems.Add(row[1].ToString());
                lvi.SubItems.Add(row[3].ToString().Substring(0, row[3].ToString().LastIndexOf('.')));
            }
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnIN_Click(object sender, EventArgs e)
        {
            //DataTable dtSanPham_Loai_NCC = db.LayDLDataTable("select*from SANPHAM");
            //new FormBaoCao("SANPHAM", dtSanPham_Loai_NCC).Show();
            new FormBaoCao("SANPHAM", dtSanPham).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void frm_SanPham_Load(object sender, EventArgs e)
        {
            
        }
    }
}
