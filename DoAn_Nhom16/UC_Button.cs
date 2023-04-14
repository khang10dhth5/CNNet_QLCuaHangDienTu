using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom16
{
    public partial class UC_Button : UserControl
    {
        public UC_Button()
        {
            InitializeComponent();
        }

        override
        public string Text
        {
            set { button1.Text = value; }
        }
        private void UC_Button_Load(object sender, EventArgs e)
        {

        }
    }
}
