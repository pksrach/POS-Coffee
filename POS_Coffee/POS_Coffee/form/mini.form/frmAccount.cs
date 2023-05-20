using POS_Coffee.AlertMessage;
using POS_Coffee.cls;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace POS_Coffee.Subform
{
    public partial class frmAccount : Form
    {
        Warning warning;

        public frmAccount()
        {
            InitializeComponent();
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

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtReceive_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCurrentPwd.Text == "") { txtCurrentPwd.Focus(); return; }
            else if(txtNewPass.Text == "") { txtNewPass.Focus(); return; }
            else if(txtConfirmPass.Text == "") { txtConfirmPass.Focus(); return; }
            else if(txtNewPass.Text != txtConfirmPass.Text)
            {
                warning = new Warning("លេខសម្ងាត់ថ្មីផ្ទៀងផ្ទាត់មិនត្រូវគ្នា ព្យាយាមម្ដងទៀត", "ប្ដូរលេខសម្ងាត់");
                warning.ShowDialog();
                return;
            }
            else
            {
                try {
                    string currentPwd = "";
                    SqlCommand cmd = new SqlCommand("Select user_pwd from tbl_user where sid = @sid and deleted_date is null", ConnectionDb.cnn);
                    cmd.Parameters.AddWithValue("@sid", StaticData.SID);
                    ConnectionDb.cnn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (!dr.Read())
                    {
                        warning = new Warning("User រកមិនឃើញ, ព្យាយាមម្ដងទៀត", "ទិន្នន័យរកមិនឃើញ");
                        warning.ShowDialog();
                        this.Close();
                    }
                    currentPwd = dr["user_pwd"].ToString();
                    dr.Close();

                    if(currentPwd != txtCurrentPwd.Text)
                    {
                        warning = new Warning("លេខសម្ងាត់កំពុងប្រើប្រាស់មិនត្រឹមត្រូវ, ព្យាយាមម្ដងទៀត", "ទិន្នន័យរកមិនឃើញ");
                        warning.ShowDialog();
                        txtCurrentPwd.SelectAll();
                        txtCurrentPwd.Focus();
                        ConnectionDb.cnn.Close();
                        return;
                    }

                    //Update password
                    cmd = new SqlCommand("Update tbl_user Set user_pwd = @pwd Where sid = @sid", ConnectionDb.cnn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@pwd", txtNewPass.Text);
                    cmd.Parameters.AddWithValue("@sid", StaticData.SID);
                    cmd.ExecuteNonQuery();
                    Information information = new Information("លេខសម្ងាត់ប្ដូរបានដោយជោគជ័យ", "ប្ដូរលេខសង្ងាត់");
                    information.ShowDialog();
                    ConnectionDb.cnn.Close();
                    this.Close();
                } catch(Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtCurrentPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNewPass.SelectAll();
                txtNewPass.Focus();
            }
        }

        private void txtNewPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtConfirmPass.SelectAll();
                txtConfirmPass.Focus();
            }
        }

        private void txtConfirmPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(null, null);
            }
        }

        private void txtCurrentPwd_MouseClick(object sender, MouseEventArgs e)
        {
            txtCurrentPwd.SelectAll();
        }
    }//
}
