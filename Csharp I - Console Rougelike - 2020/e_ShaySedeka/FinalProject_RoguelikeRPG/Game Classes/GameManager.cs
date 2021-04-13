using FinalProject_RoguelikeRPG.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinalProject_RoguelikeRPG.GameDefinitions;

namespace FinalProject_RoguelikeRPG
{
    class GameManager
    {
        #region Class Members

        Player player, playerAtLevelStart;
        GameLevel currentLevel;
        Shop shop;
        EventLog eventLog;
        public static MusicManager music;


        bool isMainLoopActive;

        #endregion

        public GameManager()
        {
            isMainLoopActive = false;
            Console.CursorVisible = false;

            PrepareNewGame();

            music = new MusicManager();
            music.PlayAmbientMusic();

            PrintGameStartText();
            StartMainLoop();
 
        }

        #region Game Flow Management Methods

        public void StartMainLoop()
        {
            PrintGameInfo();
            this.isMainLoopActive = true;

            while (this.isMainLoopActive)
            {
                //print the game state on screen
                PrintGameState();

                //get Player Input
                ConsoleKeyInfo input = Console.ReadKey(true);

                //do enemy logic
                DoEnemyTurns();

                //try to place uncovered traps
                currentLevel.PlaceUncoveredTraps();

                //process player input
                ProccessPlayerInput(input);


            }

        }

        private void ProccessPlayerInput(ConsoleKeyInfo input)
        {
            ConsoleKey key = input.Key;

            switch (key)
            {

                case MoveUpKey:
                    MovePlayer(GameDirection.Up);
                    break;

                case MoveDownKey:
                    MovePlayer(GameDirection.Down);
                    break;

                case MoveLeftKey:
                    MovePlayer(GameDirection.Left);
                    break;

                case MoveRightKey:
                    MovePlayer(GameDirection.Right);
                    break;


                case AttackUpKey:
                    PlayerAttack(GameDirection.Up);
                    break;

                case AttackDownKey:
                    PlayerAttack(GameDirection.Down);
                    break;

                case AttackLeftKey:
                    PlayerAttack(GameDirection.Left);
                    break;

                case AttackRightKey:
                    PlayerAttack(GameDirection.Right);
                    break;



                case ReloadLevelKey:
                    RelaodLevel();
                    break;
            }
        }

        private void RelaodLevel()
        {
            
            this.isMainLoopActive = false;

            //create a new level and place the player in it
            this.player = new Player(this.playerAtLevelStart);
            this.currentLevel = new GameLevel(this.currentLevel.LevelIndex);
            this.player.UpdatePosition(this.currentLevel.PlayerPosRow, this.currentLevel.PlayerPosColumn);
            StartMainLoop();
        }

        private void LoadNewLevel()
        {
            int newLevelIndex = this.currentLevel.LevelIndex + 1;

            //if the player finished the game
            if (newLevelIndex == FinalLevel)
            {
                OnGoodEnding();
            }

            else
            {
                //create a new level and place the player in it
                this.playerAtLevelStart = new Player(this.player);
                this.currentLevel = new GameLevel(newLevelIndex);
                this.player.UpdatePosition(this.currentLevel.PlayerPosRow, this.currentLevel.PlayerPosColumn);

                //add the event to the log
                this.eventLog.AddEvent("You have reached level " + this.currentLevel.LevelIndex + ".");
            }
        }

