using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    class PlayerGuile: Player
    {
        public override string Name { get; set; }
        public override int wins { get; set; }
        public override Roshambo Ro { get;set; }
        public PlayerGuile()
        {
            Name = "GUILE";
        }
        public override Roshambo generateRoshambo()
        {
            Ro = Roshambo.rock;
            return Ro;
        }
    }
}
