using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class Werewolf : SpiritTypes
    {
        public Werewolf() : base()
        {
            this.SpiritClass = "Werewolf";
            this.LifePoints += 5;
            this.PhysicalAttack += 5;
            this.PhysicalDefense += 5;
            this.Speed += 5;
            this.Life = this.LifePoints;
            this.Mana = this.ManaPoints;
        }
        public override void levelUp()
        {
            base.levelUp();
            this.Life += 5;
            this.PhysicalAttack += 5;
            this.PhysicalDefense += 5;
            this.Speed += 5;

        }
    }
}
