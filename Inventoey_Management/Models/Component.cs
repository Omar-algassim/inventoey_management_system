using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Text;

namespace Inventoey_Management.Models
{
    public class Component : Base
    {
        public string Description { get; set; } = string.Empty;
        public int Amount { get; set; }
        public string Code { get; set; } = string.Empty;
        
        [ForeignKey(typeof(Inventory))]
        public int InventoryId { get; set; }
        
        [ManyToOne]
        public Inventory? Inventory { get; set; }
        
        // One-to-Many: One Component can be in many Requests
        [OneToMany(CascadeOperations = CascadeOperation.CascadeRead)]
        public List<Request>? Requests { get; set; }
    }
}
