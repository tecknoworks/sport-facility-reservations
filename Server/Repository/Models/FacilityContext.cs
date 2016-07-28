using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Repository.Domain;
using Repository.Migrations;
using Repository.Models;
using Repository.Repositories;

namespace Repository.Domain
{
    public class FacilityContext : DbContext
    {
        public FacilityContext()
            : base("FacilityContext")
        {
            //this.Configuration.LazyLoadingEnabled = false;
           // Database.SetInitializer(new MigrateDatabaseToLatestVersion<FacilityContext, Repository.Migrations.Configuration>("FacilityContext"));
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FacilityContext, Configuration>("FacilityContext"));
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ///!!!!!!
           // modelBuilder.Configurations.Add(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
