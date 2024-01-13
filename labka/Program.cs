
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


            // Ініціалізація 
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
}







