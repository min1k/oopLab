﻿
namespace labka
{
    class Program
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
            IGameService game = new GameService(gameRepository);

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


            //Виведення списку гравців
            Console.WriteLine("  Список гравців:");
            var players = gameAccountService.GetAllAccounts();
            foreach (var player in players)
            {
                Console.WriteLine($"ID: {player.Id}, Username: {player.UserName}, Rating: {player.CurentRating}");
            }
            //читання окремого аккаунту
            Console.WriteLine("\n  Акаунт з ID = 1");
            gameAccountService.ReadAccount(1);

            // видалення акаунту
            gameAccountService.DeleteAccount(3);
            Console.WriteLine("\n  Список гравців після видалення гравця з ID3:");
            foreach (var player in players)
            {
                Console.WriteLine($"ID: {player.Id}, Username: {player.UserName}, Rating: {player.CurentRating}");
            }

            //проводжу гру 
            Game game1 = new StandartGame("Player1", "Player2","Win", "StandartGame");
            Game game2 = new WithoutRatingGame("Player2", "Player1","Win", "WithoutRatingGame");
            Game game3 = new StandartGame("Player2", "Player1","Win", "StandartGame");
            Game game4 = new WithoutRatingGame("Player1", "Player2","Win", "WithoutRatingGame");

            //записую гру в DbContext 
            game.CreateGame(game1);
            game.CreateGame(game2);
            game.CreateGame(game3);
            game.CreateGame(game4);

            //читання окремої гри
            Console.WriteLine("\n  Читання гри з ID 1001:");
            game.ReadGame(1001);

            //Всі ігри деякого гравця
            Console.WriteLine("\n Всі ігри гравця Player2:");
            game.GetAllGames("Player2");
        }
    }
}





