using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SmallBasket.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SmallBasket.Generic
{
    public class ExecuteData
    {
        private readonly string dbConn;
        
        public ExecuteData()
        {
            dbConn = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["DbConn"];

        }

        public void ExecuteReader(string query)
        {            
            using (SqlConnection conn = new SqlConnection(dbConn))
            {
                SqlCommand cmd = new SqlCommand(query,conn);
                conn.Open();
                
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    string value = Convert.ToString(dr["UserName"]);
                }
            }
        }
    }
}
