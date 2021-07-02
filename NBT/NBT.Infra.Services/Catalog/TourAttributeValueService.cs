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
    public class TourAttributeValueService : ServiceBase<TourAttributeValue>, ITourAttributeValueService
    {
        ITourAttributeValueRepository _tourAttributeValueRepo;
        public TourAttributeValueService(IUnitOfWork unitOfWork, ITourAttributeValueRepository tourAttributeValueRepo) : base(unitOfWork, tourAttributeValueRepo)
        {
            _tourAttributeValueRepo = tourAttributeValueRepo;
        }

        public void Add(IEnumerable<TourAttributeValue> list)
        {
            try
            {
                _tourAttributeValueRepo.Insert(list);
            }
            catch
            {
                throw;
            }
        }

        public int DeleteByTourId(long id)
        {
            try
            {
                var model = _tourAttributeValueRepo.GetMulti(x => x.TourId == id);
                return _tourAttributeValueRepo.Delete(model);
            }
            catch
            {
                throw;
            }
        }
    }
}
