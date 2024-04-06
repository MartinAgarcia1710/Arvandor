using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class Goblin : Enemy
    {
        public Goblin() : base()
        {
            this.name = "Goblin";
            this.LifePoints += 10;
            this.PhysicalAttack += 10;
            this.Exp = 25;
            this.Gold = 5;
        }
    }
}
