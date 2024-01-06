
using System.Security.AccessControl;
namespace labka
{

    public class Game
    {
        public string OpponentName { get; private set; }
        public int Rating { get; private set; }
        public int Index { get; private set; }
        public string Result { get; private set; }

        private static int currentIndex = new Random().Next(1, 30000);
        public Game(string opponentName, int rating, string result)
        {
            OpponentName = opponentName;
            Rating = rating;
            Index = GetNextIndex();
            Result = result;
        }

        private int GetNextIndex()
        {
            currentIndex++;
            return currentIndex;
        }
    }
}
