using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class StoneFace : Enemy
    {
        
        public StoneFace() 
        {
            this.name = "Stone Face";
            this.Level = 15;
            this.MagicAttack += this.MagicAttack * this.Level;
            this.MagicDefense += this.MagicDefense * this.Level;
            this.Speed += this.Speed * this.Level;
            this.LifePoints = this.LifePoints * this.Level + 100;
            this.PhysicalAttack *= this.Level + 50;
            this.PhysicalDefense *= this.Level + 50;
            this.ManaPoints *= this.Level;
            this.Life = this.LifePoints;
            this.Mana = this.ManaPoints;
        }
    }
}
