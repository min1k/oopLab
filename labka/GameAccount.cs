
using labka;
using System.Security.AccessControl;

namespace labka
{
    public class GameAccount
    {
        public string UserName { get; set; }
        public int CurentRaiting { get; set; }
        public int GamesCount { get; set; }
        public List<Game> GameHistory { get; } = new List<Game>();


        public GameAccount(string userName, int curentRaiting, int gamesCount)
        {
            UserName = userName;
            CurentRaiting = curentRaiting;
            GamesCount = gamesCount;
        }

        public void WinGame(GameAccount opponent, int raiting)
        {
            Console.WriteLine($"{UserName} переміг челіка з нiкнеймом {opponent.UserName}. Йому нараховуються: {raiting} рейтингу\n");
            CurentRaiting += raiting;
            GamesCount++;

            Game gameWin = new Game(opponent.UserName, raiting, "Перемога!");
            GameHistory.Add(gameWin);

            Game gameLoss = new Game(UserName, raiting, "Поразка:(");
            opponent.GameHistory.Add(gameLoss); // Додавання запису програвця в історію переможця
        }




        public void LoseGame(GameAccount opponent, int raiting)
        {
            Console.WriteLine($"{UserName} отримав поразку в битві з {opponent.UserName}, він втрачає:{raiting} рейтингу;");

            if (CurentRaiting - raiting < 1)
            {
                Console.WriteLine("Навчіться грати! Ми не будемо понижати ваш рейтинг нижче 1.\n");
            }
            else
            {
                Console.WriteLine("\n");
                CurentRaiting = CurentRaiting - raiting;
            }
            GamesCount++;

            Game gameLoss = new Game(opponent.UserName, raiting, "Поразка:(");
            GameHistory.Add(gameLoss);

            Game gameWin = new Game(UserName, raiting, "Перемога!");
            opponent.GameHistory.Add(gameWin); // Додавання запису переможця в історію програвця
        }

        public void GetStatus()
        {
            Console.WriteLine($"\nhistory: {UserName}   \t\t\t\t\t|");
            Console.WriteLine("--------------------------------------------------------------");
            foreach (var game in GameHistory)
            {
                Console.WriteLine($"{game.Result} Опонент: {game.OpponentName}     Рейтинг: {game.Rating}     Індекс гри: {game.Index}");
            }
            Console.WriteLine("--------------------------------------------------------------");
        }
    }

}











//аналогічно 
/*
public void LoseGame(GameAccount opponent, int raiting)
{
    Console.WriteLine($"{UserName} отримав поразку в битві з {opponent.UserName}, він втрачає:{raiting} рейтингу;");

    if (CurentRaiting - raiting < 1)
    {
        Console.WriteLine("Навчіться грати! Ми не будемо понижати ваш рейтинг нижче 1.\n");
    }
    else
    {
        Console.WriteLine("\n");
        CurentRaiting = CurentRaiting - raiting;
    }
    GamesCount++;

    Game gameLoss = new Game(opponent.UserName, raiting, "Поразка:(");
    GameHistory.Add(gameLoss);

    Game gameWin = new Game(UserName, raiting, "Перемога!");
    opponent.GameHistory.Add(gameWin); // Додавання запису переможця в історію програвця
}*/





/*
public void WinGame(string gameType, GameAccount opponent, int rating)
{
    GameType = gameType;
    Console.WriteLine($"{UserName} переміг челіка з нiкнеймом {opponent.UserName}. Йому нараховуються: {rating} рейтингу\n");
    CurentRating += rating;
    GamesCount++;

    Game gameWin;

    if (gameType == "StandartGame")
    {
        gameWin = new StandartGame(opponent.UserName, rating, "Стандартна гра. Перемога!", gameType);
    }
    else
    {
        gameWin = new WithoutRatingGame(opponent.UserName, rating, "Гра без рейтингу. Перемога!", gameType);
    }
    GameHistory.Add(gameWin);
    Game gameLose;
    if (gameType == "StandartGame")
    {
        gameLose = new StandartGame(UserName, rating, "Стандартна гра. Поразка!", gameType);
    }
    else
    {
        gameLose = new WithoutRatingGame(UserName, rating, "Гра без рейтингу. Поразка!", gameType);
    }
    opponent.GameHistory.Add(gameLose);
}*/