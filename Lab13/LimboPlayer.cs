using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    class LimboPlayer: Player
    {
        public new string Name { get; }
        public new Roshambo Ro { get; set; }

        public LimboPlayer()
        {
            Name = "Limbo";
        }

        public override Roshambo generateRoshambo()
        {
            Random r = new Random();
            Ro = (Roshambo)r.Next(0, 3);
            return Ro;
        }
    }
}
