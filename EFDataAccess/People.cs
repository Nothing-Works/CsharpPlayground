using System.Collections.Generic;

namespace EFDataAccess
{
    public class People
    {
        public int Id { get; set; }

        public string FN { get; set; }
        public string LN { get; set; }
        public int Age { get; set; }

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Email> Emails { get; set; } = new List<Email>();
    }
}