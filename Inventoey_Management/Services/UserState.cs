using System;
using System.Collections.Generic;
using System.Text;
using Inventoey_Management.Models;
namespace Inventoey_Management.Services
{
    public class UserState
    {
        public Admin? Admin { get; set; }
        public event Action? OnChange;
    }


}
