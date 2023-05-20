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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Coffee.Subform
{
    public partial class frmUser : Form
    {

        Confirm confirm;
        UserDao dao = new UserDao();
        UserDto dto = new UserDto();
        public frmUser()
        {
            InitializeComponent();
        }

        private void focusText()
        {
            txtUsername.Focus();
            txtUsername.SelectAll();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            //check Textbox null
            if (txtUsername.Text.Trim() == "")
            {
                focusText();
                return;
            }else if(txtPwd.Text.Trim() == "")
            {
                txtPwd.Focus();
                return;
            }

            confirm = new Confirm("តើអ្នកពិតជាចង់ រក្សាទុកមែនទេ?", "រក្សាទុក");
            confirm.ShowDialog();

            if (confirm.DialogResult == DialogResult.Yes)
            {
                try
                {
                    // Assign value into dto
                    dto.Sid = Convert.ToInt64(cboStaff.SelectedValue);
                    dto.Username = txtUsername.Text;
                    dto.Password = txtPwd.Text;
                    if (radioCashier.Checked) dto.Role = radioCashier.Text;
                    else if (radioGeneral.Checked) dto.Role = radioGeneral.Text;
                    else dto.Role = radioAdmin.Text;

                    //save data into db
                    if (btnSave.Text == "បង្កើតថ្មី")
                    {
                        if (cboStaff.Text == "")
                        {
                            Warning warning = new Warning("ឈ្មោះបុគ្គលិករកមិនឃើញ, ព្យាយាមម្ដងទៀត", "ជ្រើសរើសបុគ្គលិក");
                            warning.ShowDialog();
                            return;
                        }

                        if (dao.CheckDataExists(txtUsername.Text.Trim()) == true)
                        {
                            Warning warning = new Warning("ឈ្មោះអ្នកប្រើប្រាស់មានរួចហើយ, ព្យាយាមម្ដងទៀត", "ទិន្នន័យមានរួចរាល់");
                            warning.ShowDialog();
                            txtUsername.SelectAll();
                            txtUsername.Focus();
                            return;
                        }

                        // Assign who is create this user ?
                        dto.CreatedBy = StaticData.SID;

                        // Create
                        if (dao.create(dto) == false)
                        {
                            Warning warning = new Warning("ទិន្នន័យបង្កើត បរាជ័យ, ព្យាយាមម្ដងទៀត", "បង្កើតបុគ្គលិក");
                            warning.ShowDialog();
                            return;
                        }
                    }
                    else if(btnSave.Text == "រក្សាទុក")
                    {
                        // Check username
                        if (dao.CheckDataExists(txtUsername.Text) == true && txtUsername.Text != currentUsername)
                        {
                            Warning warning = new Warning("ឈ្មោះអ្នកប្រើប្រាស់មានរួចហើយ, ព្យាយាមម្ដងទៀត", "ទិន្នន័យមានរួចរាល់");
                            warning.ShowDialog();
                            txtUsername.SelectAll();
                            txtUsername.Focus();
                            return;
                        }

                        // Assign value into dto
                        dto.Uid = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["colUid"].Value);
                        // Assing who is update this user ?
                        dto.UpdatedBy = StaticData.SID;

                        // Update
                        if (dao.update(dto) == false)
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
                    Warning warning = new Warning("មានបញ្ហា ["+ex+"] ព្យាយាមម្ដងទៀត", "បញ្ហា System");
                    warning.ShowDialog();
                    return;
                }
            }
            else return;
        }

        private void clear()
        {
            txtUsername.Clear();
            txtUsername.Focus();
            txtPwd.Clear();
            currentUsername = "";

            dataGridView1.ClearSelection();
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridView1.Enabled = true;

            btnEdit.Text = "កែប្រែ";
            btnSave.Text = "បង្កើតថ្មី";
        }

        private void  loadData()
        {
            // DataPropertyName = "sid"; jea name column in db
            dataGridView1.Columns["colUid"].DataPropertyName = "uid";
            dataGridView1.Columns["colUsername"].DataPropertyName = "user_name";
            dataGridView1.Columns["colPwd"].DataPropertyName = "user_pwd";
            dataGridView1.Columns["colRole"].DataPropertyName = "role";
            dataGridView1.Columns["colStaff"].DataPropertyName = "staff_name";

            // Assign data from GetAllAvailable into datagridview after set value to columns
            dataGridView1.DataSource = dao.GetAllAvailable();

            // Load staff (combo box)
            loadStaff();

            // Clear textbox
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
                dto.Uid = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["colUid"].Value);
                dto.UpdatedBy = StaticData.SID;

                // Delete
                if(dao.deleteSoft(dto) == false)
                {
                    Warning warning = new Warning("ទិន្នន័យលុប បរាជ័យ, ព្យាយាមម្ដងទៀត", "លុប User");
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

        private string currentUsername="";

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //check Textbox and selection table is null
            if (dataGridView1.SelectedRows.Count > 0)
            {
                currentUsername = row.Cells["colUsername"].Value.ToString();
                txtUsername.Text = row.Cells["colUsername"].Value.ToString();
                txtPwd.Text = row.Cells["colPwd"].Value.ToString();
                // Role
                string value = row.Cells["colRole"].Value.ToString();
                if(value == "Cashier") radioCashier.Checked= true;
                else if(value == "General") radioGeneral.Checked= true;
                else radioAdmin.Checked= true;

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

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void frmStaff_Shown(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void loadStaff()
        {
            LoadData load = new LoadData();
            string query = "select s.sid, staff_name, uid from tbl_staffs s left outer join tbl_user u on s.sid = u.sid where u.deleted_date is null and s.deleted_date is null and u.sid is null";
            load.ComboBoxLoad(cboStaff, query, "staff_name", "sid");
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }//
}///
