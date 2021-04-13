using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoughLite
{
    class Enemy
    {
        
        public int HP { get; set; }
        public int Armor { get; set; }
        public int Power { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        private string _enemyMarker;
        
        private ConsoleColor _enemyColor;
        
        private Random _r = new Random();
      
        public Enemy(int startingX, int startingY, int level)
        {
            
            X = startingX;
            Y = startingY;
            HP = 1; 
            Armor = _r.Next(2, level / 2 + 6);
            Power = _r.Next(2, level / 2 + 6);
            _enemyMarker = "¤";
            _enemyColor = ConsoleColor.DarkRed;
        }
        public void DrawEnemy()
        {
           Console.ForegroundColor = _enemyColor;
           Console.SetCursorPosition(X, Y);
           Console.Write(_enemyMarker);
           Console.ResetColor();
        }
    }
}
