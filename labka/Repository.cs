using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labka
{
    public interface IGameAccountRepository
    {
        List<GameAccount> GetAllAccounts();
        GameAccount GetAccountById(int accountId);
        void CreateAccount(GameAccount account);
        void UpdateAccount(GameAccount account);
        void DeleteAccount(int accountId);
    }
    public interface IGameRepository
    {
        List<Game> GetAllGames();
        Game GetGameById(int gameId);
        void CreateGame(Game game);
        void UpdateGame(Game game);
        void DeleteGame(int gameId);
    }

    public class GameAccountRepository : IGameAccountRepository
    {
        private readonly GameDbContext _dbContext;

        public GameAccountRepository(GameDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<GameAccount> GetAllAccounts()
        {
            return _dbContext.GameAccounts;
        }

        public GameAccount GetAccountById(int accountId)
        {
            return _dbContext.GameAccounts.FirstOrDefault(a => a.Id == accountId);
        }

        public void CreateAccount(GameAccount account)
        {
            _dbContext.GameAccounts.Add(account);
        }

        public void UpdateAccount(GameAccount account)
        {
            // Implement update logic if needed
        }

        public void DeleteAccount(int accountId)
        {
            var account = _dbContext.GameAccounts.FirstOrDefault(a => a.Id == accountId);
            if (account != null)
            {
                _dbContext.GameAccounts.Remove(account);
            }
        }
    }


    public class GameRepository : IGameRepository
    {
        private readonly GameDbContext _dbContext;

        public GameRepository(GameDbContext dbContext)
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
            // Implement update logic if needed
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
