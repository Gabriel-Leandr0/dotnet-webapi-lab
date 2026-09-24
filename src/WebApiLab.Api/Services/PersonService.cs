using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiLab.Api.Model;

namespace WebApiLab.Api.Services
{
    public class PersonService : IPersonServices
    {
        public Person CreatePerson(Person person)
        {
            person.Id = new Random().Next(1, 1000); // Simulate ID generation
            person.FirstName = person.FirstName; // Ensure FirstName is set correctly
            person.LastName = person.LastName; // Ensure LastName is set correctly
            person.DateOfBirth = person.DateOfBirth; // Ensure DateOfBirth is set correctly
            person.Gender = person.Gender; // Ensure Gender is set correctly

            return person;
        }

        public bool DeletePerson(int id)
        {
            return true; // Simulate successful deletion
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _persons;
        }

        public Person GetPerson(int id)
        {
            return _persons.FirstOrDefault(p => p.Id == id)
        ?? throw new KeyNotFoundException($"Person with id {id} was not found.");
        }

        public Person UpdatePerson(int id, Person person)
        {
            throw new NotImplementedException();
        }


        private List<Person> _persons = new List<Person>
        {
            new Person { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateOnly(1990, 1, 1), Gender = "Male" },
            new Person { Id = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1995, 5, 15), Gender = "Female" }
        };
    }
}