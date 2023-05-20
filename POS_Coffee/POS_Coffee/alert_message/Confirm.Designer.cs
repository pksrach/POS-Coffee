namespace POS_Coffee.AlertMessage
{
    partial class Confirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Confirm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbHeadTitle = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(169)))), ((int)(((byte)(132)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lbHeadTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 40);
            this.panel1.TabIndex = 4;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyMouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyMouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(571, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.pictureBox1.Size = new System.Drawing.Size(27, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lbHeadTitle
            // 
            this.lbHeadTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbHeadTitle.Font = new System.Drawing.Font("Kh Preyveng", 11.25F);
            this.lbHeadTitle.ForeColor = System.Drawing.Color.White;
            this.lbHeadTitle.Location = new System.Drawing.Point(0, 0);
            this.lbHeadTitle.Name = "lbHeadTitle";
            this.lbHeadTitle.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbHeadTitle.Size = new System.Drawing.Size(236, 38);
            this.lbHeadTitle.TabIndex = 0;
            this.lbHeadTitle.Text = "Head Title";
            this.lbHeadTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbHeadTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyMouseDown);
            this.lbHeadTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyMouseMove);
            // 
            // lbTitle
            // 
            this.lbTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTitle.Font = new System.Drawing.Font("Kh Preyveng", 11.25F);
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(4, 43);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(593, 222);
            this.lbTitle.TabIndex = 5;
            this.lbTitle.Text = "Title";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNo
            // 
            this.btnNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.FlatAppearance.BorderSize = 0;
            this.btnNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.Font = new System.Drawing.Font("Kh Preyveng", 11.25F);
            this.btnNo.ForeColor = System.Drawing.Color.White;
            this.btnNo.Location = new System.Drawing.Point(97, 0);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(60, 36);
            this.btnNo.TabIndex = 3;
            this.btnNo.Text = "ត្រលប់";
            this.btnNo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnClose_Click);
            this.btnNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnNo_KeyDown);
            this.btnNo.MouseEnter += new System.EventHandler(this.btnNo_MouseEnter);
            this.btnNo.MouseLeave += new System.EventHandler(this.btnNo_MouseLeave);
            // 
            // btnYes
            // 
            this.btnYes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYes.FlatAppearance.BorderSize = 0;
            this.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.Font = new System.Drawing.Font("Kh Preyveng", 11.25F);
            this.btnYes.ForeColor = System.Drawing.Color.White;
            this.btnYes.Location = new System.Drawing.Point(3, 0);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(60, 36);
            this.btnYes.TabIndex = 6;
            this.btnYes.Text = "ព្រម";
            this.btnYes.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            this.btnYes.MouseEnter += new System.EventHandler(this.btnYes_MouseEnter);
            this.btnYes.MouseLeave += new System.EventHandler(this.btnYes_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNo);
            this.panel2.Controls.Add(this.btnYes);
            this.panel2.Location = new System.Drawing.Point(220, 268);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(160, 36);
            this.panel2.TabIndex = 7;
            // 
            // Confirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(75)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(600, 305);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Kantumruy Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Confirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirm";
            this.Shown += new System.EventHandler(this.Confirm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Confirm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyMouseMove);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbHeadTitle;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Panel panel2;
    }
}