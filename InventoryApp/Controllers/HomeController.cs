using InventoryApp.BLL;
using InventoryApp.Models.BarCode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.Mvc;

namespace InventoryApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Team()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Service()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Portfolio()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PrintBarCode()
        {
            ViewBag.Message = "Print Bar Code";
            BarCodeInfo barCodeInfo = new BarCodeInfo();
            return View(barCodeInfo);
        }

        public JsonResult GetBarCode(BarCodeDTO dto)
        {
            ValidateBarCodeProperties(dto);

            var barCodeValue = dto.BarCodeValue;
            var dir = Server.MapPath("/Images/BarCode");
            string fileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + ".jpg";
            string filePath = dir + "/" + fileName;
            string relativePath = "/Images/BarCode/" + fileName;
            
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            b.IncludeLabel = true;
            Image img = b.Encode(BarcodeLib.TYPE.CODE128, barCodeValue, Color.Black, Color.White, 290, 120);
            img.Save(filePath);
            
            List<string> result = new List<string>() { barCodeValue, relativePath };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private void ValidateBarCodeProperties(BarCodeDTO dto)
        {
            BarCodeBLL.ValidateBarCodeProperties(dto);
        }
    }
}