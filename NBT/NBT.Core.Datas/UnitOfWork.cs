using NBT.Core.Common;
using NBT.Core.Datas.Factories;
using NBT.Core.Services.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Datas
{
    public class UnitOfWork : DisposableObject, IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private MasterDBContext dbContext;
        private DbContextTransaction _tranContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public MasterDBContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void SaveChange()
        {
            DbContext.SaveChanges();
        }

        public virtual void BeginTran()
        {
            _tranContext = DbContext.Database.BeginTransaction(System.Data.IsolationLevel.Serializable);
        }

        public virtual void CommitTran()
        {
            _tranContext.Commit();
            _tranContext.Dispose();
        }

        public virtual void RollbackTran()
        {
            _tranContext.Rollback();
            _tranContext.Dispose();
        }

        protected override void DisposeCore()
        {
            DbContext?.Dispose();
        }
    }
}
