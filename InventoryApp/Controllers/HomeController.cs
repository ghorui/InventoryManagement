using InventoryApp.BLL;
using InventoryApp.Models.BarCode;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Security;
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

                PointF companyLocation = new PointF(0f, 25f);
                PointF firstLocation = new PointF(18f, 0f);
                PointF secondLocation = new PointF(320f, 0f);

                StringFormat drawFormat = new StringFormat { FormatFlags = StringFormatFlags.DirectionVertical };

                string firstText = dto.Craft + " - INR:" + dto.Mrp.ToString(CultureInfo.InvariantCulture);
                string companyString = "KAMALASAREE.COM";

                Bitmap bitmap = (Bitmap)Image.FromFile(tempFilePath);//load the image file

                Bitmap bigImage = new Bitmap(350, 200);

                using (Graphics graphics = Graphics.FromImage(bigImage))
                {
                    using (Font companyFont = new Font("Arial Black",10,FontStyle.Bold))
                    {
                        graphics.DrawString(companyString, companyFont, Brushes.Black, companyLocation, drawFormat);

                    }
                    using (Font arialFont = new Font("Arial", 14))
                    {
                        graphics.DrawImage(bitmap, new Point() {X = 35, Y = 0});
                        graphics.DrawLine(Pens.Black, new PointF(19, 0), new PointF(19, 200));
                        graphics.DrawString(firstText, arialFont,
                            Brushes.Black, firstLocation, drawFormat);
                        graphics.DrawString("Vendor: " + dto.Vendor.ToString(CultureInfo.InvariantCulture), arialFont,
                            Brushes.Black, secondLocation, drawFormat);
                    }
                }
                bigImage.Save(filePath);//save the image file
                bigImage.Dispose();

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

        public JsonResult SaveProduct(ProductInfo product)
        {
            BarCodeBLL.SaveProduct(product);

            return Json(product, JsonRequestBehavior.AllowGet);
        }
    }
}