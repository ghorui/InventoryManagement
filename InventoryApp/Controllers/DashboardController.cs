using InventoryApp.BLL;
using InventoryApp.Models.Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryApp.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult ShopInventory()
        {
            if (true) //role check
            {

            }
            var dashboardBLL = new DashboardBLL();
            List<Product> productsInShop = dashboardBLL.GetAllProductsInTheShop();
            return View(productsInShop);
        }

        public ActionResult StorageInventory()
        {
            var dashboardBLL = new DashboardBLL();
            List<Product> productsInShop = dashboardBLL.GetAllProductsInTheInventory();
            return View(productsInShop);
        }
    }
}