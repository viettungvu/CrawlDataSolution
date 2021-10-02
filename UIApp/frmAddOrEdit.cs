using BL;
using Models;
using Models.CustomEventArgs;
using System;
using System.Windows.Forms;
using Utils;
using static Models.AllEnums;

namespace UIApp
{
    public partial class frmAddOrEdit : Form
    {
        private Product product { get; set; }
        public frmAddOrEdit(bool isEdit, Product p = null)
        {
            InitializeComponent();
            product = p;
            LoadForm(isEdit, product);
        }
        private void LoadForm(bool isEdit, Product p = null)
        {
            cbbStatus.DataSource = Enum.GetValues(typeof(ProductStatus));
            if (isEdit)
            {
                Text = $"Update info for {p.Name}";
                btnAddOrEdit.Text = "Save";
                SetValue(p);
            }
            else
            {
                Text = $"Create new product";
                btnAddOrEdit.Text = "Add";
                Reset();
            }
            controlBar.CloseControl += ControlBar1_CloseControl;
        }
        private void SetValue(Product p)
        {
            txtId.Text = p.Id;
            txtName.Text = p.Name;
            txtBrand.Text = p.Brand;
            txtModel.Text = p.Model;
            txtDescription.Text = p.Description;
            txtPrice.Text = p.Price.ToString();
            cbbStatus.SelectedItem = p.Status;
            nberTotalLinks.Value = p.TotalLinks;
        }
        // Reset giá trị form
        private void Reset()
        {
            txtId.Text = null;
            txtName.Text = null;
            txtDescription.Text = null;
            txtBrand.Text = null;
            txtModel.Text = null;
            txtPrice.Text = null;
            cbbStatus.SelectedIndex = 0;
            nberTotalLinks.Value = 0;
            txtName.Focus();
        }

        private event EventHandler<CUProductEventArg> valueUpdated;
        public event EventHandler<CUProductEventArg> ValueUpdated
        {
            add { valueUpdated += value; }
            remove { valueUpdated -= value; }
        }
        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            var product = GetDataFromForm();
            valueUpdated?.Invoke(this, new CUProductEventArg(product));
        }

        //Lấy data từ form
        private Product GetDataFromForm()
        {
            Product p = new()
            {
                Id = txtId.Text
            };
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Name is required", "Required field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            p.Name = txtName.Text.Trim();
            p.Description = txtDescription.Text;
            p.Brand = txtBrand.Text;
            p.Model = txtModel.Text;
            if (!string.IsNullOrEmpty(txtPrice.Text))
            {
                try
                {
                    p.Price = txtPrice.Text.ConvertToLong();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    txtPrice.Focus();
                    return null;
                }
            }
            else
            {
                p.Price = -1;
            }
            try
            {
                ProductStatus status;
                Enum.TryParse(cbbStatus.SelectedValue.ToString(), out status);
                p.Status = status;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            p.TotalLinks = (int)nberTotalLinks.Value;
            p.DateCreated =DateTime.Now;
            return p;
        }
        // Sự kiện hủy AddOrEdit
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult notify = MessageBox.Show("Are you sure you want to cancel this progess?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (notify == DialogResult.Yes)
            {
                Close();
            }
        }
        private void ControlBar1_CloseControl(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
