using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    class Dialog
    {
        private static Dialog _instance = null;
        public static Dialog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Dialog();
                }

                return _instance;
            }
        }

        Queue<string> textLog = new Queue<string>(5);

        private int _writeX = 20;
        private int _writeY = 20;

        public void TextLog(string text)
        {
            if (Console.ForegroundColor == ConsoleColor.White)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            
            textLog.Enqueue(text);

            for (int i = 0; i < textLog.Count; i++)
            {
                Console.SetCursorPosition(_writeX, _writeY + i);

                if (textLog.Count == 6)
                {
                    textLog.Dequeue();
                }

                Console.WriteLine("                                ");

                Console.SetCursorPosition(_writeX, _writeY + i);
                Console.WriteLine(textLog.ToArray()[i]);
            }

            Console.ResetColor();
        }

        public void ClearLog()
        {
            TextLog("                                   ");
            TextLog("                                   ");
            TextLog("                                   ");
            TextLog("                                   ");
            TextLog("                                   ");
        }

        public void Legend()
        {
            string player = "δ = Player"; //  #235
            string enemy = "Θ = Enemy"; //  #233
            string gold = "£ = gold"; //  #233
            string shop = "ô = shop"; // #
            string bossUpper = "φ = Boss"; //  #237
            string bossUnder = "Ω"; //  #234
            string treasureChest = "∩ = Tresure Chest"; //  #239
            string Exit = "≥ = Level Exit"; //  #242
            string Entrance = "≤ = Level Entrance"; // #243

            _writeX = 81;
            _writeY = 1;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(_writeX, _writeY);
            Console.WriteLine(treasureChest);
            Console.SetCursorPosition(_writeX, _writeY + 1);
            Console.WriteLine(Entrance);
            Console.SetCursorPosition(_writeX, _writeY + 2);
            Console.WriteLine(Exit);
            Console.SetCursorPosition(_writeX, _writeY + 3);
            Console.WriteLine(gold);
            Console.SetCursorPosition(_writeX, _writeY + 4);
            Console.WriteLine(shop);
            Console.SetCursorPosition(_writeX, _writeY + 5);
            Console.WriteLine(player);
            Console.SetCursorPosition(_writeX, _writeY + 6);
            Console.WriteLine(enemy);
            Console.SetCursorPosition(_writeX, _writeY + 7);
            Console.WriteLine(bossUpper);
            Console.SetCursorPosition(_writeX, _writeY + 8);
            Console.WriteLine(bossUnder);
            Console.SetCursorPosition(_writeX, _writeY + 10);
            Console.WriteLine("w, a, s, d to Move.");
            Console.SetCursorPosition(_writeX, _writeY + 11);
            Console.WriteLine("F to Atk, must be adjacent to enemy");

            _writeX = 20;
            _writeY = 20;
        }

        public void Intro()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Misc.TypeLine("Welcome to Daimnon's Rogue");
            Misc.Type("Are you a Wizard or a Warrior? ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Misc.Type("[Wiz,");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Misc.Type(" War]");
            Console.WriteLine();
            string input = Console.ReadLine().ToLower();
            if (input == "wiz")
            {
                Player.Instance.isWizard = true;
            }
            else if (input == "war")
            {
                Player.Instance.isWizard = false;
            }
            else
            {
                Misc.TypeLine("You must've did something wrong, C'mon it's not that hard..");
            }
            Console.Clear();
            Console.ResetColor();
        }

        public void DeathMenu()
        {
            _writeX = 37;
            _writeY = 7;
            string input;

            Console.SetCursorPosition(_writeX, _writeY);
            Console.WriteLine("              ");
            Console.SetCursorPosition(_writeX, _writeY + 1);
            Console.WriteLine("   You Died   ");
            Console.SetCursorPosition(_writeX, _writeY + 2);
            Console.WriteLine("              ");
            Console.SetCursorPosition(_writeX - 9, _writeY + 7);
            Console.WriteLine("Do you want to start again? [Y/N]");
            Console.SetCursorPosition(_writeX - 9, _writeY + 9);

            input = Console.ReadLine();

            if (input == "y")
            {
                Console.Clear();
                // HUD elements
                Player.Instance.CurrentHp = Player.Instance.Hp;
                Player.Instance.CurrentMp = Player.Instance.Mp;

                // Attributes
                Player.Instance.Str = 4;
                Player.Instance.Dex = 4;
                Player.Instance.Int = 4;
                Player.Instance.Luk = 4;

                // Equipment
                Player.Instance.Weapon = "None";
                Player.Instance.Earrings = "None";

                // Currency
                Player.Instance.GoldAmount = 0;

                // Exp
                Player.Instance.Exp = 0;

                // Dead or Alive
                Player.Instance.isAlive = true;
                GameRenderer renderer = new GameRenderer();
            }
            else if (input == "n")
            {
                Environment.Exit(0);
            }
        }
    }
}
