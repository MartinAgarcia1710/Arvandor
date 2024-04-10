using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class Shop
    {
        public Merchant Merch { get; set; }

        public void shopMenu(SpiritTypes player)
        {
            int op;
            while (true)
            {
                Console.WriteLine("Welcome to my shop!");
                Console.WriteLine("1. Buy\n2. Sell\n3. Exit");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        buy(player);
                        break;
                    case 2:
                        sell(player);
                        break;
                    case 3:
                        return;
                }
            }
        }

        public void buy(SpiritTypes player)
        {
            int op;
            while (true)
            {

                Console.WriteLine("1. Health Potion........................$50");
                Console.WriteLine("2. Mana Potion..........................$50");
                Console.WriteLine("3. Return");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        HealthPotion hp = new HealthPotion();
                        if(player.Gold > 50)
                        {
                            player.OwnItems.Add(hp);
                            player.Gold -= 50;
                        }
                        else
                        {
                            Console.WriteLine("You have not enough gold to purchase");
                            return;
                        }
                        break;
                    case 2:
                        ManaPotion mp = new ManaPotion();
                        if(player.Gold > 50)
                        {
                            player.OwnItems.Add(mp);
                            player.Gold -= 50;
                        }
                        else
                        {
                            Console.WriteLine("You have not enough gold to purchase");
                            return;
                        }
                        break;
                    case 3:
                        return;
                }
            }

        }
        public void sell(SpiritTypes player)
        {
            int op;
            int co = 1;
            while (true)
            {

                foreach (Item item in player.OwnItems)
                {
                    Console.WriteLine(co + ". " + item.Name + "...........$" + item.SellPrice);
                    co++;
                }
                op = int.Parse (Console.ReadLine());
                int ig = player.OwnItems[op - 1].SellPrice;
                player.OwnItems.RemoveAt(op - 1);
                player.Gold += ig;
                return;
                //player.Gold += player.OwnItems[op - 1].SellPrice;

                
            }

        }
    }
}
