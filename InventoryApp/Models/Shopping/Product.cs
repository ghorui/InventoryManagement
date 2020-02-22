using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace InventoryApp.Models.Shopping
{
    public class Product
    {
        public string BarCode { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public float Value { get; set; }
        public float ItemDiscountPercentage { get; set; }
        public float ItemDiscountAmount { get; set; }
        public float TaxableValue { get; set; }
        public int BillingTransactionId { get; set; }  

        public static Product Create(IDataRecord record)
        {
            float.TryParse(record["UnitPrice"].ToString(), out var unitPrice);
            float.TryParse(record["Value"].ToString(), out var value);
            float.TryParse(record["ItemDiscountPercentage"].ToString(), out var itemDiscountPercentage);
            float.TryParse(record["ItemDiscountAmount"].ToString(), out var itemDiscountAmount);
            float.TryParse(record["TaxableValue"].ToString(), out var taxableValue);
            Product product = new Product
            {
                BarCode = record["BarCode"].ToString(),
                ItemName = record["ItemName"].ToString(),
                Quantity = Convert.ToInt32(record["Quantity"].ToString()),
                UnitPrice = unitPrice,
                Value = value,
                ItemDiscountPercentage = itemDiscountPercentage,
                ItemDiscountAmount = itemDiscountAmount,
                TaxableValue = taxableValue,
                BillingTransactionId = Convert.ToInt32( record["BillingTransactionId"].ToString())
            };
            

            return product;

        }
    }
}