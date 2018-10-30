using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    class Player2: Player
    {
        public override string Name { get; set; }
        public override Roshambo Ro { get; set; }
        public override int wins { get; set; }

        public Player2()
        {
            Console.Write("FIGHTERS NAME: ");
            string s = Console.ReadLine().ToUpper();
            Name = s;
        }

        public override Roshambo generateRoshambo()
        {
            Random r = new Random();
            Ro = (Roshambo)r.Next(0, 3);
            return Ro;
        }
    }
}
