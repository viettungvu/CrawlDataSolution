using BL;
using ES;
using Models.CustomEventArgs;
using Models.Links;
using Models.Pagings;
using Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIApp.UtilsMessages;
using Utils;
using static Models.AllEnums;

namespace UIApp
{
    public partial class frmLink : Form
    {
        private readonly ProductService _productService;
        private readonly LinkService _linkService;
        public frmLink(LinkService linkService, ProductService productService)
        {
            InitializeComponent();
            _productService = productService;
            _linkService = linkService;
        }
        private void frmLink_Load(object sender, EventArgs e)
        {
            cbbStatus.DataSource = Enum.GetValues(typeof(LinkStatus));
            cbbStatus.SelectedIndex = -1;
            dpkCreateFrom.Checked = false;
            dpkCreateTo.Checked = false;
            dpkUpdateFrom.Checked = false;
            dpkUpdateTo.Checked = false;
            pager.Visible = false;
            pager.SendRequest += Pager2_SendRequest;
        }
        private async void Pager2_SendRequest(object sender, PagerSendDataEventArg e)
        {
            var res = await _linkService.GetAll(e.PagingRequest);
            if (res.IsSuccess)
            {
                dgvResult.DataSource = res.Data.Items;
                if (res.Data.PageCount > 1)
                {
                    pager.Source = res.Data;
                    pager.Visible = true;
                }
            }
            else
            {
                MessageBox.Show(res.ErrorMessage);
            }
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var request = GetFormData();
            if (request != null)
            {
                var res = await _linkService.Search(request);
                if (res.IsSuccess)
                {
                    dgvResult.DataSource = res.Data.Items;
                    if (res.Data.PageCount > 1)
                    {
                        pager.Source = res.Data;
                        pager.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show(res.ErrorMessage);
                }
            }
        }
        private SearchLinkRequest GetFormData()
        {
            var request = new SearchLinkRequest()
            {
                PageIndex = 1,
                PageSize = 10,
            };
            if (!string.IsNullOrEmpty(txtLowPrice.Text))
            {
                try
                {
                    request.LowPrice = txtLowPrice.Text.ConvertToLong();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
                    return null;
                }
            }
            if (cbbStatus.SelectedIndex != -1)
            {
                try
                {
                    LinkStatus status;
                    Enum.TryParse(cbbStatus.SelectedValue.ToString(), out status);
                    request.Status = status;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
            if (dpkUpdateFrom.Checked)
            {
                request.DateCreatedFrom = dpkUpdateFrom.Value;
            }
            if (dpkUpdateTo.Checked)
            {
                request.DateCreatedTo = dpkUpdateTo.Value;
            }
            request.Domain = txtDomain.Text;
            request.IsBelongToAnyProduct = cbxIsBelongTo.Checked;
            request.ProductName = txtProductName.Text;
            return request;
        }
        private async void btnTest_Click(object sender, EventArgs e)
        {
            var pageingReq = new PagingRequestBase()
            {
                PageIndex = 1,
                PageSize = 10,
            };
            var res = await _linkService.GetAll(pageingReq);
            if (res.IsSuccess)
            {
                dgvResult.DataSource = res.Data.Items;
                if (res.Data.PageCount > 1)
                {
                    pager.Source = res.Data;
                    pager.Visible = true;
                }
            }
            else
            {
                MessageBox.Show(res.ErrorMessage);
            }

        }
        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAssign.Enabled = true;
            btnUnsign.Enabled = true;
        }
        private void dgvResult_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            btnAssign.Enabled = true;
            btnUnsign.Enabled = true;
        }
        private void dgvResult_DataSourceChanged(object sender, EventArgs e)
        {
            btnAssign.Enabled = false;
            btnUnsign.Enabled = false;
        }
        private void btnAssign_Click(object sender, EventArgs e)
        {
            frmAssignLink frm = new(_productService);
            frm.AssignLink += AssignLink;
            frm.ShowDialog();
        }
        private void AssignLink(object sender, StringEventArg e)
        {
            List<PartialLink> links = GetSelectedRow();
            var res = _linkService.Assign(links, e.Product);
            DisplayMessage.Display(res, "Gán link thành công");
        }
        private async void btnUnsign_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có chắc rằng bạn muốn reset productId của link này?");
            if (dialog == DialogResult.OK)
            {
                List<PartialLink> unLinks = GetSelectedRow();
                var res = await _linkService.UnAssign(unLinks);
                DisplayMessage.Display(res, "Reset ID thành công");
            }
        }
        private List<PartialLink> GetSelectedRow()
        {
            List<PartialLink> links = new();

            foreach (DataGridViewRow row in dgvResult.SelectedRows)
            {
                string id = row.Cells[0].Value.ToString();
                string productId = null;
                if (row.Cells[2].Value != null)
                {
                    productId = row.Cells[2].Value.ToString();
                }
                long price = 0;
                if (row.Cells[7].Value != null)
                {
                    price = row.Cells[7].Value.ToString().ConvertToLong();
                }
                links.Add(new PartialLink() { Id = id, ProductId = productId, ProductPrice = price });
            }
            return links;
        }

    }
}
