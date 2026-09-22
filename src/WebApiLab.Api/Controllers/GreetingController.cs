using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiLab.Api.Model;

namespace WebApiLab.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController : Controller
    {

        private static long _counter = 0;
        private static readonly string _template = "Hello, {0}!";


        [HttpGet]
        public Greeting Get([FromQuery] string name = "World")
        {
            var id = Interlocked.Increment(ref _counter);
            var content = string.Format(_template, name);
            return new Greeting(id, string.Format(_template, name));
        }
    }
}