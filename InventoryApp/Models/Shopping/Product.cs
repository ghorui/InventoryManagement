using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

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
            Product result = null;
            if (record.FieldCount > 0)
            {
                result = new Product();

                for (int i = 0; i < record.FieldCount; i++)
                {
                    switch (record.GetName(i))
                    {
                        case "TaxableValue":
                            float.TryParse(record["TaxableValue"].ToString(), out var taxableValue);
                            result.TaxableValue = taxableValue;
                            break;
                        case "ItemName":
                            result.ItemName = record["ItemName"].ToString();
                            break;
                        case "BarCode":
                            result.BarCode = record["BarCode"].ToString();
                            break;
                        case "Quantity":
                            int.TryParse(record["Quantity"].ToString(), out var quantity);
                            result.Quantity = quantity;
                            break;
                        case "BillingTransactionId":
                            int.TryParse(record["BillingTransactionId"].ToString(), out var billingTransactionId);
                            result.BillingTransactionId = billingTransactionId;
                            break;
                        case "UnitPrice":
                            float.TryParse(record["UnitPrice"].ToString(), out var unitPrice);
                            result.UnitPrice = unitPrice;
                            break;
                        case "Value":
                            float.TryParse(record["Value"].ToString(), out var value);
                            result.Value = value;
                            break;
                        case "ItemDiscountPercentage":
                            float.TryParse(record["ItemDiscountPercentage"].ToString(), out var itemDiscountPercentage);
                            result.ItemDiscountPercentage = itemDiscountPercentage;
                            break;
                        case "ItemDiscountAmount":
                            float.TryParse(record["ItemDiscountAmount"].ToString(), out var itemDiscountAmount);
                            result.ItemDiscountAmount = itemDiscountAmount;
                            break;
                    }
                }
            }

            return result;

        }
    }
}