using System;
using Inventoey_Management.Models;

namespace Inventoey_Management.Services
{
    public class UserState
    {
        public Admin? Admin { get; private set; }
        public event Action? OnChange;

        public void SetAdmin(Admin? admin)
        {
            Admin = admin;
            OnChange?.Invoke();
        }
    }
}
