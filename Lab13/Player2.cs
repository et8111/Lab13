using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    class Player2
    {
        public string Name { get; set; }
        public Roshambo Ro;

        public Player2(string n)
        {
            Name = n;
        }

        public Roshambo generateRoshambo()
        {
            Random r = new Random();
            Ro = (Roshambo)r.Next(0, 3);
            return Ro;
        }
    }
}
