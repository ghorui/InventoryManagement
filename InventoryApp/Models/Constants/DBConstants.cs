using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryApp.Models.Constants
{
    public static class DBConstants
    {
        #region Stored Proc

        public static string usp_GetAllProductFromShop = "usp_GetAllProductFromShop";
        public static string usp_GetAllProductFromInventory = "usp_GetAllProductFromInventory";
        public static string usp_GetCustomerbyMobileNumber = "usp_GetCustomerbyMobileNumber";
        public static string usp_SaveCustomerbyMobileNumber = "usp_SaveCustomerbyMobileNumber";
        public static string usp_saveBillingDetails = "usp_saveBillingDetails";
        public static string usp_getBillingDetailsbyTrxId = "usp_getBillingDetailsbyTrxId";
        public static string usp_saveProductsSoldAtShop = "usp_saveProductsSoldAtShop";
        public static string usp_getProductsDetailsbyBillingTrxId = "usp_getProductsDetailsbyBillingTrxId";
        public static string usp_getProductsDetailsByBarCode = "usp_getProductsDetailsByBarCode";

        #endregion Stored Proc
    }
}