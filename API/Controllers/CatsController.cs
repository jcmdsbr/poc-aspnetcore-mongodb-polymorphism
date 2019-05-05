using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mongo.Contracts;
using Mongo.Entities;
//using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CatsController : Controller 
    {
        private readonly IAnimalRepository<Cat> _repository;
        public CatsController(IAnimalRepository<Cat> repository) {  _repository =  repository; }

        [HttpGet]
        public async Task<IEnumerable<Cat>> Gets()
        {
            return await _repository.FindAll();
        }

        // GET api/Cats/5
        [HttpGet("{id}")]
        public async Task<Cat> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        // POST api/Cats
        [HttpPost("")]
        public async Task<IActionResult> Post(Cat cat) 
        { 
            var response =await _repository.Add(cat);

            return StatusCode(201, response);
        }

        // PUT api/Cats/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, Cat cat) 
        {
             cat.Id = id;
             await _repository.Update(cat);
        }

        // DELETE api/Cats/5
        [HttpDelete("{id}")]
        public async Task DeleteById(Guid id) 
        { 
            await _repository.Delete(id);
        }
}
}