using System;
namespace Paypont.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public String FirstName { get; set; }
        public String SureName { get; set; }
        public String StreetAddress { get; set; }
        public String City { get; set; }
        public String PostCode { get; set; }

    }
}
