using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiLab.Api.Model;

namespace WebApiLab.Api.Services
{
    public interface IPersonServices
    {
        Person CreatePerson(Person person);
        Person GetPerson(int id);
        IEnumerable<Person> GetAllPersons();
        Person UpdatePerson(int id, Person person);
        bool DeletePerson(int id);
    }
}