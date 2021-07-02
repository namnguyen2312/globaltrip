using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Common
{
    public abstract class DisposableObject: IDisposable
    {
        protected bool IsDisposed { get; set; } = false;

        ~DisposableObject()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.IsDisposed && disposing)
            {
                this.DisposeCore();
            }

            this.IsDisposed = true;
        }

        protected abstract void DisposeCore();
    }
}
