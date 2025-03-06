using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BowlingConsoleApp.src.Factories;
using BowlingConsoleApp.src.Logger;
using BowlingConsoleApp.src.Players;
using BowlingConsoleApp.src.Strategies;
using BowlingConsoleApp.src.Game;
using BowlingConsoleApp.src.User;
using System.Collections;
using System.Transactions;
using System.Buffers;
using Microsoft.VisualBasic;

namespace BowlingConsoleApp.src.Game
{
    public class GameManager
    {
        private readonly UserManager userManager;
        private readonly SingletonLogger logger;

        public GameManager()
        {
            logger = SingletonLogger.Instance;
            userManager = new UserManager();
        }

        private string GetValiedUser(string nameInput)
        {
            string name;
            while (true)
            {
                Console.Write(nameInput);
                name = Console.ReadLine();

                if (!userManager.UserExists(name))
                {
                    System.Console.WriteLine($"User '{name}' dose not exist. Please try again");
                }
                else
                {
                    return name;
                }

            }
        }

        public void StartGame()
        {
  
            logger.Log("Game Session started");

            System.Console.WriteLine("Welcome to the bowling game!");
  

            while (true)
            {
                logger.StartGame();
                //Console.Clear();
                System.Console.WriteLine("-----The Bowling Game-----");
                System.Console.WriteLine("1. Register User");
                System.Console.WriteLine("2. View all registerd users");
                System.Console.WriteLine("3. Delete user");
                System.Console.WriteLine("4. Play a game");
                System.Console.WriteLine("5. Exit");
                System.Console.Write("Choose an option 1-5: ");


                int choice;


                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 5)
                    {
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("Invalid input please enter a number between 1 and 5");
                    }
                }


                switch (choice)
                {
                    case 1:
                        userManager.RegisterUser();
                        break;
                    case 2:
                        userManager.DisplayAllUsers();
                        break;
                    case 3:
                        userManager.DeleteUser();
                        break;
                    case 4:
                        PlayGame();
                        break;
                    case 5:
                        Console.Write("Exiting the game");
                        Environment.Exit(0);//here
                        break;

                    default:
                        System.Console.WriteLine("Invalid input");
                        break;

                }
            }
        }



        private void PlayGame()
        {

            List<Player> players = new List<Player>();
            PlayerFactory playerFactory = null;
            bool playAgain = false;
            int rounds = 0;


            do
            {
                if (!playAgain || players.Count == 0)
                {

                    players.Clear();

                    System.Console.WriteLine("Choose Game type");
                    System.Console.WriteLine("1. Play vs another human");
                    System.Console.WriteLine("2. Play vs Computer");
                    System.Console.Write("Make your choice 1 or 2: ");
                    int gameMode;

                    while (true)
                    {
                        Console.Write("Make your choice (1 or 2): ");
                        if (int.TryParse(Console.ReadLine(), out gameMode) && (gameMode == 1 || gameMode == 2))
                        {
                            break; // Valid input, exit loop
                        }
                        else
                        {
                            System.Console.WriteLine("Invalid input. Please enter 1 for Human vs Human or 2 for Human vs Computer.");
                        }
                    }



                        switch (gameMode)
                        {
                            //Human vs Human
                            case 1:
                                string playerOne = GetValiedUser("Enter name of the first player: ");
                                string playerTwo = GetValiedUser("Enter name of the second player: ");

                                playerFactory = new HumanPlayerFactory();
                                players.Add(playerFactory.CreatePlayer(playerOne));
                                players.Add(playerFactory.CreatePlayer(playerTwo));

                                logger.Log($"Player 1: {playerOne} vs Player 2: {playerTwo}");
                                break;

                            case 2:
                                //System.Console.WriteLine("Enter name your name");
                                string player = GetValiedUser("Enter your name: ");
                                playerFactory = new HumanPlayerFactory();
                                players.Add(playerFactory.CreatePlayer(player));


                                System.Console.WriteLine("Choose Ai difficulty ");
                                System.Console.WriteLine("1 - Easy mode");
                                System.Console.WriteLine("2 - Hard mode");
                                System.Console.Write("Enter your choice (1 or 2): ");
                                int gameDifficulty;


                                while (true)
                                {
                                    Console.Write("Enter your choice (1 or 2): ");
                                    string input = Console.ReadLine();

                                    if (int.TryParse(input, out gameDifficulty) && (gameDifficulty == 1 || gameDifficulty == 2))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Invalid input, pick 1 for easy or 2 for hard");
                                    }
                                }
                                IAiStrategy aiStrategy = null;
                                string aiName = "";

                                if (gameDifficulty == 1)
                                {
                                    aiStrategy = new EasyAiStrategy();
                                    aiName = "Easy Mode";
                                }
                                else if (gameDifficulty == 2)
                                {
                                    aiStrategy = new HardAiStrategy();
                                    aiName = "Hard Mode";
                                }


                                playerFactory = new AiPlayerFactory(aiStrategy);
                                players.Add(playerFactory.CreatePlayer(aiName));

                                logger.Log($"{player} VS {aiName}");
                                break;

                        }

                    }



                    System.Console.WriteLine("How many rounds do you want to play? ");

                    while (!int.TryParse(Console.ReadLine(), out rounds) || rounds <= 0)
                    {
                        System.Console.WriteLine("Invalid input. please enter a positive number");
                    }


                    Match match = new Match(players, rounds);
                    match.Start();
                    logger.Log($"number of rounds {rounds}");

                    System.Console.WriteLine("1. Do you want to play again");
                    System.Console.WriteLine("2. Back to main menu");
                    System.Console.WriteLine("3. Exit Game");
                    System.Console.Write("Enter your choice:");

                    int afterGameChoice;
                    while (!int.TryParse(Console.ReadLine(), out afterGameChoice) || afterGameChoice < 1 || afterGameChoice > 3)
                    {
                        System.Console.WriteLine("invalid input. Please enter a number between 1 and 3");
                    }
                    switch (afterGameChoice)
                    {
                        case 1:
                            playAgain = true;
                            break;
                        case 2:
                            return;
                        case 3:
                            Environment.Exit(0);
                            break;

                    }

                } while (playAgain) ;

            }}


    }
    