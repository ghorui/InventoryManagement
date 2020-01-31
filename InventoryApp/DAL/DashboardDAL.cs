using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryApp.Models.Shopping;
using System.Data.SqlClient;
using System.Data;
using InventoryApp.Models.Constants;

namespace InventoryApp.DAL
{
    public class DashboardDAL
    {
        public List<Product> GetAllProductsInTheShop()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var result = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = DBConstants.usp_GetAllProductFromShop;
                SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                DataHelper dataHelper = new DataHelper();
                result = dataHelper.GetData(sqlDataReader, Product.Create).ToList();
            }
            return result;
        }

        public List<Product> GetAllProductsInTheInventory()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var result = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = DBConstants.usp_GetAllProductFromInventory;
                SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                DataHelper dataHelper = new DataHelper();
                result = dataHelper.GetData(sqlDataReader, Product.Create).ToList();
            }
            return result;
        }
    }
}