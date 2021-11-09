using ClinicaDentalArt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ClinicaDentalArt.DAL
{
    public class ClinicaContext : DbContext
    {
        public ClinicaContext() : base("ClinicaContext")
        {
        }
        public DbSet<Echipa> Echipe { get; set; }
        public DbSet<Serviciu> Servicii { get; set; }
        public DbSet<Pret> Preturi { get; set; }
        public DbSet<Programare> Programari { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}