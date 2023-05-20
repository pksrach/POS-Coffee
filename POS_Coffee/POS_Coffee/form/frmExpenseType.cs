using POS_Coffee.AlertMessage;
using POS_Coffee.cls;
using POS_Coffee.data.layer.dao;
using POS_Coffee.data.layer.dto;
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

namespace POS_Coffee.Subform
{
    public partial class frmExpenseType : Form
    {

        Confirm confirm;
        ExpenseTypeDto dto = new ExpenseTypeDto();
        ExpenseTypeDao dao = new ExpenseTypeDao();
        public frmExpenseType()
        {
            InitializeComponent();
        }

        private void focusText()
        {
            txtName.Focus();
            txtName.SelectAll();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            //check Textbox null
            if (txtName.Text.Trim() == "")
            {
                focusText();
                return;
            }

            confirm = new Confirm("តើអ្នកពិតជាចង់ រក្សាទុកមែនទេ?", "រក្សាទុក");
            confirm.ShowDialog();

            if (confirm.DialogResult == DialogResult.Yes)
            {
                try
                {
                    // Assign value into dto
                    dto.Type = txtName.Text.Trim();

                    //save data into db
                    if (btnSave.Text == "បង្កើតថ្មី")
                    {
                        if(dao.create(dto) == false)
                        {
                            Warning warning = new Warning("ទិន្នន័យបង្កើត បរាជ័យ, ព្យាយាមម្ដងទៀត", "បង្កើត ប្រភេទចំណាយ");
                            warning.ShowDialog();
                            return;
                        }
                    }
                    else if(btnSave.Text == "រក្សាទុក")
                    {
                        // Assign value into dto
                        dto.Id = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["colID"].Value);

                        // Update
                        if(dao.update(dto) == false)
                        {
                            Warning warning = new Warning("ទិន្នន័យកែប្រែ បរាជ័យ, ព្យាយាមម្ដងទៀត", "កែប្រែ ប្រភេទចំណាយ");
                            warning.ShowDialog();
                            return;
                        }
                    }
                    loadData();
                    clear();
                }
                catch (Exception ex)
                {
                    Warning warning = new Warning("ឈ្មោះជាន់គ្នា [" + ex + "] ព្យាយាមម្ដងទៀត", "បង្កើត ប្រភេទចំណាយ");
                    warning.ShowDialog();
                    return;
                }
            }
            else return;
        }

        private void clear()
        {
            txtName.Clear();
            txtName.Focus();

            dataGridView1.ClearSelection();
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridView1.Enabled = true;

            btnEdit.Text = "កែប្រែ";
            btnSave.Text = "បង្កើតថ្មី";
        }

        private void  loadData()
        {
            // DataPropertyName = "sid"; jea name column in db
            dataGridView1.Columns["colID"].DataPropertyName = "id";
            dataGridView1.Columns["colName"].DataPropertyName = "type";

            // Assign data from GetAllAvailable into datagridview after set value to columns
            dataGridView1.DataSource = dao.GetAllAvailable();
            clear();
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
                dto.Id = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["colID"].Value);

                // Delete
                if(dao.deleteSoft(dto) == false)
                {
                    Warning warning = new Warning("ទិន្នន័យលុប បរាជ័យ, ព្យាយាមម្ដងទៀត", "លុប ប្រភេទចំណាយ");
                    warning.ShowDialog();
                    return;
                }
                clear();
                loadData();
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
                    txtName.Text = row.Cells["colName"].Value.ToString().Trim();

                    Method method = new Method();
                    if (method.DisableTableWhenSelected(dataGridView1, btnEdit, btnSave) == false)
                    {
                        txtName.Clear();
                        txtName.Focus();
                        return;
                    }
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

        private void frmStaff_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void frmStaff_Shown(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }//
}///
