using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryApp.DAL;
using InventoryApp.Models;
using InventoryApp.Models.BarCode;

namespace InventoryApp.BLL
{
    public static class BarCodeBLL
    {
        public static IEnumerable<SelectListItem> GetAllDepts()
        {
            var response = BarCodeDAL.GetAllDepts();
            response.Add(new Dept() { Id = 0, Name = "Others" });

            var selectList = new List<SelectListItem>();
            foreach (var element in response)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.Name
                });
            }
            return selectList;

        }

        public static IEnumerable<SelectListItem> GetAllQualitys()
        {
            var response = BarCodeDAL.GetAllQualitys();
            response.Add(new Quality() { Id = 0, Name = "Others" });

            var selectList = new List<SelectListItem>();
            foreach (var element in response)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.Name
                });
            }
            return selectList;
        }

        public static IEnumerable<SelectListItem> GetAllCrafts()
        {
            var response = BarCodeDAL.GetAllCrafts();
            response.Add(new Craft() { Id = 0, Name = "Others" });

            var selectList = new List<SelectListItem>();
            foreach (var element in response)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.Name
                });
            }
            return selectList;
        }

        public static IEnumerable<SelectListItem> GetAllSizes()
        {
            var response = BarCodeDAL.GetAllSizes();
            response.Add(new Size() { Id = 0, Name = "Others" });

            var selectList = new List<SelectListItem>();
            foreach (var element in response)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.Name
                });
            }
            return selectList;
        }

        public static IEnumerable<SelectListItem> GetAllVendors()
        {
            var response = BarCodeDAL.GetAllVendors();
            response.Add(new Vendor() { Id = 0, Name = "Others" });

            var selectList = new List<SelectListItem>();
            foreach (var element in response)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.Name
                });
            }
            return selectList;
        }

        public static void ValidateBarCodeProperties(BarCodeDTO dto)
        {
            var depts = GetAllDepts();
            if (depts.All(d => d.Text != dto.Dept))
            {
                BarCodeDAL.SaveBarCodeProperties("Dept", dto.Dept);
            }

            var crafts = GetAllCrafts();
            if (crafts.All(d => d.Text != dto.Craft))
            {
                BarCodeDAL.SaveBarCodeProperties("Craft", dto.Craft);
            }

            var qualitys = GetAllQualitys();
            if (qualitys.All(d => d.Text != dto.Quality))
            {
                BarCodeDAL.SaveBarCodeProperties("Quality", dto.Quality);
            }

            var sizes = GetAllSizes();
            if (sizes.All(d => d.Text != dto.Size))
            {
                BarCodeDAL.SaveBarCodeProperties("Size", dto.Size);
            }

            var vendors = GetAllVendors();
            if (vendors.All(d => d.Text != dto.Vendor))
            {
                BarCodeDAL.SaveBarCodeProperties("Vendor", dto.Vendor);
            }
        }

        public static void SaveBarCode(BarCodeDTO dto, string barCodeValue, string relativePath)
        {
            BarCodeDAL.SaveBarCode(dto, barCodeValue, relativePath);
        }

        public static string ValidateOrCreateBarCode(string barCodeValue, float mrp)
        {
            return BarCodeDAL.ValidateOrCreateBarCode(barCodeValue, mrp);
        }

        public static string GetBarCodeFilePathByBarCode(string currentBarCode)
        {
            return BarCodeDAL.GetBarCodeFilePathByBarCode(currentBarCode);
        }

        public static void SaveProduct(ProductInfo product)
        {
            BarCodeDAL.SaveProduct(product);
        }
    }
}