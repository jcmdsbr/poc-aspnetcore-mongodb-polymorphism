using System;
using Mongo.Contracts;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Mongo.Entities
{
    public  abstract class Animal : IEntity
    {
        public Guid Id { get;  set; }
        public double Weight { get;  set; }
        public double Height { get;  set; }

    }
}