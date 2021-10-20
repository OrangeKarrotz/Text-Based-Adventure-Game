using System;
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
        static string[] userDetails = new string[4];
        #region Ascii
        static string dogAscii = @"
            |\_/|        D\___/\
            (0_0)         (0_o)
           ==(Y)==         (V)
----------(u)---(u)----oOo--U--oOo---
__|_______|_______|_______|_______|___";
        static string[] title = new string[] { @"

._______ ._______.___    .___    ._____.___ ._______  .______  .______  .___    
: __   / : .____/|   |   |   |   :         |: .___  \ : __   \ :      \ |   |   
|  |>  \ | : _/\ |   |   |   |   |   \  /  || :   |  ||  \____||   .   ||   |   
|  |>   \|   /  \|   |/\ |   |/\ |   |\/   ||     :  ||   :  \ |   :   ||   |/\ 
|_______/|_.: __/|   /  \|   /  \|___| |   | \_. ___/ |   |___\|___|   ||   /  \
            :/   |______/|______/      |___|   :/     |___|        |___||______/
                                               :                                
                                                                                
                                                                                
", @"

██████╗ ███████╗██╗     ██╗     ███╗   ███╗ ██████╗ ██████╗  █████╗ ██╗     
██╔══██╗██╔════╝██║     ██║     ████╗ ████║██╔═══██╗██╔══██╗██╔══██╗██║     
██████╔╝█████╗  ██║     ██║     ██╔████╔██║██║   ██║██████╔╝███████║██║     
██╔══██╗██╔══╝  ██║     ██║     ██║╚██╔╝██║██║   ██║██╔══██╗██╔══██║██║     
██████╔╝███████╗███████╗███████╗██║ ╚═╝ ██║╚██████╔╝██║  ██║██║  ██║███████╗
╚═════╝ ╚══════╝╚══════╝╚══════╝╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝
                                                                            
", @"

██████  ███████ ██      ██      ███    ███  ██████  ██████   █████  ██      
██   ██ ██      ██      ██      ████  ████ ██    ██ ██   ██ ██   ██ ██      
██████  █████   ██      ██      ██ ████ ██ ██    ██ ██████  ███████ ██      
██   ██ ██      ██      ██      ██  ██  ██ ██    ██ ██   ██ ██   ██ ██      
██████  ███████ ███████ ███████ ██      ██  ██████  ██   ██ ██   ██ ███████ 
                                                                            
                                                                            
", @"

  _______   ______   __       __       ___ __ __   ______   ______    ________   __          
/_______/\ /_____/\ /_/\     /_/\     /__//_//_/\ /_____/\ /_____/\  /_______/\ /_/\         
\::: _  \ \\::::_\/_\:\ \    \:\ \    \::\| \| \ \\:::_ \ \\:::_ \ \ \::: _  \ \\:\ \        
 \::(_)  \/_\:\/___/\\:\ \    \:\ \    \:.      \ \\:\ \ \ \\:(_) ) )_\::(_)  \ \\:\ \       
  \::  _  \ \\::___\/_\:\ \____\:\ \____\:.\-/\  \ \\:\ \ \ \\: __ `\ \\:: __  \ \\:\ \____  
   \::(_)  \ \\:\____/\\:\/___/\\:\/___/\\. \  \  \ \\:\_\ \ \\ \ `\ \ \\:.\ \  \ \\:\/___/\ 
    \_______\/ \_____\/ \_____\/ \_____\/ \__\/ \__\/ \_____\/ \_\/ \_\/ \__\/\__\/ \_____\/ 
                                                                                             
", @"

 ______     ______     __         __         __    __     ______     ______     ______     __        
/\  == \   /\  ___\   /\ \       /\ \       /\ '-./  \   /\  __ \   /\  == \   /\  __ \   /\ \       
\ \  __<   \ \  __\   \ \ \____  \ \ \____  \ \ \-./\ \  \ \ \/\ \  \ \  __<   \ \  __ \  \ \ \____  
 \ \_____\  \ \_____\  \ \_____\  \ \_____\  \ \_\ \ \_\  \ \_____\  \ \_\ \_\  \ \_\ \_\  \ \_____\ 
  \/_____/   \/_____/   \/_____/   \/_____/   \/_/  \/_/   \/_____/   \/_/ /_/   \/_/\/_/   \/_____/

