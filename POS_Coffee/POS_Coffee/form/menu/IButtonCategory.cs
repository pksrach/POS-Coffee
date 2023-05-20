using POS_Coffee.cls;
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

namespace POS_Coffee.form.menu
{
    public partial class IButtonCategory : UserControl
    {
        public IButtonCategory()
        {
            InitializeComponent();
           
        }

        public IButtonCategory(int id, string name, TableLayoutPanel tlp)
        {
            InitializeComponent();
            this.CID= id;
            this.CategoryName= name;
            this.tlp= tlp;
        }

        Method method = new Method();
        TableLayoutPanel tlp;

        private Image GetPhotos(byte[] value)
        {
            MemoryStream ms = new MemoryStream(value);
            return Image.FromStream(ms);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.tlp.Controls.Clear();
            this.tlp.AutoScroll = false;
            this.tlp.AutoScroll = true;

            SqlCommand cmd = new SqlCommand("", ConnectionDb.cnn);
            cmd.Parameters.Clear();
            cmd.CommandText = "select pro.pid, pro.product_name, pro.price, pro.image from tbl_product pro inner join tbl_category c on c.cid = pro.cid where c.cid=@cid and pro.status = 1 and c.status = 1";
            cmd.Parameters.AddWithValue("@cid", CID);
            ConnectionDb.cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int x = 0, y = 1;
            while(dr.Read())
            {
                int pid = Convert.ToInt32(dr["pid"].ToString());
                string productName = "" + dr["product_name"];
                string price = double.Parse(dr["price"] + "").ToString("c2");
                object img = dr["image"] is DBNull ? method.DefaultImage() : GetPhotos((byte[])dr["image"]);

                // product object
                IObjectProduct obj = new IObjectProduct(pid, productName, price, (Image)img);
                tlp.Controls.Add(obj, y, x);
                y++;
                if(y > 4)
                {
                    y = 1;
                    x++;
                }
            }
            ConnectionDb.cnn.Close();
            dr.Close();
        }
    }
}
