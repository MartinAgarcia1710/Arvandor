﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class GiantSpider : Enemy
    {
        public GiantSpider()
        {
            this.name = "Giant Spider";
            this.PhysicalDefense += 10;
            this.MagicDefense += 10;
            
        }
    }
}