using System;
using System.Collections.Generic;
using System.Text;

namespace EnchantedPOS
{
    public class ProductRecord
    {
        public string Barcode { get; set; }
        public string EngName { get; set; }
        public string KorName { get; set; }
        public decimal RegPrice { get; set; }
        public decimal WholesalePrice { get; set; }
        public decimal VipPrice { get; set; }
        public decimal RoyalPrice { get; set; }
        public bool IsNonVat { get; set; }
    }
}
