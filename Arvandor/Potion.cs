using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class Potion : Item
    {
        public string Color { get; set; }
        public Potion() : base() 
        {
            
        }

        public virtual int addPoints()
        {
            return 25;
        }
    }
}
