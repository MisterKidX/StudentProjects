using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndOfSemester_Project
{
class Shop
{
    private static Shop _shopInstance = null;
    public static Shop GetShopInstance
    {
        get
        {
            if (_shopInstance == null)
            {
                _shopInstance = new Shop();
            }
            return _shopInstance;
        }
    }
    ConsoleKeyInfo Key;

    bool InShop = false;

    public void AbookShop()
    {

           
        Console.WriteLine(Player.GetPlayerInstance.Name + "'s Lost Souls : " + Player.GetPlayerInstance.LostSouls + "¢");
        Console.WriteLine("What would you like to purchase?");
        Console.WriteLine("______________________________");
        Console.WriteLine("Press 1 - Max Health Upgrade (Upgrade Max Health)" + " - COST 2¢");
        Console.WriteLine("Press 2 - Reduce Enemy Damage(Reduce Damage Taken When Hitting An Enemy)" + " - COST 3¢");
        Console.WriteLine("Press 3 - Fully Heal" + " - COST 4¢");
        Console.WriteLine("Press 4 - Increase Potion Heal Amount" + " - COST 5¢");
        Console.WriteLine("Press X - To Leave Shop.");
            
        do
        {
            Key = Console.ReadKey(true);
            switch (Key.Key)
            {
                    
                case ConsoleKey.D1:
                    if (Player.GetPlayerInstance.LostSouls >= 2)
                    {
                        Player.GetPlayerInstance.LostSouls -= 2;
                        Player.GetPlayerInstance.MaxHP += 25;
                        Console.Clear();
                        Console.WriteLine("You Just Recieved 25 Bonus HP to your max HP!");
                        Console.WriteLine("Your Max Health Is Now : " + Player.GetPlayerInstance.MaxHP);
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine(Player.GetPlayerInstance.Name + "'s Lost Souls : " + Player.GetPlayerInstance.LostSouls + "¢");
                        Console.WriteLine("What would you like to purchase?");
                        Console.WriteLine("______________________________");
                        Console.WriteLine("Press 1 - Max Health Upgrade (Upgrade Max Health)" + " - COST 2¢");
                        Console.WriteLine("Press 2 - Reduce Enemy Damage(Reduce Damage Taken When Hitting An Enemy)" + " - COST 3¢");
                        Console.WriteLine("Press 3 - Fully Heal" + " - COST 4¢");
                        Console.WriteLine("Press 4 - Increase Potion Heal Amount" + " - COST 5¢");
                        Console.WriteLine("Press X - To Leave Shop.");
                    }
                    else
                    {
                        Console.WriteLine("You Do Not Have Enough Souls");


                    }
                    break;
                case ConsoleKey.D2:
                    if (Player.GetPlayerInstance.LostSouls >= 3)
                    {
                        Player.GetPlayerInstance.LostSouls -= 3;
                        Player.GetPlayerInstance.EnemyDmg -= 5;
                        Console.Clear();
                        Console.WriteLine("Enemies Now Do Less Damage , Enemy Damage is now at : " + Player.GetPlayerInstance.EnemyDmg);
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine(Player.GetPlayerInstance.Name + "'s Lost Souls : " + Player.GetPlayerInstance.LostSouls + "¢");
                        Console.WriteLine("What would you like to purchase?");
                        Console.WriteLine("______________________________");
                        Console.WriteLine("Press 1 - Max Health Upgrade (Upgrade Max Health)" + " - COST 2¢");
                        Console.WriteLine("Press 2 - Reduce Enemy Damage(Reduce Damage Taken When Hitting An Enemy)" + " - COST 3¢");
                        Console.WriteLine("Press 3 - Fully Heal" + " - COST 4¢");
                        Console.WriteLine("Press 4 - Increase Potion Heal Amount" + " - COST 5¢");
                        Console.WriteLine("Press X - To Leave Shop.");
                    }
                    else
                    {
                        Console.WriteLine("You Do Not Have Enough Souls");


                    }
                    break;
                case ConsoleKey.D3:
                    if (Player.GetPlayerInstance.LostSouls >= 4 && Player.GetPlayerInstance.CurrentHP != Player.GetPlayerInstance.MaxHP)
                    {
                        Player.GetPlayerInstance.LostSouls -= 4;
                        Player.GetPlayerInstance.CurrentHP = Player.GetPlayerInstance.MaxHP;
                        Console.Clear();
                        Console.WriteLine("You Have Been Returned to Full HP!");
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine(Player.GetPlayerInstance.Name + "'s Lost Souls : " + Player.GetPlayerInstance.LostSouls + "¢");
                        Console.WriteLine("What would you like to purchase?");
                        Console.WriteLine("______________________________");
                        Console.WriteLine("Press 1 - Max Health Upgrade (Upgrade Max Health)" + " - COST 2¢");
                        Console.WriteLine("Press 2 - Reduce Enemy Damage(Reduce Damage Taken When Hitting An Enemy)" + " - COST 3¢");
                        Console.WriteLine("Press 3 - Fully Heal" + " - COST 4¢");
                        Console.WriteLine("Press 4 - Increase Potion Heal Amount" + " - COST 5¢");
                        Console.WriteLine("Press X - To Leave Shop.");
                    }
                    else if (Player.GetPlayerInstance.CurrentHP == Player.GetPlayerInstance.MaxHP)
                    {
                        Console.WriteLine("You already are on full health moron!");
                    }
                    else
                    {
                        Console.WriteLine("You Do Not Have Enough Souls");



                    }
                    break;
                case ConsoleKey.D4:
                    if (Player.GetPlayerInstance.LostSouls >= 5)
                    {
                        Player.GetPlayerInstance.LostSouls -= 5;
                        Player.GetPlayerInstance.PotionHP += 10;
                        Console.Clear();
                        Console.WriteLine("Potions Now Heal For " +Player.GetPlayerInstance.PotionHP+"!");
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine(Player.GetPlayerInstance.Name + "'s Lost Souls : " + Player.GetPlayerInstance.LostSouls + "¢");
                        Console.WriteLine("What would you like to purchase?");
                        Console.WriteLine("______________________________");
                        Console.WriteLine("Press 1 - Max Health Upgrade (Upgrade Max Health)" + " - COST 2¢");
                        Console.WriteLine("Press 2 - Reduce Enemy Damage(Reduce Damage Taken When Hitting An Enemy)" + " - COST 3¢");
                        Console.WriteLine("Press 3 - Fully Heal" + " - COST 4¢");
                        Console.WriteLine("Press 4 - Increase Potion Heal Amount" + " - COST 5¢");
                        Console.WriteLine("Press X - To Leave Shop.");
                    }
                        else
                        {
                            Console.WriteLine("You Don't Have Enough Souls");
                        }
                    break;
                case ConsoleKey.X:
                    InShop = true;
                    break;
                default:
                    break;
            }




        } while (!InShop);
           
    }
}
}
