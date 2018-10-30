using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    abstract class Player
    {
        public virtual string Name { get; set; }
        public virtual Roshambo Ro { get; set; }

        public abstract Roshambo generateRoshambo();
    }
}
