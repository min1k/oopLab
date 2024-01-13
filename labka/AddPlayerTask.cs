using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labka
{
    public class AddPlayerTask
    {
        private readonly IGameAccountService _gameAccountService;

        public AddPlayerTask(IGameAccountService gameAccountService)
        {
            _gameAccountService = gameAccountService;
        }

        public void Execute()
        {
            Console.WriteLine("Додавання нового гравця:");

            Console.Write("Ім'я гравця: ");
            string userName = Console.ReadLine();

            Console.Write("Рейтинг гравця: ");
            if (!int.TryParse(Console.ReadLine(), out int currentRating))
            {
                Console.WriteLine("Некоректний формат рейтингу. Введіть ціле число.");
                return;
            }

            Console.Write("Кількість зіграних партій: ");
            if (!int.TryParse(Console.ReadLine(), out int gamesCount))
            {
                Console.WriteLine("Некоректний формат кількості партій. Введіть ціле число.");
                return;
            }

            string accountType;
            do
            {
                Console.Write("Тип акаунту (StandartAccount або BonusAccount): ");
                accountType = Console.ReadLine();
            } while (accountType != "StandartAccount" && accountType != "BonusAccount");

            if (accountType == "StandartAccount")
            {
                _gameAccountService.CreateAccount(new StandartAccount(userName, currentRating, gamesCount));
            }
            else if (accountType == "BonusAccount")
            {
                _gameAccountService.CreateAccount(new BonusAccount(userName, currentRating, gamesCount));
            }

            Console.WriteLine($"Гравець {userName} успішно доданий до бази даних.");
        }
    }
}
