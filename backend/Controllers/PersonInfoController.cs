using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonInfoController : ControllerBase
    {
        private static List<Person> People = new List<Person>
        {
            new Person{ Id = 1, Name = "Sabbir Ahammed", Age = 25 },
            new Person{ Id = 2, Name = "Araf Hossain", Age = 27 },
            new Person{ Id = 3, Name = "Saiful Islam", Age = 26 },
            new Person{ Id = 4, Name = "Shovan Mahmood", Age = 27 },
        };

        public PersonInfoController()
        {

        }

        [HttpGet]
        public List<Person> Get() => People;

        [HttpPost]
        public async Task Post(Person person)
        {
            await Task.Run(() =>
            {
                People.Add(person);
            });
        }
    }
}
