using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class SilverWitch : Enemy
    {
        public SilverWitch() : base()
        {
            this.name = "Silver Witch";
            this.Level = 20;
            this.MagicAttack += this.MagicAttack * this.Level + 50;
            this.MagicDefense += this.MagicDefense * this.Level + 50;
            this.Speed += this.Speed * this.Level + 50;
            this.LifePoints = this.LifePoints * this.Level - 100;
            this.PhysicalAttack *= this.Level;
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
