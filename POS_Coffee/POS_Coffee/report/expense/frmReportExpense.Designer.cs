namespace POS_Coffee.Subform
{
    partial class frmReportExpense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportExpense));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxDateFilter = new System.Windows.Forms.CheckBox();
            this.lblResfress = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnPreviewPrintDetail = new System.Windows.Forms.Button();
            this.lblPagination = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDatetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal_us = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal_kh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreated_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStaff_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPreviewPrint = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(75)))), ((int)(((byte)(81)))));
            this.panel1.Controls.Add(this.checkBoxDateFilter);
            this.panel1.Controls.Add(this.lblResfress);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1185, 40);
            this.panel1.TabIndex = 0;
            // 
            // checkBoxDateFilter
            // 
            this.checkBoxDateFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxDateFilter.AutoSize = true;
            this.checkBoxDateFilter.Font = new System.Drawing.Font("Kh Preyveng", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDateFilter.Location = new System.Drawing.Point(1088, 14);
            this.checkBoxDateFilter.Name = "checkBoxDateFilter";
            this.checkBoxDateFilter.Size = new System.Drawing.Size(15, 14);
            this.checkBoxDateFilter.TabIndex = 17;
            this.checkBoxDateFilter.UseVisualStyleBackColor = true;
            this.checkBoxDateFilter.CheckedChanged += new System.EventHandler(this.checkBoxDateFilter_CheckedChanged);
            // 
            // lblResfress
            // 
            this.lblResfress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResfress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblResfress.Image = ((System.Drawing.Image)(resources.GetObject("lblResfress.Image")));
            this.lblResfress.Location = new System.Drawing.Point(1139, 5);
            this.lblResfress.Name = "lblResfress";
            this.lblResfress.Size = new System.Drawing.Size(34, 30);
            this.lblResfress.TabIndex = 16;
            this.lblResfress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblResfress.Click += new System.EventHandler(this.lblResfress_Click);
            this.lblResfress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblResfress_MouseDown);
            this.lblResfress.MouseEnter += new System.EventHandler(this.lblResfress_MouseEnter);
            this.lblResfress.MouseLeave += new System.EventHandler(this.lblResfress_MouseLeave);
            this.lblResfress.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblResfress_MouseMove);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Kh Preyveng", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(922, 5);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(160, 29);
            this.dateTimePicker2.TabIndex = 15;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Kh Preyveng", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(744, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(160, 29);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Kh Preyveng", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(200, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "របាយការណ៍ ចំណាយ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(657, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 29);
            this.label2.TabIndex = 13;
            this.label2.Text = "Filter By";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnPreviewPrint);
            this.panel3.Controls.Add(this.btnPreviewPrintDetail);
            this.panel3.Controls.Add(this.lblPagination);
            this.panel3.Controls.Add(this.btnNext);
            this.panel3.Controls.Add(this.btnPre);
            this.panel3.Controls.Add(this.btnEdit);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 558);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1185, 64);
            this.panel3.TabIndex = 3;
            // 
            // btnPreviewPrintDetail
            // 
            this.btnPreviewPrintDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(169)))), ((int)(((byte)(132)))));
            this.btnPreviewPrintDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreviewPrintDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviewPrintDetail.ForeColor = System.Drawing.Color.White;
            this.btnPreviewPrintDetail.Location = new System.Drawing.Point(148, 11);
            this.btnPreviewPrintDetail.Name = "btnPreviewPrintDetail";
            this.btnPreviewPrintDetail.Size = new System.Drawing.Size(153, 40);
            this.btnPreviewPrintDetail.TabIndex = 12;
            this.btnPreviewPrintDetail.Text = "Preview Print លម្អិត";
            this.btnPreviewPrintDetail.UseVisualStyleBackColor = false;
            this.btnPreviewPrintDetail.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblPagination
            // 
            this.lblPagination.Location = new System.Drawing.Point(688, 15);
            this.lblPagination.Name = "lblPagination";
            this.lblPagination.Size = new System.Drawing.Size(125, 32);
            this.lblPagination.TabIndex = 11;
            this.lblPagination.Text = "label4";
            this.lblPagination.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(819, 14);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(98, 35);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPre
            // 
            this.btnPre.Location = new System.Drawing.Point(584, 14);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(98, 35);
            this.btnPre.TabIndex = 9;
            this.btnPre.Text = "Previous";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(169)))), ((int)(((byte)(132)))));
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(11, 11);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(110, 40);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "កែប្រែ";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(1062, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 40);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "លុប";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(169)))), ((int)(((byte)(132)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Kh Preyveng", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.colId,
            this.colDatetime,
            this.colTotal_us,
            this.colTotal_kh,
            this.colCreated_by,
            this.colStaff_name});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 40);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 40;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1185, 518);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "ល.រ";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 61;
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colDatetime
            // 
            this.colDatetime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDatetime.HeaderText = "កាលបរិច្ឆេទ";
            this.colDatetime.Name = "colDatetime";
            this.colDatetime.ReadOnly = true;
            // 
            // colTotal_us
            // 
            this.colTotal_us.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTotal_us.HeaderText = "សរុបគិតជា $";
            this.colTotal_us.Name = "colTotal_us";
            this.colTotal_us.ReadOnly = true;
            // 
            // colTotal_kh
            // 
            this.colTotal_kh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTotal_kh.HeaderText = "សរុបគិតជា ៛";
            this.colTotal_kh.Name = "colTotal_kh";
            this.colTotal_kh.ReadOnly = true;
            // 
            // colCreated_by
            // 
            this.colCreated_by.HeaderText = "Created By";
            this.colCreated_by.Name = "colCreated_by";
            this.colCreated_by.ReadOnly = true;
            this.colCreated_by.Visible = false;
            // 
            // colStaff_name
            // 
            this.colStaff_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStaff_name.HeaderText = "បុគ្គលិក";
            this.colStaff_name.Name = "colStaff_name";
            this.colStaff_name.ReadOnly = true;
            // 
            // btnPreviewPrint
            // 
            this.btnPreviewPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(169)))), ((int)(((byte)(132)))));
            this.btnPreviewPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreviewPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviewPrint.ForeColor = System.Drawing.Color.White;
            this.btnPreviewPrint.Location = new System.Drawing.Point(329, 11);
            this.btnPreviewPrint.Name = "btnPreviewPrint";
            this.btnPreviewPrint.Size = new System.Drawing.Size(113, 40);
            this.btnPreviewPrint.TabIndex = 13;
            this.btnPreviewPrint.Text = "Preview Print";
            this.btnPreviewPrint.UseVisualStyleBackColor = false;
            this.btnPreviewPrint.Click += new System.EventHandler(this.btnPreviewPrint_Click);
            // 
            // frmReportExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1185, 622);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Kh Preyveng", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "frmReportExpense";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportIncome_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblPagination;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Button btnEdit;
        public System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPreviewPrintDetail;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblResfress;
        private System.Windows.Forms.CheckBox checkBoxDateFilter;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal_us;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal_kh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreated_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStaff_name;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPreviewPrint;
    }
}