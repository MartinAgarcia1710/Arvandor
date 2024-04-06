using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class Item
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public int getItem(int n)
        {
            
            Random r = new Random();
            n = r.Next();
            return n; 
        }
        public virtual void use()
        {

        }
        public Item()
        {

        }
    }
}
