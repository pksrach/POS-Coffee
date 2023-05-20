using Microsoft.Reporting.WinForms;
using POS_Coffee.cls;
using POS_Coffee.report;
using POS_Coffee.static_data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace POS_Coffee.Subform
{
    public partial class frmReportIncome : Form
    {
        //DataTable table = new DataTable();

        public frmReportIncome()
        {
            InitializeComponent();
        }
        
        private void frmReportIncome_Load(object sender, EventArgs e)
        {
            LoadData();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            lblPagination.Focus();
        }

        int totalRecords = 0;
        int totalPages = 0;
        int pageNumber = 1;
        int pageSize = 20;
        private void LoadData()
        {
            // DataPropertyName = "sid"; jea name column in db
            dataGridView1.Columns["colSaleId"].DataPropertyName = "sale_id";
            dataGridView1.Columns["colDatetime"].DataPropertyName = "datetime";
            dataGridView1.Columns["colInvoice"].DataPropertyName = "invoice";
            dataGridView1.Columns["colSubtotal_us"].DataPropertyName = "subtotal_us";
            dataGridView1.Columns["colDiscount_invoice"].DataPropertyName = "discount_invoice";
            dataGridView1.Columns["colGrand_total_us"].DataPropertyName = "grand_total_us";
            dataGridView1.Columns["colGrand_total_kh"].DataPropertyName = "grand_total_kh";
            dataGridView1.Columns["colReceived_us"].DataPropertyName = "received_us";
            dataGridView1.Columns["colReceived_kh"].DataPropertyName = "received_kh";
            dataGridView1.Columns["colChange_kh"].DataPropertyName = "change_kh";
            dataGridView1.Columns["colSid"].DataPropertyName = "sid";
            dataGridView1.Columns["colStaff"].DataPropertyName = "staff_name";
            dataGridView1.Columns["colPayment_type_id"].DataPropertyName = "payment_type_id";
            dataGridView1.Columns["colPaymentType"].DataPropertyName = "payment";

            // Set the column to display currency values
            dataGridView1.Columns["colSubtotal_us"].DefaultCellStyle.Format = "c";
            dataGridView1.Columns["colGrand_total_us"].DefaultCellStyle.Format = "c";
            dataGridView1.Columns["colReceived_us"].DefaultCellStyle.Format = "c";
            dataGridView1.Columns["colGrand_total_kh"].DefaultCellStyle.Format = String.Format("#,##0៛");
            dataGridView1.Columns["colReceived_kh"].DefaultCellStyle.Format = String.Format("#,##0៛");
            dataGridView1.Columns["colChange_kh"].DefaultCellStyle.Format = String.Format("#,##0៛");

            //count
            // Retrieve the total number of records in the table
            SqlCommand countCommand = new SqlCommand("SELECT COUNT(*) FROM tbl_sales s inner join tbl_staffs st on s.sid = st.sid inner join tbl_type_payment tp on s.payment_type_id = tp.id ", ConnectionDb.cnn);
            ConnectionDb.cnn.Open();
            totalRecords = (int)countCommand.ExecuteScalar();

            // Calculate the number of pages required
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // Retrieve the records for the current page
            int offset = (pageNumber - 1) * pageSize;

            string query = "Select s.sale_id, s.datetime, s.invoice, s.subtotal_us, s.discount_invoice, s.grand_total_us, s.grand_total_kh, s.received_us, s.received_kh, s.change_kh, s.sid, st.staff_name, s.payment_type_id, tp.payment from tbl_sales s inner join tbl_staffs st on s.sid = st.sid inner join tbl_type_payment tp on s.payment_type_id = tp.id where s.deleted_date is NULL order by s.datetime desc OFFSET @Offset ROWS FETCH NEXT @pageSize ROWS ONLY;";
            SqlCommand cmd = new SqlCommand(query, ConnectionDb.cnn);
            cmd.Parameters.AddWithValue("@Offset", offset);
            cmd.Parameters.AddWithValue("@pageSize", pageSize);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.ClearSelection();
            ConnectionDb.cnn.Close();

            // Pagination
            lblPagination.Text = string.Format("Page: {0} / {1}", pageNumber, totalPages);
        }

        private void LoadDataDateFilter()
        {
            // DataPropertyName = "sid"; jea name column in db
            dataGridView1.Columns["colSaleId"].DataPropertyName = "sale_id";
            dataGridView1.Columns["colDatetime"].DataPropertyName = "datetime";
            dataGridView1.Columns["colInvoice"].DataPropertyName = "invoice";
            dataGridView1.Columns["colSubtotal_us"].DataPropertyName = "subtotal_us";
            dataGridView1.Columns["colDiscount_invoice"].DataPropertyName = "discount_invoice";
            dataGridView1.Columns["colGrand_total_us"].DataPropertyName = "grand_total_us";
            dataGridView1.Columns["colGrand_total_kh"].DataPropertyName = "grand_total_kh";
            dataGridView1.Columns["colReceived_us"].DataPropertyName = "received_us";
            dataGridView1.Columns["colReceived_kh"].DataPropertyName = "received_kh";
            dataGridView1.Columns["colChange_kh"].DataPropertyName = "change_kh";
            dataGridView1.Columns["colSid"].DataPropertyName = "sid";
            dataGridView1.Columns["colStaff"].DataPropertyName = "staff_name";
            dataGridView1.Columns["colPayment_type_id"].DataPropertyName = "payment_type_id";
            dataGridView1.Columns["colPaymentType"].DataPropertyName = "payment";

            // Set the column to display currency values
            //dataGridView1.Columns["datetime"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dataGridView1.Columns["colSubtotal_us"].DefaultCellStyle.Format = "c";
            dataGridView1.Columns["colGrand_total_us"].DefaultCellStyle.Format = "c";
            dataGridView1.Columns["colReceived_us"].DefaultCellStyle.Format = "c";
            dataGridView1.Columns["colGrand_total_kh"].DefaultCellStyle.Format = String.Format("#,##0៛");
            dataGridView1.Columns["colReceived_kh"].DefaultCellStyle.Format = String.Format("#,##0៛");
            dataGridView1.Columns["colChange_kh"].DefaultCellStyle.Format = String.Format("#,##0៛");

            //count
            // Retrieve the total number of records in the table
            SqlCommand countCommand = new SqlCommand("SELECT COUNT(*) FROM tbl_sales s inner join tbl_staffs st on s.sid = st.sid inner join tbl_type_payment tp on s.payment_type_id = tp.id where CONVERT(date, s.datetime) between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' and s.deleted_date is NULL;", ConnectionDb.cnn);
            ConnectionDb.cnn.Open();
            totalRecords = (int)countCommand.ExecuteScalar();

            // Calculate the number of pages required
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // Retrieve the records for the current page
            int offset = (pageNumber - 1) * pageSize;

            string query = "Select s.sale_id, s.datetime, s.invoice, s.subtotal_us, s.discount_invoice, s.grand_total_us, s.grand_total_kh, s.received_us, s.received_kh, s.change_kh, s.sid, st.staff_name, s.payment_type_id, tp.payment from tbl_sales s inner join tbl_staffs st on s.sid = st.sid inner join tbl_type_payment tp on s.payment_type_id = tp.id where CONVERT(date, s.datetime) between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' and s.deleted_date is NULL order by s.datetime OFFSET @Offset ROWS FETCH NEXT @pageSize ROWS ONLY;";
            SqlCommand cmd = new SqlCommand(query, ConnectionDb.cnn);
            cmd.Parameters.AddWithValue("@Offset", offset);
            cmd.Parameters.AddWithValue("@pageSize", pageSize);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.ClearSelection();
            ConnectionDb.cnn.Close();

            // Pagination
            lblPagination.Text = string.Format("Page: {0} / {1}", pageNumber, totalPages);
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pageNumber == totalPages) return;
            pageNumber++;
            LoadData();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (pageNumber <= 1) { return; }
            pageNumber--;
            LoadData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPreviewReport reportIncome = new frmPreviewReport();

            if (checkBoxDateFilter.Checked)
            {
                string query = "Select s.sale_id, s.datetime, s.invoice, s.subtotal_us, s.discount_invoice, s.grand_total_us, s.grand_total_kh, s.received_us, s.received_kh, s.change_kh, s.sid, st.staff_name, s.payment_type_id, tp.payment from tbl_sales s inner join tbl_staffs st on s.sid = st.sid inner join tbl_type_payment tp on s.payment_type_id = tp.id where CONVERT(date, s.datetime) between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' and s.deleted_date is NULL;";
                string parameter_date = "ចាប់ពីថ្ងៃ : " + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "    ដល់ : " + dateTimePicker2.Value.ToString("dd/MM/yyyy") + "   ដោយបុគ្គលិក: " + StaticData.StaffName;
                reportIncome.LoadDataByDateFilterIncome(query, parameter_date);
            }
            else
            {
                string param = "កាលបរិច្ឆេទ Print: " + DateTime.Now.ToString("dd/MM/yyyy") + "     ដោយបុគ្គលិក: " + StaticData.StaffName;
                reportIncome.LoadAllDataIncome(param);
            }
            reportIncome.ShowDialog();
        }

        ButtonPicture btnPic = new ButtonPicture();
        private void lblResfress_MouseDown(object sender, MouseEventArgs e)
        {
            btnPic.MouseAction(lblResfress, @"Pictures\reset_32px_3.png");
        }

        private void lblResfress_MouseEnter(object sender, EventArgs e)
        {
            btnPic.MouseAction(lblResfress, @"Pictures\reset_26px_1.png");
        }

        private void lblResfress_MouseLeave(object sender, EventArgs e)
        {
            btnPic.MouseAction(lblResfress, @"Pictures\reset_32px_3.png");
        }

        private void lblResfress_MouseMove(object sender, MouseEventArgs e)
        {
            btnPic.MouseAction(lblResfress, @"Pictures\reset_26px_1.png");
        }

        private void lblResfress_Click(object sender, EventArgs e)
        {
            if (checkBoxDateFilter.Checked)
            {
                LoadDataDateFilter();
            }
            else
            {
                LoadData();
            }
        }

        private void checkBoxDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDateFilter.Checked)
            {
                dateTimePicker1.Enabled= true;
                dateTimePicker2.Enabled= true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the current column is the "datetime" column
            if (dataGridView1.Columns[e.ColumnIndex].Name == "datetime")
            {
                // Check if the cell value is a DateTime
                if (e.Value is DateTime)
                {
                    // Format the cell value as "dd/MM/yyyy"
                    e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
            }
        }
    }//
}///
