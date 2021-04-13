using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TryFinal
{
    class Game
    {
        public int level = 1;
        public Game(int level)
        {
            MapGenerator map = new MapGenerator(20, 50, level);
            Player player = new Player(10);
            GameLoop(level);
            playGame(map, level, player.name);
        }
        public void playGame(MapGenerator map, int level, string name)
        {
            map.CreatEnemy(level);
            Player player = map.drawPlayer('@', level); //retruns enemy
           //  Enemies enemy = map.drawEnemy('M', level);
            player.name = name;
            map.drawMap();
            player.movePlayer(level);
        }

        public void combatSystem()
        {
            //ConsoleKeyInfo keyinf;
            //player.movePlayer();
            //while (!Console.KeyAvailable)
            //{
            //    enemy.moveEnemy();
            //    break;
            //}
            //keyinf = Console.ReadKey(true);
            //Console.WriteLine(keyinf.Key);
            //Console.ReadLine();
        }
        public void GameLoop(int level)
        {

            bool playerLost = false;
            //int level = this.level;
            MapGenerator map = new MapGenerator(20, 50, level);
            Player player = new Player(10);

            // playGame(map , level);   



            while (!playerLost)
            {
                if (level == 1)
                {
                    Console.WriteLine("Hello Welcome to the Daungeon");
                    Console.WriteLine(" ");
                    Console.WriteLine("       Press Enter");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Are You Ready To DIE?");
                    Console.WriteLine(" ");
                    Console.WriteLine("       Press Enter");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Enter Your Name:");
                    player.name = Console.ReadLine();
                    Console.Clear();
                }

                //player.currentHP = 1;
                if(level <= 5)
                {
                    playGame(map, level, player.name);
                }
                else if(level > 5)
                {
                    Console.WriteLine("You Win!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    level = 1;
                    GameLoop(level);
                    
                    break;
                }    
                //if(player.currentHP <= 0)
                //{
                //    playerLost = true;
                //    Console.WriteLine("You Lost");
                //    break;
                //}
            }
        }
    }
}
