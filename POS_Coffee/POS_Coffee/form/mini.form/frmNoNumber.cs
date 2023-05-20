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
    public partial class frmNoNumber : Form
    {
        Warning warning;
        Confirm confirm;
        public frmNoNumber()
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

        private void keyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers and decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        private void keyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("KeyUp");
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(null, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           if(txtNoCount.Text == "") { txtNoCount.Focus(); return; }
           else if(txtMaxNo.Text == "") { txtMaxNo.Focus(); return; }

            confirm = new Confirm("តើអ្នកពិតជាចង់ រក្សាទុកមែនទេ?", "រក្សាទុកទិន្នន័យ");
            if(confirm.ShowDialog() == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("Update tbl_no_number set no_count = @no_count, max_num = @max_num", ConnectionDb.cnn);
                cmd.Parameters.AddWithValue("@no_count", txtNoCount.Text);
                cmd.Parameters.AddWithValue("@max_num", txtMaxNo.Text);
                ConnectionDb.cnn.Open();
                cmd.ExecuteNonQuery();
                ConnectionDb.cnn.Close();

                LoadData();
            }
        }

        private void ResetNumber()
        {
            SqlCommand cmd = new SqlCommand("Update tbl_no_number set no_count = 1", ConnectionDb.cnn);
            ConnectionDb.cnn.Open();
            cmd.ExecuteNonQuery();
            ConnectionDb.cnn.Close();

            LoadData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            confirm = new Confirm("តើអ្នកចង់ កំណត់ឡើងវិញមែនទេ?", "Reset");

            if(confirm.ShowDialog() == DialogResult.Yes)
            {
                ResetNumber();
            }
        }

        private void LoadData()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from tbl_no_number", ConnectionDb.cnn);
                ConnectionDb.cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    warning = new Warning("ទិន្នន័យរកមិនឃើញ", "បង្ហាញទិន្នន័យ");
                    warning.ShowDialog();
                    ConnectionDb.cnn.Close();
                    return;
                }

                txtNoCount.Text = dr["no_count"].ToString();
                txtMaxNo.Text = dr["max_num"].ToString();

                dr.Close();
                ConnectionDb.cnn.Close();
            }
            catch (Exception ex)
            {
                warning = new Warning("មានបញ្ហា " + ex.Message, "បង្ហាញទិន្នន័យ");
                warning.ShowDialog();
                ConnectionDb.cnn.Close();
                return;
            }
        }

        private void frmNoNumber_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }//
}
