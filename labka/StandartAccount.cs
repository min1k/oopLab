using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labka
{
    public class StandartAccount : GameAccount
    {
        public StandartAccount(string userName, int curentRating, int gamesCount)
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
                gameWin = new StandartGame(opponent.UserName, rating, "Стандартна гра. Поразка:(!", gameType);
                gameLose = new StandartGame(UserName, rating, "Стандартна гра. Перемога!", gameType);

            }
            else
            {
                gameWin = new WithoutRatingGame(opponent.UserName, rating, "Стандартна гра. Поразка:(!", gameType);
                gameLose = new WithoutRatingGame(UserName, rating, "Стандартна гра. Перемога!", gameType);
            }

        }
    }
}
