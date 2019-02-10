using System;
using System.Data.Entity;

namespace Whale.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; set; }

        public void Commit()
        {
            Context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
