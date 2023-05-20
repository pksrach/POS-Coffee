using POS_Coffee.AlertMessage;
using POS_Coffee.cls;
using POS_Coffee.data.layer.dao;
using POS_Coffee.data.layer.dto;
using POS_Coffee.static_data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace POS_Coffee.Subform
{
    public partial class frmExpense : Form
    {

        Confirm confirm;
        ExpenseDto dto = new ExpenseDto();
        ExpenseDao dao = new ExpenseDao();
        LoadData load = new LoadData();

        double totalUs = 0;
        long totalKh = 0;

        public frmExpense()
        {
            InitializeComponent();
        }

        private void focusText()
        {
            txtTotalUs.Focus();
            txtTotalUs.SelectAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
            {
                Warning warning = new Warning("គ្មានទិន្នន័យ សូមបញ្ចូលទិន្នន័យ", "រក្សាទុក");
                warning.ShowDialog();
                return;
            }

            confirm = new Confirm("តើអ្នកពិតជាចង់ រក្សាទុកមែនទេ?", "រក្សាទុក");
            confirm.ShowDialog();

            if (confirm.DialogResult == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        totalUs += Convert.ToDouble(row.Cells["colTotalUs"].Value);
                        totalKh += Convert.ToInt64(row.Cells["colTotalKh"].Value);
                    }

                    // Assign value into dto
                    dto.Total_us = totalUs;
                    dto.Total_kh = totalKh;
                    dto.Created_by = StaticData.SID;
                    dto.Created_date = dateTimePicker1.Value;

                    //save data into db
                    if (dao.create(dto, dataGridView1) == false)
                    {
                        Warning warning = new Warning("ទិន្នន័យបង្កើត បរាជ័យ, ព្យាយាមម្ដងទៀត", "បង្កើត ប្រភេទចំណាយ");
                        warning.ShowDialog();
                        return;
                    }
                    loadData();
                    clear();
                    dataGridView1.Rows.Clear();
                    totalUs = 0; 
                    totalKh = 0;
                }
                catch (Exception ex)
                {
                    Warning warning = new Warning("មានបញ្ហា [" + ex + "] ព្យាយាមម្ដងទៀត", "បង្កើត ការចំណាយ");
                    warning.ShowDialog();
                    return;
                }
            }
            else return;
        }

        private void clear()
        {
            txtTotalUs.Clear();
            txtTotalUs.Focus();
            txtTotalKh.Clear();
            txtDescription.Clear();

            dataGridView1.ClearSelection();
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridView1.Enabled = true;

            btnEdit.Text = "កែប្រែ";
            btnAddNew.Text = "បញ្ចូលថ្មី";
            btnSave.Visible = true;
        }

        private void  loadData()
        {
            // DataPropertyName = "sid"; jea name column in db
            /*dataGridView1.Columns["colID"].DataPropertyName = "id";
            dataGridView1.Columns["colName"].DataPropertyName = "type";*/

            // Assign data from GetAllAvailable into datagridview after set value to columns
            /*dataGridView1.DataSource = dao.GetAllAvailable();
            clear();*/
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //check Textbox and selection table is null
           if(dataGridView1.SelectedRows.Count <= 0)
            {
                focusText();
                return;
            }

            confirm = new Confirm("តើអ្នកពិតជាចង់ លុបទិន្នន័យនេះមែនទេ?", "លុបទិន្នន័យ");
            confirm.ShowDialog();
            if (confirm.DialogResult == DialogResult.Yes)
            {
                // Get the selected rows
                DataGridViewSelectedRowCollection selectedRows = dataGridView1.SelectedRows;

                // Loop through the selected rows and remove them
                foreach (DataGridViewRow row in selectedRows)
                {
                    dataGridView1.Rows.Remove(row);
                }



                clear();
            }
        }

        DataGridViewRow row;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                row = dataGridView1.Rows[e.RowIndex];
            }
            else
                dataGridView1.ClearSelection();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //check Textbox and selection table is null
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    txtTotalUs.Text = row.Cells["colTotalUs"].Value.ToString();
                    txtTotalKh.Text = row.Cells["colTotalKh"].Value.ToString();
                    cboExpenseType.SelectedValue = row.Cells["colExpenseTypeId"].Value;
                    txtDescription.Text = row.Cells["colDescription"].Value.ToString();

                    Method method = new Method();
                    if (method.DisableTableWhenSelected(dataGridView1, btnEdit, btnAddNew) == false)
                    {
                        clear();
                        return;
                    }
                    btnSave.Visible = false;
                    focusText();
                }
            }
            catch (Exception ex)
            {
                Warning warning = new Warning("មានបញ្ហា " + ex + " សូមព្យាយាមម្ដងទៀត", "បញ្ហា Select ទិន្នន័យ");
                warning.ShowDialog();
            }

        }

        private void lblResfress_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                string path = @"Pictures\reset_32px_3.png";
                lblResfress.Image = Image.FromFile(path);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void lblResfress_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                string path = @"Pictures\reset_26px_1.png";
                lblResfress.Image = Image.FromFile(path);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void lblResfress_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                string path = @"Pictures\reset_32px_3.png";
                lblResfress.Image = Image.FromFile(path);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void lblResfress_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                string path = @"Pictures\reset_26px_1.png";
                lblResfress.Image = Image.FromFile(path);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void lblResfress_Click(object sender, EventArgs e)
        {
            clear();
            loadData();
            btnEdit.Text = "កែប្រែ";
            btnSave.Text = "បង្កើតថ្មី";
        }
        
        private void loadExpenseType()
        {
            load.ComboBoxLoad(cboExpenseType, "select id, type from tbl_expense_type where deleted_date is null", "type", "id");
        }

        private void frmStaff_Load(object sender, EventArgs e)
        {
            loadData();
            loadExpenseType();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void frmStaff_Shown(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dataGridView1.ClearSelection();
            txtTotalUs.Focus();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            //if (Method.isEmptyTextBoxCurrency(txtTotalUs, txtTotalKh) == true) return;
            if (txtTotalUs.Text == "" && txtTotalKh.Text == "")
            {
                Warning warning = new Warning("សូមបញ្ចូលទិន្នន័យ", "គ្មានទិន្នន័យ");
                warning.ShowDialog();
                return;
            }
            if (txtTotalUs.Text == "") txtTotalUs.Text = "0";
            if (txtTotalKh.Text == "") txtTotalKh.Text = "0";
            else if (txtTotalKh.Text != "" && txtTotalKh.Text != "0" && Convert.ToInt64(txtTotalKh.Text) < 100)
            {
                Warning warning = new Warning("ប្រាក់រៀលត្រូវតែ ធំជាងឬស្មើរ 100៛", "បញ្ចូលទិន្នន័យ");
                warning.ShowDialog();
                return;
            }

            if(btnAddNew.Text == "បញ្ចូលថ្មី")
            {
                // Get the row index where you want to assign the value
                int rowIndex = dataGridView1.Rows.Add();

                // Get the column index where you want to assign the value by using the column header name
                int colIndex2 = dataGridView1.Columns["colExpenseTypeId"].Index;
                int colIndex3 = dataGridView1.Columns["colExpenseType"].Index;
                int colIndex4 = dataGridView1.Columns["colTotalUs"].Index;
                int colIndex5 = dataGridView1.Columns["colTotalKh"].Index;
                int colIndex6 = dataGridView1.Columns["colDescription"].Index;

                // Set the value of the cell using the row and column index
                dataGridView1.Rows[rowIndex].Cells[colIndex2].Value = cboExpenseType.SelectedValue;
                dataGridView1.Rows[rowIndex].Cells[colIndex3].Value = cboExpenseType.Text;
                dataGridView1.Rows[rowIndex].Cells[colIndex4].Value = txtTotalUs.Text;
                dataGridView1.Rows[rowIndex].Cells[colIndex5].Value = txtTotalKh.Text;
                dataGridView1.Rows[rowIndex].Cells[colIndex6].Value = txtDescription.Text;

            }else if(btnAddNew.Text == "រក្សាទុក")
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                selectedRow.Cells["colTotalUs"].Value = txtTotalUs.Text;
                selectedRow.Cells["colTotalKh"].Value = txtTotalKh.Text;
                selectedRow.Cells["colExpenseTypeId"].Value = cboExpenseType.SelectedValue;
                selectedRow.Cells["colExpenseType"].Value = cboExpenseType.Text;
                selectedRow.Cells["colDescription"].Value = txtDescription.Text;

            }

            clear();
        }

        private void txtTotalUs_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers and decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            // Allow only one decimal point
            else if (e.KeyChar == '.' && (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == 8 && txtTotalUs.Text == "0")
            {
                txtTotalUs.SelectAll();
            }
        }

        private void txtTotalKh_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers and decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            // Allow only one decimal point
            else if (e.KeyChar == '.' && (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == 8 && txtTotalKh.Text == "0")
            {
                txtTotalKh.SelectAll();
            }
        }
    }//
}///
