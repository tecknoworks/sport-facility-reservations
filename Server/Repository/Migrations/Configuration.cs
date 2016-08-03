namespace Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Repository.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Repository.Domain.FacilityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
        protected override void Seed(Repository.Domain.FacilityContext context)
        {                  
        }
    }
}
