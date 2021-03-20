using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Helper
{
    public class PersonMap
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string EMailAddress { get; set; }        

    }
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        {

        }
    }

    public static class DB
    {        
        public static List<PersonMap> GetPersonDetails(string connectionString)
        {
            //conn = configuration.GetConnectionString("DefaultConnection");
            List<PersonMap> personMaps = new List<PersonMap>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select top 100 * from Person.PersonInfo", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())                
                {
                    PersonMap personMap = new PersonMap();
                    personMap.LastName = reader["LastName"].ToString();
                    personMap.MiddleName = reader["MiddleName"].ToString();
                    personMap.FirstName = reader["FirstName"].ToString();
                    personMap.TelephoneNumber = reader["TelephoneNumber"].ToString();
                    personMap.AddressLine1 = reader["AddressLine1"].ToString();
                    personMap.State = reader["StateProvinceCode"].ToString();
                    personMap.PostalCode = reader["PostalCode"].ToString();
                    personMap.Country = reader["CountryRegionCode"].ToString();
                    personMap.EMailAddress = reader["EmailAddress"].ToString();
                    personMaps.Add(personMap);
                }
                
                con.Close();
            }
            return personMaps;
        }

    }
}
