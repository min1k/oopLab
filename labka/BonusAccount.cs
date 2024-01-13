using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labka
{

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
                gameWin = new StandartGame(UserName, opponent.UserName, "Стандартна гра. Перемога!", gameType);
                gameLose = new StandartGame(opponent.UserName, UserName,  "Стандартна гра. Поразка!", gameType);
            }
            else
            {
                gameWin = new WithoutRatingGame(UserName, opponent.UserName, "Гра без рейтингу. Перемога!", gameType);
                gameLose = new WithoutRatingGame(opponent.UserName, UserName, "Гра без рейтингу. Поразка!", gameType);
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

        public override void LoseGame(string gameType, GameAccount opponent, int rating)
        {
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
                gameWin = new StandartGame(UserName, opponent.UserName,  "Стандартна гра. Поразка:(!", gameType);
                gameLose = new StandartGame(opponent.UserName, UserName,  "Стандартна гра. Перемога!", gameType);

            }
            else
            {
                gameWin = new WithoutRatingGame(UserName, opponent.UserName, "Стандартна гра. Поразка:(!", gameType);
                gameLose = new WithoutRatingGame(opponent.UserName, UserName, "Стандартна гра. Перемога!", gameType);
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
}
