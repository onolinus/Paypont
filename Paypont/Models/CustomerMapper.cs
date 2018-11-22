using System;
using CsvHelper.Configuration;

namespace Paypont.Models
{
    public class CustomerMapper : ClassMap<Customer>
    {
        public CustomerMapper()
        {
            Map(x => x.FirstName).Name("FirstName").Index(0);
            Map(x => x.SureName).Name("Surname").Index(1);
            Map(x => x.StreetAddress).Name("StreetAddress").Index(2);
            Map(x => x.City).Name("City").Index(3);
            Map(x => x.PostCode).Name("PostCode").Index(4);

            //FirstName,Surname,StreetAddress,City,PostCode
        }
    }
}
