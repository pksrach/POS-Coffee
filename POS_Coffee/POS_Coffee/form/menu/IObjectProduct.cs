using POS_Coffee.cls;
using POS_Coffee.static_data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace POS_Coffee.form.menu
{
    public partial class IObjectProduct : UserControl
    {
        public IObjectProduct(int pid, string productName, string price, Image img)
        {
            InitializeComponent();
            this.PID = pid;
            lblName.Text = productName;
            lblPrice.Text = price;
            pictureBox1.Image = img;
        }
        private void clickAction(object sender, EventArgs e)
        {
            int idxRow = findIndexRow(PID);
            if (idxRow >= 0)
            {
                if (PID == (int)Rows[idxRow].Cells["colPID"].Value)
                {
                    int qty = Convert.ToInt32(Rows[idxRow].Cells["colQty"].Value); // jea column in dataGridview
                    qty += 1;
                    double amount = double.Parse(Price.Replace("$", "")) * qty;
                    Rows[idxRow].Cells["colQty"].Value = qty; // assign qty after calculate
                    Rows[idxRow].Cells[6].Value = amount.ToString("c2"); //c2 = currency 2 k'tong kroy kbeas; "$3.00"
                }
            }
            else
            {
                Rows.Add("", PID, ProductName, Price, "1", "0%", Price, Image.FromFile(@"Pictures/icons8_add_26px.png"), Image.FromFile(@"Pictures/icons8_minus_26px.png"));
            }
        }

        private int findIndexRow(int id)
        {
            for (int i = 0; i < Rows.Count; i++)
            {
                int idOrder = int.Parse(Rows[i].Cells[1].Value + "");
                if (id == idOrder)
                {
                    return i;
                }
            }
            return -1;
        }


        private void mouseEnter(object sender, EventArgs e)
        {
            // dak mouse pi ler
            lblName.BackColor = Color.FromArgb(69, 75, 81);
            lblPrice.BackColor = Color.FromArgb(69, 75, 81); // dark
        }

        private void mouseLeave(object sender, EventArgs e)
        {
            // dork mouse jenh
            lblName.BackColor = Color.FromArgb(88, 169, 132);
            lblPrice.BackColor = Color.FromArgb(88, 169, 132); // green
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            // joj mouse jos krom
            lblName.BackColor = Color.DarkGray;
            lblPrice.BackColor = Color.DarkGray;
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            // bro laeng mouse venh
            lblName.BackColor = Color.FromArgb(69, 75, 81);
            lblPrice.BackColor = Color.FromArgb(69, 75, 81); // dark
        }
    }
}
