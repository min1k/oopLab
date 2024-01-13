using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace labka
{
    public class WithoutRatingGame : Game
    {
        public WithoutRatingGame(string opponentName, string result, string gameType) : base(opponentName, 0, result, gameType) { }

        public override int CalculateRating()
        {
            return Rating;
        }
    }
}
