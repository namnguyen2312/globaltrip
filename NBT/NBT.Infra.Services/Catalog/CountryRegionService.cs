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
    public class CountryRegionService : ServiceBase<CountryRegion>, ICountryRegionService
    {
        ICountryRegionRepository _countryRegionRepo;
        public CountryRegionService(IUnitOfWork unitOfWork, ICountryRegionRepository countryRegionRepo) : base(unitOfWork, countryRegionRepo)
        {
            _countryRegionRepo = countryRegionRepo;
        }

        public IEnumerable<CountryRegion> GetAll(bool? isShow = null, bool? domestic = null)
        {
            var query = _countryRegionRepo.TableNoTracking;
            if (isShow != null)
                query = query.Where(x => x.IsShow == isShow.Value);
            if (domestic != null)
                query = query.Where(x => x.Domestic == domestic.Value);
            return query.ToList();
        }

        public IPagedList<CountryRegion> GetAll(int pageIndex = 1, int pageSize = 20, string filter = "", int continentId = 0)
        {
            var query = _countryRegionRepo.TableNoTracking;

            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(x => x.Name.Contains(filter));
            if (continentId != 0)
                query = query.Where(x => x.ContinentId == continentId);

            return query.OrderBy(x => x.Name).ToPagedList(pageIndex, pageSize);
        }
    }
}
