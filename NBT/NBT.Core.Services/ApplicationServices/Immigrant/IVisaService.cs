using NBT.Core.Domain.Immigrant;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.ApplicationServices.Immigrant
{
    public interface IVisaService: IService<Visa>
    {
        IEnumerable<Visa> GetAll(bool? isWeb = null);
        IPagedList<Visa> GetAll(int pageIndex = 1, int pageSize = 20, string filter = "", bool? isWeb = null);
        Visa GetByAlias(string alias);
    }
}
