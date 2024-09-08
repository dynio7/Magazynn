using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Magazyn.Models;

namespace Magazyn.Data
{
    public class MagazynContext : DbContext
    {
        public MagazynContext (DbContextOptions<MagazynContext> options)
            : base(options)
        {
        }

        public DbSet<Magazyn.Models.Category> Category { get; set; } = default!;
        public DbSet<Magazyn.Models.Product> Product { get; set; } = default!;
    }
}
