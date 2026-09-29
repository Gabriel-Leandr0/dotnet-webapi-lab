using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiLab.Api.Services;

namespace WebApiLab.Api.Controllers
{
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonServices _personService;

        public PersonController(IPersonServices personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetAllPersons()
        {
            var persons = _personService.FindAll();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonById(int id)
        {
            var person = _personService.FindById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult CreatePerson([FromBody] Models.Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdPerson = _personService.CreatePerson(person);
            return CreatedAtAction(nameof(GetPersonById), new { id = createdPerson.Id }, createdPerson);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, [FromBody] Models.Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedPerson = _personService.UpdatePerson(id, person);
                return Ok(updatedPerson);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            var deleted = _personService.DeletePerson(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
        
    }
}