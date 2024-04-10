using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class Andariel : Enemy
    {
        public Andariel() 
        {
            this.name = "Andariel";
            this.LifePoints += 1000;
            this.PhysicalAttack += 30;
            this.Exp = 500;
            this.Gold = 200;
        }
        public override void stats()
        {
            Console.WriteLine(this.name);
            base.stats();
        }
    }
}