        public void StartShopLoop()
        {
            Console.Clear();
            this.isMainLoopActive = false;

            PrintShop();

            ConsoleKeyInfo input = Console.ReadKey();

            while (input.Key != ConsoleKey.D4)
            {
                if (input.Key == ConsoleKey.D1)
                {
                    if (player.Gold >= shop.GetWeaponCost())
                    {
                        //player implications
                        player.BaseDamage++;
                        player.Gold -= shop.GetWeaponCost();

                        //shop implications
                        shop.WeaponLevel++;

                        //re-print shop
                        PrintShop();
                        Console.WriteLine("\n Enjoy your new toy, may the shrines guide you.          ");

                    }

                    else
                    {
                        Console.WriteLine("\n Don't come back here until you got the gold to pay, now scram!        ");
                    }
                }

                else if (input.Key == ConsoleKey.D2)
                {
                    if (player.Gold >= shop.GetArmorCost())
                    {
                        //player implications
                        player.Armor++;
                        player.Gold -= shop.GetArmorCost();

                        //shop implications
                        shop.ArmorLevel++;

                        //re-print shop
                        PrintShop();
                        Console.WriteLine("\n Wear this, there is no such thing as too much steel.        ");

                    }

                    else
                    {
                        Console.WriteLine("\n Don't come back here until you got the gold to pay, now scram!        ");
                    }
                }
                else if (input.Key == ConsoleKey.D3)
                {
                    if (player.Gold >= ShopHealingCost)
                    {
                        //player implications

                        int hpAddition = (int)(player.MaxHealth * ShopHealingAmount);
                        if (player.CurrentHealth + hpAddition > player.MaxHealth) hpAddition = player.MaxHealth - player.CurrentHealth;

                        player.CurrentHealth += hpAddition;
                        player.Gold -= GameDefinitions.ShopHealingCost;

                        //re-print shop
                        PrintShop();
                        Console.WriteLine("\n It's the best I could manage, now go get me more gold.        ");

                    }

                    else
                    {
                        Console.WriteLine("\n I'm not gonna touch your for that much gold, scram!");
                    }
                }

                input = Console.ReadKey();

            }

            Console.Clear();
            music.PlayExitSound();
            StartMainLoop();

        }

        public void OnGameOver(string message)
        {
            isMainLoopActive = false;
            Console.WriteLine("\n" + message + "\n\n");

            PrintGameOverText();

            PrepareNewGame();

            StartMainLoop();

        }

        public void OnGoodEnding()
        {
            isMainLoopActive = false;

            PrintGoodEndingText();

            PrepareNewGame();

            StartMainLoop();

        }

        private void PrepareNewGame()
        {
            this.player = new Player();
            this.playerAtLevelStart = new Player();
            this.currentLevel = new GameLevel(1);
            this.player.UpdatePosition(this.currentLevel.PlayerPosRow, this.currentLevel.PlayerPosColumn);

            this.eventLog = new EventLog();
            this.eventLog.AddEvent("A new adventure begins. May fortune favor you.");

            this.shop = new Shop();
        }

        #endregion

        #region Gameplay Actions

        private void MovePlayer(GameDirection direction)
        {
            // pickup checks
            CheckAndHandleShrinePickup(direction);

            // check for traps
            CheckAndHandleCoveredTraps(direction);

            // shop entry check
            if (CheckNextSymbolInDirection(direction, ShopSymbol))
            {
                //play exit sound
                music.PlayExitSound();
                //load a new level
                this.isMainLoopActive = false;
                StartShopLoop();
                return;
            }

            // exit check and generating a new level
            else if (CheckNextSymbolInDirection(direction, ExitSymbol))
            {
                //play exit sound
                music.PlayExitSound();
                //load a new level
                LoadNewLevel();
            }

            //attempt to move player
            CheckAndHandleMovementInDirection(direction);

        }

        private void PlayerAttack(GameDirection direction)
        {
            //play swing sound
            music.PlaySwingSound();

            //check enemy in the tile
            bool isEnemyThere = CheckNextSymbolInDirection(direction, EnemySymbol);
            //preform attack
            if (isEnemyThere)
            {
                int enemyRow = 0;
                int enemyColumn = 0;
                switch (direction)
                {
                    case GameDirection.Up:
                        enemyRow = player.PosRow - 1;
                        enemyColumn = player.PosColumn;
                        break;

                    case GameDirection.Down:
                        enemyRow = player.PosRow + 1;
                        enemyColumn = player.PosColumn;
                        break;

                    case GameDirection.Left:
                        enemyRow = player.PosRow;
                        enemyColumn = player.PosColumn - 1;
                        break;

                    case GameDirection.Right:
                        enemyRow = player.PosRow;
                        enemyColumn = player.PosColumn + 1;
                        break;
                }

            

                int damageToHit = player.CalculateHitDamage();
                bool isCrit = (damageToHit > player.BaseDamage);
                this.currentLevel.HurtEnemyOnPosition(enemyRow, enemyColumn, player.CalculateHitDamage(), isCrit, eventLog, player);
            }
        }

