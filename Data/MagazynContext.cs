using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Magazyn.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Magazyn.Data
{
    public class MagazynContext : IdentityDbContext<IdentityUser>
    {
        public MagazynContext (DbContextOptions<MagazynContext> options)
            : base(options)
        {
        }

        public DbSet<Magazyn.Models.Category> Category { get; set; } = default!;
        public DbSet<Magazyn.Models.Product> Product { get; set; } = default!;
    }
}
