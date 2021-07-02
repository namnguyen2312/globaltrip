using NBT.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.ApplicationServices.Catalog
{
    public interface ITourAttributeValueService:IService<TourAttributeValue>
    {
        int DeleteByTourId(long id);
        void Add(IEnumerable<TourAttributeValue> list);
    }
}
