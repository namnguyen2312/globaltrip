using NBT.Core.Domain.Catalog;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.ApplicationServices.Catalog
{
    public interface ICountryRegionService:IService<CountryRegion>
    {
        IEnumerable<CountryRegion> GetAll(bool? isShow = null,bool? domestic=null);
        IPagedList<CountryRegion> GetAll(int pageIndex=1, int pageSize =20, string filter = "", int continentId=0);
    }
}
