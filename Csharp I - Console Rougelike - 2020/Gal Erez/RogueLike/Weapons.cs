using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    class Weapons
    {
        private static Weapons _instance = null;
        public static Weapons Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Weapons();
                }

                return _instance;
            }
        }

        Random rand = new Random();


                                                                            // ↓ magical ↓
        public string[] swords = { "WoodenSword", "StoneSword", "IronSword", "SilverSword", "AzureSword" };

                                                                // ↓ magical ↓
        public string[] axes = { "WoodenAxe", "StoneAxe", "IronAxe", "FireAxe", "MalachiteAxe" };

        public string[] staffs = { "FireStaf", "IceStaff", "LightStaff", "DarkStaff", "AmethystStaff" };

                                                             // ↓physical↓
        public string[] wands = { "ElectricWand", "NatureWand", "LasoWand", "VenomWand", "QuartzWand" };

        public string SwordUpperSymbol = "║";
        public string SwordUnderSymbol = "╬";

        public string AxeUpperSymbol = "(φ)";
        public string AxeLowerSymbol = " │";

        public string StaffUpperSymbol = "ªφª";
        public string StaffLowerSymbol = " │";

        public string WandUpperSymbol = "÷";
        public string WandLowerSymbol = "│";

        public string weaponSymbol = MapGenerator.Instance.Blank;

        public int[,] atkUp;
        public int[,] magicAtkUp;

        public bool isSword = false;
        public bool isAxe = false;
        public bool isStaff = false;
        public bool isWand = false;


        public void EquipWeapon(string weaponName)
        {
            atkUp = new int[0, 0];
            magicAtkUp = new int[0, 0];

            Hud.Instance.WeaponColor = ConsoleColor.White;

            if (isSword == true)
            {
                weaponSymbol = "╫";
                switch (weaponName)
                {
                    case "WoodenSword":
                        Hud.Instance.WeaponColor = ConsoleColor.DarkYellow;
                        atkUp = new int[2,5];
                        break;

                    case "StoneSword":
                        Hud.Instance.WeaponColor = ConsoleColor.DarkGray;
                        atkUp = new int[7, 10];
                        break;

                    case "IronSword":
                        Hud.Instance.WeaponColor = ConsoleColor.Gray;
                        atkUp = new int[30, 50];
                        break;

                    case "SilverSword":
                        Hud.Instance.WeaponColor = ConsoleColor.White;
                        atkUp = new int[75, 120];
                        magicAtkUp = new int[20, 40];
                        Player.Instance.Luk += 1; 
                        break;

                    case "AzureSword":
                        Hud.Instance.WeaponColor = ConsoleColor.Blue;
                        atkUp = new int[210, 350];
                        break;

                    default:
                        atkUp = new int[0, 0];
                        break;
                }

                Player.Instance.Weapon = weaponName;
            }
            else if (isAxe == true)
            {
                weaponSymbol = "φ";
                switch (weaponName)
                {
                    case "WoodenAxe":
                        Hud.Instance.WeaponColor = ConsoleColor.DarkYellow;
                        atkUp = new int[1, 7];
                        break;

                    case "StoneAxe":
                        Hud.Instance.WeaponColor = ConsoleColor.DarkGray;
                        atkUp = new int[4, 14];
                        break;

                    case "IronAxe":
                        Hud.Instance.WeaponColor = ConsoleColor.Gray;
                        atkUp = new int[20, 70];
                        break;

                    case "FireAxe":
                        Hud.Instance.WeaponColor = ConsoleColor.DarkRed;
                        atkUp = new int[50, 175];
                        magicAtkUp = new int[1, 5];
                        Player.Instance.Luk += 1;
                        break;

                    case "MalachiteAxe":
                        Hud.Instance.WeaponColor = ConsoleColor.Green;
                        atkUp = new int[150, 500];
                        break;

                    default:
                        atkUp = new int[0, 0];
                        break;
                }

                Player.Instance.Weapon = weaponName;
            }
            else if (isStaff == true)
            {
                weaponSymbol = "ÿ";
                switch (weaponName)
                {
                    case "FireStaftt":
                        Hud.Instance.WeaponColor = ConsoleColor.Red;
                        magicAtkUp = new int[1, 5];
                        break;

                    case "IceStaff":
                        Hud.Instance.WeaponColor = ConsoleColor.Cyan;
                        magicAtkUp = new int[5, 10];
                        break;

                    case "LightStaff":
                        Hud.Instance.WeaponColor = ConsoleColor.Yellow;
                        magicAtkUp = new int[25, 50];
                        Player.Instance.Luk += 4;
                        break;

                    case "DarkStaff":
                        Hud.Instance.WeaponColor = ConsoleColor.DarkMagenta;
                        magicAtkUp = new int[75, 150];
                        break;

                    case "AmethystStaff":
                        Hud.Instance.WeaponColor = ConsoleColor.Magenta;
                        magicAtkUp = new int[200, 350];
                        break;

                    default:
                        magicAtkUp = new int[0, 0];
                        break;
                }

                Player.Instance.Weapon = weaponName;
            }
            else if (isWand == true)
            {
                weaponSymbol = "¡";
                switch (weaponName)
                {
                    case "ElectricWand":
                        Hud.Instance.WeaponColor = ConsoleColor.DarkBlue;
                        magicAtkUp = new int[3, 3];
                        Player.Instance.Luk += 1;
                        break;

                    case "NatureWand":
                        Hud.Instance.WeaponColor = ConsoleColor.DarkGreen;
                        magicAtkUp = new int[7, 8];
                        Player.Instance.Luk += 1;
                        break;

                    case "LasoWand":
                        Hud.Instance.WeaponColor = ConsoleColor.DarkYellow;
                        magicAtkUp = new int[35, 45];
                        atkUp = new int[15, 15];
                        Player.Instance.Luk += 1;
                        break;

                    case "VenomWand":
                        Hud.Instance.WeaponColor = ConsoleColor.DarkMagenta;
                        magicAtkUp = new int[100, 120];
                        Player.Instance.Luk += 1;
                        break;

                    case "QuartzWand":
                        Hud.Instance.WeaponColor = ConsoleColor.Gray;
                        magicAtkUp = new int[275, 300];
                        Player.Instance.Luk += 1;
                        break;

                    default:
                        magicAtkUp = new int[0, 0];
                        break;
                }

                Player.Instance.Weapon = weaponName;
            }
        }

        public void ProduceWoodenSword()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[1, 2] = "┌";
            Shop.Instance.ShopDimentions[1, 3] = "─";
            Shop.Instance.ShopDimentions[1, 4] = "─";
            Shop.Instance.ShopDimentions[1, 5] = "─";
            Shop.Instance.ShopDimentions[1, 6] = "┐";
            Shop.Instance.ShopDimentions[2, 2] = "│";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Shop.Instance.ShopDimentions[2, 4] = SwordUpperSymbol;
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 2] = "│";
            Shop.Instance.ShopDimentions[2, 6] = "│";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Shop.Instance.ShopDimentions[3, 4] = SwordUnderSymbol;
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 6] = "│";
            Shop.Instance.ShopDimentions[4, 2] = "└";
            Shop.Instance.ShopDimentions[4, 3] = "─";
            Shop.Instance.ShopDimentions[4, 4] = "─";
            Shop.Instance.ShopDimentions[4, 5] = "─";
            Shop.Instance.ShopDimentions[4, 6] = "┘";
        }

        public void ProduceStoneSword()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[1, 2] = "┌";
            Shop.Instance.ShopDimentions[1, 3] = "─";
            Shop.Instance.ShopDimentions[1, 4] = "─";
            Shop.Instance.ShopDimentions[1, 5] = "─";
            Shop.Instance.ShopDimentions[1, 6] = "┐";
            Shop.Instance.ShopDimentions[2, 2] = "│";
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Shop.Instance.ShopDimentions[2, 4] = SwordUpperSymbol;
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 2] = "│";
            Shop.Instance.ShopDimentions[2, 6] = "│";
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Shop.Instance.ShopDimentions[3, 4] = SwordUnderSymbol;
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 6] = "│";
            Shop.Instance.ShopDimentions[4, 2] = "└";
            Shop.Instance.ShopDimentions[4, 3] = "─";
            Shop.Instance.ShopDimentions[4, 4] = "─";
            Shop.Instance.ShopDimentions[4, 5] = "─";
            Shop.Instance.ShopDimentions[4, 6] = "┘";
        }

        public void ProduceIronSword()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[1, 2] = "┌";
            Shop.Instance.ShopDimentions[1, 3] = "─";
            Shop.Instance.ShopDimentions[1, 4] = "─";
            Shop.Instance.ShopDimentions[1, 5] = "─";
            Shop.Instance.ShopDimentions[1, 6] = "┐";
            Shop.Instance.ShopDimentions[2, 2] = "│";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[2, 4] = SwordUpperSymbol;
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 2] = "│";
            Shop.Instance.ShopDimentions[2, 6] = "│";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 4] = SwordUnderSymbol;
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 6] = "│";
            Shop.Instance.ShopDimentions[4, 2] = "└";
            Shop.Instance.ShopDimentions[4, 3] = "─";
            Shop.Instance.ShopDimentions[4, 4] = "─";
            Shop.Instance.ShopDimentions[4, 5] = "─";
            Shop.Instance.ShopDimentions[4, 6] = "┘";
        }

        public void ProduceSilverSword()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[1, 2] = "┌";
            Shop.Instance.ShopDimentions[1, 3] = "─";
            Shop.Instance.ShopDimentions[1, 4] = "─";
            Shop.Instance.ShopDimentions[1, 5] = "─";
            Shop.Instance.ShopDimentions[1, 6] = "┐";
            Shop.Instance.ShopDimentions[2, 2] = "│";
            Console.ForegroundColor = ConsoleColor.White;
            Shop.Instance.ShopDimentions[2, 4] = SwordUpperSymbol;
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 2] = "│";
            Shop.Instance.ShopDimentions[2, 6] = "│";
            Console.ForegroundColor = ConsoleColor.White;
            Shop.Instance.ShopDimentions[3, 4] = SwordUnderSymbol;
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 6] = "│";
            Shop.Instance.ShopDimentions[4, 2] = "└";
            Shop.Instance.ShopDimentions[4, 3] = "─";
            Shop.Instance.ShopDimentions[4, 4] = "─";
            Shop.Instance.ShopDimentions[4, 5] = "─";
            Shop.Instance.ShopDimentions[4, 6] = "┘";
        }

        public void ProduceAzureSword()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[1, 2] = "┌";
            Shop.Instance.ShopDimentions[1, 3] = "─";
            Shop.Instance.ShopDimentions[1, 4] = "─";
            Shop.Instance.ShopDimentions[1, 5] = "─";
            Shop.Instance.ShopDimentions[1, 6] = "┐";
            Shop.Instance.ShopDimentions[2, 2] = "│";
            Console.ForegroundColor = ConsoleColor.Blue;
            Shop.Instance.ShopDimentions[2, 4] = SwordUpperSymbol;
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 2] = "│";
            Shop.Instance.ShopDimentions[2, 6] = "│";
            Console.ForegroundColor = ConsoleColor.Blue;
            Shop.Instance.ShopDimentions[3, 4] = SwordUnderSymbol;
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 6] = "│";
            Shop.Instance.ShopDimentions[4, 2] = "└";
            Shop.Instance.ShopDimentions[4, 3] = "─";
            Shop.Instance.ShopDimentions[4, 4] = "─";
            Shop.Instance.ShopDimentions[4, 5] = "─";
            Shop.Instance.ShopDimentions[4, 6] = "┘";
        }

        public void ProduceWoodenAxe()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[1, 12] = "┌";
            Shop.Instance.ShopDimentions[1, 13] = "─";
            Shop.Instance.ShopDimentions[1, 14] = "─";
            Shop.Instance.ShopDimentions[1, 15] = "─";
            Shop.Instance.ShopDimentions[1, 16] = "┐";
            Shop.Instance.ShopDimentions[2, 12] = "│";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Shop.Instance.ShopDimentions[2, 13] = "(";
            Shop.Instance.ShopDimentions[2, 14] = "φ";
            Shop.Instance.ShopDimentions[2, 15] = ")";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 12] = "│";
            Shop.Instance.ShopDimentions[2, 16] = "│";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Shop.Instance.ShopDimentions[3, 14] = "│";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 16] = "│";
            Shop.Instance.ShopDimentions[4, 12] = "└";
            Shop.Instance.ShopDimentions[4, 13] = "─";
            Shop.Instance.ShopDimentions[4, 14] = "─";
            Shop.Instance.ShopDimentions[4, 15] = "─";
            Shop.Instance.ShopDimentions[4, 16] = "┘";
        }

        public void ProduceStoneAxe()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[1, 12] = "┌";
            Shop.Instance.ShopDimentions[1, 13] = "─";
            Shop.Instance.ShopDimentions[1, 14] = "─";
            Shop.Instance.ShopDimentions[1, 15] = "─";
            Shop.Instance.ShopDimentions[1, 16] = "┐";
            Shop.Instance.ShopDimentions[2, 12] = "│";
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Shop.Instance.ShopDimentions[2, 13] = "(";
            Shop.Instance.ShopDimentions[2, 14] = "φ";
            Shop.Instance.ShopDimentions[2, 15] = ")";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 12] = "│";
            Shop.Instance.ShopDimentions[2, 16] = "│";
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Shop.Instance.ShopDimentions[3, 14] = "│";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 16] = "│";
            Shop.Instance.ShopDimentions[4, 12] = "└";
            Shop.Instance.ShopDimentions[4, 13] = "─";
            Shop.Instance.ShopDimentions[4, 14] = "─";
            Shop.Instance.ShopDimentions[4, 15] = "─";
            Shop.Instance.ShopDimentions[4, 16] = "┘";
        }

        public void ProduceIronAxe()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[1, 12] = "┌";
            Shop.Instance.ShopDimentions[1, 13] = "─";
            Shop.Instance.ShopDimentions[1, 14] = "─";
            Shop.Instance.ShopDimentions[1, 15] = "─";
            Shop.Instance.ShopDimentions[1, 16] = "┐";
            Shop.Instance.ShopDimentions[2, 12] = "│";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[2, 13] = "(";
            Shop.Instance.ShopDimentions[2, 14] = "φ";
            Shop.Instance.ShopDimentions[2, 15] = ")";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 12] = "│";
            Shop.Instance.ShopDimentions[2, 16] = "│";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 14] = "│";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 16] = "│";
            Shop.Instance.ShopDimentions[4, 12] = "└";
            Shop.Instance.ShopDimentions[4, 13] = "─";
            Shop.Instance.ShopDimentions[4, 14] = "─";
            Shop.Instance.ShopDimentions[4, 15] = "─";
            Shop.Instance.ShopDimentions[4, 16] = "┘";
        }

        public void ProduceFireAxe()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[1, 12] = "┌";
            Shop.Instance.ShopDimentions[1, 13] = "─";
            Shop.Instance.ShopDimentions[1, 14] = "─";
            Shop.Instance.ShopDimentions[1, 15] = "─";
            Shop.Instance.ShopDimentions[1, 16] = "┐";
            Shop.Instance.ShopDimentions[2, 12] = "│";
            Console.ForegroundColor = ConsoleColor.Red;
            Shop.Instance.ShopDimentions[2, 13] = "(";
            Shop.Instance.ShopDimentions[2, 14] = "φ";
            Shop.Instance.ShopDimentions[2, 15] = ")";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 12] = "│";
            Shop.Instance.ShopDimentions[2, 16] = "│";
            Console.ForegroundColor = ConsoleColor.Red;
            Shop.Instance.ShopDimentions[3, 14] = "│";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 16] = "│";
            Shop.Instance.ShopDimentions[4, 12] = "└";
            Shop.Instance.ShopDimentions[4, 13] = "─";
            Shop.Instance.ShopDimentions[4, 14] = "─";
            Shop.Instance.ShopDimentions[4, 15] = "─";
            Shop.Instance.ShopDimentions[4, 16] = "┘";
        }

        public void ProduceMalachiteAxe()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[1, 12] = "┌";
            Shop.Instance.ShopDimentions[1, 13] = "─";
            Shop.Instance.ShopDimentions[1, 14] = "─";
            Shop.Instance.ShopDimentions[1, 15] = "─";
            Shop.Instance.ShopDimentions[1, 16] = "┐";
            Shop.Instance.ShopDimentions[2, 12] = "│";
            Console.ForegroundColor = ConsoleColor.Green;
            Shop.Instance.ShopDimentions[2, 13] = "(";
            Shop.Instance.ShopDimentions[2, 14] = "φ";
            Shop.Instance.ShopDimentions[2, 15] = ")";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 12] = "│";
            Shop.Instance.ShopDimentions[2, 16] = "│";
            Console.ForegroundColor = ConsoleColor.Green;
            Shop.Instance.ShopDimentions[3, 14] = "│";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 16] = "│";
            Shop.Instance.ShopDimentions[4, 12] = "└";
            Shop.Instance.ShopDimentions[4, 13] = "─";
            Shop.Instance.ShopDimentions[4, 14] = "─";
            Shop.Instance.ShopDimentions[4, 15] = "─";
            Shop.Instance.ShopDimentions[4, 16] = "┘";
        }

        public void ProduceFireStaff()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[1, 22] = "┌";
            Shop.Instance.ShopDimentions[1, 23] = "─";
            Shop.Instance.ShopDimentions[1, 24] = "─";
            Shop.Instance.ShopDimentions[1, 25] = "─";
            Shop.Instance.ShopDimentions[1, 26] = "┐";
            Shop.Instance.ShopDimentions[2, 22] = "│";
            Console.ForegroundColor = ConsoleColor.Red;
            Shop.Instance.ShopDimentions[2, 23] = "ª";
            Shop.Instance.ShopDimentions[2, 24] = "φ";
            Shop.Instance.ShopDimentions[2, 25] = "ª";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 22] = "│";
            Shop.Instance.ShopDimentions[2, 26] = "│";
            Console.ForegroundColor = ConsoleColor.Red;
            Shop.Instance.ShopDimentions[3, 24] = "│";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 26] = "│";
            Shop.Instance.ShopDimentions[4, 22] = "└";
            Shop.Instance.ShopDimentions[4, 23] = "─";
            Shop.Instance.ShopDimentions[4, 24] = "─";
            Shop.Instance.ShopDimentions[4, 25] = "─";
            Shop.Instance.ShopDimentions[4, 26] = "┘";
        }

        public void ProduceIceStaff()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[1, 22] = "┌";
            Shop.Instance.ShopDimentions[1, 23] = "─";
            Shop.Instance.ShopDimentions[1, 24] = "─";
            Shop.Instance.ShopDimentions[1, 25] = "─";
            Shop.Instance.ShopDimentions[1, 26] = "┐";
            Shop.Instance.ShopDimentions[2, 22] = "│";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Shop.Instance.ShopDimentions[2, 23] = "ª";
            Shop.Instance.ShopDimentions[2, 24] = "φ";
            Shop.Instance.ShopDimentions[2, 25] = "ª";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 22] = "│";
            Shop.Instance.ShopDimentions[2, 26] = "│";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Shop.Instance.ShopDimentions[3, 24] = "│";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 26] = "│";
            Shop.Instance.ShopDimentions[4, 22] = "└";
            Shop.Instance.ShopDimentions[4, 23] = "─";
            Shop.Instance.ShopDimentions[4, 24] = "─";
            Shop.Instance.ShopDimentions[4, 25] = "─";
            Shop.Instance.ShopDimentions[4, 26] = "┘";
        }

        public void ProduceLightStaff()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[1, 22] = "┌";
            Shop.Instance.ShopDimentions[1, 23] = "─";
            Shop.Instance.ShopDimentions[1, 24] = "─";
            Shop.Instance.ShopDimentions[1, 25] = "─";
            Shop.Instance.ShopDimentions[1, 26] = "┐";
            Shop.Instance.ShopDimentions[2, 22] = "│";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Shop.Instance.ShopDimentions[2, 23] = "ª";
            Shop.Instance.ShopDimentions[2, 24] = "φ";
            Shop.Instance.ShopDimentions[2, 25] = "ª";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 22] = "│";
            Shop.Instance.ShopDimentions[2, 26] = "│";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Shop.Instance.ShopDimentions[3, 24] = "│";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 26] = "│";
            Shop.Instance.ShopDimentions[4, 22] = "└";
            Shop.Instance.ShopDimentions[4, 23] = "─";
            Shop.Instance.ShopDimentions[4, 24] = "─";
            Shop.Instance.ShopDimentions[4, 25] = "─";
            Shop.Instance.ShopDimentions[4, 26] = "┘";
        }

        public void ProduceDarkStaff()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[1, 22] = "┌";
            Shop.Instance.ShopDimentions[1, 23] = "─";
            Shop.Instance.ShopDimentions[1, 24] = "─";
            Shop.Instance.ShopDimentions[1, 25] = "─";
            Shop.Instance.ShopDimentions[1, 26] = "┐";
            Shop.Instance.ShopDimentions[2, 22] = "│";
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Shop.Instance.ShopDimentions[2, 23] = "ª";
            Shop.Instance.ShopDimentions[2, 24] = "φ";
            Shop.Instance.ShopDimentions[2, 25] = "ª";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 22] = "│";
            Shop.Instance.ShopDimentions[2, 26] = "│";
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Shop.Instance.ShopDimentions[3, 24] = "│";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 26] = "│";
            Shop.Instance.ShopDimentions[4, 22] = "└";
            Shop.Instance.ShopDimentions[4, 23] = "─";
            Shop.Instance.ShopDimentions[4, 24] = "─";
            Shop.Instance.ShopDimentions[4, 25] = "─";
            Shop.Instance.ShopDimentions[4, 26] = "┘";
        }

        public void ProduceAmethystStaff()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[1, 22] = "┌";
            Shop.Instance.ShopDimentions[1, 23] = "─";
            Shop.Instance.ShopDimentions[1, 24] = "─";
            Shop.Instance.ShopDimentions[1, 25] = "─";
            Shop.Instance.ShopDimentions[1, 26] = "┐";
            Shop.Instance.ShopDimentions[2, 22] = "│";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Shop.Instance.ShopDimentions[2, 23] = "ª";
            Shop.Instance.ShopDimentions[2, 24] = "φ";
            Shop.Instance.ShopDimentions[2, 25] = "ª";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 22] = "│";
            Shop.Instance.ShopDimentions[2, 26] = "│";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Shop.Instance.ShopDimentions[3, 24] = "│";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[3, 26] = "│";
            Shop.Instance.ShopDimentions[4, 22] = "└";
            Shop.Instance.ShopDimentions[4, 23] = "─";
            Shop.Instance.ShopDimentions[4, 24] = "─";
            Shop.Instance.ShopDimentions[4, 25] = "─";
            Shop.Instance.ShopDimentions[4, 26] = "┘";
        }

        public void ProduceElectricWand()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[7, 2] = "┌";
            Shop.Instance.ShopDimentions[7, 3] = "─";
            Shop.Instance.ShopDimentions[7, 4] = "─";
            Shop.Instance.ShopDimentions[7, 5] = "─";
            Shop.Instance.ShopDimentions[7, 6] = "┐";
            Shop.Instance.ShopDimentions[8, 2] = "│";
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Shop.Instance.ShopDimentions[8, 4] = WandUpperSymbol;
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[9, 2] = "│";
            Shop.Instance.ShopDimentions[8, 6] = "│";
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Shop.Instance.ShopDimentions[9, 4] = WandLowerSymbol;
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[9, 6] = "│";
            Shop.Instance.ShopDimentions[10, 2] = "└";
            Shop.Instance.ShopDimentions[10, 3] = "─";
            Shop.Instance.ShopDimentions[10, 4] = "─";
            Shop.Instance.ShopDimentions[10, 5] = "─";
            Shop.Instance.ShopDimentions[10, 6] = "┘";
        }

        public void ProduceNatureWand()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[7, 2] = "┌";
            Shop.Instance.ShopDimentions[7, 3] = "─";
            Shop.Instance.ShopDimentions[7, 4] = "─";
            Shop.Instance.ShopDimentions[7, 5] = "─";
            Shop.Instance.ShopDimentions[7, 6] = "┐";
            Shop.Instance.ShopDimentions[8, 2] = "│";
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Shop.Instance.ShopDimentions[8, 4] = WandUpperSymbol;
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[9, 2] = "│";
            Shop.Instance.ShopDimentions[8, 6] = "│";
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Shop.Instance.ShopDimentions[9, 4] = WandLowerSymbol;
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[9, 6] = "│";
            Shop.Instance.ShopDimentions[10, 2] = "└";
            Shop.Instance.ShopDimentions[10, 3] = "─";
            Shop.Instance.ShopDimentions[10, 4] = "─";
            Shop.Instance.ShopDimentions[10, 5] = "─";
            Shop.Instance.ShopDimentions[10, 6] = "┘";
        }

        public void ProduceLasoWand()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[7, 2] = "┌";
            Shop.Instance.ShopDimentions[7, 3] = "─";
            Shop.Instance.ShopDimentions[7, 4] = "─";
            Shop.Instance.ShopDimentions[7, 5] = "─";
            Shop.Instance.ShopDimentions[7, 6] = "┐";
            Shop.Instance.ShopDimentions[8, 2] = "│";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Shop.Instance.ShopDimentions[8, 4] = WandUpperSymbol;
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[9, 2] = "│";
            Shop.Instance.ShopDimentions[8, 6] = "│";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Shop.Instance.ShopDimentions[9, 4] = WandLowerSymbol;
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[9, 6] = "│";
            Shop.Instance.ShopDimentions[10, 2] = "└";
            Shop.Instance.ShopDimentions[10, 3] = "─";
            Shop.Instance.ShopDimentions[10, 4] = "─";
            Shop.Instance.ShopDimentions[10, 5] = "─";
            Shop.Instance.ShopDimentions[10, 6] = "┘";
        }

        public void ProduceVenomWand()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[7, 2] = "┌";
            Shop.Instance.ShopDimentions[7, 3] = "─";
            Shop.Instance.ShopDimentions[7, 4] = "─";
            Shop.Instance.ShopDimentions[7, 5] = "─";
            Shop.Instance.ShopDimentions[7, 6] = "┐";
            Shop.Instance.ShopDimentions[8, 2] = "│";
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Shop.Instance.ShopDimentions[8, 4] = WandUpperSymbol;
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[9, 2] = "│";
            Shop.Instance.ShopDimentions[8, 6] = "│";
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Shop.Instance.ShopDimentions[9, 4] = WandLowerSymbol;
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[9, 6] = "│";
            Shop.Instance.ShopDimentions[10, 2] = "└";
            Shop.Instance.ShopDimentions[10, 3] = "─";
            Shop.Instance.ShopDimentions[10, 4] = "─";
            Shop.Instance.ShopDimentions[10, 5] = "─";
            Shop.Instance.ShopDimentions[10, 6] = "┘";
        }

        public void ProduceQuartzWand()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[7, 2] = "┌";
            Shop.Instance.ShopDimentions[7, 3] = "─";
            Shop.Instance.ShopDimentions[7, 4] = "─";
            Shop.Instance.ShopDimentions[7, 5] = "─";
            Shop.Instance.ShopDimentions[7, 6] = "┐";
            Shop.Instance.ShopDimentions[8, 2] = "│";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[8, 4] = WandUpperSymbol;
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[9, 2] = "│";
            Shop.Instance.ShopDimentions[8, 6] = "│";
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[9, 4] = WandLowerSymbol;
            Console.ForegroundColor = ConsoleColor.Gray;
            Shop.Instance.ShopDimentions[9, 6] = "│";
            Shop.Instance.ShopDimentions[10, 2] = "└";
            Shop.Instance.ShopDimentions[10, 3] = "─";
            Shop.Instance.ShopDimentions[10, 4] = "─";
            Shop.Instance.ShopDimentions[10, 5] = "─";
            Shop.Instance.ShopDimentions[10, 6] = "┘";
        }
    }
}
