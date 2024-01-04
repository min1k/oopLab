
namespace labka
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            GameAccount user1 = new BonusAccount("nub", 1, 2);
            GameAccount user2 = new StandartAccount("Pro", 5, 26);

            GameAccount user4 = new HalfPointsForLossAccount("bybka", 1, 2);


            user1.WinGame("StandartGame", user2, 10);
            user1.WinGame("StandartGame", user2, 10);
            user1.WinGame("StandartGame", user2, 10);

            user4.WinGame("StandartGame", user2, new Random().Next(1, 15));

            user1.LoseGame("SinglPlayerGame", user2, new Random().Next(1, 15));
            // user2.LoseGame(user1, new Random().Next(1, 6));
            //user2.WinGame("StandartGame", user4, new Random().Next(1, 15));
            //user2.WinGame("StandartGame", user1, new Random().Next(1, 15));
            user1.GetStatus();
            user2.GetStatus();
        }
    }
}





