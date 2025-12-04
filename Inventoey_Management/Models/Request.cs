using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SQLite;
namespace Inventoey_Management.Models
{
    public class Request : Base
    {
        public string? Report { get; set; } = null;
        public string Status { get; set; } = "Pending";
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        [ForeignKey("Component")]
        public int ComponentId { get; set; }
        [ForeignKey("Technician")]
        public int TechnicianId { get; set; }
    }
}
