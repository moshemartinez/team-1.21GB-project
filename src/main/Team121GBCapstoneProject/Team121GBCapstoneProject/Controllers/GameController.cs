using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Team121GBCapstoneProject.Areas.Identity.Data;
using Team121GBCapstoneProject.Models;
using Team121GBCapstoneProject.Services.Abstract;
using Team121GBCapstoneProject.DAL.Abstract;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;

namespace Team121GBCapstoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IIgdbService _igdbService;
        private IRepository<Game> _gameRepository;
        private string _clientId;
        private string _bearerToken;

        public GameController(IIgdbService igdbService, IRepository<Game> gameRepository)
        {
            _igdbService = igdbService;
            _gameRepository = gameRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IgdbGame>>> Index(string query)
        {
            // TODO: Move these to UserSecrets before deployment
            _bearerToken = "llrnvo5vfowcyr0ggecl445q5dunyl";
            _clientId = "8ah5b0s8sx19uadsx3b5m4bfekrgla";
            
            // Set Credentials
            _igdbService.SetCredentials(_clientId, _bearerToken);

            var searchResult = await _igdbService.SearchGames(query);

            if (searchResult is null)
            {
                return NotFound();
            }

            return Ok(searchResult);
        }
        [HttpPost("addGame")]
        //public async Task<ActionResult<IgdbGame>> AddGameToList(Game game)
        public async Task<ActionResult<IgdbGame>> AddGameToList()
        {   //need to set it up so we have a user a that is logged in.
            var game = new Game();
            game.Title = "aaaaaaaaa";
            try
            {
                // * check if this game already exists in the database
                bool check = _gameRepository.GetAll()
                                            .Any(g => g.Title == game.Title);
                if(check) //add game to a users list 
                {
                    
                }
                else // add game to db first.
                {
                    await AddGameToDb(game);
                    //now add to users list
                }
                return Ok();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<IgdbGame>>  AddGameToDb(Game game)
        {
            try
            {
                _gameRepository.AddOrUpdate(game);
                return Ok();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return BadRequest(e);
            }
        }
    }
}
