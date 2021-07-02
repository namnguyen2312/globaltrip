using NBT.Core.Domain.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.ApplicationServices.System
{
    public interface ISettingsService: IService<Settings>
    {
        IEnumerable<Settings> GetAll();
        void InsertFromSystem();
    }
}
