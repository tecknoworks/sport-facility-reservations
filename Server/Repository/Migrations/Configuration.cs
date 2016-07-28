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
            var users = new List<User>
            {
            new User{ID=1, Name="Carson Alexander", Password="clock",UserName="wee"},
            new User{ID=2, Name="Carson1 Alexander", Password="clock1",UserName="wee"},
            new User{ID=3, Name="Carson2 Alexander", Password="clock2",UserName="wee"},
            };
            users.ForEach(s => context.Users.AddOrUpdate(s));
            context.SaveChanges();          
        }
    }
}
