﻿using System;
using System.Threading;

namespace _2048
{
    class Program
    {
        static void Main(string[] args)
        {
            LaunchGame.Manage();
        }
    }

    class MessageDisplayment
    {
        public static void Name()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   [Игра 2048]");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Menu()
        {
            Console.WriteLine("\n     Меню");
            Console.WriteLine("1. Начать игру" +
                              "\n2. Правила игры" +
                              "\n0. Закрыть приложение");

        }
        public static void Specification()
        {
            Console.WriteLine("\nНажатием стрелки вы можете скинуть все плитки игрового поля в одну из 4 сторон." +
                              "\nЕсли при скидывании две плитки одного номинала 'налетают' одна на другую, то они" +
                              "\nслипаются в одну, номинал которой равен сумме соединившихся плиток. После каждо-" +
                              "\nго хода на свободной секции поля появляется новая плитка номиналом «2» или «4». " +
                              "\nЕсли при нажатии кнопки местоположение плиток или их номинал не изменится, то " +
                              "\nход не совершается. Игра заканчивается поражением, если после очередного хода " +
                              "\nневозможно совершить действие");
        }

        public static void BackToMenu()
        {
            Console.WriteLine("\n1. Выйти в меню");
        }

        public static void Exit()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nЗакрытие приложения...");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void StartAgain()
        {
            Console.WriteLine("2. Начать игру заново");
        }
    }

    class LaunchGame
    {
        public static void Manage()
        {
            int finishGame, menuTracker; 
            do
            {
                finishGame = 0;
                menuTracker = 0;
                ConsoleKeyInfo externalMenu, internalMenu; 
                Console.Clear();
                do
                {
                    MessageDisplayment.Name();
                    MessageDisplayment.Menu();
                    externalMenu = Console.ReadKey();
                    Console.Clear();
                    
                    switch (externalMenu.Key.ToString())
                    {
                       
                        case "D1":
                            Game();
                            break;

                        case "D2":
                           
                            do
                            {
                                Console.Clear();
                                MessageDisplayment.Name();
                                MessageDisplayment.Specification();
                                MessageDisplayment.BackToMenu();
                                internalMenu = Console.ReadKey();
                            } while (internalMenu.Key.ToString() != "D1");
                            menuTracker = 1;
                            break;

                        case "D0":
                            Console.Clear();
                            MessageDisplayment.Name();
                            MessageDisplayment.Exit();
                            finishGame = 1;
                            menuTracker = 1;
                            break;
                    }
                } while (menuTracker == 0);
            } while (finishGame == 0);
            Environment.Exit(0);
        }

