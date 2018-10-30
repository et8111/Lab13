using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    class LimboPlayer: Player
    {
        public override string Name { get; set; }
        public override Roshambo Ro { get; set; }
        public override int wins { get; set; }

        public LimboPlayer()
        {
            Name = "LIMBO";
        }

        public override Roshambo generateRoshambo()
        {
            Random r = new Random();
            Ro = (Roshambo)r.Next(0, 3);
            return Ro;
        }
    }
}
