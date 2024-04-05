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
        public int PhysicalAttack { get; set; }
        public int PhysicalDamage { get; set; }
        public int MagicAttack { get; set; }
        public int MagicDamage { get; set; }
        public int PhysicalDefense { get; set; }
        public int MagicDefense { get; set;}
        public int LifePoints { get; set; }
        public int ManaPoints { get; set; }
        public string Nationality { get; set; }
        public int Speed { get; set; }
        public int AttackSpeed { get; set;}

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
            this.Life += 10;
            this,Mana += 10;
        }

    }
}
