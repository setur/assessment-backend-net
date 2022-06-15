using Contact.Data.Entities;
using Contact.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
            try
            {
                var people = _repository.People.GetPeople();
                return Ok(people);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public  ActionResult<Person> AddPerson([FromBody] Person person)
        {
            try
            {
                if (person is null)
                {
                    return BadRequest("Person object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                _repository.People.AddPerson(person);
                _repository.Save();
                return Ok(person);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public ActionResult<Person> UpdatePerson([FromBody] Person person)
        {
            _repository.People.UpdatePerson(person);
            _repository.Save();
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int id)
        {
            try
            {
                Person person = _repository.People.GetPersonByID(id);
                if (person == null)
                {
                    return NotFound();
                }
                _repository.People.DeletePerson(person);
                _repository.Save();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
