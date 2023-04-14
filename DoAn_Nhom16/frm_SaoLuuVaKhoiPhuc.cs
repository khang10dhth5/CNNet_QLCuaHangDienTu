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
    public partial class frm_SaoLuuVaKhoiPhuc : Form
    {
        string ProjectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        DataColumn[] key = new DataColumn[1];//Cấp phát cho 1 khóa
        XuLyDB db = new XuLyDB();
        DataTable dtdb;
        public frm_SaoLuuVaKhoiPhuc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(db.SaoLuu("DBSaoLuuNgay")) {
                MessageBox.Show("Sao lưu cơ sở dữ liệu thành công!!!");

                dtdb = db.LayDSFileBackup();
                dataGridView1.DataSource = dtdb;
                dataGridView1.Refresh();
            }
                else
                MessageBox.Show("Sao lưu cơ sở dữ liệu thất bại!!!");
        }

        private void frm_SaoLuuVaKhoiPhuc_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;

            dtdb = db.LayDSFileBackup();
            //chỉ định khóa chính cho bảng
            key[0] = dtdb.Columns[0];
            dtdb.PrimaryKey = key;


            dataGridView1.DataSource = dtdb;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //DataBiding
            textBox1.DataBindings.Add("Text", dtdb, "FileName");
            //

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentCell.Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa file khôi phục:\n" + textBox1.Text.Trim() + "", "Thông báo xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string aaa = ProjectPath + @"\Data\" + textBox1.Text.Trim();
                MessageBox.Show("xóa file: "+aaa);
                File.Delete(aaa);//@"D:\LeVanHuong_2001190104\.NET\.DoAn\DoAn_Nhom16_03\DoAn_Nhom16\HinhAnhSP\z2815346455553_4b2922ef8b7f286cd8610ed18e882466.jpg");
            

                dtdb = db.LayDSFileBackup();
                dataGridView1.DataSource = dtdb;
                dataGridView1.Refresh();
                textBox1.Clear();
            }
            else return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (db.PhucHoi(ProjectPath + @"\Data\" + textBox1.Text.Trim()))
            {
                MessageBox.Show("Phục hồi cơ sở dữ liệu thành công!!!");
            }
            else
                MessageBox.Show("Phục hồi cơ sở dữ liệu thất bại!!!"+ProjectPath+textBox1.Text.Trim());
        }

    }
}
