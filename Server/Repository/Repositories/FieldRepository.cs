using Repository.Domain;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class FieldRepository : Repository<Field>, IFieldRepository
    {
        internal DbSet<Field> dbSet;
        public FieldRepository(FacilityContext context) : base(context)
        {
            this.dbSet = context.Set<Field>();
        }

        public IEnumerable<Field> GetFieldsByColumn(Expression<Func<Field, bool>> filter = null,
                                                    Func<IQueryable<Field>, IOrderedQueryable<Field>> orderBy = null,
                                                    string includeProperties = "")
        {



            IQueryable<Field> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
               (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }

        }
        public FacilityContext FacilityContext
        {
            get { return Context as FacilityContext; }
        }

    }
}
