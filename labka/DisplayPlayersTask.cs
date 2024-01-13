using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labka
{
    public class DisplayPlayersTask
    {
        private readonly IGameAccountService _gameAccountService;

        public DisplayPlayersTask(IGameAccountService gameAccountService)
        {
            _gameAccountService = gameAccountService;
        }

        public void Execute()
        {
            var players = _gameAccountService.GetAllAccounts();
            Console.WriteLine("  Список гравців:");
            foreach (var player in players)
            {
                Console.WriteLine($"ID: {player.Id}, Username: {player.UserName}, Rating: {player.CurentRating}");
            }
        }
    }
}
