﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class Vampire : SpiritTypes
    {
        public Vampire() : base()
        {
            this.SpiritClass = "Vampire";
            this.ManaPoints += 5;
            this.MagicAttack += 5;
            this.MagicDefense += 5;
            this.Speed += 5;
            this.Life = this.LifePoints;
            this.Mana = this.ManaPoints;
        }
        public override void levelUp()
        {
            base.levelUp();
            this.ManaPoints += 5;
            this.MagicAttack += 5;
            this.MagicDefense += 5;
            this.Speed += 5;
        }
    }
}