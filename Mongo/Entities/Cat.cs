using System;

namespace Mongo.Entities
{
    public class Cat : Animal
    {
     public Cat(double weight, double height)
     {
         Id = Guid.NewGuid();
         Weight  = weight;
         Height = height;
     }   
    }
}