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
    }
}