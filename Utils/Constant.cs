using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class Constant
    {
        #region Lấy thông tin cơ bản
        /*
         * listproduct: dienmayxanh
         * pl18-item-ul: mediamart
         * product-list: hc
         * mk-product: nguyenkim
         */
        public const string UL_PARTTERN = @"<\s*(div|ul)(\s+class=""(listproduct|pl18-item-ul|products-category|nk-product-tivi)(?:\s+(?:.*?))*"")(?:\s+[^>]*\s*)*>[.\n\t\s]*(?<data>.*?)[.\n\t\s]*<\/\1>";
        /*
         * Thẻ li này là thẻ bao quát, chứa thông tin của 1 item
         * Được lấy dựa vào html trong data của UL_PARTTERN
         * item:dienmay xanh
         * pl-18-item-li: mediamart
         * product-layout(product-item-container) hc
         * nk-fgp-items:nguyenkim
         */
        public const string LI_PARTTERN = @"<\s*(div|li)(\s+class=""\s*(item|pl18-item-li|product-item-container|nk-fgp-items)(?:\s+(?:.*?))?"")(\s+[^>]*\s*)*>[.\n\t\s]*(?<data>.*?)[.\n\t\s]*<\/\1>";
        /*
         * Lấy thẻ a là link đến sản phẩm dựa trên thuộc tính href
         * đồng thời lấy ra các attribute khác trong thẻ này
         */
        public const string A_PARTTERN = @"<\s*(a)(\s+id="".*?"")?(?:\s+href='(?<link>(/tivi/|p--tivi|.*?).*?)')(?<attribute>\s+[^>]*\s*)?>[.\n\t\s]*(?<data>.*?)[.\n\t\s]*<\/\1>";
       
        public const string SPAN_PARTTERN = @"<\s*(span)(?<id>id=""[|]"")?(?<class>class=""[|](?:\s+(?:.*?))?"")?>[.\n\t\s]*(?<data>.*?)[.\n\t\s]*<\/\1>";
        /*
         * Sau khi lấy được thẻ a thì trong attribute
         * của thẻ a có chứa các thông tin về
         * hãng, tên, giá...nên dựa vào đây để lấy luôn
         */
        public const string P_BRAND_PARTTERN = @"data-brand=""(?<brand>.*?)""";
        
        public const string P_NAME_PARTTERN = @"data-name=""(?<name>.*?)""";

        public const string P_PRICE_PARTTERN = @"data-price=""(?<price>.*?)""";
        /*
         * Tên sản phẩm được đặt trong thẻ heading
         */
        public const string HEADING_PARTTERN = @"<(\s*h[1-5]\s*)(.*?\s*)?>[.\n\s\t]?(?<data>.*?)[.\n\s\t]?<\/\1>";
        /*
         * Lấy giá sản phẩm từ thẻ, không phải từ trong attribute của thẻ a
         * Trong data vẫn có thể còn html tag, dùng tiếp parttern price dot để lấy ra
         */
        public const string PRICE_PARTTERN = @"<\s*([a-z]+)(\s+class=""\s*(?:price-new|price|pl18-item-pbuy|final-price)"")(\s+[^>]*\s*)?>(?<data>.*?)<\/\1>";
        /*
         * Ex: 560.000.000
         * 560,000,000
         */
        public const string DECIMAL_GSEPARATOR_PARTTERN = @"[1-9]\d{0,2}([\.|\,]\d{3})+";
        /* 
         * Ex: 56000,0
         * 56000.0
         */
        public const string DECIMAL_PARTTERN = @"[1-9]\d*[\.\,]\d+";
        public const string DIGIT_PARTTERN = @"[1-9]\d*";
        /*
         * Lấy thông tin mô tả chung chung 
         */
        public const string P_DESCRIPT_PARTTERN = @"<(\s*[a-z]+)(\s+[^>]*\s*)*(\s+class=""\s*(item-compare|abc)(\s+(.*?))?""\s*)(\s+[^>]*\s*)*>[.\n\t\s]*(?<data>.*?)[.\n\t\s]*<\/\1>";
        #endregion

        #region Lấy thông tin chi tiết
        /*
         * Lấy danh sách các thông số kĩ thuật của 1 sản phẩm
         */
        public const string P_PARAMS_PARTTERN = @"<\s*([a-z]+)(?<id>\s+id=""(?:|)(?:\s+[^""]*)?"")?(?<class>\s+class=""\s*(?:parameter__list|specs)(?:\s+[^""]*)*"")(?::\s+[^>]*)?>[.\n\t\s]*(?<data>.*?)[.\n\t\s]*<\/\1>";
        public const string PARAM_PARTTERN = @"<\s*(li)(?<id>\s+id=""(?:|)(?:\s+[^""]*)?"")?(?<class>\s+class=""\s*(?:parameter__list|manu)(?:\s+[^""]*)?"")?((\s+data-index=""\d*"")(?:\s+[^>]*))?>[.\n\t\s]*(?<data>.*?)[.\n\t\s]*<\/\1>";
        /*
         * Lấy giá sản phẩm trong trang chi tiết sản phẩm
         */
        public const string PRICE_DETAIL_PATTERN = @"<(\s*[a-z]+)(?<class>\s+class=""\s*(?:box-price-present|prices|price)(?:\s+[^""]*)?"")>[.\n\t\s]*(?<data>.*?)[.\n\t\s]*<\/\1>";
        /*
         * Lấy tiêu đề của thông số
         * VD: "Hãng", "Kích thước", "Công nghệ"
         */
        public const string TITLE_PARTTERN = @"<(\s*[a-z]+)(\s+[^>]*\s*)?(\s+class=""specname|lileft"")(\s+[^>]*\s*)?>[.\n\t\s]*(?<data>.*?)[.\n\t\s]*<\/\1>";
        public const string P_DESCRIPT_LISTDETAIL_PARTTERN = @"<\s*([a-z]+)(?<id>\s+id=""(?:|)(?:\s+[^""]*)?"")?(?<class>\s+class=""\s*(?:liright|specname)(?:\s+[^""]*)*"")(?:(?:\s+data-index=""\d*"")(?:\s+[^>]*))?>[.\n\t\s]*(?<data>.*?)[.\n\t\s]*<\/\1>";
        /*
         * Lấy nội dung thông số
         * VD: "Sony", "20x30", "Oled"
         */
        public const string P_DESCRIPT_DETAIL_PARTTERN = @"<\s*([a-z]+)(?<id>\s+id=""(?:|)(?:\s+[^""]*)?"")?(?<class>\s+class=""\s*(?:comma|specval)(?:\s+[^""]*)*"")(?:\s+[^>]*)?>[.\n\t\s]*(?<data>.*?)[.\n\t\s]*<\/\1>";
        #endregion

        public const string DOMAIN_PARTTERN = @"(?:(?<protocol>https|http)(?:\://))?(?:www\.)?(?<domain>(?:[\w\d]{1,61})(\.(?<type>[\w]{2,})){1,})";
        //Parttern này gộp cả protocol vào domain (https/http)
        public const string DOMAIN1_PARTTERN=@"(?<domain>(?:(?<protocol>https|http)(?:\://))?(?:www\.)?(?:(?:[\w\d]{1,61})(?<type>\.(?:[\w]{2,})){1,}))";
        //public const string domain_pattern = @"^[a-zA-Z0-9][a-zA-Z0-9-]{1,61}[a-zA-Z0-9]\.[a-zA-Z]{2,}$";
    }
}
