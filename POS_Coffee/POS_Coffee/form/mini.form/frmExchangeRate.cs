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
    public partial class frmExchangeRate : Form
    {
        public frmExchangeRate()
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

        private void txtReceive_MouseClick(object sender, MouseEventArgs e)
        {
            txtExchange.SelectAll();
        }

        private void txtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                txtExchange.SelectAll();
                txtExchange.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtExchange.Text == "") txtExchange.Text = StaticData.ExchangeRate.ToString();
            else if (txtExchange.Text == currentValue) return;

            SqlCommand cmd = new SqlCommand("", ConnectionDb.cnn);
            cmd.CommandText = "Update tbl_exchange Set exchange_rate = @exchange";
            cmd.Parameters.AddWithValue("@exchange", txtExchange.Text);
            ConnectionDb.cnn.Open();
            cmd.ExecuteNonQuery();
            ConnectionDb.cnn.Close();

            StaticData.ExchangeRate = Convert.ToDouble(txtExchange.Text);

            Information information = new Information("ទិន្នន័យកែប្រែ ជោគជ័យ", "អត្រាប្ដូរប្រាក់");
            information.ShowDialog();
            this.Close();
        }

        private string currentValue;
        private void frmExchangeRate_Load(object sender, EventArgs e)
        {
            txtExchange.Text = StaticData.ExchangeRate.ToString();

            currentValue = txtExchange.Text;
        }
    }//
}
