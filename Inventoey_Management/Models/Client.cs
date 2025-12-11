using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using SQLiteNetExtensions.Attributes;

namespace Inventoey_Management.Models
{
    public class Client : Base
    {
        [Required(ErrorMessage ="رقم الموظف مطلوب")]
        public int ContactNumber { get; set; }
        [Required(ErrorMessage = "اسم المبنى مطلوب")]
        public string BuildingName { get; set; } = string.Empty;
        [Required(ErrorMessage = "رقم المبنى مطلوب")]
        public int BuildingNumber { get; set; }
        [Required(ErrorMessage = "الطابق مطلوب")]
        public int Floor { get; set; }
        [Required(ErrorMessage = "رقم المكتب مطلوب")]
        public string OfficeNumber { get; set; }
        [Required(ErrorMessage = "القسم مطلوب")]
        public string Department { get; set; } = string.Empty;
        
        // One-to-Many: One Client can have many Requests
        [OneToMany(CascadeOperations = CascadeOperation.CascadeRead)]
        public List<Request>? Requests { get; set; }
    }
}
