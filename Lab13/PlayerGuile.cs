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
        public new Roshambo Ro = Roshambo.rock;
        public PlayerGuile()
        {
            Name = "GUILE";
        }
        public override Roshambo generateRoshambo()
        {
            return Roshambo.rock;
        }
    }
}
