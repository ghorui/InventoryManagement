using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryApp.BLL;
using InventoryApp.Models;
using InventoryApp.Models.BarCode;
using InventoryApp.Models.Shopping;
using Microsoft.AspNet.Identity;

namespace InventoryApp.Controllers
{
    public class BillingController : Controller
    {
        // GET: Billing
        public ActionResult Index(int transactionId)
        {
            CustomerBillingDetails b;
            if (transactionId>0)
            {
                var billingDto = SellFromShopBLL.GetBillingDetailsByTransationId(transactionId);
                var customer = SellFromShopBLL.GetCustomerDetailsByTransactionId(transactionId.ToString());
                return View(new CustomerBillingDetails() {BillingDto = billingDto, Customer = customer});
            }

            return null;
        }

        public JsonResult Sell(BillingDTO billingDto)
        {
            billingDto.LastUpdatedUser = User.Identity.GetUserName();
            long res = 0;
            if (billingDto.TransactionId == 0)
            {
                res = SellFromShopBLL.SellProduct(billingDto);
            }

            return Json(Url.Action("Index", "Billing", new { transactionId = res }));
            //return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Print(long transationId)
        {
            throw new NotImplementedException();
        }

        public JsonResult MarkPaymentConfirmation(long transactionId)
        {
            bool response = SellFromShopBLL.UpdatePaymentConfirmation(transactionId);
            return Json(response);
        }

        public JsonResult GetCustomerDetailsByTransactionId(string transactionId)
        {
            Customer customer = SellFromShopBLL.GetCustomerDetailsByTransactionId(transactionId);
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllBarCodeInfo()
        {
            var barCodeInfo = new BarCodeInfo();
            return Json(barCodeInfo, JsonRequestBehavior.AllowGet);
        }
    }
}