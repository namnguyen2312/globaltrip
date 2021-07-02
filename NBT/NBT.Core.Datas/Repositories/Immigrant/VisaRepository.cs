using NBT.Core.Domain.Immigrant;
using NBT.Core.Services.DomainServices.Immigrant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Datas.Repositories.Immigrant
{
    public class VisaRepository : RepositoryBase<Visa>, IVisaRepository
    {
        public VisaRepository(MasterDBContext dbContext) : base(dbContext)
        {
        }
    }
}
