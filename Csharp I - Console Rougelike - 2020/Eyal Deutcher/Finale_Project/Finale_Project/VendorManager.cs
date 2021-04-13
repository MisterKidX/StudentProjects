using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    public class VendorManager
    {
        static bool inShop = false;
        //check if player is on the vendor
        //if so, make the screen go to shop
        //handle enter and exit from the shop
        public static void EnterShop()
        {
            SoundManager.VendorSound();
            inShop = true;
            while (inShop == true)
            {
                Console.Clear();
                Hud.PrintHUD();
                ShopText();
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.X:
                        inShop = false;
                        Console.Clear();
                        break;
                    case ConsoleKey.D1:
                        if(PlayerStats.hasSword != true)
                        {
                            if(PlayerStats.gold >= ItemManager.Sword.buyPrice)
                            {
                                SoundManager.PerchaseSound();
                                Vendor.BuySword();
                            }
                            else
                            {
                                Hud.InfoText2 = "Not Enough Resources to complete Purchase";
                            }
                        }
                        else
                        {
                            if(PlayerStats.gold >= ItemManager.Sword.upgradeGoldPrice && PlayerStats.leather >= ItemManager.Sword.upgradeLeatherPrice)
                            {
                                SoundManager.PerchaseSound();
                                Vendor.UpgradeSword();
                            }
                            else
                            {
                                Hud.InfoText2 = "Not Enough Resources to complete Purchase";
                            }
                        }
                        break;
                    case ConsoleKey.D2:
                        if (PlayerStats.hasBow != true)
                        {
                            if (PlayerStats.gold >= ItemManager.Bow.buyPrice)
                            {
                                SoundManager.PerchaseSound();
                                Vendor.BuyBow();
                            }
                            else
                            {
                                Hud.InfoText2 = "Not Enough Resources to complete Purchase";
                            }
                        }
                        else
                        {
                            if (PlayerStats.gold >= ItemManager.Bow.upgradeGoldPrice && PlayerStats.leather >= ItemManager.Bow.upgradeLeatherPrice)
                            {
                                SoundManager.PerchaseSound();
                                Vendor.UpgradeBow();
                            }
                            else
                            {
                                Hud.InfoText2 = "Not Enough Resources to complete Purchase";
                            }
                        }
                        break;
                    case ConsoleKey.D3:
                        if (PlayerStats.hasHelmet != true)
                        {
                            if (PlayerStats.gold >= ItemManager.Helmet.buyPrice)
                            {
                                SoundManager.PerchaseSound();
                                Vendor.BuyHelmet();
                            }
                            else
                            {
                                Hud.InfoText2 = "Not Enough Resources to complete Purchase";
                            }
                        }
                        else
                        {
                            if (PlayerStats.gold >= ItemManager.Helmet.upgradeGoldPrice && PlayerStats.leather >= ItemManager.Helmet.upgradeLeatherPrice)
                            {
                                SoundManager.PerchaseSound();
                                Vendor.UpgradeHelmet();
                            }
                            else
                            {
                                Hud.InfoText2 = "Not Enough Resources to complete Purchase";
                            }
                        }
                        break;
                    case ConsoleKey.D4:
                        if (PlayerStats.hasChestPlate != true)
                        {
                            if (PlayerStats.gold >= ItemManager.ChestPlate.buyPrice)
                            {
                                SoundManager.PerchaseSound();
                                Vendor.BuyChestPlate();
                            }
                            else
                            {
                                Hud.InfoText2 = "Not Enough Resources to complete Purchase";
                            }
                        }
                        else
                        {
                            if (PlayerStats.gold >= ItemManager.ChestPlate.upgradeGoldPrice && PlayerStats.leather >= ItemManager.ChestPlate.upgradeLeatherPrice)
                            {
                                SoundManager.PerchaseSound();
                                Vendor.UpgradeChestPlate();
                            }
                            else
                            {
                                Hud.InfoText2 = "Not Enough Resources to complete Purchase";
                            }
                        }
                        break;
                    case ConsoleKey.D5:
                        if (PlayerStats.hasArmBracers != true)
                        {
                            if (PlayerStats.gold >= ItemManager.ArmBracers.buyPrice)
                            {
                                SoundManager.PerchaseSound();
                                Vendor.BuyArmBracers();
                            }
                            else
                            {
                                Hud.InfoText2 = "Not Enough Resources to complete Purchase";
                            }
                        }
                        else
                        {
                            if (PlayerStats.gold >= ItemManager.ArmBracers.upgradeGoldPrice && PlayerStats.leather >= ItemManager.ArmBracers.upgradeLeatherPrice)
                            {
                                SoundManager.PerchaseSound();
                                Vendor.UpgradeArmBracers();
                            }
                            else
                            {
                                Hud.InfoText2 = "Not Enough Resources to complete Purchase";
                            }
                        }
                        break;
                    case ConsoleKey.D6:
                        if (PlayerStats.hasBoots != true)
                        {
                            if (PlayerStats.gold >= ItemManager.Boots.buyPrice)
                            {
                                SoundManager.PerchaseSound();
                                Vendor.BuyBoots();
                            }
                            else
                            {
                                Hud.InfoText2 = "Not Enough Resources to complete Purchase";
                            }
                        }
                        else
                        {
                            if (PlayerStats.gold >= ItemManager.Boots.upgradeGoldPrice && PlayerStats.leather >= ItemManager.Boots.upgradeLeatherPrice)
                            {
                                SoundManager.PerchaseSound();
                                Vendor.UpgradeBoots();
                            }
                            else
                            {
                                Hud.InfoText2 = "Not Enough Resources to complete Purchase";
                            }
                        }
                        break;
                    case ConsoleKey.D7:
                        if (PlayerStats.hasGuntlet != true)
                        {
                            if (PlayerStats.gold >= ItemManager.Guntlet.buyPrice)
                            {
                                SoundManager.PerchaseSound();
                                Vendor.BuyGuntlet();
                            }
                            else
                            {
                                Hud.InfoText2 = "Not Enough Resources to complete Purchase";
                            }
                        }
                        else
                        {
                            if (PlayerStats.gold >= ItemManager.Guntlet.upgradeGoldPrice && PlayerStats.leather >= ItemManager.Guntlet.upgradeLeatherPrice)
                            {
                                SoundManager.PerchaseSound();
                                Vendor.UpgradeGuntlet();
                            }
                            else
                            {
                                Hud.InfoText2 = "Not Enough Resources to complete Purchase";
                            }
                        }
                        break;
                    case ConsoleKey.D8:
                        {
                            if(PlayerStats.gold >= Vendor.refillHPCost)
                            {
                                SoundManager.PerchaseSound();
                                Vendor.RefillHP();
                            }
                            else
                            {
                                Hud.InfoText2 = "Not Enough Resources to complete Purchase";
                            }
                        }
                        break;
                    case ConsoleKey.D9:
                        {
                            if (PlayerStats.gold >= Vendor.increaceMaxHPCost)
                            {
                                SoundManager.PerchaseSound();
                                Vendor.IncreaceMaxHP();
                            }
                            else
                            {
                                Hud.InfoText2 = "Not Enough Resources to complete Purchase";
                            }
                        }
                        break;
                }
            }
        }
        static void ShopText()
        {
            Console.WriteLine("-----Shop-----");
            Console.WriteLine();
            Console.Write("To ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" Exit ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" Shop Press");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" x");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" key");
            Console.WriteLine();

            BuyOrUpgradeItems();

            HealthUpgrades();
        }
        static void BuyOrUpgradeItems()
        {
            if(PlayerStats.hasSword != true)
            {
                Console.Write("To Buy ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(ItemManager.Sword.name);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("           for ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(ItemManager.Sword.buyPrice + " Gold");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" Press ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ItemManager.Sword.id);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.Write("To Upgrade ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(ItemManager.Sword.name);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("       for ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(ItemManager.Sword.upgradeGoldPrice + " Gold");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" and ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(ItemManager.Sword.upgradeLeatherPrice + " Leather");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" Press ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ItemManager.Sword.id);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if (PlayerStats.hasBow != true)
            {
                Console.Write("To Buy ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(ItemManager.Bow.name);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("             for ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(ItemManager.Bow.buyPrice + " Gold");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" Press ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ItemManager.Bow.id);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.Write("To Upgrade ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(ItemManager.Bow.name);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("         for ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(ItemManager.Bow.upgradeGoldPrice + " Gold");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" and ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(ItemManager.Bow.upgradeLeatherPrice + " Leather");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" Press ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ItemManager.Bow.id);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if (PlayerStats.hasHelmet!= true)
            {
                Console.Write("To Buy ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(ItemManager.Helmet.name);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("          for ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(ItemManager.Helmet.buyPrice + " Gold");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" Press ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ItemManager.Helmet.id);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.Write("To Upgrade ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(ItemManager.Helmet.name);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("      for ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(ItemManager.Helmet.upgradeGoldPrice + " Gold");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" and ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(ItemManager.Helmet.upgradeLeatherPrice + " Leather");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" Press ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ItemManager.Helmet.id);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if (PlayerStats.hasChestPlate != true)
            {
                Console.Write("To Buy ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(ItemManager.ChestPlate.name);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("     for ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(ItemManager.ChestPlate.buyPrice + " Gold");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" Press ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ItemManager.ChestPlate.id);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.Write("To Upgrade ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(ItemManager.ChestPlate.name);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" for ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(ItemManager.ChestPlate.upgradeGoldPrice + " Gold");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" and ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(ItemManager.ChestPlate.upgradeLeatherPrice + " Leather");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" Press ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ItemManager.ChestPlate.id);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if (PlayerStats.hasArmBracers != true)
            {
                Console.Write("To Buy ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(ItemManager.ArmBracers.name);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("     for ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(ItemManager.ArmBracers.buyPrice + " Gold");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" Press ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ItemManager.ArmBracers.id);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.Write("To Upgrade ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(ItemManager.ArmBracers.name);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" for ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(ItemManager.ArmBracers.upgradeGoldPrice + " Gold");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" and ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(ItemManager.ArmBracers.upgradeLeatherPrice + " Leather");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" Press ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ItemManager.ArmBracers.id);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if (PlayerStats.hasBoots != true)
            {
                Console.Write("To Buy ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(ItemManager.Boots.name);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("           for ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(ItemManager.Boots.buyPrice + " Gold");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" Press ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ItemManager.Boots.id);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.Write("To Upgrade ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(ItemManager.Boots.name);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("       for ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(ItemManager.Boots.upgradeGoldPrice + " Gold");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" and ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(ItemManager.Boots.upgradeLeatherPrice + " Leather");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" Press ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ItemManager.Boots.id);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if (PlayerStats.hasGuntlet != true)
            {
                Console.Write("To Buy ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(ItemManager.Guntlet.name);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("         for ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(ItemManager.Guntlet.buyPrice + " Gold");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" Press ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ItemManager.Guntlet.id);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.Write("To Upgrade ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(ItemManager.Guntlet.name);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("     for ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(ItemManager.Guntlet.upgradeGoldPrice + " Gold");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" and ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(ItemManager.Guntlet.upgradeLeatherPrice + " Leather");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" Press ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ItemManager.Guntlet.id);
                Console.ForegroundColor = ConsoleColor.Gray;
            }






        }
        static void HealthUpgrades()
        {
            Console.Write("To Refill ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("HP");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("           for ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Vendor.refillHPCost + " Gold");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" Press ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("8");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("To Increace ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Max HP");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("     for ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Vendor.increaceMaxHPCost + " Gold");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" Press ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("9");
            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }
}
