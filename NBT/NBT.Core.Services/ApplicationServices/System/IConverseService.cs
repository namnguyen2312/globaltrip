using NBT.Core.Domain.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.ApplicationServices.System
{
    public interface IConverseService:IService<Converse>
    {
        IEnumerable<Converse> GetAll(bool? isShow = null);
    }
}
