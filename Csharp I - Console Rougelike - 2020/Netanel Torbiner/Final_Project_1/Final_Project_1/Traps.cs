using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_1
{
    class Traps
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
        public int width6;
        public int length6;
        public int width7;
        public int length7;
        public int width8;
        public int length8;
        public int width9;
        public int length9;
        public Traps()
        {
            Random rand = new Random();
            playersymbol = '!';
            width = rand.Next(8, 38);
            length = rand.Next(4, 16);
            width1 = rand.Next(5, 31);
            length1 = rand.Next(2, 17);
            width2 = rand.Next(11, 33);
            length2 = rand.Next(4, 11);
            width3 = rand.Next(10, 46);
            length3 = rand.Next(6, 10);
            width4 = rand.Next(12, 18);
            length4 = rand.Next(5, 14);
            width5 = rand.Next(8, 43);
            length5 = rand.Next(2, 10);
            width6 = rand.Next(9, 30);
            length6 = rand.Next(2, 8);
            width7 = rand.Next(20, 34);
            length7 = rand.Next(8, 12);
            width8 = rand.Next(11, 27);
            length8 = rand.Next(4, 15);
            width9 = rand.Next(6, 33);
            length9 = rand.Next(7, 16);
        }
        public void setWidth(int w)
        {
            width = w;
        }
        public void setWidth1(int w)
        {
                width1 = w;
        }
        public void setWidth2(int w)
        {
            width2 = w;
        }
        public void setWidth3(int w)
        {
            width3 = w;
        }
        public void setWidth4(int w)
        {
            width4 = w;
        }
        public void setWidth5(int w)
        {
            width5 = w;
        }
        public void setWidth6(int w)
        {
            width6 = w;
        }
        public void setWidth7(int w)
        {
            width7 = w;
        }
        public void setWidth8(int w)
        {
            width8 = w;
        }
        public void setWidth9(int w)
        {
            width9 = w;
        }
        public void setlength(int w)
        {
            length = w;
        }
        public void setlength1(int w)
        {
            length1 = w;
        }
        public void setlength2(int w)
        {
            length2 = w;
        }
        public void setlength3(int w)
        {
            length3 = w;
        }
        public void setlength4(int w)
        {
            length4 = w;
        }
        public void setlength5(int w)
        {
            length5 = w;
        }
        public void setlength6(int w)
        {
            length6 = w;
        }
        public void setlength7(int w)
        {
            length7 = w;
        }
        public void setlength8(int w)
        {
            length8 = w;
        }
        public void setlength9(int w)
        {
            length9 = w;
        }
    }
}
