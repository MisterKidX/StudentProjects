using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject101_RonBandel
{
    class ConstructWalls
    {
        public static ConstructWalls instance;
        public ConstructWalls()
        {

        }

        public static ConstructWalls Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConstructWalls();
                }
                return instance;
            }
        }

        public void MapBossWalls()
        {
            Map.BuildVerticalWall(6, 5, 4);
            Map.BuildHorizontalWall(7, 5, 4);
            
            Map.BuildVerticalWall(6, 13, 4);
            Map.BuildHorizontalWall(38, 5, 4);
            
            Map.BuildVerticalWall(37, 5, 4);
            Map.BuildHorizontalWall(33, 8, 4);
            
            Map.BuildVerticalWall(37, 13, 4);
            Map.BuildHorizontalWall(33, 16, 4);
        }

        public void Map2Walls()
        {
            Map.BuildHorizontalWall(1, 13, 7);
            Map.BuildVerticalWall(7, 14, 5);
            
            Map.BuildVerticalWall(5, 2, 7);
            Map.BuildHorizontalWall(6, 4, 12);
            Map.BuildVerticalWall(14, 5, 9);
            Map.BuildHorizontalWall(15, 8, 8);
            
            Map.BuildVerticalWall(27, 4, 7);
            Map.BuildHorizontalWall(28, 8, 11);
            Map.BuildVerticalWall(33, 9, 5);
            Map.BuildVerticalWall(38, 9, 5);
        }

        public void Map3Walls()
        {
            Map.BuildHorizontalWall(1, 15, 2);
            Map.BuildHorizontalWall(5, 15, 9);
            Map.BuildHorizontalWall(15, 15, 1);
            Map.BuildVerticalWall(14, 15, 6);
            Map.BuildHorizontalWall(15, 16, 1);
            Map.BuildVerticalWall(16, 15, 2);
            Map.BuildHorizontalWall(15, 17, 18);

            Map.BuildVerticalWall(5, 3, 10);
            Map.BuildHorizontalWall(6, 5, 14);
            Map.BuildHorizontalWall(17, 8, 9);
            Map.BuildVerticalWall(11, 7, 4);
            Map.BuildHorizontalWall(6, 10, 5);
            Map.BuildHorizontalWall(6, 12, 21);

            Map.BuildVerticalWall(26, 1, 8);
            Map.BuildHorizontalWall(27, 7, 6);
            Map.BuildHorizontalWall(36, 4, 7);
            Map.BuildVerticalWall(39, 5, 5);

            Map.BuildVerticalWall(32, 10, 4);
            Map.BuildHorizontalWall(33, 11, 7);
            Map.BuildVerticalWall(27, 12, 3);
            Map.BuildHorizontalWall(28, 14, 15);
            Map.BuildVerticalWall(37, 15, 4);
        }

        public void Map4Walls()
        {
            Map.BuildHorizontalWall(7, 3, 9);
            Map.BuildVerticalWall(7, 4, 5);

            Map.BuildHorizontalWall(28, 3, 9);
            Map.BuildVerticalWall(36, 4, 5);

            Map.BuildHorizontalWall(7, 18, 9);
            Map.BuildVerticalWall(7, 13, 5);

            Map.BuildHorizontalWall(28, 18, 9);
            Map.BuildVerticalWall(36, 13, 5);

        }

        public void Map5Walls()
        {
            Map.BuildHorizontalWall(1, 8, 6);
            Map.BuildVerticalWall(7, 8, 4);

            Map.BuildHorizontalWall(1, 14, 8);
            Map.BuildVerticalWall(9, 14, 3);
            Map.BuildVerticalWall(9, 19, 2);

            Map.BuildHorizontalWall(16, 3, 9);
            Map.BuildVerticalWall(25, 3, 7);
            Map.BuildHorizontalWall(26, 3, 13);
            Map.BuildVerticalWall(39, 3, 7);

            Map.BuildHorizontalWall(16, 7, 3);
            Map.BuildHorizontalWall(21, 7, 4);
            Map.BuildVerticalWall(15, 7, 6);
            Map.BuildVerticalWall(24, 8, 5);
            Map.BuildHorizontalWall(16, 12, 8);

            Map.BuildHorizontalWall(28, 15, 12);
            Map.BuildVerticalWall(28, 16, 3);
            Map.BuildVerticalWall(39, 16, 5);
        }

        public void Map6Walls()
        {
            Map.BuildVerticalWall(6, 1, 7);
            Map.BuildVerticalWall(6, 14, 7);

            Map.BuildVerticalWall(13, 6, 10);
            Map.BuildHorizontalWall(14, 6, 12);
            Map.BuildHorizontalWall(14, 15, 12);

            Map.BuildVerticalWall(34, 1, 7);
            Map.BuildHorizontalWall(35, 7, 3);

            Map.BuildVerticalWall(34, 14, 7);
            Map.BuildHorizontalWall(35, 14, 3);
        }

        public void Map7Walls()
        {
            Map.BuildVerticalWall(6, 3, 16);
            Map.BuildHorizontalWall(7, 3, 36);
            Map.BuildHorizontalWall(7, 18, 31);

            Map.BuildVerticalWall(38, 6, 13);
            Map.BuildVerticalWall(33, 9, 7);

            Map.BuildVerticalWall(11, 6, 10);
            Map.BuildHorizontalWall(12, 6, 26);
            Map.BuildHorizontalWall(16, 9, 17);
            Map.BuildHorizontalWall(12, 15, 21);
        }

        public void Map8Walls()
        {
            Map.BuildHorizontalWall(5, 3, 34);
            Map.BuildVerticalWall(7, 6, 10);
            Map.BuildHorizontalWall(10, 8, 24);
            Map.BuildVerticalWall(12, 10, 2);
            Map.BuildVerticalWall(31, 10, 2);
            Map.BuildHorizontalWall(10, 13, 24);
            Map.BuildVerticalWall(36, 6, 10);
            Map.BuildHorizontalWall(5, 18, 34);
        }

        public void Map9Walls()
        {
            int houseWallCordsX = 8;
            int houseWallCordsY = 1;
            //  Rooms VerticalWalls
            for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                {
                    houseWallCordsX = 8;
                    houseWallCordsY = 17;
                }
                Map.BuildVerticalWall(houseWallCordsX, houseWallCordsY, 4);
                if ( i != 4)
                {
                    houseWallCordsX += 8;
                }
            }

            houseWallCordsX = 1;
            houseWallCordsY = 4;
            //  Rooms HorizontalWalls
            for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                {
                    houseWallCordsX = 1;
                    houseWallCordsY = 17;
                }
                Map.BuildHorizontalWall(houseWallCordsX, houseWallCordsY, 3);
                Map.BuildHorizontalWall(houseWallCordsX+5, houseWallCordsY, 2);
                if (i != 4)
                {
                    houseWallCordsX += 8;
                }
            }

            //  Center
            Map.BuildVerticalWall(11, 8, 6);
            Map.BuildVerticalWall(12, 8, 6);
            Map.BuildVerticalWall(13, 8, 6);
            Map.BuildVerticalWall(21, 8, 6);
            Map.BuildVerticalWall(22, 8, 6);
            Map.BuildVerticalWall(23, 8, 6);
            Map.BuildHorizontalWall(12, 8, 11);
            Map.BuildHorizontalWall(12, 9, 11);
            Map.BuildHorizontalWall(14, 10, 7);
            Map.BuildHorizontalWall(14, 11, 7);
            Map.BuildHorizontalWall(12, 12, 11);
            Map.BuildHorizontalWall(12, 13, 11);

            Map.BuildVerticalWall(17, 8, 6);
        }
    }
}