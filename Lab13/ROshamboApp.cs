using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    class ROshamboApp
    {//SELECTOR(choice1, choice2, Banner message, lowerSub message, UpperSubMessage)
        public int[] player1Score { get; set; }
        public int[] player2Score { get; set; }

        public List<Player> players;

        public void Play()
        {
            players = new List<Player>();
            players.Add(new LimboPlayer());
            int choice = SELCTOR("GUILE", "CUSTOM", "FIGHTER SELECTION", "", "");
            if (choice == 1)
                players.Add(new PlayerGuile());
            else
                players.Add(new Player2());
            Prefight(players);
            choice = SELCTOR("YEA", "I TRULY WANT NO SMOKE!", "        NEW CHACTER?", "", "");
            if (choice == 1)
            {
                players[0].wins = 0;
                players[1].wins = 0;
                players[1].Name = "";
                Play();
            }

        }
        private void Prefight(List<Player> p1)
        {
            ConsoleColor Current = Console.ForegroundColor;
            int choice = SELCTOR("READY", "No smoke bruh...", $"{p1[0].Name,-8} VS. {p1[1].Name,8}", "   READY TO THROW DOWN?", $"{p1[0].wins,5}{":",6}{p1[1].wins,6}");
            if (choice == 2)
                return;
            Roshambo temp1, temp2;
            temp1 = p1[0].generateRoshambo();
            System.Threading.Thread.Sleep(100);
            temp2 = p1[1].generateRoshambo();
            string temp3 = Fightlogic(temp1, temp2);
            if (temp3 == ">")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{temp1,-10}{ temp3,-2}");
                Console.ForegroundColor = Current;
                Console.WriteLine($"{temp2,8}");
                p1[0].wins++;
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Threading.Thread.Sleep(500);
                Console.Write($"   {p1[0].Name}");
                Console.ForegroundColor = Current;
                Console.WriteLine(" WINS!!!!");
            }
            else if (temp3 == "<")
            {
                
                Console.Write($"{temp1,-10}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{ temp3,-2}{temp2,8}");
                Console.ForegroundColor = Current;
                p1[1].wins++;
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Threading.Thread.Sleep(500);
                Console.Write($"   {p1[1].Name}");
                Console.ForegroundColor = Current;

                Console.WriteLine(" WINS!!!!");
            }
            else
                Console.WriteLine($"{temp1,-10}{temp3, -2}{temp2, 8}\n       DRAW!!!!");
            Console.ReadLine();
            Prefight(players);
        }

        private string Fightlogic(Roshambo t1, Roshambo t2)
        {
            if (t1 == t2)
                return "=";
            if (t1 == 0 && (int)t2 == 2)
                return ">";
            else if ((int)t1 > (int)t2)
                return ">";
            else
                return "<";
        }

        public int SELCTOR(string c1, string c2, string banner, string LsubMessage, string UsubMessage)
        {
            ConsoleColor Current = Console.ForegroundColor;
            Console.Clear();
            Console.WriteLine(banner);
            Console.WriteLine(UsubMessage);
            Console.WriteLine("=".PadLeft(c1.Length+c2.Length+6,'='));
            Console.WriteLine(LsubMessage);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(c1);
            Console.ForegroundColor = Current;
            Console.WriteLine($"      {c2}");
            ConsoleKeyInfo k;
            int temp = 1;
            while (true)
            {
                k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.Enter)
                    break;
                else if (k.Key == ConsoleKey.RightArrow)
                {
                    Console.SetCursorPosition(0, 4);
                    Console.ForegroundColor = Current;
                    Console.Write(c1);
                    Console.SetCursorPosition(c1.Length+6, 4);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(c2);
                    temp = 2;
                }
                else if (k.Key == ConsoleKey.LeftArrow)
                {
                    Console.SetCursorPosition(0, 4);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(c1);
                    Console.SetCursorPosition(c1.Length+6, 4);
                    Console.ForegroundColor = Current;
                    Console.Write(c2);
                    temp = 1;
                }
                
            }
            Console.ForegroundColor = Current;
            Console.SetCursorPosition(0, 4);
            Console.Write(c1 +"      "+ c2);
            Console.SetCursorPosition(0, 5);
            Console.WriteLine();
            return temp;
        }
    }
}
