
using System.Security.AccessControl;
namespace labka
{

    public abstract class Game
    {
        public string PlayerName { get; private set; }
        public string OpponentName { get; private set; }
        public int Rating { get; private set; }
        public int Index { get; private set; }
        public string Result { get; private set; }
        public string GameType { get; private set; }
        public int Id { get; internal set; }


        public Game(string playerName, string opponentName, int rating, string result, string gameType)
        {
            PlayerName = playerName;
            OpponentName = opponentName;
            Result = result;

            Rating = rating;

            GameType = gameType;
        }

        public abstract int CalculateRating();
    }
}
