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
            _context.Persons.Add(person);
            _context.SaveChanges();
            return person;
        }

        public bool DeletePerson(int id)
        {
            var person = FindById(id);
            if (person == null) return false;

            _context.Persons.Remove(person);
            _context.SaveChanges();
            return true;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person? FindById(int id)
        {
            return _context.Persons.FirstOrDefault(p => p.Id == id);
        }

        public Person UpdatePerson(int id, Person person)
        {
            var existingPerson = FindById(id);
            if (existingPerson == null) throw new InvalidOperationException("Person not found");

            existingPerson.FirstName = person.FirstName;
            existingPerson.LastName = person.LastName;
            existingPerson.Gender = person.Gender;

            _context.SaveChanges();
            return existingPerson;
        }
    }
}