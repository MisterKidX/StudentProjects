using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleGame
{
    class Game
    {
        private World CurrentWorld;
        public Player CurrentPlayer;
        public Enemy CurrentEnemy;
        private Laser CurrentLaser;
        private Game CurrentGame;
        public Exit CurrentExit;
        private Treasure CurrentTreasure;
        private Traps CurrentTrap;
        int level = 1;
        // The symbols that will be used to draw boxes.
        private static readonly char[] BoxSymbols = { '═', '║', '╬' };


        public void Start()
        {
            Title = "Welcome to the Maze!";
            CursorVisible = false;
            DisplayIntro();
            RunGameLoop();
        }

        private void HandleMovement()
        {
            ConsoleKey key = ReadKey(true).Key;
            GameObject.direction direction = GameObject.direction.Other;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    direction = GameObject.direction.Up;
                    break;

                case ConsoleKey.DownArrow:
                    direction = GameObject.direction.Down;
                    break;

                case ConsoleKey.LeftArrow:
                    direction = GameObject.direction.Left;
                    break;

                case ConsoleKey.RightArrow:
                    direction = GameObject.direction.Right;
                    break;

                case ConsoleKey.Z:

                    if (!CurrentWorld.HasGameObject(CurrentTreasure))
                    {
                        if (CurrentWorld.HasGameObject(CurrentLaser))
                        {
                            return;
                        }
                        Beep(466, 52);
                        if (!CurrentWorld.HasGameObject(CurrentLaser) && CurrentWorld.HasGameObject(CurrentEnemy))
                        {
                            CurrentLaser = new Laser(CurrentPlayer.X, CurrentPlayer.Y, CurrentGame, CurrentPlayer, CurrentWorld, CurrentEnemy);
                            CurrentWorld.AddGameObject(CurrentLaser);
                        }

                    }

                    break;
                case ConsoleKey.S:
                    CurrentPlayer.Y++;
                    CurrentPlayer.Y++;
                    CurrentWorld.DrawWorld();
                    break;
                case ConsoleKey.W:
                    CurrentPlayer.Y--;
                    CurrentPlayer.Y--;
                    CurrentWorld.DrawWorld();
                    break;
                case ConsoleKey.D:
                    CurrentPlayer.X++;
                    CurrentPlayer.X++;
                    CurrentWorld.DrawWorld();
                    break;
                case ConsoleKey.A:
                    CurrentPlayer.X--;
                    CurrentPlayer.X--;
                    CurrentWorld.DrawWorld();
                    break;
            }
            if (direction != GameObject.direction.Other)
            {
                CurrentWorld.MoveGameObject(CurrentPlayer, direction);
                CurrentEnemy.EnemyMoveToTarget();
                CurrentLaser?.MoveLaser();
            }

        }
        private void DisplayIntro()
        {
            WriteLine(">Welcome To My Trash Game!");
            WriteLine("\n>Instructions");
            WriteLine(">Use the arrow keys to move!");
            Write(">Try to reach the goal that looks like this: ");
            ForegroundColor = ConsoleColor.Green;
            Write("X\n");
            ResetColor();
            WriteLine(">To Reach The X, You Must Defeat The Enemy!");
            WriteLine(">If You Collect The Treasure you can Use The Laser To Shoot the Enemey!");
            WriteLine(">Press Z To Fire The Laser!");
            Beep(659, 125); Beep(659, 125); Thread.Sleep(125); Beep(659, 125); Thread.Sleep(167); Beep(523, 125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(375); Console.Beep(392, 125); Thread.Sleep(375);
            WriteLine("\n>Press Any Key To Start");
            ReadKey(true);
            Clear();

        }
        private void DisplayOutro()
        {
            Clear();
            WriteLine("You Escaped :0");
            WriteLine("Thanks For Playing my game :)");
            WriteLine(">Press Any key To Exit...");
            Beep(130, 100); Beep(262, 100); Beep(330, 100); Beep(392, 100); Beep(523, 100); Beep(660, 100); Beep(784, 300); Beep(660, 300); Beep(146, 100); Beep(262, 100); Beep(311, 100); Beep(415, 100); Beep(523, 100); Beep(622, 100); Beep(831, 300); Beep(622, 300); Beep(155, 100); Beep(294, 100); Beep(349, 100); Beep(466, 100); Beep(588, 100); Beep(699, 100); Beep(933, 300); Beep(933, 100); Beep(933, 100); Beep(933, 100); Beep(1047, 400);
            ReadKey(true);

        }
        private void DisplayLoose()
        {
            Clear();
            WriteLine("You Just Got Bamozled by stupid AI");
            WriteLine("Thanks For Loosing in my game :)");
            WriteLine(">Press Any key To Exit...");
            ReadKey(true);
        }
        private void DrawFrame()
        {
            CurrentWorld.DrawGameObjects();
        }

        public void CreateLevel(int level)
        {
            Clear();
            //Game Settings
            // if we send {50, 50} - the right top position is {0, 0} and the left bottom position is {50, 50}.
            int[] MapEndPoint = new int[] { 30 + (level * 5), 30 + (level * 5) };
            CurrentWorld = new World(MapEndPoint, BoxSymbols, 2 + (level * 2), new int[] { 2 + (level * 3), 2 + (level * 3) }, new int[,] { { 3, 3 }, { 35, 35 } });
            //Player(x,y)
            CurrentPlayer = new Player(new int[,] { { 1, 1 }, { 7, 7 } });
            CurrentWorld.AddGameObject(CurrentPlayer);
            //Enemy(x,y)
            int[,] EnemyAndTreasureSpawnZone = new int[,] { { MapEndPoint[0] - 5, MapEndPoint[1] - 5 }, { MapEndPoint[0] - 1, MapEndPoint[1] - 1 } };
            CurrentEnemy = new Enemy(CurrentPlayer, CurrentWorld, EnemyAndTreasureSpawnZone);
            CurrentWorld.AddGameObject(CurrentEnemy);
            //Treasure(x,y)
            CurrentTreasure = new Treasure(EnemyAndTreasureSpawnZone);
            CurrentWorld.AddGameObject(CurrentTreasure);
            CurrentTrap = new Traps(EnemyAndTreasureSpawnZone);
            CurrentWorld.AddGameObject(CurrentTrap);
            CurrentWorld.DrawWorld();
            CurrentWorld.SpawnGameObjects();
            DrawFrame();
            SetWindowSize(CurrentWorld.MapGrid.GetLength(0) + 5, CurrentWorld.MapGrid.GetLength(1) + 5);
            SetCursorPosition(0, 0);
            SetBufferSize(CurrentWorld.MapGrid.GetLength(0) + 15, CurrentWorld.MapGrid.GetLength(1) + 15);
        }
        public bool CanShootLaser()
        {
            return !CurrentWorld.HasGameObject(CurrentTreasure);
        }
        private void HUD()
        {
            SetCursorPosition(CurrentWorld.MapGrid.GetLength(0), CurrentWorld.MapGrid.GetLength(1));
            WriteLine();
            WriteLine("Current Level " + level);
            WriteLine("Can Shoot Laser " + CanShootLaser() + "  ");
            WriteLine("EnemyHP " + +CurrentEnemy.HP);
            SetCursorPosition(0, 0);
        }
        private void RunGameLoop()
        {
            WriteLine("Choose Amout Of Levels:");
            int ChooseLevel = int.Parse(ReadLine());
            CreateLevel(2);
            //SetWindowSize(CurrentWorld.MapGrid.GetLength(0)+5, CurrentWorld.MapGrid.GetLength(1)+5);
            //SetCursorPosition(0, 0);
            //SetBufferSize(CurrentWorld.MapGrid.GetLength(0)+15, CurrentWorld.MapGrid.GetLength(1)+15);
            while (true)
            {

                HUD();
                // Chack for player input from the keyboard and move the player
                HandleMovement();

                // Chacks If There is Laser And Player Took Treasure
                if (CurrentPlayer.X == CurrentTreasure.X && CurrentPlayer.Y == CurrentTreasure.Y)
                {
                    CurrentWorld.RemoveGameObject(CurrentTreasure);
                }
                if (CurrentWorld.HasGameObject(CurrentLaser) && !CurrentWorld.HasGameObject(CurrentTreasure))
                {

                    if (CurrentLaser.X == CurrentEnemy.X && CurrentLaser.Y == CurrentEnemy.Y)
                    {
                        Beep(297, 20);
                        CurrentWorld.RemoveGameObject(CurrentLaser);
                        CurrentEnemy.HP--;
                    }
                    if (CurrentEnemy.HP == 0)
                    {
                        Beep(297, 500);
                        CurrentWorld.RemoveGameObject(CurrentLaser);
                        CurrentWorld.RemoveGameObject(CurrentEnemy);
                    }
                    if (!CurrentWorld.HasGameObject(CurrentEnemy))
                    {
                        CurrentExit = new Exit(new int[,] { { 2, 2 }, { 25, 25 } });
                        CurrentWorld.AddGameObject(CurrentExit);
                        CurrentWorld.SpawnGameObject(CurrentExit);

                    }
                }

                // Draw Everything
                DrawFrame();

                // Check if the player has reached the exit or lost the game
                if (CurrentPlayer.X == CurrentExit?.X && CurrentPlayer.Y == CurrentExit?.Y)
                {
                    CreateLevel(level++);
                    CurrentEnemy.HP = 5 + level;
                    if (level == ChooseLevel)
                    {
                        DisplayOutro();
                        ReadKey(true);
                        break;
                    }

                }

                else if (CurrentWorld.HasGameObject(CurrentEnemy) && CurrentPlayer.X == CurrentEnemy.X && CurrentPlayer.Y == CurrentEnemy.Y || CurrentWorld.HasGameObject(CurrentTrap) && CurrentPlayer.X == CurrentTrap.X && CurrentPlayer.Y == CurrentTrap.Y)
                {
                    DisplayLoose();
                    break;
                }
                // Give the Console a chance to render.
                Thread.Sleep(20);

            }
        }
    }
}