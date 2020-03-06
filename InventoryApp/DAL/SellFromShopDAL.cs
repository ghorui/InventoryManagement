using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using InventoryApp.Models;
using InventoryApp.Models.Constants;
using InventoryApp.Models.Shopping;

namespace InventoryApp.DAL
{
    public class SellFromShopDAL
    {
        public static Customer GetCustomer(string mobileNumber)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var result = new Customer();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string cmdText = DBConstants.usp_GetCustomerbyMobileNumber;
                    SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
                    sqlCommand.Parameters.AddWithValue("@mobileNumber", mobileNumber);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    DataHelper dataHelper = new DataHelper();
                    var res = dataHelper.GetData(sqlDataReader, Customer.Create).ToList();
                    result = res.Count > 0 ? res[0] : null;
                }
            }
            catch (Exception exception)
            {
                Console.Write("Error:SellFromShopDAL:GetCustomer:{0}:{1}", exception.Message, exception);
                throw;
            }
            return result;
        }

        internal static long SellProduct(BillingDTO billingDto)
        {
            var transactionId = billingDto.TransactionId;
            if (billingDto != null)
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string cmdText = DBConstants.usp_saveBillingDetails;
                    SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
                    sqlCommand.Parameters.AddWithValue("@overallDiscountRate", billingDto.OverallDiscountRate);
                    sqlCommand.Parameters.AddWithValue("@overallDiscountAmount", billingDto.OverallDiscountAmount);
                    sqlCommand.Parameters.AddWithValue("@CGSTRate", billingDto.CGSTRate);
                    sqlCommand.Parameters.AddWithValue("@CGSTAmount", billingDto.CGSTAmount);
                    sqlCommand.Parameters.AddWithValue("@SGSTRate", billingDto.SGSTRate);
                    sqlCommand.Parameters.AddWithValue("@SGSTAmount", billingDto.SGSTAmount);
                    sqlCommand.Parameters.AddWithValue("@IGSTRate", billingDto.IGSTRate);
                    sqlCommand.Parameters.AddWithValue("@IGSTAmount", billingDto.IGSTAmount);
                    sqlCommand.Parameters.AddWithValue("@AdditionalCharges", billingDto.AdditionalCharges);
                    sqlCommand.Parameters.AddWithValue("@totalAmount", billingDto.TotalAmount);
                    sqlCommand.Parameters.AddWithValue("@grandAmount", billingDto.GrandTotal);
                    sqlCommand.Parameters.AddWithValue("@lastUpdatedUser", billingDto.LastUpdatedUser);
                    sqlCommand.Parameters.AddWithValue("@transactionId", 0);
                    sqlCommand.Parameters.AddWithValue("@customerMobile", billingDto.CustomerMobile);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        var res = sqlDataReader["TransactionId"].ToString();
                        long.TryParse(res, out transactionId);
                    }

                }

                if (transactionId > 0)
                {
                    foreach (var product in billingDto.Products)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string cmdText = DBConstants.usp_saveProductsSoldAtShop;
                            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
                            sqlCommand.Parameters.AddWithValue("@barCode", product.BarCode);
                            sqlCommand.Parameters.AddWithValue("@itemName", product.ItemName);
                            sqlCommand.Parameters.AddWithValue("@quantity", product.Quantity);
                            sqlCommand.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
                            sqlCommand.Parameters.AddWithValue("@value", product.Value);
                            sqlCommand.Parameters.AddWithValue("@itemDiscountPercentage", product.ItemDiscountPercentage);
                            sqlCommand.Parameters.AddWithValue("@itemDiscountAmount", product.ItemDiscountAmount);
                            sqlCommand.Parameters.AddWithValue("@taxableValue", product.TaxableValue);
                            sqlCommand.Parameters.AddWithValue("@billingTrxId", transactionId);
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                            if (sqlDataReader.Read())
                            {
                                var productId = Convert.ToInt32(sqlDataReader["ProductId"].ToString());
                            }

                        }
                    }
                }
                return transactionId;
            }

            return 0;
        }

        public static int SaveCustomer(Customer model)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = DBConstants.usp_SaveCustomerbyMobileNumber;
                SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
                sqlCommand.Parameters.AddWithValue("@mobileNumber", model.MobileNumber);
                sqlCommand.Parameters.AddWithValue("@name", model.Name);
                sqlCommand.Parameters.AddWithValue("@address", model.Address);
                sqlCommand.Parameters.AddWithValue("@email", model.Email);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                res = sqlCommand.ExecuteNonQuery();
            }
            return res;
        }

        public static bool UpdatePaymentConfirmation(long transactionId)
        {
            if (transactionId != 0)
            {
                return true;
            }

            return false;
        }

        public static BillingDTO GetBillingDetailsByTransationId(long transactionId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            BillingDTO res = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = DBConstants.usp_getBillingDetailsbyTrxId;
                var sqlCommand = new SqlCommand(cmdText, connection);
                sqlCommand.Parameters.AddWithValue("@transactionId", transactionId);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                var dataHelper = new DataHelper();
                res = dataHelper.GetData(sqlDataReader, BillingDTO.Create).FirstOrDefault();
                if (res != null)
                {
                    res.Products = new List<Product>();
                    res.Products.AddRange(GetProductDetailsByTransationId(res.TransactionId));
                }
            }
            return res;
        }

        public static List<Product> GetProductDetailsByTransationId(long transactionId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            List<Product> res;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = DBConstants.usp_getProductsDetailsbyBillingTrxId;
                SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
                sqlCommand.Parameters.AddWithValue("@transactionId", transactionId);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                DataHelper dataHelper = new DataHelper();
                res = dataHelper.GetData(sqlDataReader, Product.Create).ToList();
            }
            return res;
        }

        public static List<Product> GetProductByBarCode(string barCode)
        {
            
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            List<Product> res;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = DBConstants.usp_getProductsDetailsByBarCode;
                SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
                sqlCommand.Parameters.AddWithValue("@barCode", barCode);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                DataHelper dataHelper = new DataHelper();
                res = dataHelper.GetData(sqlDataReader, Product.Create).ToList();
            }
            return res;
        }

        public static Customer GetCustomerDetailsByTransactionId(string transactionId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Customer res;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = DBConstants.usp_GetCustomerbytransactionId;
                SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
                sqlCommand.Parameters.AddWithValue("@transactionId", transactionId);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                DataHelper dataHelper = new DataHelper();
                res = dataHelper.GetData(sqlDataReader, Customer.Create).FirstOrDefault();
            }
            return res;
        }
    }
}