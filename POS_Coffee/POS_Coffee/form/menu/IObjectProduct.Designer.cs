using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace POS_Coffee.form.menu
{
    partial class IObjectProduct
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public static DataGridViewRowCollection Rows { get; set; } //laeng ng use static doy sa pel order product jrern product tae oy jol tae datagridview tae muy jg trov declare jea static; ber min declare jea static te vea pkot jea create datagridview tam product del hz doj jea yg order product 100 jg datagridview vea mean 100 del hz; jg ban ke oy use static mean datagridview tae muy;  

        public int PID { get; set; }
        public Image Img
        {
            get => pictureBox1.Image;
            set => pictureBox1.Image = value;
        }
        public new string ProductName
        {
            get => lblName.Text;
            set => lblName.Text = value;
        }
        public string Price
        {
            get => lblPrice.Text;
            set => lblPrice.Text = value;
        }

        public int CID { get; set; }



        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.clickAction);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.mouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.mouseLeave);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(169)))), ((int)(((byte)(132)))));
            this.lblName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.Font = new System.Drawing.Font("Kh Preyveng", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Padding = new System.Windows.Forms.Padding(5);
            this.lblName.Size = new System.Drawing.Size(148, 31);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "StaffName";
            this.lblName.Click += new System.EventHandler(this.clickAction);
            this.lblName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.lblName.MouseEnter += new System.EventHandler(this.mouseEnter);
            this.lblName.MouseLeave += new System.EventHandler(this.mouseLeave);
            this.lblName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // lblPrice
            // 
            this.lblPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(169)))), ((int)(((byte)(132)))));
            this.lblPrice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPrice.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPrice.Font = new System.Drawing.Font("Kh Preyveng", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.White;
            this.lblPrice.Location = new System.Drawing.Point(0, 159);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Padding = new System.Windows.Forms.Padding(5);
            this.lblPrice.Size = new System.Drawing.Size(148, 31);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "Price";
            this.lblPrice.Click += new System.EventHandler(this.clickAction);
            this.lblPrice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.lblPrice.MouseEnter += new System.EventHandler(this.mouseEnter);
            this.lblPrice.MouseLeave += new System.EventHandler(this.mouseLeave);
            this.lblPrice.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // IObjectProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "IObjectProduct";
            this.Size = new System.Drawing.Size(148, 190);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblName;
        private Label lblPrice;
    }
}
