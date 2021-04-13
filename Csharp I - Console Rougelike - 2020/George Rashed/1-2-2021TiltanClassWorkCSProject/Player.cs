using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_2_2021TiltanClassWorkCSProject
{
    class Player
    {
        public int Level = 0;
        public static bool IsDead = false;


        // General Player Data:
        public static string CharacterName;
        public static int BaseHP;
        public static int CurrentHP;
        public static string HeldWeapon;
        public static int MinDamage;
        public static int MaxDamage;
        public static int WeaponLevel;
        public static int Coins;
        public static int HealthPacks;
        public static int SpecialA;
        public static float DodgeChance;


        // Assigning Values To Player Instance
        public Player(string name)
        {
            CharacterName = name;
            BaseHP = 10;
            CurrentHP = BaseHP;
            HeldWeapon = "Hands";
            MinDamage = 0;
            MaxDamage = 3;
            WeaponLevel = 0;
            Coins = 1;
            HealthPacks = 4;
            SpecialA = 1;
            DodgeChance = 0.4f;
        }



        //--------------------
        // Functions/Methods:


        //  Display Stats
        public static void DisplayStats(int mapRow, int level)
        {
            Console.SetCursorPosition(0, mapRow);
            Console.WriteLine("/--------------------------------------------------/");
            Console.WriteLine("|                                                   ");
            Console.WriteLine("|                                                   ");
            Console.WriteLine("|                                                   ");
            Console.WriteLine("|                                                   ");
            Console.WriteLine("|                                                   ");
            Console.WriteLine("|                                                   ");
            Console.WriteLine("/--------------------------------------------------/");
            Console.SetCursorPosition(0, mapRow);
            Console.WriteLine("/--------------------------------------------------/");
            Console.WriteLine("| Level:" + level);
            Console.WriteLine("| " + CharacterName + "'s Current Stats Are:");
            Console.WriteLine("| " + CurrentHP + "/" + BaseHP + " Health Points");
            Console.WriteLine("| Carried Weapon: " + HeldWeapon + "(" + MinDamage + "-" + MaxDamage + " Damage)");
            Console.WriteLine("| " + Coins + " Coins");
            Console.WriteLine("| " + HealthPacks + " HealthPacks");
            Console.WriteLine("/--------------------------------------------------/");
        }

        public static string Intro()
        {
            // Little Intro
            Console.WriteLine(CharacterName + "! Hello There Adventurer");
            Console.WriteLine("Use The 'Arrow Keys' To Move");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("'|' and '-' = Walls");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("'@' = You");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("'E' = Entrance");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("'X' = Exit");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("'*' = Trap");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("'M' = Enemy");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("'#' = Treasure Chest");
            Console.ResetColor();
            Console.Write("Click 'Enter' To Continue");
            Console.ReadLine();
            Console.Clear();

            string gameModeChoice = "";
            bool gameMode = true;
            while (gameMode)
            {
                ConsoleKeyInfo keyInfo;
                Console.WriteLine("Which Game Mode Would You Like To Play?");
                Console.WriteLine("    ?? '1.Story' OR '2.Survival' ??    ");
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        gameModeChoice = "Story";
                        gameMode = false;
                        Console.Clear();
                        Console.WriteLine("You Are Stuck In A Dungeon Of Violent Potatoes!");
                        Console.WriteLine("You Are On The 1st Level & You Can Only Go Up");
                        Console.WriteLine("Your Goal? Reach The Exit On The 11th Level");
                        Console.WriteLine("Good Luck '" + CharacterName + "' & Do Your Best!");
                        break;
                    case ConsoleKey.D2:
                        gameModeChoice = "Survival";
                        gameMode = false;
                        Console.Clear();
                        Console.WriteLine("You Are Stuck In An Infinite Dungeon Of Violent Potatoes!");
                        Console.WriteLine("You Are On The 1st Level & You Can Only Go Up");
                        Console.WriteLine("How Long Can You Survive?");
                        Console.WriteLine("Good Luck '" + CharacterName + "' & Do Your Best!");
                        break;
                    default:
                        gameMode = true;
                        Console.Clear();
                        break;
                }
            }

            Console.WriteLine("Press 'ENTER' To Continue");
            Console.ReadLine();
            Console.Clear();
            return gameModeChoice;
        }

        // Calculating Damage
        public static int DamageCalc()
        {
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
        }

        // Trap Damage Function
        public void TrapDamage(int mapRow, int level)
        {
            CurrentHP --;
            DisplayStats(mapRow, level);
            Console.WriteLine("=====================================");
            Console.WriteLine("|You Took Trap Damage! You Lost -1HP|");
            Console.WriteLine("=====================================");

            CheckDeath();
        }

        public static bool CheckDeath()
        {
            IsDead = false;
            if (Player.CurrentHP <= 0)
            {
                AudioManager.getAudioManagerInstance.RunGameOverMusic();

                IsDead = true;
                Console.WriteLine("********** You Are Dead **********");
                Console.WriteLine("************ GAME OVER ***********");
                Console.WriteLine("        Try Again Next Time");
                Console.WriteLine("       Thank You For Playing!");
                Console.WriteLine("                                  ");
                Console.WriteLine("      Press 'ESCAPE' To Quit");
                Console.WriteLine("     Press 'ENTER' To Try Again");
                ConsoleKeyInfo keyInfo;
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        System.Environment.Exit(-1);
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        break;
                    default:
                        CheckDeath();
                        break;
                }
            }
            return IsDead;

        }

        public void CollectTreasureChest(int rowSize)
        {
            Console.SetCursorPosition(0, rowSize + 8);
            Console.WriteLine("===================================================");
            Console.WriteLine("|You Found A Treasure Chest & Found '1' Gold Coin!|");
            Console.WriteLine("===================================================");
            Coins++;
        }


        // Market Gear
        public void MarketGear(int rowSize, int level)
        {
            bool skipMarket = false;
            ConsoleKeyInfo keyInfo;
            Console.WriteLine("Before You Head Further");
            Console.WriteLine("You Find A Mini-Market!");


            while (Coins > 0 && skipMarket == false)
            {
                Console.WriteLine("=======================");
                Console.WriteLine("What Would You Like To Buy?");
                Console.WriteLine("1.Armor(Increases HP), 2.New_Weapon(Increases Damage), 3.HealthPack(Adds HealthPack), 4.Skip");
                keyInfo = Console.ReadKey(true);
                Console.WriteLine("");
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Coins = Coins - 1;
                        BaseHP = BaseHP + 10;
                        Console.WriteLine("You Bought Some Armor For '1' Coin");
                        Console.WriteLine("Your BaseHP Is Now At '" + BaseHP + "' HP");
                        Console.WriteLine("Just Remember, This Does NOT Heal You!");
                        break;
                    case ConsoleKey.D2:
                        Coins = Coins - 1;
                        Console.WriteLine("You Spent '1' Coin On A Weapon");
                        if (HeldWeapon == "Hands")
                        {
                            HeldWeapon = "Dagger";
                            MaxDamage = MaxDamage * 2;
                            Console.WriteLine("You Just Upgraded Your Weapon To: ");
                            Console.WriteLine("The " + HeldWeapon + "(" + MinDamage + "-" + MaxDamage + " Damage)");
                        }
                        else if (HeldWeapon == "Dagger")
                        {
                            HeldWeapon = "Sword";
                            MaxDamage = MaxDamage * 2;
                            Console.WriteLine("You Just Upgraded Your Weapon To: ");
                            Console.WriteLine("The " + HeldWeapon + "(" + MinDamage + "-" + MaxDamage + " Damage)");
                        }
                        else if (HeldWeapon == "Sword")
                        {
                            HeldWeapon = "BroadSword";
                            MaxDamage = MaxDamage * 2;
                            Console.WriteLine("You Just Upgraded Your Weapon To: ");
                            Console.WriteLine("The " + HeldWeapon + "(" + MinDamage + "-" + MaxDamage + " Damage)");
                        }
                        else if (HeldWeapon == "BroadSword")
                        {
                            HeldWeapon = "Magical BroadSword";
                            MaxDamage = MaxDamage * 2;
                            Console.WriteLine("You Just Upgraded Your Weapon To: ");
                            Console.WriteLine("The " + HeldWeapon + "(" + MinDamage + "-" + MaxDamage + " Damage)");
                        }
                        else if (HeldWeapon == "Magical BroadSword")
                        {
                            HeldWeapon = "BattleAxe";
                            MaxDamage = MaxDamage * 2;
                            Console.WriteLine("You Just Upgraded Your Weapon To: ");
                            Console.WriteLine("The " + HeldWeapon + "(" + MinDamage + "-" + MaxDamage + " Damage)");
                        }
                        else if (HeldWeapon == "BattleAxe")
                        {
                            HeldWeapon = "Great Scythe";
                            MaxDamage = MaxDamage * 2;
                            Console.WriteLine("You Just Upgraded Your Weapon To: ");
                            Console.WriteLine("The " + HeldWeapon + "(" + MinDamage + "-" + MaxDamage + " Damage)");
                        }
                        else if (HeldWeapon == "Great Scythe")
                        {
                            HeldWeapon = "Claymore";
                            MaxDamage = MaxDamage * 2;
                            Console.WriteLine("You Just Upgraded Your Weapon To: ");
                            Console.WriteLine("The " + HeldWeapon + "(" + MinDamage + "-" + MaxDamage + " Damage)");
                        }
                        else if (HeldWeapon == "Claymore")
                        {
                            HeldWeapon = "Black Knight GreatSword";
                            MaxDamage = MaxDamage * 2;
                            Console.WriteLine("You Just Upgraded Your Weapon To: ");
                            Console.WriteLine("The " + HeldWeapon + "(" + MinDamage + "-" + MaxDamage + " Damage)");
                        }
                        else if (HeldWeapon == "BroadSword")
                        {
                            HeldWeapon = "Black Knight Halberd";
                            MaxDamage = MaxDamage * 2;
                            Console.WriteLine("You Just Upgraded Your Weapon To: ");
                            Console.WriteLine("The " + HeldWeapon + "(" + MinDamage + "-" + MaxDamage + " Damage)");
                        }
                        else if (level >= 10)
                        {
                            WeaponLevel++;
                            HeldWeapon = "Black Knight Halberd +" + WeaponLevel;
                            MaxDamage = MaxDamage * 2;
                            Console.WriteLine("You Just Upgraded Your Weapon To: ");
                            Console.WriteLine("The " + HeldWeapon + " (" + MinDamage + "-" + MaxDamage + " Damage)");
                        }
                        break;
                    case ConsoleKey.D3:
                        Coins = Coins - 1;
                        HealthPacks = HealthPacks + 1;
                        Console.WriteLine("You Bought Another HealthPack For '1' Coin!");
                        Console.WriteLine("You Now Hold '" + HealthPacks + "' HealthPacks");
                        if (CurrentHP != BaseHP)
                        {
                            Console.WriteLine("Huh, Apparently Looking At The New HealthPack Was Enough To Fully Recover Your HP!");
                            CurrentHP = BaseHP;
                        }
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("You Chose To Skip");
                        Console.WriteLine("Regret Might Be Upon You Adventurer...");
                        skipMarket = true;
                        break;
                    default:
                        Map.ClearNoteBoard(rowSize);
                        MarketGear(rowSize, level);
                        break;
                }
                if (skipMarket == false)
                {
                    Console.WriteLine("Press 'ENTER' To Continue");
                    Console.ReadLine();
                    DisplayStats(rowSize, level);
                    Map.ClearNoteBoard(rowSize);
                }
            }
            if (skipMarket == false)
            {
                Console.WriteLine("You Are Out Of Coins!?");

            }
            Console.WriteLine("There Is No Use In Waiting Here Anymore");
            Console.WriteLine("Press 'ENTER' To Continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
