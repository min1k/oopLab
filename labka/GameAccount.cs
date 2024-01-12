
using labka;
using System.Security.AccessControl;

namespace labka
{
    public abstract class GameAccount
    {
        public string UserName { get; set; }
        public int CurentRating { get; set; }
        public int GamesCount { get; set; }


        public GameAccount(string userName, int curentRating, int gamesCount)
        {
            UserName = userName;
            CurentRating = curentRating;
            GamesCount = gamesCount;
        }

        public string GameType { get; set;}
        public int Id { get; internal set; }

        public abstract void WinGame(string gameType, GameAccount opponent, int rating);

        public abstract void LoseGame(string gameType, GameAccount opponent, int rating);


    }

}
