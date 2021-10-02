
namespace UIApp
{
    partial class frmAnalyze
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
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelLink = new System.Windows.Forms.Panel();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dpkFromDate = new System.Windows.Forms.DateTimePicker();
            this.dpkToDate = new System.Windows.Forms.DateTimePicker();
            this.panelToolBar = new System.Windows.Forms.TableLayoutPanel();
            this.btnAnalyzeLink = new System.Windows.Forms.Button();
            this.btnAnalyzeProduct = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelProduct = new System.Windows.Forms.Panel();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblAverage = new System.Windows.Forms.Label();
            this.lblSum = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelLink.SuspendLayout();
            this.panelToolBar.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelProduct.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.ColumnCount = 1;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.Controls.Add(this.panel1, 0, 0);
            this.mainPanel.Controls.Add(this.panel2, 0, 1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 2;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.Size = new System.Drawing.Size(985, 555);
            this.mainPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelLink);
            this.panel1.Controls.Add(this.panelToolBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(979, 166);
            this.panel1.TabIndex = 1;
            // 
            // panelLink
            // 
            this.panelLink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLink.Controls.Add(this.txtDomain);
            this.panelLink.Controls.Add(this.label4);
            this.panelLink.Controls.Add(this.label1);
            this.panelLink.Controls.Add(this.label2);
            this.panelLink.Controls.Add(this.dpkFromDate);
            this.panelLink.Controls.Add(this.dpkToDate);
            this.panelLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLink.Location = new System.Drawing.Point(0, 0);
            this.panelLink.Name = "panelLink";
            this.panelLink.Size = new System.Drawing.Size(979, 120);
            this.panelLink.TabIndex = 9;
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(112, 14);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(300, 27);
            this.txtDomain.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Domain";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "To";
            // 
            // dpkFromDate
            // 
            this.dpkFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpkFromDate.Location = new System.Drawing.Point(112, 58);
            this.dpkFromDate.Name = "dpkFromDate";
            this.dpkFromDate.ShowCheckBox = true;
            this.dpkFromDate.Size = new System.Drawing.Size(130, 27);
            this.dpkFromDate.TabIndex = 2;
            // 
            // dpkToDate
            // 
            this.dpkToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpkToDate.Location = new System.Drawing.Point(279, 58);
            this.dpkToDate.Name = "dpkToDate";
            this.dpkToDate.ShowCheckBox = true;
            this.dpkToDate.Size = new System.Drawing.Size(133, 27);
            this.dpkToDate.TabIndex = 1;
            // 
            // panelToolBar
            // 
            this.panelToolBar.ColumnCount = 3;
            this.panelToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelToolBar.Controls.Add(this.btnAnalyzeLink, 0, 0);
            this.panelToolBar.Controls.Add(this.btnAnalyzeProduct, 2, 0);
            this.panelToolBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelToolBar.Location = new System.Drawing.Point(0, 120);
            this.panelToolBar.Name = "panelToolBar";
            this.panelToolBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panelToolBar.RowCount = 1;
            this.panelToolBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelToolBar.Size = new System.Drawing.Size(979, 46);
            this.panelToolBar.TabIndex = 6;
            // 
            // btnAnalyzeLink
            // 
            this.btnAnalyzeLink.BackColor = System.Drawing.Color.White;
            this.btnAnalyzeLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalyzeLink.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAnalyzeLink.Location = new System.Drawing.Point(3, 3);
            this.btnAnalyzeLink.Name = "btnAnalyzeLink";
            this.btnAnalyzeLink.Size = new System.Drawing.Size(159, 40);
            this.btnAnalyzeLink.TabIndex = 1;
            this.btnAnalyzeLink.Text = "Analyze link";
            this.btnAnalyzeLink.UseVisualStyleBackColor = false;
            this.btnAnalyzeLink.Click += new System.EventHandler(this.btnAnalyzeLink_Click);
            // 
            // btnAnalyzeProduct
            // 
            this.btnAnalyzeProduct.BackColor = System.Drawing.Color.White;
            this.btnAnalyzeProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalyzeProduct.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAnalyzeProduct.Location = new System.Drawing.Point(168, 3);
            this.btnAnalyzeProduct.Name = "btnAnalyzeProduct";
            this.btnAnalyzeProduct.Size = new System.Drawing.Size(152, 40);
            this.btnAnalyzeProduct.TabIndex = 0;
            this.btnAnalyzeProduct.Tag = "frmAnalyze";
            this.btnAnalyzeProduct.Text = "Analyze product";
            this.btnAnalyzeProduct.UseVisualStyleBackColor = false;
            this.btnAnalyzeProduct.Click += new System.EventHandler(this.btnAnalyzeProduct_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelProduct);
            this.panel2.Controls.Add(this.lblInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 175);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(979, 377);
            this.panel2.TabIndex = 2;
            // 
            // panelProduct
            // 
            this.panelProduct.Controls.Add(this.lblMax);
            this.panelProduct.Controls.Add(this.lblMin);
            this.panelProduct.Controls.Add(this.lblAverage);
            this.panelProduct.Controls.Add(this.lblSum);
            this.panelProduct.Controls.Add(this.lblCount);
            this.panelProduct.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.panelProduct.Location = new System.Drawing.Point(98, 12);
            this.panelProduct.Name = "panelProduct";
            this.panelProduct.Size = new System.Drawing.Size(862, 283);
            this.panelProduct.TabIndex = 1;
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(33, 183);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(44, 23);
            this.lblMax.TabIndex = 4;
            this.lblMax.Text = "Max";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(33, 233);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(40, 23);
            this.lblMin.TabIndex = 3;
            this.lblMin.Text = "Min";
            // 
            // lblAverage
            // 
            this.lblAverage.AutoSize = true;
            this.lblAverage.Location = new System.Drawing.Point(33, 133);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(73, 23);
            this.lblAverage.TabIndex = 2;
            this.lblAverage.Text = "Average";
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.Location = new System.Drawing.Point(33, 83);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(44, 23);
            this.lblSum.TabIndex = 1;
            this.lblSum.Text = "Sum";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(33, 33);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(57, 23);
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "Count";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(23, 22);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(56, 20);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Result: ";
            // 
            // frmAnalyze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(985, 555);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAnalyze";
            this.Text = "Analyze link price change";
            this.Load += new System.EventHandler(this.frmAnalyze_Load);
            this.mainPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelLink.ResumeLayout(false);
            this.panelLink.PerformLayout();
            this.panelToolBar.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelProduct.ResumeLayout(false);
            this.panelProduct.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel panelToolBar;
        private System.Windows.Forms.Button btnAnalyzeProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpkFromDate;
        private System.Windows.Forms.DateTimePicker dpkToDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Button btnAnalyzeLink;
        private System.Windows.Forms.Panel panelLink;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Panel panelProduct;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.Label lblCount;
    }
}