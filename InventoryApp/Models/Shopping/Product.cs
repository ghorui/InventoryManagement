using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryApp.Models.Shopping
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public float CostPerPc { get; set; }
        public float WeightPerPc { get; set; }
        public int LastPurchaseId { get; set; }
        public int LastSellId { get; set; }
        public string LastUpdatedUser { get; set; }
        public DateTime LastUpdatedTime { get; set; }
    }
}