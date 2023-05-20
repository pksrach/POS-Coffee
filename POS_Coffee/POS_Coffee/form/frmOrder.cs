using POS_Coffee.AlertMessage;
using POS_Coffee.cls;
using POS_Coffee.form;
using POS_Coffee.form.menu;
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
    public partial class frmOrder : Form
    {
        public string getInvoice;
        public frmOrder()
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

        private void frmOrder_Load(object sender, EventArgs e)
        {
            // Load Table
            LoadTable();
        }

        public void LoadTable()
        {
            flowLayoutPanel1.Controls.Clear();

            try
            {
                SqlCommand cmd = new SqlCommand("Select tid, table_name, pending From tbl_tables Where deleted_date is null", ConnectionDb.cnn);
                ConnectionDb.cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    long id = Convert.ToInt64(dr["tid"]);
                    string name = dr["table_name"].ToString();
                    Boolean pending = Convert.ToBoolean(dr["pending"]);
                    IOrder obj = new IOrder(id, name, pending, this);
                    if(obj.Pending == true)
                    {
                        obj.button1.BackgroundImage = Image.FromFile(@"Pictures\pending.png");
                    }
                    else
                    {
                        obj.button1.BackgroundImage = Image.FromFile(@"Pictures\free.png");
                    }
                    flowLayoutPanel1.Controls.Add(obj);
                }

                // Get Invoice to save order
                StaticData.GetStaticInvoice = getInvoice;

                dr.Close();
                ConnectionDb.cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Table: "+ex.Message);
            }
        }
    }//
}///
