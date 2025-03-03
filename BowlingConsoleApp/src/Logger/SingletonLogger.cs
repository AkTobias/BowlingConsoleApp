using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace BowlingConsoleApp.src.Logger
{
    public class SingletonLogger
    {
        private static readonly Lazy<SingletonLogger> _instance = 
            new Lazy<SingletonLogger>(() => new SingletonLogger());
        //private static readonly object _lock = new object();
        private string _gameLogFilePath = "game_log.txt";
        private string _NumOfGamesFilePath = "current_game_num.txt";
        private int _currentGameNumber;

        private SingletonLogger()
        {
            if(File.Exists(_NumOfGamesFilePath))
            {
                string gameNumString = File.ReadAllText(_NumOfGamesFilePath);
                if(int.TryParse(gameNumString, out int gameNumber))
                {
                    _currentGameNumber = gameNumber;
                }
                else{
                    _currentGameNumber = 1;
                }
            }
            else
            {
                _currentGameNumber = 1;

            }
        }

        /* public static SingletonLogger Instance
        {
            get
            {
                lock(_lock)
                {
                    if(_instance == null)
                    {
                        _instance = new SingletonLogger();
                    }
                    return _instance;
                }
            }
        } */
        public static SingletonLogger Instance => _instance.Value;
        public void StartGame()
        {
            lock (_instance)
            {
                string gameHeader = $"--------Game {_currentGameNumber}--------";
                File.AppendAllText(_gameLogFilePath, gameHeader + Environment.NewLine);
                _currentGameNumber++;

                File.WriteAllText(_NumOfGamesFilePath, _currentGameNumber.ToString());
            }
        }
        
        public void Log(string message, Dictionary<string, object> additionalData = null)
        {
            lock (_instance)
            {
                string logEntry = $"[{DateTime.Now}] {message}";

                if(additionalData != null)
                {
                    foreach (var key in additionalData.Keys)
                    {
                        logEntry += $"\n{key}: {additionalData[key]}";
                    }
                }

                logEntry += Environment.NewLine;

                System.Console.WriteLine(logEntry);

                File.AppendAllText(_gameLogFilePath, logEntry);
            }
        }
    }
}