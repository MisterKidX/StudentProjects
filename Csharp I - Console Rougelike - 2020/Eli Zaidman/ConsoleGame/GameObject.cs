using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class GameObject
    {
        public enum direction
        {
            Down,
            Up,
            Left,
            Right,
            Other
        }

        public int X { get; set; }
        public int Y { get; set; }
        public char Icon { get; private set; }
        public ConsoleColor Color { get; private set; }
        public int[,] SpawnZone { get; private set; }

        public int HP { get; set; }

        public GameObject(char Icon, ConsoleColor Color, int[,] SpawnZone, int HP)
        {
            this.Icon = Icon;
            this.Color = Color;
            this.SpawnZone = SpawnZone;
            this.HP = HP;
        }
        //public void SetPosition(int X, int Y)
        //{
        //    if (X > 0)
        //    {
        //        this.X = X;
        //    }
        //    if (Y > 0)
        //    {
        //        this.Y = Y;
        //    }
        //}

    }
}
