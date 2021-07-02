using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.Data
{
    public interface IUnitOfWork: IDisposable
    {
        void SaveChange();
        void BeginTran();
        void CommitTran();
        void RollbackTran();
    }
}
