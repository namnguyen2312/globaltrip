using NBT.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Datas.Extensions
{
    public interface IDBContextExtension
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity<TEntity>;
    }
}
