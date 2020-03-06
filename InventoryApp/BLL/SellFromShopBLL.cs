using InventoryApp.DAL;
using InventoryApp.Models;
using InventoryApp.Models.Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace InventoryApp.BLL
{
    public static class SellFromShopBLL
    {
        public static Customer GetCustomer(string mobileNumber)
        {
            return SellFromShopDAL.GetCustomer(mobileNumber);
        }

        public static int SaveCustomer(Customer model)
        {
            return SellFromShopDAL.SaveCustomer(model);
        }

        public static long SellProduct(BillingDTO billingDto)
        {
            //var sellDto = SellFromShopDAL.RegisterSell();
            return SellFromShopDAL.SellProduct(billingDto);
        }

        public static bool UpdatePaymentConfirmation(long transactionId)
        {
            return SellFromShopDAL.UpdatePaymentConfirmation(transactionId);
        }

        public static BillingDTO GetBillingDetailsByTransationId(long transactionId)
        {
            return SellFromShopDAL.GetBillingDetailsByTransationId(transactionId);
        }

        public static List<Product> GetProductByBarCode(string barCode)
        {
            return SellFromShopDAL.GetProductByBarCode(barCode);
        }

        public static Customer GetCustomerDetailsByTransactionId(string transactionId)
        {
            return SellFromShopDAL.GetCustomerDetailsByTransactionId(transactionId);
        }
    }
}