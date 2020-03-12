using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryApp.Models.Shopping
{
    public class SellingProduct
    {
        public string BarCode { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public float Value { get; set; }
        public float DiscountPercentage { get; set; }
        public float DiscountAmount { get; set; }
        public float TaxableValue { get; set; }
    }

    public class UniqueSellingProduct
    {
        public Guid UniqueIdentifier { get; set; }
        public IEnumerable<SellingProduct> SellingProducts { get; set; }
    }
}