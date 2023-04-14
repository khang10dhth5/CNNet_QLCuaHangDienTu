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
    public partial class UC_ComboBox : UserControl
    {
        public UC_ComboBox()
        {
            InitializeComponent();
        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        public Image setIcon
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        public Color setColor
        {
            get { return rectangleShape1.BorderColor; }
            set { rectangleShape1.BorderColor = value; }
        }
        override
        public string Text
        {
            get { return comboBox1.SelectedText; }
        }
        public List<string> setListItem
        {
            set { comboBox1.DataSource = value; }
        } 
        public int selectedIndex
        {
            get { return comboBox1.SelectedIndex; }
            set { comboBox1.SelectedIndex = value; }
        }
        public string selectedItem
        {
            get { return comboBox1.SelectedItem.ToString(); }
            set { comboBox1.Text = value; }
        }
        private void UC_ComboBox_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
