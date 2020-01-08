using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryApp.Models.Shopping;
using System.Data.SqlClient;

namespace InventoryApp.DAL
{
    public class DashboardDAL
    {
        public List<Product> GetAllProductsInTheShop()
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings.Get("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

            }
            return null;
        }
    }
}