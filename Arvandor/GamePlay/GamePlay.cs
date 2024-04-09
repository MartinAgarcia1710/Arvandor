﻿using System;
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
        public void intro()
        {
            Console.WriteLine("Arvandor is in danger. Evil forces came from another world to destroy everything.");
            Console.WriteLine("Many attempts to eradicate them by the king failed and there is no hope.");
            Console.WriteLine("An ancient order of warrior returned from the ashes by the invocation of an unknown old man");
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("This old man found an old book that talked about this order and what to call them");
            Console.WriteLine("the invocation brings to life the spirits of ancient warriors who take possession of living");
            Console.WriteLine("beings...");
            
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
            Console.WriteLine("What's your name?");
            this.player.Name = Console.ReadLine();
        }

        public void tutorial()
        {
            Console.WriteLine("For now you are weak, so you must deal low level monster to increase your skills");
            Console.WriteLine("Then you will be strong to defeact powerful bosses.");
            Console.WriteLine("First of all, you have a menu to choose your action. You can train and grow up your level");
            Console.WriteLine("facing up different random enemies and them you can choose a boss to fight.");
            Console.WriteLine("Don't forget to heal whith potions between battles.");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("\t\tBattles");
            Console.WriteLine("The best way to grow up your level and skills. Battles are confrontations in which you must");
            Console.WriteLine("roll two dice. Some enemies could drop gold and items that can be useful to you in the future");
            Console.WriteLine("In battles you can attack or (if you are in the correct level) use your special ability");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("\t\tPotions");
            Console.WriteLine("You can obtain them from enemies who drops items when you win a battle");
            Console.WriteLine("There are two types of potions:");
            Console.WriteLine("Life Potion: restores 25 health points");
            Console.WriteLine("Mana Potion: restores 25 mana points");
            Console.WriteLine("BECARFUL, YOU CAN ONLY USE POTIONS WHEN YOU ARE OUT OF BATTLE");
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
        public void battle()
        {
            int t = 0;
            Battle b1 = new Battle();
            Enemy e1 = new Enemy();
            e1 = enemyList[e1.getRandomEnemy(enemyList.Count)];
            bool tu = b1.battleOrder(this.player, e1);
            head();
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
                Console.ReadKey();
                }
                t++;
            }
        }
        /*
        public void randomBattle()
        {
            int[] dice = new int[2];
            Random rand = new Random();
            int getEnemy = rand.Next(4);
            Enemy e1 = new Enemy();
            e1 = enemyList[getEnemy];
            Console.WriteLine("You fight with " + e1.name + " Level: " + e1.Level);
            Console.WriteLine("Draw turn");

            for (int x = 0; x < 2; x++)
            {
                dice[x] = rand.Next(6) + 1;
            }
            
            while (dice[0] == dice[1])
            {
                Console.WriteLine("SON IGUALES");
                for (int x = 0; x < 2; x++)
                {
                    dice[x] = rand.Next(6) + 1;
                }
            }
            
            Console.WriteLine("Player: " + dice[0]);
            Console.WriteLine(e1.name + ": " + dice[1]);
            
            bool bat = true;
            while(bat) 
            {
                Console.Clear();
                head();
                Console.WriteLine("START");
                Console.WriteLine(this.player.Name + " atack!");
                dice[0] = rand.Next(6) + 1;
                Console.WriteLine("Dice:" + dice[0]);
                int dam = this.player.PhisicalAttack(dice[0]);
                Console.WriteLine("Damage: " + dam);
                e1.getDamage(dam);
                if(e1.Life <= 0)
                {
                    Console.WriteLine("Enemy die");
                    bat = false;
                    this.player.winBattle(e1.Exp, e1.Gold);
                    return;
                }

                Console.WriteLine(e1.name + " atack!");
                dice[1] = rand.Next(6) + 1;
                Console.WriteLine("Dice:" + dice[1]);
                dam = e1.PhisicalAttack(dice[1]);
                Console.WriteLine("Damage: " + dam);
                this.player.getDamage(dam);
                if (this.player.Life <= 0)
                {
                    Console.WriteLine("You die");
                    System.Environment.Exit(-1);
                    bat = false;
                    return;
                }


                Console.ReadKey();
            }
        }
        */
        public void stageMenu()
        {
            Console.Clear();
            head();
            int op;
            while(true) { 
            Console.WriteLine("Menu");
            Console.WriteLine("1. Battle\n2. Items\n3. Boss\n4. Save\n5. Quit");
            op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                        battle();
                    //randomBattle();
                    break;
                case 2:
                    this.player.useItem();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
            }
        }
    }
}
