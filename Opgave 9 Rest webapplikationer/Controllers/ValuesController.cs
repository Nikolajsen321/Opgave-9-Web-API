using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Opgave_9_Rest_webapplikationer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static List<Person> Persons { get; set; } =
            new List<Person>() { new Person(1, "Benjamin", 26), new Person(2, "Niels", 26) };

        [HttpGet]
        [Route("GetPersoner")]
        public List<Person> GetPersoner()
        {

            return Persons;
        }
        
        [HttpGet]
        [Route("GetPerson")]
        public Person GetPerson(int id)
        {

            return Persons.Where(x => x.Id == id).First();
        }
        [HttpPost]

        public Person addtPerson(Person person)
        {
            Persons.Add(person);
            Console.WriteLine("Added Person " + person.Name);

            return person;

        }
    }
}
