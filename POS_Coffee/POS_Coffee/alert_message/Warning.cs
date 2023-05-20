using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Coffee.AlertMessage
{
    public partial class Warning : Form
    {
        public Warning(string title, string headTitle)
        {
            InitializeComponent();
            lbTitle.Text = title;
            lbHeadTitle.Text = headTitle;
            btnYes.DialogResult = DialogResult.Yes;
        }

        public Warning()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Confirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnClose_Click(sender, e);
            }
        }
        //======== Event ========//
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

        private void btnYes_MouseEnter(object sender, EventArgs e)
        {
            btnYes.ForeColor = Color.Green;
        }

        private void btnYes_MouseLeave(object sender, EventArgs e)
        {
            btnYes.ForeColor = Color.White;
        }
        //======== End Event ========//

    }
}
