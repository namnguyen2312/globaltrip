using NBT.Core.Domain.Catalog;
using NBT.Core.Services.ApplicationServices.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBT.Core.Services.Data;
using NBT.Core.Services.DomainServices.Catalog;

namespace NBT.Infra.Services.Catalog
{
    public class TourAttributeService : ServiceBase<TourAttribute>, ITourAttributeService
    {
        ITourAttributeRepository _tourAttributeRepo;
        public TourAttributeService(IUnitOfWork unitOfWork, ITourAttributeRepository tourAttributeRepo) : base(unitOfWork, tourAttributeRepo)
        {
            _tourAttributeRepo = tourAttributeRepo;
        }

        public IEnumerable<TourAttribute> GetAll()
        {
            return _tourAttributeRepo.TableNoTracking.ToList();
        }
    }
}
