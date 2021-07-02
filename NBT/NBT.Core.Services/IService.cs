using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services
{
    public interface IService<T> : IDisposable where T : class
    {
        T GetById(object id);
        Task<T> GetByIdAsync(object id);
        Task AddAsync(T entity);
        T Add(T entity);
        Task UpdateAsync(T entity);
        T Update(T entity);
        Task DeleteAsync(T entity);
    }
}
