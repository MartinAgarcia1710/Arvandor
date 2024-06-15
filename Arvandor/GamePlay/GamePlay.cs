using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    
    internal class GamePlay
    {
        private GameSaveLoad gs = new GameSaveLoad();
        private Shop shop = new Shop();
        private SpiritTypes player;
        private List<Enemy> enemyList = new List<Enemy>() { 
            new GiantSpider(),
            new Goblin(),
            new Zombie(),
            new Rat()
        };

        public void head()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Player: " + this.player.Name + "|" + this.player.SpiritClass + " |Lvl: " + this.player.Level);
            Console.WriteLine("Life: " + this.player.Life + "/" + this.player.LifePoints);
            Console.WriteLine("Mana: " + this.player.Mana + "/" + this.player.ManaPoints);
            Console.WriteLine("Gold: " + this.player.Gold);
            Console.WriteLine("Experience: " + this.player.ExpPoints + "/" + this.player.PointsToNextLevel);
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
        }
        public void enemyHead(Enemy enemy)
        {      
            Console.WriteLine("Enemy: " + enemy.name + "| Lvl: " + enemy.Level);
            Console.WriteLine("Life: " + enemy.Life + "/" + enemy.LifePoints);
            Console.WriteLine("Mana: " + enemy.Mana + "/" + enemy.ManaPoints);
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
        }
        public void intro()
        {
            Console.WriteLine("Arvandor is in danger. Evil forces came from another world to destroy everything.");
            Console.WriteLine("Many attempts to eradicate them by the king failed and there is no hope.");
            Console.WriteLine("An ancient order of warrior returned from the ashes by the invocation of an unknown old man");
            Console.WriteLine("But... In the process they had changes, strange mutations");
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("This old man found an old book that talked about this order and what to call them");
            Console.WriteLine("the invocation brings to life the spirits of ancient warriors who take possession of living");
            Console.WriteLine("beings. The combination of these spirits with new bodies produced hybrid people.");
            
        }

        public void selectCharacter() 
        {
            
            this.player = new SpiritTypes();
            int op;
            int gender;
            Console.WriteLine("\tCharacter selection");

            Console.WriteLine("Choose gender");
            Console.WriteLine("1. Female\n2. Male");
            gender = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose spirit type");
            Console.WriteLine("1. Vampire\n2. Werewolf\n3. Orc");
            op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    this.player = new Vampire();       
                    break;
                case 2:
                    this.player = new Werewolf();
                    break;
                case 3:
                    this.player = new Orc();
                    break;
            }
            this.player.stats();
            Console.WriteLine("Press 'Y' to confirm " + this.player.SpiritClass);
            char con = char.Parse(Console.ReadLine());
            if(con == 'Y' || con == 'y')
            {
                Console.WriteLine("What's your name?");
                this.player.Name = Console.ReadLine();
            }
            else
            {
                selectCharacter();
            }
        }

        public void tutorial()
        {
            Console.WriteLine("For now you are weak, so you must deal low level monster to increase your skills");
            Console.WriteLine("Then you will be strong to defeact powerful bosses.");
            Console.WriteLine("First of all, you have a menu to choose your action. You can train and grow up your level");
            Console.WriteLine("facing up different random enemies and them you can choose a boss to fight.");
            Console.WriteLine("Don't forget to heal whith potions between battles.");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("\n\t\tBattles");
            Console.WriteLine("The best way to grow up your level and skills. Battles are confrontations in which you must");
            Console.WriteLine("roll two dice. Some enemies could drop gold and items that can be useful to you in the future");
            Console.WriteLine("In battles you can attack, take defence or use items to recover");
            Console.WriteLine("When you grow to level 6 you can use the special ability. Each Spirit Type has a diferent one");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("\n\t\tPotions");
            Console.WriteLine("You can obtain them from enemies who drops items when you win a battle or you can buy at shop");
            Console.WriteLine("There are two types of potions:");
            Console.WriteLine("Life Potion: restores 25 health points");
            Console.WriteLine("Mana Potion: restores 25 mana points");
            Console.WriteLine("\n\t\tShop");
            Console.WriteLine("In the shop you can boy potions to restore Health and Mana with gold that enemies drop in battles");
            Console.WriteLine("------------------------------------------------------------------------------------------");
        }
        public void listItems()
        {
            int op;
            Console.WriteLine("\t\tITEMS");
            foreach (Item item in this.player.OwnItems)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("\n\tSelect Item");
            op = int.Parse(Console.ReadLine());

        }
        public void continueGame()
        {
            //this.player = this.gs.loadGame();
        }

        public void battle()
        {
            int round = 1;
            int t = 0;
            Battle b1 = new Battle();
            Enemy e1 = new Enemy();
            e1 = enemyList[e1.getRandomEnemy(enemyList.Count)];
            bool tu = b1.battleOrder(this.player, e1);
            Console.Clear();
            head();
            enemyHead(e1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("BATTLE");
            Console.WriteLine("You fight with " + e1.name);
            Console.ResetColor();
            if(tu)
            {
                t = 0;
            }
            else
            {
                t = 1;
            }

            while (true)
            {  
                head();
                enemyHead(e1);
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Round " + round);
                Console.ResetColor();
                
                if(t % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("JUEGA PERSONAJE");
                    Console.ResetColor();
                    b1.battleMenu(this.player, e1);
                    if(e1.Life <= 0)
                    {
                        Console.WriteLine("Enemy die");
                        this.player.winBattle(e1.Exp, e1.Gold);
                        //
                        e1.restoreHP();
                        return;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("JUEGA ENEMIGO");
                    Console.ResetColor();
                    b1.enemyBattle(this.player, e1);
                    if (this.player.Life <= 0)
                    {
                        Console.WriteLine(this.player.Name + " die");
                        return;
                    }
                }
                else
                {
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("JUEGA ENEMIGO");
                    Console.ResetColor();
                    b1.enemyBattle(this.player, e1);
                    if(this.player.Life <= 0)
                    {
                        Console.WriteLine(this.player.Name + " die");
                        return;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("JUEGA PERSONAJE");
                    Console.ResetColor();
                    b1.battleMenu(this.player, e1);
                    if (e1.Life <= 0)
                    {
                        Console.WriteLine("Enemy die");
                        this.player.winBattle(e1.Exp, e1.Gold);
                        e1.restoreHP();
                        return;
                    }
                }
                Console.WriteLine("Round end, press to continue");
                Console.ReadKey();
                Console.Clear();
                round++;
            }
        }
        public void bossBattle(SpiritTypes player)
        {
            int t = 0;
            int round = 1;
            Battle b1 = new Battle();
            Enemy e1 = new Enemy();
            e1 = b1.bossSelect(player);
            Console.WriteLine("You fight with " + e1.name);
            bool tu = b1.battleOrder(this.player, e1);
            head();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("BATTLE");
            Console.WriteLine("You fight with " + e1.name);
            Console.ResetColor();
            if (tu)
            {
                t = 0;
            }
            else
            {
                t = 1;
            }

            while (true)
            {
                head();
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Round " + round);
                Console.ResetColor();

                if (t % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("JUEGA PERSONAJE");
                    Console.ResetColor();
                    b1.battleMenu(this.player, e1);
                    if (e1.Life <= 0)
                    {
                        Console.WriteLine("Enemy die");
                        this.player.winBattle(e1.Exp, e1.Gold);
                        this.player.bossCounter++; 
                        return;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("JUEGA ENEMIGO");
                    Console.ResetColor();
                    b1.enemyBattle(this.player, e1);
                    if (this.player.Life <= 0)
                    {
                        Console.WriteLine(this.player.Name + " die");
                        return;
                    }
                }
                else
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("JUEGA ENEMIGO");
                    Console.ResetColor();
                    b1.enemyBattle(this.player, e1);
                    if (this.player.Life <= 0)
                    {
                        Console.WriteLine(this.player.Name + " die");
                        return;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("JUEGA PERSONAJE");
                    Console.ResetColor();
                    b1.battleMenu(this.player, e1);
                    if (e1.Life <= 0)
                    {
                        Console.WriteLine("Enemy die");
                        this.player.winBattle(e1.Exp, e1.Gold);
                        this.player.bossCounter++;
                        return;
                    }
                }
                Console.WriteLine("Round end, press to continue");
                Console.ReadKey();
                Console.Clear();
                round++;
            }
        }
        public void stageMenu()
        {
            Console.Clear();
            head();
            int op;
            while(true) { 
            Console.WriteLine("Menu");
            Console.WriteLine("1. Battle\n2. Items\n3. Boss\n4. Shop\n5. Save\n6. Quit");
            op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                        battle();
                    break;
                case 2:
                    this.player.useItem();
                    break;
                case 3:
                    bossBattle(this.player);
                    break;
                case 4:
                    this.shop.shopMenu(player);
                    break;
                case 5:
                        //this.gs.checkExistDataBase(player);
                    break;
                case 6:
                    return;
            }
            }
        }
    }
}
