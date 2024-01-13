using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labka
{
    public class PlayerStatisticsTask
    {
        private readonly IGameAccountService _gameAccountService;

        public PlayerStatisticsTask(IGameAccountService gameAccountService)
        {
            _gameAccountService = gameAccountService;
        }

        public void DisplayPlayerInfo()
        {
            Console.Write("Введіть ідентифікатор гравця: ");
            if (!int.TryParse(Console.ReadLine(), out int playerId))
            {
                Console.WriteLine("Некоректний формат ідентифікатора гравця. Введіть ціле число.");
                return;
            }

            // метод ReadAccount з ідентифікатором гравця
            _gameAccountService.ReadAccount(playerId);
        }
    }
}
