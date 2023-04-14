namespace DoAn_Nhom16
{
    partial class frm_QL_NhaCungCap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uC_ComboBox_Simple1 = new DoAn_Nhom16.UC_ComboBox_Simple();
            this.uC_Textbox_Simple1 = new DoAn_Nhom16.UC_Textbox_Simple();
            this.uC_Date_Simple1 = new DoAn_Nhom16.UC_Date_Simple();
            this.SuspendLayout();
            // 
            // uC_ComboBox_Simple1
            // 
            this.uC_ComboBox_Simple1.Location = new System.Drawing.Point(70, 146);
            this.uC_ComboBox_Simple1.Name = "uC_ComboBox_Simple1";
            this.uC_ComboBox_Simple1.selectedIndex = -1;
            this.uC_ComboBox_Simple1.setColor = System.Drawing.SystemColors.ControlText;
            this.uC_ComboBox_Simple1.Size = new System.Drawing.Size(374, 53);
            this.uC_ComboBox_Simple1.TabIndex = 1;
            // 
            // uC_Textbox_Simple1
            // 
            this.uC_Textbox_Simple1.Location = new System.Drawing.Point(65, 71);
            this.uC_Textbox_Simple1.Name = "uC_Textbox_Simple1";
            this.uC_Textbox_Simple1.setColor = System.Drawing.SystemColors.ControlText;
            this.uC_Textbox_Simple1.Size = new System.Drawing.Size(502, 56);
            this.uC_Textbox_Simple1.TabIndex = 0;
            // 
            // uC_Date_Simple1
            // 
            this.uC_Date_Simple1.Location = new System.Drawing.Point(70, 205);
            this.uC_Date_Simple1.Name = "uC_Date_Simple1";
            this.uC_Date_Simple1.setColor = System.Drawing.SystemColors.ControlText;
            this.uC_Date_Simple1.Size = new System.Drawing.Size(374, 51);
            this.uC_Date_Simple1.TabIndex = 2;
            // 
            // frm_QL_NhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 447);
            this.Controls.Add(this.uC_Date_Simple1);
            this.Controls.Add(this.uC_ComboBox_Simple1);
            this.Controls.Add(this.uC_Textbox_Simple1);
            this.Name = "frm_QL_NhaCungCap";
            this.Text = "frm_QL_NhaCungCap";
            this.Load += new System.EventHandler(this.frm_QL_NhaCungCap_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UC_Textbox_Simple uC_Textbox_Simple1;
        private UC_ComboBox_Simple uC_ComboBox_Simple1;
        private UC_Date_Simple uC_Date_Simple1;
    }
}