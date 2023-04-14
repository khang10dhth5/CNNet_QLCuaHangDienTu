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
    public partial class frm_NhanVien : Form
    {
        XuLyDB db = new XuLyDB();
        DataTable dtKH;
        DataColumn[] keydon = new DataColumn[1];
        bool them = false;
        public frm_NhanVien()
        {
            InitializeComponent();
        }

        private void frm_NhanVien_Load(object sender, EventArgs e)
        {
            hienthi();
        }
        void hienthi()
        {
            listView1.Clear();
            listView1.Columns.Add("Mã ");
            listView1.Columns.Add("Tên ");
            listView1.Columns.Add("SDT");

            listView1.Columns[0].Width = 60;
            listView1.Columns[1].Width = 200;
            listView1.Columns[2].Width = 100;

            dtKH = db.LayDLDataTable("Select*from NHANVIEN");
            keydon[0] = dtKH.Columns[0];
            dtKH.PrimaryKey = keydon;

            foreach (DataRow row in dtKH.Rows)
            {

                ListViewItem lvi = listView1.Items.Add(row[0].ToString());
                lvi.SubItems.Add(row[1].ToString());
                lvi.SubItems.Add(row[4].ToString());


            }
            rbo_Nam.Checked = true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                uC_Ma.Text = listView1.SelectedItems[0].SubItems[0].Text;
                DataTable dtTam = db.LayDLDataTable("select*from NHANVIEN WHERE MANV=" + uC_Ma.Text);
                foreach (DataRow row in dtTam.Rows)
                {
                    uC_Ten.Text = row[1].ToString();
                    uC_NgaySinh.Text = row[2].ToString().Substring(0, row[2].ToString().IndexOf(' '));
                    if (row[3].ToString() == "Nam")
                    {
                        rbo_Nam.Checked = true;
                    }
                    else if (row[3].ToString() == "Nữ")
                    {
                        rbo_Nu.Checked = true;
                    }
                    else
                    {
                        rbo_Khac.Checked = true;
                    }
                    uC_SDT.Text = row[4].ToString();
                    uC_DiaChi.Text = row[5].ToString();
                }

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            uC_DiaChi.Enabled = true;
            uC_NgaySinh.Enabled = true;
            uC_Ten.Enabled = true;
            uC_SDT.Enabled = true;
            rbo_Khac.Enabled = true;
            rbo_Nam.Enabled = true;
            rbo_Nu.Enabled = true;
           
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool t2 = db.checkTonTai("select*from DONHANG WHERE MANV=" + uC_Ma.Text);
            bool t1 = db.checkTonTai("select*from DONNHAP WHERE MANV=" + uC_Ma.Text);
            if (t2 == true||t1==true)
            {
                MessageBox.Show("Không thể xóa do có  đơn hàng tham chiếu");
            }
            else
            {

                bool xoa = db.ThemXoaSua("DELETE FROM NHANVIEN WHERE MANV=" + uC_Ma.Text);
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            uC_DiaChi.Enabled = false;
            uC_NgaySinh.Enabled = false;
            uC_Ten.Enabled = false;
            uC_SDT.Enabled = false;
            rbo_Khac.Enabled = false;
            rbo_Nam.Enabled = false;
            rbo_Nu.Enabled = false;
          
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tt = "";
            if (rbo_Nam.Checked)
            {
                tt = "Nam";
            }
            if (rbo_Nu.Checked)
            {
                tt = "Nữ";
            }
            if (rbo_Khac.Checked)
            {
                tt = "Khác";
            }
            if (uC_SDT.Text == "" || uC_Ten.Text == "" || uC_DiaChi.Text == "" || uC_NgaySinh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            }
            else
            {
                string sql = String.Format("UPDATE NHANVIEN SET TENNV=N'{0}',NGAYSINH='{1}',GIOITINH=N'{2}',SDT=N'{3}',DIACHI=N'{4}'" +
                        " WHERE MANV={5}", uC_Ten.Text, uC_NgaySinh.Text, tt, uC_SDT.Text, uC_DiaChi.Text, uC_Ma.Text);
                bool kq = db.ThemXoaSua(sql);
                if (kq == true)
                {
                    MessageBox.Show(" Cập nhật thành công");
                    uC_DiaChi.Enabled = false;
                    uC_NgaySinh.Enabled = false;
                    uC_Ten.Enabled = false;
                    uC_SDT.Enabled = false;
                    rbo_Khac.Enabled = false;
                    rbo_Nam.Enabled = false;
                    rbo_Nu.Enabled = false;
                   
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnLuu.Enabled = false;
                    btnHuy.Enabled = false;
                    hienthi();
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            listView1.Columns.Add("Mã ");
            listView1.Columns.Add("Tên ");
            listView1.Columns.Add("SDT");

            listView1.Columns[0].Width = 60;
            listView1.Columns[1].Width = 200;
            listView1.Columns[2].Width = 100;
            string sql = "select*from NHANVIEN";
            if (txtTimKiem.Text == "")
            {
                dtKH = db.LayDLDataTable(sql);
            }
            else
            {
                dtKH = db.LayDLDataTable("select*from NHANVIEN WHERE TENNV LIKE N'%" + txtTimKiem.Text + "%'");
            }
            foreach (DataRow row in dtKH.Rows)
            {

                ListViewItem lvi = listView1.Items.Add(row[0].ToString());
                lvi.SubItems.Add(row[1].ToString());
                lvi.SubItems.Add(row[4].ToString());


            }
        }

        private void btnIN_Click(object sender, EventArgs e)
        {
            new FormBaoCao("NHANVIEN", dtKH).Show();
        }
    }
}
