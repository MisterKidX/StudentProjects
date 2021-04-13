using System;
using System.Collections.Generic;
using System.Text;
namespace ConsoleApp1
{
    class Menu
    {
        string Title;
        string[] Options;
        int SelectedIndex;

        public Menu(string title, string[] options)
        {
            Title = title;
            Options = options;
            SelectedIndex = 0;
        }

        private void PrintMenu()
        {
            Console.WriteLine(Title);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentoption = Options[i];
                string prefix;
                if (i == SelectedIndex)
                {
                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($" {prefix} < {currentoption} >");
                Console.ResetColor();
            }
        }
        public int Run()
        {
            ConsoleKey keypressed;
            do
            {
                Console.Clear();
                PrintMenu();
                ConsoleKeyInfo keyinfo = Console.ReadKey(true);
                keypressed = keyinfo.Key;
                if (keypressed == ConsoleKey.W)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keypressed == ConsoleKey.S)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            } while (keypressed != ConsoleKey.Enter);
            return SelectedIndex;
        }

    }
}