        private void DoEnemyTurns()
        {
            foreach(Enemy e in currentLevel.EnemyList)
            {
                //enemy in hit range
                if(e.CheckIfPlayerInMeleeRange(currentLevel.LevelMap))
                {
                    if(!player.RollForPlayerEvasion())
                    {
                        int damageTaken = player.CalculateDamageTaken(e.Damage);
                        player.CurrentHealth -= damageTaken;

                        eventLog.AddEvent(e.Name + " hits you for " + damageTaken + " DMG.");

                        if(player.CurrentHealth <= 0)
                        {
                            OnGameOver(e.Name + " has killed you.");
                        }
                    }

                    else
                    {
                        eventLog.AddEvent(e.Name + " attacks and misses you.");
                    }
                }
                // enemy in chase range
                else if(e.CheckIfPlayerInChaseRadius(player.PosRow, player.PosColumn))
                {
                    e.IsChasing = true;
                    e.MoveTowardsPlayer(player.PosRow, player.PosColumn, currentLevel.LevelMap);
                }
                //enemy outside chase range
                else
                {
                    if(!e.IsChasing)
                    {
                        e.DoEnemyPatrol(currentLevel.LevelMap);
                    }
                    else
                    {
                        e.MoveTowardsPlayer(player.PosRow, player.PosColumn, currentLevel.LevelMap);
                    }
                }
            }
        }

        #endregion

        #region Legality Checks and Event Handlers

        private bool CheckLegalMove(GameDirection direction)
        {
            int currentRow = this.player.PosRow;
            int currentColum = this.player.PosColumn;
            char[,] mapLayout = this.currentLevel.LevelMap.GetMapLayout();

            bool isMoveLegal = false;

            switch (direction)
            {
                case GameDirection.Up:
                    if ( IsLegalWalkingTile(mapLayout[currentRow - 1, currentColum]) ) isMoveLegal = true;
                    break;
                case GameDirection.Down:
                    if (IsLegalWalkingTile(mapLayout[currentRow + 1, currentColum]) ) isMoveLegal = true;
                    break;
                case GameDirection.Left:
                    if ( IsLegalWalkingTile(mapLayout[currentRow, currentColum - 1]) ) isMoveLegal = true;
                    break;
                case GameDirection.Right:
                    if ( IsLegalWalkingTile(mapLayout[currentRow, currentColum + 1]) ) isMoveLegal = true;
                    break;
            }

            return isMoveLegal;
        }

        private bool IsLegalWalkingTile(char symbol)
        {
            return (symbol != WallSymbol && symbol != EntranceSymbol && symbol != ExitSymbol && symbol != EnemySymbol);
        }

