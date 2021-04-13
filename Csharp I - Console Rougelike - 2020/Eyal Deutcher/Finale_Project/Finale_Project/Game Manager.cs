using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    public enum Type
    {
        Player,
        SmallEnemy,
        BigEnemyUpperLeft,
        BigEnemyUpperRight,
        BigEnemyLowerLeft,
        BigEnemyLowerRight,
        BigEnemyNextStep,
        Chest,
        Trap,
        Entrance,
        Exit,
        Wall,
        IslandWall,
        IslandCenter,
        Vendor,
        Empty
    }
    public class GameManager
    {
        public static VendorManager vendorManager = new VendorManager();
        public static Map map;
        public static Player player = new Player();
        public static ItemManager itemManager = new ItemManager();
        MainMenu _mainMenu = new MainMenu();
        Entrance _entrance = new Entrance();
        Vendor _vendor = new Vendor();
        Exit _exit = new Exit();
        public static int level = 1;
        public static bool firstMap = true;
        public static int mapHightLoad;
        public static int mapLengthLoad;
        public static int mapSpawnWallChanceLoad;
        public static bool loadInfo = false;

        #region SetupGame
        public void SetupGame()
        {
            ScreenSize();
            ListInitializer();
            GameStartEvents();
        }
        void ScreenSize()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        }
        void ListInitializer()
        {
            EnemyManager.bigEnemyList.Clear();
            EnemyManager.smallEnemyList.Clear();
            EnemyManager.trapList.Clear();
            ChestManager.chestList.Clear();
            for (int i = 0; i < 100; i++)
            {
                EnemyManager.bigEnemyList.Add(null);
                EnemyManager.smallEnemyList.Add(null);
                EnemyManager.trapList.Add(null);
                ChestManager.chestList.Add(null);
            }
        }
        void GameStartEvents()
        {
            _mainMenu.LoadGame();
            _mainMenu.EnterName();
            _mainMenu.Story();
            _mainMenu.Tutorial();
            _mainMenu.SoundActivation();
        }
        #endregion
        #region GamePlayLoop
        public bool GamePlayLoop()
        {
            bool levelIsNotOver = true;
            CreateMap();
            while (levelIsNotOver)
            {
                ScreenManager.PrintScreen();
                Movement();
                levelIsNotOver = IsLevelOver();
                if(IsGameOver())
                {
                    return false;
                }
            }
            return true;
        }
        #region MapCreation
        void CreateMap()
        {
            if (firstMap == true)
            {
                MapSelection();
                firstMap = false;
                Console.Clear();
            }
            else
            {
                NextMap();
                Console.Clear();
            }
            SpawnAll();
        }
        #region Map Selection
        void MapSelection()
        {
            bool needToMakeMap = true;
            while (needToMakeMap)
            {
                Console.WriteLine("Do you want to make your own map?");
                Console.WriteLine("Y to make your map size");
                Console.WriteLine("X to use defult map");
                switch (Console.ReadKey().Key)
                {
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                    case ConsoleKey.Y:
                        needToMakeMap = false;
                        int length;
                        int hight;
                        int spawnWallChance;
                        hight = userMapSizeCreation("hight");
                        length = userMapSizeCreation("length");
                        spawnWallChance = spawnChanceSwitch();
                        map = new Map(hight, length, spawnWallChance);
                        break;
                    case ConsoleKey.X:
                        map = new Map(10, 10, 0);
                        needToMakeMap = false;
                        break;
                }
                if (needToMakeMap == false)
                {
                    IslandGenerator islandGenerator;

                    map.GenerateMap();
                    islandGenerator = new IslandGenerator(map.GetMapHight(), map.GetMapLength());
                    islandGenerator.CreateIslands(level, map);
                }
            }
        }
        int userMapSizeCreation(string hightOrLength)
        {
            int minNumber = 10;
            int size;
            Console.WriteLine("Add map " + hightOrLength + "(min of " + minNumber + " )");
            while (true)
            {
                size = int.Parse(Console.ReadLine());
                if (size < minNumber)
                {
                    Console.WriteLine("Too small please enter a value bigger than " + minNumber);
                }
                else
                {
                    return size;
                }
            }
        }
        int spawnChanceSwitch()
        {
            int spawnWallChance = 0;
            bool needSpawnChance = true;
            while (needSpawnChance)
            {
                Console.WriteLine("Add map Edge Spawn Chance");
                Console.WriteLine("1 is low");
                Console.WriteLine("2 is medium");
                Console.WriteLine("3 is high");
                switch (Console.ReadKey().Key)
                {
                    default:
                        Console.WriteLine("WrongInput");
                        break;
                    case ConsoleKey.D1:
                        spawnWallChance = -20;
                        needSpawnChance = false;
                        break;
                    case ConsoleKey.D2:
                        spawnWallChance = 0;
                        needSpawnChance = false;
                        break;
                    case ConsoleKey.D3:
                        spawnWallChance = 20;
                        needSpawnChance = false;
                        break;
                }
            }
            return spawnWallChance;
        }
        #endregion
        void NextMap()
        {
            IslandGenerator islandGenerator;
            if (loadInfo)
            {
                map = new Map(mapHightLoad, mapLengthLoad, mapSpawnWallChanceLoad);
                map.GenerateMap();
                islandGenerator = new IslandGenerator(map.GetMapHight(), map.GetMapLength());
                islandGenerator.CreateIslands(level, map);
                Hud.InfoText = "Map Loaded, You Are at LEVEL: " + level;
                loadInfo = false;
            }
            else
            {
                map = new Map(map.GetMapHight(), map.GetMapLength(), map.GetReducedWallSpawnChance());
                map.GenerateMap();
                islandGenerator = new IslandGenerator(map.GetMapHight(), map.GetMapLength());
                islandGenerator.CreateIslands(level, map);
                Hud.InfoText = "Advanced To LEVEL: " + level;
            }

        }
        void SpawnAll()
        {
            Spawner spawner = new Spawner();
            spawner.SpawnAll(map, level, player, _entrance, _exit, _vendor);
        }
        #endregion

        #region Movement
        void Movement()
        {
            player.Movement(map, _entrance, _vendor);
            EnemyManager.BigEnemyMovement();
            EnemyManager.SmallEnemyMovement();
            MonsterTypeCheck();
            player.PlayerPositionCheck(map, _entrance, _vendor);
        }
        #region MonsterTypeCheck
        void MonsterTypeCheck()
        {
            bool smallEnemyOnEntrance = false;
            bool smallEnemyOnVendor = false;
            bool bigEnemyOnEntrance = false;
            bool bigEnemyOnVendor = false;
            Type bigEnemyTypeOnEntrance = Type.Entrance;
            Type bigEnemyTypeOnVendor = Type.Vendor;
            for (int i = 0; i < EnemyManager.smallEnemyList.Count; i++)
            {
                if (EnemyManager.smallEnemyList[i] != null)
                {
                    if (Position.PositionCheck(EnemyManager.smallEnemyList[i].position, _entrance.position))
                    {
                        smallEnemyOnEntrance = true;
                    }
                    if (Position.PositionCheck(EnemyManager.smallEnemyList[i].position, _vendor.position))
                    {
                        smallEnemyOnVendor = true;
                    }
                }
            }
            for (int i = 0; i < EnemyManager.bigEnemyList.Count; i++)
            {
                if(EnemyManager.bigEnemyList[i] != null)
                {
                    //check if position of one of the body parts of that enemy are on the entrance
                    //if so, Get his type and make bool true
                    if(EnemyManager.CheckBigEnemyType(_entrance.position, EnemyManager.bigEnemyList[i]))
                    {
                        bigEnemyOnEntrance = true;
                        bigEnemyTypeOnEntrance = EnemyManager.GetBigEnemyType(_entrance.position, EnemyManager.bigEnemyList[i]);
                    }
                    if(EnemyManager.CheckBigEnemyType(_vendor.position, EnemyManager.bigEnemyList[i]))
                    {
                        bigEnemyOnVendor = true;
                        bigEnemyTypeOnVendor = EnemyManager.GetBigEnemyType(_vendor.position, EnemyManager.bigEnemyList[i]);
                    }
                }
            }
            EnemyOnEntranceCheck(player, smallEnemyOnEntrance, _entrance, bigEnemyOnEntrance, bigEnemyTypeOnEntrance);
            EnemyOnVendorCheck(player, smallEnemyOnVendor, _vendor, bigEnemyOnVendor, bigEnemyTypeOnVendor);
        }
        void EnemyOnEntranceCheck(Player player, bool smallEnemyOnObject, Entrance entrance, bool bigEnemyOnObject, Type bigEnemyType)
        {
            if (bigEnemyType == Type.Empty)
            {
                bigEnemyType = Type.Entrance;
            }
            if (!Position.PositionCheck(player.position, entrance.position) && smallEnemyOnObject == false && bigEnemyOnObject == false)
            {
                map.mapArray[entrance.position.y, entrance.position.x].type = Type.Entrance;
            }
            else if (smallEnemyOnObject)
            {
                map.mapArray[entrance.position.y, entrance.position.x].type = Type.SmallEnemy;
            }
            else if(bigEnemyOnObject)
            {
                map.mapArray[entrance.position.y, entrance.position.x].type = bigEnemyType;
            }
            else
            {
                map.mapArray[entrance.position.y, entrance.position.x].type = Type.Player;
            }
        }
        void EnemyOnVendorCheck(Player player, bool smallEnemyOnObject, Vendor vendor, bool bigEnemyOnObject, Type bigEnemyType)
        {
            if (bigEnemyType == Type.Empty)
            {
                bigEnemyType = Type.Vendor;
            }
            if (!Position.PositionCheck(player.position, vendor.position) && smallEnemyOnObject == false && bigEnemyOnObject == false)
            {
                map.mapArray[vendor.position.y, vendor.position.x].type = Type.Vendor;
            }
            else if (smallEnemyOnObject)
            {
                map.mapArray[vendor.position.y, vendor.position.x].type = Type.SmallEnemy;
            }
            else if(bigEnemyOnObject)
            {
                map.mapArray[vendor.position.y, vendor.position.x].type = bigEnemyType;

            }
            else
            {
                map.mapArray[vendor.position.y, vendor.position.x].type = Type.Player;
            }
        }
        #endregion
        #endregion
        bool IsLevelOver()
        {
            if (PlayerStats.health <= 0)
            {
                return false;
            }
            if (Position.PositionCheck(player.position, _exit.position) == true)
            {
                SoundManager.NextLevelSound();
                LevelUp();
                return false;
            }
            else
            {
                return true;
            }
        }
        bool IsGameOver()
        {
            if (PlayerStats.health <= 0 || PlayerStats.armor >= 100)
            {
                return true;
            }
            return false;
        }
        #region LevelUp
        void LevelUp()
        {
            int spawnWallChance = map.GetReducedWallSpawnChance();
            level++;
            map = new Map(maxMapSizeCheck(30,map.GetMapHight()), maxMapSizeCheck(80, map.GetMapLength()), spawnWallChance);
            ListInitializer();
        }
        int maxMapSizeCheck(int maxNumber, int mapSize)
        {
            if(mapSize < maxNumber)
            {
                return mapSize += 2;
            }
            else
            {
                return mapSize;
            }
        }
        #endregion
        #endregion
        #region EndGameEvents
        public bool EndGameEvents()
        {
            Narrative narrative = new Narrative();
            EndGameNarative(narrative);
            return PlayAgain(narrative);
        }
        void EndGameNarative(Narrative narrative)
        {
            if (PlayerStats.health <= 0)
            {
                //you dead son
                Console.Clear();
                narrative.Death();
            }
            else if (PlayerStats.armor >= 100)
            {
                //you win bro
                Console.Clear();
                narrative.Win();
            }
        }
        bool PlayAgain(Narrative narrative)
        {
            bool canNotContinue = true;
            while (canNotContinue)
            {
                narrative.PlayAgainQuestion();
                var input = Console.ReadKey().Key;
                if (input == ConsoleKey.Y)
                {
                    canNotContinue = false;
                    ResetGame();
                    MainMenu.replayGame = true;
                    //replay
                    return true;
                }
                else if (input == ConsoleKey.X)
                {
                    canNotContinue = false;
                    //finish game
                    return false;
                }
            }
            return true;
        }
        void ResetGame()
        {
            level = 1;
            PlayerStats.maxHealth = 5;
            PlayerStats.health = 5;
            PlayerStats.gold = 0;
            PlayerStats.leather = 0;
            PlayerStats.armor = 0;
            PlayerStats.hasSword = false;
            PlayerStats.hasBow = false;
            PlayerStats.hasHelmet = false;
            PlayerStats.hasChestPlate = false;
            PlayerStats.hasArmBracers = false;
            PlayerStats.hasBoots = false;
            PlayerStats.hasGuntlet = false;
            EnemyManager.smallEnemyDeathCounter = 0;
            EnemyManager.bigEnemyDeathCounter = 0;
            ItemManager.Sword = new Item(1, 1, 0, 1, 0, 1, 5, 0, "Sword");
            ItemManager.Bow = new Item(1, 2, 0, 2, 5, 1, 5, 0, "Bow");
            ItemManager.Helmet = new Item(0, 0, 2, 3, 4, 1, 3, 0, "Helmet");
            ItemManager.ChestPlate = new Item(0, 0, 3, 4, 8, 3, 5, 0, "Chest Plate");
            ItemManager.ArmBracers = new Item(0, 0, 2, 5, 4, 2, 3, 0, "Arm Bracers");
            ItemManager.Boots = new Item(0, 0, 1, 6, 2, 1, 2, 0, "Boots");
            ItemManager.Guntlet = new Item(1, 0, 1, 7, 5, 2, 5, 0, "Guntlet");
            firstMap = true;
        }
        #endregion
    }
}
