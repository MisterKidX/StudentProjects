using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    class Modifiers
    {
        private static Modifiers _instance = null;
        public static Modifiers Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Modifiers();
                }

                return _instance;
            }
        }

        public int PlayerAtkRange()
        {
            int meleeDmg;
            Random playerAtk = new Random();
            meleeDmg = playerAtk.Next(0/* + Weapons.Instance.atkUp.GetLength(0)*/, Player.Instance.Str + Player.Instance.Dex / 2/* + Weapons.Instance.atkUp.GetLength(1)*/);

            Console.ForegroundColor = ConsoleColor.Red;
            if (meleeDmg == 0)
            {
                Dialog.Instance.TextLog("You missed.");
            }
            else
            {
                Dialog.Instance.TextLog("You've dealt " + meleeDmg + " damage.");
            }

            Console.ResetColor();

            return meleeDmg;
        }

        public int PlayerMAtkRange()
        {
            int magicDmg;
            Random playerAtk = new Random();
            magicDmg = playerAtk.Next(0/* + Weapons.Instance.magicAtkUp.GetLength(0)*/, Player.Instance.Int + Player.Instance.Dex/* + Weapons.Instance.magicAtkUp.GetLength(1)*/);
            Player.Instance.CurrentMp -= 5;
            if (Player.Instance.CurrentMp < 0)
            {
                Player.Instance.CurrentMp = 0;
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            if (magicDmg == 0)
            {
                Dialog.Instance.TextLog("You missed.");
            }
            else
            {
                Dialog.Instance.TextLog("You've dealt " + magicDmg + " damage.");
            }

            return magicDmg;
        }

        public int AzureSkillRange()
        {
            int azureDmg;
            Random playerAtk = new Random();
            azureDmg = playerAtk.Next(Player.Instance.Dex /* + Weapons.Instance.atkUp.GetLength(0)*/, Player.Instance.Str * 2/* + Weapons.Instance.atkUp.GetLength(1)*/);
            Player.Instance.CurrentMp -= 25;
            if (Player.Instance.CurrentMp < 0)
            {
                Player.Instance.CurrentMp = 0;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            if (azureDmg == 0)
            {
                Dialog.Instance.TextLog("You missed.");
            }
            else
            {
                Dialog.Instance.TextLog("You've dealt " + azureDmg + " damage.");
            }

            Console.ResetColor();

            return azureDmg;
        }

        public int MalachiteSkillRange()
        {
            int malachiteDmg;
            Random playerAtk = new Random();
            malachiteDmg = playerAtk.Next(Player.Instance.Str/* + Weapons.Instance.atkUp.GetLength(0)*/, Player.Instance.Str * 3/* + Weapons.Instance.atkUp.GetLength(1)*/);
            Player.Instance.CurrentMp -= 25;

            Console.ForegroundColor = ConsoleColor.Green;
            if (malachiteDmg == 0)
            {
                Dialog.Instance.TextLog("You missed.");
            }
            else
            {
                Dialog.Instance.TextLog("You've dealt " + malachiteDmg + " damage.");
            }

            Console.ResetColor();

            return malachiteDmg;
        }

        public int AmethystSkillRange()
        {
            int amethystDmg;
            Random playerAtk = new Random();
            amethystDmg = playerAtk.Next(Player.Instance.Int * 2/* + Weapons.Instance.magicAtkUp.GetLength(0)*/, Player.Instance.Int * 3/* + Weapons.Instance.magicAtkUp.GetLength(1)*/);
            Player.Instance.CurrentMp -= 50;
            if (Player.Instance.CurrentMp < 0)
            {
                Player.Instance.CurrentMp = 0;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            if (amethystDmg == 0)
            {
                Dialog.Instance.TextLog("You missed.");
            }
            else
            {
                Dialog.Instance.TextLog("You've dealt " + amethystDmg + " damage.");
            }

            Console.ResetColor();

            return amethystDmg;
        }

        public int QuartzSkillRange()
        {
            int quartzDmg;
            Random playerAtk = new Random();
            quartzDmg = playerAtk.Next(0 /* + Weapons.Instance.atkUp.GetLength(0)*/, Player.Instance.Int * 2/* + Weapons.Instance.magicAtkUp.GetLength(1)*/);
            Player.Instance.CurrentMp -= 10;
            if (Player.Instance.CurrentMp < 0)
            {
                Player.Instance.CurrentMp = 0;
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            if (quartzDmg == 0)
            {
                Dialog.Instance.TextLog("You missed.");
            }
            else
            {
                Dialog.Instance.TextLog("You've dealt " + quartzDmg + " damage.");
            }

            Console.ResetColor();

            return quartzDmg;
        }

    }
}
