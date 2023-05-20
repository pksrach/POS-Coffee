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
    public partial class frmReportExpense : Form
    {
      
        frmPreviewReport preview = new frmPreviewReport();
        public frmReportExpense()
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
            dataGridView1.Columns["colId"].DataPropertyName = "id";
            dataGridView1.Columns["colDatetime"].DataPropertyName = "created_date";
            dataGridView1.Columns["colTotal_us"].DataPropertyName = "total_us";
            dataGridView1.Columns["colTotal_kh"].DataPropertyName = "total_kh";
            dataGridView1.Columns["colCreated_by"].DataPropertyName = "created_by";
            dataGridView1.Columns["colStaff_name"].DataPropertyName = "staff_name";

            // Set the column to display currency values
            dataGridView1.Columns["colTotal_us"].DefaultCellStyle.Format = "c";
            dataGridView1.Columns["colTotal_kh"].DefaultCellStyle.Format = String.Format("#,##0៛");

            //count
            // Retrieve the total number of records in the table
            SqlCommand countCommand = new SqlCommand("SELECT COUNT(*) FROM tbl_expenses e inner join tbl_staffs st on e.created_by = st.sid where e.deleted_date is null;", ConnectionDb.cnn);
            ConnectionDb.cnn.Open();
            totalRecords = (int)countCommand.ExecuteScalar();

            // Calculate the number of pages required
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // Retrieve the records for the current page
            int offset = (pageNumber - 1) * pageSize;

            string query = "Select e.id, e.created_date, e.total_us, e.total_kh, e.created_by, st.staff_name from tbl_expenses e inner join tbl_staffs st on e.created_by = st.sid where e.deleted_date is null order by e.created_date desc OFFSET @Offset ROWS FETCH NEXT @pageSize ROWS ONLY;";
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
            dataGridView1.Columns["colId"].DataPropertyName = "id";
            dataGridView1.Columns["colDatetime"].DataPropertyName = "created_date";
            dataGridView1.Columns["colTotal_us"].DataPropertyName = "total_us";
            dataGridView1.Columns["colTotal_kh"].DataPropertyName = "total_kh";
            dataGridView1.Columns["colCreated_by"].DataPropertyName = "created_by";
            dataGridView1.Columns["colStaff_name"].DataPropertyName = "staff_name";

            // Set the column to display currency values
            dataGridView1.Columns["colTotal_us"].DefaultCellStyle.Format = "c";
            dataGridView1.Columns["colTotal_kh"].DefaultCellStyle.Format = String.Format("#,##0៛");
            
            //count
            // Retrieve the total number of records in the table
            SqlCommand countCommand = new SqlCommand("SELECT COUNT(*) FROM tbl_expenses e inner join tbl_staffs st on e.created_by = st.sid where e.deleted_date is null;", ConnectionDb.cnn);
            ConnectionDb.cnn.Open();
            totalRecords = (int)countCommand.ExecuteScalar();

            // Calculate the number of pages required
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // Retrieve the records for the current page
            int offset = (pageNumber - 1) * pageSize;

            string query = "Select e.id, e.created_date, e.total_us, e.total_kh, e.created_by, st.staff_name from tbl_expenses e inner join tbl_staffs st on e.created_by = st.sid  where CONVERT(date, e.created_date) between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' and e.deleted_date is null order by e.created_date desc OFFSET @Offset ROWS FETCH NEXT @pageSize ROWS ONLY;";
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
            if (dataGridView1.SelectedRows.Count == 0) return;

            string param = "កាលបរិច្ឆេទ Print: " + DateTime.Now.ToString("dd/MM/yyyy") + "     ដោយបុគ្គលិក: " + StaticData.StaffName;
            preview.LoadDataExpenseDetailByMasterId(dataGridView1.SelectedRows[0].Cells["colId"].Value.ToString(), param);
            preview.ShowDialog();
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
 
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check when no data and try to double click it will be error
            if (dataGridView1.Rows.IndexOf(dataGridView1.CurrentRow) < 0) return;

            frmReportExpenseDetail frmDetail = new frmReportExpenseDetail(this.dataGridView1.SelectedRows[0].Cells["colId"].Value.ToString());
            frmDetail.ShowDialog();
        }

        private void btnPreviewPrint_Click(object sender, EventArgs e)
        {
            if(checkBoxDateFilter.Checked)
            {
                string query = "Select e.id, e.created_date, e.total_us, e.total_kh, e.created_by, st.staff_name from tbl_expenses e inner join tbl_staffs st on e.created_by = st.sid  where CONVERT(date, e.created_date) between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' and e.deleted_date is null";
                string parameter_date = "ចាប់ពីថ្ងៃ : " + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "    ដល់ : " + dateTimePicker2.Value.ToString("dd/MM/yyyy") + "   ដោយបុគ្គលិក: " + StaticData.StaffName;
                preview.LoadDataByDateFilterExpense(query, parameter_date);
            }
            else
            {
                string param = "កាលបរិច្ឆេទ Print: " + DateTime.Now.ToString("dd/MM/yyyy") + "     ដោយបុគ្គលិក: " + StaticData.StaffName;
                preview.LoadAllDataExpense(param);
            }
            preview.ShowDialog();
        }
    }//
}///
