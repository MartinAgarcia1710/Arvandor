﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class ManaPotion : Potion
    {
        public int add { get; set; } = 25;
        public ManaPotion() : base() 
        {
            this.ID = 1;
            this.Name = "Mana potion";
            this.Color = "Blue";
            this.SellPrice = 25;
            this.BuyPrice = 50;
        }

        public override void use()
        {
            
        }
    }
}
