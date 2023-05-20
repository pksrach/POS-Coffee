using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using POS_Coffee.AlertMessage;
using POS_Coffee.cls;
using POS_Coffee.static_data;
using System.Runtime.Caching;
using POS_Coffee.form;

namespace POS_Coffee.Subform
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            new GenerateInvoice("INV");


            MemoryCache cache = MemoryCache.Default;
            Image image = (Image)cache.Get("BackgroundImage");
            if(image == null)
            {
                try
                {
                    // Load the image from file
                    image = Image.FromFile(@"Pictures/Login Background-01.jpg");

                    // Cache the image in memory
                    cache.Set("BackgroundImage", image, DateTimeOffset.MaxValue);
                }
                catch (Exception ex)
                {
                    Warning warning = new Warning("រូបភាពមានបញ្ហា Path រកមិនឃើញ (" + ex.Message + ")", "ចូល System");
                    warning.ShowDialog();
                }
            }

            // Create a PictureBox control and set its properties
            pictureBox1.Image = image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            // Add the PictureBox control to the Panel control
            panel_background.Controls.Add(pictureBox1);
        }

        private void SendEmail()
        {
            var fromAddress = new MailAddress("mediasocial605@gmail.com");
            var toAddress = new MailAddress("ss5.c.sharp@gmail.com", "Coffee Shop");

            const string fromPassword = "ss516012023";
            const string subject = "Subject";
            const string body = "Body";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HighlighTextBox_Enter(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            if (c is TextBox)
            {
                c = (TextBox)c;
            }

            if (c.Text == c.Tag.ToString())
            {
                c.Text = "";
                c.ForeColor = Color.White;
            }
        }
        private void HighlighTextBox_Leave(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            if (c is TextBox)
            {
                c = (TextBox)c;
            }

            if (c.Text.Trim() == "")
            {
                c.Text = c.Tag.ToString();
                c.ForeColor = Color.Gainsboro;
            }
        }

        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtUsername.Text == "Username" || txtPassword.Text == "" || txtPassword.Text == "Password") return;

            try
            {
                SqlCommand cmd = new SqlCommand("", ConnectionDb.cnn);
                cmd.CommandText = "select s.sid, s.staff_name, u.user_name, u.user_pwd, u.role from tbl_user u inner join tbl_staffs s on u.sid = s.sid where u.deleted_date is null and s.deleted_date is null and u.user_name= '" + txtUsername.Text + "' and u.user_pwd = '" + txtPassword.Text + "'";
                ConnectionDb.cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    Warning warning = new Warning("ឈ្មោះ និងលេខសម្ងាត់មិនត្រឹមត្រូវទេ! សូមព្យាយាមម្ដងទៀត!", "ចូល System");
                    warning.ShowDialog();
                    txtPassword.SelectAll();
                    txtPassword.Focus();
                    dr.Close();
                    ConnectionDb.cnn.Close();
                    return;
                }
                else
                {
                    StaticData.SID = (long)dr["sid"];
                    StaticData.StaffName = (string)dr["staff_name"];
                    StaticData.Role = dr["role"].ToString();

                    dr.Close();
                    ConnectionDb.cnn.Close();

                    if (StaticData.Role == Role.GENERAL || StaticData.Role == Role.ADMIN)
                    {
                        frmMain frm = new frmMain();
                        frm.Show();
                    }
                    else if (StaticData.Role == Role.CASHIER)
                    {
                        frmCashier frm = new frmCashier();
                        frm.Show();
                    }
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                ConnectionDb.cnn.Close();
                Warning warning = new Warning("Connection មានបញ្ហា [" + ex.Message + "]", "Connection Database");
                warning.ShowDialog();
                return;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (txtUsername.Text != "" || txtPassword.Text != "")
                {
                    btnLogin_Click(sender, e);
                }
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtUsername.Text != "")
                {
                    txtPassword.SelectAll();
                    txtPassword.Focus();

                }
            }
        }
    }
}
