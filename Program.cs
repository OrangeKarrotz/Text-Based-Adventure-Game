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
        static bool inMenu = true;
        static bool playing = true;
        #endregion
        static void Main(string[] args)
        {
            SetTitle("Starting...");
            do
            {
                MainMenu();
            } while (inMenu);


            Console.ReadKey();
        }
        static void MainMenu()
        {
            ConsoleKey keyPress;
            SetTitle("Menu");
            Console.Clear();
            Spacing(2);
            WriteMiddle("", "Red", "[insert title here]");
            Spacing(1);
            Console.ForegroundColor = ConsoleColor.Green;
            WriteMiddle("", "Green", "WELCOME!");
            
            do
            {
                Spacing(1);
                WriteMiddle("", "", "Please choose a valid option:");
                #region Commented
                //WriteMiddle("", "", "[a]");
                //WriteMiddle("", "", "PLAY");
                //WriteMiddle("", "", "[b]");
                //WriteMiddle("", "", "OPTIONS");
                //WriteMiddle("", "", "[e]");
                //WriteMiddle("", "", "EXIT");
                #endregion
                WriteMiddle("", "", "[a] PLAY");
                WriteMiddle("", "", "[b] OPTIONS");
                WriteMiddle("", "", "[e] EXIT");
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
                    inMenu = false;
                    Play();
                    return;
                case 'B':
                    inMenu = false;
                    Options();
                    return;
                case 'E':
                    inMenu = false;
                    Exit();
                    return;
                default:
                    WriteMiddle("t50", "Red", "ERROR: INVALID INPUT");
                    return;
            }
        }
        static void Play()
        {
            Console.Clear();
            SetTitle("Playing");
            WriteMiddle("t20", "Blue", "Welcome to the game");
            Console.ReadKey();
        }
        static void Options()
        {
            Console.Clear();
            SetTitle("Options");
            Spacing(2);
            WriteMiddle("", "Green", "OPTIONS:");
            WriteMiddle("", "", "");
            Console.ReadKey();
        }
        static void Type(string args, int delay)
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
            Type("Exitting...", 100);
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
            Spacing(windowHeight / 2);
            WriteMiddle(type, colour, output);
        }
    }
}