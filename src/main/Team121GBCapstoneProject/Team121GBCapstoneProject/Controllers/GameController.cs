﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Team121GBCapstoneProject.Services;
using Team121GBCapstoneProject.Models;
using Team121GBCapstoneProject.Services.Abstract;

namespace Team121GBCapstoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IIgdbService _igdbService;
        private string _clientId;
        private string _bearerToken;

        public GameController(IIgdbService igdbService)
        {
            _igdbService = igdbService;
        }

        //[HttpPost]
        public ActionResult<IEnumerable<IgdbGame>> GameSearch()
        {
            // TODO: Move these somewhere else
            _bearerToken = "llrnvo5vfowcyr0ggecl445q5dunyl";
            _clientId = "8ah5b0s8sx19uadsx3b5m4bfekrgla";
            // Set Credentials
            _igdbService.SetCredentials(_clientId, _bearerToken);

            // User temp string for testing with a manual search
            var temp = "";

            return Ok(_igdbService.SearchGames(temp));
        }


    }
}