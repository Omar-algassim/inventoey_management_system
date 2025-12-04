using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Inventoey_Management.Models
{
    public class Base
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
