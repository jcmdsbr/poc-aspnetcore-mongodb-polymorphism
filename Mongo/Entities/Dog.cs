using System;

namespace Mongo.Entities
{
    public class Dog : Animal
    {
        public Dog(double weight, double height)
        {
            Id = Guid.NewGuid();
            Weight  = weight;
            Height = height;
        }   
    }
}