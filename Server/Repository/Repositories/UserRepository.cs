using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Domain;
using Repository.Models;
using Repository.Repositories;

namespace Repository.Domain
{
    public class UserRepository : Repository<User>,IUserRepository
    {
        public UserRepository(FacilityContext context)
           : base(context)
        {
        }


        public FacilityContext FacilityContext
        {
            get { return Context as FacilityContext; }
        }

    }
}
