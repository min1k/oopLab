
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

        public void Execute(string userName, int currentRating, int gamesCount, string accountType)
        {
            // Логіка додавання нового гравця з вказаними параметрами
            // Використовуйте _gameAccountService для створення гравця
            // та додавання його в базу даних
        }
    }

    public class PlayerStatisticsTask
    {
        private readonly IGameAccountService _gameAccountService;

        public PlayerStatisticsTask(IGameAccountService gameAccountService)
        {
            _gameAccountService = gameAccountService;
        }

        public void Execute(int playerId)
        {
            // Логіка виведення статистики конкретного гравця за допомогою playerId
            // Використовуйте _gameAccountService та _gameService за потреби
        }
    }

    public class PlayGameTask
    {
        private readonly IGameService _gameService;

        public PlayGameTask(IGameService gameService)
        {
            _gameService = gameService;
        }

        public void Execute(string playerName, string opponentName, string result, string gameType)
        {
            // Логіка гри між гравцями з вказаними параметрами
            // Використовуйте _gameService для створення гри
            // та зберігання результатів гри в базі даних
        }
    }
}







