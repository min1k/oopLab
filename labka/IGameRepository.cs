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
        void RDeleteGame(int gameId);
        void RReadGame(int accountId);
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

        public void RReadGame(int gameId)
        {
            var game = _dbContext.Games.FirstOrDefault(a => a.Id == gameId);

            if (game != null)
            {
                // Вивести інформацію про гру
                Console.WriteLine($"Game ID: {game.Id}, Opponent: {game.OpponentName}, Result: {game.Result}, Rating: {game.Rating}, GameType: {game.GameType}");
            }
            else
            {
                // Якщо гра не знайдена
                Console.WriteLine($"Гра з ідентифікатором {gameId} не знайдена.");
            }
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
    }
}
