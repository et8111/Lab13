using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    class PlayerGuile
    {
        public string Name { get;}
        public Roshambo Ro = Roshambo.rock;
        public PlayerGuile()
        {
            Name = "Guile";
        }
        public Roshambo generateRoshambo()
        {
            return Ro;
        }
    }
}
