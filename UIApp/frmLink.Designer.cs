
namespace UIApp
{
    partial class frmLink
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dpkCreateFrom = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panelPrice = new System.Windows.Forms.Panel();
            this.txtLowPrice = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtHighPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxIsBelongTo = new System.Windows.Forms.CheckBox();
            this.cbbStatus = new System.Windows.Forms.ComboBox();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.pager = new UIApp.UcControls.pager();
            this.panelToolBar = new System.Windows.Forms.TableLayoutPanel();
            this.btnUnsign = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dpkCreateTo = new System.Windows.Forms.DateTimePicker();
            this.dpkUpdateFrom = new System.Windows.Forms.DateTimePicker();
            this.dpkUpdateTo = new System.Windows.Forms.DateTimePicker();
            this.mainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelPrice.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.panelToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.ColumnCount = 1;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.Controls.Add(this.panel1, 0, 0);
            this.mainPanel.Controls.Add(this.panel6, 0, 2);
            this.mainPanel.Controls.Add(this.panelToolBar, 0, 1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 3;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.mainPanel.Size = new System.Drawing.Size(1182, 653);
            this.mainPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1176, 189);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1176, 189);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panelPrice);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbxIsBelongTo);
            this.panel2.Controls.Add(this.cbbStatus);
            this.panel2.Controls.Add(this.txtDomain);
            this.panel2.Controls.Add(this.txtProductName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1170, 183);
            this.panel2.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.dpkUpdateTo);
            this.panel4.Controls.Add(this.dpkUpdateFrom);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Location = new System.Drawing.Point(791, 91);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(362, 74);
            this.panel4.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Last update";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(189, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = "To";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 20);
            this.label10.TabIndex = 19;
            this.label10.Text = "From";
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dpkCreateTo);
            this.panel3.Controls.Add(this.dpkCreateFrom);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(386, 91);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(362, 74);
            this.panel3.TabIndex = 23;
            // 
            // dpkCreateFrom
            // 
            this.dpkCreateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpkCreateFrom.Location = new System.Drawing.Point(51, 39);
            this.dpkCreateFrom.Name = "dpkCreateFrom";
            this.dpkCreateFrom.ShowCheckBox = true;
            this.dpkCreateFrom.Size = new System.Drawing.Size(129, 27);
            this.dpkCreateFrom.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Date created ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "From";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(186, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "To";
            // 
            // panelPrice
            // 
            this.panelPrice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPrice.Controls.Add(this.txtLowPrice);
            this.panelPrice.Controls.Add(this.label12);
            this.panelPrice.Controls.Add(this.txtHighPrice);
            this.panelPrice.Controls.Add(this.label3);
            this.panelPrice.Controls.Add(this.label4);
            this.panelPrice.Location = new System.Drawing.Point(791, 12);
            this.panelPrice.Name = "panelPrice";
            this.panelPrice.Size = new System.Drawing.Size(362, 73);
            this.panelPrice.TabIndex = 22;
            // 
            // txtLowPrice
            // 
            this.txtLowPrice.Location = new System.Drawing.Point(42, 34);
            this.txtLowPrice.Name = "txtLowPrice";
            this.txtLowPrice.Size = new System.Drawing.Size(128, 27);
            this.txtLowPrice.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 20);
            this.label12.TabIndex = 21;
            this.label12.Text = "Product price";
            // 
            // txtHighPrice
            // 
            this.txtHighPrice.Location = new System.Drawing.Point(221, 34);
            this.txtHighPrice.Name = "txtHighPrice";
            this.txtHighPrice.Size = new System.Drawing.Size(128, 27);
            this.txtHighPrice.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Low";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "High";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(386, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "State";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Domain";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Product name";
            // 
            // cbxIsBelongTo
            // 
            this.cbxIsBelongTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxIsBelongTo.AutoSize = true;
            this.cbxIsBelongTo.Location = new System.Drawing.Point(17, 141);
            this.cbxIsBelongTo.Name = "cbxIsBelongTo";
            this.cbxIsBelongTo.Size = new System.Drawing.Size(200, 24);
            this.cbxIsBelongTo.TabIndex = 9;
            this.cbxIsBelongTo.Text = "Is belong to any product?";
            this.cbxIsBelongTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbxIsBelongTo.UseVisualStyleBackColor = true;
            // 
            // cbbStatus
            // 
            this.cbbStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbbStatus.BackColor = System.Drawing.Color.White;
            this.cbbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbStatus.ForeColor = System.Drawing.Color.Black;
            this.cbbStatus.FormattingEnabled = true;
            this.cbbStatus.Location = new System.Drawing.Point(386, 42);
            this.cbbStatus.Name = "cbbStatus";
            this.cbbStatus.Size = new System.Drawing.Size(362, 28);
            this.cbbStatus.TabIndex = 7;
            // 
            // txtDomain
            // 
            this.txtDomain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDomain.Location = new System.Drawing.Point(17, 102);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(318, 27);
            this.txtDomain.TabIndex = 5;
            // 
            // txtProductName
            // 
            this.txtProductName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtProductName.Location = new System.Drawing.Point(17, 41);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(318, 27);
            this.txtProductName.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvResult);
            this.panel6.Controls.Add(this.pager);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 263);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1176, 387);
            this.panel6.TabIndex = 3;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResult.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(0, 0);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvResult.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.RowTemplate.Height = 29;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(1176, 345);
            this.dgvResult.TabIndex = 1;
            this.dgvResult.DataSourceChanged += new System.EventHandler(this.dgvResult_DataSourceChanged);
            this.dgvResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellContentClick);
            this.dgvResult.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvResult_RowStateChanged);
            // 
            // pager
            // 
            this.pager.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pager.Location = new System.Drawing.Point(0, 345);
            this.pager.Margin = new System.Windows.Forms.Padding(0);
            this.pager.Name = "pager";
            this.pager.Size = new System.Drawing.Size(1176, 42);
            this.pager.Source = null;
            this.pager.TabIndex = 4;
            // 
            // panelToolBar
            // 
            this.panelToolBar.ColumnCount = 5;
            this.panelToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.panelToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.panelToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.panelToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.panelToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.panelToolBar.Controls.Add(this.btnUnsign, 3, 0);
            this.panelToolBar.Controls.Add(this.btnAssign, 2, 0);
            this.panelToolBar.Controls.Add(this.btnSearch, 1, 0);
            this.panelToolBar.Controls.Add(this.btnLoad, 0, 0);
            this.panelToolBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelToolBar.Location = new System.Drawing.Point(3, 198);
            this.panelToolBar.Name = "panelToolBar";
            this.panelToolBar.RowCount = 1;
            this.panelToolBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelToolBar.Size = new System.Drawing.Size(1176, 59);
            this.panelToolBar.TabIndex = 4;
            // 
            // btnUnsign
            // 
            this.btnUnsign.BackColor = System.Drawing.Color.White;
            this.btnUnsign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUnsign.Enabled = false;
            this.btnUnsign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnsign.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUnsign.Location = new System.Drawing.Point(393, 3);
            this.btnUnsign.Name = "btnUnsign";
            this.btnUnsign.Size = new System.Drawing.Size(124, 53);
            this.btnUnsign.TabIndex = 3;
            this.btnUnsign.Text = "UnAssign";
            this.btnUnsign.UseVisualStyleBackColor = false;
            this.btnUnsign.Click += new System.EventHandler(this.btnUnsign_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.BackColor = System.Drawing.Color.White;
            this.btnAssign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAssign.Enabled = false;
            this.btnAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssign.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAssign.Location = new System.Drawing.Point(263, 3);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(124, 53);
            this.btnAssign.TabIndex = 1;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = false;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.Location = new System.Drawing.Point(133, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(124, 53);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.White;
            this.btnLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLoad.Location = new System.Drawing.Point(3, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(124, 53);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load data";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // dpkCreateTo
            // 
            this.dpkCreateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpkCreateTo.Location = new System.Drawing.Point(217, 39);
            this.dpkCreateTo.Name = "dpkCreateTo";
            this.dpkCreateTo.ShowCheckBox = true;
            this.dpkCreateTo.Size = new System.Drawing.Size(129, 27);
            this.dpkCreateTo.TabIndex = 28;
            // 
            // dpkUpdateFrom
            // 
            this.dpkUpdateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpkUpdateFrom.Location = new System.Drawing.Point(54, 39);
            this.dpkUpdateFrom.Name = "dpkUpdateFrom";
            this.dpkUpdateFrom.ShowCheckBox = true;
            this.dpkUpdateFrom.Size = new System.Drawing.Size(129, 27);
            this.dpkUpdateFrom.TabIndex = 29;
            // 
            // dpkUpdateTo
            // 
            this.dpkUpdateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpkUpdateTo.Location = new System.Drawing.Point(221, 39);
            this.dpkUpdateTo.Name = "dpkUpdateTo";
            this.dpkUpdateTo.ShowCheckBox = true;
            this.dpkUpdateTo.Size = new System.Drawing.Size(129, 27);
            this.dpkUpdateTo.TabIndex = 30;
            // 
            // frmLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLink";
            this.Tag = "frmLink";
            this.Text = "Product Link";
            this.Load += new System.EventHandler(this.frmLink_Load);
            this.mainPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelPrice.ResumeLayout(false);
            this.panelPrice.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.panelToolBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbbStatus;
        private System.Windows.Forms.TextBox txtHighPrice;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbxIsBelongTo;
        private System.Windows.Forms.TextBox txtLowPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel6;
        private UcControls.pager pager;
        private System.Windows.Forms.TableLayoutPanel panelToolBar;
        private System.Windows.Forms.Button btnUnsign;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.DateTimePicker dpkCreateFrom;
        private System.Windows.Forms.DateTimePicker dpkUpdateTo;
        private System.Windows.Forms.DateTimePicker dpkUpdateFrom;
        private System.Windows.Forms.DateTimePicker dpkCreateTo;
    }
}