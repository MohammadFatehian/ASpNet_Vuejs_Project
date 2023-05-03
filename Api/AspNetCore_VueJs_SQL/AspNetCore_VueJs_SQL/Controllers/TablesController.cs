using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_VueJs_SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TablesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // Get DataBase Tables List From SQL
        [HttpGet]

        public IList<string> TableList()
        {
            List<string> tables = new List<string>();
            string query = @"select * from INFORMATION_SCHEMA.TABLES GO";
            DataTable dataTable = new DataTable();
            string dataSource = _configuration.GetConnectionString("DBVue_AspNetCore_SQLConnection");
            
            

            using (SqlConnection myconnections = new SqlConnection(dataSource))
            {
                myconnections.Open();
                using (SqlCommand mycommand = new SqlCommand(query, myconnections))
                {
                    dataTable = myconnections.GetSchema("Tables");
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        string tableName = (string)dataRow[2];
                        tables.Add(tableName);
                    }
                    myconnections.Close();
                }
            }

            return tables;
        }

        //Get Records from Selected Table

        [HttpGet("[action]/{name}")]
        public JsonResult GetTable(string name)
       {
            string tableName = "dbo."+name ;
            string query = $"select * from {tableName}";
            DataTable dataTable = new DataTable();
            string dataSource = _configuration.GetConnectionString("DBVue_AspNetCore_SQLConnection");
            SqlDataReader dataReader;
            using (SqlConnection myconnections = new SqlConnection(dataSource))
            {
                myconnections.Open();
                using (SqlCommand mycommand = new SqlCommand(query, myconnections))
                {
                    dataReader = mycommand.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataReader.Close();
                    myconnections.Close();
                }
            }

            return new JsonResult(dataTable);

        }


       
    }
}