        private void CheckAndHandleMovementInDirection(GameDirection direction)
        {
            //regular movement
            switch (direction)
            {
                case GameDirection.Up:
                    if (CheckLegalMove(GameDirection.Up))
                    {
                        //remove player from old position on map layout
                        this.currentLevel.LevelMap.PlaceOnMapLayout(FreeSymbol, this.player.PosRow, this.player.PosColumn);
                        //set in the player instance
                        this.player.PosRow -= 1;
                        //set in the level instance
                        this.currentLevel.PlayerPosRow -= 1;
                        //play sound
                        music.PlayWalkSound();
                    }
                    break;
                case GameDirection.Down:
                    if (CheckLegalMove(GameDirection.Down))
                    {
                        //remove player from old position on map layout
                        this.currentLevel.LevelMap.PlaceOnMapLayout(FreeSymbol, this.player.PosRow, this.player.PosColumn);
                        //set in the player instance
                        this.player.PosRow += 1;
                        //set in the level instance
                        this.currentLevel.PlayerPosRow += 1;
                        //play sound
                        music.PlayWalkSound();

                    }
                    break;
                case GameDirection.Left:
                    if (CheckLegalMove(GameDirection.Left))
                    {
                        //remove player from old position on map layout
                        this.currentLevel.LevelMap.PlaceOnMapLayout(FreeSymbol, this.player.PosRow, this.player.PosColumn);
                        //set in the player instance
                        this.player.PosColumn -= 1;
                        //set in the level instance
                        this.currentLevel.PlayerPosColumn -= 1;
                        //play sound
                        music.PlayWalkSound();
                    }
                    break;
                case GameDirection.Right:
                    if (CheckLegalMove(GameDirection.Right))
                    {
                        //remove player from old position on map layout
                        this.currentLevel.LevelMap.PlaceOnMapLayout(FreeSymbol, this.player.PosRow, this.player.PosColumn);
                        //set in the player instance
                        this.player.PosColumn += 1;
                        //set in the level instance
                        this.currentLevel.PlayerPosColumn += 1;
                        //play sound
                        music.PlayWalkSound();
                    }
                    break;
            }

            // Update map layout with new player position
            this.currentLevel.LevelMap.PlaceOnMapLayout(PlayerSymbol, this.player.PosRow, this.player.PosColumn);
        }

        private bool CheckNextSymbolInDirection(GameDirection direction, char symbol)
        {
            int currentRow = this.player.PosRow;
            int currentColum = this.player.PosColumn;
            char[,] mapLayout = this.currentLevel.LevelMap.GetMapLayout();

            bool isSymbol = false;

            switch (direction)
            {
                case GameDirection.Up:
                    if (mapLayout[currentRow - 1, currentColum] == symbol) isSymbol = true;
                    break;
                case GameDirection.Down:
                    if (mapLayout[currentRow + 1, currentColum] == symbol) isSymbol = true;
                    break;
                case GameDirection.Left:
                    if (mapLayout[currentRow, currentColum - 1] == symbol) isSymbol = true;
                    break;
                case GameDirection.Right:
                    if (mapLayout[currentRow, currentColum + 1] == symbol) isSymbol = true;
                    break;
            }

            return isSymbol;
        }

        private void CheckAndHandleShrinePickup(GameDirection direction)
        {
            int currentRow = this.player.PosRow;
            int currentColum = this.player.PosColumn;
            char[,] mapLayout = this.currentLevel.LevelMap.GetMapLayout();

            //calculate the index of the next tile
            switch (direction)
            {
                case GameDirection.Up:
                    currentRow -= 1;
                    break;
                case GameDirection.Down:
                    currentRow += 1;
                    break;
                case GameDirection.Left:
                    currentColum -= 1;
                    break;
                case GameDirection.Right:
                    currentColum += 1;
                    break;
            }

            char symbolInNextTile = mapLayout[currentRow, currentColum];

            if(symbolInNextTile == MaxHPShrineSymbol)
            {
                // add bonus to player
                this.player.AddShrineBonus(RewardType.MaxHP);
                //delete shrine from level
                this.currentLevel.RemoveTreasureOnPosition(currentRow, currentColum);
                //add the pickup to the log
                this.eventLog.AddEvent("You kneel before the Shrine of Life, and gain " + GameDefinitions.MaxHpBaseReward + " MAX HP.");
                //play sound
                music.PlayShrineSound();
            }
            else if (symbolInNextTile == CritShrineSymbol)
            {
                // add bonus to player
                this.player.AddShrineBonus(RewardType.CritChance);
                //delete shrine from level
                this.currentLevel.RemoveTreasureOnPosition(currentRow, currentColum);
                //add the pickup to the log
                this.eventLog.AddEvent("You kneel before the Shrine of Focus, and gain " + GameDefinitions.CritChanceBaseReward*100 + "% CRIT CHANCE.");
                //play sound
                music.PlayShrineSound();
            }
            else if (symbolInNextTile == EvasionShrineSymbol)
            {
                // add bonus to player
                this.player.AddShrineBonus(RewardType.EvasionChance);
                //delete shrine from level
                this.currentLevel.RemoveTreasureOnPosition(currentRow, currentColum);
                //add the pickup to the log
                this.eventLog.AddEvent("You kneel before the Shrine of Shadows, and gain " + GameDefinitions.EvasionChanceBaseReward*100 + "% EVASION CHANCE.");
                //play sound
                music.PlayShrineSound();
            }
            else if (symbolInNextTile == CurrentHPShrineSymbol)
            {
                // add bonus to player
                this.player.AddShrineBonus(RewardType.CurrentHP);
                //delete shrine from level
                this.currentLevel.RemoveTreasureOnPosition(currentRow, currentColum);
                //add the pickup to the log
                this.eventLog.AddEvent("You drink a mucky potion, and gain " + CurrentHpReward*100 + "% HP.");
                //play sound
                music.PlayShrineSound();
            }
        }

