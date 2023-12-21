//по папках розділено!
//проблемит з індексом.


namespace labka
{
    //тип гри 


    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            GameAccount user1 = new GameAccount("nub", 1, 2);
            GameAccount user2 = new GameAccount("Pro", 5, 26);
            GameAccount user4 = new GameAccount("bybka", 30, 5);

            user1.WinGame(user2, new Random().Next(1, 15));
            user2.LoseGame(user1, new Random().Next(1, 15));
            user2.LoseGame(user1, new Random().Next(1, 6));
            user2.WinGame(user4, new Random().Next(1, 15));
            user2.WinGame(user1, new Random().Next(1, 15));

            user1.GetStatus();
            user2.GetStatus();
        }
    }
}





