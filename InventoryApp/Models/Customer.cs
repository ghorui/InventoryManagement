using InventoryApp.Models.Shopping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace InventoryApp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MobileNumber { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string CustomerGST { get; set; }

        public static Customer Create(IDataRecord record)
        {
            Customer result = null;
            if (record.FieldCount > 0)
            {
                result = new Customer();

                for (int i = 0; i < record.FieldCount; i++)
                {
                    var propertyName = record.GetName(i);
                    switch (propertyName)
                    {
                        case "Id":
                            result.Id = Convert.ToInt32(record[propertyName].ToString());
                            break;
                        case "Name":
                            result.Name = record[propertyName].ToString();
                            break;
                        case "MobNum":
                            result.MobileNumber = record[propertyName].ToString();
                            break;
                        case "Address":
                            result.Address = record[propertyName].ToString();
                            break;
                        case "Email":
                            result.Email = record[propertyName].ToString();
                            break;
                        case "GST":
                            result.CustomerGST = record[propertyName].ToString();
                            break;
                    }
                }
            }
            return result;
        }

        public UniqueSellingProduct GetSellingProducts()
        {
            return new UniqueSellingProduct()
            {
                SellingProducts = new List<SellingProduct>(),
                UniqueIdentifier = Guid.NewGuid()
            };
        }

    }
}