using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

class Program

{

    static void Main()

    {

        Console.WindowHeight = 18;

        Console.WindowWidth = 32;

        int screenwidth = 32;

        int screenheight = 16;

        Random randomnummer = new Random();

        string movement = "RIGHT";

        List<int> teljePositie = new List<int>();

        int score = 0;

        Pixel hoofd = new Pixel();

        hoofd.xPos = screenwidth / 2;

        hoofd.yPos = screenheight / 2;

        hoofd.schermKleur = ConsoleColor.Red;


        teljePositie.Add(hoofd.xPos);

        teljePositie.Add(hoofd.yPos);



        DateTime tijd = DateTime.Now;

        string obstacle = "*";

        int obstacleXpos = randomnummer.Next(1, screenwidth - 1);

        int obstacleYpos = randomnummer.Next(1, screenheight - 1);

        while (true)

        {

            Console.Clear();

            //Draw Obstacle

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.SetCursorPosition(obstacleXpos, obstacleYpos);

            Console.Write(obstacle);



            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);

            Console.Write("■");



            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < screenwidth; i++)

            {

                Console.SetCursorPosition(i, 0);

                Console.Write("■");

            }

            for (int i = 0; i < screenwidth; i++)

            {

                Console.SetCursorPosition(i, screenheight - 1);

                Console.Write("■");

            }

            for (int i = 0; i < screenheight; i++)

            {

                Console.SetCursorPosition(0, i);

                Console.Write("■");

            }

            for (int i = 0; i < screenheight; i++)

            {

                Console.SetCursorPosition(screenwidth - 1, i);

                Console.Write("■");

            }

            Console.ForegroundColor = ConsoleColor.Red;

            Console.SetCursorPosition(0, screenheight);

            Console.Write("Score: " + score);

            Console.ForegroundColor = ConsoleColor.White;


            for (int i = 0; i < teljePositie.Count(); i+=2)

            {

                Console.SetCursorPosition(teljePositie[i], teljePositie[i + 1]);

                Console.Write("■");

            }

            //Draw Snake

            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);

            Console.Write("■");

            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);

            Console.Write("■");

            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);

            Console.Write("■");

            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);

            Console.Write("■");



            //Game Logic
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo info = Console.ReadKey();
                switch (info.Key)

                {

                    case ConsoleKey.UpArrow:

                        movement = "UP";

                        break;

                    case ConsoleKey.DownArrow:

                        movement = "DOWN";

                        break;

                    case ConsoleKey.LeftArrow:

                        movement = "LEFT";

                        break;

                    case ConsoleKey.RightArrow:

                        movement = "RIGHT";

                        break;

                }
            }

            if (movement == "UP")

                hoofd.yPos--;

            if (movement == "DOWN")

                hoofd.yPos++;

            if (movement == "LEFT")

                hoofd.xPos--;

            if (movement == "RIGHT")

                hoofd.xPos++;

            //Hindernis treffen

            if (hoofd.xPos == obstacleXpos && hoofd.yPos == obstacleYpos)

            {

                score++;

                obstacleXpos = randomnummer.Next(1, screenwidth);

                obstacleYpos = randomnummer.Next(1, screenheight);

            }

            teljePositie.Insert(0, hoofd.xPos);

            teljePositie.Insert(1, hoofd.yPos);

            if (teljePositie.Count > (score + 1) * 2)
            {
                teljePositie.RemoveAt(teljePositie.Count - 1);
                teljePositie.RemoveAt(teljePositie.Count - 1);
            }

            //Kollision mit Wände oder mit sich selbst

            if (hoofd.xPos == 0 || hoofd.xPos == screenwidth - 1 || hoofd.yPos == 0 || hoofd.yPos == screenheight - 1)

            {

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;

                Console.SetCursorPosition(screenwidth / 5, screenheight / 2);

                Console.WriteLine("Game Over");

                Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 1);

                Console.WriteLine("Dein Score ist: " + score);

                Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 2);

                Environment.Exit(0);

            }

            for (int i = 2; i < teljePositie.Count(); i += 2)

            {

                if (hoofd.xPos == teljePositie[i] && hoofd.yPos == teljePositie[i + 1])

                {

                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.SetCursorPosition(screenwidth / 5, screenheight / 2);

                    Console.WriteLine("Das Spiel ist aus");

                    Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 1);

                    Console.WriteLine("Dein Score ist: " + score);

                    Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 2);

                    Environment.Exit(0);

                }

            }

            Thread.Sleep(150);

        }

    }

}




