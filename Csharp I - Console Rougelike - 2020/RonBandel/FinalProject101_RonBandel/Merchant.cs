using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject101_RonBandel
{
    class Merchant
    {
        public static Merchant instance;
        Random rand = new Random();
        public static int[,] goods = new int[6,2];  //  seed && price
        List<string> merchantLines = new List<string>();
        public static Merchant Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Merchant();
                }
                return instance;
            }
        }

        private Merchant()
        {
            InitializeMerchantLines();
        }

        public void SetUpShop()
        {
            InitializeMerchantGoodsValues();
            PrintGoodsOntoConsole();
        }

        public void InitializeMerchantGoodsValues()
        {
            Random rand = new Random(Map.level * Player.Instance.luck);
            for (int i = 0; i < 3; i++)
            {
                goods[i,0] = rand.Next(1, 101); // determine Potion Type
                goods[i, 1] = rand.Next(10, 26);    //  determine Price
            }
            for (int i = 3; i < 6; i++)
            {
                goods[i, 0] = rand.Next(1, 101); // determine Weapon Type
                goods[i, 1] = rand.Next(75, 200);    //  determine Price
            }
            
        }

        public void PrintGoodsOntoConsole()
        {
            string standSign;
            int standsCordsX = 9;
            int standsCordsY = 4;

            Map.mapLayout[11, 11] = GameIcons.merchant;
            Console.SetCursorPosition(11, 11);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(GameIcons.merchant);

            for (int i = 0; i < 6; i++)
            {
                // Set up Sign (price and name)
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(standsCordsX, standsCordsY);                
                standSign = goods[i, 1] + "$";
                Console.Write(standSign);
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.Write(FindNameOfItem(i));
                Map.BuildHorizontalWall(standsCordsX, standsCordsY, standSign.Length + FindNameOfItem(i).Length);
                // Set up shelf
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(standsCordsX - 2, standsCordsY);
                Console.Write(GameIcons.shelf);
                Map.mapLayout[standsCordsY, standsCordsX - 2] = GameIcons.shelf;
                standsCordsY += 2;
                if (standsCordsY == 10)
                {
                    standsCordsY += 5;
                }
            }
         
  
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        string FindNameOfItem(int seed)
        {
            if (seed < 3)     // Potions
            {
                if (goods[seed, 0] <= (Treasure.Instance.potionStatistic*1))
                {
                    return "HealingPotion";
                }
                else if (goods[seed, 0] > (Treasure.Instance.potionStatistic * 1) && 
                         goods[seed, 0] <= (Treasure.Instance.potionStatistic * 2))
                {
                    return "StrengthPotion";
                }
                else if (goods[seed, 0] > (Treasure.Instance.potionStatistic * 2) &&
                         goods[seed, 0] <= (Treasure.Instance.potionStatistic * 3))
                {
                    return "SniperPotion";
                }
                else if (goods[seed, 0] > (Treasure.Instance.potionStatistic * 3) &&
                         goods[seed, 0] <= (Treasure.Instance.potionStatistic * 4))
                {
                    return "AssassinPotion";
                }
                else if (goods[seed, 0] > (Treasure.Instance.potionStatistic * 4) &&
                         goods[seed, 0] <= (Treasure.Instance.potionStatistic * 5))
                {
                    return "FortifyPotion";
                }
                else
                {
                    return "PowerfullPotion";
                }
            }
            else
            {
                if (goods[seed, 0] <= (Treasure.Instance.weaponStatistic * 1))
                {
                    return "BattleAxe";
                }
                else if (goods[seed, 0] > (Treasure.Instance.weaponStatistic * 1) &&
                         goods[seed, 0] <= (Treasure.Instance.weaponStatistic * 2))
                {
                    return "Dagger";
                }
                else if (goods[seed, 0] > (Treasure.Instance.weaponStatistic * 2) &&
                         goods[seed, 0] <= (Treasure.Instance.weaponStatistic * 3))
                {
                    return"BowAndArrow";
                }
                else if (goods[seed, 0] > (Treasure.Instance.weaponStatistic * 3) &&
                         goods[seed, 0] <= (Treasure.Instance.weaponStatistic * 4))
                {
                    return"Sabre";
                }
                else if (goods[seed, 0] > (Treasure.Instance.weaponStatistic * 4) &&
                         goods[seed, 0] <= (Treasure.Instance.weaponStatistic * 5))
                {
                    return "Shield";
                }
                else
                {
                    return"JaggedSword";
                }
            }
        }

        public void BuyItemFromShelf()
        {
            switch (Player.Instance.currentRow)
            {
                case 4:
                    if (Player.Instance.gold >= goods[0, 1])
                    {
                        Player.Instance.SpendGold(goods[0, 1]);
                        Treasure.Instance.AddSeededPotionToPouch(goods[0, 0]);
                    }                    
                    break;

                case 6:
                    if (Player.Instance.gold >= goods[1, 1])
                    {
                        Player.Instance.SpendGold(goods[1, 1]);
                        Treasure.Instance.AddSeededPotionToPouch(goods[1, 0]);
                    }
                    break;

                case 8:
                    if (Player.Instance.gold >= goods[2, 1])
                    {
                        Player.Instance.SpendGold(goods[2, 1]);
                        Treasure.Instance.AddSeededPotionToPouch(goods[2, 0]);
                    }
                    break;

                case 15:
                    if (Player.Instance.gold >= goods[3, 1])
                    {
                        Player.Instance.SpendGold(goods[3, 1]);
                        Treasure.Instance.GetSeededWeapon(goods[3, 0]);
                    }
                    break;

                case 17:
                    if (Player.Instance.gold >= goods[4, 1])
                    {
                        Player.Instance.SpendGold(goods[4, 1]);
                        Treasure.Instance.GetSeededWeapon(goods[4, 0]);
                    }
                    break;

                case 19:
                    if (Player.Instance.gold >= goods[5, 1])
                    {
                        Player.Instance.SpendGold(goods[5, 1]);
                        Treasure.Instance.GetSeededWeapon(goods[5, 0]);
                    }
                    break;

            }
        }
        
        public void InitializeMerchantLines()
        {
            merchantLines.Clear();
            merchantLines.Add("My potions are too powerfull!");
            merchantLines.Add("So uh, you gonna buy something or...?");
            merchantLines.Add("Hey, stop that!");
            merchantLines.Add("You got a thing for poking, don't you?");
            merchantLines.Add("Bussiness first, pleasure later");
            merchantLines.Add("This place ain't big en- oh wait it is");
            merchantLines.Add("The Sabre makes you crit more often!");
            merchantLines.Add("The Jagged Sword makes you crit harder!");
            merchantLines.Add("The Battle Axe makes you hit harder!");
            merchantLines.Add("Shields give armor, as well as evasion!");
            merchantLines.Add("Daggers make you attack faster!");
            merchantLines.Add("Bows make your attacks reach further!");
            merchantLines.Add("§ ¶ ↑ ► § » Θ ¶ ♦ α ▬");
            merchantLines.Add("§ ¶ ↓ ► ♣ » Θ ¶ ß δ ╢ T");
        }
        
        public void WordsOfWisdom()
        {
            HUD.NewHUDEntry(merchantLines[rand.Next(0, merchantLines.Count)]);
            SoundManager.Instance.PlayMerchantSound();
        }

        public void DecipherSecretLetter()
        {
            int letterNumber = rand.Next(1, 9);
            switch (letterNumber)
            {
                case 1:
                    HUD.NewHUDEntry("§ = Powerfull / Power");
                    break;

                case 2:
                    HUD.NewHUDEntry("¶ = Potion, Θ = Other");
                    break;

                case 3:
                    HUD.NewHUDEntry("T = Treasure Chests, ▬ = Stage");
                    break;

                case 4:
                    HUD.NewHUDEntry("δ = Drop, ♣ = Chance");
                    break;

                case 5:
                    HUD.NewHUDEntry("↑ = Increase, ↓ = Decrease");
                    break;

                case 6:
                    HUD.NewHUDEntry("╢ = From, ♦ = For / Four");
                    break;

                case 7:
                    HUD.NewHUDEntry("α = One, ß = Two / To");
                    break;

                case 8:
                    HUD.NewHUDEntry("► = The, » = Of");
                    break;
            }
        }
    }

}
