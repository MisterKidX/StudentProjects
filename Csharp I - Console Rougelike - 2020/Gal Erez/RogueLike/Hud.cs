using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    class Hud
    {
        private static Hud _instance = null;
        public static Hud Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Hud();
                }

                return _instance;
            }
        }

        private string[] fill = { "■         ", "█         ", "█■        ", "██        ", "██■       ", "███       ", "███■      ", "████      ",  "████■     ","█████     ",
                                  "█████■    ", "██████    ", "██████■   ", "███████   ", "███████■  ", "████████  ", "████████■ ", "█████████ ", "█████████■", "██████████" };

        public ConsoleColor EarringsColor;
        public ConsoleColor WeaponColor;

        private void HpBar()
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════╗  ");
            Console.Write("║");
            Console.ForegroundColor = ConsoleColor.DarkRed;

            float hpFill = ((float)Player.Instance.CurrentHp / (float)Player.Instance.Hp) * 100f;
            hpFill = hpFill / 5 - 1;
            if (hpFill < 0)
            {
                hpFill = 0;
            }
            Console.Write(fill[(int)hpFill]);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("║ Hp");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚══════════╝  ");
        }
        private void MpBar()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════╗  ");
            Console.Write("║");
            Console.ForegroundColor = ConsoleColor.Magenta;

            float mpFill = ((float)Player.Instance.CurrentMp / (float)Player.Instance.Mp) * 100f;
            mpFill = mpFill / 5 - 1;
            if (mpFill < 0)
            {
                mpFill = 0;
            }

            Console.Write(fill[(int)mpFill]);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("║ Mp");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚══════════╝  ");
        }

        private void Lvl()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("┌─┐");
            Console.Write("│");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Player.Instance.Lvl);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("│");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("└─┘");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Lvl");
        }

        private void Weapon()
        {
            Console.SetCursorPosition(4, 26);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("┌─┐");
            Console.SetCursorPosition(4, 27);
            Console.Write("│");
            Console.ForegroundColor = WeaponColor;
            Console.Write(Weapons.Instance.weaponSymbol);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("│");
            Console.SetCursorPosition(4, 28);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("└─┘");
            Console.SetCursorPosition(4, 29);
            Console.ForegroundColor = WeaponColor;
            Console.Write("Wpn");
        }

        private void Earring()
        {
            Console.SetCursorPosition(8, 26);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("┌─┐");
            Console.SetCursorPosition(8, 27);
            Console.Write("│");
            Console.ForegroundColor = EarringsColor;
            Console.Write(EarringsItem.Instance.EarringSymbol);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("│");
            Console.SetCursorPosition(8, 28);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("└─┘");
            Console.SetCursorPosition(8, 29);
            Console.ForegroundColor = EarringsColor;
            Console.Write("Erg");
        }

        private void Gold()
        {
            Console.SetCursorPosition(12, 26);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("┌─┐");
            Console.SetCursorPosition(12, 27);
            Console.Write("│");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("£");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("│");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" " + Player.Instance.GoldAmount);
            Console.SetCursorPosition(12, 28);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("└─┘");
            Console.SetCursorPosition(12, 29);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Gld");
        }

        public void ShowHud()
        {
            for (int x = 0; x < 1; x++)
            {
                for (int y = 0; y < 1; y++)
                {
                    Console.SetCursorPosition(0, 20);
                    HpBar();
                    MpBar();
                    Lvl();
                    Weapon();
                    Earring();
                    Gold();

                    Misc.ChangeColor("white");
                }
            }
        }
    }
}
