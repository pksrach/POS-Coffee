using POS_Coffee.AlertMessage;
using POS_Coffee.cls;
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
    public partial class frmTable : Form
    {

        Confirm confirm;
        public frmTable()
        {
            InitializeComponent();
        }

        private void focusText()
        {
            txtTable.Focus();
            txtTable.SelectAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check Textbox null
            if (txtTable.Text.Trim() == "")
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
                    //check data in db exists data or not
                    string data = "Select table_name from tbl_tables where deleted_date is null and table_name = '" + txtTable.Text.Trim() + "'";
                    Check check = new Check();
                    string name = "";
                    if (check.CheckExistsData(data, name, "table_name") == txtTable.Text)
                    {
                        Warning warning = new Warning("ទិន្នន័យនេះ មានរួចរាល់ហើយ!", "បំរាម");
                        warning.ShowDialog();
                        txtTable.Focus();
                        txtTable.SelectAll();
                        ConnectionDb.cnn.Close();
                        return;
                    }
                    //end of check data 

                    //save data into db
                    SqlCommand cmd = new SqlCommand("", ConnectionDb.cnn);
                    ConnectionDb.cnn.Open();
                    if (btnSave.Text == "បង្កើតថ្មី")
                    {
                        cmd.CommandText = "Insert into tbl_tables(table_name) values(N'" + txtTable.Text.Trim() + "')";
                        cmd.ExecuteNonQuery();
                    }
                    else if(btnSave.Text == "រក្សាទុក")
                    {
                        cmd.CommandText = "Update tbl_tables set table_name=N'" + txtTable.Text.Trim() + "' Where tid = '" + lblId.Text + "' ";
                        cmd.ExecuteNonQuery();
                    }
                    ConnectionDb.cnn.Close();

                    txtTable.Clear();
                    txtTable.Focus();
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
            loadData.loadData(dataGridView1, "Select tid, table_name from tbl_tables where deleted_date is null", 0, 1);

            //clear selection must be under code process
            dataGridView1.ClearSelection();
            dataGridView1.Enabled = true;
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            // Load data
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

            confirm = new Confirm("តើអ្នកពិតជាចង់ លុបទិន្នន័យនេះមែនទេ?", "លុបទិន្នន័យ");
            confirm.ShowDialog();
            if (confirm.DialogResult == DialogResult.Yes)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("", ConnectionDb.cnn);
                    cmd.CommandText = "Update tbl_tables set deleted_date = getdate(), deleted_by=" + StaticData.SID + " where tid = " + Convert.ToInt64(lblId.Text);
                    ConnectionDb.cnn.Open();
                    cmd.ExecuteNonQuery();
                    ConnectionDb.cnn.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                laodData();
                txtTable.Clear();
                txtTable.Focus();
            }
            

        }
        DataGridViewRow row;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                row = dataGridView1.Rows[e.RowIndex];
                lblId.Text = row.Cells["colID"].Value.ToString();
            }
            else
                dataGridView1.ClearSelection();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //check Textbox and selection table is null
            if (dataGridView1.SelectedRows.Count > 0)
            {
                lblId.Text = row.Cells["colID"].Value.ToString();
                txtTable.Text = row.Cells["colName"].Value.ToString();
                btnSave.Text = "រក្សាទុក";
                focusText();

                Method method = new Method();
                if (method.DisableTableWhenSelected(dataGridView1, btnEdit, btnSave) == false)
                {
                    txtTable.Clear();
                    txtTable.Focus();
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
            lblId.Text = "";
            txtTable.Focus();
            txtTable.SelectAll();
            laodData();
            btnEdit.Text = "កែប្រែ";
            btnSave.Text = "បង្កើតថ្មី";
        }
    }//
}///
