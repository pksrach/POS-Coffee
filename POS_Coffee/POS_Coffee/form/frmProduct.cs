using POS_Coffee.AlertMessage;
using POS_Coffee.cls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace POS_Coffee.Subform
{
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        Method method = new Method();
        LoadData load;

        private void FocusText()
        {
            txtProductName.Focus();
            txtProductName.SelectAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check Textbox null
            if (txtProductName.Text.Trim() == "")
            {
                FocusText();
                return;
            }

            Confirm confirm = new Confirm("តើអ្នកពិតជាចង់ រក្សាទុកមែនទេ?", "រក្សាទុក");
            confirm.ShowDialog();

            if (confirm.DialogResult == DialogResult.Yes)
            {
                try
                {
                    //save data into db
                    SqlCommand cmd = new SqlCommand("", ConnectionDb.cnn);
                    if (btnSave.Text == "បង្កើតថ្មី")
                    {
                        //check data in db exists data or not
                        string data = "Select product_name from tbl_product where status = 1 and product_name = '" + txtProductName.Text.Trim() + "'";
                        Check check = new Check();
                        string name = "";
                        if (check.CheckExistsData(data, name, "product_name") == txtProductName.Text)
                        {
                            Warning warning = new Warning("ទិន្នន័យនេះ មានរួចរាល់ហើយ!", "បំរាម");
                            warning.ShowDialog();
                            txtProductName.Focus();
                            txtProductName.SelectAll();
                            ConnectionDb.cnn.Close();
                            return;
                        }
                        //end of check data

                        if (image_product.ImageLocation == method.DefaultParth)
                        {
                            cmd.CommandText = "Insert into tbl_product(product_name, price, image, cid) values(N'" + txtProductName.Text + "', @price, NULL, '" + cboCategory.SelectedValue + "')";
                            //check when null value insert into db
                            string txt_price = txtPrice.Text.Length > 0 ? txtPrice.Text : "0";
                            double price = Convert.ToDouble(txt_price.Replace(",", "."));

                            cmd.Parameters.AddWithValue("@price", price);
                        }
                        else
                        {
                            cmd.CommandText = "Insert into tbl_product(product_name, price, image, cid) values(N'" + txtProductName.Text + "', @price, @image, '" + cboCategory.SelectedValue + "')";
                            //check when null value insert into db
                            string txt_price = txtPrice.Text.Length > 0 ? txtPrice.Text : "0";
                            double price = Convert.ToDouble(txt_price.Replace(",", "."));

                            cmd.Parameters.AddWithValue("@price", price);
                            // cmd.Parameters.AddWithValue("@image", method.SavePhoto(image_product));
                            cmd.Parameters.AddWithValue("@image", ConvertSizeImage());
                        }
                        ConnectionDb.cnn.Open();
                        cmd.ExecuteNonQuery();
                        ConnectionDb.cnn.Close();
                    }
                    else if(btnSave.Text == "រក្សាទុក")
                    {
                        double price = Convert.ToDouble(txtPrice.Text.ToString().Replace(",", "."));

                        if (image_product.ImageLocation == method.DefaultParth)
                        {
                            cmd.CommandText = "Update tbl_product set product_name=@product_name, price=@price, cid=@cid Where pid = @pid ";
                            cmd.Parameters.AddWithValue("@product_name", txtProductName.Text.Trim());
                            cmd.Parameters.AddWithValue("@price", price);
                            cmd.Parameters.AddWithValue("@cid", cboCategory.SelectedValue);
                            cmd.Parameters.AddWithValue("@pid", lblID.Text);
                        }
                        else
                        {
                            cmd.CommandText = "Update tbl_product set product_name=@product_name, price=@price, image=@image, cid=@cid Where pid = @pid ";
                            cmd.Parameters.AddWithValue("@product_name", txtProductName.Text.Trim());
                            cmd.Parameters.AddWithValue("@price", price);
                            // cmd.Parameters.AddWithValue("@image", method.SavePhoto(image_product));
                            cmd.Parameters.AddWithValue("@image", ConvertSizeImage());
                            cmd.Parameters.AddWithValue("@cid", cboCategory.SelectedValue);
                            cmd.Parameters.AddWithValue("@pid", lblID.Text);
                        }

                        ConnectionDb.cnn.Open();
                        cmd.ExecuteNonQuery();
                        ConnectionDb.cnn.Close();
                    }

                    lblResfress_Click(null, null);
                    btnEdit.Text = "កែប្រែ";
                    btnSave.Text = "បង្កើតថ្មី";
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else return;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            //check Textbox and selection table is null
           if(dataGridView1.SelectedRows.Count <= 0)
            {
                FocusText();
                return;
            }

            Confirm confirm = new Confirm("តើអ្នកពិតជាចង់ លុបទិន្នន័យនេះមែនទេ?", "លុបទិន្នន័យ");
            confirm.ShowDialog();
            if (confirm.DialogResult == DialogResult.Yes)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("", ConnectionDb.cnn);
                    cmd.CommandText = "Update tbl_product set status = 0, image = NULL where pid = @pid";
                    cmd.Parameters.AddWithValue("@pid", lblID.Text);

                    ConnectionDb.cnn.Open();
                    cmd.ExecuteNonQuery();
                    ConnectionDb.cnn.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                LoadProductNoImage();
                txtProductName.Clear();
                txtProductName.Focus();
            }
            

        }
        DataGridViewRow row;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                row = dataGridView1.Rows[e.RowIndex];
                lblID.Text = row.Cells["colPID"].Value.ToString();
            }
            else
                dataGridView1.ClearSelection();
        }


        //get image from db to set picturebox when select datagridview
        private Image GetPhotos(byte[] value)
        {
            MemoryStream ms = new MemoryStream(value);
            return Image.FromStream(ms);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //check Textbox and selection table is null
            if (dataGridView1.SelectedRows.Count > 0)
            {
                lblID.Text = row.Cells["colPID"].Value.ToString();
                txtProductName.Text = row.Cells["colProductName"].Value.ToString();
                txtPrice.Text = row.Cells["colPrice"].Value.ToString();
                cboCategory.SelectedValue = row.Cells["colCID"].Value.ToString();
                //is DBNull check ber image in datagridview is null when edit to show nopic.png on picturebox
                //image_product.Image = (row.Cells["colImage"].Value is DBNull) ? method.DefaultImage() : GetPhotos((Byte[])row.Cells["colImage"].Value);
                image_product.Image = GetOneImageFromDB(image_product.Image);

                btnSave.Text = "រក្សាទុក";
                FocusText();

                if (method.DisableTableWhenSelected(dataGridView1, btnEdit, btnSave) == false)
                {
                    //=======Clear=========
                    Clear.ClearTextBox(panelBox);
                    txtProductName.Focus();
                    lblID.Text = "";
                    dataGridView1.Enabled = true;
                    //=======Set Default Image=========
                    image_product.ImageLocation = method.DefaultParth;

                }
            }
        }

        ButtonPicture btnPic = new ButtonPicture();

        private void lblResfress_MouseDown(object sender, MouseEventArgs e)
        {
            btnPic.MouseAction(lblResfress, @"Pictures\reset_32px_3.png");
        }

        private void lblResfress_MouseEnter(object sender, EventArgs e)
        {
            btnPic.MouseAction(lblResfress, @"Pictures\reset_26px_1.png");
        }

        private void lblResfress_MouseLeave(object sender, EventArgs e)
        {
            btnPic.MouseAction(lblResfress, @"Pictures\reset_32px_3.png");
        }

        private void lblResfress_MouseMove(object sender, MouseEventArgs e)
        {
            btnPic.MouseAction(lblResfress, @"Pictures\reset_26px_1.png");
        }

        private void lblResfress_Click(object sender, EventArgs e)
        {
            LoadProductNoImage();

            //=======Clear=========
            Clear.ClearTextBox(panelBox);
            txtProductName.Focus();
            lblID.Text = "";
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            // Load product
            LoadProductNoImage();

            //========load combo box========
            load = new LoadData();
            load.ComboBoxLoad(cboCategory, "select cid, category_name from tbl_category where status = 1", "category_name", "cid");
        }

        string imgLocation = "";
        private void image_product_Click(object sender, EventArgs e)
        {
            OFD.Filter = "All files(*.*)|*.*|png files(*.png)|*.png|jpg files(*.jpg)|*.jpg";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                imgLocation = OFD.FileName.ToString();
                image_product.ImageLocation = imgLocation;
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells["colNo"].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == -1)
            {
                return;
            }

            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            if(columnName == "colImage")
            {
                // check image null don't convert type (isDB Null) to image using type byte[]
                if (Convert.IsDBNull(dataGridView1.Rows[e.RowIndex].Cells[2].Value)) return;

                frmViewImage view = new frmViewImage(this);

                // get image from datagrid to set into from view image
                byte[] imgData = (byte[])dataGridView1.Rows[e.RowIndex].Cells[2].Value;

                MemoryStream ms = new MemoryStream(imgData);

                view.pictureBox1.Image = Image.FromStream(ms);

                view.ShowDialog();


            }
        }

        // Befor save image into db need convert type image to byte data
        public byte[] ConvertImageToByte()
        {
            if (image_product.Image == null) return null;

            try
            {
                MemoryStream ms = new MemoryStream();
                image_product.Image.Save(ms, image_product.Image.RawFormat);
                return ms.GetBuffer();
            }
            catch (Exception)
            {
                return null;
            }

        }

        private byte[] ConvertSizeImage()
        {
            // Load the original image from a file or stream
            Image originalImage = Image.FromFile(image_product.ImageLocation);
            // Or: Image originalImage = Image.FromStream(stream);

            // Set the desired scale for the resized image
            float scale = 0.2f;

            // Calculate the new dimensions based on the scale
            int newWidth = (int)(originalImage.Width * scale);
            int newHeight = (int)(originalImage.Height * scale);

            // Create a new bitmap with the desired size
            Bitmap resizedImage = new Bitmap(newWidth, newHeight);

            // Create a graphics object to draw the resized image
            Graphics g = Graphics.FromImage(resizedImage);

            // Set the interpolation mode to high quality bicubic
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            // Draw the original image onto the resized image
            g.DrawImage(originalImage, new Rectangle(0, 0, newWidth, newHeight));

            // Save the resized image to a memory stream
            MemoryStream ms = new MemoryStream();
            resizedImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            // Get the byte array of the resized image
            byte[] imageBytes = ms.ToArray();

            return imageBytes;
        }



        private Image GetOneImageFromDB(Image image)
        {
            SqlCommand cmd = new SqlCommand("Select image from tbl_product Where pid = @pid", ConnectionDb.cnn);
            cmd.Parameters.AddWithValue("@pid", lblID.Text);
            ConnectionDb.cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                object obj = dr["image"];
                if (obj != DBNull.Value)
                {
                    image = (row.Cells["colPreviewImage"].Value is DBNull) ? method.DefaultImage() : GetPhotos((Byte[])dr["image"]);
                }
                else
                {
                    dr.Close();
                    ConnectionDb.cnn.Close();
                    return method.DefaultImage();
                }
            }

            dr.Close();
            ConnectionDb.cnn.Close();
            return image;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

            if(columnName == "colPreviewImage")
            {
                frmViewImage frm = new frmViewImage(this);
                frm.pictureBox1.Image = GetOneImageFromDB(frm.pictureBox1.Image);
                frm.ShowDialog();
            }
        }

        private void frmProduct_Shown(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void lblSearch_MouseDown(object sender, MouseEventArgs e)
        {
            btnPic.MouseAction(lblSearch, @"Pictures\search_32px.png");
        }

        private void lblSearch_MouseEnter(object sender, EventArgs e)
        {
            btnPic.MouseAction(lblSearch, @"Pictures\search_26px.png");
        }

        private void lblSearch_MouseLeave(object sender, EventArgs e)
        {
            btnPic.MouseAction(lblSearch, @"Pictures\search_32px.png");
        }

        private void lblSearch_MouseMove(object sender, MouseEventArgs e)
        {
            btnPic.MouseAction(lblSearch, @"Pictures\search_26px.png");
        }

        private void lblSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                lblResfress_Click(null, null);
                return;
            }

            // create a filter string
            string filter = "Select p.pid, p.product_name, p.price, p.cid, c.category_name from tbl_product p inner join tbl_category c on c.cid = p.cid where LOWER(p.product_name) like N'%" + txtSearch.Text.Trim() + "%' and p.status = 1 and c.status = 1";

            // create a SqlCommand object
            SqlCommand cmd = new SqlCommand(filter, ConnectionDb.cnn);

            // create a SqlDataAdapter object and pass in the SqlCommand object
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            // create a DataTable object
            DataTable dataTable = new DataTable();

            // fill the DataTable with the results of the query
            adapter.Fill(dataTable);

            // check if the DataTable is empty
            if (dataTable.Rows.Count == 0)
            {
                Warning warning = new Warning("ទិន្នន័យរកមិនឃើញ \"" + txtSearch.Text + "\"", "ស្វែងរកទិន្នន័យ");
                warning.ShowDialog();
                txtSearch.SelectAll();
                txtSearch.Focus();
            }
            else
            {
                // set the DataSource property of the DataGridView to the DataTable
                dataGridView1.DataSource = dataTable;
                dataGridView1.ClearSelection();
            }

            // close the SqlDataAdapter and the SqlConnection
            adapter.Dispose();
            ConnectionDb.cnn.Close();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (txtSearch.Text == "")
                {
                    lblResfress_Click(null, null);
                }
                else
                {
                    lblSearch_Click(null, null);
                }
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
           if(pageNumber <= 1) { return; }
            pageNumber--;
            LoadProductNoImage();
        }

        

        int totalRecords = 0;
        int totalPages = 0;
        int pageNumber = 1;
        int pageSize = 20;
        private void LoadProductNoImage()
        {
            // Hide columns
            dataGridView1.Columns["colImage"].Visible = false;

            // Assign data using columns
            dataGridView1.Columns["colPID"].DataPropertyName = "pid";
            dataGridView1.Columns["colProductName"].DataPropertyName = "product_name";
            dataGridView1.Columns["colPrice"].DataPropertyName = "price";
            dataGridView1.Columns["colCID"].DataPropertyName = "cid";
            dataGridView1.Columns["colCategoryName"].DataPropertyName = "category_name";

            // Retrieve the total number of records in the table
            SqlCommand countCommand = new SqlCommand("SELECT COUNT(*) FROM View_Product", ConnectionDb.cnn);
            ConnectionDb.cnn.Open();
            totalRecords = (int)countCommand.ExecuteScalar();

            // Calculate the number of pages required
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // Retrieve the records for the current page
            int offset = (pageNumber -1) * pageSize;

            SqlCommand cmd = new SqlCommand("Select p.pid, p.product_name, p.price, p.cid, c.category_name from tbl_product p inner join tbl_category c on c.cid = p.cid where p.status = 1 and c.status = 1 ORDER BY p.pid DESC OFFSET @Offset ROWS FETCH NEXT @pageSize ROWS ONLY;", ConnectionDb.cnn);
            cmd.Parameters.AddWithValue("@Offset", offset);
            cmd.Parameters.AddWithValue("@pageSize", pageSize);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            ConnectionDb.cnn.Close();

            // Pagination
            lblPagination.Text = string.Format("Page: {0} / {1}", pageNumber, totalPages);

            dataGridView1.DataSource = table;
            dataGridView1.Enabled = true;
            dataGridView1.ClearSelection();
            dataGridView1.Columns["colPrice"].DefaultCellStyle.Format = "c";

            //=======Set Default Image=========
            image_product.ImageLocation = method.DefaultParth;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(pageNumber == totalPages) return;
            pageNumber++;
            LoadProductNoImage();
        }
    }//
}///
