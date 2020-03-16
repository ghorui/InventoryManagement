using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryApp.Models.Shopping
{
    public class CustomerSellingProductMapping
    {
        public Customer CustomerModel { get; set; }
        public List<SellingProduct> Products { get; set; }
    }
}