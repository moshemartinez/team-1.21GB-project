using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Team121GBCapstoneProject.Services;
using Team121GBCapstoneProject.Models;
using Team121GBCapstoneProject.Services.Abstract;
using Team121GBCapstoneProject.DAL.Abstract;
using System.Diagnostics;


namespace Team121GBCapstoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
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

        [HttpPost]
        public async Task<ActionResult<IgdbGame>>  AddGame(Game game)
        //public async Task<ActionResult<IgdbGame>>  AddGame()
        {
            game.Title = "Thing";
            game.Description = "Thing Thing";
            game.EsrbratingId = 9;
            game.AverageRating =  9.0;
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
