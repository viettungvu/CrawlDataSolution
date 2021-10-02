using Models.Pagings;
using System;

namespace Models.CustomEventArgs
{
    public class PagerSendDataEventArg:EventArgs
    {
        public PagingRequestBase PagingRequest { get; set; }
        public PagerSendDataEventArg()
        {

        }
        public PagerSendDataEventArg(PagingRequestBase pagingRequest)
        {
            PagingRequest = pagingRequest;
        }
    }
}
