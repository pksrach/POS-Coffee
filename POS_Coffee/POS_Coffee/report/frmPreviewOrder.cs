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
    public partial class frmPreviewOrder : Form
    {
        public frmPreviewOrder()
        {
            InitializeComponent();
        }
        
        private void frmReportIncome_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        public void OrderNum(string master_id, string no)
        {
            try
            {
                DataSet1 ds = new DataSet1();
                ReportDataSource rptDS;
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\reports\ReportOrder.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                //DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                ConnectionDb.cnn.Open();
                da = new SqlDataAdapter("SELECT oid, invoice, datetime FROM tbl_orders where oid = " + master_id + " ", ConnectionDb.cnn);
                da.Fill(ds.Tables["DataTableOrder"]); // table name in DataSet1.xsd
                ConnectionDb.cnn.Close();

                // Set parameter in report
                ReportParameter pNo = new ReportParameter("pNo", no);
                reportViewer1.LocalReport.SetParameters(pNo);
                // End of set parameter in report

                rptDS = new ReportDataSource("order", ds.Tables["DataTableOrder"]); // "Receipt" is a name in ReportReceipt.rdlc
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
