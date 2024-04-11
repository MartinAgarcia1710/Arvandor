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
            this.name = "Stone Face";
            this.Level = 30;
            this.MagicAttack += this.MagicAttack * this.Level + 100;
            this.MagicDefense += this.MagicDefense * this.Level;
            this.Speed += this.Speed * this.Level;
            this.LifePoints = this.LifePoints * this.Level + 100;
            this.PhysicalAttack *= this.Level + 100;
            this.PhysicalDefense *= this.Level;
            this.ManaPoints *= this.Level;
            this.Life = this.LifePoints;
            this.Mana = this.ManaPoints;
        }
        public override void stats()
        {
            Console.WriteLine(this.name);
            base.stats();
        }
    }
}
