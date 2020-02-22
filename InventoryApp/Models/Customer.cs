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

        public static Customer Create(IDataRecord record)
        {
            Customer customer = new Customer();

            customer.Id = Convert.ToInt32(record["Id"].ToString());
            customer.Name = record["Name"].ToString();
            customer.MobileNumber = record["MobNum"].ToString();
            customer.Address = record["Address"].ToString();
            customer.Email = record["Email"].ToString();

            return customer;

        }

        public List<SellingProduct> GetSellingProducts()
        {
            return new List<SellingProduct>();
        }

    }
}