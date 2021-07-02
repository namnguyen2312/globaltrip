using NBT.Core.Domain.System;
using NBT.Core.Services.DomainServices.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Datas.Repositories.System
{
    public class ErrorRepository : RepositoryBase<Error>, IErrorRepository
    {
        public ErrorRepository(MasterDBContext dbContext) : base(dbContext)
        {
        }
    }
}
