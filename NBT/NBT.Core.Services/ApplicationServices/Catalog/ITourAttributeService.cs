using NBT.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.ApplicationServices.Catalog
{
    public interface ITourAttributeService : IService<TourAttribute>
    {
        IEnumerable<TourAttribute> GetAll();
    }
}
