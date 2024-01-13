using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labka
{

    public interface IGameService
    {
        List<Game> GetAllGames();
        Game GetGameById(int gameId);
        void CreateGame(Game game);
        void DeleteGame(int gameId);
        void ReadGame(int accountId);
    }

    public class GameService : IGameService
    {
        
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }


        public List<Game> GetAllGames()
        {
            return _gameRepository.RGetAllGames();
        }

        public Game GetGameById(int gameId)
        {
            return _gameRepository.RReadGameById(gameId);
        }

        public void ReadGame(int accountId)
        {
            _gameRepository.RReadGame(accountId);
        }

        public void CreateGame(Game game)
        {
            _gameRepository.RCreateGame(game);
        }

        public void DeleteGame(int gameId)
        {
            _gameRepository.RDeleteGame(gameId);
        }
    }
}
