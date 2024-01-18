using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioWeb.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; } 
        public string PhoneNumber { get; set; }
        public string Budget { get; set; }
        public string EMail { get; set; } 
        public string? Comment { get; set; }

    }
}
