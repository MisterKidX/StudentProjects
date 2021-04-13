using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Shop
    {
        Player player;
        List<string> ItemsForSale;
        int level;
        char ShopMarker = '$';
        Random rnd = new Random();
        public int x;
        public int y;
        public Shop(int level, Player player)
        {
            this.level = level;
            this.player = player;
            ItemsForSale = new List<string>(level);
            x = rnd.Next(40, 47);
            y = rnd.Next(4,10);
            //the more the player advances in the game more items will be for sale
        }
        public void PrintShop()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(ShopMarker);
            Console.ResetColor();
        }
        public void RunShop()
        {
            string prompt = @"
  ____  _                 
 / ___|| |__   ___  _ __  
 \___ \| '_ \ / _ \| '_ \ 
  ___) | | | | (_) | |_) |
 |____/|_| |_|\___/| .__/ 
                   |_|    
   Welcome to my Shop
";
            string[] Options = { "Buy", "Resume" };
            Menu ShopMenu = new Menu(prompt,Options);
            int selectedIndexShop = ShopMenu.Run();
            switch (selectedIndexShop)
            {
                case 0:
                    Buy();
                    break;
                case 1:
                    break;
                default:
                    break;
            }
        }

        void Buy()
        {
            Dictionary<string, int> ShopList = new Dictionary<string, int>(level);
            string[] Options = {"Health potion - " + level*5, "Strength Potion - " +level*10,"Dexterity Potion- " +level*10,
                "intelligence potion- " +level*10, "Magic Resistance Potion- " +level*10, "Armor Potion- " +level*10, "Key - " + level * 2, "Random Item - " + level*3,"Go Back"};
            string prompt = @"
  ____              
 |  _ \             
 | |_) |_   _ _   _ 
 |  _ <| | | | | | |
 | |_) | |_| | |_| |
 |____/ \__,_|\__, |
               __/ |
              |___/ 
    How can I help?
