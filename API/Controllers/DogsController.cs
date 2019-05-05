using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mongo.Contracts;
using Mongo.Entities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class DogsController : Controller
    {
        private readonly IAnimalRepository<Dog> _repository;
        public DogsController(IAnimalRepository<Dog> repository) {  _repository =  repository; }

        [HttpGet]
        public async Task<IEnumerable<Dog>> Gets()
        {
            return await _repository.FindAll();
        }

        // GET api/dogs/5
        [HttpGet("{id}")]
        public async Task<Dog> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        // POST api/dogs
        [HttpPost("")]
        public async Task<IActionResult> Post(Dog dog) 
        { 
            var response = await _repository.Add(dog);

            return Created(string.Empty, response);
        }

        // PUT api/dogs/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, Dog dog) 
        {
             dog.Id = id;
             await _repository.Update(dog);
        }

        // DELETE api/dogs/5
        [HttpDelete("{id}")]
        public async Task DeleteById(Guid id) 
        { 
            await _repository.Delete(id); 
        }
    }
}