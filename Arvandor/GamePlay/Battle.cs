using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class Battle
    {
        public Dice battleDice { get; set; }

        public void attackCommand(SpiritTypes player, Enemy enemy, bool playerAttack)
        {
            if(playerAttack)
            {
                Console.WriteLine(player.Name + " attack!");
                enemy.getDamage(player.PhisicalAttack(this.battleDice.attackDice()));
                if(battleDice.criticDice() >= 10)
                {
                    Console.WriteLine("Critic Atack!");
                    enemy.getDamage(10);
                }
            }
            else
            {
                Console.WriteLine(enemy.name + " attakc!");
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
                player.PhysicalDefense += player.PhysicalDefense / 2;
            }
            else
            {
                enemy.PhysicalDefense += enemy.PhysicalDefense / 2;
            }
        }
        public bool battleOrder(SpiritTypes player, Enemy enemy)
        {
            int[] di = new int[2];
            this.battleDice = new Dice;
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("Shift draw");
            Console.ResetColor();
            for(int x = 0; x < 2; x++)
            {
                di[x] = this.battleDice.randomDice(6);
            }
            Console.WriteLine(player.Name + ": " + di[0]);
            Console.WriteLine(enemy.name + ": " + di[1]);
            if (di[0] > di[1])
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
