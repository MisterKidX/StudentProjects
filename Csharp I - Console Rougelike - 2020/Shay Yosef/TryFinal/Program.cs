using System;
using System.Security.Cryptography.X509Certificates;

namespace TryFinal
{


    class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game(1);
            game.GameLoop(1);

            //bool playerLost = false;
            //int level = 1;


            //MapGenerator map = new MapGenerator(20, 50, level);
            //Player player = new Player('@', 0, 0, 0, 0, 0, map);

            //// playGame(map , level);   
            ////Console.WriteLine("Hello Welcome to the Daungeon");
            ////Console.WriteLine(" ");
            ////Console.WriteLine("       Press Enter");            
            ////Console.ReadLine();
            ////Console.Clear();
            ////Console.WriteLine("Are You Ready To DIE?");
            ////Console.WriteLine(" ");
            ////Console.WriteLine("       Press Enter");
            ////Console.ReadLine();
            ////Console.Clear();
            ////Console.WriteLine("Enter Your Name:");
            ////player.name = Console.ReadLine();
            ////Console.Clear();

            //while (!playerLost)
            //{
            //    playGame(map, level, player.name);

            //    while (level < 5)
            //    {

            //        //if(player. == 'X')
            //        //{
            //        //    Console.Clear();
            //        //}
            //    }





            //}


        }


        static void playGame(MapGenerator map , int level, string name)
        {
            //Enemies enemy = map.drawEnemy('M' , level);     
            map.CreatEnemy(level);
            Player player = map.drawPlayer('@' , level); //retruns enemy
            player.name = name;
            map.drawMap();
            player.movePlayer(level);
            
            // enemy.moveEnemy();

            //retruns player
            
            
                // move player and enemy here
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
    }
}
