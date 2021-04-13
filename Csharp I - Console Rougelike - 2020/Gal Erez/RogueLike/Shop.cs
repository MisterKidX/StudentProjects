using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    class Shop
    {
        private static Shop _instance = null;
        public static Shop Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Shop(20, 80);
                }

                return _instance;
            }
        }

        Random rand = new Random();

        public string[,] ShopDimentions;

        public static int Rows;
        public static int Cols;


        public Shop(int width, int height)
        {
            Rows = width;
            Cols = height;

            ShopDimentions = new string[width, height];
        }

        public void ProduceShop()
        {
            for (Rows = 0; Rows < ShopDimentions.GetLength(0); Rows++)
            {
                for (Cols = 0; Cols < ShopDimentions.GetLength(1); Cols++)
                {
                    #region OutLine

                    ShopDimentions[Rows, Cols] = MapGenerator.Instance.Blank;

                    // build map top
                    ShopDimentions[0, Cols] = MapGenerator.Instance.HoriWall;

                    // build map Bottom
                    ShopDimentions[ShopDimentions.GetLength(0) - 1, Cols] = MapGenerator.Instance.HoriWall;

                    // build map left edge
                    ShopDimentions[Rows, 0] = MapGenerator.Instance.VertWall;

                    // build map right edge
                    ShopDimentions[Rows, ShopDimentions.GetLength(1) - 1] = MapGenerator.Instance.VertWall;

                    // build top left corner
                    ShopDimentions[0, 0] = MapGenerator.Instance.CornerTL;

                    // build top right corner
                    ShopDimentions[0, ShopDimentions.GetLength(1) - 1] = MapGenerator.Instance.CornerTR;

                    // build borrom left corner
                    ShopDimentions[ShopDimentions.GetLength(0) - 1, 0] = MapGenerator.Instance.CornerBL;

                    // build bottom left corner
                    ShopDimentions[ShopDimentions.GetLength(0) - 1, ShopDimentions.GetLength(1) - 1] = MapGenerator.Instance.CornerBR;

                    #endregion

                    ProduceShopKeeper();

                    Console.Write(ShopDimentions[Rows, Cols]);
                }

                Console.WriteLine();
            }
        }

        private void ProduceShopKeeper()
        {
            // Counter
            ProduceHorizontalWall(Rows, Cols, 0, 79, 14);

            // Body Left
            ProduceVerticalWall(Rows, Cols, 10, 14, 33);
            ShopDimentions[14, 33] = "┴";

            // Body Right
            ProduceVerticalWall(Rows, Cols, 10, 14, 47);
            ShopDimentions[14, 47] = "┴";

            // Hand left
            ProduceVerticalWall(Rows, Cols, 8, 13, 30);
            ProduceHorizontalWall(Rows, Cols, 30, 33, 13);
            ShopDimentions[13, 30] = MapGenerator.Instance.CornerBL;
            ShopDimentions[13, 33] = "┤";

            // Hand Right
            ProduceVerticalWall(Rows, Cols, 8, 13, 50);
            ProduceHorizontalWall(Rows, Cols, 47, 50, 13);
            ShopDimentions[13, 47] = "├";
            ShopDimentions[13, 50] = MapGenerator.Instance.CornerBR;

            // Shoulder Left
            ProduceHorizontalWall(Rows, Cols, 30, 37, 8);
            ShopDimentions[8, 30] = MapGenerator.Instance.CornerTL;
            ShopDimentions[8, 37] = MapGenerator.Instance.CornerBR;

            // Shoulder Right
            ProduceHorizontalWall(Rows, Cols, 43, 50, 8);
            ShopDimentions[8, 50] = MapGenerator.Instance.CornerTR;
            ShopDimentions[8, 43] = MapGenerator.Instance.CornerBL;

            // Hand left
            ProduceVerticalWall(Rows, Cols, 8, 13, 30);
            ProduceHorizontalWall(Rows, Cols, 30, 33, 13);
            ShopDimentions[13, 30] = MapGenerator.Instance.CornerBL;
            ShopDimentions[13, 33] = "┤";

            // Head Right
            ProduceHorizontalWall(Rows, Cols, 36, 44, 4);
            ProduceVerticalWall(Rows, Cols, 4, 7, 36);
            ProduceVerticalWall(Rows, Cols, 4, 7, 44);
            ShopDimentions[4, 36] = MapGenerator.Instance.CornerTL;
            ShopDimentions[7, 36] = MapGenerator.Instance.CornerBL;
            ShopDimentions[4, 44] = MapGenerator.Instance.CornerTR;
            ShopDimentions[7, 44] = MapGenerator.Instance.CornerBR;



        }

        private void ProduceGoods(int shopType)
        {
            switch (shopType)
            {
                case 0:
                    Weapons.Instance.ProduceWoodenSword();
                    Weapons.Instance.ProduceWoodenAxe();
                    Weapons.Instance.ProduceFireStaff();
                    Weapons.Instance.ProduceElectricWand();
                    break;

                case 1:
                    Weapons.Instance.ProduceStoneSword();
                    Weapons.Instance.ProduceStoneAxe();
                    Weapons.Instance.ProduceIceStaff();
                    Weapons.Instance.ProduceNatureWand();
                    break;

                case 2:
                    Weapons.Instance.ProduceIronSword();
                    Weapons.Instance.ProduceIronAxe();
                    Weapons.Instance.ProduceLightStaff();
                    Weapons.Instance.ProduceElectricWand();
                    break;

                case 3:
                    Weapons.Instance.ProduceSilverSword();
                    Weapons.Instance.ProduceFireAxe();
                    Weapons.Instance.ProduceDarkStaff();
                    Weapons.Instance.ProduceElectricWand();
                    break;

                case 4:
                    Weapons.Instance.ProduceAzureSword();
                    Weapons.Instance.ProduceMalachiteAxe();
                    Weapons.Instance.ProduceAmethystStaff();
                    Weapons.Instance.ProduceElectricWand();
                    break;

                default:
                    break;
            }
        }

        #region WallProduction

        // Produce Long Wall
        private void ProduceVerticalWall(int rows, int cols, int from, int to, int col)
        {
            if (rows > from && rows < to)
            {
                if (cols == col)
                {
                    ShopDimentions[rows, cols] = MapGenerator.Instance.VertWall;
                }
            }

        }

        // Produce Custom wall
        private void ProduceVerticalWall(int rows, int cols, int row, int col)
        {
            if (rows == row && cols == col)
            {
                ShopDimentions[rows, cols] = MapGenerator.Instance.VertWall;
            }
        }

        // Produce Long Wall
        private void ProduceHorizontalWall(int rows, int cols, int from, int to, int row)
        {
            if (cols > from && cols < to)
            {
                if (rows == row)
                {
                    ShopDimentions[rows, cols] = MapGenerator.Instance.HoriWall;
                }
            }
        }

        // Produce Custom wall
        private void ProduceHorizontalWall(int rows, int cols, int row, int col)
        {
            if (rows == row && cols == col)
            {
                ShopDimentions[rows, cols] = MapGenerator.Instance.HoriWall;
            }
        }

        private void BlankSpot(int row, int col)
        {
            ShopDimentions[row, col] = MapGenerator.Instance.Blank;
        }

        private void ProduceCornerTL(int row, int col)
        {
            ShopDimentions[row, col] = MapGenerator.Instance.CornerTL;
        }

        private void ProduceCornerTR(int row, int col)
        {
            ShopDimentions[row, col] = MapGenerator.Instance.CornerTR;
        }

        private void ProduceCornerBL(int row, int col)
        {
            ShopDimentions[row, col] = MapGenerator.Instance.CornerBL;
        }

        private void ProduceCornerBR(int row, int col)
        {
            ShopDimentions[row, col] = MapGenerator.Instance.CornerBR;
        }

        private void DoorwayTop(int row, int col)
        {
            ShopDimentions[row, col++] = MapGenerator.Instance.CornerBR;
            ShopDimentions[row, col++] = MapGenerator.Instance.Blank;
            ShopDimentions[row, col++] = MapGenerator.Instance.CornerBL;
        }

        private void DoorwayBot(int row, int col)
        {
            ShopDimentions[row, col++] = MapGenerator.Instance.CornerTR;
            ShopDimentions[row, col++] = MapGenerator.Instance.Blank;
            ShopDimentions[row, col++] = MapGenerator.Instance.CornerTL;
        }

        private void DoorwayLeft(int row, int col)
        {
            ShopDimentions[row++, col] = MapGenerator.Instance.CornerBR;
            ShopDimentions[row++, col] = MapGenerator.Instance.Blank;
            ShopDimentions[row++, col] = MapGenerator.Instance.CornerTR;
        }

        private void DoorwayRight(int row, int col)
        {
            ShopDimentions[row++, col] = MapGenerator.Instance.CornerBL;
            ShopDimentions[row++, col] = MapGenerator.Instance.Blank;
            ShopDimentions[row++, col] = MapGenerator.Instance.CornerTL;
        }

        private void CustomVerticalDoorway(int row, int col, string firstShape, string secondShape)
        {
            ShopDimentions[row++, col] = firstShape;
            ShopDimentions[row++, col] = MapGenerator.Instance.Blank;
            ShopDimentions[row++, col] = secondShape;
        }

        private void CustomHorizontalDoorway(int row, int col, string firstShape, string secondShape)
        {
            ShopDimentions[row, col++] = firstShape;
            ShopDimentions[row, col++] = MapGenerator.Instance.Blank;
            ShopDimentions[row, col++] = secondShape;
        }

        #endregion
    }
}
