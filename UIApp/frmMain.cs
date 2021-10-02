using BL;
using System;
using System.Windows.Forms;

namespace UIApp
{
    public partial class frmMain : Form
    {
        private readonly ProductService productService;
        private readonly LinkService linkService;

        public frmMain()
        {
            InitializeComponent();
            productService = (ProductService)(Program.ServiceProvider.GetService(typeof(ProductService)));
            linkService = (LinkService)(Program.ServiceProvider.GetService(typeof(LinkService)));
        }
        private Form activeForm;
        private void OpenChildForm(Form child)
        {
            if (activeForm != null)
            {
                if (activeForm.Tag == child.Tag)
                {
                    return;
                }
                else
                {
                    activeForm.Close();
                }
            }
            activeForm = child;
            activeForm.Tag = child.Tag;
            child.TopLevel = false;
            child.Dock = DockStyle.Fill;
            child.BringToFront();
            panelContent.Controls.Add(child);
            child.Show();
        }
        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct formProduct = new frmProduct(productService);
            OpenChildForm(formProduct);
        }
        private void crawlLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLink formLink = new(linkService, productService);
            OpenChildForm(formLink);
        }
        private void aggregationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAnalyze formAnalyze = new frmAnalyze(linkService, productService);
            OpenChildForm(formAnalyze);
        }
    }
}
