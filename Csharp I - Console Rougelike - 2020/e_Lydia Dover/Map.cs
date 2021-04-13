using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayRogLike
{
    public enum Type
    {
        Player,
        Enemy,
        Chest,
        Exit,
        Empty,
        HorizontalWall,
        VerticalWall,
        Entrance,
        IslandCenter,
        Vendor
    }
    public abstract class GameObject
    {
        public Position position = new Position();
    }
    #region Gameobects Classes
    public class Player : GameObject
    {
        public int money;
        public int life = 3;
    }
    public class Enemy : GameObject
    {
    }
    public class Chest : GameObject
    {
    }
    public class Exit : GameObject
    {
    }
    public class Entrance : GameObject
    {
        public bool firstStep = false;
    }
    public class Level
    {
        public int level = 0;
        public bool newLevel = false;
    }
    public class Item
    {
        public string itemType;
        public int price;
        public string name;
        public string description;
        public int value;
        public Item(int itemPrice, string itemName, string itemDescription, int itemValue)
        {
            price = itemPrice;
            name = itemName;
            description = itemDescription;
            value = itemValue;
        }
    }
    public class Island : GameObject
    {
        public int width;
        public int height;
        public Island(int a, int b)
        {
            width = a;
            height = b;
        }

    }
    public class Vendor : GameObject
    {
        public string instructions = "Oy partna! Welcome to mee shop. now, take what'cha want and stop wasting mee time...";
        public Item HPPotion = new Item(2, "HP Potion", "Get +2 HP", 2);
        public List<Item> items = new List<Item>();
        bool hasBeenVisited;

        public void PrintShop(Player player)
        {
            Console.Clear();
            if (hasBeenVisited == false)
            {
                items.Add(HPPotion);
                items.Add(HPPotion);
                hasBeenVisited = true;
            }
            Console.Write(Environment.NewLine);
            Console.WriteLine(instructions);
            Console.Write(Environment.NewLine);
            string[,] shopInventory = new string[items.Count, 4];

            for (int i = 0; i < items.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    switch (j)
                    {
                        case 0:
                            shopInventory[i, j] = items[i].name;
                            break;
                        case 1:
                            shopInventory[i, j] = items[i].description;
                            break;
                        case 2:
                            shopInventory[i, j] = items[i].price.ToString() + "$";
                            break;
                        case 3:
                            shopInventory[i, j] = i.ToString();
                            break;
                    }
                }
            }
            Console.WriteLine($"{"Name",-20}{"Description",-20}{"Price",-20}{"ID",-20}");
            for (int i = 0; i < items.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"{shopInventory[i, j],-20}");
                }
                Console.Write(Environment.NewLine);
            }
            Console.Write(Environment.NewLine);
            Console.Write(Environment.NewLine);
            bool hasBought = false;
            int itemID;
            string input;
            do
            {
                Console.WriteLine("Enter the ID of the item you wish to buy. Then press any [KEY] to continue. press [E] to EXIT.");
                input = Console.ReadLine();

                if (!int.TryParse(input, out itemID)) // if player enters invalid char
                    Console.WriteLine("Please enter a valid ID.");

                else if (!(player.money > items[itemID].price)) // if player doesnt have enough money
                    Console.WriteLine("You don't have enough money.");

                else if (!(itemID < items.Count)) // if item doesn't exist
                    Console.WriteLine("Please enter a valid ID.");

                else
                {
                    switch (itemID)
                    {
                        case 0:
                            player.money -= items[itemID].price;
                            player.life += items[itemID].value;
                            break;
                    }
                    hasBought = true;
                }
            }
            while (!hasBought && input != "E");

        }
    }
    #endregion
    class Map
    {
        public Level level = new Level();
        public Player player = new Player();
        public Entrance entrance = new Entrance();
        public Enemy enemy = new Enemy();
        public Chest chest = new Chest();
        public Exit exit = new Exit();
        public static Random rnd = new Random();
        public Island island = new Island(rnd.Next(3, 5), rnd.Next(1, 5));
        public Cell[,] board = new Cell[30, 41];
        public Vendor vendor = new Vendor();
        string instructions =
        "[Q]uit [N]ew" + Environment.NewLine +
        "Press WASD To Move";
        public char key = new Char();

        public Position GetRandomPosition()
        {
            Random rnd = new Random();
            return new Position(rnd.Next(1, 29), rnd.Next(1, 40));
        }
        #region Spawners
        public void SpawnIsland()
        {
            bool isClearForIsland = false;
            while (isClearForIsland == false)
            {
                island.position = GetRandomPosition();
                if (island.position.x + island.width < 29 && island.position.y + island.height < 40)
                {
                    for (int i = island.position.x; i <= island.position.x + island.width; i++)
                    {
                        for (int j = island.position.y; j <= island.position.y + island.height; j++)
                        {
                            if (board[i, j].type == Type.Empty)
                            {
                                isClearForIsland = true;
                            }
                            else isClearForIsland = false;
                        }
                    }
                    if (isClearForIsland)
                    {
                        for (int i = island.position.x; i <= island.position.x + island.width; i++)
                        {
                            for (int j = island.position.y; j <= island.position.y + island.height; j++)
                            {
                                if (i == island.position.x || i == island.position.x + island.width)
                                {
                                    board[i, j].type = Type.HorizontalWall;
                                }
                                else
                                if (j == island.position.y || j == island.position.y + island.height)
                                {
                                    {
                                        board[i, j].type = Type.VerticalWall;
                                    }
                                }
                                else
                                {
                                    board[i, j].type = Type.IslandCenter;
                                }
                            }

                        }
                    }
                }
            }
        }
        private void Spawn(GameObject gameObject, Type type)
        {
            bool hasBeenCreated = false;
            while (hasBeenCreated == false)
            {
                gameObject.position = GetRandomPosition();

                if (board[gameObject.position.x, gameObject.position.y].type == Type.Empty)
                {
                    board[gameObject.position.x, gameObject.position.y].type = type;
                    hasBeenCreated = true;
                }
            }
        }
        public void SpawnPlayer()
        {
            Spawn(player, Type.Player);
        }
        public void SpawnEnemy()
        {
            for (int i = 0; i < level.level; i++)
            {
                Spawn(enemy, Type.Enemy);
            }
        }
        public void SpawnExit()
        {
            Spawn(exit, Type.Exit);
        }

        public void SpawnVendor()
        {
            Spawn(vendor, Type.Vendor);
        }

        public void SpawnChest()
        {
            Spawn(chest, Type.Chest);
        }
        #endregion
        public void CreateMap()
        {
            for (int height = 0; height < 30; height++)
            {
                for (int width = 0; width < 41; width++)
                {
                    if (height == 0 || height == 29)
                    {
                        board[height, width] = new Cell() { type = Type.HorizontalWall };
                    }
                    else
                        if (width == 0 || width == 40)
                    {
                        board[height, width] = new Cell() { type = Type.VerticalWall };
                    }
                    else
                    {
                        board[height, width] = new Cell() { type = Type.Empty };
                    }
                }
            }
        }

        public void PrintMap()
        {
            Console.Clear();
            for (int height = 0; height < 30; height++)
            {
                for (int width = 0; width < 41; width++)
                {
                    switch (board[height, width].type)
                    {
                        case Type.Player:
                            Console.Write("@");
                            break;
                        case Type.Enemy:
                            Console.Write("M");
                            break;
                        case Type.Chest:
                            Console.Write("#");
                            break;
                        case Type.Exit:
                            Console.Write("X");
                            break;
                        case Type.Empty:
                            Console.Write(" ");
                            break;
                        case Type.HorizontalWall:
                            Console.Write("-");
                            break;
                        case Type.VerticalWall:
                            Console.Write("|");
                            break;
                        case Type.Entrance:
                            Console.Write("E");
                            break;
                        case Type.IslandCenter:
                            Console.Write(" ");
                            break;
                        case Type.Vendor:
                            Console.Write("V");
                            break;
                        default:
                            break;
                    }
                }
                Console.Write(Environment.NewLine);
            }
        }
        public void NewLevel()
        {

            level.newLevel = true;
            entrance.firstStep = true;
            entrance.position = player.position;
            if (level.newLevel == true)
            {
                Console.Clear();
                CreateMap();
                for (int i = 0; i < level.level; i++)
                {
                    SpawnIsland();
                }
                SpawnPlayer();
                SpawnVendor();
                for (int i = 0; i < level.level; i++)
                {
                    SpawnEnemy();
                    SpawnChest();
                }
                SpawnExit();
                PrintMap();
                level.newLevel = false;
            }
        }
        #region Movement
        public void MovePlayer(Position pos)
        {
            if (entrance.firstStep == true)
            {
                board[player.position.x, player.position.y].type = Type.Entrance;
                player.position = pos;
                board[player.position.x, player.position.y].type = Type.Player;
                entrance.firstStep = false;
            }
            else
            {
                board[player.position.x, player.position.y].type = Type.Empty;
                player.position = pos;
                board[player.position.x, player.position.y].type = Type.Player;
            }
        }

        //public void MoveEnemy

        public void HandlePlayerMovement(Position newPlayerPos)
        {
            Type type = board[newPlayerPos.x, newPlayerPos.y].type;

            switch (type)
            {
                case Type.Enemy:
                    player.life--;
                    MovePlayer(newPlayerPos);
                    break;
                case Type.Chest:
                    player.money++;
                    MovePlayer(newPlayerPos);
                    break;
                case Type.Empty:
                    MovePlayer(newPlayerPos);
                    break;
                case Type.Exit:
                    level.level++;
                    NewLevel();
                    break;
                case Type.Vendor:
                    vendor.PrintShop(player);
                    break;
            }
            PrintMap();
        }
        public void MoveRight()
        {
            if (player.position.y < 40)
            {
                Position newPlayerPos = new Position(player.position.x, player.position.y + 1);
                HandlePlayerMovement(newPlayerPos);
            }
        }
        public void MoveLeft()
        {
            if (player.position.y > 1)
            {
                Position newPlayerPos = new Position(player.position.x, player.position.y - 1);
                HandlePlayerMovement(newPlayerPos);
            }
        }
        public void MoveDown()
        {
            if (player.position.x < 29)
            {
                Position newPlayerPos = new Position(player.position.x + 1, player.position.y);
                HandlePlayerMovement(newPlayerPos);
            }
        }
        public void MoveUp()
        {
            if (player.position.x > 1)
            {
                Position newPlayerPos = new Position(player.position.x - 1, player.position.y);
                HandlePlayerMovement(newPlayerPos);
            }
        }
        #endregion
        public void PrintUI()
        {
            Console.WriteLine(instructions);
            Console.WriteLine("Your score is: " + player.money);
            Console.WriteLine("you have " + player.life + " lives");
            Console.WriteLine("Level: " + level.level);
            key = Char.ToUpper(Console.ReadKey(true).KeyChar);
        }
    }
}
