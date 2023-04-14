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
    public partial class UC_Textbox_Simple : UserControl
    {
        public UC_Textbox_Simple()
        {
            InitializeComponent();
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

        private void UC_Textbox_Simple_Load(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        public Color setColor
        {
            get { return rectangleShape1.BorderColor; }
            set { rectangleShape1.BorderColor = value; }
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
    }
}
