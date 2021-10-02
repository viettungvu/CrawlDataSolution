using BL;
using Models.Aggregations;
using Models.Links;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace UIApp
{
    public partial class frmAnalyze : Form
    {
        private readonly LinkService _linkService;
        private readonly ProductService _productService;
        public frmAnalyze(LinkService linkService, ProductService productService)
        {
            InitializeComponent();
            _linkService = linkService;
            _productService = productService;
        }

        private void btnAnalyzeLink_Click(object sender, EventArgs e)
        {
            var request = new AnalyzeLinkRequest()
            {
                Domain = txtDomain.Text
            };
            if (dpkFromDate.Checked)
            {
                request.FromDate = dpkFromDate.Value;
            }
            if (dpkToDate.Checked)
            {
                request.ToDate = dpkToDate.Value;
            }

            var respone = _linkService.Analyze(request);
            lblInfo.Text = $"Result: {respone} links changed price";
            lblInfo.Visible = true;
            panelProduct.Visible = false;
        }

        private void btnAnalyzeProduct_Click(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
            var res = _productService.Analyze();
            AddItem(res);
        }
        private void AddItem(StatsResult statsResult)
        {
            panelProduct.Visible = true;
            lblCount.Text = $"Total {statsResult.Count} products";
            lblSum.Text = $"Total {statsResult.Sum} links assigned to products";
            lblAverage.Text = $"{statsResult.Average} links per a product";
            lblMax.Text = $"Maximum {statsResult.Max} link belong to a product";
            lblMin.Text = $"Minimum {statsResult.Min} link belong to a product";
        }
        private void frmAnalyze_Load(object sender, EventArgs e)
        {
            dpkFromDate.Checked = false;
            panelProduct.Visible = false;
            lblInfo.Visible = false;
        }
    }
}
