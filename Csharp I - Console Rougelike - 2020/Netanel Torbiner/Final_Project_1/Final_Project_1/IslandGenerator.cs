using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_1
{
    class IslandGenerator
    {
        public char[,] island1;
        public char[,] island2;
        public char[,] island3;
        public int rowStartIndex1;
        public int rowStartIndex2;
        public int rowStartIndex3;
        public int colStartIndex1;
        public int colStartIndex2;
        public int colStartIndex3;
        public int rowMaxSize1;
        public int rowMaxSize2;
        public int colMaxSize1;
        public int colMaxSize2;
        public int rowSum;
        public int colSum;
        public int rowSum1;
        public int colSum1;
        public int rowSum2;
        public int colSum2;

        public IslandGenerator()
        {
            Random rand = new Random();
            rowStartIndex1 = rand.Next(11, 15);
            rowStartIndex2 = rand.Next(5, 12);
            rowStartIndex3 = rand.Next(8, 10);
            colStartIndex1 = rand.Next(10, 14);
            colStartIndex2 = rand.Next(32, 37);
            colStartIndex3 = rand.Next(19, 26);
            rowMaxSize1 = rand.Next(3, 6);
            colMaxSize1 = rand.Next(5, 10);
            rowMaxSize2 = rand.Next(4, 7);
            colMaxSize2 = rand.Next(3, 8);
            island1 = new char[rowStartIndex1 + rowMaxSize1, colStartIndex1 + colMaxSize1];
            island2 = new char[rowStartIndex2 + rowMaxSize2, colStartIndex2 + colMaxSize2];
            island3 = new char[rowStartIndex3 + rowMaxSize1, colStartIndex3 + colMaxSize1];
            GeneratIsland();
            GeneratIsland1();
            GeneratIsland2();
        }
        public void GeneratIsland()
        {
            rowSum = rowStartIndex1 + rowMaxSize1;
            colSum = colStartIndex1 + colMaxSize1;

            for (int i = rowStartIndex1; i < rowSum; i++)
            {
                for (int j = colStartIndex1; j < colSum; j++)
                {
                    island1[rowStartIndex1, j] = '*';
                    island1[i, colStartIndex1] = '*';
                    island1[i, colSum - 1] = '*';
                    island1[rowSum - 1, j] = '*';
                }
            }
        }
        public void GeneratIsland1()
        {
            rowSum1 = rowStartIndex2 + rowMaxSize2;
            colSum1 = colStartIndex2 + colMaxSize2;

            for (int i = rowStartIndex2; i < rowSum1; i++)
            {
                for (int j = colStartIndex2; j < colSum1; j++)
                {
                    island2[rowStartIndex2, j] = '*';
                    island2[i, colStartIndex2] = '*';
                    island2[i, colSum1 - 1] = '*';
                    island2[rowSum1 - 1, j] = '*';
                }
            }
        }
        public void GeneratIsland2()
        {
            rowSum2 = rowStartIndex3 + rowMaxSize1;
            colSum2 = colStartIndex3 + colMaxSize1;

            for (int i = rowStartIndex3; i < rowSum2; i++)
            {
                for (int j = colStartIndex3; j < colSum2; j++)
                {
                    island3[rowStartIndex3, j] = '*';
                    island3[i, colStartIndex3] = '*';
                    island3[i, colSum2 - 1] = '*';
                    island3[rowSum2 - 1, j] = '*';
                }
            }
        }

 
    }
}
