using InventoryApp.BLL;
using InventoryApp.Models.Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryApp.Util;
using Newtonsoft.Json;

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

        public ActionResult EditInventory()
        {
            return View();
        }

        [HttpGet]
        public JsonResult SearchByBarcode(string barcode)
        {
            var dashboardBLL = new DashboardBLL();
            var response = dashboardBLL.GetProductByBarcode(barcode);
            Logger.Log(User.Identity.Name, "Dashboard/SearchByBarcode", response?.BillingTransactionId.ToString(), barcode,
                "Response: " + JsonConvert.SerializeObject(response));
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveProductByBarcode(Product product)
        {
            var dashboardBLL = new DashboardBLL();
            var response = dashboardBLL.SaveProductByBarcode(product);
            Logger.Log(User.Identity.Name, "Dashboard/SaveProductByBarcode", product?.BillingTransactionId.ToString(),
                product?.BarCode,
                "Request: " + JsonConvert.SerializeObject(product) + ", Response: " + response);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}