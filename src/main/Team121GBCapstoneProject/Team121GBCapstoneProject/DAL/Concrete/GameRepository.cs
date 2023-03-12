﻿using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using System.Linq.Expressions;
using Team121GBCapstoneProject.DAL.Abstract;
using Team121GBCapstoneProject.Models;

namespace Team121GBCapstoneProject.DAL.Concrete
{
    public class GameRepository : IGameRepository
    {
        private DbSet<Game> _game;
        public GameRepository(GPDbContext context)
        {
            _game = context.Games;
        }

        public Game AddOrUpdate(Game entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Game entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Game FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Game> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Game> GetAll(params Expression<Func<Game, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public List<Game> GetGamesByTitle(string title)
        {
            var gamesToReturn = _game.Where(g => g.Title.Contains(title)).Take(10).ToList();
            return gamesToReturn;
        }

        public List<Game> GetTrendingGames(int numberOfGames)
        {
            var gamesReturn = _game.OrderByDescending(g => g.AverageRating).Take(numberOfGames).ToList();
            return gamesReturn;
        }


    }
}
