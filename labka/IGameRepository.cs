using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace labka
{
    public interface IGameRepository
    {
        List<Game> RGetAllGames();
        Game RReadGameById(int gameId);
        void RCreateGame(Game game);
        void RUpdateGame(Game game);
        void RDeleteGame(int gameId);
    }


    public class GameRepository : IGameRepository
    {
        private readonly DbContext _dbContext;
        private static int GameId = 1000;

        public GameRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Game> RGetAllGames()
        {
            return _dbContext.Games;
        }

        public Game RReadGameById(int gameId)
        {
            return _dbContext.Games.FirstOrDefault(g => g.Id == gameId);
        }

        public void RCreateGame(Game game)
        {
            game.Id = ++GameId;
            _dbContext.Games.Add(game);
        }

        public void RDeleteGame(int gameId)
        {
            var game = _dbContext.Games.FirstOrDefault(g => g.Id == gameId);
            if (game != null)
            {
                _dbContext.Games.Remove(game);
            }
        }

        public void RUpdateGame(Game game)
        {

        }
    }
}
