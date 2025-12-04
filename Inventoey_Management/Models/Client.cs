using System;
using System.Collections.Generic;
using System.Text;

namespace Inventoey_Management.Models
{
    public class Client : Base
    {
        public int ContactNumber { get; set; }
        public string BuildingName { get; set; } = string.Empty;
        public int Floor { get; set; }
        public string OfficeNumber { get; set; } = string.Empty;
    }
}
