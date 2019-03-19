using System;

namespace Backend.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
