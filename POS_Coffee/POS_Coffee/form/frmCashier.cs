using POS_Coffee.AlertMessage;
using POS_Coffee.cls;
using POS_Coffee.data.layer.dto;
using POS_Coffee.form.menu;
using POS_Coffee.static_data;
using POS_Coffee.Subform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace POS_Coffee.form
{
    public partial class frmCashier : Form
    {
        Confirm confirm;
        Warning warning;
        LoadData load = new LoadData();
        public frmCashier()
        {
            InitializeComponent();

            //initialize somrab jab DataGridViewRowCollection in IObjectProduct frm to this dataGridview frm
            IObjectProduct.Rows = this.getRows();
        }
        //create somrab jab DataGridViewRowCollection row dak jol dataGridView1 in frm ng
        public DataGridViewRowCollection getRows()
        {
            return dataGridView1.Rows;
        }

        private void loadCategory()
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel2.Controls.Clear();

            int x = 0, y = 1;
            try
            {
                string sql = "select * from tbl_category where status = 1";
                ConnectionDb.cnn.Open();
                SqlCommand cmd = new SqlCommand(sql, ConnectionDb.cnn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = int.Parse(dr[0] + "");
                    string categoryName = "" + dr[1];
                    IButtonCategory obj = new IButtonCategory(id, categoryName, tableLayoutPanel2);
                    tableLayoutPanel1.RowCount = x;
                    tableLayoutPanel1.Controls.Add(obj, y, x);
                    y++;
                    if (y > 3)
                    {
                        y = 1;
                        x++;
                    }
                }//while
                dr.Close();
                ConnectionDb.cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void Cashier_Load(object sender, EventArgs e)
        {
            // load config receipt
            LoadConfigReceipt();

            // initialize custom constructor
            ConfigTable config = new ConfigTable(dataGridView1);

            //config table
            config.DisplayTable(dataGridView1); // set display table

            // Set Header color
            config.SetHeaderBackColor(dataGridView1, Color.FromArgb(69, 75, 81));
            config.SetHeaderForeColor(dataGridView1, Color.White);

            // Set Rows color
            config.SetRowsBackColor(dataGridView1, Color.FromArgb(88, 169, 132));
            config.SetRowsForeColor(dataGridView1, Color.White);
            config.SetRowsBackColorSelected(dataGridView1, Color.FromArgb(69, 75, 81));

            // Set Grid Color
            // do not set color tranparent, it not work for grid color
            config.SetGridColor(dataGridView1, Color.WhiteSmoke);

            // Load category
            loadCategory();

            // Load name of staff to login
            lblStaffName.Text = StaticData.StaffName;

            // Load check permission
            Permission();

            // Load Exchange Rate
            load.loadExchangeRate();
        }

        private void lbExit_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                string path = @"Pictures\home_32px black.png";
                lblHome.Image = Image.FromFile(path);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void lbExit_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                string path = @"Pictures\home_32px.png";
                lblHome.Image = Image.FromFile(path);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            frmMain frm = new frmMain();
            frm.Show();
            this.Hide();
            frm.lbNameUser.Text = StaticData.StaffName;
            //frm.lbNameUser.Text = Program.name_user;
        }

        ButtonPicture btnPic = new ButtonPicture();
        private void lblLogout_MouseEnter(object sender, EventArgs e)
        {
            btnPic.MouseAction(lblLogout, @"Pictures\Logout_32px black.png");
        }

        private void lblLogout_MouseLeave(object sender, EventArgs e)
        {
            btnPic.MouseAction(lblLogout, @"Pictures\Logout_32px.png");
        }

        private void Permission()
        {
            if(StaticData.Role == Role.CASHIER)
            {
                lblHome.Visible = false;
                lblSetting.Visible = false;
            }
            else
            {
                lblHome.Visible = true;
                lblSetting.Visible = true;
            }
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            confirm = new Confirm("តើអ្នកពិតជាចង់ចាកចេញ មែនទេ?", "ចេញពី System");
            confirm.ShowDialog();
            if (confirm.DialogResult == DialogResult.Yes)
            {
                lblHome.Visible = true;
                frmLogin frm = new frmLogin();
                frm.Show();
                this.Hide();
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void btnClearDataGridView_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            if(columnName == "colAdd")
            {
                // Assign value from table into varaible
                int qtyOnTable = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["colQty"].Value);
                double price = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["colPrice"].Value.ToString().Replace("$", ""));
                int discount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["colDiscount"].Value.ToString().Replace("%", ""));
                
                // On click button add qty
                qtyOnTable++;

                // Calculate each row
                double amount = qtyOnTable * price;
                double cashDiscount = amount * discount / 100;
                double subAmount = amount - cashDiscount;

                // Assign value into table
                dataGridView1.Rows[e.RowIndex].Cells["colQty"].Value = qtyOnTable;
                dataGridView1.Rows[e.RowIndex].Cells["colAmount"].Value = subAmount.ToString("c2");
            }else if(columnName == "colRemove")
            {
                // Assign value from table into varaible
                int qtyOnTable = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["colQty"].Value);
                double price = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["colPrice"].Value.ToString().Replace("$", ""));
                int discount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["colDiscount"].Value.ToString().Replace("%", ""));

                // Check qty must bigger than 1 ===>
                if (qtyOnTable <= 1)
                {
                    // Remove by index of record
                    dataGridView1.Rows.RemoveAt(e.RowIndex);

                    // Refresh the DataGridView
                    dataGridView1.Refresh();

                    return;
                }

                // On click button add qty
                qtyOnTable--;

                // Calculate each 
                double amount = qtyOnTable * price;
                double cashDiscount = amount * discount / 100;
                double subAmount = amount - cashDiscount;

                // Assign value into table
                dataGridView1.Rows[e.RowIndex].Cells["colQty"].Value = qtyOnTable;
                dataGridView1.Rows[e.RowIndex].Cells["colAmount"].Value = subAmount.ToString("c2");
            }
        }

        private void calculateAfterDiscount(DataGridViewCellEventArgs e)
        {
            int discount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["colDiscount"].Value.ToString().Replace("%", ""));
            if(discount > 100)
            {
                dataGridView1.Rows[e.RowIndex].Cells["colDiscount"].Value = "100%";
            }
            int qty = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["colQty"].Value.ToString());
            double price = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["colPrice"].Value.ToString().Replace("$", ""));
            double amount = qty * price;
            double cashDiscount = amount * discount / 100;
            double subAmount = amount - cashDiscount;

            // assign amount 
            dataGridView1.Rows[e.RowIndex].Cells["colAmount"].Value = subAmount.ToString("c2");
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // ========Check Discount Column========
            if (dataGridView1.CurrentRow.Cells["colDiscount"]?.Value == null)
            {
                // handle null value or zero
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0%";
            }else
            {
                string discount = dataGridView1.Rows[e.RowIndex].Cells["colDiscount"].Value.ToString();

                if (discount.Contains('%'))
                {
                    dataGridView1.Rows[e.RowIndex].Cells["colDiscount"].Value = discount;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells["colDiscount"].Value = discount + "%";
                }
            }

            // ========Check Qty Column========
            if (dataGridView1.CurrentRow.Cells["colQty"]?.Value == null || Convert.ToInt16(dataGridView1.CurrentRow.Cells["colQty"].Value) < 1)
            {
                // handle null value or zero assign qty 1
                dataGridView1.Rows[e.RowIndex].Cells["colQty"].Value = "1";

                string price = dataGridView1.Rows[e.RowIndex].Cells["colPrice"].Value.ToString();

                dataGridView1.Rows[e.RowIndex].Cells["colAmount"].Value = price;
            }
            else
            {
                int qty = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["colQty"].Value);
                double price = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["colPrice"].Value.ToString().Replace("$", ""));
                double amount = qty * price;

                dataGridView1.Rows[e.RowIndex].Cells["colAmount"].Value = amount.ToString("c2");
            }

            calculateAfterDiscount(e);
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colQty")
            {
                // Check if the entered value is a digit
                int value;
                if (!int.TryParse(e.FormattedValue.ToString(), out value) && !e.FormattedValue.ToString().Equals(""))
                {
                    // If not a digit, cancel the editing process and show an error message
                    dataGridView1.Rows[e.RowIndex].ErrorText = "Value must be a digit";
                    e.Cancel = true;
                }
                else
                {
                    // If a digit, clear the error message
                    dataGridView1.Rows[e.RowIndex].ErrorText = "";
                }
            }else if (dataGridView1.Columns[e.ColumnIndex].Name == "colDiscount")
            {
                // Check if the entered value is a digit
                int value;
                if (!int.TryParse(e.FormattedValue.ToString(), out value) && !e.FormattedValue.ToString().Contains('%') && !e.FormattedValue.ToString().Equals(""))
                {
                    // If not a digit, cancel the editing process and show an error message
                    dataGridView1.Rows[e.RowIndex].ErrorText = "Value must be a digit";
                    e.Cancel = true;
                }
                else
                {
                    // If a digit, clear the error message
                    dataGridView1.Rows[e.RowIndex].ErrorText = "";
                }
            }
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                frmDiscount frm = new frmDiscount();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int discount = Convert.ToInt32(frm.txtDiscount.Text.Replace("%", ""));
                    DataGridViewRow row = dataGridView1.SelectedRows[0];
                    row.Cells["colDiscount"].Value = discount+"%".ToString();
                }
            }
        }

        public string getInvoice()
        {
            // Loading Invoice number
            GenerateInvoice.LoadingInvoiceNumber();
            string invoice = GenerateInvoice.NextInvoiceNumber();

            return invoice;
        }

        SalesDto saleDto = new SalesDto(); // Sale Master Global In this form
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                frmCheckout frm = new frmCheckout(dataGridView1);
                double subtotal = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    subtotal += Convert.ToDouble(dataGridView1.Rows[i].Cells["colAmount"].Value.ToString().Replace("$", ""));
                }
                frm.txtSubtotal.Text = subtotal.ToString("c2");
                frm.txtDiscount.Text = 0.ToString("#0%");

                if (frm.ShowDialog(this) == DialogResult.Yes)
                {
                    long sale_id = 0;
                    SalesDetailDto detailDto = new SalesDetailDto(); // Sale Detail

                    // Open Connection
                    ConnectionDb.cnn.Open();
                    // Begin the transaction
                    SqlTransaction transaction = ConnectionDb.cnn.BeginTransaction();
                    try
                    {
                        // Data transfer object of table master (sale)
                        saleDto.Subtotal_us = Convert.ToDouble(frm.txtSubtotal.Text.Replace("$", ""));
                        saleDto.Discount_invoice = Convert.ToInt32(frm.txtDiscount.Text.Replace("%", ""));
                        saleDto.Grand_total_us = Convert.ToDouble(frm.txtGrandtotalUS.Text.Replace("$", ""));
                        saleDto.Grand_total_kh = Convert.ToInt64(frm.txtGrandTotalKh.Text.Replace("៛", "").Replace(",",""));
                        saleDto.Received_us = Convert.ToDouble(frm.txtReceiveUS.Text.Replace("$", ""));
                        saleDto.Received_kh = Convert.ToInt64(frm.txtReceiveKh.Text.Replace("៛", "").Replace(",", ""));
                        saleDto.Change_kh = Convert.ToInt64(frm.txtChangeKh.Text.Replace("៛", "").Replace(",", ""));
                        saleDto.Sid = StaticData.SID;
                        saleDto.PaymentTypeId = Convert.ToInt64(frm.cboPaymentType.SelectedValue);

                        // Create an insert query with parameters
                        string insertSale = "insert into tbl_sales(invoice, subtotal_us, discount_invoice, grand_total_us, grand_total_kh, received_us, received_kh, change_kh, sid, datetime, payment_type_id) values(@invoice, @subtotal_us, @discount_invoice, @grand_total_us, @grand_total_kh, @received_us, @received_kh, @change_kh, @sid, getdate(), @payment_type_id); SELECT SCOPE_IDENTITY();";
                        SqlCommand cmd = new SqlCommand(insertSale, ConnectionDb.cnn, transaction);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@invoice", saleDto.Invoice);
                        cmd.Parameters.AddWithValue("@subtotal_us", saleDto.Subtotal_us);
                        cmd.Parameters.AddWithValue("@discount_invoice", saleDto.Discount_invoice);
                        cmd.Parameters.AddWithValue("@grand_total_us", saleDto.Grand_total_us);
                        cmd.Parameters.AddWithValue("@grand_total_kh", saleDto.Grand_total_kh);
                        cmd.Parameters.AddWithValue("@received_us", saleDto.Received_us);
                        cmd.Parameters.AddWithValue("@received_kh", saleDto.Received_kh);
                        cmd.Parameters.AddWithValue("@change_kh", saleDto.Change_kh);
                        cmd.Parameters.AddWithValue("@sid", saleDto.Sid);
                        cmd.Parameters.AddWithValue("@payment_type_id", saleDto.PaymentTypeId);


                        // Execute the insert query and get master id to insert detail below
                        sale_id = Convert.ToInt64(cmd.ExecuteScalar());

                        string updateInvoice = "update tbl_invoice_num set InvoicesNum = @inv";
                        cmd = new SqlCommand(updateInvoice, ConnectionDb.cnn, transaction);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@inv", GenerateInvoice.Invoice);
                        cmd.ExecuteNonQuery();

                        // Loop add detail 
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            // Data transfer object of table master (sale detail)
                            detailDto.Product_id = Convert.ToInt64(row.Cells["colPID"].Value.ToString());
                            detailDto.Price = Convert.ToDouble(row.Cells["colPrice"].Value.ToString().Replace("$", ""));
                            detailDto.Qty = Convert.ToInt32(row.Cells["colQty"].Value);
                            detailDto.Discount_item = Convert.ToInt32(row.Cells["colDiscount"].Value.ToString().Replace("%", ""));
                            detailDto.Amount = Convert.ToDouble(row.Cells["colAmount"].Value.ToString().Replace("$", ""));

                            string insertSaleDetail = "insert into tbl_sales_detail(sale_id, product_id, price, qty, discount_item, amount) values(@sale_id , @product_id, @price, @qty, @discount_item, @amount)";
                            cmd = new SqlCommand(insertSaleDetail, ConnectionDb.cnn, transaction);
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@sale_id", sale_id);
                            cmd.Parameters.AddWithValue("@product_id", detailDto.Product_id);
                            cmd.Parameters.AddWithValue("@price", detailDto.Price);
                            cmd.Parameters.AddWithValue("@qty", detailDto.Qty);
                            cmd.Parameters.AddWithValue("@discount_item", detailDto.Discount_item);
                            cmd.Parameters.AddWithValue("@amount", detailDto.Amount);

                            // Execute the insert query
                            cmd.ExecuteNonQuery();
                        }
                        // Commit the transaction all and complete
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // If error then rollback
                        transaction.Rollback(); // do not save all in db
                        MessageBox.Show("Import User Info Failed [" + ex.Message + "]!");
                    }
                    finally
                    {
                        // Close the connection
                        ConnectionDb.cnn.Close();
                        dataGridView1.Rows.Clear();

                        frmPreviewReceipt preview = new frmPreviewReceipt();
                        preview.LoadReceiptByMasterId(sale_id.ToString(), header, subtitle, footer);
                        preview.ShowDialog();
                    }
                }
            }
        }

        string header = "Default";
        string subtitle = "Default";
        string footer = "Default";
        private void LoadConfigReceipt()
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
                }

                header = dr["header"].ToString();
                subtitle = dr["subtitle"].ToString();
                footer = dr["footer"].ToString();
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

        private void getValuesDgv()
        {
            StaticData.DT.Rows.Clear();
            StaticData.DT.Columns.Clear();
            // In the form constructor or load event, add columns to the DataTable based on the DataGridView columns
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                StaticData.DT.Columns.Add(column.Name);
            }

            // When you want to update the static DataTable with the data from the DataGridView, clear the DataTable and add new rows based on the DataGridView data
            StaticData.DT.Clear();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataRow dr = StaticData.DT.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dr[cell.ColumnIndex] = cell.Value;
                }
                StaticData.DT.Rows.Add(dr);
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            // Get data from datagridviews1 to global 
            getValuesDgv();

            frmOrder frmOrder = new frmOrder();
            frmOrder.getInvoice = getInvoice();
            frmOrder.ShowDialog();
            if (frmOrder.DialogResult == DialogResult.Yes)
            {
                dataGridView1.Rows.Clear();
            }
        }

        private void lblSetting_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                contextMenuStripSetting.Show(lblSetting, new Point(20, lblSetting.Height));
            }
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

        private void configNoNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNoNumber frm = new frmNoNumber();
            frm.ShowDialog();
        }
    }//
}///
