using System;
using System.Linq;

namespace Backend.Interfaces
{
    public interface IRepository<TEntity> : IUnitOfWork, IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
    }
}
