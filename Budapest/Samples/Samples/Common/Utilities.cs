using System;
using System.Collections.Generic;

namespace KadGen.Functional.Samples
{
    // Hack for isolated demo
    public static class Utilities
    {
        public static CTDbContext GetDbContext()
        {
            return default;
        }

        public static string GetConnString()
        {
            return "Hello World";
        }
     }

    public class CTDbContext : IDisposable
    {
        public CTDbContext(string connStrong)
        {

        }

        public IEnumerable<int> Courses { get; set; }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CTDbContext() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
