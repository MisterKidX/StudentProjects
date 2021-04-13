using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_1
{
    class Player
    {
        private char playersymbol;
        public int width;
        public int length;
        public int score;
        public int health = 20;
        public Player()
        {
            playersymbol = '♥';
            width = 2;
            length = 1;
        }
        public int getWidth()
        {
            return width;
        }
        public int getlength()
        {
            return length;
        }
        public void setWidth(int w)
        {
            width = w;
        }
        public void setlength(int w)
        {
            length = w;
        }
        public char getplayersynbol()
        {
            return playersymbol;
        }
    }
}
