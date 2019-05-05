using Mongo.Entities;

namespace Mongo.Contracts
{
    public interface IAnimalRepository<T> : IBaseRepository<T> where  T : Animal
    {
         
    }
}