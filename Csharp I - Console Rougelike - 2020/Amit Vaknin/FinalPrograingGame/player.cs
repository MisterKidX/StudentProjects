using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;


namespace FinalPrograingGame
{
    class player
    {
        public int X;
        public int Y;
        public bool traptrigger = false;
        public int trapx = 37;
        public int trapy = 14;
        public int startx = 1;
        public int starty = 11;
        public int baseHp = 100;
        public int enemydmg = 10;
        public int coins = 0;
        private static player playerInstance = null;
        public static player getplayerInstance
        {
            get
            {
                if (playerInstance == null)
                {
                    playerInstance = new player();
                }
                return playerInstance;
            }
        }
    }
}




