using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using Repository.Domain;

namespace Repository.Models
{
    public class FacilityInitializer: System.Data.Entity. DropCreateDatabaseIfModelChanges < FacilityContext >
    {
        protected override void Seed(FacilityContext context)
        {
            var users = new List<User>
            {
            new User{ID=1, Name="Alexander"},
            
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var fields= new List<Field>
            {
            new Field{ ID=1,Name="ClujArena",Location="Cluj"},
          
            };
            fields.ForEach(s => context.Fields.Add(s));
            context.SaveChanges();
        }
    }
}
