using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventoey_Management.Models
{
    public class Admin : Base
    {
        [Unique]
        public string Username { get; set; } = string.Empty;
        public string? PasswordHash { get; set; }
        
        [ForeignKey(typeof(Inventory))]
        public int InventoryId { get; set; }
        
        [ManyToOne]
        public Inventory? Inventory { get; set; }
    }
}
