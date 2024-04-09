using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class SpiritTypes : Character
    {
        public int Gold { get; set; }
        public int ExpPoints { get; set; }
        public int PointsToNextLevel { get; set; }
        public string SpiritClass { get; set; }
        public SpiritTypes() 
        {
            this.OwnItems = new List<Item>();
            this.LifePoints = 3000;
            this.ManaPoints = 20;
            this.MagicDefense = 10;
            this.MagicAttack = 10;
            this.PhysicalAttack = 10;
            this.PhysicalDefense = 10;
            this.Speed = 10;
            this.ExpPoints = 0;
            this.Life = this.LifePoints;
            this.Mana = this.ManaPoints;
            this.PointsToNextLevel = this.Level * 50;
            ManaPotion mp = new ManaPotion();
            HealthPotion hp = new HealthPotion();
            this.OwnItems.Add(mp);
            this.OwnItems.Add(hp);
            
        }
        public virtual void levelUp()
        {
            this.Level += 1;
            this.LifePoints += 10;
            this.ManaPoints += 10;
            this.MagicAttack += 10;
            this.PhysicalAttack += 10;
            this.PhysicalDefense += 10;
            this.MagicDefense += 10;
        }
        public virtual void useItem()
        {
            int op;
            int n = 1;
            Console.WriteLine("Items");
            foreach (Item item in this.OwnItems)
            {
                Console.WriteLine(n + ". " + item.Name);
                n++;
            }
            op = int.Parse(Console.ReadLine());

            switch (this.OwnItems[op - 1].ID)
            {
                case 1:
                    this.manaRech();
                    this.OwnItems.RemoveAt(op - 1);
                    break;
                case 2:
                    this.healthRech();
                    this.OwnItems.RemoveAt(op - 1);
                    break;
                case 3:
                    break;
            }
        }
        public void manaRech()
        {
            this.Mana += 25;
            if(this.Mana > this.ManaPoints) 
            {
                this.Mana = this.ManaPoints;
            }
        }

        public void healthRech()
        {
            this.Life += 25;
            if (this.Life > this.LifePoints)
            {
                this.Life = this.LifePoints;
            }
        }
        public virtual void winBattle(int exp, int gold)
        {
            Console.WriteLine("Expe won: " + exp);
            Console.WriteLine("Gold won: " + gold);
            this.ExpPoints += exp;
            if(this.ExpPoints > this.PointsToNextLevel)
            {
                this.levelUp();
                this.PointsToNextLevel = this.Level * 50;
                this.ExpPoints = 0;
            }
            this.Gold += gold;

        }
    }
}
