using POS_Coffee.cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Coffee.Subform
{
    public partial class frmViewImage : Form
    {
        public frmViewImage(frmProduct pro)
        {
            InitializeComponent();
            this.pro = pro; //call frm Product
        }
        frmProduct pro;
        ButtonPicture btnPic = new ButtonPicture();

        // Event scale form
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
        // End of event scale form
        private string pathImage1 = @"Pictures\full_screen_32px.png";
        private string pathImage2 = @"Pictures\full_screen_26px.png";
        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            btnPic.MouseAction(label2, pathImage1);
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            btnPic.MouseAction(label2, pathImage2);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            btnPic.MouseAction(label2, pathImage1);
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            btnPic.MouseAction(label2, pathImage2);
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            btnPic.MouseAction(label3, @"Pictures\close_window_32px.png");
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            btnPic.MouseAction(label3, @"Pictures\close_window_26px.png");
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            btnPic.MouseAction(label3, @"Pictures\close_window_32px.png");
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            btnPic.MouseAction(label3, @"Pictures\close_window_26px.png");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                label2.Image = Image.FromFile(@"Pictures\restore_window_32px.png");
                pathImage1 = @"Pictures\full_screen_32px.png";
                pathImage2 = @"Pictures\full_screen_26px.png";
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                label2.Image = Image.FromFile(@"Pictures\full_screen_32px.png");
                pathImage1 = @"Pictures\restore_window_32px.png";
                pathImage2 = @"Pictures\restore_window_26px.png";
            }
        }
    }
}
