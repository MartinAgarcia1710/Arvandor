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
        public int Exp { get; set; }
        public int Gold { get; set; }

        public Enemy() : base()
        {
            this.Level = 1;
            this.Life = this.Level * 50;
            this.LifePoints = this.Level * 10;
            this.ManaPoints = this.Level * 10;
            this.PhysicalDefense = this.Level * 10;
            this.PhysicalAttack = this.Level * 10;
            this.MagicAttack = this.Level * 10;
            this.MagicDefense = this.Level * 10;
            
        }
        
        public Item dropItem()
        {
            Random random = new Random();
            Item it = new Item();

            return it;
        }
        

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
