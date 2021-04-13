using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace FinalProject101_RonBandel
{
    class Player
    {
        private static Player instance;
        public Potion[] potionPouch = new Potion[5];
        public bool alive = true;
        public int maxHP = 10;
        public int currentHP = 8;
        public int currentColumn;
        public int currentRow;
        Random rand = new Random();
        public int armor = 5;
        public int levelTimer = 0;
        public int gold = 200;
        public int luck = 0;

        public int timeSinceLastShot = 50;
        public int baseJabCD = 50;
        public int baseJabRange = 3;
        public int baseJabDamage = 1;
        public int baseEvadeChance = 10;
        public int baseCritChance = 10;
        public int baseCritMultiplier = 2;

        public int tempDamageBonus = 0;
        public int tempJabRangeBonus = 0;
        public int tempAttackSpeedBonus = 0;
        public int tempCritChanceBonus = 0;
        public int tempCritMultiplier = 0;
        public int tempEvadeChance = 0;
        public int tempPotionPower = 1;

        int finalJabDamage
        {
            get
            {
                int result = baseJabDamage + tempDamageBonus * tempPotionPower;
                if (rand.Next(1, 101) < finalCritChance)
                {
                    result *= finalCritMultiplier;
                    HUD.NewHUDEntry("You've landed a Critical Hit!");
                }
                return result;
            }
        }
        int finalJabRange
        {
            get
            {
                return baseJabRange + (tempJabRangeBonus * tempPotionPower);
            }
        }
        int finalJabCD
        {
            get
            {
                int result = baseJabCD - (tempAttackSpeedBonus * tempPotionPower);
                if ( result > 0 )
                {
                    return result;
                }
                else
                {
                    return 0;
                }
                
            }
        }
        int finalCritChance
        {
            get
            {
                return baseCritChance + (tempCritChanceBonus * tempPotionPower);
            }
        }
        int finalCritMultiplier
        {
            get 
            {
                return baseCritMultiplier + (tempCritMultiplier * tempPotionPower);
            }
        }
        int finalEvadeChance
        {
            get
            {
                return baseEvadeChance + (tempEvadeChance*tempPotionPower);
            }
        }

        private Player()
        {
        }

        public static Player Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Player();
                }
                return instance;
            }
        }


        public void PlayerUpdate()
        {
            PlayerInput();
            //PlacePlayerIconOnMapNoRefresh(map);
            timeSinceLastShot++;
            levelTimer++;   // 50+ every second
        }

        // ------------ Player Input -----------
        public bool PlayerInput()
        {
            if (Console.KeyAvailable)
            {
                var input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case (ConsoleKey.D): // move right
                        MovePlayer(currentRow, currentColumn + 1);                                
                        return true;

                    case (ConsoleKey.A): // move left
                        MovePlayer(currentRow, currentColumn - 1);
                        return true;

                    case (ConsoleKey.W): // move up
                        MovePlayer(currentRow - 1, currentColumn);
                        return true;

                    case (ConsoleKey.S): // move down
                        MovePlayer(currentRow + 1, currentColumn);
                        return true;

                    case (ConsoleKey.UpArrow): // shoot Up
                        JabUp();
                        return true;

                    case (ConsoleKey.DownArrow): // shoot Down
                        JabDown();
                        return true;

                    case (ConsoleKey.RightArrow): // shoot Right
                        JabRight();
                        return true;

                    case (ConsoleKey.LeftArrow): // shoot Left
                        JabLeft();
                        return true;

                    case (ConsoleKey.D1): // Drink Potion 1
                        DrinkPotionInSlot(0);
                        return true;

                    case (ConsoleKey.D2): // Drink Potion 2
                        DrinkPotionInSlot(1);
                        return true;

                    case (ConsoleKey.D3): // Drink Potion 3
                        DrinkPotionInSlot(2);
                        return true;

                    case (ConsoleKey.D4): // Drink Potion 4
                        DrinkPotionInSlot(3);
                        return true;

                    case (ConsoleKey.D5): // Drink Potion 5
                        DrinkPotionInSlot(4);
                        return true;

                    case (ConsoleKey.M): // Mute all Sounds
                        SoundManager.Instance.ChangeMuteMode();
                        return true;

                    case (ConsoleKey.N): // Mute enemy death sounds only omg its so annoying why
                        SoundManager.Instance.ChangeEnemyDeathSoundMuteMode();
                        return true;
                }

            }
            return false;
        }

        // ------------ Player Level Up---------
        public void PlayerResetTempStats()
        {
            levelTimer = 0;
            tempDamageBonus = 0;
            tempJabRangeBonus = 0;
            tempAttackSpeedBonus = 0;
            tempCritChanceBonus = 0;
            tempCritMultiplier = 0;
            tempEvadeChance = 0;
            tempPotionPower = 1;
        }

        void DetermineGoldLevelClear()
        {
            if ( Map.numberOfNonMerchantInstances != 0) //  you dont get gold for merchant levels
            {
                int levelTimerInSeconds = levelTimer / 50;
                int goldReceived = Map.level * (60 / levelTimerInSeconds);
                GainGold(goldReceived);
                HUD.NewHUDEntry("You got " + goldReceived + "g for clearing the level!");
            }            
        }

        // ------------ Player Items ----------

        void DrinkPotionInSlot(int potionNumber)
        {
            if (potionPouch[potionNumber] != null)
            {
                potionPouch[potionNumber].Drink();
                potionPouch[potionNumber] = null;
                PrintPlayerPotions();
            }            
        }

        public void PrintPlayerPotions()
        {
            int potionStartingPosition = 12;

            for (int i = 0; i<5; i++)
            {                
                Console.SetCursorPosition(potionStartingPosition + i, 23);
                Console.Write(" "); // delete old pot in slot
                Console.SetCursorPosition(potionStartingPosition + i, 23);
                if (potionPouch[i] != null)
                {
                    switch (potionPouch[i].potionName)
                    {
                        case "Healing Potion":
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;

                        case "Strength Potion":
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            break;

                        case "Sniper Potion":
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;

                        case "Assassin Potion":
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            break;

                        case "Fortify Potion":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;

                        default:
                            break;
                    }

                    Console.Write(i+1);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                potionStartingPosition++;
            }
        }   //  end of PrintPlayerPotions

        public void GainGold(int goldGained)
        {
            if (gold + goldGained >= 999)
            {
                gold = 999;
            }
            else
            {
                gold += goldGained;
            }            
            PrintPlayerGold();
            SoundManager.Instance.PlayGainGoldSound();
        }

        public void SpendGold(int goldSpent)
        {
            gold -= goldSpent;
            PrintPlayerGold();
            SoundManager.Instance.PlayBuySound();
        }

        public void PrintPlayerGold()
        {
            int startingGoldStringPosition = 39;
            string goldString = (gold.ToString() + GameIcons.gold);
            int numberOfEmptySpacesDesired = 3 - gold.ToString().Length;
            int goldStringLength = goldString.Length;

            //  delete old
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(startingGoldStringPosition + i, 23);
                Console.Write(" ");
            }

            for (int i = 0; i < numberOfEmptySpacesDesired; i++)
            {
                startingGoldStringPosition++;
            }
            Console.SetCursorPosition(startingGoldStringPosition, 23);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(goldString);
            Console.ForegroundColor = ConsoleColor.Gray;           
        }

        // ------------ Player Movement -----------
        void MovePlayer(int targetRow, int targetColumn)
        {
            if (Map.CheckForBossParts(targetRow, targetColumn))
            {
                TakeDamage(1);
                HUD.NewHUDEntry("Don't ram into the boss!");
            }
            else if (Map.mapLayout[targetRow, targetColumn] == GameIcons.merchant)
            {
                Merchant.Instance.WordsOfWisdom();
            }
            else if (!Map.CheckForWalls(targetRow, targetColumn))
            {
                // delete old player avatar from console
                Console.SetCursorPosition(currentColumn, currentRow);
                Console.Write(GameIcons.emptySpace);
                // delete old player avatar from the map[]
                Map.mapLayout[currentRow, currentColumn] = GameIcons.emptySpace;
                ChangeCordinates(targetRow, targetColumn);
                CheckForInteractables(targetRow, targetColumn);
                Map.mapLayout[currentRow, currentColumn] = GameIcons.player;
                Console.SetCursorPosition(currentColumn, currentRow);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(GameIcons.player);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        void ChangeCordinates(int yTarget, int xTarget)
        {
            if ( (yTarget == currentRow) && (xTarget == currentColumn + 1) )
            {
                currentColumn++;
            }
            else if ((yTarget == currentRow) && (xTarget == currentColumn - 1))
            {
                currentColumn--;
            }
            else if ((yTarget == currentRow - 1) && (xTarget == currentColumn))
            {
                currentRow--;
            }
            else if ((yTarget == currentRow + 1) && (xTarget == currentColumn))
            {
                currentRow++;
            }
        }

        void CheckForInteractables(int targetRow, int targetColumn)
        {
            if (Map.mapLayout[targetRow, targetColumn] == GameIcons.enemy)
            {
                TakeDamage(Map.level);
                EnemyManager.Instance.KillEnemy(targetColumn, targetRow);
            }
            else if (Map.mapLayout[targetRow, targetColumn] == GameIcons.mine)
            {
                TakeDamage(1 + Map.level/10);
            }
            else if (Map.mapLayout[targetRow, targetColumn] == GameIcons.invisibleMine)
            {
                TakeDamage(1 + Map.level / 10);
                HUD.NewHUDEntry("You've stepped on a hidden mine!");
            }
            else if(Map.mapLayout[targetRow, targetColumn] == GameIcons.apple)
            {
                Heal(1);
            }
            else if(Map.mapLayout[targetRow, targetColumn] == GameIcons.treasureChest)
            {
                Treasure.Instance.GenerateSeededTreasure(rand.Next(1, 101));
            }
            else if (Map.mapLayout[targetRow, targetColumn] == GameIcons.shelf)
            {
                Merchant.Instance.BuyItemFromShelf();
            }
            else if (Map.mapLayout[targetRow, targetColumn] == GameIcons.codexPage)
            {
                Merchant.Instance.DecipherSecretLetter();
            }
            else if (Map.mapLayout[targetRow, targetColumn] == GameIcons.exit)
            {
                DetermineGoldLevelClear();
                Map.GenerateRandomMap();
            }
        }

        // ------------ Player Attack -----------

        void JabAnimationAndInteraction(int xCords, int yCords, string jabShape)
        {
            if (Map.mapLayout[yCords, xCords] == GameIcons.enemy)
            {
                EnemyManager.Instance.DealDamageToEnemy(xCords, yCords, finalJabDamage);                
            }
            else if(Map.CheckForBossParts(yCords, xCords))
            {
                EnemyManager.Instance.DealDamageToBoss(finalJabDamage);
            }
            else
            {
                Console.SetCursorPosition(xCords, yCords);
                Console.Write(jabShape);
                Thread.Sleep(20);
                Console.SetCursorPosition(xCords, yCords);
                Console.Write(GameIcons.emptySpace);
                Map.mapLayout[yCords, xCords] = GameIcons.emptySpace;
            }
        }

        void JabUp()
        {
            string upJab = "^";
            if (timeSinceLastShot >= finalJabCD)
            {
                timeSinceLastShot = 0;
                for (int i = 0; i < finalJabRange; i++)
                {
                    if (currentRow - 1 - i > 0) // check that shot doesnt go out of bounds (upper bound of mapLayout)
                    {
                        if (Map.CheckForWalls(currentRow - 1 - i, currentColumn) ||
                            Map.mapLayout[currentRow - 1 - i, currentColumn] == GameIcons.treasureChest ||
                            Map.mapLayout[currentRow - 1 - i, currentColumn] == GameIcons.shelf)
                        {
                            break; // stop shot once it hits the wall
                        }
                        else
                        {
                            JabAnimationAndInteraction(currentColumn, currentRow - 1 - i, upJab);
                        }
                    }                    
                }
            }            
        }

        void JabDown()
        {
            string downJab = "v";
            if (timeSinceLastShot >= finalJabCD)
            {
                timeSinceLastShot = 0;
                for (int i = 0; i < finalJabRange; i++)
                {
                    if (currentRow + 1 + i > 0) // check that shot doesnt go out of bounds (lower bound of mapLayout)
                    {
                        if (Map.CheckForWalls(currentRow + 1 + i, currentColumn) ||
                            Map.mapLayout[currentRow + 1 + i, currentColumn] == GameIcons.treasureChest ||
                            Map.mapLayout[currentRow + 1 + i, currentColumn] == GameIcons.shelf)
                        {
                            break; // stop shot once it hits the wall
                        }
                        else
                        {
                            JabAnimationAndInteraction(currentColumn, currentRow + 1 + i, downJab);
                        }
                    }
                }
            }
        }

        void JabRight()
        {
            string rightJab = ">";
            if (timeSinceLastShot >= finalJabCD)
            {
                timeSinceLastShot = 0;
                for (int i = 0; i < finalJabRange; i++)
                {
                    if (currentColumn + 1 + i > 0) // check that shot doesnt go out of bounds (lower bound of mapLayout)
                    {
                        if (Map.CheckForWalls(currentRow, currentColumn + 1 + i) ||
                            Map.mapLayout[currentRow, currentColumn + 1 + i] == GameIcons.treasureChest ||
                            Map.mapLayout[currentRow, currentColumn + 1 + i] == GameIcons.shelf)
                        {
                            break; // stop shot once it hits the wall
                        }
                        else
                        {
                            JabAnimationAndInteraction(currentColumn + 1 + i, currentRow, rightJab);
                        }
                    }
                }
            }
        }

        void JabLeft()
        {
            string leftJab = "<";
            if (timeSinceLastShot >= finalJabCD)
            {
                timeSinceLastShot = 0;
                for (int i = 0; i < finalJabRange; i++)
                {
                    if (currentColumn - 1 - i > 0) // check that shot doesnt go out of bounds (lower bound of mapLayout)
                    {
                        if (Map.CheckForWalls(currentRow, currentColumn - 1 - i) ||
                            Map.mapLayout[currentRow, currentColumn - 1 - i] == GameIcons.treasureChest ||
                            Map.mapLayout[currentRow, currentColumn - 1 - i] == GameIcons.shelf)
                        {
                            break; // stop shot once it hits the wall
                        }
                        else
                        {
                            JabAnimationAndInteraction(currentColumn - 1 - i, currentRow, leftJab);
                        }
                    }
                }
            }
        }

        // ------------ Player HP -----------

        public void TakeDamage(int damageAmount)
        {
            if (rand.Next(1,101) < finalEvadeChance)
            {
                HUD.NewHUDEntry("You've evaded the attack!");
            }
            else
            {
                ArmorAbsorbDamage(damageAmount);
                Flicker();
                PrintPlayerHPAndArmor();
                if (currentHP <= 0)
                {
                    PlayerLost();
                }
                SoundManager.Instance.PlayTakeDamagehSound();
            }            
        }

        void ArmorAbsorbDamage(int damageAmount)
        {
            if (damageAmount > 1)
            {
                damageAmount--;
                currentHP--;
                if (damageAmount > armor)
                {
                    damageAmount -= armor;
                    armor = 0;
                    currentHP -= damageAmount;
                }
                else
                {
                    armor -= damageAmount;
                }
            }
            else
            {
                currentHP -= damageAmount;
            }
        }

        public void Flicker()
        {
            Console.SetCursorPosition(currentColumn, currentRow);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(GameIcons.player);
            Thread.Sleep(50);
            Console.SetCursorPosition(currentColumn, currentRow);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(GameIcons.player);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void Heal(int healAmount)
        {
            if ((currentHP + healAmount) < maxHP)
            {
                currentHP += healAmount;
            }
            else
            {
                currentHP = maxHP;
            }
            PrintPlayerHPAndArmor();
        }

        public void PrintPlayerHPAndArmor()
        {
            int heartStartingPosition = 1;
            bool halfHeart = false;
            string heart = "♥";
            string JJ = "\u26f5";
            //const char H = '\u&#x1F5A4';
            //char heartSymbol = '&#x1F5A4';
            ////string hex = ((int)c).ToString("X4"); // Now hex = "0123"
            //string heartSymbolSymbol = ((int)heartSymbol).ToString("X");

            for (int i = 0; i < (maxHP / 2); i++)
            {
                // 0 1 2 3 4
                // ♥ ♥ ♥ 💔 🤍


                if ((currentHP / 2) > i) // print a 'full' heart for every 2 current life
                {
                    Console.SetCursorPosition(heartStartingPosition, 23);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(heart);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    heartStartingPosition++;
                }
                else if ((currentHP % 2 == 1) && !halfHeart) // print a 'half' heart for odd-numbered current life
                {
                    Console.SetCursorPosition(heartStartingPosition, 23);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(heart);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    halfHeart = true;
                    heartStartingPosition++;
                }
                else // print an 'empty' heart for the rest
                {
                    Console.SetCursorPosition(heartStartingPosition, 23);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(heart);
                    heartStartingPosition++;
                }
            }

            heartStartingPosition++;
            
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(heartStartingPosition + i, 23);
                Console.Write(" ");
            }
            Console.SetCursorPosition(heartStartingPosition, 23);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(heart+armor);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // ------------ Player Losing -----------

        void PlayerLost()
        {
            alive = false;
            Console.Clear();
            PrintPlayerLostScreen();
        }
        
        void PrintPlayerLostScreen()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ---------------------- ");
            Console.Write("|       ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("You Lost!");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("      |\n");
            Console.WriteLine(" ---------------------- ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Press any key to Quit");
            Console.ReadKey();
            System.Environment.Exit(0);
        }
    }
}