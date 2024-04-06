using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class SpiritTypes : Character
    {
        public int Gold { get; set; }
        public int ExpPoints { get; set; }
        public int PointsToNextLevel { get; set; }
        public string SpiritClass { get; set; }
        public SpiritTypes() 
        {
            this.LifePoints = 30;
            this.ManaPoints = 10;
            this.MagicDefense = 10;
            this.MagicAttack = 10;
            this.PhysicalAttack = 10;
            this.PhysicalDefense = 10;
            this.Speed = 10;
            this.ExpPoints = 0;
            this.Life = this.LifePoints;
            this.Mana = this.ManaPoints;
            this.PointsToNextLevel = this.Level * 50;
        }
        public virtual void levelUp()
        {
            this.Level += 1;
            this.LifePoints += 10;
            this.ManaPoints += 10;
            this.MagicAttack += 10;
            this.PhysicalAttack += 10;
            this.PhysicalDefense += 10;
            this.MagicDefense += 10;
        }
    }
}
