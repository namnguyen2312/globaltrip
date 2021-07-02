using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.Data
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<T> GetByIdAsync(object id);
        T GetById(object id);

        Task<T> InsertAsync(T entity);

        T Insert(T entity);
        int Insert(IEnumerable<T> entities);

        Task<int> InsertAsync(IEnumerable<T> entities);

        Task<T> UpdateAsync(T entity);

        T Update(T entity);

        Task<int> UpdateAsync(IEnumerable<T> entities);

        Task DeleteAsync(T entity);

        T Delete(T entity);

        Task<int> DeleteAsync(IEnumerable<T> entities);
        int Delete(IEnumerable<T> entities);

        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }
        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);
        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}
