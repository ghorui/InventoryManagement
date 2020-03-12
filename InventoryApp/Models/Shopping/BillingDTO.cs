using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using InventoryApp.DAL;

namespace InventoryApp.Models.Shopping
{
    public class BillingDTO
    {
        public long TransactionId { get; set; }
        public string CustomerMobile { get; set; }
        public string OverallDiscountRate { get; set; }
        public string OverallDiscountAmount { get; set; }
        public string CGSTRate { get; set; }
        public string CGSTAmount { get; set; }
        public string SGSTRate { get; set; }
        public string SGSTAmount { get; set; }
        public string IGSTRate { get; set; }
        public string IGSTAmount { get; set; }
        public string AdditionalCharges { get; set; }
        public string TotalAmount { get; set; }
        public string GrandTotal { get; set; }
        public List<Product> Products { get; set; }
        public string LastUpdatedUser { get; set; }
        public string LastUpdatedTime { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public Guid UniqueIdentifier { get; set; }

        public static BillingDTO Create(IDataRecord record)
        {
            BillingDTO result = null;
            if (record.FieldCount > 0)
            {
                result = new BillingDTO();

                for (int i = 0; i < record.FieldCount; i++)
                {
                    var propertyName = record.GetName(i);
                    switch (propertyName)
                    {
                        case "TransactionId":
                            int.TryParse(record[propertyName].ToString(), out var data);
                            result.TransactionId = data;
                            break;
                        case "OverallDiscountRate":
                            result.OverallDiscountRate = record[propertyName].ToString();
                            break;
                        case "OverallDiscountAmount":
                            result.OverallDiscountAmount = record[propertyName].ToString();
                            break;
                        case "CGSTRate":
                            result.CGSTRate = record[propertyName].ToString();
                            break;
                        case "CGSTAmount":
                            result.CGSTAmount = record[propertyName].ToString();
                            break;
                        case "SGSTRate":
                            result.SGSTRate = record[propertyName].ToString();
                            break;
                        case "SGSTAmount":
                            result.SGSTAmount = record[propertyName].ToString();
                            break;
                        case "IGSTRate":
                            result.IGSTRate = record[propertyName].ToString();
                            break;
                        case "IGSTAmount":
                            result.IGSTAmount = record[propertyName].ToString();
                            break;
                        case "AdditionalCharges":
                            result.AdditionalCharges = record[propertyName].ToString();
                            break;
                        case "TotalAmount":
                            result.TotalAmount = record[propertyName].ToString();
                            break;
                        case "GrandTotal":
                            result.GrandTotal = record[propertyName].ToString();
                            break;
                        case "LastUpdatedUser":
                            result.LastUpdatedUser = record[propertyName].ToString();
                            break;
                        case "LastUpdateTime":
                            result.LastUpdatedTime = record[propertyName].ToString();
                            break;
                        case "CustomerMobile":
                            result.CustomerMobile = record[propertyName].ToString();
                            break;
                        case "PaymentMethod":
                            result.PaymentMethod = record[propertyName].ToString();
                            break;
                        case "Status":
                            result.Status = record[propertyName].ToString();
                            break;
                        case "UniqueIdentifier":
                            result.UniqueIdentifier = Guid.Parse(record[propertyName].ToString());
                            break;
                    }
                }
            }

            return result;
        }
    }
}