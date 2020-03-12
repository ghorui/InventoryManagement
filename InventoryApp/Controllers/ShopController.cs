using InventoryApp.BLL;
using InventoryApp.Models;
using InventoryApp.Models.Shopping;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace InventoryApp.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop

        public ActionResult Sell(Customer model)
        {
            ViewData["message"] = "Mobile number not found in the database. Please collect details.";
            Customer customer = null;
            if (!string.IsNullOrEmpty(model.Name))
            {
                var res = SellFromShopBLL.SaveCustomer(model);
            }
            if (!string.IsNullOrEmpty(model.MobileNumber))
            {
                customer = SellFromShopBLL.GetCustomer(model.MobileNumber);
            }
            return View(customer ?? new Customer() { MobileNumber = model.MobileNumber });
        }

        public ActionResult SaveCustomer(Customer model)
        {
            if (model != null && !string.IsNullOrEmpty(model.MobileNumber))
            {
                var res = SellFromShopBLL.SaveCustomer(model);
            }
            return Sell(model);
        }

        public RedirectToRouteResult SellProduct(BillingDTO billingDto)
        {
            billingDto.LastUpdatedUser = User.Identity.GetUserName();
            long res = 0;
            if (billingDto.TransactionId == 0)
            {
                res = SellFromShopBLL.SellProduct(billingDto);
            }
            if (res > 0)
            {
                return RedirectToAction("Index", "Billing", new { transactionId = res });
            }

            return null;
        }

        [HttpGet]
        public JsonResult GetProductByBarCode(string barCode)
        {
            var response = Json(SellFromShopBLL.GetProductByBarCode(barCode), JsonRequestBehavior.AllowGet);
            return response;
        }

        [HttpGet]
        public JsonResult GetPaymentMethods()
        {
            var response = Json(SellFromShopBLL.GetPaymentMethods(), JsonRequestBehavior.AllowGet);
            return response;
        }
    }
}