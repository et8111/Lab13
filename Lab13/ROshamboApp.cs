using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    class ROshamboApp
    {
        public int[] player1Score { get; set; }
        public int[] player2Score { get; set; }

        public Player2 player2;
        public PlayerGuile Guile;
        public Player player1;

        public void Play()
        {
            int choice = PlayerSelection();
            string chr = (choice == 1)? "GUILE" :"CUSTOM";
            Console.WriteLine($"YOU CHOSE {chr}");
        }

        public int PlayerSelection()
        {
            ConsoleColor Current = Console.ForegroundColor;
            Console.Clear();
            Console.WriteLine("FIGHTER SELECTION");
            Console.WriteLine("=================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("GUILE");
            Console.ForegroundColor = Current;
            Console.WriteLine("      CUSTOM");
            ConsoleKeyInfo k;
            int temp = 1;
            while (true)
            {
                k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.Enter)
                    break;
                else if (k.Key == ConsoleKey.RightArrow)
                {
                    Console.SetCursorPosition(0, 2);
                    Console.ForegroundColor = Current;
                    Console.Write("GUILE");
                    Console.SetCursorPosition(11, 2);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("CUSTOM");
                    temp = 2;
                }
                else if (k.Key == ConsoleKey.LeftArrow)
                {
                    Console.SetCursorPosition(0, 2);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("GUILE");
                    Console.SetCursorPosition(11, 2);
                    Console.ForegroundColor = Current;
                    Console.Write("CUSTOM");
                    temp = 1;
                }
                
            }
            Console.ForegroundColor = Current;
            Console.SetCursorPosition(0, 3);
            return temp;
        }
    }
}
