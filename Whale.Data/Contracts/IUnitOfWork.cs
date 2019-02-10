using System;
using System.Data.Entity;

namespace Whale.Data
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; set; }
        void Commit();
    }
}
