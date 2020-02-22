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

        public static BillingDTO Create(IDataRecord record)
        {
            var res =  new BillingDTO()
            {
                TransactionId = Convert.ToInt64(record["TransactionId"].ToString()),
                OverallDiscountRate = record["OverallDiscountRate"].ToString(),
                OverallDiscountAmount = record["OverallDiscountAmount"].ToString(),
                CGSTRate = record["CGSTRate"].ToString(),
                CGSTAmount = record["CGSTAmount"].ToString(),
                SGSTRate = record["SGSTRate"].ToString(),
                SGSTAmount = record["SGSTAmount"].ToString(),
                IGSTRate = record["IGSTRate"].ToString(),
                IGSTAmount = record["IGSTAmount"].ToString(),
                AdditionalCharges = record["AdditionalCharges"].ToString(),
                TotalAmount = record["TotalAmount"].ToString(),
                GrandTotal = record["GrandTotal"].ToString(),
                LastUpdatedUser = record["LastUpdatedUser"].ToString(),
                LastUpdatedTime = record["LastUpdateTime"].ToString()
            };
            

            return res;
        }
    }
}