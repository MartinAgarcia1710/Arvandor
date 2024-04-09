using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class Dice
    {
        private Random rand;
        public int valueDice { get; set; }

        public Dice()
        {
            rand = new Random();
        }

        public int randomDice(int c)
        {
            return rand.Next(1, c + 1);
            
        }
        public int attackDice()
        {
            int d = 6;
            
            return randomDice(d);
        }
        public int criticDice()
        {
            int d = 12;
            return randomDice(d);
        }
        public int defenseDice()
        {
            int d = 8;
            return randomDice(d);
        }
    }
}
