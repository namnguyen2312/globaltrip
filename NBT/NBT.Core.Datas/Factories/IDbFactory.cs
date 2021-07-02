using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Datas.Factories
{
    public interface IDbFactory : IDisposable
    {
        MasterDBContext Init();
    }
}
