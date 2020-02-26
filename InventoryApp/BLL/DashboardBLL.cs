using InventoryApp.DAL;
using InventoryApp.Models.Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryApp.BLL
{
    public class DashboardBLL
    {
        public List<Product> GetAllProductsInTheShop()
        {
            var dal = new DashboardDAL();
            return dal.GetAllProductsInTheShop();
        }

        public List<Product> GetAllProductsInTheInventory()
        {
            var dal = new DashboardDAL();
            return dal.GetAllProductsInTheInventory();
        }
    }
}