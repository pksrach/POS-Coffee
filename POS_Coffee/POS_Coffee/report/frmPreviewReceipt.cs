using Microsoft.Reporting.WinForms;
using POS_Coffee.cls;
using POS_Coffee.report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace POS_Coffee.Subform
{
    public partial class frmPreviewReceipt : Form
    {
        public frmPreviewReceipt()
        {
            InitializeComponent();
        }
        
        private void frmReportIncome_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        public void LoadReceiptByMasterId(string master_id, string header, string subtitle, string footer)
        {
            try
            {
                DataSet1 ds = new DataSet1();
                ReportDataSource rptDS;
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\reports\ReportReceipt.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                //DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                ConnectionDb.cnn.Open();
                da = new SqlDataAdapter("SELECT tbl_product.product_name, tbl_sales_detail.price, tbl_sales_detail.qty, tbl_sales_detail.discount_item, tbl_sales_detail.amount, tbl_sales.invoice, tbl_sales.subtotal_us, tbl_sales.discount_invoice, tbl_sales.grand_total_us, tbl_sales.grand_total_kh, tbl_sales.received_us, tbl_sales.received_kh, tbl_sales.change_kh, tbl_staffs.staff_name, tbl_sales.datetime, tbl_sales_detail.sale_id FROM tbl_sales INNER JOIN tbl_sales_detail ON tbl_sales.sale_id = tbl_sales_detail.sale_id INNER JOIN tbl_staffs ON tbl_sales.sid = tbl_staffs.sid INNER JOIN tbl_product ON tbl_sales_detail.product_id = tbl_product.pid Where tbl_sales_detail.sale_id = " + master_id + " and tbl_sales.deleted_date is null", ConnectionDb.cnn);
                da.Fill(ds.Tables["DataTableReceipt"]); // table name in DataSet1.xsd
                ConnectionDb.cnn.Close();

                // Set parameter in report
                ReportParameter pHeader = new ReportParameter("pHeader", header);
                ReportParameter pSubtitle = new ReportParameter("pSubtitle", subtitle);
                ReportParameter pFooter = new ReportParameter("pFooter", footer);

                reportViewer1.LocalReport.SetParameters(pHeader);
                reportViewer1.LocalReport.SetParameters(pSubtitle);
                reportViewer1.LocalReport.SetParameters(pFooter);
                // End of set parameter in report

                rptDS = new ReportDataSource("Receipt", ds.Tables["DataTableReceipt"]); // "Receipt" is a name in ReportReceipt.rdlc
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
            }
            catch (Exception ex)
            {
                ConnectionDb.cnn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public Point mouseLocation;
        private void MyMouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }
        private void MyMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }//
}///
