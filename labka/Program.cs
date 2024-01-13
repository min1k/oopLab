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
            Console.WriteLine("Список гравців:");
            var players = gameAccountService.GetAllAccounts();
            foreach (var player in players)
            {
                Console.WriteLine($"ID: {player.Id}, Username: {player.UserName}, Rating: {player.CurentRating}");
            }
            //читання окремого аккаунту
            gameAccountService.ReadAccount(1);

            // видалення акаунту
            gameAccountService.DeleteAccount(3);
            Console.WriteLine("\nСписок гравців після видалення гравця з ID3:");
            foreach (var player in players)
            {
                Console.WriteLine($"ID: {player.Id}, Username: {player.UserName}, Rating: {player.CurentRating}");
            }

            //проводжу гру 
            Game game1 = new StandartGame( "Player2",  20, "Win", "StandartGame");
            Game game2 = new WithoutRatingGame("Player2", 0, "Win", "WithoutRatingGame");
            Game game3 = new StandartGame( "Player1", 20, "Win", "StandartGame");
            Game game4 = new WithoutRatingGame("Player2", 0, "Win", "WithoutRatingGame");

            //записую гру в DbContext 
            game.CreateGame(game1);
            game.CreateGame(game2);

            // Вивід результату всіх ігор 
            Console.WriteLine("\nРезультати ігор:");
            var allGames = game.GetAllGames();
            foreach (var currentGame in allGames)
            {
                Console.WriteLine($"Game ID: {currentGame.Id},User:------,  Opponent: {currentGame.OpponentName}, Result: {currentGame.Result}, Rating: {currentGame.Rating}, GameType: {currentGame.GameType}");
            }

            game.GetGameById(1001);


            //IGameRepository gameRepository = new GameRepository(dbContext);

            //    // Створення репозиторій гравців і ігор
            //    IGameAccountRepository accountRepository = new GameAccountRepository(dbContext);
            //    IGameRepository gameRepository = new GameRepository(dbContext);

            //    // Створення сервіс гри, який використовує створені репозиторії для доступу до даних.
            //    Service gameService = new GameService(accountRepository, gameRepository);

            //    GameAccount player1 = new StandartAccount("Player1", 1000, 0);
            //    GameAccount player2 = new BonusAccount("Player2", 1200, 0);
            //    gameService.CreateAccount(player1);
            //    gameService.CreateAccount(player2);

            //    Game game1 = new StandartGame("Player1", 10, "Win", "StandartGame");
            //    Game game2 = new WithoutRatingGame("Player2", 0, "Win", "WithoutRatingGame");
            //    gameService.CreateGame(game1);
            //    gameService.CreateGame(game2);


            //    //Вивід результату всіх ігор 
            //    Console.WriteLine("\nРезультати ігор:");
            //    var games = gameService.GetAllGames();
            //    foreach (var game in games)
            //    {
            //        Console.WriteLine($"Game ID: {game.Id}, Opponent: {game.OpponentName}, Result: {game.Result}, Rating: {game.Rating}, GameType: {game.GameType}");
            //    }

            //    // Виведення списку гравців
            //    Console.WriteLine("Список гравців:");
            //    var players = gameService.GetAllAccounts();
            //    foreach (var player in players)
            //    {
            //        Console.WriteLine($"ID: {player.Id}, Username: {player.UserName}, Rating: {player.CurentRating}");
            //    }
        }
    }
}





