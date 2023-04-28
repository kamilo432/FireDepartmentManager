using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FireDepartmentManager.Models;

namespace FireDepartmentManager.Data
{
    public class FireDepartmentManagerContext : DbContext
    {
        public FireDepartmentManagerContext (DbContextOptions<FireDepartmentManagerContext> options)
            : base(options)
        {
        }

        public DbSet<FireDepartmentManager.Models.FireFighter> FireFighter { get; set; } = default!;

        public DbSet<FireDepartmentManager.Models.Vehicle>? Vehicle { get; set; }

        public DbSet<FireDepartmentManager.Models.Action>? Action { get; set; }
    }
}
