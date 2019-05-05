using System;
using Microsoft.Extensions.Configuration;
using Mongo.Contracts;
using Mongo.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;

namespace Mongo.Repositores
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase _database;
        public MongoContext(IConfiguration configuration, IMongoClient client)
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;
            
            _database = client.GetDatabase(configuration.GetSection("MongoSettings").GetSection("DatabaseName").Value);

            // BsonSerializer.RegisterIdGenerator(typeof(Guid),CombGuidGenerator.Instance);
        }

        public void Dispose()
        {
           GC.SuppressFinalize(this);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }
    }
}