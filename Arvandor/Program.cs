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
            int op;
            GamePlay game = new GamePlay();
            
            Console.WriteLine("\t\tArvandor");
            Console.WriteLine("\t    Arshaalth's Quest");

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
