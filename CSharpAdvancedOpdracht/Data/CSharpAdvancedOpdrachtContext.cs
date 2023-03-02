using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CSharpAdvancedOpdracht.Models;

namespace CSharpAdvancedOpdracht.Data
{
    public class CSharpAdvancedOpdrachtContext : DbContext
    {
        public CSharpAdvancedOpdrachtContext (DbContextOptions<CSharpAdvancedOpdrachtContext> options)
            : base(options)
        {
        }

        public DbSet<CSharpAdvancedOpdracht.Models.Landlords> Landlords { get; set; } = default!;

        public DbSet<CSharpAdvancedOpdracht.Models.Locations> Locations { get; set; }
    }
}
