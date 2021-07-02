using NBT.Core.Domain.Catalog;
using NBT.Core.Services.ApplicationServices.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBT.Core.Services.Data;
using NBT.Core.Services.DomainServices.Catalog;
using PagedList;

namespace NBT.Infra.Services.Catalog
{
    public class StateProvinceService : ServiceBase<StateProvince>, IStateProvinceService
    {
        IStateProvinceRepository _stateProvinceRepo;
        public StateProvinceService(IUnitOfWork unitOfWork, IStateProvinceRepository stateProvinceRepo) : base(unitOfWork, stateProvinceRepo)
        {
            _stateProvinceRepo = stateProvinceRepo;
        }


        public IEnumerable<StateProvince> GetAll(bool? isShow = null)
        {
            return isShow != null ? _stateProvinceRepo.TableNoTracking.Where(x => x.IsShow == isShow.Value).ToList() 
                : _stateProvinceRepo.TableNoTracking.ToList();
        }

        public IPagedList<StateProvince> GetAll(int pageIndex = 1, int pageSize = 20, string filter = "", int countryRegionId = 0)
        {
            var query = _stateProvinceRepo.TableNoTracking;

            if (!string.IsNullOrEmpty(filter))
                query = query.Where(x => x.Name.Contains(filter) || x.Code.Contains(filter));
            if (countryRegionId != 0)
                query = query.Where(x => x.CountryRegionId == countryRegionId);

            return query.OrderBy(x => x.Name).ToPagedList(pageIndex, pageSize);
        }
    }
}
