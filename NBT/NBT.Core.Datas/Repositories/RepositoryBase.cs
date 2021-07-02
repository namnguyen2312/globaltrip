using NBT.Core.Common;
using NBT.Core.Services.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Datas.Repositories
{
    public class RepositoryBase<T> : DisposableObject, IRepository<T> where T : class
    {
        protected MasterDBContext DbContext { get; }
        protected DbSet<T> DbSet => this.DbContext.Set<T>();
        protected DbQuery<T> DbQueryNotracking => this.DbSet.AsNoTracking();

        public RepositoryBase(MasterDBContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public IQueryable<T> Table
        {
            get
            {
                return this.DbSet;
            }
        }

        public IQueryable<T> TableNoTracking
        {
            get
            {
                return this.DbQueryNotracking;
            }
        }
        public IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = DbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.Where<T>(predicate).AsQueryable<T>();
            }

            return DbContext.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        public T Delete(T entity)
        {
            entity = DbSet.Remove(entity);
            DbContext.SaveChanges();
            return entity;
                
        }
        public int Delete(IEnumerable<T> entities)
        {
            try
            {
                foreach (var entity in entities)
                    DbSet.Remove(entity);

                return DbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public async Task DeleteAsync(T entity)
        {
            try
            {
                DbSet.Remove(entity);
                await DbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteAsync(IEnumerable<T> entities)
        {
            try
            {
                foreach (var entity in entities)
                    DbSet.Remove(entity);

                return await DbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public T GetById(object id)
        {
            return DbSet.Find(id);
        }
        public async Task<T> GetByIdAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<T> InsertAsync(T entity)
        {
            try
            {
                var newEntity = DbSet.Add(entity);
                await DbContext.SaveChangesAsync();
                return newEntity;
            }
            catch
            {
                throw;
            }

        }

        public async Task<int> InsertAsync(IEnumerable<T> entities)
        {
            try
            {
                DbSet.AddRange(entities);
                return await DbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

        }

        public int Insert(IEnumerable<T> entities)
        {
            try
            {
                DbSet.AddRange(entities);
                return DbContext.SaveChanges();
            }
            catch
            {
                throw;
            }

        }
        public T Insert(T entity)
        {
            try
            {
                DbSet.Add(entity);
                DbContext.SaveChanges();
                return entity;
            }
            catch
            {
                throw;
            }
        }

        public T Update(T entity)
        {
            try
            {
                DbSet.Attach(entity);
                DbContext.Entry(entity).State = EntityState.Modified;
                DbContext.SaveChanges();
                return entity;
            }
            catch
            {
                throw;
            }
        }
        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                DbSet.Attach(entity);
                DbContext.Entry(entity).State = EntityState.Modified;
                await DbContext.SaveChangesAsync();
                return entity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateAsync(IEnumerable<T> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    DbSet.Attach(entity);
                    DbContext.Entry(entity).State = EntityState.Modified;
                }
                var result = await DbContext.SaveChangesAsync();
                return result;
            }
            catch
            {
                throw;
            }
        }

        protected override void DisposeCore()
        {
            this.DbContext.Dispose();
        }

        public bool CheckContains(Expression<Func<T, bool>> predicate)
        {
            return DbQueryNotracking.Count(predicate) > 0;
        }

        
    }
}
