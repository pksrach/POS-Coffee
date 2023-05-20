using POS_Coffee.AlertMessage;
using POS_Coffee.cls;
using POS_Coffee.data.layer.dao;
using POS_Coffee.data.layer.dto;
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
    public partial class frmStaff : Form
    {

        Confirm confirm;
        StaffDao dao = new StaffDao();
        StaffDto dto = new StaffDto();
        public frmStaff()
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
                    dto.Staff_name = txtName.Text;
                    dto.Dob = dob.Value.Date;
                    dto.Address = txtAddress.Text;
                    dto.Phone_number = txtPhoneNumer.Text;
                    if (radioMale.Checked) dto.Gender = radioMale.Text;
                    else if (radioFemale.Checked) dto.Gender = radioFemale.Text;
                    else dto.Gender = radioOther.Text;

                    //save data into db
                    if (btnSave.Text == "បង្កើតថ្មី")
                    {
                        if(dao.create(dto) == false)
                        {
                            Warning warning = new Warning("ទិន្នន័យបង្កើត បរាជ័យ, ព្យាយាមម្ដងទៀត", "បង្កើតបុគ្គលិក");
                            warning.ShowDialog();
                            return;
                        }
                    }
                    else if(btnSave.Text == "រក្សាទុក")
                    {
                        // Assign value into dto
                        dto.Sid = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["colID"].Value);

                        // Update
                        if(dao.update(dto) == false)
                        {
                            Warning warning = new Warning("ទិន្នន័យកែប្រែ បរាជ័យ, ព្យាយាមម្ដងទៀត", "កែប្រែព័តមាន បុគ្គលិក");
                            warning.ShowDialog();
                            return;
                        }
                    }
                    loadData();
                    clear();
                }
                catch (Exception ex)
                {
                    Warning warning = new Warning("ឈ្មោះជាន់គ្នា ["+ex+"] ព្យាយាមម្ដងទៀត", "បង្កើតបុគ្គលិក");
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
            txtAddress.Clear();
            txtPhoneNumer.Clear();

            dataGridView1.ClearSelection();
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridView1.Enabled = true;

            btnEdit.Text = "កែប្រែ";
            btnSave.Text = "បង្កើតថ្មី";
        }

        private void  loadData()
        {
            // DataPropertyName = "sid"; jea name column in db
            dataGridView1.Columns["colID"].DataPropertyName = "sid";
            dataGridView1.Columns["colName"].DataPropertyName = "staff_name";
            dataGridView1.Columns["colGender"].DataPropertyName = "gender";
            dataGridView1.Columns["colDob"].DataPropertyName = "dob";
            dataGridView1.Columns["colPhoneNumber"].DataPropertyName = "phone_number";
            dataGridView1.Columns["colAddress"].DataPropertyName = "address";

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
                dto.Sid = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["colID"].Value);

                // Delete
                if(dao.deleteSofe(dto) == false)
                {
                    Warning warning = new Warning("ទិន្នន័យលុប បរាជ័យ, ព្យាយាមម្ដងទៀត", "លុប បុគ្គលិក");
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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtName.Text = row.Cells["colName"].Value.ToString();
                txtAddress.Text = row.Cells["colAddress"].Value.ToString();
                txtPhoneNumer.Text = row.Cells["colPhoneNumber"].Value.ToString();
                dob.Text = row.Cells["colDob"].Value.ToString();
                // Gender
                string value = row.Cells["colGender"].Value.ToString();
                if(value == "ប្រុស") radioMale.Checked= true;
                else if(value == "ស្រី") radioFemale.Checked= true;
                else radioOther.Checked= true;

                if (btnEdit.Text == "ត្រឡប់")
                {
                    dataGridView1.Enabled = true;
                    btnEdit.Text = "កែប្រែ";
                    btnSave.Text = "បង្កើតថ្មី";
                    clear();
                }
                else
                {
                    dataGridView1.Enabled = false;
                    btnEdit.Text = "ត្រឡប់";
                    btnSave.Text = "រក្សាទុក";
                    dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red;
                }
                focusText();
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
