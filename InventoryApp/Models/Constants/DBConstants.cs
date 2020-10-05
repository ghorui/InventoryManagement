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
        public static string usp_saveBarCode = "usp_saveBarCode";
        public static string usp_getBarCodeByPattern = "usp_getBarCodeByPattern";
        public static string usp_validateBarCode = "usp_validateBarCode";
        public static string usp_getFilePathByBarCode = "usp_getFilePathByBarCode";
        public static string usp_saveProductByInfo = "usp_saveProductByInfo";
        public static string usp_GetCustomerbytransactionId = "usp_GetCustomerbytransactionId";
        public static string usp_getPaymentMethods = "usp_getPaymentMethods";
        public static string usp_updateProductInfo = "usp_updateProductInfo";
        public static string usp_getProductByBarCode = "usp_getProductByBarCode";
        public static string usp_updateProductsDetailsByBarCode = "usp_updateProductsDetailsByBarCode";
        public static string usp_AddLog = "usp_AddLog";

        #endregion Stored Proc
    }
}