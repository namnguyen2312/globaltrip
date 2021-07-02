using NBT.Core.Domain.System;
using NBT.Core.Services.ApplicationServices.System;
using NBT.Core.Services.Data;
using NBT.Core.Services.DomainServices.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Infra.Services.System
{
    public class ConverseService : ServiceBase<Converse>, IConverseService
    {
        IConverseRepository _converseRepo;
        public ConverseService(IUnitOfWork unitOfWork, IConverseRepository converseRepo) : base(unitOfWork, converseRepo)
        {
            _converseRepo = converseRepo;
        }

        public IEnumerable<Converse> GetAll(bool? isShow = null)
        {
            var query = _converseRepo.TableNoTracking;
            if (isShow != null)
                query = query.Where(x=>x.IsShow == isShow);
            return query.ToList();
        }
    }
}
