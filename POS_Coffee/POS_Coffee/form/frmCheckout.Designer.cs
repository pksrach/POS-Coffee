namespace POS_Coffee.Subform
{
    partial class frmCheckout
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckout));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReceiveUS = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtChangeKh = new System.Windows.Forms.TextBox();
            this.txtGrandtotalUS = new System.Windows.Forms.TextBox();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReceiveKh = new System.Windows.Forms.TextBox();
            this.txtGrandTotalKh = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboPaymentType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblOrderInvoice = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(75)))), ((int)(((byte)(81)))));
            this.panel1.Controls.Add(this.lblClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 40);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyMouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyMouseMove);
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Image = ((System.Drawing.Image)(resources.GetObject("lblClose.Image")));
            this.lblClose.Location = new System.Drawing.Point(457, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(31, 40);
            this.lblClose.TabIndex = 2;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Kh Preyveng", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(89, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "គិតប្រាក់";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "សរុប";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "បញ្ចុះតម្លៃ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "ប្រាក់បង់ $";
            // 
            // txtReceiveUS
            // 
            this.txtReceiveUS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReceiveUS.Location = new System.Drawing.Point(159, 389);
            this.txtReceiveUS.MaxLength = 15;
            this.txtReceiveUS.Name = "txtReceiveUS";
            this.txtReceiveUS.ShortcutsEnabled = false;
            this.txtReceiveUS.Size = new System.Drawing.Size(300, 37);
            this.txtReceiveUS.TabIndex = 5;
            this.txtReceiveUS.Text = "$0";
            this.txtReceiveUS.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtReceive_MouseClick);
            this.txtReceiveUS.TextChanged += new System.EventHandler(this.txtReceiveTextChanged);
            this.txtReceiveUS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.txtReceiveUS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyPress);
            this.txtReceiveUS.Leave += new System.EventHandler(this.txtReceive_Leave);
            // 
            // txtDiscount
            // 
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscount.Location = new System.Drawing.Point(159, 230);
            this.txtDiscount.MaxLength = 3;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ShortcutsEnabled = false;
            this.txtDiscount.Size = new System.Drawing.Size(300, 37);
            this.txtDiscount.TabIndex = 9;
            this.txtDiscount.Text = "០%";
            this.txtDiscount.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtDiscount_MouseClick);
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyPress);
            this.txtDiscount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDiscount_KeyUp);
            this.txtDiscount.Leave += new System.EventHandler(this.txtDiscount_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 391);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 29);
            this.label5.TabIndex = 10;
            this.label5.Text = "ប្រាក់ទទួល $";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 497);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 29);
            this.label6.TabIndex = 12;
            this.label6.Text = "ប្រាក់អាប់ ៛";
            // 
            // txtChangeKh
            // 
            this.txtChangeKh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChangeKh.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtChangeKh.HideSelection = false;
            this.txtChangeKh.Location = new System.Drawing.Point(159, 495);
            this.txtChangeKh.Name = "txtChangeKh";
            this.txtChangeKh.ReadOnly = true;
            this.txtChangeKh.ShortcutsEnabled = false;
            this.txtChangeKh.Size = new System.Drawing.Size(300, 37);
            this.txtChangeKh.TabIndex = 11;
            this.txtChangeKh.Text = "0៛";
            // 
            // txtGrandtotalUS
            // 
            this.txtGrandtotalUS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGrandtotalUS.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtGrandtotalUS.HideSelection = false;
            this.txtGrandtotalUS.Location = new System.Drawing.Point(159, 283);
            this.txtGrandtotalUS.Name = "txtGrandtotalUS";
            this.txtGrandtotalUS.ReadOnly = true;
            this.txtGrandtotalUS.ShortcutsEnabled = false;
            this.txtGrandtotalUS.Size = new System.Drawing.Size(300, 37);
            this.txtGrandtotalUS.TabIndex = 13;
            this.txtGrandtotalUS.Text = "$0";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubtotal.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtSubtotal.HideSelection = false;
            this.txtSubtotal.Location = new System.Drawing.Point(159, 177);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.ShortcutsEnabled = false;
            this.txtSubtotal.Size = new System.Drawing.Size(300, 37);
            this.txtSubtotal.TabIndex = 14;
            this.txtSubtotal.Text = "$0";
            // 
            // btnCheckout
            // 
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(169)))), ((int)(((byte)(132)))));
            this.btnCheckout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.Font = new System.Drawing.Font("Kh Preyveng", 12F);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Location = new System.Drawing.Point(33, 563);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(426, 50);
            this.btnCheckout.TabIndex = 15;
            this.btnCheckout.Text = "គិតប្រាក់";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // lblInvoice
            // 
            this.lblInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(169)))), ((int)(((byte)(132)))));
            this.lblInvoice.ForeColor = System.Drawing.Color.White;
            this.lblInvoice.Location = new System.Drawing.Point(159, 72);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(300, 36);
            this.lblInvoice.TabIndex = 16;
            this.lblInvoice.Text = "Invoice Number";
            this.lblInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 444);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 29);
            this.label7.TabIndex = 18;
            this.label7.Text = "ប្រាក់ទទួល ៛";
            // 
            // txtReceiveKh
            // 
            this.txtReceiveKh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReceiveKh.Location = new System.Drawing.Point(159, 442);
            this.txtReceiveKh.MaxLength = 15;
            this.txtReceiveKh.Name = "txtReceiveKh";
            this.txtReceiveKh.ShortcutsEnabled = false;
            this.txtReceiveKh.Size = new System.Drawing.Size(300, 37);
            this.txtReceiveKh.TabIndex = 17;
            this.txtReceiveKh.Text = "0៛";
            this.txtReceiveKh.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtReceiveKh_MouseClick);
            this.txtReceiveKh.TextChanged += new System.EventHandler(this.txtReceiveKh_TextChanged);
            this.txtReceiveKh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.txtReceiveKh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReceiveKh_KeyPress);
            this.txtReceiveKh.Leave += new System.EventHandler(this.txtReceiveKh_Leave);
            // 
            // txtGrandTotalKh
            // 
            this.txtGrandTotalKh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGrandTotalKh.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtGrandTotalKh.HideSelection = false;
            this.txtGrandTotalKh.Location = new System.Drawing.Point(159, 336);
            this.txtGrandTotalKh.Name = "txtGrandTotalKh";
            this.txtGrandTotalKh.ReadOnly = true;
            this.txtGrandTotalKh.ShortcutsEnabled = false;
            this.txtGrandTotalKh.Size = new System.Drawing.Size(300, 37);
            this.txtGrandTotalKh.TabIndex = 20;
            this.txtGrandTotalKh.Text = "$0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 338);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 29);
            this.label8.TabIndex = 19;
            this.label8.Text = "ប្រាក់បង់ ៛";
            // 
            // cboPaymentType
            // 
            this.cboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentType.FormattingEnabled = true;
            this.cboPaymentType.Location = new System.Drawing.Point(159, 124);
            this.cboPaymentType.Name = "cboPaymentType";
            this.cboPaymentType.Size = new System.Drawing.Size(300, 37);
            this.cboPaymentType.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 29);
            this.label9.TabIndex = 22;
            this.label9.Text = "ប្រភេទ សាច់ប្រាក់";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 29);
            this.label10.TabIndex = 23;
            this.label10.Text = "វិក្កយបត្រ";
            // 
            // lblOrderInvoice
            // 
            this.lblOrderInvoice.AutoSize = true;
            this.lblOrderInvoice.Location = new System.Drawing.Point(349, 43);
            this.lblOrderInvoice.Name = "lblOrderInvoice";
            this.lblOrderInvoice.Size = new System.Drawing.Size(102, 29);
            this.lblOrderInvoice.TabIndex = 24;
            this.lblOrderInvoice.Text = "Invoice Order";
            this.lblOrderInvoice.Visible = false;
            // 
            // frmCheckout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(491, 646);
            this.ControlBox = false;
            this.Controls.Add(this.lblOrderInvoice);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboPaymentType);
            this.Controls.Add(this.txtGrandTotalKh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtReceiveKh);
            this.Controls.Add(this.lblInvoice);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.txtGrandtotalUS);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtChangeKh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtReceiveUS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Kh Preyveng", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCheckout";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmCheckout_Load);
            this.Shown += new System.EventHandler(this.frmCheckout_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyMouseMove);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtReceiveUS;
        public System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtChangeKh;
        public System.Windows.Forms.TextBox txtGrandtotalUS;
        public System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtReceiveKh;
        public System.Windows.Forms.TextBox txtGrandTotalKh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox cboPaymentType;
        public System.Windows.Forms.Label lblInvoice;
        public System.Windows.Forms.Label lblOrderInvoice;
        private System.Windows.Forms.Label label10;
    }
}