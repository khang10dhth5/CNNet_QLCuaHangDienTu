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
    public partial class UC_Date_Simple : UserControl
    {
        public UC_Date_Simple()
        {
            InitializeComponent();
        }

        private void UC_Date_Simple_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";//Date: 01/34/6789
        }
        override
        public string Text
        {
            get { return dateTimePicker1.Text; }
        }

        public Color setColor
        {
            get { return rectangleShape1.BorderColor; }
            set { rectangleShape1.BorderColor = value; }
        }
    }
}
