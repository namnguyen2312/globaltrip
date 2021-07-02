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
    public class ErrorService : ServiceBase<Error>, IErrorService
    {
        IErrorRepository _errorRepo;
        public ErrorService(IUnitOfWork unitOfWork, IErrorRepository errorRepo) : base(unitOfWork, errorRepo)
        {
            _errorRepo = errorRepo;
        }
    }
}
