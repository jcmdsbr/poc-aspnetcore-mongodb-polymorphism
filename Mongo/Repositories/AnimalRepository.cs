using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Mongo.Contracts;
using Mongo.Entities;
using Mongo.Repositores;
using MongoDB.Driver;

namespace Mongo.Repositories
{
    public class AnimalRepository<T> : IAnimalRepository<T> where T : Animal
    {
        private readonly IMongoCollection<T> _collection;
        public AnimalRepository(IMongoContext context, IConfiguration configuration)
        {
            var animalsCollection = context.GetCollection<Animal>(
                configuration.GetSection("MongoSettings")
                             .GetSection("CollectionName").Value);

            _collection = animalsCollection.OfType<T>();
        }
        public async Task<T> Add(T entity) 
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task Update (T entity) 
        {
            await _collection.ReplaceOneAsync(x=>x.Id == entity.Id, entity);
        }

        public async Task Delete (Guid id) 
        {
            await _collection.DeleteOneAsync(x=>x.Id == id);
        }

        public async virtual Task<T> GetById(Guid id) 
        {
            return (await _collection.FindAsync(x=> x.Id == id)).SingleOrDefault();
        }

        public async virtual Task<IEnumerable<T>> FindAll() 
        {
            return (await _collection.FindAsync(_=> true)).ToList();
        }
    }
}