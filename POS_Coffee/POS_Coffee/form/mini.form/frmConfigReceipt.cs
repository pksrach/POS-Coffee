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
    public partial class frmConfigReceipt : Form
    {
        Warning warning;
        public frmConfigReceipt()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtHeader.Text == "") { txtHeader.Focus(); return; }
            else if(txtSubtitle.Text == "") { txtSubtitle.Focus(); return; }
            else if(txtFooter.Text == "") { txtFooter.Focus(); return; }
            else
            {
                try {
                    //Update password
                    SqlCommand cmd = new SqlCommand("Update tbl_config_receipt Set header = @header, subtitle=@subtitle, footer = @footer", ConnectionDb.cnn);
                    cmd.Parameters.AddWithValue("@header", txtHeader.Text);
                    cmd.Parameters.AddWithValue("@subtitle", txtSubtitle.Text);
                    cmd.Parameters.AddWithValue("@footer", txtFooter.Text);
                    ConnectionDb.cnn.Open();
                    cmd.ExecuteNonQuery();
                    ConnectionDb.cnn.Close();

                    LoadData();
                    Information information = new Information("ព័តមានកែប្រែបានជោគជ័យ", "កែប្រែព័តមាន Receipt");
                    information.ShowDialog();
                    this.Close();
                } catch(Exception ex) {
                    Warning warning = new Warning("កែប្រែព័តមាន ត្រូវបានបរាជ័យ, ព្យាយាមម្ដងទៀត " + ex.Message​, "កែប្រែព័តមាន Receipt");
                    warning.ShowDialog();
                    ConnectionDb.cnn.Close();
                }
            }
        }

        private void txtCurrentPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSubtitle.SelectAll();
                txtSubtitle.Focus();
            }
        }

        private void txtNewPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFooter.SelectAll();
                txtFooter.Focus();
            }
        }

        private void LoadData()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from tbl_config_receipt", ConnectionDb.cnn);
                ConnectionDb.cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    warning = new Warning("ទិន្នន័យរកមិនឃើញ, ព្យាយាមម្ដងទៀត", "កែប្រែព័តមាន");
                    warning.ShowDialog();
                    ConnectionDb.cnn.Close();
                    this.Close();
                }

                txtHeader.Text = dr["header"].ToString();
                txtSubtitle.Text = dr["subtitle"].ToString();
                txtFooter.Text = dr["footer"].ToString();
                dr.Close();
            }
            catch (Exception ex)
            {
                warning = new Warning("មាន​បញ្ហា " + ex.Message + ", ព្យាយាមម្ដងទៀត", "កែប្រែព័តមាន");
                warning.ShowDialog();
            }
            finally
            {
                ConnectionDb.cnn.Close();
            }
        }

        private void frmConfigReceipt_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }//
}///
