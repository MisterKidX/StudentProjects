using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_1
{
    class Treasure
    {
        public IslandGenerator island;
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
        public Treasure()
        {
            island = new IslandGenerator();
            Random rand = new Random();
            playersymbol = '#';
            TreasurePos();
            width1 = rand.Next(4, 22);
            length1 = rand.Next(6, 11);
            width2 = rand.Next(14, 33);
            length2 = rand.Next(10, 16);
            width3 = rand.Next(27, 44);
            length3 = rand.Next(6, 11);
            width4 = rand.Next(5, 14);
            length4 = rand.Next(2, 7);
        }
        public void TreasurePos()
        {
            bool flag = true;

            while (flag)
            {
                Random rand = new Random();
                width = rand.Next(10, 40);
                length = rand.Next(2, 17);

                if (!(island.rowStartIndex1 < width && width < island.rowMaxSize1) && !(island.colStartIndex1 < length && width < island.colMaxSize1))
                {
                    flag = false;
                }
            }
        }
        public int setWidth(int w)
        {
            width = w;
            return w;
        }
        public int setWidth1(int w)
        {
            width1 = w;
            return w;
        }
        public int setWidth2(int w)
        {
            width2 = w;
            return w;
        }
        public int setWidth3(int w)
        {
            width3 = w;
            return w;
        }
        public int setWidth4(int w)
        {
            width4 = w;
            return w;
        }
        public int setlength(int w)
        {
            length = w;
            return w;
        }
        public int setlength1(int w)
        {
            length1 = w;
            return w;
        }
        public int setlength2(int w)
        {
            length2 = w;
            return w;
        }
        public int setlength3(int w)
        {
            length3 = w;
            return w;
        }
        public int setlength4(int w)
        {
            length4 = w;
            return w;
        }
    }
}
