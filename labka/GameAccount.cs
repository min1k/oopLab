
using labka;
using System.Security.AccessControl;

namespace labka
{
    public abstract class GameAccount
    {
        public string UserName { get; set; }
        public int CurentRating { get; set; }
        public int GamesCount { get; set; }
        public List<Game> GameHistory { get; } = new List<Game>();


        public GameAccount(string userName, int curentRating, int gamesCount)
        {
            UserName = userName;
            CurentRating = curentRating;
            GamesCount = gamesCount;
        }

        public string GameType { get; set;}

        public abstract void WinGame(string gameType, GameAccount opponent, int rating);

        public abstract void LoseGame(string gameType, GameAccount opponent, int rating);

        public void GetStatus()
        {
            Console.WriteLine($"\nhistory: {UserName}");
            Console.WriteLine("--------------------------------------------------------------");
            foreach (var game in GameHistory)
            {
                Console.WriteLine($"{game.Result} Опонент: {game.OpponentName}     Рейтинг: {game.Rating}     Індекс гри: {game.Index}");
            }
            Console.WriteLine("--------------------------------------------------------------");
        }

    }


    public class BonusAccount : GameAccount
    {
        public BonusAccount(string userName, int curentRating, int gamesCount)
            : base(userName, curentRating, gamesCount) { }

        public override void WinGame(string gameType, GameAccount opponent, int rating)
        {
            GameType = gameType;
            Console.WriteLine($"{UserName} переміг челіка з нiкнеймом {opponent.UserName}. Йому нараховуються: {rating} рейтингу\n");
            CurentRating += rating;
            GamesCount++;

            Game gameWin;
            Game gameLose;

            if (gameType == "StandartGame")
            {
                gameWin = new StandartGame(opponent.UserName, rating, "Стандартна гра. Перемога!", gameType);
                gameLose = new StandartGame(UserName, rating, "Стандартна гра. Поразка!", gameType);
            }
            else
            {
                gameWin = new WithoutRatingGame(opponent.UserName, rating, "Гра без рейтингу. Перемога!", gameType);
                gameLose = new WithoutRatingGame(UserName, rating, "Гра без рейтингу. Поразка!", gameType);
            }
            GameHistory.Add(gameWin);
            opponent.GameHistory.Add(gameLose);


            // Перевірка на наявність двох перемог у історії гри
            if (CheckForTwoConsecutiveWins())
            {
                CurentRating += 10; //додатковий рейтинг 
            }
        Console.WriteLine($"За серію перемог для {UserName} нараховується 10 балів.\n");

        }

        public override void LoseGame(string gameType, GameAccount opponent, int rating) {
            GameType = gameType;
            Console.WriteLine($"{UserName} отримав поразку в битві з {opponent.UserName}, він втрачає:{rating} рейтингу;");

            if (CurentRating - rating < 1)
            {
                Console.WriteLine("Навчіться грати! Ми не будемо понижати ваш рейтинг нижче 1.\n");
            }
            else
            {
                Console.WriteLine("\n");
                CurentRating = CurentRating - rating;
            }
            GamesCount++;


            Game gameWin;
            Game gameLose;

            if (gameType == "StandartGame")
            {
                gameWin = new StandartGame(opponent.UserName, rating, "Стандартна гра. Поразка:(!", gameType);
                gameLose = new StandartGame(UserName, rating, "Стандартна гра. Перемога!", gameType);

            }
            else
            {
                gameWin = new WithoutRatingGame(opponent.UserName, rating, "Стандартна гра. Поразка:(!", gameType);
                gameLose = new WithoutRatingGame(UserName, rating, "Стандартна гра. Перемога!", gameType);
            }
            GameHistory.Add(gameWin);
            opponent.GameHistory.Add(gameLose);
        }

        private bool CheckForTwoConsecutiveWins()
        {
            if (GameHistory.Count >= 2)
            {
                // Перевірка на наявність двох перемог підряд
                return GameHistory[GameHistory.Count - 1] is StandartGame winGame1 &&
                       winGame1.Result == "Стандартна гра. Перемога!" &&
                       GameHistory[GameHistory.Count - 2] is StandartGame winGame2 &&
                       winGame2.Result == "Стандартна гра. Перемога!";
                // Тут можна розглянути інші варіанти логіки перевірки
            }
            return false;
        }
    }



