using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoughLite
{
    class MainMenu
    {
        private int _selectedIndex;
        
        private string[] _options;
        private string _prompt; //what will show up before the options(like title)
        
        public MainMenu(string prompt, string[] options)
        {
            _prompt = prompt;
            _options = options;
            _selectedIndex = 0;

        }

        private void DisplayOptions()
        {
            Console.WriteLine(_prompt);
            for (int i = 0; i < _options.Length; i++)
            {
                string currentOption = _options[i];
                string nowSelected;
                if(i == _selectedIndex)
                {
                    nowSelected = "->";
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    nowSelected = "  ";
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{nowSelected} [{currentOption}] ");
            }
            Console.ResetColor();
        }
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();
                
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                keyPressed = keyInfo.Key;
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    _selectedIndex--;
                    if(_selectedIndex == -1)
                    {
                        _selectedIndex = _options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    _selectedIndex++;
                    if(_selectedIndex == _options.Length)
                    {
                        _selectedIndex = 0;
                    }
                }
            }
            while (keyPressed != ConsoleKey.Enter);

            return _selectedIndex;
        } 
    }

}
