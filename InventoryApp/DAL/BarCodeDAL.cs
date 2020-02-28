using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using InventoryApp.Models;
using InventoryApp.Models.BarCode;
using InventoryApp.Models.Constants;

namespace InventoryApp.DAL
{
    public static class BarCodeDAL
    {
        static readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static List<Dept> GetAllDepts()
        {
            List<Dept> result;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = DBConstants.usp_getAllDept;
                SqlCommand sqlCommand = new SqlCommand(cmdText, connection) {CommandType = CommandType.StoredProcedure};
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                DataHelper dataHelper = new DataHelper();
                result = dataHelper.GetData(sqlDataReader, Dept.Create).ToList();
            }

            return result;
        }

        public static List<Quality> GetAllQualitys()
        {
            List<Quality> result;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = DBConstants.usp_getAllQuality;
                SqlCommand sqlCommand = new SqlCommand(cmdText, connection) {CommandType = CommandType.StoredProcedure};
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                DataHelper dataHelper = new DataHelper();
                result = dataHelper.GetData(sqlDataReader, Quality.Create).ToList();
            }

            return result;
        }

        public static List<Craft> GetAllCrafts()
        {
            List<Craft> result;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = DBConstants.usp_getAllCraft;
                SqlCommand sqlCommand = new SqlCommand(cmdText, connection) { CommandType = CommandType.StoredProcedure };
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                DataHelper dataHelper = new DataHelper();
                result = dataHelper.GetData(sqlDataReader, Craft.Create).ToList();
            }

            return result;
        }

        public static List<Size> GetAllSizes()
        {
            List<Size> result;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = DBConstants.usp_getAllSize;
                SqlCommand sqlCommand = new SqlCommand(cmdText, connection) { CommandType = CommandType.StoredProcedure };
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                DataHelper dataHelper = new DataHelper();
                result = dataHelper.GetData(sqlDataReader, Size.Create).ToList();
            }

            return result;
        }

        public static List<Vendor> GetAllVendors()
        {
            List<Vendor> result;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = DBConstants.usp_getAllVendor;
                SqlCommand sqlCommand = new SqlCommand(cmdText, connection) { CommandType = CommandType.StoredProcedure };
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                DataHelper dataHelper = new DataHelper();
                result = dataHelper.GetData(sqlDataReader, Vendor.Create).ToList();
            }

            return result;
        }

        public static void SaveBarCodeProperties(string item, string value)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = DBConstants.usp_saveBarCodeProperties;
                SqlCommand sqlCommand = new SqlCommand(cmdText, connection) { CommandType = CommandType.StoredProcedure };
                sqlCommand.Parameters.AddWithValue("@item", item);
                sqlCommand.Parameters.AddWithValue("@itemValue", value);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public static void SaveBarCode(BarCodeDTO dto, string barCodeValue, string relativePath)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = DBConstants.usp_saveBarCode;
                SqlCommand sqlCommand = new SqlCommand(cmdText, connection) { CommandType = CommandType.StoredProcedure };
                sqlCommand.Parameters.AddWithValue("@mrp", dto.Mrp);
                sqlCommand.Parameters.AddWithValue("@dept", dto.Dept);
                sqlCommand.Parameters.AddWithValue("@craft", dto.Craft);
                sqlCommand.Parameters.AddWithValue("@size", dto.Size);
                sqlCommand.Parameters.AddWithValue("@quality", dto.Quality);
                sqlCommand.Parameters.AddWithValue("@actualCost", dto.ActualCost);
                sqlCommand.Parameters.AddWithValue("@sellingPrice", dto.SellingPrice);
                sqlCommand.Parameters.AddWithValue("@vendor", dto.Vendor);
                sqlCommand.Parameters.AddWithValue("@barCodeValue", barCodeValue);
                sqlCommand.Parameters.AddWithValue("@relativePath", relativePath);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public static int CheckDbEntryForBarCode(string dtoBarCodeValue)
        {
            string barCodeToCheck = dtoBarCodeValue.Substring(0, dtoBarCodeValue.Length - 2) + "%";
            Object response;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = DBConstants.usp_getBarCodeByPattern;
                SqlCommand sqlCommand = new SqlCommand(cmdText, connection) { CommandType = CommandType.StoredProcedure };
                sqlCommand.Parameters.AddWithValue("@barCodeToCheck", barCodeToCheck);
                 response = sqlCommand.ExecuteScalar();
            }

            return Convert.ToInt32(response.ToString());
        }

        public static string ValidateOrCreateBarCode(string barCodeValue, float mrp)
        {
            string status = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = DBConstants.usp_validateBarCode;
                SqlCommand sqlCommand = new SqlCommand(cmdText, connection) {CommandType = CommandType.StoredProcedure};
                sqlCommand.Parameters.AddWithValue("@barCodeValue", barCodeValue);
                sqlCommand.Parameters.AddWithValue("@mrp", mrp);
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    // get the results of each column
                    status = reader["Status"].ToString();
                }
            }

            return status;
        }

        public static string GetBarCodeFilePathByBarCode(string currentBarCode)
        {
            string filePath = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = DBConstants.usp_getFilePathByBarCode;
                SqlCommand sqlCommand = new SqlCommand(cmdText, connection) { CommandType = CommandType.StoredProcedure };
                sqlCommand.Parameters.AddWithValue("@barCodeValue", currentBarCode);
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    // get the results of each column
                    filePath = reader["RelativePath"].ToString();
                }
            }

            return filePath;
        }

        public static void SaveProduct(ProductInfo product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = DBConstants.usp_saveProductByInfo;
                SqlCommand sqlCommand = new SqlCommand(cmdText, connection) { CommandType = CommandType.StoredProcedure };
                sqlCommand.Parameters.AddWithValue("@barCodeValue", product.BarCode);
                sqlCommand.Parameters.AddWithValue("@count", product.Count);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}