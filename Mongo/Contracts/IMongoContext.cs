using System;
using MongoDB.Driver;

namespace Mongo.Contracts
{
    public interface IMongoContext : IDisposable
    {
         IMongoCollection<T> GetCollection<T>(string name);
    }
}