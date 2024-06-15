using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 30;
            Console.WindowWidth = 73;
            int op;
            GamePlay game = new GamePlay();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.CursorVisible = false;
            
            Console.WriteLine("░█████╗░ ██████╗░ ██╗░░░██╗ ░█████╗░ ███╗░░██╗ ██████╗░ ░█████╗░ ██████╗░\r\n██╔══██╗ ██╔══██╗ ██║░░░██║ ██╔══██╗ ████╗░██║ ██╔══██╗ ██╔══██╗ ██╔══██╗\r\n███████║ ██████╔╝ ╚██╗░██╔╝ ███████║ ██╔██╗██║ ██║░░██║ ██║░░██║ ██████╔╝\r\n██╔══██║ ██╔══██╗ ░╚████╔╝░ ██╔══██║ ██║╚████║ ██║░░██║ ██║░░██║ ██╔══██╗\r\n██║░░██║ ██║░░██║ ░░╚██╔╝░░ ██║░░██║ ██║░╚███║ ██████╔╝ ╚█████╔╝ ██║░░██║\r\n╚═╝░░╚═╝ ╚═╝░░╚═╝ ░░░╚═╝░░░ ╚═╝░░╚═╝ ╚═╝░░╚══╝ ╚═════╝░ ░╚════╝░ ╚═╝░░╚═╝");

            

            
            Console.WriteLine("\t    Arshaalth's Quest");

            Console.WriteLine("╔■═■══════════╗\r\n║   1. Play   ║\n║   2. Help   ║\n║   3. Load   ║\n║   4. Quit   ║\r\n╚══════════■═■╝");
            Console.WriteLine("1. Play\n2. Help\n3. Load\n4. Quit");
            op = int.Parse(Console.ReadLine());
            while(true)
            {

                switch (op)
                {
                    case 1:
                        //game.intro();
                        game.selectCharacter();
                        //game.tutorial();
                        game.stageMenu();
                        break;

                    case 2:
                        break;
                    case 3:
                        game.continueGame();
                        game.stageMenu();
                        break;
                    case 4:
                        System.Environment.Exit(0);
                        break;
                }
                Console.WriteLine("1. Play\n2. Help\n3. Load\n4. Quit");
                op = int.Parse(Console.ReadLine());
            }
            
        }
    }
}
