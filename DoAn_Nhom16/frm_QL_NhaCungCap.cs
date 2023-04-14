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
    public partial class frm_QL_NhaCungCap : Form
    {
        public frm_QL_NhaCungCap()
        {
            InitializeComponent();
        }

        private void frm_QL_NhaCungCap_Load(object sender, EventArgs e)
        {
            //Full screen không có khung bên ngoài
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
