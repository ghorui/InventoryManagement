using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryApp.BLL;
using InventoryApp.Models.Shopping;
using Microsoft.AspNet.Identity;

namespace InventoryApp.Controllers
{
    public class BillingController : Controller
    {
        // GET: Billing
        public JsonResult Index(BillingDTO billingDto)
        {
            billingDto.LastUpdatedUser = User.Identity.GetUserName();
            long res = 0;
            if (billingDto.TransactionId == 0)
            {
                res = SellFromShopBLL.SellProduct(billingDto);
            }

            return Json(res, JsonRequestBehavior.AllowGet);
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
            return Json("{\"Name\": \"Tarun\",\"Phone\":\"9836916672\"}");
        }
    }
}