using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.Domain
{
    public interface IFieldRepository : IRepository<Field>
    {
        List<Field> GetFieldsByColumn(Expression<Func<Field, bool>> filter = null,
                                      Func<IQueryable<Field>, IOrderedQueryable<Field>> orderBy = null,
                                      string includeProperties = "");
        IEnumerable<Field> GetFieldsOrderedByPrice();
        IEnumerable<Field> FilterFieldsBy(string name, string location, int type, int length, int width);
    }
}
