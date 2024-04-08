using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class Merchant : Beings
    {
        public int Gold { get; set; }
        public Merchant() 
        {
            this.Name = "Merchant";
        }
    }
}
