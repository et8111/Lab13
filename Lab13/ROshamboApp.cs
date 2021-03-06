﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    class ROshamboApp
    {
        public List<Player> players;

        public void Play()
        {//Determine if usering PlayerGuile or Player2(custom class) then enter the 'prefight()' loop
            players = new List<Player>();
            players.Add(new LimboPlayer());
            int choice = SELCTOR("GUILE", "CUSTOM", "FIGHTER SELECTION", "", "");
            if (choice == 1)
                players.Add(new PlayerGuile());
            else
                players.Add(new Player2());
            Prefight(players);
            choice = SELCTOR("YAAS", "I SAID NO SMOKE", "     NEW CHACTER?", "", "");
            if (choice != 1)                                                            //2 to exit
                return;                                                                 //
            Play();                                                                     //1 to replay
            players.Clear();                                                            //delete Original 2 players
        }
        private void Prefight(List<Player> p1)
        {//Using 'SELCTOR()' to format console and 'WinResults()' for logic, loop recursively till user chooses to exit
            int choice = SELCTOR("READY", "No smoke bruh...", $"{p1[0].Name,-8} VS. {p1[1].Name,8}", "   READY TO THROW DOWN?", $"{p1[0].wins,5}{":",6}{p1[1].wins,6}");
            if (choice == 2)
                return;
            p1[0].generateRoshambo();
            System.Threading.Thread.Sleep(83);                 //try to force diffrent random outcome by slightly adjustring time
            p1[1].generateRoshambo();
            string temp3 = Fightlogic(p1[0].Ro, p1[1].Ro);
            if (temp3 == ">")
            {
                WinResults($"{p1[0].Ro,-10}{ temp3,-2}", $"{p1[1].Ro,8}", $"   {p1[0].Name}", true);
                p1[0].wins++;
            }
            else if (temp3 == "<")
            {
                WinResults($"{p1[0].Ro,-10}", $"{ temp3,-2}{p1[1].Ro,8}", $"   {p1[1].Name}", false);
                p1[1].wins++;

            }
            else
                Console.WriteLine($"{p1[0].Ro,-10}{temp3, -2}{p1[1].Ro, 8}\n       DRAW!!!!");
            while (Console.KeyAvailable)                                                    //clear buffer
                Console.ReadKey(true);                                                      //
            Console.ReadLine();
            Prefight(players);
        }

        private void WinResults(string s1, string s2, string name, bool winner)
        {
            ConsoleColor Current = Console.ForegroundColor;
            Console.ForegroundColor = (winner == true)?ConsoleColor.Yellow: Current;
            Console.Write(s1);
            Console.ForegroundColor = (winner == false)?ConsoleColor.Yellow: Current;
            Console.WriteLine(s2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Threading.Thread.Sleep(500);             //helps game flow better with light pause before user can enter anything
            Console.Write(name);
            Console.ForegroundColor = Current;
            Console.WriteLine(" WINS!!!!");
        }

        private string Fightlogic(Roshambo t1, Roshambo t2)
        {
            if (t1 == t2)
                return "=";
            if ((t1 == 0 && (int)t2 == 2) || ((int)t1 > (int)t2 && !((int)t1 == 2 && (int)t2 == 0))  )
                return ">";
            else
                return "<";
        }

        public int SELCTOR(string c1, string c2, string banner, string LsubMessage, string UsubMessage)
        {
            ConsoleColor Current = Console.ForegroundColor;//My Conosle colors are custume and fancy this is to save it
            Console.Clear();                                                                //ensure everything lines up
            Console.WriteLine(banner+ "\n" + UsubMessage + "\n" + "=".PadLeft(c1.Length+c2.Length+6,'=') + "\n" + LsubMessage);
            Console.ForegroundColor = ConsoleColor.Yellow;          //Pre set the first options to yellow
            Console.Write(c1);                                      //
            Console.ForegroundColor = Current;                      //
            Console.WriteLine($"      {c2}");                       //
            ConsoleKeyInfo k;                                       //initialize a value to hold key selections
            int temp = 1;
            while (true)                //while loop swaps between left and right option switching the color based on user input
            {
                k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.Enter)
                    break;
                else if (k.Key == ConsoleKey.RightArrow || k.Key == ConsoleKey.LeftArrow)
                {
                    Console.SetCursorPosition(0, 4);
                    Console.ForegroundColor = (k.Key == ConsoleKey.RightArrow)?Current: ConsoleColor.Yellow;
                    Console.Write(c1);
                    Console.SetCursorPosition(c1.Length+6, 4);
                    Console.ForegroundColor = (k.Key == ConsoleKey.RightArrow)?ConsoleColor.Yellow:Current;
                    Console.Write(c2);
                    temp = (k.Key == ConsoleKey.RightArrow)?2: 1;
                }
            }
            Console.ForegroundColor = Current;  //set color back to normal
            Console.SetCursorPosition(0, 4);    //set position at the selectable options line
            Console.Write(c1 +"      "+ c2);    //write over both options with normal color
            Console.SetCursorPosition(0, 5);    //go to unused line just in case cursor is not at line 4 for some reason
            Console.WriteLine();                //added security
            return temp;                        //return user choice
        }
    }
}
