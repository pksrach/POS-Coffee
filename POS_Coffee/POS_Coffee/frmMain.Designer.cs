namespace POS_Coffee
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSetting = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.contextMenuStripSetting = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.typePaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exchangeRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configReceiptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnReportIncome = new System.Windows.Forms.Button();
            this.btnReportExpense = new System.Windows.Forms.Button();
            this.btnExpense = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.btnTable = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnCashier = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbNameUser = new System.Windows.Forms.Label();
            this.picStaff = new System.Windows.Forms.PictureBox();
            this.panelDisplay = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStripExpense = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.expenseTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.contextMenuStripSetting.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStaff)).BeginInit();
            this.panelDisplay.SuspendLayout();
            this.contextMenuStripExpense.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(169)))), ((int)(((byte)(132)))));
            this.panel1.Controls.Add(this.lblSetting);
            this.panel1.Controls.Add(this.lblExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1161, 50);
            this.panel1.TabIndex = 0;
            // 
            // lblSetting
            // 
            this.lblSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetting.Image = ((System.Drawing.Image)(resources.GetObject("lblSetting.Image")));
            this.lblSetting.Location = new System.Drawing.Point(12, 7);
            this.lblSetting.Name = "lblSetting";
            this.lblSetting.Size = new System.Drawing.Size(36, 37);
            this.lblSetting.TabIndex = 1;
            this.lblSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSetting.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblSetting_MouseClick);
            this.lblSetting.MouseEnter += new System.EventHandler(this.lblSetting_MouseEnter);
            this.lblSetting.MouseLeave += new System.EventHandler(this.lblSetting_MouseLeave);
            // 
            // lblExit
            // 
            this.lblExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExit.Image = ((System.Drawing.Image)(resources.GetObject("lblExit.Image")));
            this.lblExit.Location = new System.Drawing.Point(1113, 7);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(36, 37);
            this.lblExit.TabIndex = 0;
            this.lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblExit.Click += new System.EventHandler(this.lbExit_Click);
            this.lblExit.MouseEnter += new System.EventHandler(this.lbExit_MouseEnter);
            this.lblExit.MouseLeave += new System.EventHandler(this.lbExit_MouseLeave);
            // 
            // contextMenuStripSetting
            // 
            this.contextMenuStripSetting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.typePaymentToolStripMenuItem,
            this.exchangeRateToolStripMenuItem,
            this.accountToolStripMenuItem,
            this.configReceiptToolStripMenuItem});
            this.contextMenuStripSetting.Name = "contextMenuStrip1";
            this.contextMenuStripSetting.Size = new System.Drawing.Size(170, 116);
            // 
            // typePaymentToolStripMenuItem
            // 
            this.typePaymentToolStripMenuItem.Font = new System.Drawing.Font("Kh Preyveng", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typePaymentToolStripMenuItem.Name = "typePaymentToolStripMenuItem";
            this.typePaymentToolStripMenuItem.Size = new System.Drawing.Size(169, 28);
            this.typePaymentToolStripMenuItem.Text = "ប្រភេទ សាច់ប្រាក់";
            this.typePaymentToolStripMenuItem.Click += new System.EventHandler(this.typePaymentToolStripMenuItem_Click);
            // 
            // exchangeRateToolStripMenuItem
            // 
            this.exchangeRateToolStripMenuItem.Font = new System.Drawing.Font("Kh Preyveng", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exchangeRateToolStripMenuItem.Name = "exchangeRateToolStripMenuItem";
            this.exchangeRateToolStripMenuItem.Size = new System.Drawing.Size(169, 28);
            this.exchangeRateToolStripMenuItem.Text = "អត្រា ប្ដូរប្រាក់";
            this.exchangeRateToolStripMenuItem.Click += new System.EventHandler(this.exchangeRateToolStripMenuItem_Click);
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.Font = new System.Drawing.Font("Kh Preyveng", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(169, 28);
            this.accountToolStripMenuItem.Text = "ប្ដូរ លេខសម្ងាត់";
            this.accountToolStripMenuItem.Click += new System.EventHandler(this.accountToolStripMenuItem_Click);
            // 
            // configReceiptToolStripMenuItem
            // 
            this.configReceiptToolStripMenuItem.Font = new System.Drawing.Font("Kh Preyveng", 9.75F);
            this.configReceiptToolStripMenuItem.Name = "configReceiptToolStripMenuItem";
            this.configReceiptToolStripMenuItem.Size = new System.Drawing.Size(169, 28);
            this.configReceiptToolStripMenuItem.Text = "កំណត់ Receipt";
            this.configReceiptToolStripMenuItem.Click += new System.EventHandler(this.configReceiptToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(75)))), ((int)(((byte)(81)))));
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 614);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.btnReportIncome);
            this.panel4.Controls.Add(this.btnReportExpense);
            this.panel4.Controls.Add(this.btnExpense);
            this.panel4.Controls.Add(this.btnUser);
            this.panel4.Controls.Add(this.btnStaff);
            this.panel4.Controls.Add(this.btnTable);
            this.panel4.Controls.Add(this.btnLogout);
            this.panel4.Controls.Add(this.btnProduct);
            this.panel4.Controls.Add(this.btnCategory);
            this.panel4.Controls.Add(this.btnCashier);
            this.panel4.Location = new System.Drawing.Point(0, 150);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 461);
            this.panel4.TabIndex = 2;
            // 
            // btnReportIncome
            // 
            this.btnReportIncome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(75)))), ((int)(((byte)(81)))));
            this.btnReportIncome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReportIncome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportIncome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReportIncome.FlatAppearance.BorderSize = 0;
            this.btnReportIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportIncome.Font = new System.Drawing.Font("Kh Preyveng", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportIncome.ForeColor = System.Drawing.Color.White;
            this.btnReportIncome.Image = ((System.Drawing.Image)(resources.GetObject("btnReportIncome.Image")));
            this.btnReportIncome.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReportIncome.Location = new System.Drawing.Point(0, 296);
            this.btnReportIncome.Name = "btnReportIncome";
            this.btnReportIncome.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnReportIncome.Size = new System.Drawing.Size(200, 37);
            this.btnReportIncome.TabIndex = 10;
            this.btnReportIncome.Text = "របាយការណ៍ ចំណូល";
            this.btnReportIncome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportIncome.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnReportIncome.UseVisualStyleBackColor = false;
            this.btnReportIncome.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnReportExpense
            // 
            this.btnReportExpense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(75)))), ((int)(((byte)(81)))));
            this.btnReportExpense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReportExpense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportExpense.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReportExpense.FlatAppearance.BorderSize = 0;
            this.btnReportExpense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportExpense.Font = new System.Drawing.Font("Kh Preyveng", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportExpense.ForeColor = System.Drawing.Color.White;
            this.btnReportExpense.Image = ((System.Drawing.Image)(resources.GetObject("btnReportExpense.Image")));
            this.btnReportExpense.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReportExpense.Location = new System.Drawing.Point(0, 259);
            this.btnReportExpense.Name = "btnReportExpense";
            this.btnReportExpense.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnReportExpense.Size = new System.Drawing.Size(200, 37);
            this.btnReportExpense.TabIndex = 9;
            this.btnReportExpense.Text = "របាយការណ៍ ចំណាយ";
            this.btnReportExpense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportExpense.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnReportExpense.UseVisualStyleBackColor = false;
            this.btnReportExpense.Click += new System.EventHandler(this.btnReportExpense_Click);
            // 
            // btnExpense
            // 
            this.btnExpense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(75)))), ((int)(((byte)(81)))));
            this.btnExpense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExpense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExpense.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExpense.FlatAppearance.BorderSize = 0;
            this.btnExpense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpense.Font = new System.Drawing.Font("Kh Preyveng", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpense.ForeColor = System.Drawing.Color.White;
            this.btnExpense.Image = ((System.Drawing.Image)(resources.GetObject("btnExpense.Image")));
            this.btnExpense.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExpense.Location = new System.Drawing.Point(0, 222);
            this.btnExpense.Name = "btnExpense";
            this.btnExpense.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnExpense.Size = new System.Drawing.Size(200, 37);
            this.btnExpense.TabIndex = 8;
            this.btnExpense.Text = "ចំណាយ";
            this.btnExpense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExpense.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExpense.UseVisualStyleBackColor = false;
            this.btnExpense.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnExpense_MouseClick);
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(75)))), ((int)(((byte)(81)))));
            this.btnUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUser.FlatAppearance.BorderSize = 0;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.Font = new System.Drawing.Font("Kh Preyveng", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.ForeColor = System.Drawing.Color.White;
            this.btnUser.Image = ((System.Drawing.Image)(resources.GetObject("btnUser.Image")));
            this.btnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUser.Location = new System.Drawing.Point(0, 185);
            this.btnUser.Name = "btnUser";
            this.btnUser.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnUser.Size = new System.Drawing.Size(200, 37);
            this.btnUser.TabIndex = 7;
            this.btnUser.Text = "អ្នកប្រើប្រាស់";
            this.btnUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUser.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnUser.UseVisualStyleBackColor = false;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(75)))), ((int)(((byte)(81)))));
            this.btnStaff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStaff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStaff.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStaff.FlatAppearance.BorderSize = 0;
            this.btnStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaff.Font = new System.Drawing.Font("Kh Preyveng", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaff.ForeColor = System.Drawing.Color.White;
            this.btnStaff.Image = ((System.Drawing.Image)(resources.GetObject("btnStaff.Image")));
            this.btnStaff.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStaff.Location = new System.Drawing.Point(0, 148);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnStaff.Size = new System.Drawing.Size(200, 37);
            this.btnStaff.TabIndex = 6;
            this.btnStaff.Text = "បុគ្គលិក";
            this.btnStaff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaff.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnStaff.UseVisualStyleBackColor = false;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // btnTable
            // 
            this.btnTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(75)))), ((int)(((byte)(81)))));
            this.btnTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTable.FlatAppearance.BorderSize = 0;
            this.btnTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTable.Font = new System.Drawing.Font("Kh Preyveng", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTable.ForeColor = System.Drawing.Color.White;
            this.btnTable.Image = ((System.Drawing.Image)(resources.GetObject("btnTable.Image")));
            this.btnTable.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTable.Location = new System.Drawing.Point(0, 111);
            this.btnTable.Name = "btnTable";
            this.btnTable.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnTable.Size = new System.Drawing.Size(200, 37);
            this.btnTable.TabIndex = 5;
            this.btnTable.Text = "បង្កើត តុ";
            this.btnTable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTable.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnTable.UseVisualStyleBackColor = false;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(75)))), ((int)(((byte)(81)))));
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Kh Preyveng", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogout.Location = new System.Drawing.Point(0, 417);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnLogout.Size = new System.Drawing.Size(200, 35);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "ចាកចេញ";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(75)))), ((int)(((byte)(81)))));
            this.btnProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Font = new System.Drawing.Font("Kh Preyveng", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.ForeColor = System.Drawing.Color.White;
            this.btnProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnProduct.Image")));
            this.btnProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProduct.Location = new System.Drawing.Point(0, 74);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnProduct.Size = new System.Drawing.Size(200, 37);
            this.btnProduct.TabIndex = 2;
            this.btnProduct.Text = "ផលិតផល";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(75)))), ((int)(((byte)(81)))));
            this.btnCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategory.FlatAppearance.BorderSize = 0;
            this.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory.Font = new System.Drawing.Font("Kh Preyveng", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategory.ForeColor = System.Drawing.Color.White;
            this.btnCategory.Image = ((System.Drawing.Image)(resources.GetObject("btnCategory.Image")));
            this.btnCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCategory.Location = new System.Drawing.Point(0, 37);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnCategory.Size = new System.Drawing.Size(200, 37);
            this.btnCategory.TabIndex = 1;
            this.btnCategory.Text = "ប្រភេទ";
            this.btnCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategory.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCategory.UseVisualStyleBackColor = false;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnCashier
            // 
            this.btnCashier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(75)))), ((int)(((byte)(81)))));
            this.btnCashier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCashier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCashier.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCashier.FlatAppearance.BorderSize = 0;
            this.btnCashier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCashier.Font = new System.Drawing.Font("Kh Preyveng", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCashier.ForeColor = System.Drawing.Color.White;
            this.btnCashier.Image = ((System.Drawing.Image)(resources.GetObject("btnCashier.Image")));
            this.btnCashier.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCashier.Location = new System.Drawing.Point(0, 0);
            this.btnCashier.Name = "btnCashier";
            this.btnCashier.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnCashier.Size = new System.Drawing.Size(200, 37);
            this.btnCashier.TabIndex = 3;
            this.btnCashier.Text = "ចូលលក់";
            this.btnCashier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCashier.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCashier.UseVisualStyleBackColor = false;
            this.btnCashier.Click += new System.EventHandler(this.btnCashier_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbNameUser);
            this.panel3.Controls.Add(this.picStaff);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 143);
            this.panel3.TabIndex = 1;
            // 
            // lbNameUser
            // 
            this.lbNameUser.Font = new System.Drawing.Font("Kh Preyveng", 11.25F);
            this.lbNameUser.ForeColor = System.Drawing.Color.White;
            this.lbNameUser.Location = new System.Drawing.Point(4, 104);
            this.lbNameUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNameUser.Name = "lbNameUser";
            this.lbNameUser.Size = new System.Drawing.Size(192, 39);
            this.lbNameUser.TabIndex = 1;
            this.lbNameUser.Text = "បុគ្គលិក";
            this.lbNameUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picStaff
            // 
            this.picStaff.Image = ((System.Drawing.Image)(resources.GetObject("picStaff.Image")));
            this.picStaff.Location = new System.Drawing.Point(0, 28);
            this.picStaff.Margin = new System.Windows.Forms.Padding(4);
            this.picStaff.Name = "picStaff";
            this.picStaff.Size = new System.Drawing.Size(200, 72);
            this.picStaff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStaff.TabIndex = 0;
            this.picStaff.TabStop = false;
            // 
            // panelDisplay
            // 
            this.panelDisplay.Controls.Add(this.label1);
            this.panelDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDisplay.Location = new System.Drawing.Point(200, 50);
            this.panelDisplay.Name = "panelDisplay";
            this.panelDisplay.Size = new System.Drawing.Size(961, 614);
            this.panelDisplay.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Kh Preyveng", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(3, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(955, 219);
            this.label1.TabIndex = 0;
            this.label1.Text = "សូមស្វាគមន៍";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStripExpense
            // 
            this.contextMenuStripExpense.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expenseTypeToolStripMenuItem,
            this.expenseToolStripMenuItem});
            this.contextMenuStripExpense.Name = "contextMenuStripExpense";
            this.contextMenuStripExpense.Size = new System.Drawing.Size(161, 60);
            // 
            // expenseTypeToolStripMenuItem
            // 
            this.expenseTypeToolStripMenuItem.Font = new System.Drawing.Font("Kh Preyveng", 9.75F);
            this.expenseTypeToolStripMenuItem.Name = "expenseTypeToolStripMenuItem";
            this.expenseTypeToolStripMenuItem.Size = new System.Drawing.Size(160, 28);
            this.expenseTypeToolStripMenuItem.Text = "ប្រភេទ ចំណាយ";
            this.expenseTypeToolStripMenuItem.Click += new System.EventHandler(this.expenseTypeToolStripMenuItem_Click);
            // 
            // expenseToolStripMenuItem
            // 
            this.expenseToolStripMenuItem.Font = new System.Drawing.Font("Kh Preyveng", 9.75F);
            this.expenseToolStripMenuItem.Name = "expenseToolStripMenuItem";
            this.expenseToolStripMenuItem.Size = new System.Drawing.Size(160, 28);
            this.expenseToolStripMenuItem.Text = "កត់ត្រា ចំណាយ";
            this.expenseToolStripMenuItem.Click += new System.EventHandler(this.expenseToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1161, 664);
            this.Controls.Add(this.panelDisplay);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmMain";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.contextMenuStripSetting.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picStaff)).EndInit();
            this.panelDisplay.ResumeLayout(false);
            this.contextMenuStripExpense.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picStaff;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Panel panelDisplay;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lbNameUser;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.Label lblSetting;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSetting;
        private System.Windows.Forms.ToolStripMenuItem exchangeRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.ToolStripMenuItem typePaymentToolStripMenuItem;
        private System.Windows.Forms.Button btnReportIncome;
        private System.Windows.Forms.Button btnReportExpense;
        private System.Windows.Forms.Button btnExpense;
        private System.Windows.Forms.Button btnCashier;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripExpense;
        private System.Windows.Forms.ToolStripMenuItem expenseTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configReceiptToolStripMenuItem;
    }
}

