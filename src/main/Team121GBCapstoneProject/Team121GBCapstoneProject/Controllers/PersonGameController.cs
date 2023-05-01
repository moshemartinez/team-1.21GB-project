using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Team121GBCapstoneProject.Areas.Identity.Data;
using Team121GBCapstoneProject.DAL.Abstract;
using Team121GBCapstoneProject.Models;
using Team121GBCapstoneProjects.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Team121GBCapstoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonGameController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        IRepository<PersonGame> _personGameRepository;

        public PersonGameController(UserManager<ApplicationUser> userManager, IRepository<PersonGame> personGameRepository)
        {
            _userManager = userManager;
            _personGameRepository = personGameRepository;
        }

        // GET: api/<PersonGameController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PersonGameController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Console.WriteLine("Get PersonGame...");
            return "value";
        }

        // POST api/<PersonGameController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PersonGameController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonGameController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Console.WriteLine("Deleting PersonGame...");

            var personGame = _personGameRepository.GetAll().FirstOrDefault(g => g.Id == id);

            if (personGame == null)
            {
                Console.WriteLine("No game found");
            }
            else
            {
                _personGameRepository.Delete(personGame);
            }
        }
    }
}
