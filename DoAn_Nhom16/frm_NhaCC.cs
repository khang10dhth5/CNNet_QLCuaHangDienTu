using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom16
{
    public partial class frm_NhaCC : Form
    {
        XuLyDB db = new XuLyDB();
        DataTable dtNCC;
        DataColumn[] keydon = new DataColumn[1];
        bool them = false;
        public frm_NhaCC()
        {
            InitializeComponent();
        }

        private void frm_NhaCC_Load(object sender, EventArgs e)
        {

            hienthi();
        }
        void hienthi()
        {
            listView1.Clear();
            listView1.Columns.Add("Mã NCC");

            listView1.Columns.Add("Tên Nhà Cung Cấp");
            listView1.Columns.Add("SDT");
            listView1.Columns.Add("Địa chỉ");
            listView1.Columns[0].Width = 60;
            listView1.Columns[1].Width = 200;
            listView1.Columns[2].Width = 100;
            listView1.Columns[3].Width = 100;
            dtNCC = db.LayDLDataTable("Select*from NHACC");
            keydon[0] = dtNCC.Columns[0];
            dtNCC.PrimaryKey = keydon;

            foreach (DataRow row in dtNCC.Rows)
            {

                ListViewItem lvi = listView1.Items.Add(row[0].ToString());
                lvi.SubItems.Add(row[1].ToString());
                lvi.SubItems.Add(row[2].ToString());
                lvi.SubItems.Add(row[3].ToString());

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                uC_TextBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
                uC_TextBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
                uC_TextBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
                uC_TextBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            uC_TextBox1.Text = "";
            uC_TextBox2.Text = "";
            uC_TextBox3.Text = "";
            uC_TextBox4.Text = "";
            uC_TextBox4.Enabled = true;
            uC_TextBox2.Enabled = true;
            uC_TextBox3.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            them = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            uC_TextBox4.Enabled = true;
            uC_TextBox2.Enabled = true;
            uC_TextBox3.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool t2 = db.checkTonTai("select*from DONNHAP WHERE MANCC=" + uC_TextBox1.Text);
            bool t1 = db.checkTonTai("select*from THIETBI WHERE MANCC=" + uC_TextBox1.Text);
            if (t2 == true || t1 == true)
            {
                MessageBox.Show("Không thể xóa do có chi tiết đơn hàng tham chiếu");
            }
            else
            {

                bool xoa = db.ThemXoaSua("DELETE FROM NHACC WHERE MANCC=" + uC_TextBox1.Text);
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (uC_TextBox4.Text == "" || uC_TextBox2.Text == "" || uC_TextBox3.Text == "")
            {
                MessageBox.Show("Vui Lòng Nhập đầy đủ thông tin");
            }
            else
            {
                if (them)
                {
                    string sql = String.Format("Insert Into NHACC(TENNCC,SDT,DIACHI) VALUES(N'{0}',N'{1}',N'{2}')", uC_TextBox2.Text, uC_TextBox3.Text, uC_TextBox4.Text);
                    bool kq = db.ThemXoaSua(sql);
                    if (kq == true)
                    {
                        MessageBox.Show("Thêm thành công");
                        uC_TextBox1.Text = "";
                        uC_TextBox2.Text = "";
                        uC_TextBox3.Text = "";
                        uC_TextBox4.Text = "";
                        btnThem.Enabled = true;
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                        btnLuu.Enabled = false;
                        btnHuy.Enabled = false;
                        uC_TextBox3.Enabled = false;
                        uC_TextBox2.Enabled = false;
                        uC_TextBox1.Enabled = false;
                        uC_TextBox4.Enabled = false;
                        hienthi();
                    }
                }
                else
                {
                    string sql = String.Format("UPDATE NHACC SET TENNCC=N'{0}',SDT=N'{1}',DIACHI=N'{2}' WHERE MANCC={3}", uC_TextBox2.Text, uC_TextBox3.Text, uC_TextBox4.Text, uC_TextBox1.Text);
                    bool kq = db.ThemXoaSua(sql);
                    if (kq == true)
                    {
                        MessageBox.Show("Cập Nhật thành công");
                        uC_TextBox1.Text = "";
                        uC_TextBox2.Text = "";
                        uC_TextBox3.Text = "";
                        uC_TextBox4.Text = "";
                        uC_TextBox3.Enabled = false;
                        uC_TextBox2.Enabled = false;
                        uC_TextBox1.Enabled = false;
                        uC_TextBox4.Enabled = false;
                        btnThem.Enabled = true;
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                        btnLuu.Enabled = false;
                        btnHuy.Enabled = false;
                        hienthi();
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            uC_TextBox1.Text = "";
            uC_TextBox2.Text = "";
            uC_TextBox3.Text = "";
            uC_TextBox4.Text = "";
            uC_TextBox3.Enabled = false;
            uC_TextBox2.Enabled = false;
            uC_TextBox1.Enabled = false;
            uC_TextBox4.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            listView1.Clear();
            listView1.Columns.Add("Mã NCC");

            listView1.Columns.Add("Tên Nhà Cung Cấp");
            listView1.Columns.Add("SDT");
            listView1.Columns.Add("Địa chỉ");
            listView1.Columns[0].Width = 60;
            listView1.Columns[1].Width = 200;
            listView1.Columns[2].Width = 100;
            listView1.Columns[2].Width = 100;
            string sql = "select*from NHACC";
            if (txtTimKiem.Text == "")
            {
                dtNCC = db.LayDLDataTable(sql);
            }
            else
            {
                dtNCC = db.LayDLDataTable("select*from NHACC WHERE TENNCC LIKE N'%" + txtTimKiem.Text + "%'");
            }
            foreach (DataRow row in dtNCC.Rows)
            {

                ListViewItem lvi = listView1.Items.Add(row[0].ToString());
                lvi.SubItems.Add(row[1].ToString());
                lvi.SubItems.Add(row[2].ToString());
                lvi.SubItems.Add(row[3].ToString());

            }
        }

        private void btnIN_Click(object sender, EventArgs e)
        {
            new FormBaoCao("NHACC", dtNCC).Show();
        }
    }
}
