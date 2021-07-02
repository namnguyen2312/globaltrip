using NBT.Core.Domain.Catalog;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.ApplicationServices.Catalog
{
    public interface IStateProvinceService : IService<StateProvince>
    {
        IEnumerable<StateProvince> GetAll(bool? isShow = null);
        IPagedList<StateProvince> GetAll(int pageIndex = 1, int pageSize = 20, string filter = "",int countryRegionId=0);
    }
}
