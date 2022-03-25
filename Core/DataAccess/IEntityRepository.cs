using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> GetQueryableList { get; }
        T Get(Expression<Func<T, bool>> filter);
        T GetById(int id);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        T Add(T entity);
        IList<T> AddRange(IList<T> entities);
        IList<T> UpdateRange(IList<T> entities);
        int Count(Expression<Func<T, bool>> filter = null);
        T Update(T entity);
        IList<T> DeleteRange(IList<T> entity);
        T Delete(T entity);
        bool Any(Expression<Func<T, bool>> filter);
    }
}
