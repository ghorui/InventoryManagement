using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryApp.BLL;

namespace InventoryApp.Models.BarCode
{
    public class BarCodeDTO
    {
        private string barCodeFormat = "{0,2}{1,2}{2,2}{3,2}{4,4}{5,2}{6,2}";

        public string Dept { get; set; }
        public string Quality { get; set; }
        public string Craft { get; set; }
        public string Size { get; set; }
        public string Vendor { get; set; }
        //public string ManufactureDate { get; set; }
        public float ActualCost { get; set; }
        public float SellingPrice { get; set; }
        public float Mrp { get; set; }
        public int Count { get; set; }
        public bool IsValid { get; set; }

        //one placeholder for future use
        public string BarCodeValue
        {
            get
            {
                BarCodeInfo barCodeInfo = new BarCodeInfo();
                var name = string.Format(barCodeFormat,
                    barCodeInfo.Depts.Where(b => b.Text == Dept).Select(s => s.Value).FirstOrDefault(),
                    barCodeInfo.Qualitys.Where(b => b.Text == Quality).Select(s => s.Value).FirstOrDefault(),
                    barCodeInfo.Crafts.Where(b => b.Text == Craft).Select(s => s.Value).FirstOrDefault(),
                    barCodeInfo.Sizes.Where(b => b.Text == Size).Select(s => s.Value).FirstOrDefault(),
                    barCodeInfo.Vendors.Where(b => b.Text == Vendor).Select(s => s.Value).FirstOrDefault(),
                    Count.ToString(), "00");
                return name.Replace(' ','0');
            }   // get method
        }

    }

    public class BarCodeInfo
    {
        public IEnumerable<SelectListItem> Depts => BarCodeBLL.GetAllDepts();

        public IEnumerable<SelectListItem> Qualitys => BarCodeBLL.GetAllQualitys();

        public IEnumerable<SelectListItem> Crafts => BarCodeBLL.GetAllCrafts();

        public IEnumerable<SelectListItem> Sizes => BarCodeBLL.GetAllSizes();

        public IEnumerable<SelectListItem> Vendors => BarCodeBLL.GetAllVendors();
    }

    public class Dept
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static Dept Create(IDataRecord record)
        {
            Dept result = null;
            if (record.FieldCount > 0)
            {
                result = new Dept();

                for (int i = 0; i < record.FieldCount; i++)
                {
                    switch (record.GetName(i))
                    {
                        case "Id":
                            int.TryParse(record["Id"].ToString(), out var id);
                            result.Id = id;
                            break;
                        case "Name":
                            result.Name = record["Name"].ToString();
                            break;
                    }
                }
            }

            return result;
        }
    }

    public class Quality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static Quality Create(IDataRecord record)
        {
            Quality result = null;
            if (record.FieldCount > 0)
            {
                result = new Quality();

                for (int i = 0; i < record.FieldCount; i++)
                {
                    switch (record.GetName(i))
                    {
                        case "Id":
                            int.TryParse(record["Id"].ToString(), out var id);
                            result.Id = id;
                            break;
                        case "Name":
                            result.Name = record["Name"].ToString();
                            break;
                    }
                }
            }

            return result;
        }
    }
    public class Craft
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static Craft Create(IDataRecord record)
        {
            Craft result = null;
            if (record.FieldCount > 0)
            {
                result = new Craft();

                for (int i = 0; i < record.FieldCount; i++)
                {
                    switch (record.GetName(i))
                    {
                        case "Id":
                            int.TryParse(record["Id"].ToString(), out var id);
                            result.Id = id;
                            break;
                        case "Name":
                            result.Name = record["Name"].ToString();
                            break;
                    }
                }
            }

            return result;
        }
    }
    public class Size
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static Size Create(IDataRecord record)
        {
            Size result = null;
            if (record.FieldCount > 0)
            {
                result = new Size();

                for (int i = 0; i < record.FieldCount; i++)
                {
                    switch (record.GetName(i))
                    {
                        case "Id":
                            int.TryParse(record["Id"].ToString(), out var id);
                            result.Id = id;
                            break;
                        case "Name":
                            result.Name = record["Name"].ToString();
                            break;
                    }
                }
            }

            return result;
        }
    }
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static Vendor Create(IDataRecord record)
        {
            Vendor result = null;
            if (record.FieldCount > 0)
            {
                result = new Vendor();

                for (int i = 0; i < record.FieldCount; i++)
                {
                    switch (record.GetName(i))
                    {
                        case "Id":
                            int.TryParse(record["Id"].ToString(), out var id);
                            result.Id = id;
                            break;
                        case "Name":
                            result.Name = record["Name"].ToString();
                            break;
                    }
                }
            }

            return result;
        }
    }
    //public class ManufactureDate
    //{
    //    public int Id { get; set; }
    //    public string Format { get; set; }
    //    public string Name { get; set; }

    //    public static ManufactureDate Create(IDataRecord record)
    //    {
    //        ManufactureDate result = null;
    //        if (record.FieldCount > 0)
    //        {
    //            result = new ManufactureDate();

    //            for (int i = 0; i < record.FieldCount; i++)
    //            {
    //                switch (record.GetName(i))
    //                {
    //                    case "Id":
    //                        int.TryParse(record["Id"].ToString(), out var id);
    //                        result.Id = id;
    //                        break;
    //                    case "Name":
    //                        result.Name = record["Name"].ToString();
    //                        break;
    //                    case "Format":
    //                        result.Format = record["Format"].ToString();
    //                        break;
    //                }
    //            }
    //        }

    //        return result;
    //    }
    //}
    //public class ActualCost
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
    //public class SellingPrice
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
    //public class MRP
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}