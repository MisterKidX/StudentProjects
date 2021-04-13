using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    class Misc
    {
        public static void Type(string text)
        {
            foreach (var character in text)
            {
                Console.Write(character);
                System.Threading.Thread.Sleep(30);
            }
        }

        public static void TypeLine(string text)
        {
            foreach (var character in text)
            {
                Console.Write(character);
                System.Threading.Thread.Sleep(30);
            }

            System.Threading.Thread.Sleep(1000);
            Console.WriteLine();
        }

        public static void TypeBot(string text)
        {
            foreach (var character in text)
            {
                Console.Write(character);
                System.Threading.Thread.Sleep(30);
            }

            Console.WriteLine();
        }

        public static void ChangeColor(string color)
        {
            switch (color)
            {
                case "cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;

                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case "Magenta":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                
                case "Dark Magenta":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
}
