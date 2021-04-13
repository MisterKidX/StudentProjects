using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_1
{
    class Enemy
    {
        public char playersymbol;
        public int width;
        public int length;
        public int width1;
        public int length1;
        public int width2;
        public int length2;
        public int width3;
        public int length3;
        public int width4;
        public int length4;
        public int width5;
        public int length5;
        public int damage;
        public int MonsterDamage;
        public Enemy()
        {
            Random rand = new Random();
            playersymbol = 'M';
            width = rand.Next(4, 38);
            length = rand.Next(3, 7);
            width1 = rand.Next(11, 37);
            length1 = rand.Next(5, 10);
            width2 = rand.Next(6, 41);
            length2 = rand.Next(7, 11);
            width3 = rand.Next(12, 35);
            length3 = rand.Next(7, 15);
            width4 = rand.Next(14, 32);
            length4 = rand.Next(5, 11);
            width5 = rand.Next(10, 24);
            length5 = rand.Next(6, 14);
        }
        public void setWidth(int w)
        {
            width = w;
        }
        public void setlength(int w)
        {
            length = w;
        }
        public void setWidth1(int w)
        {
            width1 = w;
        }
        public void setlength1(int w)
        {
            length1 = w;
        }
        public void setWidth2(int w)
        {
            width2 = w;
        }
        public void setlength2(int w)
        {
            length2 = w;
        }
        public void setWidth3(int w)
        {
            width3 = w;
        }
        public void setlength3(int w)
        {
            length3 = w;
        }
        public void setWidth4(int w)
        {
            width4 = w;
        }
        public void setlength4(int w)
        {
            length4 = w;
        }
        public void setWidth5(int w)
        {
            width5 = w;
        }
        public void setlength5(int w)
        {
            length5 = w;
        }
    }
}

