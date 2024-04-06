using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class HealthPotion : Potion
    {
        public int Add { get; set; } = 25;
        public HealthPotion() 
        {
            this.ID = 2;
            this.Name = "Health potion";
            this.Color = "Red";
        }
    }
}
