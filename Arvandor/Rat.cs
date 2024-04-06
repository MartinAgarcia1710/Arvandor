using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class Rat : Enemy
    {
        public Rat()
        {
            this.name = "Rat";
            this.PhysicalAttack += 10;
            this.PhysicalAttack += 10;
        }
    }
}
