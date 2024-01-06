
namespace labka
{
    class Program
    {
        static void Main(string[] args)
        {
            // Імітація роботи з базою даних
            GameDbContext dbContext = new GameDbContext();

            // Створення репозиторій гравців, який використовує контекст бази даних.
            IGameAccountRepository accountRepository = new GameAccountRepository(dbContext);
            // Створення репозиторій ігор, який також використовує контекст бази даних.
            IGameRepository gameRepository = new GameRepository(dbContext);

            // Створюємо сервіс гри, який використовує створені репозиторії для доступу до даних.
            IGameService gameService = new GameService(accountRepository, gameRepository);

            // Додайте інші необхідні частини коду згідно з вашим проектом
            GameAccount player1 = new StandartAccount("Player1", 1000, 0);
            GameAccount player2 = new BonusAccount("Player2", 1200, 0);
            gameService.CreateAccount(player1);
            gameService.CreateAccount(player2);

            Game game1 = new StandartGame("Player1", 10, "Win", "StandartGame");
            Game game2 = new WithoutRatingGame("Player2", 0, "Win", "WithoutRatingGame");
            gameService.CreateGame(game1);
            gameService.CreateGame(game2);






            //Вивід результату всіх ігор 
            Console.WriteLine("\nРезультати ігор:");
            var games = gameService.GetAllGames();
            foreach (var game in games)
            {
                Console.WriteLine($"Game ID: {game.Id}, Opponent: {game.OpponentName}, Result: {game.Result}, Rating: {game.Rating}, GameType: {game.GameType}");
            }

            // Виведення списку гравців
            Console.WriteLine("Список гравців:");
            var players = gameService.GetAllAccounts();
            foreach (var player in players)
            {
                Console.WriteLine($"ID: {player.Id}, Username: {player.UserName}, Rating: {player.CurentRating}");
            }
        }
    }


}





