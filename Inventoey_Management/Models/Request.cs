using System;
using System.Collections.Generic;
using System.Text;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Inventoey_Management.Models
{
    public class Request : Base
    {
        public string? Report { get; set; } = null;
        public string Status { get; set; } = "newRequest";
        [Required(ErrorMessage ="نوع الآلة مطلوب")]
        public string? MachineType { get; set;}
        [Required(ErrorMessage = "كود الآلة مطلوب")]
        public string? MachineCode { get; set;}
        public string? Note { get; set; }
        public int ComponentQuantity { get; set; } = 0;

        [ForeignKey(typeof(Client))]
        public int ClientId { get; set; }
        
        [ForeignKey(typeof(Component))]
        public int ComponentId { get; set; }
        
        [ForeignKey(typeof(Technician))]
        public int TechnicianId { get; set; }

        // Many-to-One relationships
        [ManyToOne]
        public Client? Client { get; set; }
        
        [ManyToOne]
        public Component? Component { get; set; }
        
        [ManyToOne]
        public Technician? Technician { get; set; }
    }
}
