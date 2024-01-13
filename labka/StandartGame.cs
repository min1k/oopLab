using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labka
{
    public class StandartGame : Game
    {
        public StandartGame(string playerName, string opponentName, string result, string gameType) : base(playerName, opponentName, 10, result, gameType) // Рейтинг для стандартної гри
        {
        }
        public override int CalculateRating()
        {
            return Rating;
        }
    }
}
