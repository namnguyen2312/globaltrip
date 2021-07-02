using NBT.Core.Domain.Catalog;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.ApplicationServices.Catalog
{
    public interface IContinentService:IService<Continent>
    {
        IEnumerable<Continent> GetAll(bool? isShow = null);
    }
}
