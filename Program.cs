﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Text_Based_Adventure_Game
{
    class Program
    {
        #region GlobalVariables
        static bool playing = true;
        static bool glitchMenu = true;
        #region Ascii
        static string dogAscii = @"
            |\_/|        D\___/\
            (0_0)         (0_o)
           ==(Y)==         (V)
----------(u)---(u)----oOo--U--oOo---
__|_______|_______|_______|_______|___";
        static string[] title = new string[] {@"



 ▄████████    ▄█    █▄       ▄████████  ▄█     ▄████████       ▄█    █▄     ▄████████        ▄▄▄▄███▄▄▄▄      ▄████████     ███         ███     
███    ███   ███    ███     ███    ███ ███    ███    ███      ███    ███   ███    ███      ▄██▀▀▀███▀▀▀██▄   ███    ███ ▀█████████▄ ▀█████████▄ 
███    █▀    ███    ███     ███    ███ ███▌   ███    █▀       ███    ███   ███    █▀       ███   ███   ███   ███    ███    ▀███▀▀██    ▀███▀▀██ 
███         ▄███▄▄▄▄███▄▄  ▄███▄▄▄▄██▀ ███▌   ███             ███    ███   ███             ███   ███   ███   ███    ███     ███   ▀     ███   ▀ 
███        ▀▀███▀▀▀▀███▀  ▀▀███▀▀▀▀▀   ███▌ ▀███████████      ███    ███ ▀███████████      ███   ███   ███ ▀███████████     ███         ███     
███    █▄    ███    ███   ▀███████████ ███           ███      ███    ███          ███      ███   ███   ███   ███    ███     ███         ███     
███    ███   ███    ███     ███    ███ ███     ▄█    ███      ███    ███    ▄█    ███      ███   ███   ███   ███    ███     ███         ███     
████████▀    ███    █▀      ███    ███ █▀    ▄████████▀        ▀██████▀   ▄████████▀        ▀█   ███   █▀    ███    █▀     ▄████▀      ▄████▀   
                            ███    ███                                                                                                          

", @"




 ██████╗██╗  ██╗██████╗ ██╗███████╗    ██╗   ██╗███████╗    ███╗   ███╗ █████╗ ████████╗████████╗
██╔════╝██║  ██║██╔══██╗██║██╔════╝    ██║   ██║██╔════╝    ████╗ ████║██╔══██╗╚══██╔══╝╚══██╔══╝
██║     ███████║██████╔╝██║███████╗    ██║   ██║███████╗    ██╔████╔██║███████║   ██║      ██║   
██║     ██╔══██║██╔══██╗██║╚════██║    ╚██╗ ██╔╝╚════██║    ██║╚██╔╝██║██╔══██║   ██║      ██║   
╚██████╗██║  ██║██║  ██║██║███████║     ╚████╔╝ ███████║    ██║ ╚═╝ ██║██║  ██║   ██║      ██║   
 ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝╚══════╝      ╚═══╝  ╚══════╝    ╚═╝     ╚═╝╚═╝  ╚═╝   ╚═╝      ╚═╝   
   


", @"




 ██████ ██   ██ ██████  ██ ███████     ██    ██ ███████     ███    ███  █████  ████████ ████████ 
██      ██   ██ ██   ██ ██ ██          ██    ██ ██          ████  ████ ██   ██    ██       ██    
██      ███████ ██████  ██ ███████     ██    ██ ███████     ██ ████ ██ ███████    ██       ██    
██      ██   ██ ██   ██ ██      ██      ██  ██       ██     ██  ██  ██ ██   ██    ██       ██    
 ██████ ██   ██ ██   ██ ██ ███████       ████   ███████     ██      ██ ██   ██    ██       ██    
   



", @"

 ▄▄▄▄▄▄▄▄▄▄▄  ▄         ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄       ▄               ▄  ▄▄▄▄▄▄▄▄▄▄▄       ▄▄       ▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄ 
▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░▌             ▐░▌▐░░░░░░░░░░░▌     ▐░░▌     ▐░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌
▐░█▀▀▀▀▀▀▀▀▀ ▐░▌       ▐░▌▐░█▀▀▀▀▀▀▀█░▌ ▀▀▀▀█░█▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀       ▐░▌           ▐░▌ ▐░█▀▀▀▀▀▀▀▀▀      ▐░▌░▌   ▐░▐░▌▐░█▀▀▀▀▀▀▀█░▌ ▀▀▀▀█░█▀▀▀▀  ▀▀▀▀█░█▀▀▀▀ 
▐░▌          ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌     ▐░▌                 ▐░▌         ▐░▌  ▐░▌               ▐░▌▐░▌ ▐░▌▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌     
▐░▌          ▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌     ▐░▌     ▐░█▄▄▄▄▄▄▄▄▄         ▐░▌       ▐░▌   ▐░█▄▄▄▄▄▄▄▄▄      ▐░▌ ▐░▐░▌ ▐░▌▐░█▄▄▄▄▄▄▄█░▌     ▐░▌          ▐░▌     
▐░▌          ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░▌     ▐░░░░░░░░░░░▌         ▐░▌     ▐░▌    ▐░░░░░░░░░░░▌     ▐░▌  ▐░▌  ▐░▌▐░░░░░░░░░░░▌     ▐░▌          ▐░▌     
▐░▌          ▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀█░█▀▀      ▐░▌      ▀▀▀▀▀▀▀▀▀█░▌          ▐░▌   ▐░▌      ▀▀▀▀▀▀▀▀▀█░▌     ▐░▌   ▀   ▐░▌▐░█▀▀▀▀▀▀▀█░▌     ▐░▌          ▐░▌     
▐░▌          ▐░▌       ▐░▌▐░▌     ▐░▌       ▐░▌               ▐░▌           ▐░▌ ▐░▌                ▐░▌     ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌     
▐░█▄▄▄▄▄▄▄▄▄ ▐░▌       ▐░▌▐░▌      ▐░▌  ▄▄▄▄█░█▄▄▄▄  ▄▄▄▄▄▄▄▄▄█░▌            ▐░▐░▌        ▄▄▄▄▄▄▄▄▄█░▌     ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌     
▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌             ▐░▌        ▐░░░░░░░░░░░▌     ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌          ▐░▌     
 ▀▀▀▀▀▀▀▀▀▀▀  ▀         ▀  ▀         ▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀               ▀          ▀▀▀▀▀▀▀▀▀▀▀       ▀         ▀  ▀         ▀       ▀            ▀      
                                                                                                                                                               
", /*@"

 ▄▄·  ▄ .▄▄▄▄  ▪  .▄▄ ·      ▌ ▐·.▄▄ ·     • ▌ ▄ ·.  ▄▄▄· ▄▄▄▄▄▄▄▄▄▄
▐█ ▌▪██▪▐█▀▄ █·██ ▐█ ▀.     ▪█·█▌▐█ ▀.     ·██ ▐███▪▐█ ▀█ •██  •██  
██ ▄▄██▀▐█▐▀▀▄ ▐█·▄▀▀▀█▄    ▐█▐█•▄▀▀▀█▄    ▐█ ▌▐▌▐█·▄█▀▀█  ▐█.▪ ▐█.▪
▐███▌██▌▐▀▐█•█▌▐█▌▐█▄▪▐█     ███ ▐█▄▪▐█    ██ ██▌▐█▌▐█ ▪▐▌ ▐█▌· ▐█▌·
·▀▀▀ ▀▀▀ ·.▀  ▀▀▀▀ ▀▀▀▀     . ▀   ▀▀▀▀     ▀▀  █▪▀▀▀ ▀  ▀  ▀▀▀  ▀▀▀ 
",*/ @"




▄█▄     ▄  █ █▄▄▄▄ ▄█    ▄▄▄▄▄           ▄      ▄▄▄▄▄       █▀▄▀█ ██     ▄▄▄▄▀ ▄▄▄▄▀ 
█▀ ▀▄  █   █ █  ▄▀ ██   █     ▀▄          █    █     ▀▄     █ █ █ █ █ ▀▀▀ █ ▀▀▀ █    
█   ▀  ██▀▀█ █▀▀▌  ██ ▄  ▀▀▀▀▄       █     █ ▄  ▀▀▀▀▄       █ ▄ █ █▄▄█    █     █    
█▄  ▄▀ █   █ █  █  ▐█  ▀▄▄▄▄▀         █    █  ▀▄▄▄▄▀        █   █ █  █   █     █     
▀███▀     █    █    ▐                  █  █                    █     █  ▀     ▀      
         ▀    ▀                         █▐                    ▀     █                
                                        ▐                          ▀            


", @"

 ▄████▄   ██░ ██  ██▀███   ██▓  ██████     ██▒   █▓  ██████     ███▄ ▄███▓ ▄▄▄     ▄▄▄█████▓▄▄▄█████▓
▒██▀ ▀█  ▓██░ ██▒▓██ ▒ ██▒▓██▒▒██    ▒    ▓██░   █▒▒██    ▒    ▓██▒▀█▀ ██▒▒████▄   ▓  ██▒ ▓▒▓  ██▒ ▓▒
▒▓█    ▄ ▒██▀▀██░▓██ ░▄█ ▒▒██▒░ ▓██▄       ▓██  █▒░░ ▓██▄      ▓██    ▓██░▒██  ▀█▄ ▒ ▓██░ ▒░▒ ▓██░ ▒░
▒▓▓▄ ▄██▒░▓█ ░██ ▒██▀▀█▄  ░██░  ▒   ██▒     ▒██ █░░  ▒   ██▒   ▒██    ▒██ ░██▄▄▄▄██░ ▓██▓ ░ ░ ▓██▓ ░ 
▒ ▓███▀ ░░▓█▒░██▓░██▓ ▒██▒░██░▒██████▒▒      ▒▀█░  ▒██████▒▒   ▒██▒   ░██▒ ▓█   ▓██▒ ▒██▒ ░   ▒██▒ ░ 
░ ░▒ ▒  ░ ▒ ░░▒░▒░ ▒▓ ░▒▓░░▓  ▒ ▒▓▒ ▒ ░      ░ ▐░  ▒ ▒▓▒ ▒ ░   ░ ▒░   ░  ░ ▒▒   ▓▒█░ ▒ ░░     ▒ ░░   
  ░  ▒    ▒ ░▒░ ░  ░▒ ░ ▒░ ▒ ░░ ░▒  ░ ░      ░ ░░  ░ ░▒  ░ ░   ░  ░      ░  ▒   ▒▒ ░   ░        ░    
░         ░  ░░ ░  ░░   ░  ▒ ░░  ░  ░          ░░  ░  ░  ░     ░      ░     ░   ▒    ░        ░      
░ ░       ░  ░  ░   ░      ░        ░           ░        ░            ░         ░  ░                 
░                                              ░                                                     


" };

        #endregion
        #endregion
        static void Main(string[] args)
        {
            #region window debugging
            //Type("Window size: ");
            //Console.WriteLine($"{Console.WindowWidth}, {Console.WindowHeight}");
            //Thread.Sleep(500);
            //Type("Please maximise your screen.");
            //Type("Press enter when you have");
            //Console.ReadKey();
            //Console.WriteLine($"{Console.WindowWidth}, {Console.WindowHeight}");
            //int consoleWidth = int.Parse(Console.ReadLine());
            //int consoleHeight = int.Parse(Console.ReadLine());
            #endregion
            SetConsole(180, 48);
            SetTitle("Starting...");
            do
            {
                if (glitchMenu) TitleGlitch();
                else MainMenu();
            } while (playing);
            Exit();
            //Console.ReadKey();
        }
        static void SetConsole(int consoleWidth, int consoleHeight)
        {
            Console.WindowHeight = consoleHeight;
            Console.WindowWidth = consoleWidth;
        }
        static void MainMenu() //TitleGlitch is now the preferred sub-routine for the menus
        {
            ConsoleKey keyPress;
            SetTitle("Menu");
            Console.Clear();
            Spacing(2);
            WriteMiddle("", "Red", "[only glitched menu gets fancy ascii art >:)]");
            Spacing(1);
            Console.ForegroundColor = ConsoleColor.Green;
            WriteMiddle("", "Green", "WELCOME!");
            
            do
            {
                Spacing(1);
                WriteMiddle("t20", "", "Please choose a valid option:");
                #region Commented
                //WriteMiddle("", "", "[a]");
                //WriteMiddle("", "", "PLAY");
                //WriteMiddle("", "", "[b]");
                //WriteMiddle("", "", "OPTIONS");
                //WriteMiddle("", "", "[e]");
                //WriteMiddle("", "", "EXIT");
                #endregion
                WriteMiddle("", "Green", "[a] PLAY");
                WriteMiddle("", "Yellow", "[b] INFO / OPTIONS");
                WriteMiddle("", "Red", "[e] EXIT");
                keyPress = Console.ReadKey().Key;
            } while ((char) keyPress != 'A' && (char) keyPress != 'B' && (char) keyPress != 'E');
            #region Commented
            //while ((char)keyPress != 'A' && (char)keyPress != 'B' && (char)keyPress != 'E')
            //{
            //    Spacing(1);
            //    WriteMiddle("", "", "Please choose an option:");
            //    WriteMiddle("", "Red", "ERROR: INVALID INPUT");
            //    WriteMiddle("", "", "[a] PLAY");
            //    WriteMiddle("", "", "[b] OPTIONS");
            //    WriteMiddle("", "", "[e] EXIT");
            //    keyPress = Console.ReadKey().Key;
            //}
            #endregion
            switch ((char) keyPress)
            {
                case 'A':
                    Setup();
                    return;
                case 'B':
                    Options();
                    return;
                case 'E':
                    playing = false;
                    return;
                default:
                    WriteMiddle("t50", "Red", "ERROR: INVALID INPUT");
                    return;
            }
        }
        static void TitleGlitch()
        {
            SetTitle("In the menus");
            int current, previous;
            ConsoleKey keyPress;
            previous = 1;
            do
            {
                while (!Console.KeyAvailable)
                {
                    Random rnd = new Random();
                    do
                    {
                        current = rnd.Next(0, title.Length);
                    } while (current == previous);
                    Console.WriteLine(title[current]);
                    previous = current;

                    //Spacing(1);
                    Console.SetCursorPosition(0, 15);
                    Console.ResetColor();
                    Console.WriteLine("Please choose a valid option:");
                    #region Commented
                    //WriteMiddle("", "", "[a]");
                    //WriteMiddle("", "", "PLAY");
                    //WriteMiddle("", "", "[b]");
                    //WriteMiddle("", "", "OPTIONS");
                    //WriteMiddle("", "", "[e]");
                    //WriteMiddle("", "", "EXIT");
                    #endregion
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[a] PLAY");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[b] INFO / OPTIONS");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[e] EXIT");

                    Thread.Sleep(50);
                    Console.Clear();
                }
                keyPress = Console.ReadKey(true).Key;
                Console.ResetColor();
            } while (keyPress != ConsoleKey.A && keyPress != ConsoleKey.B && keyPress != ConsoleKey.E);
            switch ((char)keyPress)
            {
                case 'A':
                    Setup();
                    return;
                case 'B':
                    Options();
                    return;
                case 'E':
                    playing = false;
                    return;
                default:
                    WriteMiddle("t50", "Red", "ERROR: INVALID INPUT");
                    return;
            }
        }
        static void Game(string userJob, string userName, int userMorals)
        {
            string userMoralStr;

        }
        static void Setup()
        {
            int userMorals;
            Console.Clear();
            SetTitle("Playing");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(title[0]);
            Console.ResetColor();
            Type("Hello!");
            Wait(500);
            Type("This is a text based adventure game.");
            Console.WriteLine("\nBackstory:");
            Type2("You could be anything... ", 50);
            Wait(500);
            Type("Possibly a...", 50);
            Type2("Warrior, ");
            Wait(1000);
            Type2("Weapons Smith, ");
            Wait(1000);
            Type2("Archer");
            Type("...", 250);
            Wait(1000);
            Type2("What are you? A(n): ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string userJob = Console.ReadLine();
            Console.ResetColor();
            Wait(1000);
            Type2($"And what's your name, my good {userJob}?");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string userName = Console.ReadLine();
            Console.ResetColor();
            do
            {
                do
                {
                    Console.ResetColor();
                    Type($"And how do you see yourself morally, {userName}, on a scale of 1-17 (1 being evil, 17 being a hero)? (this will affect how NPC's interact with you)");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                } while (!int.TryParse(Console.ReadLine(), out userMorals));
            } while (userMorals > 17 || userMorals < 1) ;

            Game(userJob, userName, userMorals);
            //Console.ReadKey();
        }
        static void Options()
        {
            Console.Clear();
            SetTitle("Options");
            Spacing(1);
            Type("Welcome to the [information / options] section!");
            Spacing(2);
            Console.ForegroundColor = ConsoleColor.Green;
            Type("OPTIONS:");
            Console.ResetColor();
            if (glitchMenu) Console.WriteLine($"Menu: 'Glitched' Menu");
            if (!glitchMenu) Console.WriteLine($"Menu: Regular Menu");
            Spacing(1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Type("Controls:");
            Console.ResetColor();
            Console.WriteLine("[e] CHANGE MENU TYPE");
            Console.WriteLine("[ESC] EXIT\n");
            ConsoleKey keyPress = Console.ReadKey().Key;
            switch (keyPress)
            {
                case ConsoleKey.E:
                    glitchMenu = !glitchMenu;
                    Console.WriteLine($"\rGlitched menu: {glitchMenu}");
                    Thread.Sleep(500);
                    return;
                case ConsoleKey.Escape:
                    return;
            }
        }
        static void Type(string args, int delay = 20)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (i == args.Length-1) Console.WriteLine(args[i]);
                else Console.Write(args[i]);
                Thread.Sleep(delay);
            }
        }
        static void Type2(string args, int delay = 20)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Console.Write(args[i]);
                Thread.Sleep(delay);
            }
        }
        static void Exit()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            WriteCentre("t50", "Red", "Exitting...");
            Thread.Sleep(1000);
        }
        static void Spacing(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine("");
            }
        }
        static void SetTitle(string args)
        {
            //set title
            string Progressbar = $"Text Based Adventure Game: {args}";
            var title = "Text Based Adventure Game:";
            int temp = title.Length;
            while (true)
            {
                for (int i = temp; i < Progressbar.Length; i++)
                {
                    title += Progressbar[i];
                    Console.Title = title;
                    Thread.Sleep(50);
                }
                return;
            }
        }
        static void WriteMiddle(string type, string colour, string output)
        {
            
            if (colour == "") Console.ResetColor();
            else Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colour);

            int windowWidth = Console.WindowWidth;
            //Console.WriteLine(windowHeight);
            //Console.WriteLine(windowWidth);
            if (output.Length % 2 == 0) output += " ";
            int leftGap = (windowWidth - output.Length) / 2;
            var leftGapVar = "";
            for (int i = 0; i < leftGap; i++)
            {
                leftGapVar += " ";
            }
            
            Console.Write(leftGapVar);
            if (type == "")
            {
                Console.WriteLine(output);
                Console.ResetColor();
                return;
            }
            if (type[1] == 'T')
            {
                var delay = "";
                for (int i = 1; i < type.Length; i++)
                {
                    delay += type[i];
                }
                Type(output, int.Parse(delay));
            }
            else Console.WriteLine(output);
            Console.ResetColor();
        }
        static void WriteCentre(string type, string colour, string output)
        {
            int windowHeight = Console.WindowHeight;
            Spacing((windowHeight / 2) - 1);
            WriteMiddle(type, colour, output);
        }
        static void Wait(int delay)
        {
            Thread.Sleep(delay);
        }
    }
}