
namespace labka
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Імітація роботи з базою даних
            DbContext dbContext = new DbContext();

            // Створюю репозиторій для акаунтів
            IGameAccountRepository gameAccountRepository = new GameAccountRepository(dbContext);
            IGameAccountService gameAccountService = new GameAccountService(gameAccountRepository);

            // Створюю репозиторій для ігор
            IGameRepository gameRepository = new GameRepository(dbContext);
            IGameService gameService = new GameService(gameRepository);

            //створюю гравців 
            GameAccount player1 = new StandartAccount("Player1", 1000, 6);
            GameAccount player2 = new BonusAccount("Player2", 140, 3);
            GameAccount player3 = new BonusAccount("Player3", 1200, 6);
            GameAccount player4 = new BonusAccount("Player4", 150, 3);

            //зберігання гравців в DbContext
            gameAccountService.CreateAccount(player1);
            gameAccountService.CreateAccount(player2);
            gameAccountService.CreateAccount(player3);
            gameAccountService.CreateAccount(player4);


            // Ініціалізація всіх необхідних сервісів та завдань
        var commandProcessor = new CommandProcessor(
            new DisplayPlayersTask(gameAccountService),
            new AddPlayerTask(gameAccountService),
            new PlayerStatisticsTask(gameAccountService),
            new PlayGameTask(gameService)
        );


            while (true)
            {
                Console.Write("\nВведіть команду(1-4): ");
                Console.Write("\n 1 - переглянути гравців \n 2 - додати гравця\n 3 - переглянути статистику \n 4 - зіграти гру\n 5 - вийти \n");
                string command = Console.ReadLine();

                if (command.ToLower() == "5")
                {
                    break;
                }

                commandProcessor.ProcessCommand(command);
            }
        }
    }


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







