using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class Character : Beings
    {
        //-------------------------------//
        public int Level { get; set; }
        public int Life { get; set; }
        public int Mana { get; set; }
        public int KillCount { get; set; }
        public List<Item> OwnItems { get; set; }
        //-------------------------------//
        
        public int PhysicalAttack { get; set; }
        public int MagicAttack { get; set; }
        public int PhysicalDefense { get; set; }
        public int MagicDefense { get; set;}
        public int LifePoints { get; set; }
        public int ManaPoints { get; set; }
        
        public int Speed { get; set; }
       

        public Character()
        {
            this.Level = 1;
        }
        
        public int PhisicalAttack(int dice)
        {
            int damage = (this.PhysicalAttack + dice) / 2;

            return damage;
        }
        public int magicalAttack(int dice)
        {
            int damage = (this.MagicAttack + dice) / 2;
            return damage;
        }
        public void getDamage(int damage)
        {
            this.Life -= damage;
            Console.WriteLine("Damage: " + damage);
        }
        public void showStandings()
        {
            Console.WriteLine(this.Name);
            Console.WriteLine("Level: " + this.Level);
            Console.WriteLine("Phisical attack: " + this.PhysicalAttack);
            Console.WriteLine("Magical attack: " + this.MagicAttack);
            Console.WriteLine("Phisical defence" + this.PhysicalDefense);
            Console.WriteLine("Magical defence: " + this.MagicDefense);
            Console.WriteLine("Speed: " + this.Speed);
            Console.WriteLine("Enemies kill: " + this.KillCount);

        }
        
    }
}
