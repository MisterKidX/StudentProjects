using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace FinalProject101_RonBandel
{
    class Program
    {
        // ---- C# 101 (Dor Ben Dor) ----
        //          Ron Bandel       
        //          01/03/2021
        // ------------------------------
        // ---- Extra Credit
        //  X   1. Create an options menu that can set the map generation algorithm parameters, console logs count and other aspects of gameplay
        //  V   2. Create a HUD to present the player important data such as HP, armor, etc.    
        //  ?   3. Create an inventory system   
        //  V   4. Create enemies bigger than one tile  
        //  X   5. Add a save and load system
        //  X   6. Create a more elaborate AI for enemies
        //  V   7. Make the maps asymmetrical  
        //  V   8. Make an elaborate combat system that uses damage reduction, evasion, critical hits etc.  
        //  V   9. Use colors within the console to denote different entities   
        //  V   10. Create shops that sell items and currency that can be dropped   
        //  V   11. Add various sound effects   

        static void Main(string[] args)
        {
            Console.CursorVisible = false; // makes the cursor invisible
            Map.GenerateRandomMap();
            while (Player.Instance.alive)
            {
                Update();                
            }
        }   // ----- End of Main -----

        static void Update()
        {
            int refreshRate = 20;
            Player.Instance.PlayerUpdate();
            EnemyManager.Instance.Update();

            Thread.Sleep(refreshRate);
        }
    }   // ----- End of Program -----
}   // ----- End of NameSpace -----