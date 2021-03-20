using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helper;
using MyFirstMVC.Models;

namespace MyFirstMVC.Mapper
{
    public class ModelMap : IMapper
    {
        //DB dB = new DB();
        public List<PersonDetails> MapPersonDetails(string con)
        {
            List<PersonDetails> selfDetails = new List<PersonDetails>();            
            selfDetails.MapListtoModel(DB.GetPersonDetails(con));
            return selfDetails;
        }
    }

    public static class Extenstion
    {
        public static List<PersonDetails> MapListtoModel(this List<PersonDetails> selfDetails, List<PersonMap> personMaps)
        {
            PersonDetails details = new PersonDetails();
            foreach (var item in personMaps)
            {
                details.MapPersontoModel(item);
                selfDetails.Add(details);
            }
            return selfDetails;
        }

        public static PersonDetails MapPersontoModel(this PersonDetails self, PersonMap personMap)
        {
            self.FirstName = personMap.FirstName;
            self.LastName = personMap.LastName;
            self.MiddleName = personMap.MiddleName;
            self.PhNum = personMap.TelephoneNumber;
            self.Address = personMap.AddressLine1;
            self.State = personMap.State;
            self.Country = personMap.Country;
            self.PostalCode = personMap.PostalCode;
            self.EMailAddress = personMap.EMailAddress;
            return self;
        }
    }
}
