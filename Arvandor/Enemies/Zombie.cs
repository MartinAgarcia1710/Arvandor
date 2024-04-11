using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class Zombie : Enemy
    {
        public Zombie()
        {
            this.name = "Zombie";
            this.LifePoints += 20;
            this.Exp = 40;
            this.Gold = 30;
            this.Life = this.LifePoints;
        }
    }
}
