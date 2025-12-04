using System;
using System.Collections.Generic;
using System.Text;

namespace Inventoey_Management.Models
{
    public class Component : Base
    {
        public string Description { get; set; } = string.Empty;
        public int Amount { get; set; }
    }
}
