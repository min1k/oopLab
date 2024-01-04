
using System.Security.AccessControl;
//гра де на рейтинг грає лише один гравець. !!!!
namespace labka
{

    public abstract class Game
    {
       public string OpponentName { get; private set; }
        public int Rating { get; private set; }
        public int Index { get; private set; }
        public string Result { get; private set; }
        public string GameType { get; private set; }

        //private static int currentIndex = new Random().Next(1, 30000);
        private static int currentIndex = 100;
        private int GetNextIndex()
        {
            currentIndex++;
            return currentIndex;
        }


        public Game(string opponentName, int rating, string result, string gameType)
        {
            OpponentName = opponentName;
            Result = result;

            Rating = rating;
            Index = GetNextIndex();

            GameType = gameType;
        }

        public abstract int CalculateRating();
    }


    public class StandartGame : Game
    {
        public StandartGame(string opponentName, int raiting, string result, string gameType) : base(opponentName, 10, result, gameType) // Рейтинг для стандартної гри
        {
        }
        public override int CalculateRating()
        {
            return Rating;
        }
    }


    public class WithoutRatingGame : Game
    {
        public WithoutRatingGame(string opponentName, int raiting, string result, string gameType) : base(opponentName, 0, result, gameType) { }

        public override int CalculateRating()
        {
            return Rating;
        }
    }
    //гра де на рейтинг грає лише один гравець.
}
