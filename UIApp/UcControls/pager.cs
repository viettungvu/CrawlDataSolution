using Models.CustomEventArgs;
using Models.Pagings;
using Models.Products;
using System;
using System.Windows.Forms;

namespace UIApp.UcControls
{
    public partial class pager : UserControl
    {
        private  PagedResultBase source;
        public PagedResultBase Source
        {
            get { return source; }
            set
            {
                source = value;
                Initial();
            }
        }
        public pager()
        {
            InitializeComponent();
            btnFirst.Visible = false;
            btnLast.Visible = false;
            btnPrev.Visible = false;
            btnNext.Visible = false;
        }
        private void Initial()
        {
            if (source != null)
            {
                lblInfo.Text = $"Showing {source.PageIndex}/{source.PageCount} pages";
                if (source.PageIndex <= 1 && source.PageCount>1)
                {
                    btnFirst.Visible = false;
                    btnPrev.Visible = false;
                    btnNext.Visible = true;
                    btnLast.Visible = true;
                }
                else if (source.PageIndex > 1 && source.PageIndex < source.PageCount)
                {
                    btnFirst.Visible = true;
                    btnPrev.Visible = true;
                    btnNext.Visible = true;
                    btnLast.Visible = true;
                }
                else
                {
                    source.PageIndex = source.PageCount;
                    btnFirst.Visible = true;
                    btnPrev.Visible = true;
                    btnNext.Visible = false;
                    btnLast.Visible = false;
                }
            }
        }
 
        private event EventHandler<PagerSendDataEventArg> sendRequest;
        public event EventHandler<PagerSendDataEventArg> SendRequest
        {
            add { sendRequest += value; }
            remove { sendRequest -= value; }
        }
        private void btnFirst_Click(object sender, EventArgs e)
        {
            var request = new PagingRequestBase()
            {
                PageIndex = 1,
                PageSize = 10,
            };
            sendRequest?.Invoke(this, new PagerSendDataEventArg(request));
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            var request = new PagingRequestBase()
            {
                PageIndex = source.PageIndex-1,
                PageSize = 10,
            };
            sendRequest?.Invoke(request, new PagerSendDataEventArg(request));
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            var request = new PagingRequestBase()
            {
                PageIndex = source.PageIndex + 1,
                PageSize = 10,
            };
            sendRequest?.Invoke(request, new PagerSendDataEventArg(request));
        }
        private void btnLast_Click(object sender, EventArgs e)
        { 
            var request = new PagingRequestBase()
            {
                PageIndex = source.PageCount,
                PageSize = 10,
            };
            sendRequest?.Invoke(request, new PagerSendDataEventArg(request));
        }
    }
}
