using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPrograingGame
{
    class Gamerenderr1
    {
        Story story = new Story();

        public Gamerenderr1()
        {
            bool end = false;
            bool gameover = false;
            Music gamemusic = new Music();
            story.Narative("amit");
            Console.Clear();
            while (!end)
            {

            
            while (!gameover)
            {
                switch (MapCreator.getMapInstance.lvlcounter)
                {
                    case 1:
                        gamemusic.bgfmusic();
                        MapCreator.getMapInstance.lvl1();
                        HUD.gethudInstance.Hudcreator();
                        Movement.getMovementInstance.DrawPlayer();
                        Console.Clear();
                        break;
                    case 2:
                        SHOP.getshopInstance.Shopcreator();
                        SHOP.getshopInstance.buyphase();
                        Console.Clear();
                        MapCreator.getMapInstance.lvl2();
                        HUD.gethudInstance.Hudcreator();
                        Movement.getMovementInstance.DrawPlayer();
                        Console.Clear();
                        break;
                    case 3:
                        SHOP.getshopInstance.Shopcreator();
                        SHOP.getshopInstance.buyphase();
                        Console.Clear();
                        MapCreator.getMapInstance.lvl3();
                        HUD.gethudInstance.Hudcreator();
                        Movement.getMovementInstance.DrawPlayer();
                        Console.Clear();
                        break;
                    case 4:
                        SHOP.getshopInstance.Shopcreator();
                        SHOP.getshopInstance.buyphase();
                        Console.Clear();
                        MapCreator.getMapInstance.lvl4();
                        HUD.gethudInstance.Hudcreator();
                        Movement.getMovementInstance.DrawPlayer();
                        Console.Clear();
                        break;
                    case 5:
                        SHOP.getshopInstance.Shopcreator();
                        SHOP.getshopInstance.buyphase();
                        Console.Clear();
                        MapCreator.getMapInstance.lvl5();
                        HUD.gethudInstance.Hudcreator();
                        Movement.getMovementInstance.DrawPlayer();
                        Console.Clear();
                        break;
                    case 6:
                        SHOP.getshopInstance.Shopcreator();
                        SHOP.getshopInstance.buyphase();
                        Console.Clear();
                        MapCreator.getMapInstance.lvl6();
                        HUD.gethudInstance.Hudcreator();
                        Movement.getMovementInstance.DrawPlayer();
                        Console.Clear();
                        break;
                    case 7:
                        SHOP.getshopInstance.Shopcreator();
                        SHOP.getshopInstance.buyphase();
                        Console.Clear();
                        MapCreator.getMapInstance.lvl7();
                        HUD.gethudInstance.Hudcreator();
                        Movement.getMovementInstance.DrawPlayer();
                        Console.Clear();
                        break;
                    case 8:
                        SHOP.getshopInstance.Shopcreator();
                        SHOP.getshopInstance.buyphase();
                        Console.Clear();
                        MapCreator.getMapInstance.lvl8();
                        HUD.gethudInstance.Hudcreator();
                        Movement.getMovementInstance.DrawPlayer();
                        Console.Clear();
                        break;
                    case 9:
                        SHOP.getshopInstance.Shopcreator();
                        SHOP.getshopInstance.buyphase();
                        Console.Clear();
                        MapCreator.getMapInstance.lvl9();
                        HUD.gethudInstance.Hudcreator();
                        Movement.getMovementInstance.DrawPlayer();
                        Console.Clear();
                        break;
                    case 10:
                        SHOP.getshopInstance.Shopcreator();
                        SHOP.getshopInstance.buyphase();
                        Console.Clear();
                        MapCreator.getMapInstance.lvl10();
                        HUD.gethudInstance.Hudcreator();
                        Movement.getMovementInstance.DrawPlayer();
                        Console.Clear();
                        break;
                    case 11:
                        if (player.getplayerInstance.baseHp <= 0)
                        {
                            gameover = true;
                            Console.WriteLine("Faitlty NOOB MASTER LOST ");
                        }
                        else
                        {
                            gameover = true;
                            Console.WriteLine("Victory now go play minecraft");
                        }
                        break;


                }
                if (player.getplayerInstance.baseHp <= 0)
                {
                    MapCreator.getMapInstance.lvlcounter = 11;
                }
            }

            Console.WriteLine("Wanna do it again ? y/n");
                ConsoleKeyInfo input;
                bool answer = false;
                do
            {
                    
                    input = Console.ReadKey(true);
                    switch (input.Key)
                    {
                        case ConsoleKey.Y:
                            player.getplayerInstance.baseHp = 100;
                            player.getplayerInstance.coins = 0;
                            player.getplayerInstance.enemydmg = 10;
                            MapCreator.getMapInstance.lvlcounter = 1;
                            gameover = false;
                            answer = true;
                            Console.Clear();
                            break;
                        case ConsoleKey.N:
                            answer = true;
                            end = true;
                            break;
                        default:
                            Console.WriteLine("wrong answer");
                            break;
                    }

                } while (!answer);
        }
            if (gameover)
            {
                Console.WriteLine("game over");
            }
        }
    }
}
