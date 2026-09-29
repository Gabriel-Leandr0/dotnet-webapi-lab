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
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonServices _personService;

        public PersonController(ILogger<PersonController> logger,
                                IPersonServices personService)
        {
            _logger = logger;   
            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetAllPersons()
        {
            _logger.LogInformation("Retrieving all persons.");
            var persons = _personService.FindAll();
            _logger.LogInformation("All persons retrieved.");
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonById(int id)
        {
            _logger.LogInformation("Retrieving person by ID: {Id}", id);
            var person = _personService.FindById(id);
            if (person == null)
            {
                _logger.LogWarning("Person with ID: {Id} not found.", id);
                return NotFound();
            }
            _logger.LogInformation("Person with ID: {Id} retrieved.", id);
            return Ok(person);
        }

        [HttpPost]
        public IActionResult CreatePerson([FromBody] Models.Person person)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for creating person.");
                return BadRequest(ModelState);
            }

            _logger.LogInformation("Creating new person.");
            var createdPerson = _personService.CreatePerson(person);
            _logger.LogInformation("Person created with ID: {Id}", createdPerson.Id);
            return CreatedAtAction(nameof(GetPersonById), new { id = createdPerson.Id }, createdPerson);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, [FromBody] Models.Person person)
        {
            _logger.LogInformation("Attempting to update person with ID: {Id}", id);
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for updating person with ID: {Id}", id);
                return BadRequest(ModelState);
            }

            _logger.LogInformation("Updating person with ID: {Id}", id);

            try
            {
                _logger.LogInformation("Updating person with ID: {Id}", id);
                var updatedPerson = _personService.UpdatePerson(id, person);
                _logger.LogInformation("Person with ID: {Id} updated.", id);
                return Ok(updatedPerson);
            }
            catch (InvalidOperationException)
            {
                _logger.LogWarning("Person with ID: {Id} not found.", id);
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            _logger.LogInformation("Deleting person with ID: {Id}", id);
            var deleted = _personService.DeletePerson(id);
            if (!deleted)
            {
                _logger.LogWarning("Person with ID: {Id} not found.", id);
                return NotFound();
            }
            _logger.LogInformation("Person with ID: {Id} deleted.", id);
            return NoContent();
        }
        
    }
}