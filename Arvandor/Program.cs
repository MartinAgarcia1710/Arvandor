using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
namespace Arvandor
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

           





            int x;
            int y;
            int counter = 0;
            bool loop = true;
            ConsoleKeyInfo k;

            string[] principalOptions = new string[]
            {
                "Play",
                "Help",
                "Load",
                "Quit"
            };
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            
            int TitlePositionX = 25;
            int TitlePositionY = 5;
            int op;
            GamePlay game = new GamePlay();
            
            Console.SetCursorPosition(TitlePositionX, TitlePositionY);
            Console.WriteLine("░█████╗░ ██████╗░ ██╗░░░██╗ ░█████╗░ ███╗░░██╗ ██████╗░ ░█████╗░ ██████╗░");
            Console.SetCursorPosition(TitlePositionX, TitlePositionY + 1);
            Console.WriteLine("██╔══██╗ ██╔══██╗ ██║░░░██║ ██╔══██╗ ████╗░██║ ██╔══██╗ ██╔══██╗ ██╔══██╗");
            Console.SetCursorPosition(TitlePositionX, TitlePositionY + 2);
            Console.WriteLine("███████║ ██████╔╝ ╚██╗░██╔╝ ███████║ ██╔██╗██║ ██║░░██║ ██║░░██║ ██████╔╝");
            Console.SetCursorPosition(TitlePositionX, TitlePositionY + 3);
            Console.WriteLine("██╔══██║ ██╔══██╗ ░╚████╔╝░ ██╔══██║ ██║╚████║ ██║░░██║ ██║░░██║ ██╔══██╗");
            Console.SetCursorPosition(TitlePositionX, TitlePositionY + 4);
            Console.WriteLine("██║░░██║ ██║░░██║ ░░╚██╔╝░░ ██║░░██║ ██║░╚███║ ██████╔╝ ╚█████╔╝ ██║░░██║");
            Console.SetCursorPosition(TitlePositionX, TitlePositionY + 5);
            Console.WriteLine("╚═╝░░╚═╝ ╚═╝░░╚═╝ ░░░╚═╝░░░ ╚═╝░░╚═╝ ╚═╝░░╚══╝ ╚═════╝░ ░╚════╝░ ╚═╝░░╚═╝");
            Console.SetCursorPosition(TitlePositionX - 10, TitlePositionY + 7);
            Console.WriteLine("  ___              _                    _  _    _     _       _____                    _   ");
            Console.SetCursorPosition(TitlePositionX - 10, TitlePositionY + 8);
            Console.WriteLine(" / _ \\            | |                  | || |  | |   ( )     |  _  |                  | | ");
            Console.SetCursorPosition(TitlePositionX - 10, TitlePositionY + 9);
            Console.WriteLine("/ /_\\ \\ _ __  ___ | |__    __ _   __ _ | || |_ | |__ |/ ___  | | | | _   _   ___  ___ | |_");
            Console.SetCursorPosition(TitlePositionX - 10, TitlePositionY + 10);
            Console.WriteLine("|  _  || '__|/ __|| '_ \\  / _` | / _` || || __|| '_ \\  / __| | | | || | | | / _ \\/ __|| __|");
            Console.SetCursorPosition(TitlePositionX - 10, TitlePositionY + 11);
            Console.WriteLine("| | | || |   \\__ \\| | | || (_| || (_| || || |_ | | | | \\__ \\ \\ \\/' /| |_| ||  __/\\__ \\| |_ ");
            Console.SetCursorPosition(TitlePositionX - 10, TitlePositionY + 12);
            Console.WriteLine("\\_| |_/|_|   |___/|_| |_| \\__,_| \\__,_||_| \\__||_| |_| |___/  \\_/\\_\\ \\__,_| \\___||___/ \\__|");
            Console.SetCursorPosition(TitlePositionX - 8, TitlePositionY + 13);
            Console.WriteLine("                                                                                           ");
            Console.SetCursorPosition(TitlePositionX - 5, TitlePositionY + 14);
            
            Console.SetCursorPosition(TitlePositionX + 30, TitlePositionY + 16);
            Console.WriteLine("Push a button");
           
            Console.ReadKey();
            Console.Clear();


            x = Console.CursorLeft; 
            y = Console.CursorTop;
            int prueba = 0;
            string selOp = Menu.selection(principalOptions, counter, 30, 10);
            while (loop)
            {
                while ((k = Console.ReadKey(true)).Key != ConsoleKey.Enter)
                {
                    switch(k.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (counter == principalOptions.Length - 1)
                            {
                                continue;
                            }
                            counter++;
                            
                            break;
                        case ConsoleKey.UpArrow: 
                            if(counter == 0)
                            {
                                continue;
                            }
                            counter--;
                            break;
                        case ConsoleKey.Enter:
                            game.selectCharacter();
                            break;
                        default: 
                            break;
                    }

                    Console.CursorLeft = x; 
                    Console.CursorTop = y;
            
                    selOp = Menu.selection(principalOptions, counter, 30, 10);
                }
            }

            //Console.WriteLine("╔■═■══════════╗\r\n║   1. Play   ║\n║   2. Help   ║\n║   3. Load   ║\n║   4. Quit   ║\r\n╚══════════■═■╝");
            
            
            
            
            
            //Console.WriteLine("1. Play\n2. Help\n3. Load\n4. Quit");
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
