using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAddressBook
{
    public class Contact
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Emails { get; set; }
        public List<string> Phones { get; set; }
    }
}