    public class StandartAccount : GameAccount
    {
        public StandartAccount(string userName, int curentRating, int gamesCount)
            : base(userName, curentRating, gamesCount){}
        public override void WinGame(string gameType, GameAccount opponent, int rating){
            GameType = gameType;
            Console.WriteLine($"{UserName} переміг челіка з нiкнеймом {opponent.UserName}. Йому нараховуються: {rating} рейтингу\n");
            CurentRating += rating;
            GamesCount++;

            Game gameWin;
            Game gameLose;

            if (gameType == "StandartGame")
            {
                gameWin = new StandartGame(opponent.UserName, rating, "Стандартна гра. Перемога!", gameType);
                gameLose = new StandartGame(UserName, rating, "Стандартна гра. Поразка!", gameType);
            }
            else
            {
                gameWin = new WithoutRatingGame(opponent.UserName, rating, "Гра без рейтингу. Перемога!", gameType);
                gameLose = new WithoutRatingGame(UserName, rating, "Гра без рейтингу. Поразка!", gameType);
            }
            GameHistory.Add(gameWin);
            opponent.GameHistory.Add(gameLose);
            // Тут потрібно вирішити, чи додавати gameLoss до історії для opponent
            // Можливо, це потрібно робити в методі LoseGame опонента
           }
        public override void LoseGame(string gameType, GameAccount opponent, int rating) {

            GameType = gameType;
            Console.WriteLine($"{UserName} отримав поразку в битві з {opponent.UserName}, він втрачає:{rating} рейтингу;");

            if (CurentRating - rating < 1)
            {
                Console.WriteLine("Навчіться грати! Ми не будемо понижати ваш рейтинг нижче 1.\n");
            }
            else
            {
                Console.WriteLine("\n");
                CurentRating = CurentRating - rating;
            }
            GamesCount++;


            Game gameWin;
            Game gameLose;

            if (gameType == "StandartGame")
            {
                gameWin = new StandartGame(opponent.UserName, rating, "Стандартна гра. Поразка:(!", gameType);
                gameLose = new StandartGame(UserName, rating, "Стандартна гра. Перемога!", gameType);

            }
            else
            {
                gameWin = new WithoutRatingGame(opponent.UserName, rating, "Стандартна гра. Поразка:(!", gameType);
                gameLose = new WithoutRatingGame(UserName, rating, "Стандартна гра. Перемога!", gameType);
            }
            GameHistory.Add(gameWin);
            opponent.GameHistory.Add(gameLose);
        }
    }


    public class HalfPointsForLossAccount : GameAccount {
        public HalfPointsForLossAccount(string userName, int curentRating, int gamesCount)
            : base(userName, curentRating, gamesCount)
        {
            // Додаткова ініціалізація для PremiumGameAccount
        }

        public override void WinGame(string gameType, GameAccount opponent, int rating) {
            GameType = gameType;
            Console.WriteLine($"{UserName} переміг челіка з нiкнеймом {opponent.UserName}. Йому нараховуються: {rating} рейтингу\n");
            CurentRating += rating;
            GamesCount++;

            Game gameWin;
            Game gameLose;

            if (gameType == "StandartGame")
            {
                gameWin = new StandartGame(opponent.UserName, rating, "Стандартна гра. Перемога!", gameType);
                gameLose = new StandartGame(UserName, rating, "Стандартна гра. Поразка!", gameType);
            }
            else
            {
                gameWin = new WithoutRatingGame(opponent.UserName, rating, "Гра без рейтингу. Перемога!", gameType);
                gameLose = new WithoutRatingGame(UserName, rating, "Гра без рейтингу. Поразка!", gameType);
            }
            GameHistory.Add(gameWin);
            opponent.GameHistory.Add(gameLose);
            // Тут потрібно вирішити, чи додавати gameLoss до історії для opponent
            // Можливо, це потрібно робити в методі LoseGame опонента
        }

        public override void LoseGame(string gameType, GameAccount opponent, int rating)
        {
            GameType = gameType;
            Console.WriteLine($"{UserName} отримав поразку в битві з {opponent.UserName}, він втрачає:{rating / 2} рейтингу;");

            if (CurentRating - rating / 2 < 1)
            {
                Console.WriteLine("Навчіться грати! Ми не будемо понижати ваш рейтинг нижче 1.\n");
            }
            else
            {
                Console.WriteLine("\n");
                CurentRating = CurentRating - rating / 2;
            }
            GamesCount++;

            Game gameWin;
            Game gameLose;

            if (gameType == "StandartGame")
            {
                gameWin = new StandartGame(opponent.UserName, rating, "Стандартна гра. Поразка:(!", gameType);
                gameLose = new StandartGame(UserName, rating, "Стандартна гра. Перемога!", gameType);
            }
            else
            {
                gameWin = new WithoutRatingGame(opponent.UserName, rating, "Стандартна гра. Поразка:(!", gameType);
                gameLose = new WithoutRatingGame(UserName, rating, "Стандартна гра. Перемога!", gameType);
            }
            GameHistory.Add(gameWin);
            opponent.GameHistory.Add(gameLose);
        }
    }
}
