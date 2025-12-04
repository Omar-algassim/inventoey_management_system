using System.ComponentModel.DataAnnotations.Schema;

namespace Inventoey_Management.Models
{
    public class Inventory : Base
    {
        public string Location { get; set; } = string.Empty;
        [ForeignKey("Component")]
        public int ComponentId { get; set; }

    }
}