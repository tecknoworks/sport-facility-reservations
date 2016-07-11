using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface IRepository <TEntity>
    {
        TEntity get(int id);
        IEnumerable<TEntity> GetaAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        

    }
}
