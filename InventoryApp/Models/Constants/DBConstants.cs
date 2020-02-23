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
        public static string usp_getAllDept = "usp_getAllDept";
        public static string usp_getAllQuality = "usp_getAllQuality";
        public static string usp_getAllCraft = "usp_getAllCraft";
        public static string usp_getAllSize = "usp_getAllSize";
        public static string usp_getAllVendor = "usp_getAllVendor";
        public static string usp_saveBarCodeProperties= "usp_saveBarCodeProperties";

        #endregion Stored Proc
    }
}