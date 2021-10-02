
namespace UIApp
{
    partial class frmAssignLink
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
            this.btnAssgin = new System.Windows.Forms.Button();
            this.cbbListProduct = new System.Windows.Forms.ComboBox();
            this.lblEmpty = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAssgin
            // 
            this.btnAssgin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssgin.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAssgin.Location = new System.Drawing.Point(86, 115);
            this.btnAssgin.Name = "btnAssgin";
            this.btnAssgin.Size = new System.Drawing.Size(305, 52);
            this.btnAssgin.TabIndex = 1;
            this.btnAssgin.Text = "Assign";
            this.btnAssgin.UseVisualStyleBackColor = true;
            this.btnAssgin.Click += new System.EventHandler(this.btnAssgin_Click);
            // 
            // cbbListProduct
            // 
            this.cbbListProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbListProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbListProduct.FormattingEnabled = true;
            this.cbbListProduct.Location = new System.Drawing.Point(86, 34);
            this.cbbListProduct.Name = "cbbListProduct";
            this.cbbListProduct.Size = new System.Drawing.Size(305, 28);
            this.cbbListProduct.Sorted = true;
            this.cbbListProduct.TabIndex = 2;
            // 
            // lblEmpty
            // 
            this.lblEmpty.AutoSize = true;
            this.lblEmpty.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEmpty.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblEmpty.Location = new System.Drawing.Point(86, 65);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(53, 23);
            this.lblEmpty.TabIndex = 3;
            this.lblEmpty.Text = "label1";
            // 
            // frmAssignLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 205);
            this.Controls.Add(this.lblEmpty);
            this.Controls.Add(this.cbbListProduct);
            this.Controls.Add(this.btnAssgin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAssignLink";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Assign link";
            this.Load += new System.EventHandler(this.frmAssignLink_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAssgin;
        private System.Windows.Forms.ComboBox cbbListProduct;
        private System.Windows.Forms.Label lblEmpty;
    }
}