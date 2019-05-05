using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mongo.Contracts;

namespace Mongo.Contracts
{
    public interface IBaseRepository<T> where T : IEntity
    {
        Task<T> Add(T entity);
        Task Update (T entity);
        Task Delete (Guid id);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> FindAll();
    }
}