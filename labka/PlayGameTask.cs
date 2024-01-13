using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labka
{
    public class PlayGameTask
    {
        private readonly IGameService _gameService;

        public PlayGameTask(IGameService gameService)
        {
            _gameService = gameService;
        }

        public void Execute()
        {
            Console.WriteLine("Проведення нової гри:");

            Console.Write("Ім'я першого гравця: ");
            string player1Name = Console.ReadLine();

            Console.Write("Ім'я другого гравця: ");
            string player2Name = Console.ReadLine();

            Console.Write("Тип гри: ");
            string gameType = Console.ReadLine();

            //Game newGame = new Game(player1Name, player2Name, "Win" gameType);
            // _gameService.CreateGame(newGame);
            Console.WriteLine("В мене не вийшло доробити;(");
        }
    }
}
