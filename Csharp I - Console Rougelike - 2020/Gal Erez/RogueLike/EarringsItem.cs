using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    class EarringsItem
    {
        private static EarringsItem _instance = null;
        public static EarringsItem Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EarringsItem();
                }

                return _instance;
            }
        }

        public string EarringSymbol = "¿";

        public void EquipEarring(string type)
        {
            switch (type)
            {
                case "Azure":
                    EarringSymbol = "¿";
                    Player.Instance.Earrings = "Azure";
                    Hud.Instance.EarringsColor = ConsoleColor.Blue;
                    break;

                case "Malachite":
                    EarringSymbol = "¿";
                    Player.Instance.Earrings = "Malachite";
                    Hud.Instance.EarringsColor = ConsoleColor.Green;
                    break;

                case "Amethyst":
                    EarringSymbol = "¿";
                    Player.Instance.Earrings = "Amethyst";
                    Hud.Instance.EarringsColor = ConsoleColor.Magenta;
                    break;

                case "Quartz":
                    EarringSymbol = "¿";
                    Player.Instance.Earrings = "Quartz";
                    Hud.Instance.EarringsColor = ConsoleColor.Gray;
                    break;

                default:
                    EarringSymbol = " ";
                    Player.Instance.Earrings = "None";
                    Hud.Instance.EarringsColor = ConsoleColor.White;
                    break;
            }
        }
    }
}
