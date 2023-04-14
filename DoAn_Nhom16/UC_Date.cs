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
    public partial class UC_Date : UserControl
    {
        public UC_Date()
        {
            InitializeComponent();
        }

        public Image setIcon
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }
        override
        public string Text
        {
            get { return dateTimePicker1.Text; }
        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        public Color setColor
        {
            get { return rectangleShape1.BorderColor; }
            set { rectangleShape1.BorderColor = value; }
        }
        private void UC_Date_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";//Date: 01/34/6789
        }
    }
}
