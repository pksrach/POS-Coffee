using POS_Coffee.AlertMessage;
using POS_Coffee.cls;
using POS_Coffee.form;
using POS_Coffee.report;
using POS_Coffee.static_data;
using POS_Coffee.Subform;
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

namespace POS_Coffee
{
    public partial class frmMain : Form
    {
        Confirm confirm;
        LoadData load = new LoadData();
        public frmMain()
        {
            InitializeComponent();
        }

        private void lbExit_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                string path = @"Pictures\exit 32px.png";
                lblExit.Image = Image.FromFile(path);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            confirm = new Confirm("តើអ្នកពិតជាចង់ បិទ System មែនទេ?", "បិទ System");
            confirm.ShowDialog();
            if (confirm.DialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lbExit_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                string path = @"Pictures\exit 32px red.png";
                lblExit.Image = Image.FromFile(path);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnCashier_Click(object sender, EventArgs e)
        {
            frmCashier frm = new frmCashier();
            frm.Show();
            this.Hide();
        }

        private Form _loadedForm;
        public void LoadFormOnPanel(Form formToLoad, Panel panelToLoadOn)
        {
            if (_loadedForm != null && _loadedForm.GetType() == formToLoad.GetType())
            {
                // Form is already loaded on panel, do not load again
                return;
            }

            // Remove any existing form from the panel
            panelToLoadOn.Controls.Clear();

            // Load the new form on the panel
            formToLoad.TopLevel = false;
            formToLoad.FormBorderStyle = FormBorderStyle.None;
            formToLoad.Dock = DockStyle.Fill;
            panelToLoadOn.Controls.Add(formToLoad);
            panelToLoadOn.Tag = formToLoad;
            formToLoad.Show();

            // Set the loaded form to the current form
            _loadedForm = formToLoad;
        }

        frmCategory frmCategory = new frmCategory();
        private void btnCategory_Click(object sender, EventArgs e)
        {
            LoadFormOnPanel(frmCategory, panelDisplay);
            Permission();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.Show();
            this.Hide();
        }

        frmProduct frmProduct = new frmProduct();
        private void btnProduct_Click(object sender, EventArgs e)
        {
            LoadFormOnPanel(frmProduct, panelDisplay);
            Permission();
        }

        frmTable frmTable = new frmTable();
       
        private void btnTable_Click(object sender, EventArgs e)
        {
            LoadFormOnPanel(frmTable, panelDisplay);
            Permission();
        }

        private void lblSetting_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                string path = @"Pictures\icons8_settings_32px_1.png";
                lblSetting.Image = Image.FromFile(path);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void lblSetting_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                string path = @"Pictures\icons8_settings_32px_2.png";
                lblSetting.Image = Image.FromFile(path);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void exchangeRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExchangeRate frmExchangeRate = new frmExchangeRate();
            lblSetting.Focus();
            frmExchangeRate.ShowDialog();
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccount frm = new frmAccount();
            lblSetting.Focus();
            frm.ShowDialog();
        }

        public void Permission()
        {
            if(StaticData.Role == Role.GENERAL)
            {
                //Button
                btnStaff.Visible= false;
                btnUser.Visible= false;

                // Form
                frmTable.btnDelete.Visible= false;
                frmProduct.btnDelete.Visible= false;
                frmCategory.btnDelete.Visible= false;

                //Mini form
                typePaymentToolStripMenuItem.Visible = false;
                exchangeRateToolStripMenuItem.Visible = false;
                configReceiptToolStripMenuItem.Visible = false;
            }
            else
            {
                //Button
                btnStaff.Visible = true;
                btnUser.Visible = true;

                // Form
                frmTable.btnDelete.Visible = true;
                frmProduct.btnDelete.Visible = true;
                frmCategory.btnDelete.Visible = true;

                //Mini form
                typePaymentToolStripMenuItem.Visible = true;
                exchangeRateToolStripMenuItem.Visible = true;
                configReceiptToolStripMenuItem.Visible = true;

            }
        }
        
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Load permission
            Permission();

            // Load user name to login
            lbNameUser.Text = StaticData.StaffName;

            // Load Exchange rate
            load.loadExchangeRate();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            frmStaff frm = new frmStaff();
            LoadFormOnPanel(frm, panelDisplay);
            //FormLoading.Load_form(panelDisplay, frm);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            frmUser frm = new frmUser();
            LoadFormOnPanel(frm, panelDisplay);
        }

        
        private void typePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTypePayment frmTypePayment = new frmTypePayment();
            frmTypePayment.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            frmReportIncome frmReportIncome = new frmReportIncome();
            LoadFormOnPanel(frmReportIncome, panelDisplay);
        }

        private void btnExpense_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                contextMenuStripExpense.Show(btnExpense, new Point(200, btnExpense.Height - btnExpense.Height));
            }
        }

        private void lblSetting_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                contextMenuStripSetting.Show(lblSetting, new Point(20, lblSetting.Height));
            }
        }

        private void expenseTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExpenseType frm = new frmExpenseType();
            LoadFormOnPanel(frm, panelDisplay);
        }

        private void expenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExpense frm = new frmExpense();
            LoadFormOnPanel(frm, panelDisplay);
        }

        private void btnReportExpense_Click(object sender, EventArgs e)
        {
            frmReportExpense frmReportExpense = new frmReportExpense();
            LoadFormOnPanel(frmReportExpense, panelDisplay); 
        }

        private void configReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfigReceipt frm = new frmConfigReceipt();
            frm.ShowDialog();
        }
    }
}
