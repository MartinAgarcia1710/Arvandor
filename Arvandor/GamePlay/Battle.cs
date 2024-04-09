using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class Battle
    {
        public Dice battleDice { get; set; }
        public Dice battleDice2 { get; set; }

        public void attackCommand(SpiritTypes player, Enemy enemy, bool playerAttack)
        {
            int d;
            if(playerAttack)
            {
                Console.WriteLine(player.Name + " attack!");
                d = this.battleDice.attackDice();
                Console.WriteLine("Dice: " + d);
                enemy.getDamage(player.PhisicalAttack(this.battleDice.attackDice()));
                
                if(battleDice.criticDice() >= 10)
                {
                    
                    Console.WriteLine("Critic Atack!");
                    enemy.getDamage(10);
                }
            }
            else
            {
                Console.WriteLine(enemy.name + " attack!");
                d = this.battleDice.attackDice();
                Console.WriteLine("Dice: " + d);
                player.getDamage(enemy.PhisicalAttack(this.battleDice.attackDice()));
                if (battleDice.criticDice() >= 10)
                {
                    Console.WriteLine("Critic Atack!");
                    enemy.getDamage(10);
                }
            }
            
        }
        public void battleMenu(SpiritTypes player, Enemy enemy)
        {
            int op;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Battle Menu");
            Console.ResetColor();
            Console.WriteLine("1. Attack\n2.Items\n3. Defense\n");
            op = int.Parse(Console.ReadLine());

            switch(op)
            {
                case 1:
                    attackCommand(player, enemy, true);
                    break;
                case 2:
                    player.useItem();
                    break;
                case 3:
                    defenceCommand(player, enemy, true);
                    break;
            }
        }

        public void defenceCommand(SpiritTypes player, Enemy enemy, bool playerdefence)
        {
            if (playerdefence)
            {
                Console.WriteLine(player.Name + " DEFEND");
                player.PhysicalDefense += player.PhysicalDefense / 2;
            }
            else
            {
                Console.WriteLine(enemy.name + " DEFEND");
                enemy.PhysicalDefense += enemy.PhysicalDefense / 2;
            }
        }
        public bool battleOrder(SpiritTypes player, Enemy enemy)
        {
            //Problema con la creacion de los dados, al crear uno solo con new la semilla es la misma y por ende el mismo numero random
            //por lo que decidi agregar otro dado.
            int d1, d2;
            battleDice = new Dice();
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("Shift draw");
            Console.ResetColor();
            
            d1 = battleDice.randomDice(6);
            Console.WriteLine(player.Name + ": " + d1);
            Thread.Sleep(3000);
            battleDice2 = new Dice();
            d2 = battleDice2.randomDice(6);
            
            while (d1 == d2)
            {
                Console.WriteLine("Equals, again");
                d1 = battleDice.randomDice(6);
                d2 = battleDice2.randomDice(6);
            }
            
            Console.WriteLine(enemy.name + ": " + d2);
            if (d1 > d2)
            {
                Console.WriteLine(player.Name + " Start");
                return true;
            }
            else
            {
                Console.WriteLine(enemy.name + " Start");
                return false;
            }

        }
        public void enemyBattle(SpiritTypes player, Enemy enemy)
        {
            Random rand = new Random();
            int i = rand.Next(10);
            if(enemy.Life > enemy.LifePoints / 2)
            {
                attackCommand(player, enemy, false);
            }else if (enemy.Life < enemy.LifePoints / 2)
            {
                if(i > 4)
                {
                    attackCommand(player, enemy, false);
                }
                else
                {
                    defenceCommand(player, enemy, false);
                }
            }
        }
    }
}
