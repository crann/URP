using System;

namespace URP.DataAccess.Scaffolding.Implementation
{
    public class Disposable : IDisposable
    {
        private bool isDisposed;

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="Disposable"/> is reclaimed by garbage collection.
        /// </summary>
        ~Disposable()
        {
            Dispose(false);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing">
        /// <c>true</c> to release both managed and unmanaged resources; 
        /// <c>false</c> to release only unmanaged resources.
        /// </param>
        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        /// <summary>
        /// Disposes the core.
        /// </summary>
        protected virtual void DisposeCore() { }
    }   
}