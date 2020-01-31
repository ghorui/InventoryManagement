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

        #endregion Stored Proc
    }
}