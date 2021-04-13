using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Player
    {
        public int HP;
        public int Dexterity;
        public int strength;
        public int intelligence;
        public int MagRes;
        public int Armor;
        //level (need to see what were going to do about levels (either xp system or completing levels levels up the palyer))
        public string ClassType;
        public int PlayerX;
        public int PlayerY;
        ConsoleColor PlayerColor;
        char PlayerMarker = 'O';
        public int currenthp;
        public int XP;
        public int xptonext;
        public int level;
        public int money = 0;
        public int keys = 0;
        public int kills;
        Random rnd = new Random();
        public List<Item> Inventory = new List<Item>(6);
        public Player(int spawnX, int spawnY, string ClassType)
        {
            PlayerX = spawnX;
            PlayerY = spawnY;
            PlayerColor = ConsoleColor.Green;
            this.ClassType = ClassType;
            switch (ClassType)
            {
                case "Rogue":
                    HP = rnd.Next(10, 15);
                    Dexterity = rnd.Next(15, 25);
                    strength = rnd.Next(7, 12);
                    intelligence = rnd.Next(10, 15);
                    MagRes = rnd.Next(10, 15);
                    Armor = rnd.Next(10, 15);
                    break; 
                case "Mage":
                    HP = rnd.Next(10, 15);
                    Dexterity = rnd.Next(10, 15);
                    strength = rnd.Next(7, 12);
                    intelligence = rnd.Next(15, 25);
                    MagRes = rnd.Next(10, 15);
                    Armor = rnd.Next(10, 15);
                    break; 
                case "Warrior":
                    HP = rnd.Next(15, 20);
                    Dexterity = rnd.Next(7, 12);
                    strength = rnd.Next(15, 25);
                    intelligence = rnd.Next(7, 12);
                    MagRes = rnd.Next(10, 15);
                    Armor = rnd.Next(15, 20);
                    break;
                default:
                    break;
            }
            currenthp = HP;
            XP = 0;
            xptonext = 10;
            level = 1;
            money = 100;
            keys = 0;
            kills = 0;
        }

        public void PrintPlayer()
        {
            Console.ForegroundColor = PlayerColor;
            Console.SetCursorPosition(PlayerX, PlayerY);
            Console.Write(PlayerMarker);
            Console.ResetColor();
        }

        public void LevelUp()
        {
            string prompt = @" 
  _                _   _   _ ___ 
 | |   _____ _____| | | | | | _ \
 | |__/ -_) V / -_) | | |_| |  _/
 |____\___|\_/\___|_|  \___/|_|  
    
    Your Max HP went up by 5!
    Select another stat stat to increase (+3)
";
            string[] options = { "Dexterity", "Strength", "intelligence", "MagRes", "Armor"}; 
            Menu LevelUpMenu = new Menu(prompt, options);
            int SelectedIndexLevelUp = LevelUpMenu.Run();
            switch (SelectedIndexLevelUp)
            {
                case 0:
                    Dexterity += 3;
                    break;
                case 1:
                    strength+= 3;
                    break;
                case 2:
                    intelligence += 3;
                    break;
                case 3:
                    MagRes += 3;
                    break;
                case 4:
                    Armor += 3;
                    break;
                default:
                    break;
            }
            HP = HP + 5;
            currenthp = HP;
            XP = 0;
            level++;
            xptonext = level * 10;
        }

        public void OpenInventory()
        {
            string Prompt = "Inventory";
            string[] options = {"Swords", "Daggers", "Shields", "Wands", "Rings", "Armors","Resume"};
            Menu InventoryMenu = new Menu(Prompt, options);
            int SelectedIndexIncentory = InventoryMenu.Run();
            switch (SelectedIndexIncentory)
            {
                case 0:
                    //display sword stats
                    for (int i = 0; i < Inventory.Count; i++)
                    {
                        if (Inventory[i].name == "Sword")
                        {
                            Console.ForegroundColor = Inventory[i].itemColor;
                            Console.SetCursorPosition(52, 4);
                            Console.Write(Inventory[i].name + " " + Inventory[i].force);
                        }
                       
                    }
                    Console.ResetColor();
                    Console.ReadKey(true);
                    OpenInventory();
                    break;
                case 1:
                    for (int i = 0; i < Inventory.Count; i++)
                    {
                        if (Inventory[i].name == "Dagger")
                        {
                            Console.ForegroundColor = Inventory[i].itemColor;
                            Console.SetCursorPosition(52, 4);
                            Console.Write(Inventory[i].name + " " + Inventory[i].force);
                        }

                    }
                    Console.ResetColor();
                    Console.ReadKey(true);
                    OpenInventory();
                    break;
                case 2:
                    for (int i = 0; i < Inventory.Count; i++)
                    {
                        if (Inventory[i].name == "Shield")
                        {
                            Console.ForegroundColor = Inventory[i].itemColor;
                            Console.SetCursorPosition(52, 4);
                            Console.Write(Inventory[i].name + " " + Inventory[i].force);
                        }

                    }
                    Console.ResetColor();
                    Console.ReadKey(true);
                    OpenInventory();
                    break;
                case 3:
                    for (int i = 0; i < Inventory.Count; i++)
                    {
                        if (Inventory[i].name == "Wand")
                        {
                            Console.ForegroundColor = Inventory[i].itemColor;
                            Console.SetCursorPosition(52, 4);
                            Console.Write(Inventory[i].name + " " + Inventory[i].force);
                        }

                    }
                    Console.ResetColor();
                    Console.ReadKey(true);
                    OpenInventory();
                    break;
                case 4:
                    for (int i = 0; i < Inventory.Count; i++)
                    {
                        if (Inventory[i].name == "Magic Ring")
                        {
                            Console.ForegroundColor = Inventory[i].itemColor;
                            Console.SetCursorPosition(52, 4);
                            Console.Write(Inventory[i].name + " " + Inventory[i].force);
                        }

                    }
                    Console.ResetColor();
                    Console.ReadKey(true);
                    OpenInventory();
                    break;
                case 5:
                    for (int i = 0; i < Inventory.Count; i++)
                    {
                        if (Inventory[i].name == "Chainmail")
                        {
                            Console.ForegroundColor = Inventory[i].itemColor;
                            Console.SetCursorPosition(52, 4);
                            Console.Write(Inventory[i].name + " " + Inventory[i].force);
                        }

                    }
                    Console.ResetColor();
                    Console.ReadKey(true);
                    OpenInventory();
                    break;
                case 6:
                    
                    break;
                default:
                    break;
            }
            
        }

    }
}
