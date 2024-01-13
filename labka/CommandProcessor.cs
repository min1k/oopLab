using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labka
{
    public class CommandProcessor
    {
        private readonly DisplayPlayersTask _displayPlayersTask;
        private readonly AddPlayerTask _addPlayerTask;
        private readonly PlayerStatisticsTask _playerStatisticsTask;
        private readonly PlayGameTask _playGameTask;

        public CommandProcessor(

            DisplayPlayersTask displayPlayersTask,
            AddPlayerTask addPlayerTask,
            PlayerStatisticsTask playerStatisticsTask,
            PlayGameTask playGameTask)
        {
            _displayPlayersTask = displayPlayersTask;
            _addPlayerTask = addPlayerTask;
            _playerStatisticsTask = playerStatisticsTask;
            _playGameTask = playGameTask;
        }

        public void ProcessCommand(string command)
        {
            string[] args = command.Split(' ');

            switch (args[0])
            {
                //displayplayers
                case "1":
                    _displayPlayersTask.Execute();
                    break;

                //addplayer
                case "2":
                    if (args.Length == 2)
                    {
                        string userName = args[1];
                        int currentRating = 0; // Вам можливо, потрібно обробити помилки при парсингу.
                        int gamesCount = 0; // Тут також може бути необхідна обробка помилок.
                        string accountType = "SomeDefaultAccountType"; // Вставте свій тип акаунту за замовчуванням.

                        _addPlayerTask.Execute(userName, currentRating, gamesCount, accountType);
                    }
                    else if (args.Length == 5)
                    {
                        string userName = args[1];
                        int currentRating = int.Parse(args[2]);
                        int gamesCount = int.Parse(args[3]);
                        string accountType = args[4];

                        _addPlayerTask.Execute(userName, currentRating, gamesCount, accountType);
                    }
                    else
                    {
                        Console.WriteLine("Invalid number of arguments for addplayer command.");
                    }
                    break;

                //playerstatistics
                case "3":
                    if (args.Length == 2)
                    {
                        int playerId = int.Parse(args[1]);
                        _playerStatisticsTask.Execute(playerId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid number of arguments for playerstatistics command.");
                    }
                    break;

                //playgame
                case "4":
                    if (args.Length == 5)
                    {
                        string playerName = args[1];
                        string opponentName = args[2];
                        string result = args[3];
                        string gameType = args[4];

                        _playGameTask.Execute(playerName, opponentName, result, gameType);
                    }
                    else
                    {
                        Console.WriteLine("Invalid number of arguments for playgame command.");
                    }
                    break;

                default:
                    Console.WriteLine("Невідома команда. Доступні команди: 1, 2, 3, 4, 5");
                    break;
            }
        }

    }
    }
