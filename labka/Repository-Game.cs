using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labka
{
    public interface IGameRepository
    {
        List<Game> GetAllGames();
        Game GetGameById(int gameId);
        void CreateGame(Game game);
        void UpdateGame(Game game);
        void DeleteGame(int gameId);
    }


    public class GameRepository : IGameRepository
    {
        private readonly DbContext _dbContext;

        public GameRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Game> GetAllGames()
        {
            return _dbContext.Games;
        }

        public Game GetGameById(int gameId)
        {
            return _dbContext.Games.FirstOrDefault(g => g.Id == gameId);
        }

        public void CreateGame(Game game)
        {
            _dbContext.Games.Add(game);
        }

        public void UpdateGame(Game game)
        {

        }

        public void DeleteGame(int gameId)
        {
            var game = _dbContext.Games.FirstOrDefault(g => g.Id == gameId);
            if (game != null)
            {
                _dbContext.Games.Remove(game);
            }
        }
    }
}
