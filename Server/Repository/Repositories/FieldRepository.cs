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
        private DbSet<Field> _dbSet;
        public FieldRepository(FacilityContext context) : base(context)
        {
            this._dbSet = context.Set<Field>();
        }
        public List<Field> GetFieldsByColumn(Expression<Func<Field, bool>> filter = null,
                                                    Func<IQueryable<Field>, IOrderedQueryable<Field>> orderBy = null,
                                                    string includeProperties = "")
        {
            IQueryable<Field> query = _dbSet;
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
        public IEnumerable<Field> GetFieldsOrderedByPrice()
        {
            return FacilityContext.Fields.OrderByDescending(c => c.Price).ToList();
        }

        public FacilityContext FacilityContext
        {
            get { return Context as FacilityContext; }
        }
    }
}
