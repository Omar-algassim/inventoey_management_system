using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using SQLiteNetExtensions.Attributes;

namespace Inventoey_Management.Models
{
    public class Technician : Base
    {
        [Required, RegularExpression(@"^[0-9]+", ErrorMessage = "رقم التواصل يحتوي ارقاما فقط")]
        public string PhoneNumber { get; set; } = string.Empty;
        
        // One-to-Many: One Technician can handle many Requests
        [OneToMany(CascadeOperations = CascadeOperation.CascadeRead)]
        public List<Request>? Requests { get; set; }
    }
}
