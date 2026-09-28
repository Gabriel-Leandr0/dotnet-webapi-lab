using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiLab.Api.Models;

namespace WebApiLab.Api.Services
{
    public interface IPersonServices
    {
        Person CreatePerson(Person person);
        bool DeletePerson(int id);
        List<Person> FindAll();
        Person UpdatePerson(int id, Person person);
    }
}