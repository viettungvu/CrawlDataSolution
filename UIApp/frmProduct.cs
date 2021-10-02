using BL;
using ES;
using Models;
using Models.CustomEventArgs;
using Models.Pagings;
using Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIApp.UtilsMessages;
using Utils;
using static Models.AllEnums;

namespace UIApp
{
    public partial class frmProduct : Form
    {
        private readonly ProductService _service;
        public frmProduct(ProductService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            pager1.Visible = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            dpkCreateFrom.Checked = false;
            dpkCreateTo.Checked = false;
        }
        // Tạo mới sản phẩm
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmAddOrEdit frm = new frmAddOrEdit(false);
            frm.ValueUpdated += AddNewProduct;
            frm.ShowDialog();
        }
        private async void AddNewProduct(object sender, CUProductEventArg e)
        {
            var res = await _service.Create(e.Product);
            DisplayMessage.Display(res, "Thêm sản phẩm thành công");
        }
        // Cập nhật sản phẩm
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product p = GetSelectedRow();
            frmAddOrEdit frm = new frmAddOrEdit(true, p);
            frm.ValueUpdated += UpdateProduct;
            frm.ShowDialog();
        }
        private async void UpdateProduct(object sender, CUProductEventArg e)
        {
            var res = await _service.Update(e.Product);
            DisplayMessage.Display(res, "Cập nhật sản phẩm thành công");
        }
        // Xóa sản phẩm 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to delete this?", "Delete product", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                var currProduct = GetSelectedRow();
                if (currProduct != null)
                {
                    var res = _service.Delete(currProduct.Id);
                    DisplayMessage.Display(res, "Xóa sản phẩm thành công");
                }
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PagingRequestBase request;
            if (pager1.Source != null)
            {
                request = new PagingRequestBase { PageIndex = pager1.Source.PageIndex, PageSize = pager1.Source.PageSize };
            }
            else
            {
                request = new PagingRequestBase { PageIndex = 1, PageSize = 10 };
            }
            var response = _service.GetAll(request);
            if (response.IsSuccess)
            {
                dgvProducts.DataSource = response.Data.Items;
                pager1.Source = response.Data;
            }
            else
            {
                // Do some thing
            }
        }
        //Tim kiem san pham
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var request = GetFormData();
            if (request != null)
            {
                var response = _service.Search(request);
                if (response.IsSuccess)
                {
                    dgvProducts.DataSource = response.Data.Items;
                    pager1.Source = response.Data;
                }
                else
                {
                    MessageBox.Show(response.ErrorMessage);
                }
            }
        }
        //Lấy thông tin tìm kiếm trên form
        private SearchProductRequest GetFormData()
        {
            SearchProductRequest request = new() { PageIndex = 1, PageSize = 10 };
            /* Ten, gia, ngay tao, so luong link */
            request.ProductName = txtName.Text;
            if (!string.IsNullOrEmpty(txtLowPrice.Text))
            {
                try
                {
                    request.LowPrice = txtLowPrice.Text.ConvertToLong();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    txtLowPrice.Focus();
                    return null;
                }
            }
            if (!string.IsNullOrEmpty(txtHighPrice.Text))
            {
                try
                {
                    request.HighPrice = txtHighPrice.Text.ConvertToLong();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    txtHighPrice.Focus();
                    return null;
                }
            }
            if (!string.IsNullOrEmpty(txtLowQuantity.Text))
            {
                try
                {
                    request.LowQuantity = int.Parse(txtLowQuantity.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Quantity is invalid format");
                    txtLowQuantity.Focus();
                    return null;
                }
            }
            if (!string.IsNullOrEmpty(txtHighQuantity.Text))
            {
                try
                {
                    request.HighQuantity = int.Parse(txtHighQuantity.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Quantity is invalid format");
                    txtHighQuantity.Focus();
                    return null;
                }
            }
            if (dpkCreateFrom.Checked)
            {
                request.DateCreatedFrom = dpkCreateFrom.Value;
            }
            if (dpkCreateTo.Checked)
            {
                request.DateCreatedTo = dpkCreateTo.Value;
            }
            return request;
        }
        // Kích hoạt nút Update và Delete
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
        }
        // Lấy thông tin item đang được chọn trong gridView
        private Product GetSelectedRow()
        {
            Product p = new();
            var currRow = dgvProducts.SelectedRows[0];
            if (currRow.Cells[0].Value != null)
            {
                p.Id = currRow.Cells[0].Value.ToString();
            }
            if (currRow.Cells[1].Value != null)
            {
                p.Name = currRow.Cells[1].Value.ToString();
            }
            if (currRow.Cells[2].Value != null)
            {
                p.Description = currRow.Cells[2].Value.ToString();
            }
            if (currRow.Cells[3].Value != null)
            {
                p.Brand = currRow.Cells[3].Value.ToString();
            }
            if (currRow.Cells[4].Value != null)
            {
                p.Model = currRow.Cells[4].Value.ToString();
            }
            if (currRow.Cells[5].Value != null)
            {
                try
                {
                    p.Price = currRow.Cells[5].Value.ToString().ConvertToLong();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
            if (currRow.Cells[6].Value != null)
            {
                try
                {
                    ProductStatus status;
                    Enum.TryParse(currRow.Cells[6].Value.ToString(), out status);
                    p.Status = status;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
            if (currRow.Cells[8].Value != null)
            {
                p.TotalLinks = int.Parse(currRow.Cells[8].Value.ToString());
            }
            return p;
        }
    }
}
