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
        static bool inGame = false;
        static bool dragonHappened = false;
        static string[] userDetails = new string[4];
        static int[] userLocation = new int[] { 0, 0 };
        static int[] classStrength = new int[] { 9, 7, 3, 2 };
        static int[] classAgility = new int[] { 5, 7, 9, 3 };
        static int[] classIntell = new int[] { 3, 5, 7, 8 };
        static int[] classChar = new int[] { 5, 5, 1, 8 };
        #region Ascii
        static string dogAscii = @"
            |\_/|        D\___/\
            (0_0)         (0_o)
           ==(Y)==         (V)
----------(u)---(u)----oOo--U--oOo---
__|_______|_______|_______|_______|___";
        static string battleAscii = @"

.______        ___   .___________.___________. __       _______ 
|   _  \      /   \  |           |           ||  |     |   ____|
|  |_)  |    /  ^  \ `---|  |----`---|  |----`|  |     |  |__   
|   _  <    /  /_\  \    |  |        |  |     |  |     |   __|  
|  |_)  |  /  _____  \   |  |        |  |     |  `----.|  |____ 
|______/  /__/     \__\  |__|        |__|     |_______||_______|
                                                                
";
        static string wheretoAscii = @"

                   _______  _______  _______   _________ _______   _____  
|\     /||\     /|(  ____ \(  ____ )(  ____ \  \__   __/(  ___  ) / ___ \ 
| )   ( || )   ( || (    \/| (    )|| (    \/     ) (   | (   ) |( (   ) )
| | _ | || (___) || (__    | (____)|| (__         | |   | |   | | \/  / / 
| |( )| ||  ___  ||  __)   |     __)|  __)        | |   | |   | |    ( (  
| || || || (   ) || (      | (\ (   | (           | |   | |   | |    | |  
| () () || )   ( || (____/\| ) \ \__| (____/\     | |   | (___) |    (_)  
(_______)|/     \|(_______/|/   \__/(_______/     )_(   (_______)     _   
                                                                     (_)  
";
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
                if (inGame) Whereto();
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
        static void Game_Start()
        {
            SetTitle("Game_Start");
            int userMorals = int.Parse(userDetails[2]);
            Random rnd = new Random();
            int yearsExperience = rnd.Next(0, 30);
            Console.Clear();
            Console.WriteLine(title[0]);
            Console.SetCursorPosition(0, 15);
            Type2("Welcome to the game, ");
            Wait(500);
            Colour("Yellow");
            Type($"{userDetails[0]}!");
            Console.ResetColor();
            if (yearsExperience == 0) Type($"You are a(n) {userDetails[1]}, you've been working in Bellmoral for less than a year, and are still getting to grips with the town, but you feel like you've settled in {GetWord(userMorals, 'V')}.");
            else Type($"You are a(n) {userDetails[1]}, you've been working in Bellmoral for around {yearsExperience} years. You feel like you're a(n) {GetWord(userMorals, 'N')} part of the village.");
            Wait(1000);
            Type("Good luck on your adventures!");
            Wait(2000);
            inGame = true;
        }
        static void Whereto()
        {
            Console.Clear();
            Colour("Yellow");
            Console.WriteLine(wheretoAscii);
            Console.ResetColor();
            Spacing(1);
            SetTitle("Whereto");
            Type3(new string[] { "Do you want to go North [N], East [E], South [S], or West [W]?" }, 10, new string[] { "Gray" });
            Console.WriteLine("");
            ConsoleKey temp = Console.ReadKey().Key;
            while (temp != ConsoleKey.N && temp != ConsoleKey.E && temp != ConsoleKey.S && temp != ConsoleKey.W)
            {
                Console.WriteLine("Enter a valid input.");
                Type3(new string[] { "Do you want to go North [N], East [E], South [S], or West [W]?" }, 10, new string[] { "Gray" });
                Console.WriteLine("");
                temp = Console.ReadKey().Key;
            }
            Console.WriteLine("\r=> ");
            int[] oldPos = new int[] { userLocation[0], userLocation[1] };
            Type3(new string[] { "Loading environment" }, 50);
            Type("...", 100);
            //switch ((char)temp)
            //{
            //    case 'N':
            //        Type3(new string[] { "You attempt to head off ", $"North" }, 10, new string[] { "Gray", "Cyan" });
            //        Console.WriteLine("");
            //        if (userLocation[1] + 1 > 4)
            //        {
            //            Type("You can't go that way.");
            //            Whereto();
            //        }
                    
            //        break;
            //    case 'E':
            //        Type3(new string[] { "You attempt to head off ", $"East" }, 10, new string[] { "Gray", "Cyan" });
            //        Console.WriteLine("");
            //        if (userLocation[0] + 1 > 4)
            //        {
            //            Type("You can't go that way.");
            //            Whereto();
            //        }
            //        break;
            //    case 'W':
            //        Type3(new string[] { "You attempt to head off ", $"West" }, 10, new string[] { "Gray", "Cyan" });
            //        Console.WriteLine("");
            //        if (userLocation[0] -1 > 4)
            //        {
            //            Type("You can't go that way.");
            //            Whereto();
            //        }
            //        break;
            //    case 'S':
            //        Type3(new string[] { "You attempt to head off ", $"South" }, 10, new string[] { "Gray", "Cyan" });
            //        Console.WriteLine("");
            //        if (userLocation[1] -1 > 4)
            //        {
            //            Type("You can't go that way.");
            //            Whereto();
            //        }
            //        break;
            //    default:
            //        Console.Clear();
            //        Console.WriteLine("An error has occured. Location: Error 299");
            //        break;
            //}
            Wait(500);
            switch ((char)temp)
            {
                case 'N':
                    Type3(new string[] { "You head off ", $"North" }, 10, new string[] { "Gray", "Cyan" });
                    Console.WriteLine("");
                    Move(0, 1);
                    break;
                case 'E':
                    Type3(new string[] { "You head off ", $"East" }, 10, new string[] { "Gray", "Cyan" });
                    Console.WriteLine("");
                    Move(1, 0);
                    break;
                case 'W':
                    Type3(new string[] { "You head off ", $"West" }, 10, new string[] { "Gray", "Cyan" });
                    Console.WriteLine("");
                    Move(-1, 0);
                    break;
                case 'S':
                    Type3(new string[] { "You head off ", $"South" }, 10, new string[] { "Gray", "Cyan" });
                    Console.WriteLine("");
                    Move(0, -1);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("An error has occured. Location: Error 1");
                    break;
            }
        }
        static void Move(int x, int y)
        {
            SetTitle("Moving");
            Random rnd = new Random();
            var chance = rnd.NextDouble();
            userLocation[0] = userLocation[0] + x;
            userLocation[1] = userLocation[1] + y;
            if (userLocation[0] == 0 && userLocation[1] == 0)
            {
                Type("You've made it back to the start! You can quit from here by pressing [ESC]. Pressing anything else will result in you moving on");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    Exit();
                }
            }
            if (userLocation[0] == 0 && userLocation[1] == 1) 
            {
                Locations("Forest");
            }
            if (userLocation[0] == -1 && userLocation[1] == 0)
            {
                Type("You've found a secret cabin! You clear it out and look for something valuable...");
                Wait(500);
                Type("You found nothing valuable :(");
                Whereto();
            }
            if (userLocation[0] == 2 && userLocation[1] == 6)
            {
                Wait(1000);
                if (dragonHappened == false) Battle("Boss Dragon", rnd.Next(150, 501));
                else Type("You've already defeated the dragon!!");
                Wait(1000);
                Console.Clear();
                Type("You made it out the forest alive! Congrats!");
                Wait(1000);
                userLocation[0] = 0;
                userLocation[1] = 0;
                inGame = false;
            }
            else
            {
                double chanceOfBattle = rnd.NextDouble();
                if (chanceOfBattle > 0.8) Battle("Random Encounter", rnd.Next(5, 75));
                if (chanceOfBattle < 0.05) 
                {
                    Battle("Boss Dragon", rnd.Next(150, 501));
                    dragonHappened = true;
                }
                else Whereto();
            }
        }
        static void Locations(string location)
        {
            if (location == "Forest")
            {
                Type("You are in a forest.");
                Whereto();
            }
        }
        static void Battle(string enemy, int difficulty)
        {
            Random rnd = new Random();
            int enemyHealth = difficulty;
            int userClass = int.Parse(userDetails[3]);
            int userHealth = 100 + (20 * classStrength[userClass-1]);

            SetTitle("In a Battle");
            while (userHealth > 0 && enemyHealth > 0)
            {
                Console.Clear();
                Console.WriteLine(battleAscii);
                Spacing(1);
                Type3(new string[] { "You are now engaged in a ", "battle ", "with a ", "[", $"{enemy}", "]" }, 20, new string[] { "Gray", "Red", "Gray", "Red", "White", "Red" });
                Console.WriteLine("");
                Console.WriteLine($"Enemy Health: {enemyHealth}");
                Console.WriteLine($"Your Health: {userHealth}");
                Spacing(2);
                Type("Options:", 0, "White");
                Console.WriteLine("  (1) Attack [ENTER]");
                Console.WriteLine("  (2) Flee [ANY]");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    int damageDealt = Attack(enemyHealth, userClass);
                    enemyHealth -= damageDealt;
                    Console.WriteLine($"You dealt {damageDealt} points of damage");
                    Wait(1000);
                    if (enemyHealth < 1) break;
                    int enemyDamageDealt = enemyAttack();
                    Type($"The {enemy} fought back, dealing {enemyDamageDealt} points of damage");
                    userHealth -= enemyDamageDealt;
                }     
                else
                {
                    Type($"You attempt to flee the enemy!");
                    double chance = rnd.NextDouble();
                    Wait(1000);
                    if (chance > 0.8)
                    {
                        int directionNum = rnd.Next(1, 5);
                        string direction = "[unset - error342]";

                        switch (directionNum)
                        {
                            case 1:
                                direction = "North";
                                break;
                            case 2:
                                direction = "East";
                                break;
                            case 3:
                                direction = "South";
                                break;
                            case 4:
                                direction = "West";
                                break;
                        }

                        Type($"You escape to the {direction}");
                        Console.Write("Press enter to continue\n");
                        Console.ReadLine();
                        switch (directionNum)
                        {
                            case 1:
                                direction = "North";
                                Move(0, 1);
                                break;
                            case 2:
                                direction = "East";
                                Move(1, 0);
                                break;
                            case 3:
                                direction = "South";
                                Move(0, -1);
                                break;
                            case 4:
                                direction = "West";
                                Move(-1, 0);
                                break;
                        }
                    }
                    
                }
            }
            if (userHealth > enemyHealth)
            {
                Console.Clear();
                Colour("Green");
                Console.WriteLine(battleAscii);
                Wait(1000);
                Console.Clear();
                Console.WriteLine(title[0]);
                Console.ResetColor();

                Type("You won!");
                Wait(500);
            }
            else
            {
                Death();
            }
        }
        static int Attack(int enemyHealth, int userClass)
        {
            int damage = 5;
            Random rnd = new Random();
            double critChance = rnd.NextDouble();

            damage += classStrength[userClass - 1];
            if (critChance > 0.7) damage += damage * 2;
            if (critChance < 0.1) damage = damage / 2;
            return damage;
        }
        static int enemyAttack()
        {
            int damage = 10;
            Random rnd = new Random();
            int additionalDamage = rnd.Next(1, 50);
            double critChance = rnd.NextDouble();
            damage += additionalDamage;
            if (critChance > 0.9) damage += damage * 2;
            if (critChance < 0.3) damage = damage / 2;
            return damage;
        }
        static void Setup()
        {
            int userMorals, choice;
            
            Console.Clear();
            SetTitle("Set Up");
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

            userDetails[3] = choice.ToString();

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
                    Type3(new string[] { $"And how do you see yourself morally, ", $"{userDetails[0]}", ", on a scale of 1-17 (1 being evil, 17 being a hero)?", " (this will affect how NPC's interact with you)" }, 2, new string[] { "Gray", "Yellow", "Gray", "White" });
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                } while (!int.TryParse(Console.ReadLine(), out userMorals));
            } while (userMorals > 17 || userMorals < 1);
            userDetails[2] = $"{userMorals}";

            Game_Start();
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
            Console.WriteLine("Mode: Escape [experimental] <- Aim for Position (2, 6)");
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
        static void Death()
        {
            Console.Clear();
            WriteCentre("t50", "Red", "You are dead.");
            Wait(1000);
            Exit();
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
            Environment.Exit(0);
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
            string Progressbar = $"Pos[{userLocation[0]}, {userLocation[1]}] Text Based Adventure Game: {args}";
            var title = $"Pos[{userLocation[0]}, {userLocation[1]}] Text Based Adventure Game:";
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