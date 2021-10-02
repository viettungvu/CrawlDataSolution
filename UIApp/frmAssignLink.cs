using BL;
using Models;
using Models.CustomEventArgs;
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

namespace UIApp
{
    public partial class frmAssignLink : Form
    {
        private readonly ProductService _service;
        public frmAssignLink(ProductService service)
        {
            InitializeComponent();
            _service = service;
            lblEmpty.Visible = false;
        }

        private event EventHandler<StringEventArg> assignLink;
        public event EventHandler<StringEventArg> AssignLink
        {
            add { assignLink += value; }
            remove { assignLink -= value; }
        }
        private void btnAssgin_Click(object sender, EventArgs e)
        {
            Product p = (Product)cbbListProduct.SelectedItem;
            if (p != null)
            {
                PartialProduct partial = new() { Id = p.Id, Price = p.Price, TotalLinks = p.TotalLinks };
                assignLink?.Invoke(this, new StringEventArg(partial));
                //assignLink?.Invoke(this, new StringEventArg(p.Name));
            }
        }
        private void frmAssignLink_Load(object sender, EventArgs e)
        {
            var res = _service.GetAll(new Models.Pagings.PagingRequestBase() { PageIndex = 1, PageSize = 1000 });
            if (res.IsSuccess)
            {
                cbbListProduct.DataSource = res.Data.Items;
                cbbListProduct.DisplayMember = "name";
            }
            else
            {
                lblEmpty.Text = res.ErrorMessage;
                lblEmpty.Visible = true;
            }
        }
    }
}
