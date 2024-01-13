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
                    _addPlayerTask.Execute();
                    break;
                case "3":
                    _playerStatisticsTask.DisplayPlayerInfo();
                    break;

                case "4":
                    _playGameTask.Execute();
                    break;


                default:
                    Console.WriteLine("Невідома команда. Доступні команди: 1, 2, 3, 4, 5");
                    break;
            }
        }

    }
}
