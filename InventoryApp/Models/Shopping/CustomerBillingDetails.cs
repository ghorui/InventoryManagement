using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryApp.Models.Shopping
{
    public class CustomerBillingDetails
    {
        public BillingDTO BillingDto { get; set; }
        public Customer Customer { get; set; }
    }
}