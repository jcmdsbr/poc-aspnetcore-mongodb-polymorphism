using System;

namespace Mongo.Contracts
{
    public interface IEntity
    {
         Guid Id { get; }
    }
}