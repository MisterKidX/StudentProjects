using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_1
{
    class SupriseQ
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

        public SupriseQ()
        {
            Random rand = new Random();
            playersymbol = '?';
            width = rand.Next(7, 21);
            length = rand.Next(5, 8);
            width1 = rand.Next(6, 34);
            length1 = rand.Next(2, 7);
            width2 = rand.Next(8, 29);
            length2 = rand.Next(4, 9);
            width3 = rand.Next(10, 20);
            length3 = rand.Next(5, 14);
            width4 = rand.Next(21, 44);
            length4 = rand.Next(4, 13);
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
    }
}