", @"

.______    _______  __       __      .___  ___.   ______   .______          ___       __      
|   _  \  |   ____||  |     |  |     |   \/   |  /  __  \  |   _  \        /   \     |  |     
|  |_)  | |  |__   |  |     |  |     |  \  /  | |  |  |  | |  |_)  |      /  ^  \    |  |     
|   _  <  |   __|  |  |     |  |     |  |\/|  | |  |  |  | |      /      /  /_\  \   |  |     
|  |_)  | |  |____ |  `----.|  `----.|  |  |  | |  `--'  | |  |\  \----./  _____  \  |  `----.
|______/  |_______||_______||_______||__|  |__|  \______/  | _| `._____/__/     \__\ |_______|
                                                                                              
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
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(title[current]);
                    Console.ResetColor();
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
        static void Game()
        {
            string input, temp;
            int userMorals = int.Parse(userDetails[2]);
            Random rnd = new Random();
            int yearsExperience = rnd.Next(0, 30);
            Console.Clear();
            Console.WriteLine(title[0]);
            Console.SetCursorPosition(0, 15);
            Type2("Welcome to the game, ");
            Wait(500);
            Type($"{userDetails[0]}!");
            if (yearsExperience == 0) Type($"You are a(n) {userDetails[1]}, you've been working in Bellmoral for less than a year, and are still getting to grips with the town, but you feel like you've settled in {GetWord(userMorals, 'V')}.");
            else Type($"You are a(n) {userDetails[1]}, you've been working in Bellmoral for around {yearsExperience} years. You feel like you're a {GetWord(userMorals, 'N')} part of the village.");
            Type3(new string[] { "You find yourself in a ", "forest", ", do you want to go North [N], East [E], South [S], or West [W]?" }, 10, new string[] { "Gray", "Green", "Gray" });
            Console.WriteLine("");
            temp = Console.ReadLine();
            
        }
        static void Setup()
        {
            int userMorals, choice;
            
            Console.Clear();
            SetTitle("Playing");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(title[0]);
            Console.ResetColor();
            Type("Hello!");
            Wait(500);
            Type3(new string[] { "This is a ", "text based ", "adventure game", "." }, 20, new string[] { "Gray", "Cyan", "Green", "Gray" });
            Console.WriteLine("\n\nBackstory:");
            Type3(new string[] { "[1]", " Warrior ", "Stats: ", "Strength - 9, Agility - 5, Intelligence - 3, Charisma - 5" }, 2, new string[] { "White", "Red", "Green", "Yellow" });
            Console.WriteLine("");
            Type3(new string[] { "[2]", " Archer  ", "Stats: ", "Strength - 7, Agility - 7, Intelligence - 5, Charisma - 5" }, 2, new string[] { "White", "Cyan", "Green", "Yellow" });
            Console.WriteLine("");
            Type3(new string[] { "[3]", " Rogue   ", "Stats: ", "Strength - 3, Agility - 9, Intelligence - 7, Charisma - 1" }, 2, new string[] { "White", "Blue", "Green", "Yellow" });
            Console.WriteLine("");
            Type3(new string[] { "[4]", " Bard    ", "Stats: ", "Strength - 2, Agility - 3, Intelligence - 8, Charisma - 8" }, 2, new string[] { "White", "Magenta", "Green", "Yellow" });
            Console.WriteLine("\n");
            //Type2("You could be anything... ", 50);
            //Wait(500);
            //Type("Possibly a...", 50);
            //Type2("Warrior, ");
            //Wait(1000);
            //Type2("Weapons Smith, ");
            //Wait(1000);
            //Type2("Archer");
            //Type("...", 250);
            //Wait(1000);
            Type2("Select one (1, 2, 3 or 4): ");
            do
            {
                do
                {
                    Console.ResetColor();
                    Console.Write("\rSelect one (1, 2, 3 or 4): ");
                    Colour("Yellow");
                } while (!int.TryParse(Console.ReadLine(), out choice));
            } while (choice < 1 || choice > 4);
            
            switch (choice)
            {
                case 1:
                    userDetails[1] = "Warrior";
                    break;
                case 2:
                    userDetails[1] = "Archer";
                    break;
                case 3:
                    userDetails[1] = "Rogue";
                    break;
                case 4:
                    userDetails[1] = "Bard";
                    break;
            }
            Console.ResetColor();
            Wait(1000);
            Type3(new string[] { $"And what's your name, my good ", $"{userDetails[1]}", "? "}, 20, new string[] { "Gray", "Yellow", "Gray" });
            Console.ForegroundColor = ConsoleColor.Yellow;
            string temp = Console.ReadLine();
            Wait(500);
            Type3(new string[] { "You are about to set ", $"{temp}", " as your name, is that correct? Press ", "[ESC]", " to change it, and", " [ENTER]", " to confirm it" }, 5, new string[] { "Gray", "Yellow", "Gray", "Cyan", "Gray", "White", "Gray"});
            Console.WriteLine("");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Type3(new string[] { $"And what's your name, my good ", $"{userDetails[1]}", "? " }, 20, new string[] { "Gray", "Yellow", "Gray" });
                Colour("Yellow");
                temp = Console.ReadLine();
                Wait(500);
                Console.ResetColor();
                Type3(new string[] { "You are about to set ", $"{temp}", " as your name, is that correct? Press ", "[ESC]", " to change it, and", " [ENTER]", " to confirm it" }, 5, new string[] { "Gray", "Yellow", "Gray", "Cyan", "Gray", "White", "Gray" });
                Console.WriteLine("");
            } 

            userDetails[0] = temp;
            Console.ResetColor();
            do
            {
                do
                {
                    Console.ResetColor();
                    Type3(new string[] { $"And how do you see yourself morally, ", $"{userDetails[0]}", ", on a scale of 1-17 (1 being evil, 17 being a hero)?", " (this will affect how NPC's interact with you)" }, 2, new string[] { "Gray", "Cyan", "Gray", "White" });
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                } while (!int.TryParse(Console.ReadLine(), out userMorals));
            } while (userMorals > 17 || userMorals < 1);
            userDetails[2] = $"{userMorals}";

            Game();
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
        static string GetWord(int userMorals, char type)
        {
            Random rnd = new Random();
            int MoralGroup = (userMorals / 6) + 1; // will give 1, 2 or 3. General grouping (1 = negative, 2 = average, 3 = positive)
            string nounDesc, verbDesc, compliment;
            string output = "[GetWord Error]";
            if (type == 'N') // adjectives (describe Noun)
            {
                string[] adjectives = new string[] { "grim", "shoddy", "disgusting", "good", "alright", "average", "nice", "amazing", "awesome" };
                output = adjectives[rnd.Next((MoralGroup * 3) - 3, MoralGroup * 3)];
            }
            if (type == 'V') // adverbs (describe Verb)
            {
                string[] adverbs = new string[] { "clumsily", "terribly", "badly", "okay", "acceptably", "averagely", "flawlessly", "expertly", "incredibly" };
                output = adverbs[rnd.Next((MoralGroup * 3) - 3, MoralGroup * 3)];
            }

            return output;
        }
        static void Type(string args, int delay = 20, string colour = "Gray")
        {
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colour);
            for (int i = 0; i < args.Length; i++)
            {
                if (i == args.Length-1) Console.WriteLine(args[i]);
                else Console.Write(args[i]);
                Thread.Sleep(delay);
            }
        }
        static void Type2(string args, int delay = 20, string colour = "Gray")
        {
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colour);
            for (int i = 0; i < args.Length; i++)
            {
                Console.Write(args[i]);
                Thread.Sleep(delay);
            }
        }
        static void Type3(string[] args, int delay = 20, string[] colour = null)
        {
            colour = colour ?? new string[] { "Gray" };
            for (int i = 0; i < args.Length; i++)
            {
                Type2(args[i], delay, colour[i]);
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
        static void Colour(string colour)
        {
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colour);
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