        private void CheckAndHandleCoveredTraps(GameDirection direction)
        {
            int currentRow = this.player.PosRow;
            int currentColum = this.player.PosColumn;
            char[,] mapLayout = this.currentLevel.LevelMap.GetMapLayout();

            //calculate the index of the next tile
            switch (direction)
            {
                case GameDirection.Up:
                    currentRow -= 1;
                    break;
                case GameDirection.Down:
                    currentRow += 1;
                    break;
                case GameDirection.Left:
                    currentColum -= 1;
                    break;
                case GameDirection.Right:
                    currentColum += 1;
                    break;
            }

            foreach (Trap t in currentLevel.TrapList)
            {
                if (t.PosRow == currentRow && t.PosCol == currentColum && t.WasSteppedOn == false)
                {

                    //damage the player
                    int damageTaken = t.Level/2 + 1;
                    player.CurrentHealth -= damageTaken;

                    eventLog.AddEvent("You step on a covered trap and suffer " + damageTaken + " DMG.");

                    if (player.CurrentHealth <= 0)
                    {
                        OnGameOver("You die after stepping on a covered trap.");
                    }

                    //uncover the trap
                    t.WasSteppedOn = true;
                }

            }
        }
        

        #endregion

        #region Print Methods

        public void PrintBanner()
        {
            System.Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            // System.Console.Write(File.ReadAllText(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"/text" + "/banner.txt"));
             System.Console.Write(Resources.banner);
            Console.ForegroundColor = ConsoleColor.White;

            System.Console.WriteLine();
            System.Console.WriteLine();
        }

        public void PrintGameState()
        {
            //print Banner, HUD, Map, Log.
            Console.SetCursorPosition(0, 0);
            PrintBanner();
            Console.WriteLine();
            Console.WriteLine(player.ToString());
            Console.WriteLine();
            Console.Write("Level: " + this.currentLevel.LevelIndex + "      \n");
            currentLevel.LevelMap.PrintMap();
            Console.WriteLine();
            this.eventLog.PrintEventLog();
        }

        public void PrintGameInfo()
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            int leftPosition = 80;
            int topPosition = 12;

            //Print Control Scheme
            Console.SetCursorPosition(leftPosition, topPosition++);
            Console.WriteLine("~ Controls: ~");
            Console.SetCursorPosition(leftPosition, topPosition++);
            Console.WriteLine("------------------------");

            Console.SetCursorPosition(leftPosition, topPosition++);
            Console.WriteLine("Movement: W,A,S,D ");
            Console.SetCursorPosition(leftPosition, topPosition++);
            Console.WriteLine("Attack in Direction: ARROW KEYS");
            Console.SetCursorPosition(leftPosition, topPosition++);
            Console.WriteLine("Reload if stuck: R");

            Console.SetCursorPosition(leftPosition, topPosition++);
            Console.SetCursorPosition(leftPosition, topPosition++);

