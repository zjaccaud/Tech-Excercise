using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class ContactModel
    {
        public class Contacts
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string CellNum { get; set; }
            public string Email { get; set; }
        }
    }
}
