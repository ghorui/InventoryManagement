using InventoryApp.BLL;
using InventoryApp.Models.BarCode;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Web.Mvc;
using InventoryApp.Models;

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
            try
            {
                dto.Count = 0;
                ValidateBarCodeProperties(dto);
                while (!dto.IsValid)
                {
                    dto.Count++;
                    var currentBarCode = dto.BarCodeValue;
                    var status = ValidateOrCreateBarCode(currentBarCode, dto.Mrp);
                    if (status == "EXACT")
                    {
                        string imagePath = BarCodeBLL.GetBarCodeFilePathByBarCode(currentBarCode);
                        List<string> response = new List<string> { currentBarCode, imagePath };
                        return Json(response, JsonRequestBehavior.AllowGet);
                    }
                    else if(status == "PARTIAL")
                    {
                        dto.IsValid = false;
                    }
                    else
                    {
                        dto.IsValid = true;
                    }
                }
                
                var barCodeValue = dto.BarCodeValue;
                var dir = Server.MapPath("/Images/BarCode");
                string tempFilePath = dir + "/temp.jpg";
                string fileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + ".jpg";
                string filePath = dir + "/" + fileName;
                string relativePath = "/Images/BarCode/" + fileName;
                BarcodeLib.Barcode b = new BarcodeLib.Barcode { IncludeLabel = true };
                Image img = b.Encode(BarcodeLib.TYPE.CODE128, barCodeValue, Color.Black, Color.White, 290, 200);
                img.Save(tempFilePath);

                PointF firstLocation = new PointF(0f, 0f);
                PointF secondLocation = new PointF(270f, 0f);
                StringFormat drawFormat = new StringFormat { FormatFlags = StringFormatFlags.DirectionVertical };

                string firstText = dto.Craft + " - INR:" + dto.Mrp.ToString(CultureInfo.InvariantCulture);

                Bitmap bitmap = (Bitmap)Image.FromFile(tempFilePath);//load the image file

                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Font arialFont = new Font("Arial", 14))
                    {
                        graphics.DrawString(firstText, arialFont,
                            Brushes.Black, firstLocation, drawFormat);
                        graphics.DrawString("Vendor: " + dto.Vendor.ToString(CultureInfo.InvariantCulture), arialFont,
                            Brushes.Black, secondLocation, drawFormat);
                    }

                    //using (Font arialFont = new Font("Arial", 8))
                    //{
                    //    firstLocation = new PointF(0f, 100f);
                    //    graphics.DrawString(dto.Craft.ToString(CultureInfo.InvariantCulture), arialFont,
                    //        Brushes.Crimson, firstLocation, drawFormat);
                    //}
                }
                bitmap.Save(filePath);//save the image file
                bitmap.Dispose();

                List<string> result = new List<string> {barCodeValue, relativePath};
                Console.WriteLine($"Home/GetBarCode. result: {result}");
                BarCodeBLL.SaveBarCode(dto, barCodeValue, relativePath);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private string ValidateOrCreateBarCode(string barCodeValue, float mrp)
        {
            return BarCodeBLL.ValidateOrCreateBarCode(barCodeValue, mrp);
        }

        private void ValidateBarCodeProperties(BarCodeDTO dto)
        {
            BarCodeBLL.ValidateBarCodeProperties(dto);
        }

        //public JsonResult BarCodeToPrinter(string filePath)
        //{
        //    var dir = Server.MapPath("/Images/BarCode");
        //    string path = dir + filePath.Substring(filePath.IndexOf("BarCode", StringComparison.Ordinal) + 7);
        //    Process p = new Process
        //    {
        //        StartInfo = new ProcessStartInfo()
        //        {
        //            CreateNoWindow = true, Verb = "print", FileName = path //put the correct path here
        //        }
        //    };
        //    p.Start();
        //    return Json(true);
        //}

        public JsonResult SaveProduct(ProductInfo product)
        {
            BarCodeBLL.SaveProduct(product);

            return Json(product, JsonRequestBehavior.AllowGet);
        }
    }
}