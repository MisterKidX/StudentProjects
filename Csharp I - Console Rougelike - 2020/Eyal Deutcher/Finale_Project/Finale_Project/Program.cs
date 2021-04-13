using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    class Program
    {
        //----C#101(Dor Ben Dor)----
        //      Eyal Deutscher
        //          14/2/21
        //--------------------------
        static void Main(string[] args)
        {
            bool replay = true;
            while (replay)
            {
                GameManager gameManager = new GameManager();
                bool gameNotOver = true;
                gameManager.SetupGame();
                while (gameNotOver)
                {
                    gameNotOver = gameManager.GamePlayLoop();
                }
                replay = gameManager.EndGameEvents();
            }

            //--level creating--
            //create a map class that contains all the map stuff ---Success---
            //make a switch that let you change the parameters for this if wanted ---Success---
            //create a 2d string array that has X by X cells ---Success---
            //in each cell put a string that represents the basic map ---Success---
            //after you have a square map, try to think about a methode to make islands --- Partial Success---
            //you need to have the functionality of walls, making the player recognize where do he wanna go ---Success---
            //and when he try to go there he can get stuck in a wall---Success---
            //islands are # ---Success---
            //an option to make the map asymetrical ---Success---

            //--Player--
            //create a player script that hande movement and stats ---Success---
            //undersand how to tell a player to move in the array with input from the keybard ---Success---
            //player should be able to move into 4 directions ---Success---
            //player should have an inventory that he can see ---Success---
            //player need to be able to detect if there is a: wall, enemy, chest, exit, traps ---Success---
            //player need to spawn on the entrence of the level ---Success---
            //player going to have stats, HP, strength, gold and maybe more ---Success---
            //have basic stats of crit, damage reduction, and evation

            //--Items--
            //class of items will handle the items creation---Success---
            //have a spesific items that are pre made before and can be picked up---Success---
            //put them in spesific slots that the player can choose from---Success---
            //like weapon: sword for key 1 shield for key 2---Success---
            //make the player equip them

            //--merchant--
            //merchant will have items in his store---Success---
            //recives gold and return the item bought---Success---
            //if in item was bought vendor upgraged the items in his shop after the player has finished buying stuff---Success---

            //--enemies--
            //class of enemy will create the enemy types and handle their stats
            //enemy will have a size
            //enemy will have hp---Success---
            //enemy will have strength
            //enemy will move toward player with an AI
            //enemy can drop gold---Success---
            //enemies can drop matetials for weapon upgrades---Success---

            //--Combat--
            //class of combat will handle any interaction between player and monsters---Success---
            //player can attack a direction one of the 4 sides he can move and add an attack type---Success---
            //monster move to player and if reaches it it will exploade on the player and hurt him---Success---

            //--Saves and loads
            //will make a copy of all stats and map values and print them back when needed

            //--Game Manager--
            //will hande spawning of the map by level/difficulty and re creating in every turn ---Success---
            //will handle text to show from different places that the player can see every turn ---Success---
            //can show a hud that help the player understand what he can do and how much lives he has <3 ---Success---
            //will spawn enemies ---Success---
            //will spawn player at the starting point ---Success---
            //knows when the player died ---Success---
            //will paint the world with colors ---Success---
            //handle starting the game/screen for game start with menu 
            //handle end game menu and maybe show some stats at the end of the game 
        }
    }
}
