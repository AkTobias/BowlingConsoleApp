using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BowlingConsoleApp.src.Factories;
using BowlingConsoleApp.src.Logger;
using BowlingConsoleApp.src.Players;
using BowlingConsoleApp.src.Strategies;

namespace BowlingConsoleApp.src.Game
{
    public class GameManager
    {
        public void StartGame()
        {
            SingletonLogger logger = SingletonLogger.Instance;
            logger.Log("Game Session started");

            bool playAnotherGame = true;
            //int gameCount = 1;

            while(playAnotherGame)
            {
                logger.StartGame();
                System.Console.WriteLine("Choose Game type");
                System.Console.WriteLine("1. Play vs another human");
                System.Console.WriteLine("2. Play vs Computer");
                System.Console.Write("Make your choice 1 or 2");
                int gameMode = int.Parse(Console.ReadLine());

                List<Player> players = new List<Player>();
                PlayerFactory playerFactory = null ;

                switch (gameMode)
                {
                    //Human vs Human
                    case 1:
                        System.Console.WriteLine("Enter name of the first player");
                        string playerOne = Console.ReadLine();
                        playerFactory = new HumanPlayerFactory();
                        players.Add(playerFactory.CreatePlayer(playerOne));

                        System.Console.WriteLine("Enter name of second player");
                        string playerTwo = Console.ReadLine();
                        playerFactory = new HumanPlayerFactory();
                        players.Add(playerFactory.CreatePlayer(playerTwo));

                        logger.Log($"Player 1:{playerOne} vs Player 2: {playerTwo}");
                        break;

                    case 2:
                        System.Console.WriteLine("Enter name your name");
                        string player = Console.ReadLine();
                        playerFactory = new HumanPlayerFactory();
                        players.Add(playerFactory.CreatePlayer(player));


                        System.Console.WriteLine("Choose Ai difficulty ");
                        System.Console.WriteLine("1 - Easy mode");
                        System.Console.WriteLine("2 - Hard mode");
                        System.Console.WriteLine("Enter your choice 1 or 2");
                        int gameDifficulty = int.Parse(Console.ReadLine());
                        IAiStrategy aiStrategy = null; // here
                        string aiName = "";

                        switch (gameDifficulty)
                        {
                             case 1:
                                aiStrategy = new EasyAiStrategy();
                                aiName = "Easy Computer";
                                break;
                            case 2:
                                aiStrategy = new HardAiStrategy();
                                aiName = "Hard Computer";
                                break;
                            default:
                                System.Console.WriteLine("invalid input");
                                break;

                            
                        }

                        playerFactory = new AiPlayerFactory(aiStrategy);
                        players.Add(playerFactory.CreatePlayer(aiName)); 

                        logger.Log($"{player} VS {aiName}");
                        break;
                    
                    default:
                        System.Console.WriteLine("Invalid choice");
                        break;
                   
                }

                System.Console.WriteLine("How many rounds do you want to play?");
                int rounds = int.Parse(Console.ReadLine());

                Match match = new Match(players, rounds);
                logger.Log($"number of rounds {rounds}");
                match.Start();
              

            }

            
        }
    }
}