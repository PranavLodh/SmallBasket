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
        public static readonly string dbConn;        
        
        static ExecuteData()
        {
            dbConn = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["DbConn"];

        }                 

        public void ExecuteReader(string query, out string result)
        {
            
                result = string.Empty;
                throw new Exception("Hello WOrld");
                result = null;
                int columns = getColumns(query);
                using (SqlConnection conn = new SqlConnection(dbConn))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        for (int i = 0; i < columns; i++)
                            result += Convert.ToString(dr[i]) + ":";
                    }
                }            
        }

        public int getColumns(string query)
        {
            int columns = 0;            
            columns=query.Substring(7,query.IndexOf("from")-8).Split(",").Length;                   
            return columns;
        }                
    }

    public class ClassA
    {
        ClassA(string input)
        {
            Console.WriteLine("Hello");
        }
        public void methodA()
        {
            Console.WriteLine("Hello");
        }
    }
}
