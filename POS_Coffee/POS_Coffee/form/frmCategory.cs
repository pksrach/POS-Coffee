using POS_Coffee.AlertMessage;
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
    public partial class frmCategory : Form
    {
        ConfigTable configTable = new ConfigTable();
        public frmCategory()
        {
            InitializeComponent();
            
        }

        private void focusText()
        {
            txtCategoryName.Focus();
            txtCategoryName.SelectAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check Textbox null
            if (txtCategoryName.Text.Trim() == "")
            {
                focusText();
                return;
            }

            Confirm confirm = new Confirm("តើអ្នកពិតជាចង់ រក្សាទុកមែនទេ?", "រក្សាទុក");
            confirm.ShowDialog();

            if (confirm.DialogResult == DialogResult.Yes)
            {
                try
                {
                    //check data in db exists data or not
                    string data = "Select category_name from tbl_category where status = 1 and category_name = '" + txtCategoryName.Text.Trim() + "'";
                    Check check = new Check();
                    string cataegory_name = "";
                    if (check.CheckExistsData(data, cataegory_name, "category_name") == txtCategoryName.Text)
                    {
                        Warning warning = new Warning("ទិន្នន័យនេះ មានរួចរាល់ហើយ!", "បំរាម");
                        warning.ShowDialog();
                        txtCategoryName.Focus();
                        txtCategoryName.SelectAll();
                        ConnectionDb.cnn.Close();
                        return;
                    }
                    //end of check data 

                    //save data into db
                    SqlCommand cmd = new SqlCommand("", ConnectionDb.cnn);
                    ConnectionDb.cnn.Open();
                    if (btnSave.Text == "បង្កើតថ្មី")
                    {
                        cmd.CommandText = "Insert into tbl_category(category_name) values(N'" + txtCategoryName.Text.Trim() + "')";
                        cmd.ExecuteNonQuery();
                    }
                    else if(btnSave.Text == "រក្សាទុក")
                    {
                        cmd.CommandText = "Update tbl_category set category_name=N'" + txtCategoryName.Text.Trim() + "' Where cid = '" + lblCID.Text + "' ";
                        cmd.ExecuteNonQuery();
                    }
                    ConnectionDb.cnn.Close();

                    txtCategoryName.Clear();
                    txtCategoryName.Focus();
                    laodData();
                    btnEdit.Text = "កែប្រែ";
                    btnSave.Text = "បង្កើតថ្មី";
                }
                catch (Exception ex)
                {
                    throw  new Exception(ex.Message);
                }
            }
            else return;
        }

        private void  laodData()
        {
            LoadData loadData = new LoadData();
            loadData.loadData(dataGridView1, "Select cid, category_name from tbl_category where status = 1", 0, 1);

            configTable.HeaderFont = "Kh Preyveng";
            configTable.HeaderSize = 12;
            configTable.RowSize = 12;
            configTable.RowsFont = "Kh Preyveng";
            configTable.DisplayTable(dataGridView1);

            //clear selection must be under code process
            dataGridView1.ClearSelection();
            dataGridView1.Enabled = true;
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            laodData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //check Textbox and selection table is null
           if(dataGridView1.SelectedRows.Count <= 0)
            {
                focusText();
                return;
            }

            Confirm confirm = new Confirm("តើអ្នកពិតជាចង់ លុបទិន្នន័យនេះមែនទេ?", "លុបទិន្នន័យ");
            confirm.ShowDialog();
            if (confirm.DialogResult == DialogResult.Yes)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("", ConnectionDb.cnn);
                    cmd.CommandText = "Update tbl_category set status = 0 where cid = " + Convert.ToInt64(lblCID.Text);
                    ConnectionDb.cnn.Open();
                    cmd.ExecuteNonQuery();
                    ConnectionDb.cnn.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                laodData();
                txtCategoryName.Clear();
                txtCategoryName.Focus();
            }
            

        }
        DataGridViewRow row;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                row = dataGridView1.Rows[e.RowIndex];
                lblCID.Text = row.Cells["colCID"].Value.ToString();
            }
            else
                dataGridView1.ClearSelection();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //check Textbox and selection table is null
            if (dataGridView1.SelectedRows.Count > 0)
            {
                lblCID.Text = row.Cells["colCID"].Value.ToString();
                txtCategoryName.Text = row.Cells["colCategoryName"].Value.ToString();
                btnSave.Text = "រក្សាទុក";
                focusText();

                Method method = new Method();
                if(method.DisableTableWhenSelected(dataGridView1, btnEdit, btnSave) == false)
                {
                    txtCategoryName.Clear();
                    txtCategoryName.Focus();
                }

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
            laodData();
        }
    }//
}///
