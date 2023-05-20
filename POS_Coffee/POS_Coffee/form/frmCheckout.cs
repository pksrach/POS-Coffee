using POS_Coffee.AlertMessage;
using POS_Coffee.cls;
using POS_Coffee.data.layer.dto;
using POS_Coffee.static_data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace POS_Coffee.Subform
{
    public partial class frmCheckout : Form
    {
        DataGridView dgv;
        LoadData load = new LoadData();

        public frmCheckout(DataGridView dgv)
        {
            InitializeComponent();
            this.dgv = dgv;
        }

        public frmCheckout()
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

        private void loadTypePayment()
        {
            cboPaymentType.Items.Clear();
            load.ComboBoxLoad(cboPaymentType, "select id, payment from tbl_type_payment where deleted_date is null", "payment", "id");

            if (cboPaymentType.Items == null)
            {
                // ComboBox has a null value must set DataSource null
                cboPaymentType.DataSource = null;
                // Add value into items
                cboPaymentType.Items.Add("ជ្រើសរើស");
                cboPaymentType.SelectedIndex = 0;
            }
            else
            {
                // Cast DataSource to DataTable
                DataTable dataTable = (DataTable)cboPaymentType.DataSource;

                // Create new DataRow to add or insert new value
                DataRow newRow = dataTable.NewRow();
                newRow["payment"] = "ជ្រើសរើស";
                // Insert value to DataTable
                dataTable.Rows.InsertAt(newRow, 0);

                // Re-Bind DataSource to Combobox
                cboPaymentType.DataSource = dataTable;
                cboPaymentType.DisplayMember = "payment";
                cboPaymentType.ValueMember = "id";

                // Start SelectValue On Index 0
                cboPaymentType.SelectedIndex = 0;
            }
        }

        private void frmCheckout_Load(object sender, EventArgs e)
        {
            if (lblOrderInvoice.Text.Contains("INV"))
            {
                lblInvoice.Text = lblOrderInvoice.Text;
            }
            else
            {
                GenerateInvoice.LoadingInvoiceNumber();
                lblInvoice.Text = GenerateInvoice.NextInvoiceNumber();
            }
            
            processCalculate();
        }

        private void txtReceiveTextChanged(object sender, EventArgs e)
        {
            if (txtReceiveUS.Text == "")
            {
                txtReceiveUS.Text = "$0";
                txtReceiveUS.SelectAll();
                txtReceiveUS.Focus();
                return;
            }

            if(txtReceiveUS.Text == ".")
            {
                txtReceiveUS.Text = "$0.";
            }
            if (txtReceiveUS.Text.Length > 0 && txtReceiveUS.Text == "$")
            {
                txtReceiveUS.Text = "$0";
            }
            else
            {
                txtReceiveUS.Text.Replace("0", "");
                txtReceiveUS.SelectionStart = txtReceiveUS.Text.Length;
            }

            processCalculate();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text == "")
            {
                txtDiscount.Text = "0%";
                txtDiscount.SelectAll();
                txtDiscount.Focus();
                return;
            }
            else if (Convert.ToInt32(txtDiscount.Text.Replace("%", "")) > 100)
            {
                txtDiscount.Text = "100%";
                txtDiscount.Focus();
                return;
            }

            double subtotal = Convert.ToDouble(txtSubtotal.Text.Replace("$", ""));
            double discount = Convert.ToDouble(txtDiscount.Text.Replace("%", ""));
            double cashDiscount = subtotal * discount / 100;
            double grandTotalUS = subtotal - cashDiscount;
            long grandTotalKh = fromCurrencyUsToKh(grandTotalUS);

            processCalculate();

            txtGrandtotalUS.Text = grandTotalUS.ToString("c2");
            txtGrandTotalKh.Text = grandTotalKh.ToString("#,###0៛");

        }


        private long fromCurrencyUsToKh(double currencyUs)
        {
            long grandTotalKh = 0;
            try
            {
                grandTotalKh = Convert.ToInt64(Math.Round((currencyUs * StaticData.ExchangeRate) / 100.0, MidpointRounding.AwayFromZero) * 100.0);
            }
            catch (Exception)
            {
                MessageBox.Show("Size of type currency REAL is out of rank");
            }

            return grandTotalKh;
        }

        private void keyPress(object sender, KeyPressEventArgs e)
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
            else if(e.KeyChar == 8 && txtReceiveUS.Text == "$0")
            {
                txtReceiveUS.SelectAll();
            }

        }
        private void keyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double grandTotal = Convert.ToDouble(txtGrandtotalUS.Text.Replace("$", ""));
                double receive = Convert.ToDouble(txtReceiveUS.Text.Replace("$", ""));
                if (receive < grandTotal)
                {
                    Warning war = new Warning("ប្រាក់ទទួលមិនគ្រប់គ្រាន់", "បង់ប្រាក់");
                    war.ShowDialog();
                    return;
                }
                else
                {
                    double change = receive - grandTotal;
                    txtChangeKh.Text = change.ToString("c2");
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void processCalculate()
        {
            double grandTotalUs = Convert.ToDouble(txtGrandtotalUS.Text.Replace("$", ""));
            long grandTotalKh = fromCurrencyUsToKh(grandTotalUs);

            double receiveUs = Convert.ToDouble(txtReceiveUS.Text.Replace("$", ""));
            long receiveUsToKh = fromCurrencyUsToKh(receiveUs);

            long receiveKh = Convert.ToInt64(txtReceiveKh.Text.Replace("៛", "").Replace(",", ""));
            long changeKh = (receiveUsToKh + receiveKh) - grandTotalKh;

            txtChangeKh.Text = changeKh.ToString("#,###0៛");
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Check payment type null
                if (cboPaymentType.Text == "ជ្រើសរើស")
                {
                    cboPaymentType.DroppedDown = true;
                    return;
                }

                btnCheckout_Click(null, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }



        private void txtDiscount_MouseClick(object sender, MouseEventArgs e)
        {
            txtDiscount.SelectAll();
        }

        private void txtReceive_MouseClick(object sender, MouseEventArgs e)
        {
            txtReceiveUS.SelectAll();
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            if (txtDiscount.Text.Contains('%'))
            {
                return;
            }
            txtDiscount.Text += "%";
        }

        private void txtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                txtReceiveUS.SelectAll();
                txtReceiveUS.Focus();
            }
        }

        private void txtReceive_Leave(object sender, EventArgs e)
        {
            if (txtReceiveUS.Text.Contains('$'))
            {
                return;
            }
            if (txtReceiveUS.Text.IndexOf(".") >= 0)
            {
                // Period exists in the text box
                // Do something...
                txtReceiveUS.Text = string.Format("{0:C}", txtReceiveUS.Text);
            }

            txtReceiveUS.Text = "$" + txtReceiveUS.Text;

        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            // Check payment type null
            if (cboPaymentType.Text == "ជ្រើសរើស")
            {
                cboPaymentType.DroppedDown = true;
                return;
            }

            if (txtReceiveKh.Text == "0៛" && txtReceiveUS.Text == "$0")
            {
                txtReceiveKh.SelectAll();
                txtReceiveKh.Focus();
                return;
            }

            // Calculate
            processCalculate();

            double grandTotalUs = Convert.ToDouble(txtGrandtotalUS.Text.Replace("$", ""));
            long grandTotalKh = Convert.ToInt64(txtGrandTotalKh.Text.Replace("៛", "").Replace(",", ""));

            double receiveUs = Convert.ToDouble(txtReceiveUS.Text.Replace("$", ""));
            long receiveKh = Convert.ToInt64(txtReceiveKh.Text.Replace("៛", "").Replace(",", ""));

            long changeKh = Convert.ToInt64(txtChangeKh.Text.Replace("៛", "").Replace(",", ""));

            if (receiveUs < grandTotalUs && receiveKh < grandTotalKh && changeKh < 0)
            {
                Warning war = new Warning("ប្រាក់ទទួលមិនគ្រប់គ្រាន់", "បង់ប្រាក់");
                war.ShowDialog();
                txtReceiveUS.Focus();
                return;
            }
            else
            {
                Confirm con = new Confirm("តើអ្នកពិតជាចង់គិតប្រាក់មែនទេ?", "បញ្ជាក់");
                if (con.ShowDialog(this) == DialogResult.Yes)
                {
                    // Check payment type null
                    if (cboPaymentType.Text == "ជ្រើសរើស")
                    {
                        cboPaymentType.DroppedDown = true;
                        return;
                    }

                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
            }
        }

        private void txtReceiveKh_TextChanged(object sender, EventArgs e)
        {
            // Check empty box
            if (txtReceiveKh.Text == "")
            {
                txtReceiveKh.Text = "0៛";
                txtReceiveKh.SelectAll();
                txtReceiveKh.Focus();
                return;
            }

            if (txtReceiveKh.Text.Length > 0 && txtReceiveKh.Text == "៛")
            {
                txtReceiveKh.Text = "0៛";
            }
            else
            {
                txtReceiveKh.Text.Replace("0", "");
                txtReceiveKh.SelectionStart = txtReceiveKh.Text.Length;
            }

            processCalculate();
        }

        private void frmCheckout_Shown(object sender, EventArgs e)
        {
            // load payment type
            loadTypePayment();

            txtReceiveKh.SelectAll();
            txtReceiveKh.Focus();
            
        }

        private void txtReceiveKh_MouseClick(object sender, MouseEventArgs e)
        {
            txtReceiveKh.SelectAll();
        }

        private void txtReceiveKh_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers and decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            // Allow only one decimal point
            else if (e.KeyChar == 8 && txtReceiveUS.Text == "0៛")
            {
                txtReceiveUS.SelectAll();
            }
        }

        private void txtReceiveKh_Leave(object sender, EventArgs e)
        {
            if (txtReceiveKh.Text.Contains('៛'))
            {
                return;
            }

            txtReceiveKh.Text = txtReceiveKh.Text + "៛";
        }
    }//
}
