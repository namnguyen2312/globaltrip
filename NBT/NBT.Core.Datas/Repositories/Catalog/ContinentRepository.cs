using NBT.Core.Domain.Catalog;
using NBT.Core.Services.DomainServices.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Datas.Repositories.Catalog
{
    public class ContinentRepository : RepositoryBase<Continent>, IContinentRepository
    {
        public ContinentRepository(MasterDBContext dbContext) : base(dbContext)
        {
        }
    }
}
