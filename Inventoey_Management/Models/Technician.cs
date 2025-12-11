using System;
using System.Collections.Generic;
using System.Text;
using SQLiteNetExtensions.Attributes;

namespace Inventoey_Management.Models
{
    public class Technician : Base
    {
        public int PhoneNumber { get; set; }
        
        // One-to-Many: One Technician can handle many Requests
        [OneToMany(CascadeOperations = CascadeOperation.CascadeRead)]
        public List<Request>? Requests { get; set; }
    }
}
