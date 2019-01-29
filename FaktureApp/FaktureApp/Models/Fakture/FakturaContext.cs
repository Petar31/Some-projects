using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FaktureApp.Models.Fakture
{
    public class FakturaContext : DbContext
    {
      

        public FakturaContext(DbContextOptions<FakturaContext> options) : base(options)
        {

        }

        public DbSet<Faktura> Fakture { get; set; }
        public DbSet<Stavka> Stavke { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stavka>().HasKey(x => new { x.RedniBroj, x.BrojDokumenta });
        }

    }
}
