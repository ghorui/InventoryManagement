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

        public Product GetProductByBarcode(string barcode)
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Product result;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmdText = DBConstants.usp_getProductByBarCode;
                var sqlCommand = new SqlCommand(cmdText, connection);
                sqlCommand.Parameters.AddWithValue("@barCode", barcode);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var sqlDataReader = sqlCommand.ExecuteReader();
                var dataHelper = new DataHelper();
                result = dataHelper.GetData(sqlDataReader, Product.Create).FirstOrDefault();
            }
            return result;
        }

        public bool SaveProductByBarcode(Product product)
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmdText = DBConstants.usp_updateProductsDetailsByBarCode;
                var sqlCommand = new SqlCommand(cmdText, connection);
                sqlCommand.Parameters.AddWithValue("@barCode", product.BarCode);
                sqlCommand.Parameters.AddWithValue("@quantity", product.Quantity);
                sqlCommand.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
                sqlCommand.Parameters.AddWithValue("@itemName", product.ItemName);
                sqlCommand.Parameters.AddWithValue("@vendor", product.Vendor);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
            }
            return true;
        }
    }
}