using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using InventoryApp.Models;
using InventoryApp.Models.Constants;
using Microsoft.AspNet.Identity;

namespace InventoryApp.Util
{
    public static class Logger
    {
        public static void Log(string user, string action, string transactionId, string barcode, string message)
        {
            var fileName = string.Empty;
            var methodName = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name;
            var declaringType = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().DeclaringType;
            if (declaringType != null)
            {
                fileName = declaringType.Name;
            }

            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmdText = DBConstants.usp_AddLog;
                var sqlCommand = new SqlCommand(cmdText, connection);
                sqlCommand.Parameters.AddWithValue("@user", user ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@action", action ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@transactionId", transactionId ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@barCode", barcode ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@message", message ?? string.Empty);
                sqlCommand.Parameters.AddWithValue("@fileName", fileName);
                sqlCommand.Parameters.AddWithValue("@methodName", methodName);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
            }
        }
        
    }
}