";
            Menu buyMenu = new Menu(prompt, Options);
            int SelectedBuyIndex = buyMenu.Run();
            switch (SelectedBuyIndex)
            {
                case 0:
                    if (player.money >= level*5)
                    {
                        Console.SetCursorPosition(52, 2);
                        Console.WriteLine("you restore " +( level + 3 )+" hp");
                        player.currenthp += (level + 3);
                        if (player.currenthp >= player.HP)
                        {
                            player.currenthp = player.HP;
                        }
                        player.money -= level * 5;
                        Console.ReadKey(true);
                        Buy();
                    }
                    else
                    {
                        Console.SetCursorPosition(52, 2);
                        Console.WriteLine("too poor");
                        Console.ReadKey(true);
                        Buy();
                    }
                    break;
                case 1:
                    if (player.money >= level * 10)
                    {
                        Console.SetCursorPosition(52, 2);
                        Console.WriteLine("your Strength goes up by " + (level/2 + 3) + " points");
                        player.strength += (level / 2 + 3);
                        player.money -= level * 10;
                        Console.ReadKey(true);
                        Buy();
                    }
                    else
                    {
                        Console.SetCursorPosition(52, 2);
                        Console.WriteLine("too poor");
                        Console.ReadKey(true);
                        Buy();
                    }
                    break;
                case 2:
                    if (player.money >= level * 10)
                    {
                        Console.SetCursorPosition(52, 2);
                        Console.WriteLine("your Dexterity goes up by " + (level / 2 + 3) + " points");
                        player.Dexterity += (level / 2 + 3);
                        player.money -= level * 10;
                        Console.ReadKey(true);
                        Buy();
                    }
                    else
                    {
                        Console.SetCursorPosition(52, 2);
                        Console.WriteLine("too poor");
                        Console.ReadKey(true);
                        Buy();
                    }
                    break; 
                case 3:
                    if (player.money >= level * 10)
                    {
                        Console.SetCursorPosition(52, 2);
                        Console.WriteLine("your Intelligence goes up by " + (level / 2 + 3) + " points");
                        player.intelligence += (level / 2 + 3);
                        player.money -= level * 10;
                        Console.ReadKey(true);
                        Buy();
                    }
                    else
                    {
                        Console.SetCursorPosition(52, 2);
                        Console.WriteLine("too poor");
                        Console.ReadKey(true);
                        Buy();
                    }
                    break; 
                case 4:
                    if (player.money >= level * 10)
                    {
                        Console.SetCursorPosition(52, 2);
                        Console.WriteLine("your Magic Resistance goes up by " + (level / 2 + 3) + " points");
                        player.MagRes += (level / 2 + 3);
                        player.money -= level * 10;
                        Console.ReadKey(true);
                        Buy();
                    }
                    else
                    {
                        Console.SetCursorPosition(52, 2);
                        Console.WriteLine("too poor");
                        Console.ReadKey(true);
                        Buy();
                    }
                    break;
                case 5:
                    if (player.money >= level * 10)
                    {
                        Console.SetCursorPosition(52, 2);
                        Console.WriteLine("your Armor goes up by " + (level / 2 + 3) + " points");
                        player.Armor += (level / 2 + 3);
                        player.money -= level * 10;
                        Console.ReadKey(true);
                        Buy();
                    }
                    else
                    {
                        Console.SetCursorPosition(52, 2);
                        Console.WriteLine("too poor");
                        Console.ReadKey(true);
                        Buy();
                    }
                    break;
                case 6:
                    if (player.money >= level * 2)
                    {
                        Console.SetCursorPosition(52, 2);
                        Console.WriteLine("you gain 1 chest key");
                        player.keys++;
                        player.money -= level * 2;
                        Console.ReadKey(true);
                        Buy();
                    }
                    else
                    {
                        Console.SetCursorPosition(52, 2);
                        Console.WriteLine("too poor");
                        Console.ReadKey(true);
                        Buy();
                    }
                    break;
                case 7:
                    if (player.money >= level * 3)
                    {
                        bool found = false;
                        Item NItem = new Item(level * 3);
                        for (int i = 0; i < player.Inventory.Count; i++)
                        {
                            if (NItem.name == player.Inventory[i].name)
                            {
                                found = true;
                                if (NItem.force > player.Inventory[i].force)
                                {
                                    player.money -= 3 * level;
                                    Console.SetCursorPosition(52, 2);
                                    Console.ForegroundColor = NItem.itemColor;
                                    Console.Write("you bought a new " + NItem.name + " " + NItem.force);
                                    Console.ResetColor();
                                    Console.SetCursorPosition(52, 3);
                                    Console.ForegroundColor = player.Inventory[i].itemColor;
                                    Console.Write("you got rid of " + player.Inventory[i].name + " " + player.Inventory[i].force);
                                    Console.ResetColor();
                                    switch (NItem.name)
                                    {
                                        case "Sword":
                                            player.strength -= player.Inventory[i].force;
                                            player.Inventory.RemoveAt(i);
                                            player.Inventory.Add(NItem);
                                            player.strength += NItem.force;
                                            break;
                                        case "Shield":
                                            player.Armor -= player.Inventory[i].force;
                                            player.Inventory.RemoveAt(i);
                                            player.Inventory.Add(NItem);
                                            player.Armor += NItem.force;
                                            break;
                                        case "Wand":
                                            player.intelligence -= player.Inventory[i].force;
                                            player.Inventory.RemoveAt(i);
                                            player.Inventory.Add(NItem);
                                            player.intelligence += NItem.force;
                                            break;
                                        case "Chainmail":
                                            player.Armor -= player.Inventory[i].force;
                                            player.Inventory.RemoveAt(i);
                                            player.Inventory.Add(NItem);
                                            player.Armor += NItem.force;
                                            break;
                                        case "Magic Ring":
                                            player.MagRes -= player.Inventory[i].force;
                                            player.Inventory.RemoveAt(i);
                                            player.Inventory.Add(NItem);
                                            player.MagRes += NItem.force;
                                            break;
                                        case "Dagger":
                                            player.Dexterity -= player.Inventory[i].force;
                                            player.Inventory.RemoveAt(i);
                                            player.Inventory.Add(NItem);
                                            player.Dexterity += NItem.force;
                                            break;
                                        default:
                                            break;
                                    }
                                }

                                else
                                {
                                    Console.SetCursorPosition(52, 2);
                                    Console.Write("you already have a better " + NItem.name);
                                }
                            }
                        }

                        if (found == false)
                        {
                            found = true;
                            player.money -= 3 * level;
                            Console.SetCursorPosition(52, 2);
                            Console.ForegroundColor = NItem.itemColor;
                            Console.Write("you bought a new " + NItem.name + " " + NItem.force);
                            Console.ResetColor();
                            switch (NItem.name)
                            {
                                case "Sword":
                                    player.Inventory.Add(NItem);
                                    player.strength += NItem.force;
                                    break;
                                case "Shield":
                                    player.Inventory.Add(NItem);
                                    player.Armor += NItem.force;
                                    break;
                                case "Wand":
                                    player.Inventory.Add(NItem);
                                    player.intelligence += NItem.force;
                                    break;
                                case "Chainmail":
                                    player.Inventory.Add(NItem);
                                    player.Armor += NItem.force;
                                    break;
                                case "Magic Ring":
                                    player.Inventory.Add(NItem);
                                    player.MagRes += NItem.force;
                                    break;
                                case "Dagger":
                                    player.Inventory.Add(NItem);
                                    player.Dexterity += NItem.force;
                                    break;

                                default:
                                    break;
                            }
                        }
                        Console.ReadKey(true);
                        Buy();
                    }
                    else
                    {
                        Console.SetCursorPosition(52, 2);
                        Console.WriteLine("too poor");
                        Console.ReadKey(true);
                        Buy();
                    }
                    break;
                case 8:
                    RunShop();
                    break;
                default:
                    break;
            }
        }


    }
}