            //Print Map Legend
            Console.SetCursorPosition(leftPosition, topPosition++);
            Console.WriteLine("~ Map Legend: ~");
            Console.SetCursorPosition(leftPosition, topPosition++);
            Console.WriteLine("------------------------");

            Console.SetCursorPosition(leftPosition, topPosition++);
            Console.WriteLine(PlayerSymbol + " - Player");
            Console.SetCursorPosition(leftPosition, topPosition++);
            Console.WriteLine(EnemySymbol +" - Monster");
            Console.SetCursorPosition(leftPosition, topPosition++);
            Console.WriteLine(TrapSymbol + " - Uncovered Trap");
            Console.SetCursorPosition(leftPosition, topPosition++);
            Console.WriteLine(EvasionShrineSymbol + " - Shrine of Shadows");
            Console.SetCursorPosition(leftPosition, topPosition++);
            Console.WriteLine(CritShrineSymbol + " - Shrine of Focus");
            Console.SetCursorPosition(leftPosition, topPosition++);
            Console.WriteLine(MaxHPShrineSymbol + " - Shrine of Life");
            Console.SetCursorPosition(leftPosition, topPosition++);
            Console.WriteLine(CurrentHPShrineSymbol + " - Mucky Potion");
            Console.SetCursorPosition(leftPosition, topPosition++);
            Console.WriteLine(ShopSymbol + " - Forgotten Blacksmith");
            Console.SetCursorPosition(leftPosition, topPosition++);
            Console.WriteLine(ExitSymbol + " - To next level");

        }

        public void PrintGameStartText()
        {
            Console.SetCursorPosition(0, 0);
            PrintBanner();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("You wake up in a damp, cold room stinking of rot and mold.\n"
                + "There's a small note beside you that reads:\n\n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Dear Henry,\n\n" +
                "I am terribly sorry I had to throw you in this dungeon.\n" +
                "After seeing how impressed The Master is by your skills,\n" +
                "I decided I cannot allow you to graduate from the college and outshine me in The Master's court.\n\n" +
                "How fitting it is for the brightest student to spend his entire life wandering the endless Brightest Dungeon." +
                "\n\nYours truly," +
                "\nMalzahar.");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public void PrintGameOverText()
        {
            
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            PrintBanner();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nYou lay on the cold stone floor, pondering your life decisions.\n" +
                "You manage to scribble something on a piece of parchment before drawing your last breath.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Dear Malzahar,\n\n" +
                "Fuck You." +
                "\n\nYours truly," +
                "\nHenry.");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\nPress any key to restart...");
            Console.ReadKey();
            Console.Clear();
            
        }

        public void PrintGoodEndingText()
        {

            Console.Clear();
            Console.SetCursorPosition(0, 0);
            PrintBanner();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nYou finally step outside and take a breath of fresh air.\nOnly one thought comes to your mind:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("I'm coming for you, Malzahar.");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n\nTo Be Continued!");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\nPress any key to restart...");
            Console.ReadKey();
            Console.Clear();

        }

        public void PrintShop()
        {
            Console.SetCursorPosition(0, 0);
            PrintBanner();
            Console.WriteLine();
            Console.WriteLine(player.ToString());
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("The old Forgotten Blacksmith appears annoyed at your sight.\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\"Don't bother me if you ain't got the gold, kid.\"\n\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Press the following number keys to interact or buy from the Blacksmith:\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Upgrade your weapon to " + (shop.WeaponLevel+1) + " DMG for " + shop.GetWeaponCost() + " GOLD.");
            Console.WriteLine("2. Upgrade your armor to " + shop.ArmorLevel + " ARMOR for " + shop.GetArmorCost() + " GOLD.");
            Console.WriteLine("3. Heal " + ShopHealingAmount * 100 + "% HP for " + ShopHealingCost + " GOLD. (He seems a little rough...)");
            Console.WriteLine("4. Walk away...\n\n");
        }

        #endregion
    }
}
