using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savory.TitanService.Repository
{
    public static class TitanRepository
    {
        public static string GetConnString(string dbName)
        {
            string returnValue = null;

            using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SavoryTitanDB"].ConnectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.CommandText = "SELECT ConnString FROM ConnStringTable WHERE DBName = @DBName";
                    sqlCmd.Connection = sqlConn;
                    sqlCmd.Parameters.AddWithValue("DBName", dbName);

                    sqlConn.Open();

                    var reader = sqlCmd.ExecuteReader();
                    if (reader.Read())
                    {
                        returnValue = reader["ConnString"].ToString();
                    }
                }
            }

            return returnValue;
        }
    }
}
