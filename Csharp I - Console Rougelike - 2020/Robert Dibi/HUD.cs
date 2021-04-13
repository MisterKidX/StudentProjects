using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndOfSemester_Project
{
class HUD
{
    private static HUD _hudInstance = null;
    public static HUD GetHUDInstance
    {
        get
        {
            if (_hudInstance == null)
            {
                _hudInstance = new HUD();
            }
            return _hudInstance;
        }
    }
        
    public void ShowHUD() 
    {
           
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(Player.GetPlayerInstance.Name + "'s HEALTH : " + Player.GetPlayerInstance.CurrentHP + "/" + Player.GetPlayerInstance.MaxHP + " ");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(Player.GetPlayerInstance.Name +"'s POTIONS : " +Player.GetPlayerInstance.PotionCounter +" Press H To Use!");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(Player.GetPlayerInstance.Name + "'s LOST SOULS : " + Player.GetPlayerInstance.LostSouls + "¢");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(Player.GetPlayerInstance.Name +"'s ENEMIES SLAIN : " + Player.GetPlayerInstance.EnemiesKilled);
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("Current Level : " + Map.GetMapInstance.LevelCounter);
        Console.ResetColor();
           
    }

}
}
