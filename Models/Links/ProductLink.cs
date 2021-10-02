using System;
using static Models.AllEnums;

namespace Models.Links
{
    public class ProductLink
    {
        public string Id { get; set; }
        public string Path { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductModel { get; set; }
        public string ProductBranch { get; set; }
        public long ProductPrice { get; set; }
        public LinkStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime LastCrawl { get; set; }
    }
}
