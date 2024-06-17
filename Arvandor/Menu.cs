using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Arvandor
{
    public static class Menu
    {
        public static string selection(string[] list, int op, int x, int y)
        {
            string select = string.Empty;
            int dest = 0;

            

                    
            for (int z = 0; z < list.Length; z++)
            {
 
                if (dest == op)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    
                    Console.WriteLine(list[z]);
                    //Console.ResetColor();
                    select = list[z];
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.CursorLeft = 0;
                    
                    Console.WriteLine(list[z]);

                }
                dest++;
            }

            return select;
        }





        /*
        public static string selection(string[] list, int op, int x, int y)
        {
            string select = string.Empty;
            int dest = 0;
            
                
            for (int z = 0; z < list.Length; z++)
            {
                if (dest == op)
                {
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine(list[z]);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    select = list[z];
                }
                else
                {
                    
                    Console.WriteLine(new string(' ', Console.WindowWidth));
                    Console.CursorLeft = 0;
                    Console.WriteLine(list[z]);
                }
                    dest++;
            }

            
            return select;

        }*/
    }
}
