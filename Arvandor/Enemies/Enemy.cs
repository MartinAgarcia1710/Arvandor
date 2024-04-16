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
            
            this.LifePoints = this.Level * 50;
            this.Life = this.LifePoints;
            this.ManaPoints = this.Level * 10;
            this.Mana = this.ManaPoints;
            this.PhysicalDefense = this.Level * 10;
            this.PhysicalAttack = this.Level * 10;
            this.MagicAttack = this.Level * 10;
            this.MagicDefense = this.Level * 10;
            this.Speed = this.Level * 10;
            
        }
        
        public Item dropItem()
        {
            Random random = new Random();
            Item it = new Item();

            return it;
        }
        
        public int getRandomEnemy(int count)
        {
            Random rand = new Random();
            int x = rand.Next(count);

            return x;
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
        public void restoreHP()
        {
            this.Life = this.LifePoints;
        }
        
    }
}
