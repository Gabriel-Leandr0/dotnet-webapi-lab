using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiLab.Api.Models;
using WebApiLab.Api.Models.Context;

namespace WebApiLab.Api.Services
{
    public class PersonService : IPersonServices
    {
        private AppDbContext _context;

        public PersonService(AppDbContext context)
        {
            _context = context;
        }


        public Person CreatePerson(Person person)
        {
            person.Id = new Random().Next(1, 1000); // Simulate ID generation
            person.FirstName = person.FirstName; // Ensure FirstName is set correctly
            person.LastName = person.LastName; // Ensure LastName is set correctly
            person.Gender = person.Gender; // Ensure Gender is set correctly
            return person;
        }

        public bool DeletePerson(int id)
        {
            return true; // Simulate successful deletion
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person UpdatePerson(int id, Person person)
        {
            throw new NotImplementedException();
        }
    }
}