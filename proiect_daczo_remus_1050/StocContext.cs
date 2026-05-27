using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace proiect_daczo_remus_1050
{
    internal class StocContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=stoc.db");
        }

        public DbSet<Produs> Produse { get; set; }
        public DbSet<Furnizor> Furnizori { get; set; }
    }
}
