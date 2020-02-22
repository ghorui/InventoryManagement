using InventoryApp.BLL;
using InventoryApp.Models;
using InventoryApp.Models.Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            if (!string.IsNullOrEmpty(model.Name) && model.Id == 0)
            {
                var res = SellFromShopBLL.SaveCustomer(model);
            }
            if (!string.IsNullOrEmpty(model.MobileNumber))
            {
                customer = SellFromShopBLL.GetCustomer(model.MobileNumber);
            }
            return View(customer == null ? new Customer() { MobileNumber = model.MobileNumber } : customer);
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
                //return Redirect("/Billing/Index/" + res);
                return RedirectToAction("Index", "Billing", new { transactionId = res });
                //RedirectToAction(actionName: "Index", controllerName: "Billing");
            }

            return null;
        }

        [HttpGet]
        public JsonResult GetProductByBarCode(string barCode)
        {
            return Json(SellFromShopBLL.GetProductByBarCode(barCode));
        }
    }
}