using System;
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
    public partial class FormBaoCao : Form
    {
        public FormBaoCao(string formname, DataTable dt)
        {
            InitializeComponent();
            if (formname == "SANPHAM")
            {
            //    SanPham_report krp = new SanPham_report();
            //    krp.SetDataSource(dt);
                //    crystalReportViewer1.ReportSource = krp;
                SanPham_report krp = new SanPham_report();
                krp.SetDataSource(dt);
                crystalReportViewer1.ReportSource = krp;
            }
            if (formname == "DONHANG")
            {
                
                DonHang_report krp = new DonHang_report();
                krp.SetDataSource(dt);
                crystalReportViewer1.ReportSource = krp;
            }
            if (formname == "DONNHAP")
            {
                
                DonNhap_report krp = new DonNhap_report();
                krp.SetDataSource(dt);
                crystalReportViewer1.ReportSource = krp;
            }
            if (formname == "KHACHHANG")
            {

                KhachHang_report krp = new KhachHang_report();
                krp.SetDataSource(dt);
                crystalReportViewer1.ReportSource = krp;
            }
            if (formname == "NHACC")
            {

                NhaCC_report krp = new NhaCC_report();
                krp.SetDataSource(dt);
                crystalReportViewer1.ReportSource = krp;
            }
            if (formname == "NHANVIEN")
            {

                NhanVien_report krp = new NhanVien_report();
                krp.SetDataSource(dt);
                crystalReportViewer1.ReportSource = krp;
            }
        }

        private void FormBaoCao_Load(object sender, EventArgs e)
        {
           
        }
    }
}
