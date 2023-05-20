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
    public partial class frmPreviewReport : Form
    {

        DataSet1 ds = new DataSet1();
        public frmPreviewReport()
        {
            InitializeComponent();
        }
        
        private void frmReportIncome_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        public void LoadDataByDateFilterExpense(string sql, string param)
        {
            try
            {
                ds.Clear();
                ReportDataSource rptDS;
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\reports\ReportExpense.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                //DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                ConnectionDb.cnn.Open();
                da.SelectCommand = new SqlCommand(sql, ConnectionDb.cnn);
                da.Fill(ds.Tables["DataTableExpense"]); // table name in DataSetIncome.xsd
                ConnectionDb.cnn.Close();

                // Set parameter in report
                ReportParameter pDate = new ReportParameter("pSubtitle", param);
                reportViewer1.LocalReport.SetParameters(pDate);

                rptDS = new ReportDataSource("Expenses", ds.Tables["DataTableExpense"]); // "Expenses" is a name in ReportIncome.rdlc
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            catch (Exception ex)
            {
                ConnectionDb.cnn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//function load top 10 selling

        public void LoadDataByDateFilterIncome(string sql, string param)
        {
            try
            {
                ds.Clear();
                ReportDataSource rptDS;
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\reports\ReportIncome.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                //DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                ConnectionDb.cnn.Open();
                da.SelectCommand = new SqlCommand(sql, ConnectionDb.cnn);
                da.Fill(ds.Tables["DataTableIncomes"]); // table name in DataSetIncome.xsd
                ConnectionDb.cnn.Close();

                // Set parameter in report
                ReportParameter pDate = new ReportParameter("pSubtitle", param);
                reportViewer1.LocalReport.SetParameters(pDate);

                rptDS = new ReportDataSource("Incomes", ds.Tables["DataTableIncomes"]); // "Incomes" is a name in ReportIncome.rdlc
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            catch (Exception ex)
            {
                ConnectionDb.cnn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//function load top 10 selling

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadAllDataIncome(string param)
        {
            try
            {
                ds.Clear();
                ReportDataSource rptDS;
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\reports\ReportIncome.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                //DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                ConnectionDb.cnn.Open();
                da = new SqlDataAdapter("Select s.sale_id, s.datetime, s.invoice, s.subtotal_us, s.discount_invoice, s.grand_total_us, s.grand_total_kh, s.received_us, s.received_kh, s.change_kh, s.sid, st.staff_name, s.payment_type_id, tp.payment from tbl_sales s inner join tbl_staffs st on s.sid = st.sid inner join tbl_type_payment tp on s.payment_type_id = tp.id where s.deleted_date is NULL;", ConnectionDb.cnn);
                da.Fill(ds.Tables["DataTableIncomes"]); // table name in DataSet1.xsd
                ConnectionDb.cnn.Close();

                // Set parameter in report
                ReportParameter pDate = new ReportParameter("pSubtitle", param);
                reportViewer1.LocalReport.SetParameters(pDate);

                rptDS = new ReportDataSource("Incomes", ds.Tables["DataTableIncomes"]); // "Incomes" is a name in ReportIncome.rdlc
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            catch (Exception ex)
            {
                ConnectionDb.cnn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadAllDataExpense(string param)
        {
            try
            {
                ds.Clear();
                ReportDataSource rptDS;
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\reports\ReportExpense.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                
                SqlDataAdapter da = new SqlDataAdapter();

                ConnectionDb.cnn.Open();
                da = new SqlDataAdapter("Select e.id, e.created_date, e.total_us, e.total_kh, e.created_by, s.staff_name from tbl_expenses e inner join tbl_staffs s on e.created_by = s.sid Where e.deleted_date is null", ConnectionDb.cnn);
                da.Fill(ds.Tables["DataTableExpense"]); // table name in DataSet1.xsd
                ConnectionDb.cnn.Close();

                // Set parameter in report
                ReportParameter pDate = new ReportParameter("pSubtitle", param);
                reportViewer1.LocalReport.SetParameters(pDate);

                rptDS = new ReportDataSource("Expenses", ds.Tables["DataTableExpense"]); // "Incomes" is a name in ReportIncome.rdlc
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            catch (Exception ex)
            {
                ConnectionDb.cnn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadDataExpenseDetailByMasterId(string master_id, string param)
        {
            try
            {
                ds.Clear();
                ReportDataSource rptDS;
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\reports\ReportExpenseDetail.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                //DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                ConnectionDb.cnn.Open();
                da = new SqlDataAdapter("Select ed.master_id, et.type, ed.total_us, ed.total_kh, ed.description, et.type, s.staff_name, e.created_date from tbl_expenses e inner join tbl_expense_details ed on e.id = ed.master_id inner join tbl_expense_type et on ed.type_id = et.id inner join tbl_staffs s on e.created_by = s.sid Where ed.master_id = " + master_id+" and e.deleted_date is null", ConnectionDb.cnn);
                da.Fill(ds.Tables["DataTableExpenseDetail"]); // table name in DataSet1.xsd
                ConnectionDb.cnn.Close();

                // Set parameter in report
                ReportParameter pSubtitle = new ReportParameter("pSubtitle", param);
                reportViewer1.LocalReport.SetParameters(pSubtitle);

                rptDS = new ReportDataSource("ExpenseDetails", ds.Tables["DataTableExpenseDetail"]); // "Expenses" is a name in ReportIncome.rdlc
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
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
    }//
}///
