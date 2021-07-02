using NBT.Core.Domain.Catalog;
using NBT.Core.Services.ApplicationServices.Catalog;
using NBT.Core.Services.Data;
using NBT.Core.Services.DomainServices.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Infra.Services.Catalog
{
    public class AreaService : ServiceBase<Area>, IAreaService
    {
        IAreaRepository _areaRepo;
        public AreaService(IUnitOfWork unitOfWork, IAreaRepository areaRepo) : base(unitOfWork, areaRepo)
        {
            _areaRepo = areaRepo;
        }

        public IEnumerable<Area> GetAll(bool? isShow = null)
        {
            return _areaRepo.TableNoTracking.ToList();
        }
    }
}
