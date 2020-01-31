using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace InventoryApp.Models.Shopping
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal CostPerPc { get; set; }
        public string WeightPerPc { get; set; }
        public string LastPurchaseId { get; set; }
        public string LastSellId { get; set; }
        public string LastUpdatedUser { get; set; }
        public DateTime LastUpdatedTime { get; set; }

        public static Product Create(IDataRecord record)
        {
            Product product = new Product();

            product.Id = Convert.ToInt32(record["Id"].ToString());
            product.Name = record["Name"].ToString();
            product.Count = Convert.ToInt32(record["Count"].ToString());
            product.CostPerPc = Convert.ToDecimal(record["CostPerPc"].ToString());
            product.WeightPerPc = record["WeightPerPc"].ToString();
            product.LastPurchaseId = record["LastPurchaseId"].ToString();
            product.LastSellId = record["LastSellId"].ToString();
            product.LastUpdatedUser = record["LastUpdatedUser"].ToString();
            product.LastUpdatedTime = DateTime.Now;

            return product;

        }
    }
}