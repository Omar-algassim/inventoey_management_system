using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventoey_Management.Models
{
    public class Inventory : Base
    {
        public string Location { get; set; } = string.Empty;
        
        // One-to-Many: One Inventory has many Components
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Component>? Components { get; set; }
        
        // One-to-Many: One Inventory has many Admins
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Admin>? Admins { get; set; }
    }
}