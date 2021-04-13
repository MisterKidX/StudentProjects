using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleGame
{
    class Enemy : GameObject
    {
        private Player Target;
        private World Map;
        public Enemy(Player Target, World Map, int[,] SpawnZone) : base('E', ConsoleColor.Yellow, SpawnZone, 5)
        {
            this.Target = Target;
            this.Map = Map;
        }

        //public void EnemyDraw()
        //{
        //    ForegroundColor = EnemyColor;
        //    SetCursorPosition(X, Y);
        //    Write(EnemyMarker);
        //    ResetColor();
        //}

        public void EnemyMoveToTarget()
        {
            Random rand = new Random();
            direction direction = direction.Other;
            if (rand.Next(0, 101) > 40 && Target.X != X)
            {
                direction = Target.X > X ? direction.Right : direction.Left;
            }
            Map.MoveGameObject(this, direction);

            direction = direction.Other;
            if (rand.Next(0, 101) > 30 && Target.Y != Y)
            {
                direction = Target.Y > Y ? direction.Down : direction.Up;
            }
            Map.MoveGameObject(this, direction);
        }
    }
}
