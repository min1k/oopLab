
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
        public int Id { get; internal set; }

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
}
