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
    public partial class UC_TextBox : UserControl
    {
        public UC_TextBox()
        {
            InitializeComponent();
        }
        public Color setColor
        {
            get { return rectangleShape1.BorderColor; }
            set { rectangleShape1.BorderColor = value; }
        }
        public Image setIcon
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }
        public char SetPass
        {
            set { textBox1.PasswordChar = value; }
        }
        override
        public string Text
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        private void UC_TextBox_Load(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(textBox1.Text))
            //{
            //    textBox1.Focus();
            //    errorProvider1.SetError(textBox1, "*Trống");
            //}
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "*Trống");
            }
            else 
                errorProvider1.SetError(textBox1, null);
        }
    }
}
