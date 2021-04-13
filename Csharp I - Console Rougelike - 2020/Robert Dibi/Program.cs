using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EndOfSemester_Project
{
class Program
{
        // --------------- C# 101 (Dor Ben Dor) ---------------
        //                     Robert Dibi
        //                 Due Date: 1/3/2021
        // ----------------------------------------------------
        static void Main(string[] args)
{
            
            
    bool gameOver = false;
    Sounds SoundMngr = new Sounds();
    SoundMngr.BackgroundMusic();
    while (!gameOver)
    {
        switch (Map.GetMapInstance.LevelCounter)
        {

            case 1:
                Console.SetWindowSize(120, 45);
                GameState.GetGameStateInstance.MainMenu();
                Map.GetMapInstance.MapCreation();
                HUD.GetHUDInstance.ShowHUD();
                Player.GetPlayerInstance.CheckMove();
                Console.Clear();

                break;
            case 2:
                Console.WriteLine("A distant voice echoes in the darkness of the cave...");
                Console.WriteLine("It calls your name " + Player.GetPlayerInstance.Name);
                Console.ReadLine();
                Console.Clear();
                Console.SetWindowSize(120, 45);
                Map.GetMapInstance.MapCreation();
                HUD.GetHUDInstance.ShowHUD();
                Console.WriteLine("You have advanced to level " + Map.GetMapInstance.LevelCounter + "!");
                Player.GetPlayerInstance.CheckMove();
                Console.Clear();

                break;
            case 3:

                Console.WriteLine("Everything turns white infront of you..You hear Fighting and Swords clashing.");
                Console.WriteLine("____________________________________________________________________________");
                Console.WriteLine("A Vision Of The Past");
                Console.ReadLine();
                Console.Clear();
                Console.SetWindowSize(120, 45);
                Map.GetMapInstance.MapCreation();
                HUD.GetHUDInstance.ShowHUD();
                Console.WriteLine("You have advanced to level " + Map.GetMapInstance.LevelCounter + "!");
                Player.GetPlayerInstance.CheckMove();
                Console.Clear();

                break;
            case 4:
                    Console.WriteLine("You look at your hands , drenched in blood...however it is not your own.");
                    Console.ReadLine();
                    Console.Clear();
                Console.WriteLine("You find a strange store inside the cave that offers magical powers in return for souls");
                Console.ReadLine();
                Console.Clear();
                Shop.GetShopInstance.AbookShop();
                        Console.Clear();
                        Console.SetWindowSize(120, 45);
                Map.GetMapInstance.MapCreation();
                HUD.GetHUDInstance.ShowHUD();
                Console.WriteLine("You have advanced to level " + Map.GetMapInstance.LevelCounter + "!");
                Player.GetPlayerInstance.CheckMove();
                Console.Clear();

                break;
            case 5:
                  
                Console.WriteLine("You remember a flashing light , a figure is standing infront of it");
                Console.WriteLine("You cannot make out who or what it is.");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("The same shop from before , you see it again....");
                Console.ReadLine();
                Console.Clear();
                Shop.GetShopInstance.AbookShop();
                        Console.Clear();
                        Console.SetWindowSize(120, 45);
                Map.GetMapInstance.MapCreation();
                HUD.GetHUDInstance.ShowHUD();
                Console.WriteLine("You have advanced to level " + Map.GetMapInstance.LevelCounter + "!");
                Player.GetPlayerInstance.CheckMove();
                Console.Clear();
                break;
            case 6:
                Console.WriteLine("God forbid, I don't hate any student, I deeply despise you all.");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("The same shop from before , you see it again....");
                Console.ReadLine();
                Console.Clear();
                Shop.GetShopInstance.AbookShop();
                        Console.Clear();
                        Console.SetWindowSize(120, 45);
                Map.GetMapInstance.MapCreation();
                HUD.GetHUDInstance.ShowHUD();
                Console.WriteLine("You have advanced to level " + Map.GetMapInstance.LevelCounter + "!");
                Player.GetPlayerInstance.CheckMove();
                Console.Clear();
                break;
            case 7:
                Console.WriteLine("You Are Not From This World.....");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("The same shop from before , you see it again....");
                Console.ReadLine();
                Console.Clear();
                Shop.GetShopInstance.AbookShop();
                Console.Clear();
                Console.SetWindowSize(120, 45);
                Map.GetMapInstance.MapCreation();
                HUD.GetHUDInstance.ShowHUD();
                Console.WriteLine("You have advanced to level " + Map.GetMapInstance.LevelCounter + "!");
                Player.GetPlayerInstance.CheckMove();
                Console.Clear();
                break;
            case 8:
                Console.WriteLine("You remember the name of a great warrior that fought beside you");
                Console.WriteLine("Their name was Dor Ben Dor , famously know for their cruelty and facial hair");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("The same shop from before , you see it again....");
                Console.ReadLine();
                Console.Clear();
                Shop.GetShopInstance.AbookShop();
                Console.Clear();
                Console.SetWindowSize(120, 45);
                Map.GetMapInstance.MapCreation();
                HUD.GetHUDInstance.ShowHUD();
                Console.WriteLine("You have advanced to level " + Map.GetMapInstance.LevelCounter + "!");
                Player.GetPlayerInstance.CheckMove();
                Console.Clear();
                break;
            case 9:
                Console.WriteLine("You can sense a strong energy in the room after this one...");
                Console.WriteLine("take your time here and only move forward after you have prepared yourself");
                Console.ReadLine();
                Console.Clear();
                Console.SetWindowSize(120, 45);
                Map.GetMapInstance.MapCreation();
                HUD.GetHUDInstance.ShowHUD();
                Console.WriteLine("You have advanced to level " + Map.GetMapInstance.LevelCounter + "!");
                Player.GetPlayerInstance.CheckMove();
                Console.Clear();
                break;
            case 10:

                Console.WriteLine("The same shop from before , this is the last time you will see it....");
                Console.ReadLine();
                Console.Clear();
                Shop.GetShopInstance.AbookShop();
                Console.Clear();
                Console.SetWindowSize(120, 45);
                Map.GetMapInstance.MapCreation();
                HUD.GetHUDInstance.ShowHUD();
                Console.WriteLine("You have advanced to level " + Map.GetMapInstance.LevelCounter + "!");
                Player.GetPlayerInstance.CheckMove();
                Console.Clear();
                break;
                    case 11:
                        SoundMngr.StopBckgrnd();
                        SoundMngr.Ending();
                        Console.WriteLine("The wind howls outside, you're laying on a straw bed.");
                        Console.WriteLine("Awakened by a distant voice, You slowly open your eyelids.");
                        Console.WriteLine(Player.GetPlayerInstance.Name + ": " + "Haven't I Been Here Before?");
                        Console.WriteLine(" ");
                        Console.WriteLine("Press Enter to continue.....");
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("You Have Completed ROB'S LAND");
                        Console.WriteLine("Thank you for playing my game and I hope you enjoyed it for what it is");
                        Console.ReadLine();
                        break;
            case 12:
                Console.Clear();
                Console.SetWindowSize(120, 45);
                        SoundMngr.StopBckgrnd();
                        SoundMngr.GameOver();
                Console.WriteLine("YOUR HEALTH HAS REACHED 0!");
                Console.WriteLine("Your Journey has come to an end " + Player.GetPlayerInstance.Name+"......");
                Console.WriteLine("Restart the console to play again!");
                Console.ReadLine();
                break;
            default:
                break;

        }
                

    }
          

 
            
            



}
}
}
