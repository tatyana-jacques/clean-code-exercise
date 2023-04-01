using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Seeds
{
    internal static class PermissionSeed
    {
        public static List<Permission> Seed { get; set; } = new List<Permission>() {
            new Permission
            {
                Id = 1,
                Name= "Employee",
            },
            new Permission
            {
                Id = 2,
                Name= "Manager",
            },
            new Permission
            {
                Id = 3,
                Name= "Administrator",
            }
        };
    }
}
