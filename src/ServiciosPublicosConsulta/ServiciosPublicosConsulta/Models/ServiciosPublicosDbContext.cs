using ServiciosPublicos.DataAccess.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ServiciosPublicosConsulta.Models
{
    public class ServiciosPublicosDbContext:DbContext
    {
        public ServiciosPublicosDbContext()
            : base("ServiciosPublicos")
        {
            Database.SetInitializer<ServiciosPublicosDbContext>(null);
        }

        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>().HasKey(k => k.Id);
            modelBuilder.Entity<Log>().ToTable("Log", "public");
        }
    }
}