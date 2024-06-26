﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class Orc : SpiritTypes
    {
        public Orc() : base() 
        {
            this.SpiritClass = "Orc";
            this.LifePoints += 10;
            this.PhysicalAttack += 10;
            this.PhysicalDefense += 10;
            this.Life = this.LifePoints;
            this.Mana = this.ManaPoints;
            this.abilityName = "Brute attack";
        }
        public override void stats()
        {
            Console.WriteLine(this.SpiritClass);
            base.stats();
        }
        public override void levelUp() 
        {
            base.levelUp();
            //Los orcos tienen como bonificacion subir 5 puntos mas de energia, por lo que 
            //uso el mismo metodo base de level up y le sumo 5 mas.
            this.Life += 5;
            this.PhysicalAttack += 5;
            this.PhysicalDefense += 5;

        }
    }
}
