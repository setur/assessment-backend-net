using Contact.Data.Entities;
using Contact.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        public PersonController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetPeople()
        {
            var people = _repository.People.GetPeople();
            return Ok(people);
        }

        [HttpPost]
        public  ActionResult<Person> AddPerson([FromBody] Person person)
        {
             _repository.People.AddPerson(person);
            _repository.Save();
            return Ok(person);
        }

        [HttpPut]
        public ActionResult<Person> UpdatePerson([FromBody] Person person)
        {
            _repository.People.UpdatePerson(person);
            _repository.Save();
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDiscount(int id)
        {
            Person person = _repository.People.GetPersonByID(id);
            _repository.People.DeletePerson(person);
            _repository.Save();
            return Ok();
        }
    }
}
