using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labka
{
    public interface IGameService
    {
        List<GameAccount> GetAllAccounts();
        GameAccount GetAccountById(int accountId);
        void CreateAccount(GameAccount account);
        void UpdateAccount(GameAccount account);
        void DeleteAccount(int accountId);

        List<Game> GetAllGames();
        Game GetGameById(int gameId);
        void CreateGame(Game game);
        void UpdateGame(Game game);
        void DeleteGame(int gameId);
    }


    public class GameService : IGameService
    {
        private readonly IGameAccountRepository _accountRepository;
        private readonly IGameRepository _gameRepository;

        public GameService(IGameAccountRepository accountRepository, IGameRepository gameRepository)
        {
            _accountRepository = accountRepository;
            _gameRepository = gameRepository;
        }

        public List<GameAccount> GetAllAccounts()
        {
            return _accountRepository.GetAllAccounts();
        }

        public GameAccount GetAccountById(int accountId)
        {
            return _accountRepository.GetAccountById(accountId);
        }

        public void CreateAccount(GameAccount account)
        {
            _accountRepository.CreateAccount(account);
        }

        public void UpdateAccount(GameAccount account)
        {
            _accountRepository.UpdateAccount(account);
        }

        public void DeleteAccount(int accountId)
        {
            _accountRepository.DeleteAccount(accountId);
        }

        public List<Game> GetAllGames()
        {
            return _gameRepository.GetAllGames();
        }

        public Game GetGameById(int gameId)
        {
            return _gameRepository.GetGameById(gameId);
        }

        public void CreateGame(Game game)
        {
            _gameRepository.CreateGame(game);
        }

        public void UpdateGame(Game game)
        {
            _gameRepository.UpdateGame(game);
        }

        public void DeleteGame(int gameId)
        {
            _gameRepository.DeleteGame(gameId);
        }
    }
}
