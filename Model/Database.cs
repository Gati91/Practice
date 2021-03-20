using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Helper
{
    public class PersonMap
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string PhNum { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public string EMailAddress { get; set; }

    }
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        {

        }
    }

    public class DB
    {
         
        private IConfiguration configuration;

        public DB(IConfiguration config)
        {
            this.configuration = config;
        }
        public List<PersonMap> GetPersonDetails()
        {
            //conn = configuration.GetConnectionString("DefaultConnection");
            //List<PersonMap> personMaps = from x in this.dbs.Database.
            using (SqlConnection conn = new SqlConnection(configuration.GetConnectionString("DefaultConnection"))
            {
                 conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from [Person].[vAdditionalContactInfo]", conn);
            }
            
        }
    }
}
