using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class Enemy : Character
    {
        public string name;
        
        
        public int getLevel(int level)
        {
            if(level < 3)
            {
                return this.Level = 1;
            }
            else
            {
                return this.Level = level - 1;
            }
        }
        
    }
}
