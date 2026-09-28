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
    }
}