using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Laser : GameObject
    {
        public Player PlayerLayer;
        public Enemy Enemy;
        private World CurrentWorld;
        private Game CurrentGame;

        public Laser(int initialX, int initialY, Game CurrentGame, Player PlayerLayer, World CurrentWorld, Enemy CurrentEnemy) : base('*', ConsoleColor.Green, new int[,] { { } }, 1)
        {
            this.X = initialX;
            this.Y = initialY;
            this.PlayerLayer = PlayerLayer;
            this.CurrentWorld = CurrentWorld;
            Enemy = CurrentEnemy;
            this.CurrentGame = CurrentGame;
        }

        public void MoveLaser()
        {
            direction direction = direction.Other;
            if (Enemy.X != X)
            {
                direction = Enemy.X > X ? direction.Right : direction.Left;
            }
            CurrentWorld.MoveGameObject(this, direction);

            direction = direction.Other;
            if (Enemy.Y != Y)
            {
                direction = Enemy.Y > Y ? direction.Down : direction.Up;
            }
            //if (Enemy.X == X && Enemy.Y == Y)
            //{
            //    CurrentWorld.GameObjects.Remove(this);
            //    CurrentWorld.GameObjects.Remove(Enemy);
            //}
            CurrentWorld.MoveGameObject(this, direction);
        }
    }
}
