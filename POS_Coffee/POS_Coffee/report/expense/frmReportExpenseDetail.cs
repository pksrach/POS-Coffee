using POS_Coffee.cls;
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
    public partial class frmReportExpenseDetail : Form
    {
        string masterId = string.Empty;
        public frmReportExpenseDetail(string masterId)
        {
            InitializeComponent();
            this.masterId = masterId;
        }

        private void frmReportExpenseDetail_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            // DataPropertyName = "sid"; jea name column in db
            dataGridView1.Columns["colId"].DataPropertyName = "id";
            dataGridView1.Columns["colMasterId"].DataPropertyName = "master_id";
            dataGridView1.Columns["colType_id"].DataPropertyName = "type_id";
            dataGridView1.Columns["colTypeExpense"].DataPropertyName = "type";
            dataGridView1.Columns["colTotal_us"].DataPropertyName = "total_us";
            dataGridView1.Columns["colTotal_kh"].DataPropertyName = "total_kh";
            dataGridView1.Columns["colDescription"].DataPropertyName = "description";

            // Set the column to display currency values
            dataGridView1.Columns["colTotal_us"].DefaultCellStyle.Format = "c";
            dataGridView1.Columns["colTotal_kh"].DefaultCellStyle.Format = String.Format("#,##0៛");

            SqlCommand cmd = new SqlCommand("Select ed.id, ed.master_id, ed.type_id, et.type, ed.total_us, ed.total_kh, ed.description from tbl_expense_details ed inner join tbl_expense_type et on ed.type_id = et.id where ed.master_id = @master_id and et.deleted_date is null", ConnectionDb.cnn);
            cmd.Parameters.AddWithValue("@master_id", masterId);
            ConnectionDb.cnn.Open();
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            ConnectionDb.cnn.Close();

            dataGridView1.ClearSelection();            
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void frmReportExpenseDetail_Shown(object sender, EventArgs e)
        {
            //MessageBox.Show("Master ID: " + masterId);
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
    }
}
