using NBT.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Datas.Factories
{
    public class DbFactory : DisposableObject, IDbFactory
    {
        private MasterDBContext dbContext;
        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }

        public MasterDBContext Init()
        {
            return dbContext ?? (dbContext = new MasterDBContext());
        }
    }
}
