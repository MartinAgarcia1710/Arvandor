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
        public int Gold { get; set; }
        public List<Item> OwnItems { get; set; }
        //-------------------------------//
        public int ExpPoints { get; set; }
        public int PhysicalAttack { get; set; }
        public int MagicAttack { get; set; }
        public int PhysicalDefense { get; set; }
        public int MagicDefense { get; set;}
        public int LifePoints { get; set; }
        public int ManaPoints { get; set; }
        public string Nationality { get; set; }
        public int Speed { get; set; }
       

        public Character()
        {
            this.Level = 1;
        }
        public virtual string hello()
        {
            return "Hola soy un personaje ";
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

    }
}
