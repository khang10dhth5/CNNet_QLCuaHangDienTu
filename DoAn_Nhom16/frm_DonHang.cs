﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace DoAn_Nhom16
{
    public partial class frm_DonHang : Form
    {
        XuLyDB db = new XuLyDB();
        DataTable dtDonHang, dtTB, dtNV, dtKH, dtChiTietDH;
        DataColumn[] keydon = new DataColumn[1];
        bool them = false;
        public frm_DonHang()
        {
            InitializeComponent();
        }
        string manv;
        public frm_DonHang(string s)
        {
            InitializeComponent();
            manv = s;
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool xoa = db.ThemXoaSua("DELETE FROM CHITIETDH WHERE MADH=" + txtMa.Text + " AND MATB=" + listView1.SelectedItems[0].SubItems[0].Text);
            if (xoa == true)
            {
                MessageBox.Show("Xóa thành công");
                hienthi2();
            }
            else
            {
                MessageBox.Show("Xóa không thành công");
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {




        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            



        }
       
        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            txtSoLuong.Enabled = true;
            txtGia.Enabled = true;
            cboThietBi.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
             them = false;
            txtSoLuong.Enabled = true;
            txtGia.Enabled = true;
        
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {


            if (them == true)
            {
                bool t2 = db.checkTonTai("select*from CHITIETDH WHERE MADH=" + txtMa.Text + " AND MATB=" + cboThietBi.SelectedValue.ToString());
                if (t2 == true)
                {
                    MessageBox.Show("Không thể thêm do đơn hàng đã có sẳn sản phẩm");
                }
                else
                {
                    int so1, so2;
                    if (int.TryParse(txtSoLuong.Text, out so1) == false || int.TryParse(txtGia.Text, out so2) == false)
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin và nhập thông tin hợp lệ");
                    }
                    else
                    {
                        String sl = "";
                        DataTable dtSOTB = db.LayDLDataTable("select*from THIETBI WHERE MATB=" + cboThietBi.SelectedValue.ToString());
                        foreach (DataRow row in dtSOTB.Rows)
                        {

                            sl = row[4].ToString();
                        }
                        if (Double.Parse(txtSoLuong.Text) > Double.Parse(sl))
                        {
                            MessageBox.Show("Vượt quá số lượng tồn kho");
                        }
                        else
                        {
                            string sql = String.Format(" INSERT INTO CHITIETDH(MADH,MATB,SOLUONG,GIABAN)" +
                       " VALUES({0},{1},{2},{3})",
                        txtMa.Text, cboThietBi.SelectedValue.ToString(), txtSoLuong.Text, txtGia.Text);
                            bool kq = db.ThemXoaSua(sql);
                            if (kq == true)
                            {
                                MessageBox.Show("Thêm thành công");

                                hienthi2();
                                btnThem.Enabled = true;
                                btnSua.Enabled = true;
                                btnXoa.Enabled = true;
                                btnLuu.Enabled = false;
                                btnHuy.Enabled = false;
                                cboThietBi.Enabled = false;
                                txtSoLuong.Enabled = false;
                                txtGia.Enabled = false;
                            }
                        }



                    }
                }
            }
            else
            {

                int so1, so2;
                if (int.TryParse(txtSoLuong.Text, out so1) == false || int.TryParse(txtGia.Text, out so2) == false)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin và nhập thông tin hợp lệ");
                }
                else
                {
                    String sl = "";
                    DataTable dtSOTB = db.LayDLDataTable("select*from THIETBI WHERE MATB=" + txtMaTB.Text);
                    foreach (DataRow row in dtSOTB.Rows)
                    {

                        sl = row[4].ToString();
                    }
                    if (Double.Parse(txtSoLuong.Text) > Double.Parse(sl))
                    {
                        MessageBox.Show("Vượt quá số lượng tồn kho");
                    }
                    else
                    {
                        string sql = String.Format(" UPDATE CHITIETDH SET SOLUONG={0},GIABAN={1} WHERE MADH={2} AND MATB={3}",
                         txtSoLuong.Text, txtGia.Text, txtMa.Text, txtMaTB.Text);
                        bool kq = db.ThemXoaSua(sql);
                        if (kq == true)
                        {
                            MessageBox.Show("Cập Nhật thành công");

                            hienthi2();
                            btnThem.Enabled = true;
                            btnSua.Enabled = true;
                            btnXoa.Enabled = true;
                            btnLuu.Enabled = false;
                            btnHuy.Enabled = false;
                            cboThietBi.Enabled = false;
                            txtSoLuong.Enabled = false;
                            txtGia.Enabled = false;
                        }

                    }
                }

            }
        }
        void hienthi2()
        {
            listView1.Clear();
            listView1.Columns.Add("Mã TB");
            listView1.Columns.Add("Thiết Bị");
            listView1.Columns.Add("Số Lượng");
            listView1.Columns.Add("Gía Bán");
            listView1.Columns.Add("Thành Tiền");
            listView1.Columns[0].Width = 60;
            listView1.Columns[1].Width = 150;
            listView1.Columns[2].Width = 60;
            listView1.Columns[3].Width = 60;
            listView1.Columns[4].Width = 80;
            listBox1.Items.Clear();
            txtMa.Text = listView2.SelectedItems[0].SubItems[0].Text;
            txtNgayLap.Text = listView2.SelectedItems[0].SubItems[3].Text;
            DataTable dtTam = db.LayDLDataTable("select*from DONHANG where MADH=" + txtMa.Text);
            foreach (DataRow row in dtTam.Rows)
            {
                cbo_KH.SelectedIndex = int.Parse(row[1].ToString()) - 1;
                cbo_NV.SelectedIndex = int.Parse(row[2].ToString()) - 1;
                txtTongTien.Text = row[4].ToString();
                cbo_HinhThucTT.SelectedItem = row[5].ToString();
                cbo_TinhTrang.SelectedItem = row[6].ToString();

            }
            DataTable dtCTTam = db.LayDLDataTable("select*from CHITIETDH where MADH=" + txtMa.Text);
            foreach (DataRow row in dtCTTam.Rows)
            {

                DataTable dtTBTam = db.LayDLDataTable("select * FROM THIETBI WHERE MATB=" + row[1].ToString());
                ListViewItem lvi = new ListViewItem();
                foreach (DataRow row1 in dtTBTam.Rows)
                {
                    lvi = listView1.Items.Add(row1[0].ToString());

                    listBox1.Items.Add(row1[1].ToString());
                    lvi.SubItems.Add(row1[1].ToString());
                }
                lvi.SubItems.Add(row[2].ToString());
                lvi.SubItems.Add(row[3].ToString().Substring(0, row[3].ToString().LastIndexOf('.')));
                lvi.SubItems.Add(row[4].ToString().Substring(0, row[4].ToString().LastIndexOf('.')));


            }
        }
        private void btnThemDH_Click(object sender, EventArgs e)
        {

            them = true;
            cbo_KH.Enabled = true;
            cbo_NV.SelectedIndex = int.Parse(manv) - 1;
            cbo_HinhThucTT.Enabled = true;
            cbo_TinhTrang.Enabled = true;
            txtGhiChu.Enabled = true;
            listBox1.Items.Clear();
            txtMa.Visible = false;
            cbo_KH.SelectedIndex = -1;
            txtTongTien.Text = "";
            txtNgayLap.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
            cbo_HinhThucTT.SelectedIndex = -1;
            cbo_TinhTrang.SelectedIndex = -1;
            txtSoLuong.Text = "";
            txtGia.Text = "";
            btnThemDH.Enabled = false;
            btnSuaDH.Enabled = false;
            btnXoaDH.Enabled = false;
            btnLuuDH.Enabled = true;
            btnHuyDH.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                listView1.Clear();
                listView1.Columns.Add("Mã TB");
                listView1.Columns.Add("Thiết Bị");
                listView1.Columns.Add("Số Lượng");
                listView1.Columns.Add("Gía Bán");
                listView1.Columns.Add("Thành Tiền");
                listView1.Columns[0].Width = 60;
                listView1.Columns[1].Width = 150;
                listView1.Columns[2].Width = 60;
                listView1.Columns[3].Width = 60;
                listView1.Columns[4].Width = 80;
                listBox1.Items.Clear();
                txtMa.Text = listView2.SelectedItems[0].SubItems[0].Text;
                txtNgayLap.Text = listView2.SelectedItems[0].SubItems[3].Text;
                DataTable dtTam = db.LayDLDataTable("select*from DONHANG where MADH=" + txtMa.Text);
                foreach (DataRow row in dtTam.Rows)
                {
                    cbo_KH.SelectedIndex = int.Parse(row[1].ToString()) - 1;
                    cbo_NV.SelectedIndex = int.Parse(row[2].ToString()) - 1;
                    txtTongTien.Text = row[4].ToString();
                    cbo_HinhThucTT.SelectedItem = row[5].ToString();
                    cbo_TinhTrang.SelectedItem = row[6].ToString();

                }
                DataTable dtCTTam = db.LayDLDataTable("select*from CHITIETDH where MADH=" + txtMa.Text);
                foreach (DataRow row in dtCTTam.Rows)
                {

                    DataTable dtTBTam = db.LayDLDataTable("select * FROM THIETBI WHERE MATB=" + row[1].ToString());
                    ListViewItem lvi = new ListViewItem();
                    foreach (DataRow row1 in dtTBTam.Rows)
                    {
                        lvi = listView1.Items.Add(row1[0].ToString());

                        listBox1.Items.Add(row1[1].ToString());
                        lvi.SubItems.Add(row1[1].ToString());
                    }
                    lvi.SubItems.Add(row[2].ToString());
                    lvi.SubItems.Add(row[3].ToString().Substring(0, row[3].ToString().LastIndexOf('.')));
                    lvi.SubItems.Add(row[4].ToString().Substring(0, row[4].ToString().LastIndexOf('.')));


                }

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            if (listView1.SelectedItems.Count > 0)
            {
                txtMaTB.Text = listView1.SelectedItems[0].SubItems[0].Text;
                DataTable dtSPTam = db.LayDLDataTable("select*from THIETBI WHERE MATB=" + txtMaTB.Text);
                DataTable dtCTDHTam = db.LayDLDataTable("select*from CHITIETDH WHERE MATB=" + txtMaTB.Text+" AND MADH="+txtMa.Text);
                foreach (DataRow row in dtSPTam.Rows)
                {
                    txtTenTB.Text = row[1].ToString();
                    pictureBox1.Image = Image.FromFile(projectPath + "\\HinhAnhSP\\" + row[2].ToString());
                    txtGiaTB.Text = row[3].ToString().Substring(0, row[3].ToString().LastIndexOf('.'));
                    txtSL.Text = row[4].ToString();
                    txtMoTa.Text = row[5].ToString();
                    
                    //txtTinhTrang.Text = row[8].ToString();
                }
                foreach (DataRow row in dtCTDHTam.Rows)
                {
                    txtGia.Text = row[3].ToString().Substring(0, row[3].ToString().LastIndexOf('.'));
                    txtSoLuong.Text = row[2].ToString();
                    //txtTinhTrang.Text = row[8].ToString();
                }
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSuaDH_Click(object sender, EventArgs e)
        {
            them = false;
            cbo_KH.Enabled = true;
            cbo_NV.SelectedIndex = int.Parse(manv) - 1;
            cbo_HinhThucTT.Enabled = true;
            cbo_TinhTrang.Enabled = true;
            txtGhiChu.Enabled = true;
            btnThemDH.Enabled = false;
            btnSuaDH.Enabled = false;
            btnXoaDH.Enabled = false;
            btnLuuDH.Enabled = true;
            btnHuyDH.Enabled = true;
        }

        private void btnXoaDH_Click(object sender, EventArgs e)
        {
            bool t2 = db.checkTonTai("select*from CHITIETDH WHERE MADH=" + txtMa.Text);
            if ( t2 == true)
            {
                MessageBox.Show("Không thể xóa do có chi tiết đơn hàng tham chiếu");
            }
            else
            {
                bool xoa = db.ThemXoaSua("DELETE FROM DONHANG WHERE MADH=" + txtMa.Text);
                if (xoa == true)
                {
                    MessageBox.Show("Xóa thành công");
                    hienthi();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
        }

        private void btnHuyDH_Click(object sender, EventArgs e)
        {
            
               
                cbo_KH.Enabled = false;
                cbo_NV.SelectedIndex = -1;
                cbo_HinhThucTT.Enabled = false;
                cbo_TinhTrang.Enabled = false;
                txtGhiChu.Enabled = false;
                btnThemDH.Enabled = true;
                btnSuaDH.Enabled = true;
                btnXoaDH.Enabled = true;
                btnLuuDH.Enabled = false;
                btnHuyDH.Enabled = false;
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtSoLuong.Enabled = false;
            txtGia.Enabled = false;
            cboThietBi.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void btnSXTang_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView2.Items.Count - 1; i++)
            {

                for (int j = i + 1; j < listView2.Items.Count; j++)
                {

                    if (Double.Parse(listView2.Items[i].SubItems[4].Text) > Double.Parse(listView2.Items[j].SubItems[4].Text))
                    {

                        string a = listView2.Items[i].SubItems[0].Text;
                        string b = listView2.Items[i].SubItems[1].Text;
                        string c = listView2.Items[i].SubItems[2].Text;
                        string d = listView2.Items[i].SubItems[3].Text;
                        string x = listView2.Items[i].SubItems[4].Text;
                        listView2.Items[i].SubItems[0].Text = listView2.Items[j].SubItems[0].Text;
                        listView2.Items[i].SubItems[1].Text = listView2.Items[j].SubItems[1].Text;
                        listView2.Items[i].SubItems[2].Text = listView2.Items[j].SubItems[2].Text;
                        listView2.Items[i].SubItems[3].Text = listView2.Items[j].SubItems[3].Text;
                        listView2.Items[i].SubItems[4].Text = listView2.Items[j].SubItems[4].Text;
                        listView2.Items[j].SubItems[0].Text = a;
                        listView2.Items[j].SubItems[1].Text = b;
                        listView2.Items[j].SubItems[2].Text = c;
                        listView2.Items[j].SubItems[3].Text = d;
                        listView2.Items[j].SubItems[4].Text = x;
                    }
                }
            }
        }

        private void btnSXGiam_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView2.Items.Count - 1; i++)
            {

                for (int j = i + 1; j < listView2.Items.Count; j++)
                {

                    if (Double.Parse(listView2.Items[i].SubItems[4].Text) < Double.Parse(listView2.Items[j].SubItems[4].Text))
                    {

                        string a = listView2.Items[i].SubItems[0].Text;
                        string b = listView2.Items[i].SubItems[1].Text;
                        string c = listView2.Items[i].SubItems[2].Text;
                        string d = listView2.Items[i].SubItems[3].Text;
                        string x = listView2.Items[i].SubItems[4].Text;
                        listView2.Items[i].SubItems[0].Text = listView2.Items[j].SubItems[0].Text;
                        listView2.Items[i].SubItems[1].Text = listView2.Items[j].SubItems[1].Text;
                        listView2.Items[i].SubItems[2].Text = listView2.Items[j].SubItems[2].Text;
                        listView2.Items[i].SubItems[3].Text = listView2.Items[j].SubItems[3].Text;
                        listView2.Items[i].SubItems[4].Text = listView2.Items[j].SubItems[4].Text;
                        listView2.Items[j].SubItems[0].Text = a;
                        listView2.Items[j].SubItems[1].Text = b;
                        listView2.Items[j].SubItems[2].Text = c;
                        listView2.Items[j].SubItems[3].Text = d;
                        listView2.Items[j].SubItems[4].Text = x;
                    }
                }
            }
        }

        private void btnIN_Click(object sender, EventArgs e)
        {
            DataTable dtRP = db.LayDLDataTable("select *from DONHANGVIEW");
            new FormBaoCao("DONHANG", dtRP).Show();
        }

        private void btnLuuDH_Click(object sender, EventArgs e)
        {
            if (them == true)
            {
                if (cbo_KH.SelectedIndex == -1 || cbo_TinhTrang.SelectedIndex == -1
                    || cbo_HinhThucTT.SelectedIndex == -1)
                {

                    MessageBox.Show("Vui lòng nhập đẩy đủ thông tin");
                }
                else
                {

                    string sql = String.Format("  SET DATEFORMAT DMY" +
                        " INSERT INTO DONHANG(MAKH,MANV ,NGAYLAP,TONGTIEN ,HINHTHUCTT,TINHTRANG,GHICHU)" +
                        " VALUES({0},{1},'{2}',0,N'{3}',N'{4}',N'{5}')",
                    cbo_KH.SelectedValue.ToString(), manv, txtNgayLap.Text, cbo_HinhThucTT.Text, cbo_TinhTrang.Text, txtGhiChu.Text);
                    bool kq = db.ThemXoaSua(sql);
                    if (kq == true)
                    {
                        MessageBox.Show("Thêm thành công");

                        hienthi();

                    }

                    cbo_KH.Enabled = false;
                    cbo_NV.SelectedIndex = -1;
                    txtGia.Enabled = false;
                    txtSoLuong.Enabled = false;
                    cbo_HinhThucTT.Enabled = false;
                    cbo_TinhTrang.Enabled = false;
                    txtGhiChu.Enabled = false;
                    txtNgayLap.Enabled = false;
                    txtMa.Visible = true;
                    btnThemDH.Enabled = true;
                    btnSuaDH.Enabled = true;
                    btnXoaDH.Enabled = true;
                    btnLuuDH.Enabled = false;
                    btnHuyDH.Enabled = false;
                }
            }
            else
            {
                string sql = String.Format("  SET DATEFORMAT DMY" +
                        " UPDATE DONHANG SET MAKH={0},HINHTHUCTT=N'{1}',TINHTRANG=N'{2}',GHICHU=N'{3}'" +
                        " WHERE MADH={4}",
                    cbo_KH.SelectedValue.ToString(), cbo_HinhThucTT.Text, cbo_TinhTrang.Text, txtGhiChu.Text, txtMa.Text);
                bool kq = db.ThemXoaSua(sql);
                if (kq == true)
                {
                    MessageBox.Show("Cập Nhật thành công");

                    hienthi();
                    cbo_KH.Enabled = false;
                    cbo_NV.SelectedIndex = int.Parse(manv) - 1;
                    cbo_HinhThucTT.Enabled = false;
                    cbo_TinhTrang.Enabled = false;
                    txtGhiChu.Enabled = false;
                    btnThemDH.Enabled = true;
                    btnSuaDH.Enabled = true;
                    btnXoaDH.Enabled = true;
                    btnLuuDH.Enabled = false;
                    btnHuyDH.Enabled = false;
                }
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            listView2.Clear();
            listView2.Columns.Add("Mã DH");
            listView2.Columns.Add("Tên Khách Hàng");
            listView2.Columns.Add("Nhân Viên");
            listView2.Columns.Add("Ngày Lập");
            listView2.Columns.Add("Tổng Tiền");
            listView2.Columns[0].Width = 100;
            listView2.Columns[1].Width = 200;
            listView2.Columns[2].Width = 200;
            listView2.Columns[3].Width = 200;
            listView2.Columns[4].Width = 100;
            string d = dateTimePicker1.Value.Day+"";
            string m = dateTimePicker1.Value.Month + "";
            string  y = dateTimePicker1.Value.Year + "";
        
            string ngay=m + "/" + d+"/" + y;
            string sql = "select *from DONHANG WHERE NGAYLAP='" + ngay + "'";
            dtDonHang = db.LayDLDataTable(sql);
            foreach (DataRow row in dtDonHang.Rows)
            {
                DataTable dtKHTam = db.LayDLDataTable("select * FROM KHACHHANG WHERE MAKH=" + row[1].ToString());
                DataTable dtNVTam = db.LayDLDataTable("select * FROM NHANVIEN WHERE MANV=" + row[2].ToString());
                ListViewItem lvi = listView2.Items.Add(row[0].ToString());
                foreach (DataRow row1 in dtKHTam.Rows)
                {
                    lvi.SubItems.Add(row1[1].ToString());
                }
                foreach (DataRow row2 in dtNVTam.Rows)
                {
                    lvi.SubItems.Add(row2[1].ToString());
                }

                lvi.SubItems.Add(row[3].ToString().Substring(0, row[3].ToString().IndexOf(" ")));
                lvi.SubItems.Add(row[4].ToString().Substring(0, row[4].ToString().IndexOf(".")));
            }
        }

        private void frm_DonHang_Load(object sender, EventArgs e)
        {

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";//Date: 01/34/6789
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            hienthi();
            cbo_HinhThucTT.Items.Add("TRẢ GÓP");
            cbo_HinhThucTT.Items.Add("TIỀN MẶT");
            cbo_HinhThucTT.SelectedIndex = -1;
            cbo_TinhTrang.Items.Add("CHƯA HOÀN THÀNH");
            cbo_TinhTrang.Items.Add("HOÀN THÀNH");
            cbo_TinhTrang.SelectedIndex = -1;
           
        }
        void hienthi()
        {
            listView2.Clear();
            listView2.Columns.Add("Mã DH");
            listView2.Columns.Add("Tên Khách Hàng");
            listView2.Columns.Add("Nhân Viên");
            listView2.Columns.Add("Ngày Lập");
            listView2.Columns.Add("Tổng Tiền");
            listView2.Columns[0].Width = 100;
            listView2.Columns[1].Width = 200;
            listView2.Columns[2].Width = 200;
            listView2.Columns[3].Width = 200;
            listView2.Columns[4].Width = 100;
            dtDonHang = db.LayDLDataTable("Select*from DONHANG");
            dtTB = db.LayDLDataTable("Select*from THIETBI");
            dtNV = db.LayDLDataTable("Select*from NHANVIEN");
            dtKH = db.LayDLDataTable("Select*from KHACHHANG");
            keydon[0] = dtDonHang.Columns[0];
            dtDonHang.PrimaryKey = keydon;

            foreach (DataRow row in dtDonHang.Rows)
            {
                DataTable dtKHTam = db.LayDLDataTable("select * FROM KHACHHANG WHERE MAKH=" + row[1].ToString());
                DataTable dtNVTam = db.LayDLDataTable("select * FROM NHANVIEN WHERE MANV=" + row[2].ToString());
                ListViewItem lvi = listView2.Items.Add(row[0].ToString());
                foreach (DataRow row1 in dtKHTam.Rows)
                {
                    lvi.SubItems.Add(row1[1].ToString());
                }
                foreach (DataRow row2 in dtNVTam.Rows)
                {
                    lvi.SubItems.Add(row2[1].ToString());
                }
               
                lvi.SubItems.Add(row[3].ToString().Substring(0,row[3].ToString().IndexOf(" ")));
                lvi.SubItems.Add(row[4].ToString().Substring(0, row[4].ToString().IndexOf(".")));
            }
            cbo_KH.DataSource = dtKH;
            cbo_KH.DisplayMember = "TENKH";
            cbo_KH.ValueMember = "MAKH";
            cbo_NV.DataSource = dtNV;
            cbo_NV.DisplayMember = "TENNV";
            cbo_NV.ValueMember = "MANV";
            cbo_NV.SelectedIndex = -1;
            cbo_KH.SelectedIndex = -1;
            DataTable dtTBCBO = db.LayDLDataTable("select*from THIETBI");
            cboThietBi.DataSource = dtTBCBO;
            cboThietBi.DisplayMember = "TENTB";
            cboThietBi.ValueMember = "MATB";
            cboThietBi.SelectedIndex = -1;
        }
        
    }
}
