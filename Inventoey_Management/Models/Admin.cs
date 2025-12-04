using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventoey_Management.Models
{
    public class Admin : Base
    {
        [Unique]
        public string Username { get; set; } = string.Empty;
        public string? PasswordHash { get; set; }
        [ForeignKey("Inventory")]
        public int InventoryId { get; set; }
        
    }
}