        public static void Game()
        {
            ConsoleKeyInfo gameClick, internalMenu; 
            Random rnd = new Random(); 
            bool isClicked; 
            int counter = 0; 
            bool gameStart = true; 
            bool finish = false; 
            bool checkEmpty; 
            int tempI, tempJ; 
            string[,] gameArray = new string[4, 4]; 
            bool[,] tempArray = new bool[4, 4];
            int tempSumm;
            int score = 0;
            bool gameFinish = false;
            int flag;

            
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    gameArray[i, j] = " ";
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    tempArray[i, j] = false;

            
            while (!finish)
            {
                if (gameStart && counter != 16)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        
                        do
                        {
                            checkEmpty = false;
                            tempI = rnd.Next(0, 4);
                            tempJ = rnd.Next(0, 4);
                            if (gameArray[tempI, tempJ] == " ")
                            {
                                gameArray[tempI, tempJ] = "2";
                                checkEmpty = true;
                            }
                        } while (!checkEmpty);
                    }
                    gameStart = false;
                }
                else if (counter != 16)
                {
                    
                    do
                    {
                        checkEmpty = false;
                        tempI = rnd.Next(0, 4);
                        tempJ = rnd.Next(0, 4);
                        if (gameArray[tempI, tempJ] == " ")
                        {
                            gameArray[tempI, tempJ] = "2";
                            checkEmpty = true;
                        }
                    } while (!checkEmpty);
                }
                counter = 0;

                
                ShowArray(ref gameArray);

               
                if (gameFinish == false)
                {
                    isClicked = false;
                    do
                    {
                        
                        Console.Write("\nСчет: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(score);
                        Console.ForegroundColor = ConsoleColor.White;
                        MessageDisplayment.BackToMenu();
                        gameClick = Console.ReadKey();
                        switch (gameClick.Key.ToString())
                        {
                            case "UpArrow":
                                tempSumm = 0;
                                ShowArray(ref gameArray);
                                for (int k = 1; k <= 3; k++)
                                {
                                    for (int i = 3; i > 0; i--)
                                    {
                                        for (int j = 0; j < 4; j++)
                                        {
                                            if (gameArray[i - 1, j] == " ")
                                            {
                                                gameArray[i - 1, j] = gameArray[i, j];
                                                gameArray[i, j] = " ";
                                            }
                                            if (gameArray[i - 1, j] == gameArray[i, j] && gameArray[i, j] != " " && tempArray[i, j] == false)
                                            {
                                                tempSumm = int.Parse(gameArray[i - 1, j]) + int.Parse(gameArray[i, j]);
                                                gameArray[i - 1, j] = Convert.ToString(tempSumm);
                                                gameArray[i, j] = " ";
                                                score = ScoreCounter(ref score, ref gameArray[i - 1, j]);
                                                tempArray[i - 1, j] = true;
                                            }
                                        }
                                    }
                                }
                                for (int i = 0; i < 4; i++)
                                    for (int j = 0; j < 4; j++)
                                        tempArray[i, j] = false;
                                isClicked = true;
                                break;
                            case "DownArrow":
                                tempSumm = 0;
                                ShowArray(ref gameArray);
                                for (int k = 1; k <= 3; k++)
                                {
                                    for (int i = 0; i < 3; i++)
                                    {
                                        for (int j = 0; j < 4; j++)
                                        {
                                            if (gameArray[i + 1, j] == " ")
                                            {
                                                gameArray[i + 1, j] = gameArray[i, j];
                                                gameArray[i, j] = " ";
                                            }
                                            if (gameArray[i + 1, j] == gameArray[i, j] && gameArray[i, j] != " " && tempArray[i, j] == false)
                                            {
                                                tempSumm = int.Parse(gameArray[i + 1, j]) + int.Parse(gameArray[i, j]);
                                                gameArray[i + 1, j] = Convert.ToString(tempSumm);
                                                gameArray[i, j] = " ";
                                                score = ScoreCounter(ref score, ref gameArray[i + 1, j]);
                                                tempArray[i + 1, j] = true;
                                            }
                                        }
                                    }
                                }
                                for (int i = 0; i < 4; i++)
                                    for (int j = 0; j < 4; j++)
                                        tempArray[i, j] = false;
                                isClicked = true;
                                break;
                            case "LeftArrow":
                                tempSumm = 0;
                                ShowArray(ref gameArray);
                                for (int k = 1; k <= 3; k++)
                                {
                                    for (int i = 3; i > 0; i--)
                                    {
                                        for (int j = 0; j < 4; j++)
                                        {
                                            if (gameArray[j, i - 1] == " ")
                                            {
                                                gameArray[j, i - 1] = gameArray[j, i];
                                                gameArray[j, i] = " ";
                                            }
                                            if (gameArray[j, i - 1] == gameArray[j, i] && gameArray[j, i] != " " && tempArray[j, i] == false)
                                            {
                                                tempSumm = int.Parse(gameArray[j, i - 1]) + int.Parse(gameArray[j, i]);
                                                gameArray[j, i - 1] = Convert.ToString(tempSumm);
                                                gameArray[j, i] = " ";
                                                score = ScoreCounter(ref score, ref gameArray[j, i - 1]);
                                                tempArray[j, i - 1] = true;
                                            }
                                        }
                                    }
                                }
                                for (int i = 0; i < 4; i++)
                                    for (int j = 0; j < 4; j++)
                                        tempArray[i, j] = false;
                                isClicked = true;
                                break;
                            case "RightArrow":
                                tempSumm = 0;
                                ShowArray(ref gameArray);
                                for (int k = 1; k <= 3; k++)
                                {
                                    for (int i = 0; i < 3; i++)
                                    {
                                        for (int j = 0; j < 4; j++)
                                        {
                                            if (gameArray[j, i + 1] == " ")
                                            {
                                                gameArray[j, i + 1] = gameArray[j, i];
                                                gameArray[j, i] = " ";
                                            }
                                            if (gameArray[j, i + 1] == gameArray[j, i] && gameArray[j, i] != " " && tempArray[j, i] == false)
                                            {
                                                tempSumm = int.Parse(gameArray[j, i + 1]) + int.Parse(gameArray[j, i]);
                                                gameArray[j, i + 1] = Convert.ToString(tempSumm);
                                                gameArray[j, i] = " ";
                                                score = ScoreCounter(ref score, ref gameArray[j, i + 1]);
                                                tempArray[j, i + 1] = true;
                                            }
                                        }
                                    }
                                }
                                for (int i = 0; i < 4; i++)
                                    for (int j = 0; j < 4; j++)
                                        tempArray[i, j] = false;
                                isClicked = true;
                                break;
                            case "D1":
                                Manage();
                                break;
                            default:
                                ShowArray(ref gameArray);
                                break;
                        }
                    } while (!isClicked);

                    
                    for (int i = 0; i < 4; i++)
                        for (int j = 0; j < 4; j++)
                            if (gameArray[i, j] != " ")
                                counter++;

                    
                    flag = 0;
                    if (counter == 16)
                    {
                        for (int i = 0; i < 4; i++)
                            for (int j = 0; j < 4; j++)
                            {
                                if (i == 0)
                                {
                                    if (j == 0)
                                    {
                                        if (gameArray[i, j] == gameArray[i + 1, j] || gameArray[i, j] == gameArray[i, j + 1])
                                        {
                                            gameFinish = false;
                                            flag = 1;
                                        }
                                    }
                                    if (j == 3)
                                    {
                                        if (gameArray[i, j] == gameArray[i + 1, j] || gameArray[i, j] == gameArray[i, j - 1])
                                        {
                                            gameFinish = false;
                                            flag = 1;
                                        }
                                    }
                                    if (j == 1 || j == 2)
                                    {
                                        if (gameArray[i, j] == gameArray[i + 1, j] || gameArray[i, j] == gameArray[i, j + 1] || gameArray[i, j] == gameArray[i, j - 1])
                                        {
                                            gameFinish = false;
                                            flag = 1;
                                        }
                                    }
                                }
                                if (i == 3)
                                {
                                    if (j == 0)
                                    {
                                        if (gameArray[i, j] == gameArray[i - 1, j] || gameArray[i, j] == gameArray[i, j + 1])
                                        {
                                            gameFinish = false;
                                            flag = 1;
                                        }
                                    }
                                    if (j == 3)
                                    {
                                        if (gameArray[i, j] == gameArray[i - 1, j] || gameArray[i, j] == gameArray[i, j - 1])
                                        {
                                            gameFinish = false;
                                            flag = 1;
                                        }
                                    }
                                    if (j == 1 || j == 2)
                                    {
                                        if (gameArray[i, j] == gameArray[i - 1, j] || gameArray[i, j] == gameArray[i, j + 1] || gameArray[i, j] == gameArray[i, j - 1])
                                        {
                                            gameFinish = false;
                                            flag = 1;
                                        }
                                    }
                                }
                                if (i == 1 || i == 2)
                                {
                                    if (j == 0)
                                    {
                                        if (gameArray[i, j] == gameArray[i - 1, j] || gameArray[i, j] == gameArray[i + 1, j] || gameArray[i, j] == gameArray[i, j + 1])
                                        {
                                            gameFinish = false;
                                            flag = 1;
                                        }
                                    }
                                    if (j == 3)
                                    {
                                        if (gameArray[i, j] == gameArray[i - 1, j] || gameArray[i, j] == gameArray[i + 1, j] || gameArray[i, j] == gameArray[i, j - 1])
                                        {
                                            gameFinish = false;
                                            flag = 1;
                                        }
                                    }
                                    if (j == 1 || j == 2)
                                    {
                                        if (gameArray[i, j] == gameArray[i - 1, j] || gameArray[i, j] == gameArray[i + 1, j] || gameArray[i, j] == gameArray[i, j - 1] || gameArray[i, j] == gameArray[i, j + 1])
                                        {
                                            gameFinish = false;
                                            flag = 1;
                                        }
                                    }
                                }
                            }
                        if (flag == 0)
                            gameFinish = true;
                        else
                            gameFinish = false;
                    }
                }
                
                if (gameFinish == true)
                {
                    
                    do
                    {
                        ShowArray(ref gameArray);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nИгра завершена!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Cчет: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(score);
                        Console.ForegroundColor = ConsoleColor.White;
                        MessageDisplayment.BackToMenu();
                        MessageDisplayment.StartAgain();
                        internalMenu = Console.ReadKey();
                        if (internalMenu.Key.ToString() == "D1")
                            Manage();
                        if (internalMenu.Key.ToString() == "D2")
                            Game();
                        Console.Clear();
                    } while (internalMenu.Key.ToString() != "D1" && internalMenu.Key.ToString() != "D2");
                }

                if (gameFinish == true)
                    finish = true;
            }
        }

        public static int ScoreCounter(ref int x, ref string y)
        {
            x += int.Parse(y);
            return x;
        }

        public static void ShowArray(ref string[,] gameArray)
        {
            
            Console.Clear();
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                    Console.WriteLine("–––––––––––––––––");
                Console.Write("| ");
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(gameArray[i, j] + " | ");
                }
                Console.WriteLine("\n–––––––––––––––––");
            }
        }
    }
}
