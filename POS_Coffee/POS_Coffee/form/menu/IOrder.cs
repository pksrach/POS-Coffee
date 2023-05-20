using POS_Coffee.AlertMessage;
using POS_Coffee.cls;
using POS_Coffee.data.layer.dto;
using POS_Coffee.static_data;
using POS_Coffee.Subform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Coffee.form.menu
{
    public partial class IOrder : UserControl
    {
        Warning warning;
        public IOrder()
        {
            InitializeComponent();
        }

        frmOrder order;
        public IOrder(long id, string name, Boolean pending, frmOrder order)
        {
            InitializeComponent();
            this.ID = id;
            this.Name = name;
            this.Pending = pending;
            this.order = order;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(Pending == true)
            {
                CheckOutOrder();
                order.LoadTable();
            }
            else
            {
                // check if datagridview no have data in table on frmCashier, We do not available to click free table
                if(StaticData.DT.Rows.Count > 0)
                {
                    Confirm con = new Confirm("តើអ្នកពិតជាចង់រក្សាទុកមែនទេ?", "បញ្ជាក់");
                    con.ShowDialog();
                    if (con.DialogResult == DialogResult.Yes)
                    {
                        this.order.DialogResult = con.DialogResult;
                        TransactionOrder();
                        order.Close();
                    }
                }
            }
        }

        private void CheckOutOrder()
        {
            string invoice = "";
            DateTime datetime = DateTime.Now;

            // Define the SQL query to retrieve data from the master table
            string orderQuery = "SELECT * FROM tbl_orders Where table_id =" + this.ID;
            SqlCommand cmd = new SqlCommand(orderQuery, ConnectionDb.cnn);
            ConnectionDb.cnn.Open();    
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                invoice = dr["invoice"].ToString();
                datetime = (DateTime)dr["datetime"];
            }
            dr.Close();
            ConnectionDb.cnn.Close();   


            //====================Order Details==================

            // Define the SQL query to retrieve data from the details table
            string orderDetailsQuery = "SELECT product_id, price, qty, discount_item, amount FROM tbl_order_details Where order_id = (SELECT oid FROM tbl_orders Where table_id =" + this.ID+")";

            // Create the SqlDataAdapter objects for the master and details tables
            SqlDataAdapter detailsAdapter = new SqlDataAdapter(orderDetailsQuery, ConnectionDb.cnn);

            // Create the DataTable objects for the master and details tables
            DataTable detailsTable = new DataTable();

            // Fill the DataTable objects with data from the SQL 
            detailsAdapter.Fill(detailsTable);

            // Create the DataGridView control
            DataGridView dataGridView = new DataGridView();
            dataGridView.AllowUserToAddRows= false;
            // Set the DataSource property of the DataGridView control to the DataTable
            dataGridView.DataSource = detailsTable;

            // Add the DataGridView control to a form or container
            this.Controls.Add(dataGridView);

            // Set datagridveiw to form checkout
            frmCheckout frm = new frmCheckout(dataGridView);
            double subtotal = 0;

            // Loop order detail to get values and calculator
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                subtotal += Convert.ToDouble(dataGridView.Rows[i].Cells["price"].Value) * Convert.ToDouble(dataGridView.Rows[i].Cells["qty"].Value);
            }

            frm.lblOrderInvoice.Text = invoice;
            frm.txtSubtotal.Text = subtotal.ToString("c2");
            frm.txtDiscount.Text = 0.ToString("#0%");

            if (frm.ShowDialog(this) == DialogResult.Yes)
            {
                long sale_id = 0;
                SalesDetailDto detailDto = new SalesDetailDto(); // Sale Detail
                SalesDto saleDto = new SalesDto();
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
                    saleDto.Grand_total_kh = Convert.ToInt64(frm.txtGrandTotalKh.Text.Replace("៛", "").Replace(",", ""));
                    saleDto.Received_us = Convert.ToDouble(frm.txtReceiveUS.Text.Replace("$", ""));
                    saleDto.Received_kh = Convert.ToInt64(frm.txtReceiveKh.Text.Replace("៛", "").Replace(",", ""));
                    saleDto.Change_kh = Convert.ToInt64(frm.txtChangeKh.Text.Replace("៛", "").Replace(",", ""));
                    saleDto.Sid = StaticData.SID;
                    saleDto.PaymentTypeId = Convert.ToInt64(frm.cboPaymentType.SelectedValue);

                    // Create an insert query with parameters
                    string insertSale = "insert into tbl_sales(invoice, subtotal_us, discount_invoice, grand_total_us, grand_total_kh, received_us, received_kh, change_kh, sid, datetime, payment_type_id) values(@invoice, @subtotal_us, @discount_invoice, @grand_total_us, @grand_total_kh, @received_us, @received_kh, @change_kh, @sid, @datetime, @payment_type_id); SELECT SCOPE_IDENTITY();";
                    cmd = new SqlCommand(insertSale, ConnectionDb.cnn, transaction);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@invoice", invoice);
                    cmd.Parameters.AddWithValue("@subtotal_us", saleDto.Subtotal_us);
                    cmd.Parameters.AddWithValue("@discount_invoice", saleDto.Discount_invoice);
                    cmd.Parameters.AddWithValue("@grand_total_us", saleDto.Grand_total_us);
                    cmd.Parameters.AddWithValue("@grand_total_kh", saleDto.Grand_total_kh);
                    cmd.Parameters.AddWithValue("@received_us", saleDto.Received_us);
                    cmd.Parameters.AddWithValue("@received_kh", saleDto.Received_kh);
                    cmd.Parameters.AddWithValue("@change_kh", saleDto.Change_kh);
                    cmd.Parameters.AddWithValue("@sid", saleDto.Sid);
                    cmd.Parameters.AddWithValue("@datetime", datetime);
                    cmd.Parameters.AddWithValue("@payment_type_id", saleDto.PaymentTypeId);


                    // Execute the insert query and get master id to insert detail below
                    sale_id = Convert.ToInt64(cmd.ExecuteScalar());

                    // Update Table pending to free table instead
                    string updateTable = "update tbl_tables set pending = 0 where tid = @tid";
                    cmd = new SqlCommand(updateTable, ConnectionDb.cnn, transaction);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@tid", this.ID);
                    cmd.ExecuteNonQuery();

                    // Loop add detail 
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        // Data transfer object of table master (sale detail)
                        detailDto.Product_id = Convert.ToInt64(row.Cells["product_id"].Value);
                        detailDto.Price = Convert.ToDouble(row.Cells["price"].Value);
                        detailDto.Qty = Convert.ToInt32(row.Cells["qty"].Value);
                        detailDto.Discount_item = Convert.ToInt32(row.Cells["discount_item"].Value);
                        detailDto.Amount = Convert.ToDouble(row.Cells["amount"].Value);

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

                    // Delete orders after insert table sale
                    string deleteOrder = "Delete tbl_orders Where oid = (SELECT oid FROM tbl_orders Where table_id = " + this.ID + ")";
                    cmd = new SqlCommand(deleteOrder, ConnectionDb.cnn, transaction);
                    cmd.ExecuteNonQuery();

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

                    LoadConfigReceipt();
                    frmPreviewReceipt preview = new frmPreviewReceipt();
                    preview.LoadReceiptByMasterId(sale_id.ToString(), header, subtitle, footer);
                    preview.ShowDialog();
                }
            }
        }

        private void TransactionOrder()
        {
            long orderId = 0;
            OrderDto orderDto = new OrderDto();
            OrderDetailsDto odrDetails = new OrderDetailsDto();

            ConnectionDb.cnn.Open();
            SqlTransaction transaction = ConnectionDb.cnn.BeginTransaction();

            try
            {
                // Insert data into db
                string insertOrder = "insert into tbl_orders(invoice, table_id, sid, datetime) values(@invoice, @table_id, @sid, getdate()); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(insertOrder, ConnectionDb.cnn, transaction);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@invoice", orderDto.Invoice);
                cmd.Parameters.AddWithValue("@table_id", this.ID);
                cmd.Parameters.AddWithValue("@sid", StaticData.SID);

                // Execute the insert query and get master id to insert detail below
                orderId = Convert.ToInt64(cmd.ExecuteScalar());

                // Update Invoice Num
                string updateInvoice = "update tbl_invoice_num set InvoicesNum = @inv";
                cmd = new SqlCommand(updateInvoice, ConnectionDb.cnn, transaction);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@inv", GenerateInvoice.Invoice);
                cmd.ExecuteNonQuery();

                // Update status table
                string updatePendingTable = "update tbl_tables set pending = 1 where tid = @tid";
                cmd = new SqlCommand(updatePendingTable, ConnectionDb.cnn, transaction);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@tid", this.ID);
                cmd.ExecuteNonQuery();

                // Add order details
                foreach (DataRow row in StaticData.DT.Rows)
                {
                    // Data transfer object of table master (sale detail)
                    odrDetails.Product_id = Convert.ToInt64(row["colPID"]);
                    odrDetails.Price = Convert.ToDouble(row["colPrice"].ToString().Replace("$", ""));
                    odrDetails.Qty = Convert.ToInt32(row["colQty"]);
                    odrDetails.Discount_item = Convert.ToInt32(row["colDiscount"].ToString().Replace("%", ""));
                    odrDetails.Amount = Convert.ToDouble(row["colAmount"].ToString().Replace("$", ""));

                    // Insert order detail in db
                    string insetOderDetails = "insert into tbl_order_details(order_id, product_id, price, qty, discount_item, amount) values(@order_id , @product_id, @price, @qty, @discount_item, @amount)";
                    cmd = new SqlCommand(insetOderDetails, ConnectionDb.cnn, transaction);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@order_id", orderId);
                    cmd.Parameters.AddWithValue("@product_id", odrDetails.Product_id);
                    cmd.Parameters.AddWithValue("@price", odrDetails.Price);
                    cmd.Parameters.AddWithValue("@qty", odrDetails.Qty);
                    cmd.Parameters.AddWithValue("@discount_item", odrDetails.Discount_item);
                    cmd.Parameters.AddWithValue("@amount", odrDetails.Amount);

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
                StaticData.DT.Clear();

                // Call report order
                LoadNo();
                frmPreviewOrder preview = new frmPreviewOrder();
                preview.OrderNum(orderId.ToString(), count_no.ToString());
                preview.ShowDialog();
                if(count_no == max_num)
                {
                    ResetNumber();
                }
                else
                {
                    UpdateNo();
                }
                
            }
        }

        int count_no = 1;
        int max_num = 100;
        private void LoadNo()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select max_num, no_count from tbl_no_number", ConnectionDb.cnn);
                ConnectionDb.cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    warning = new Warning("ទិន្នន័យរកមិនឃើញ", "បង្ហាញទិន្នន័យ");
                    warning.ShowDialog();
                    ConnectionDb.cnn.Close();
                    return;
                }
                count_no = Convert.ToInt32(dr["no_count"]);
                max_num = Convert.ToInt32(dr["max_num"]);

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
        private void UpdateNo()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Update tbl_no_number set no_count = no_count+1", ConnectionDb.cnn);
                ConnectionDb.cnn.Open();
                cmd.ExecuteNonQuery();
                ConnectionDb.cnn.Close();

                LoadNo();
            }
            catch (Exception ex)
            {
                warning = new Warning("មានបញ្ហា " + ex.Message, "បង្ហាញទិន្នន័យ");
                warning.ShowDialog();
                ConnectionDb.cnn.Close();
                return;
            }
        }

        private void ResetNumber()
        {
            SqlCommand cmd = new SqlCommand("Update tbl_no_number set no_count = 1", ConnectionDb.cnn);
            ConnectionDb.cnn.Open();
            cmd.ExecuteNonQuery();
            ConnectionDb.cnn.Close();

            LoadNo();
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

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Pending != true) return;
            

        }
    }//
}///
