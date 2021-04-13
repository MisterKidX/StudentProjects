using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    class MapGenerator
    {
        private static MapGenerator _instance = null;
        public static MapGenerator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MapGenerator(20, 80);
                }

                return _instance;
            }
        }

        public string[,] Map;

        public static int Rows;
        public static int Cols;

        public string Blank = " ";
        public string HoriWall = "─";
        public string VertWall = "│";
        public string CornerTL = "┌";
        public string CornerTR = "┐";
        public string CornerBL = "└";
        public string CornerBR = "┘";
        public string Entrance = "≤";
        public string Exit = "≥";

        public MapGenerator(int width, int height)
        {
            Rows = width;
            Cols = height;

            Map = new string[width, height];
        }

        public void SetLvl(int lvl)
        {
            switch (lvl)
            {
                case 1:
                    Level1();
                    break;

                case 2:
                    Level2();
                    break;

                case 3:
                    Level3();
                    break;

                case 4:
                    Level4();
                    break;

                case 5:
                    Level8();
                    //Level5();
                    break;

                case 6:
                    Level9();
                    //Level6();
                    break;

                case 7:
                    Level10();
                    //Level7();
                    break;

                case 8:
                    Finish();
                    //Level8();
                    break;

                case 9:
                    //Level9();
                    break;

                case 10:
                    //Level10();
                    break;

                case 11:
                    //Finish();
                    break;

                default:
                    Level1();
                    break;
            }
        }

        public void Level1()
        {
            for (Rows = 0; Rows < Map.GetLength(0); Rows++)
            {
                for (Cols = 0; Cols < Map.GetLength(1); Cols++)
                {
                    #region OutLine
                    Map[Rows, Cols] = Blank;

                    // build map top
                    Map[0, Cols] = HoriWall;

                    // build map Bottom
                    Map[Map.GetLength(0) - 1, Cols] = HoriWall;

                    // build map left edge
                    Map[Rows, 0] = VertWall;

                    // build map right edge
                    Map[Rows, Map.GetLength(1) - 1] = VertWall;

                    // build top left corner
                    Map[0, 0] = CornerTL;

                    // build top right corner
                    Map[0, Map.GetLength(1) - 1] = CornerTR;

                    // build borrom left corner
                    Map[Map.GetLength(0) - 1, 0] = CornerBL;

                    // build bottom left corner
                    Map[Map.GetLength(0) - 1, Map.GetLength(1) - 1] = CornerBR;

                    #endregion

                    #region Rooms

                    #region Room 1-1

                    // print corners
                    ProduceCornerTL(1, 2);
                    ProduceCornerTR(1, 18);
                    ProduceCornerBL(6, 2);
                    ProduceCornerBR(6, 18);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 2, 18, 1);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 2, 18, 6);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 1, 6, 2);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 1, 6, 18);

                    #endregion

                    #region Room 1-2
                    // print corners
                    ProduceCornerTL(12, 30);
                    ProduceCornerTR(12, 46);
                    ProduceCornerBL(18, 30);
                    ProduceCornerBR(18, 46);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 30, 46, 12);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 30, 46, 18);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 12, 18, 30);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 12, 18, 46);

                    #endregion

                    #region Room 1-3
                    // print corners
                    ProduceCornerTL(2, 50);
                    ProduceCornerTR(2, 72);
                    ProduceCornerBL(9, 50);
                    ProduceCornerBR(9, 72);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 50, 72, 2);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 50, 72, 9);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 2, 9, 50);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 2, 9, 72);

                    #endregion

                    #endregion

                    #region Roads

                    #region Road A

                    // Road A Left Entry to Room 1-1
                    ProduceVerticalWall(Rows, Cols, 6, 19, 5);

                    // Road A Right Entry to Room 1-1
                    ProduceVerticalWall(Rows, Cols, 6, 19, 7);

                    #endregion

                    #region Road B

                    // Road B Top Entry to Room 1-2
                    ProduceHorizontalWall(Rows, Cols, 7, 30, 13);

                    // Road B Bottom Entry to Room 1-2
                    ProduceHorizontalWall(Rows, Cols, 7, 30, 15);

                    #endregion

                    #region Road C

                    //Road C Coreners
                    ProduceCornerTL(5, 20);
                    ProduceCornerTL(7, 22);

                    // Road C Left
                    ProduceVerticalWall(Rows, Cols, 5, 13, 20);

                    // Road C Right
                    ProduceVerticalWall(Rows, Cols, 7, 13, 22);

                    // Road C Top
                    ProduceHorizontalWall(Rows, Cols, 20, 50, 5);

                    // Road C Down
                    ProduceHorizontalWall(Rows, Cols, 22, 50, 7);

                    #endregion

                    #region Road D

                    //Road D Corners
                    ProduceCornerBR(15, 60);
                    ProduceCornerBR(17, 62);

                    // Road Left
                    ProduceVerticalWall(Rows, Cols, 9, 15, 60);

                    // Road Right
                    ProduceVerticalWall(Rows, Cols, 9, 17, 62);

                    // Road Top
                    ProduceHorizontalWall(Rows, Cols, 46, 60, 15);

                    // Road Bot
                    ProduceHorizontalWall(Rows, Cols, 46, 62, 17);

                    #endregion

                    #region Road Out

                    // Road D Left
                    ProduceVerticalWall(Rows, Cols, 9, 19, 68);

                    // Road D Right
                    ProduceVerticalWall(Rows, Cols, 9, 19, 70);

                    #endregion

                    #region Crossroads

                    // Crossroads A-B
                    DoorwayRight(13, 7);

                    // Crossroads B-C
                    DoorwayTop(13, 20);

                    #endregion

                    #endregion

                    #region Doorways

                    // Level Entrance Doorway
                    DoorwayTop(19, 5);

                    // Room 1-1 Bot Doorway
                    DoorwayBot(6, 5);

                    // Room 1-2 Left Doorway
                    DoorwayLeft(13, 30);

                    // Room 1-2 Right Doorway
                    DoorwayRight(15, 46);

                    // Room 1-3 Left Doorway
                    DoorwayLeft(5, 50);

                    // Room 1-3 Bot Doorway
                    DoorwayBot(9, 60);

                    // Room 1-3 Bor Doorway Out
                    DoorwayBot(9, 68);

                    // Level Exit Doorway
                    DoorwayTop(19, 68);

                    #endregion

                    Console.Write(Map[Rows, Cols]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ClearCash();

            Gold gold1Room1 = new Gold(17, 2);
            Enemy enemy1Room1 = new Enemy(14, 3, 1);

            Gold gold1Room2 = new Gold(42, 14);
            Enemy enemy1Room2 = new Enemy(39, 17, 1);

            Gold gold1Room3 = new Gold(69, 3);
            Gold gold2Room3 = new Gold(71, 3);
            Enemy boss1Room3 = new Enemy(70, 4, "Water");

            PotionStore store1 = new PotionStore(21, 6);
            EntranceAndExit Exit1 = new EntranceAndExit(6, 19, 69, 19);

            System.Threading.Thread.Sleep(10);
            Dialog.Instance.Legend();
            Player.Instance.ProducePlayer(6, 18);
        }

        public void Level2()
        {
            for (Rows = 0; Rows < Map.GetLength(0); Rows++)
            {
                for (Cols = 0; Cols < Map.GetLength(1); Cols++)
                {
                    #region OutLine
                    Map[Rows, Cols] = Blank;

                    // build map top
                    Map[0, Cols] = HoriWall;

                    // build map Bottom
                    Map[Map.GetLength(0) - 1, Cols] = HoriWall;

                    // build map left edge
                    Map[Rows, 0] = VertWall;

                    // build map right edge
                    Map[Rows, Map.GetLength(1) - 1] = VertWall;

                    // build top left corner
                    Map[0, 0] = CornerTL;

                    // build top right corner
                    Map[0, Map.GetLength(1) - 1] = CornerTR;

                    // build borrom left corner
                    Map[Map.GetLength(0) - 1, 0] = CornerBL;

                    // build bottom left corner
                    Map[Map.GetLength(0) - 1, Map.GetLength(1) - 1] = CornerBR;

                    #endregion

                    #region Rooms

                    #region Room 2-1

                    // print corners
                    ProduceCornerTL(12, 2);
                    ProduceCornerTR(12, 18);
                    ProduceCornerBL(18, 2);
                    ProduceCornerBR(18, 18);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 2, 18, 12);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 2, 18, 18);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 12, 18, 2);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 12, 18, 18);

                    #endregion

                    #region Room 2-2
                    // print corners
                    ProduceCornerTL(6, 20);
                    ProduceCornerTR(6, 36);
                    ProduceCornerBL(11, 20);
                    ProduceCornerBR(11, 36);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 20, 36, 6);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 20, 36, 11);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 6, 11, 20);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 6, 11, 36);

                    #endregion

                    #region Room 2-3
                    // print corners
                    ProduceCornerTL(6, 37);
                    ProduceCornerTR(6, 53);
                    ProduceCornerBL(11, 37);
                    ProduceCornerBR(11, 53);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 37, 53, 6);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 37, 53, 11);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 6, 11, 37);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 6, 11, 53);

                    #endregion

                    #region Room 2-4
                    // print corners
                    ProduceCornerTL(6, 54);
                    ProduceCornerTR(6, 69);
                    ProduceCornerBL(11, 54);
                    ProduceCornerBR(11, 69);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 54, 69, 6);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 54, 69, 11);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 6, 11, 54);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 6, 11, 69);

                    #endregion

                    #endregion
                    
                    #region Roads
                    
                    #region Road A

                    // Road A Left Entry to Room 2-2
                    ProduceVerticalWall(Rows, Cols, 1, 12, 5);

                    // Road A Right Entry to Room 2-2
                    ProduceVerticalWall(Rows, Cols, 3, 12, 7);

                    // Road A Top
                    ProduceHorizontalWall(Rows, Cols, 5, 77, 1);

                    // Road A Down
                    ProduceHorizontalWall(Rows, Cols, 7, 75, 3);

                    // Road A Left to Exit
                    ProduceVerticalWall(Rows, Cols, 3, 19, 75);

                    // Road A Right to Exit
                    ProduceVerticalWall(Rows, Cols, 1, 19, 77);

                    //Road A Coreners
                    ProduceCornerTL(1, 5);
                    ProduceCornerTL(3, 7);

                    ProduceCornerTR(1, 77);
                    ProduceCornerTR(3, 75);

                    #endregion
                  
                    #region Road B

                    //Road A  to Room 2-2
                    ProduceVerticalWall(Rows, Cols, 3, 6, 27);

                    //Road A  to Room 2-2
                    ProduceVerticalWall(Rows, Cols, 3, 6, 29);

                    #endregion

                    #region Road C

                    //Road A  to Room 2-4
                    ProduceVerticalWall(Rows, Cols, 3, 6, 61);

                    //Road A  to Room 2-4
                    ProduceVerticalWall(Rows, Cols, 3, 6, 63);

                    #endregion

                    #region Road Block

                    //Road A  Block
                    Map[2, 29] = VertWall;

                    //Road A  Block
                    Map[2, 61] = VertWall;

                    #endregion

                    #endregion

                    #region Doorways

                    // Room 2-1 Top Doorway
                    DoorwayTop(12, 5);

                    // Room 2-2 Top Doorway
                    DoorwayTop(6, 27);

                    // Room 2-2 Bot Doorway
                    DoorwayBot(3, 27);

                    // Room 2-2 Right Doorway
                    DoorwayRight(8, 36);

                    // Room 2-3 Left Doorway
                    DoorwayLeft(8, 37);

                    // Room 2-3 Right Doorway
                    DoorwayRight(7, 53);

                    // Room 2-4 Top Doorway
                    DoorwayTop(6, 61);

                    // Room 2-4 Bot Doorway
                    DoorwayBot(3, 61);

                    // Room 2-4 Left Doorway
                    DoorwayLeft(7, 54);


                    // Lvl Exit
                    DoorwayTop(19, 75);

                    #endregion

                    Console.Write(Map[Rows, Cols]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ClearCash();

            Gold gold1Room2 = new Gold(23, 10);
            Enemy enemy1Room2 = new Enemy(21, 7, 1);
            RewardChest rC1Room2 = new RewardChest(21, 10);

            Enemy enemy2Room3 = new Enemy(39, 7, 1);
            Enemy enemy4Room3 = new Enemy(52, 10, 1);
            TrapChest tC2Room3 = new TrapChest(45, 10);

            Enemy enemy5Room4 = new Enemy(55, 9, 1);
            Enemy enemy6Room4 = new Enemy(67, 8, 1);
            RewardChest rC2Room4 = new RewardChest(68, 10);

            PotionStore store2 = new PotionStore(6, 2);
            EntranceAndExit Exit2 = new EntranceAndExit(3, 17, 76, 19);
            System.Threading.Thread.Sleep(10);
            Dialog.Instance.Legend();

            Player.Instance.ProducePlayer(5, 17);
        }

        public void Level3()
        {
            for (Rows = 0; Rows < Map.GetLength(0); Rows++)
            {
                for (Cols = 0; Cols < Map.GetLength(1); Cols++)
                {
                    #region OutLine
                    Map[Rows, Cols] = Blank;

                    // build map top
                    Map[0, Cols] = HoriWall;

                    // build map Bottom
                    Map[Map.GetLength(0) - 1, Cols] = HoriWall;

                    // build map left edge
                    Map[Rows, 0] = VertWall;

                    // build map right edge
                    Map[Rows, Map.GetLength(1) - 1] = VertWall;

                    // build top left corner
                    Map[0, 0] = CornerTL;

                    // build top right corner
                    Map[0, Map.GetLength(1) - 1] = CornerTR;

                    // build borrom left corner
                    Map[Map.GetLength(0) - 1, 0] = CornerBL;

                    // build bottom left corner
                    Map[Map.GetLength(0) - 1, Map.GetLength(1) - 1] = CornerBR;

                    #endregion

                    #region Rooms

                    #region Room 3-1

                    // print corners
                    ProduceCornerTL(13, 2);
                    ProduceCornerTR(13, 18);
                    ProduceCornerBL(18, 2);
                    ProduceCornerBR(18, 18);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 2, 18, 13);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 2, 18, 18);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 13, 18, 2);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 13, 18, 18);

                    #endregion

                    #region Room 3-2
                    // print corners
                    ProduceCornerTL(7, 2);
                    ProduceCornerTR(7, 18);
                    ProduceCornerBL(12, 2);
                    ProduceCornerBR(12, 18);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 2, 18, 7);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 2, 18, 12);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 7, 12, 2);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 7, 12, 18);

                    #endregion

                    #region Room 3-3
                    // print corners
                    ProduceCornerTL(8, 40);
                    ProduceCornerTR(8, 56);
                    ProduceCornerBL(15, 40);
                    ProduceCornerBR(15, 56);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 40, 56, 8);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 40, 56, 15);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 8, 15, 40);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 8, 15, 56);

                    #endregion

                    #endregion

                    #region Roads

                    #region Road A

                    // Road A Left Entry to Room 3-2
                    ProduceVerticalWall(Rows, Cols, 11, 13, 3);

                    // Road A Right Entry to Room 3-2
                    ProduceVerticalWall(Rows, Cols, 11, 13, 5);

                    #endregion


                    #region Road B

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 1, 7, 7);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 2, 7, 9);

                    // Road B Top
                    ProduceHorizontalWall(Rows, Cols, 7, 32, 1);

                    // Road B Down
                    ProduceHorizontalWall(Rows, Cols, 9, 30, 3);

                    // Road B Left down
                    ProduceVerticalWall(Rows, Cols, 3, 7, 30);

                    // Road B Right down
                    ProduceVerticalWall(Rows, Cols, 1, 5, 32);

                    // Road B Top
                    ProduceHorizontalWall(Rows, Cols, 32, 77, 5);

                    // Road B Down
                    ProduceHorizontalWall(Rows, Cols, 30, 75, 7);

                    // Road B Left down
                    ProduceVerticalWall(Rows, Cols, 7, 19, 75);

                    // Road B Right down
                    ProduceVerticalWall(Rows, Cols, 5, 19, 77);

                    // Road B Coreners
                    ProduceCornerTL(1, 7);
                    ProduceCornerTL(3, 9);

                    ProduceCornerTR(1, 32);
                    ProduceCornerTR(3, 30);

                    ProduceCornerBL(5, 32);
                    ProduceCornerBL(7, 30);

                    ProduceCornerTR(5, 77);
                    ProduceCornerTR(7, 75);

                    #endregion

                    #region Road C

                    // Road C Top
                    ProduceHorizontalWall(Rows, Cols, 18, 30, 8);

                    // Road C Down
                    ProduceHorizontalWall(Rows, Cols, 18, 28, 10);

                    // Road C Left down
                    ProduceVerticalWall(Rows, Cols, 10, 18, 28);

                    // Road C Right down
                    ProduceVerticalWall(Rows, Cols, 8, 16, 30);

                    // Road C Top
                    ProduceHorizontalWall(Rows, Cols, 30, 47, 16);

                    // Road C Down
                    ProduceHorizontalWall(Rows, Cols, 28, 49, 18);

                    // Road C Right down
                    ProduceVerticalWall(Rows, Cols, 15, 18, 49);



                    // Road C Coreners
                    ProduceCornerTR(10, 28);
                    ProduceCornerTR(8, 30);

                    ProduceCornerBL(18, 28);
                    ProduceCornerBL(16, 30);

                    ProduceCornerBR(16, 47);
                    ProduceCornerBR(18, 49);


                    #endregion

                    #endregion

                    #region Doorways

                    // Room 3-1 Top Doorway
                    DoorwayTop(13, 3);


                    // Room 3-2 Bot Doorway
                    DoorwayBot(12, 3);

                    // Room 3-2 Top Doorway
                    DoorwayTop(7, 7);

                    // Room 3-2 Right Doorway
                    DoorwayRight(8, 18);

                    // Room 3-3 Bot Doorway
                    DoorwayBot(15, 47);


                    // Lvl Exit
                    DoorwayTop(19, 75);

                    #endregion

                    Console.Write(Map[Rows, Cols]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ClearCash();

            Gold gold1Room1 = new Gold(17, 14);
            
            Enemy enemy1Room2 = new Enemy(17, 11, 1);

            Enemy enemy1RoadA = new Enemy(20, 2, 1);
            Enemy enemy2RoadA = new Enemy(44, 6, 1);
            Enemy enemy3RoadA = new Enemy(44, 6, 1);
            Enemy enemy4RoadA = new Enemy(76, 10, 1);

            Enemy enemy5RoadB = new Enemy(29, 12, 1);
            Enemy enemy6RoadB = new Enemy(40, 17, 1);

            Enemy boss = new Enemy(48, 11, "Steel");
            Gold gold2Room3 = new Gold(41, 10);
            Gold gold3Room3 = new Gold(42, 9);
            Gold gold4Room3 = new Gold(54, 9);
            Gold gold5Room3 = new Gold(55, 10);
            TrapChest tC1Room3 = new TrapChest(55, 9);
            RewardChest rC1Room3 = new RewardChest(41, 9);

            PotionStore store2 = new PotionStore(30, 2);
            EntranceAndExit Exit2 = new EntranceAndExit(3, 17, 76, 19);
            System.Threading.Thread.Sleep(10);
            Dialog.Instance.Legend();
            Player.Instance.ProducePlayer(5, 17);

        }

        public void Level4()
        {
            for (Rows = 0; Rows < Map.GetLength(0); Rows++)
            {
                for (Cols = 0; Cols < Map.GetLength(1); Cols++)
                {
                    #region OutLine
                    Map[Rows, Cols] = Blank;

                    // build map top
                    Map[0, Cols] = HoriWall;

                    // build map Bottom
                    Map[Map.GetLength(0) - 1, Cols] = HoriWall;

                    // build map left edge
                    Map[Rows, 0] = VertWall;

                    // build map right edge
                    Map[Rows, Map.GetLength(1) - 1] = VertWall;

                    // build top left corner
                    Map[0, 0] = CornerTL;

                    // build top right corner
                    Map[0, Map.GetLength(1) - 1] = CornerTR;

                    // build borrom left corner
                    Map[Map.GetLength(0) - 1, 0] = CornerBL;

                    // build bottom left corner
                    Map[Map.GetLength(0) - 1, Map.GetLength(1) - 1] = CornerBR;

                    #endregion

                    #region Rooms

                    #region Room 4-1

                    // print corners
                    ProduceCornerTL(13, 2);
                    ProduceCornerTR(13, 18);
                    ProduceCornerBL(18, 2);
                    ProduceCornerBR(18, 18);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 2, 18, 13);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 2, 18, 18);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 13, 18, 2);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 13, 18, 18);

                    #endregion

                    #region Room 4-2
                    // print corners
                    ProduceCornerTL(1, 2);
                    ProduceCornerTR(1, 18);
                    ProduceCornerBL(6, 2);
                    ProduceCornerBR(6, 18);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 2, 18, 1);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 2, 18, 6);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 1, 6, 2);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 1, 6, 18);

                    #endregion

                    #region Room 4-3
                    // print corners
                    ProduceCornerTL(1, 62);
                    ProduceCornerTR(1, 78);
                    ProduceCornerBL(6, 62);
                    ProduceCornerBR(6, 78);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 62, 78, 1);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 62, 78, 6);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 1, 6, 62);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 1, 6, 78);

                    #endregion

                    #region Room 4-4
                    // print corners
                    ProduceCornerTL(13, 62);
                    ProduceCornerTR(13, 78);
                    ProduceCornerBL(18, 62);
                    ProduceCornerBR(18, 78);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 62, 78, 13);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 62, 78, 18);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 13, 18, 62);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 13, 18, 78);

                    #endregion

                    #endregion

                    #region Roads

                    #region Road A

                    // Road A Top
                    ProduceHorizontalWall(Rows, Cols, 18, 62, 2);

                    // Road A Down
                    ProduceHorizontalWall(Rows, Cols, 18, 62, 4);

                    #endregion

                    #region Road B

                    // Road B Top
                    ProduceHorizontalWall(Rows, Cols, 18, 62, 15);

                    // Road B Down
                    ProduceHorizontalWall(Rows, Cols, 18, 62, 17);

                    #endregion

                    #region Road C

                    // Road C Left
                    ProduceVerticalWall(Rows, Cols, 4, 15, 39);

                    // Road C Right
                    ProduceVerticalWall(Rows, Cols, 4, 15, 41);

                    #endregion

                    #endregion

                    #region Doorways

                    // Room 4-1 Right Doorway
                    DoorwayRight(15, 18);


                    // Room 4-2 Left Doorway
                    DoorwayLeft(15, 62);

                    // Room 4-3 Right Doorway
                    DoorwayRight(2, 18);


                    // Room 4-4 Left Doorway
                    DoorwayLeft(2, 62);

                    // Road C Bot Doorway
                    DoorwayBot(4, 39);

                    // Road C Top Doorway
                    DoorwayTop(15, 39);

                    #endregion

                    Console.Write(Map[Rows, Cols]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ClearCash();

            Gold gold1RoadA = new Gold(50, 3);
            Enemy enemy1RoadA = new Enemy(20, 3, 1);
            Enemy enemy2RoadA = new Enemy(39, 3, 2);
            Enemy enemy3RoadA = new Enemy(60, 3, 1);

            Enemy enemy4RoadB = new Enemy(20, 16, 1);
            Enemy enemy5RoadB = new Enemy(39, 16, 2);
            Enemy enemy6RoadB = new Enemy(60, 16, 1);

            Gold gold2RoadC = new Gold(40, 10);
            RewardChest rC1Room3 = new RewardChest(64, 5);

            Gold gold3Room4 = new Gold(77, 14);
            
            PotionStore store2 = new PotionStore(16, 14);
            EntranceAndExit Exit2 = new EntranceAndExit(3, 2, 77, 17);
            System.Threading.Thread.Sleep(10);
            Dialog.Instance.Legend();
            Player.Instance.ProducePlayer(5, 2);

        }

        public void Level5()
        {
            for (Rows = 0; Rows < Map.GetLength(0); Rows++)
            {
                for (Cols = 0; Cols < Map.GetLength(1); Cols++)
                {
                    #region OutLine
                    Map[Rows, Cols] = Blank;

                    // build map top
                    Map[0, Cols] = HoriWall;

                    // build map Bottom
                    Map[Map.GetLength(0) - 1, Cols] = HoriWall;

                    // build map left edge
                    Map[Rows, 0] = VertWall;

                    // build map right edge
                    Map[Rows, Map.GetLength(1) - 1] = VertWall;

                    // build top left corner
                    Map[0, 0] = CornerTL;

                    // build top right corner
                    Map[0, Map.GetLength(1) - 1] = CornerTR;

                    // build borrom left corner
                    Map[Map.GetLength(0) - 1, 0] = CornerBL;

                    // build bottom left corner
                    Map[Map.GetLength(0) - 1, Map.GetLength(1) - 1] = CornerBR;

                    #endregion

                    #region Rooms

                    #region Room 5-1
                    // print corners
                    ProduceCornerTL(1, 2);
                    ProduceCornerTR(1, 40);
                    ProduceCornerBL(12, 2);
                    ProduceCornerBR(12, 40);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 2, 40, 1);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 2, 40, 12);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 1, 12, 2);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 1, 12, 40);

                    #endregion

                    #region Room 5-2
                    // print corners
                    ProduceCornerTL(1, 50);
                    ProduceCornerTR(1, 78);
                    ProduceCornerBL(6, 50);
                    ProduceCornerBR(6, 78);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 50, 78, 1);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 50, 78, 6);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 1, 6, 50);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 1, 6, 78);

                    #endregion

                    #region Room 5-3
                    // print corners
                    ProduceCornerTL(7, 50);
                    ProduceCornerTR(7, 69);
                    ProduceCornerBL(13, 50);
                    ProduceCornerBR(13, 69);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 50, 69, 7);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 50, 69, 13);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 7, 13, 50);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 7, 13, 69);

                    #endregion

                    #endregion

                    #region Roads

                    #region Road A

                    // Road A Top
                    ProduceHorizontalWall(Rows, Cols, 40, 50, 2);

                    // Road A Down
                    ProduceHorizontalWall(Rows, Cols, 40, 50, 4);

                    #endregion

                    #region Road B

                    // Road B Top
                    ProduceHorizontalWall(Rows, Cols, 40, 50, 9);

                    // Road B Down
                    ProduceHorizontalWall(Rows, Cols, 40, 50, 11);

                    #endregion

                    #region Road C

                    // Road C Left
                    ProduceVerticalWall(Rows, Cols, 6, 19, 75);

                    // Road C Right
                    ProduceVerticalWall(Rows, Cols, 6, 19, 77);

                    #endregion

                    #region Road D

                    // Road D Top
                    ProduceHorizontalWall(Rows, Cols, 69, 75, 8);

                    // Road D Down
                    ProduceHorizontalWall(Rows, Cols, 69, 75, 10);

                    #endregion

                    #endregion

                    #region Doorways

                    // Room 5-1 Right Doorway
                    DoorwayRight(9, 40);

                    // Room 5-1 Right Doorway
                    DoorwayRight(2, 40);

                    // Room 5-2 Left Doorway
                    DoorwayLeft(9, 50);

                    // Room 5-2 Left Doorway
                    DoorwayLeft(2, 50);

                    // Road C Bot Doorway
                    DoorwayBot(6, 75);

                    // Road C Top Doorway
                    DoorwayTop(19, 75);

                    // Room 5-3 Right Doorway
                    DoorwayRight(8, 69);

                    // Road C Left Doorway
                    DoorwayLeft(8, 75);

                    #endregion

                    Console.Write(Map[Rows, Cols]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ClearCash();

            Enemy enemy1Room1 = new Enemy(38, 2, 1);
            Enemy enemy2Room1 = new Enemy(38, 4, 1);
            Enemy enemy3Room1 = new Enemy(38, 11, 2);
            Enemy enemy4Room1 = new Enemy(19, 11, 2);

            Gold gold1Room2 = new Gold(76, 2);
            Gold gold2Room2 = new Gold(77, 2);
            Gold gold3Room2 = new Gold(76, 3);
            Gold gold4Room2 = new Gold(77, 3);
            Enemy enemy5Room2 = new Enemy(52, 2, 1);
            Enemy enemy6Room2 = new Enemy(52, 4, 1);
            Enemy enemy7Room2 = new Enemy(64, 3, 2);

            TrapChest tC1Room3 = new TrapChest(67, 12);

            EntranceAndExit Exit = new EntranceAndExit(3, 2, 76, 19);
            System.Threading.Thread.Sleep(10);
            Dialog.Instance.Legend();
            Player.Instance.ProducePlayer(5, 2);
        }

        public void Level6()
        {
            for (Rows = 0; Rows < Map.GetLength(0); Rows++)
            {
                for (Cols = 0; Cols < Map.GetLength(1); Cols++)
                {
                    #region OutLine
                    Map[Rows, Cols] = Blank;

                    // build map top
                    Map[0, Cols] = HoriWall;

                    // build map Bottom
                    Map[Map.GetLength(0) - 1, Cols] = HoriWall;

                    // build map left edge
                    Map[Rows, 0] = VertWall;

                    // build map right edge
                    Map[Rows, Map.GetLength(1) - 1] = VertWall;

                    // build top left corner
                    Map[0, 0] = CornerTL;

                    // build top right corner
                    Map[0, Map.GetLength(1) - 1] = CornerTR;

                    // build borrom left corner
                    Map[Map.GetLength(0) - 1, 0] = CornerBL;

                    // build bottom left corner
                    Map[Map.GetLength(0) - 1, Map.GetLength(1) - 1] = CornerBR;

                    #endregion

                    #region Rooms

                    #region Room 5-1
                    // print corners
                    ProduceCornerTL(1, 2);
                    ProduceCornerTR(1, 77);
                    ProduceCornerBR(7, 77);
                    ProduceCornerTR(11, 77);

                    ProduceCornerTL(7, 6);
                    ProduceCornerBL(9, 6);

                    ProduceCornerTL(11, 6);
                    ProduceCornerBL(13, 6);

                    ProduceCornerTR(12, 77);
                    ProduceCornerBR(18, 77);

                    ProduceCornerBL(18, 2);
                    ProduceCornerBR(18, 77);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 2, 77, 1);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 2, 77, 18);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 1, 18, 2);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 1, 7, 77);
                    ProduceVerticalWall(Rows, Cols, 13, 18, 77);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 6, 62, 11);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 6, 62, 9);

                    ProduceHorizontalWall(Rows, Cols, 6, 62, 9);

                    #endregion
                    #endregion

                    #region Doorways

                    // Room 5-1 Right Doorway
                    //DoorwayRight(9, 40);



                    #endregion

                    Console.Write(Map[Rows, Cols]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ClearCash();
            /*
            Enemy enemy1Room1 = new Enemy(38, 2, 1);
            Enemy enemy2Room1 = new Enemy(38, 4, 1);
            Enemy enemy3Room1 = new Enemy(38, 11, 2);
            Enemy enemy4Room1 = new Enemy(19, 11, 2);

            Gold gold1Room2 = new Gold(76, 2);
            Gold gold2Room2 = new Gold(77, 2);
            Gold gold3Room2 = new Gold(76, 3);
            Gold gold4Room2 = new Gold(77, 3);
            Enemy enemy5Room2 = new Enemy(52, 2, 1);
            Enemy enemy6Room2 = new Enemy(52, 4, 1);
            Enemy enemy7Room2 = new Enemy(64, 3, 2);

            TrapChest tC1Room3 = new TrapChest(67, 12);
            */
            EntranceAndExit Exit = new EntranceAndExit(3, 3, 3, 18);
            System.Threading.Thread.Sleep(10);
            Dialog.Instance.Legend();
            Player.Instance.ProducePlayer(5, 2);
        }

        public void Level7()
        {
            for (Rows = 0; Rows < Map.GetLength(0); Rows++)
            {
                for (Cols = 0; Cols < Map.GetLength(1); Cols++)
                {
                    #region OutLine
                    Map[Rows, Cols] = Blank;

                    // build map top
                    Map[0, Cols] = HoriWall;

                    // build map Bottom
                    Map[Map.GetLength(0) - 1, Cols] = HoriWall;

                    // build map left edge
                    Map[Rows, 0] = VertWall;

                    // build map right edge
                    Map[Rows, Map.GetLength(1) - 1] = VertWall;

                    // build top left corner
                    Map[0, 0] = CornerTL;

                    // build top right corner
                    Map[0, Map.GetLength(1) - 1] = CornerTR;

                    // build borrom left corner
                    Map[Map.GetLength(0) - 1, 0] = CornerBL;

                    // build bottom left corner
                    Map[Map.GetLength(0) - 1, Map.GetLength(1) - 1] = CornerBR;

                    #endregion

                    #region Rooms

                    #region Room 1-1

                    // print corners
                    ProduceCornerTL(1, 2);
                    ProduceCornerTR(1, 18);
                    ProduceCornerBL(6, 2);
                    ProduceCornerBR(6, 18);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 2, 18, 1);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 2, 18, 6);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 1, 6, 2);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 1, 6, 18);

                    #endregion

                    #region Room 1-2
                    // print corners
                    ProduceCornerTL(12, 30);
                    ProduceCornerTR(12, 46);
                    ProduceCornerBL(18, 30);
                    ProduceCornerBR(18, 46);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 30, 46, 12);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 30, 46, 18);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 12, 18, 30);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 12, 18, 46);

                    #endregion

                    #region Room 1-3
                    // print corners
                    ProduceCornerTL(2, 50);
                    ProduceCornerTR(2, 72);
                    ProduceCornerBL(9, 50);
                    ProduceCornerBR(9, 72);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 50, 72, 2);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 50, 72, 9);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 2, 9, 50);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 2, 9, 72);

                    #endregion

                    #endregion

                    #region Roads

                    #region Road A

                    // Road A Left Entry to Room 1-1
                    ProduceVerticalWall(Rows, Cols, 6, 19, 5);

                    // Road A Right Entry to Room 1-1
                    ProduceVerticalWall(Rows, Cols, 6, 19, 7);

                    #endregion

                    #region Road B

                    // Road B Top Entry to Room 1-2
                    ProduceHorizontalWall(Rows, Cols, 7, 30, 13);

                    // Road B Bottom Entry to Room 1-2
                    ProduceHorizontalWall(Rows, Cols, 7, 30, 15);

                    #endregion

                    #region Road C

                    //Road C Coreners
                    ProduceCornerTL(5, 20);
                    ProduceCornerTL(7, 22);

                    // Road C Left
                    ProduceVerticalWall(Rows, Cols, 5, 13, 20);

                    // Road C Right
                    ProduceVerticalWall(Rows, Cols, 7, 13, 22);

                    // Road C Top
                    ProduceHorizontalWall(Rows, Cols, 20, 50, 5);

                    // Road C Down
                    ProduceHorizontalWall(Rows, Cols, 22, 50, 7);

                    #endregion

                    #region Road D

                    //Road D Corners
                    ProduceCornerBR(15, 60);
                    ProduceCornerBR(17, 62);

                    // Road Left
                    ProduceVerticalWall(Rows, Cols, 9, 15, 60);

                    // Road Right
                    ProduceVerticalWall(Rows, Cols, 9, 17, 62);

                    // Road Top
                    ProduceHorizontalWall(Rows, Cols, 46, 60, 15);

                    // Road Bot
                    ProduceHorizontalWall(Rows, Cols, 46, 62, 17);

                    #endregion

                    #region Road Out

                    // Road D Left
                    ProduceVerticalWall(Rows, Cols, 9, 19, 68);

                    // Road D Right
                    ProduceVerticalWall(Rows, Cols, 9, 19, 70);

                    #endregion

                    #region Crossroads

                    // Crossroads A-B
                    DoorwayRight(13, 7);

                    // Crossroads B-C
                    DoorwayTop(13, 20);

                    #endregion

                    #endregion

                    #region Doorways

                    // Level Entrance Doorway
                    DoorwayTop(19, 5);

                    // Room 1-1 Bot Doorway
                    DoorwayBot(6, 5);

                    // Room 1-2 Left Doorway
                    DoorwayLeft(13, 30);

                    // Room 1-2 Right Doorway
                    DoorwayRight(15, 46);

                    // Room 1-3 Left Doorway
                    DoorwayLeft(5, 50);

                    // Room 1-3 Bot Doorway
                    DoorwayBot(9, 60);

                    // Room 1-3 Bor Doorway Out
                    DoorwayBot(9, 68);

                    // Level Exit Doorway
                    DoorwayTop(19, 68);

                    #endregion

                    Console.Write(Map[Rows, Cols]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void Level8()
        {
            for (Rows = 0; Rows < Map.GetLength(0); Rows++)
            {
                for (Cols = 0; Cols < Map.GetLength(1); Cols++)
                {
                    #region OutLine
                    Map[Rows, Cols] = Blank;

                    // build map top
                    Map[0, Cols] = HoriWall;

                    // build map Bottom
                    Map[Map.GetLength(0) - 1, Cols] = HoriWall;

                    // build map left edge
                    Map[Rows, 0] = VertWall;

                    // build map right edge
                    Map[Rows, Map.GetLength(1) - 1] = VertWall;

                    // build top left corner
                    Map[0, 0] = CornerTL;

                    // build top right corner
                    Map[0, Map.GetLength(1) - 1] = CornerTR;

                    // build borrom left corner
                    Map[Map.GetLength(0) - 1, 0] = CornerBL;

                    // build bottom left corner
                    Map[Map.GetLength(0) - 1, Map.GetLength(1) - 1] = CornerBR;

                    #endregion

                    #region Rooms

                    #region Room 8-1

                    // print corners
                    ProduceCornerTL(13, 2);
                    ProduceCornerTR(13, 18);
                    ProduceCornerBL(18, 2);
                    ProduceCornerBR(18, 18);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 2, 18, 13);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 2, 18, 18);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 13, 18, 2);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 13, 18, 18);

                    #endregion

                    #region Room 8-2
                    // print corners
                    ProduceCornerTL(1, 2);
                    ProduceCornerTR(1, 18);
                    ProduceCornerBL(6, 2);
                    ProduceCornerBR(6, 18);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 2, 18, 1);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 2, 18, 6);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 1, 6, 2);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 1, 6, 18);

                    #endregion

                    #region Room 8-3
                    // print corners
                    ProduceCornerTL(1, 62);
                    ProduceCornerTR(1, 78);
                    ProduceCornerBL(6, 62);
                    ProduceCornerBR(6, 78);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 62, 78, 1);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 62, 78, 6);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 1, 6, 62);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 1, 6, 78);

                    #endregion

                    #region Room 8-4
                    // print corners
                    ProduceCornerTL(13, 62);
                    ProduceCornerTR(13, 78);
                    ProduceCornerBL(18, 62);
                    ProduceCornerBR(18, 78);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 62, 78, 13);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 62, 78, 18);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 13, 18, 62);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 13, 18, 78);

                    #endregion

                    #region Room 8-5
                    // print corners
                    ProduceCornerTL(5, 30);
                    ProduceCornerTR(5, 50);
                    ProduceCornerBL(14, 30);
                    ProduceCornerBR(14, 50);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 30, 50, 5);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 30, 50, 14);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 5, 14, 30);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 5, 14, 50);

                    #endregion

                    #endregion

                    #region Roads

                    #region Road A

                    // Road A Top
                    ProduceHorizontalWall(Rows, Cols, 18, 62, 2);

                    // Road A Down
                    ProduceHorizontalWall(Rows, Cols, 18, 62, 4);

                    #endregion

                    #region Road B

                    // Road B Top
                    ProduceHorizontalWall(Rows, Cols, 18, 62, 15);

                    // Road B Down
                    ProduceHorizontalWall(Rows, Cols, 18, 62, 17);

                    #endregion

                    #region Road C

                    // Road C Left
                    ProduceVerticalWall(Rows, Cols, 4, 15, 39);

                    // Road C Right
                    ProduceVerticalWall(Rows, Cols, 4, 15, 41);

                    #endregion

                    #region Unblock Road C

                    //Road A  Block
                    Map[5, 40] = Blank;

                    //Road A  Block
                    Map[14, 40] = Blank;

                    #endregion

                    #endregion

                    #region Doorways

                    // Room 8-1 Right Doorway
                    DoorwayRight(15, 18);


                    // Room 8-2 Left Doorway
                    DoorwayLeft(15, 62);

                    // Room 8-3 Right Doorway
                    DoorwayRight(2, 18);


                    // Room 8-4 Left Doorway
                    DoorwayLeft(2, 62);

                    // Road C Bot Doorway
                    DoorwayBot(4, 39);

                    // Road C Top Doorway
                    DoorwayTop(15, 39);

                    // Road C Left Doorway
                    Map[8, 39] = Blank;
                    Map[9, 39] = Blank;
                    Map[10, 39] = Blank;
                    Map[11, 39] = Blank;

                    // Road C Right Doorway
                    Map[8, 41] = Blank;
                    Map[9, 41] = Blank;
                    Map[10, 41] = Blank;
                    Map[11, 41] = Blank;

                    #endregion

                    Console.Write(Map[Rows, Cols]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ClearCash();

            Enemy enemy1RoadA = new Enemy(3, 2, 2);
            Enemy enemy3RoadA = new Enemy(77, 2, 3);

            Enemy enemy4RoadB = new Enemy(3, 17, 3);
            Enemy enemy6RoadB = new Enemy(77, 17, 2);

            RewardChest rC1Room1 = new RewardChest(3, 14);

            RewardChest rC2Room2 = new RewardChest(3, 5);

            RewardChest rC3Room3 = new RewardChest(77, 5);
            
            RewardChest rC4Room4 = new RewardChest(77, 14);

            PotionStore store2 = new PotionStore(49, 9);
            EntranceAndExit Exit2 = new EntranceAndExit(31, 10, 49, 10);
            System.Threading.Thread.Sleep(10);
            Dialog.Instance.Legend();
            Player.Instance.ProducePlayer(31, 9);

        }

        public void Level9()
        {
            for (Rows = 0; Rows < Map.GetLength(0); Rows++)
            {
                for (Cols = 0; Cols < Map.GetLength(1); Cols++)
                {
                    #region OutLine
                    Map[Rows, Cols] = Blank;

                    // build map top
                    Map[0, Cols] = HoriWall;

                    // build map Bottom
                    Map[Map.GetLength(0) - 1, Cols] = HoriWall;

                    // build map left edge
                    Map[Rows, 0] = VertWall;

                    // build map right edge
                    Map[Rows, Map.GetLength(1) - 1] = VertWall;

                    // build top left corner
                    Map[0, 0] = CornerTL;

                    // build top right corner
                    Map[0, Map.GetLength(1) - 1] = CornerTR;

                    // build borrom left corner
                    Map[Map.GetLength(0) - 1, 0] = CornerBL;

                    // build bottom left corner
                    Map[Map.GetLength(0) - 1, Map.GetLength(1) - 1] = CornerBR;

                    #endregion

                    #region Room 9-1
                    // print corners
                    ProduceCornerTL(6, 29);
                    ProduceCornerTR(6, 51);
                    ProduceCornerBL(13, 29);
                    ProduceCornerBR(13, 51);

                    // print top
                    ProduceHorizontalWall(Rows, Cols, 29, 51, 6);

                    // print bottom
                    ProduceHorizontalWall(Rows, Cols, 29, 51, 13);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 6, 13, 29);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 6, 13, 51);

                    #endregion

                    #region Doorways

                    // Road C Left Doorway
                    Map[9, 29] = Blank;
                    Map[10, 29] = Blank;

                    // Road C Right Doorway
                    Map[9, 51] = Blank;
                    Map[10, 51] = Blank;

                    #endregion

                    Console.Write(Map[Rows, Cols]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ClearCash();

            Enemy enemy1 = new Enemy(40, 5, 4);
            Enemy enemy2 = new Enemy(48, 5, 4);

            Enemy enemy3 = new Enemy(52, 9, 5);
            Enemy enemy4 = new Enemy(52, 10, 5);

            Enemy enemy5 = new Enemy(48, 14, 4);
            Enemy enemy6 = new Enemy(40, 14, 4);

            Gold gold1 = new Gold(30, 7);
            Gold gold2 = new Gold(32, 7);
            Gold gold3 = new Gold(31, 8);

            Gold gold5 = new Gold(50, 7);
            Gold gold4 = new Gold(50, 8);

            Gold gold10 = new Gold(48, 12);
            Gold gold11 = new Gold(50, 12);
            Gold gold12 = new Gold(49, 11);

            TrapChest tC1 = new TrapChest(36, 7);
            TrapChest tC2 = new TrapChest(50, 9);

            Enemy boss = new Enemy(28, 9, "Fire");

            PotionStore store2 = new PotionStore(30, 12);
            EntranceAndExit Exit2 = new EntranceAndExit(2, 10, 40, 10);
            System.Threading.Thread.Sleep(10);
            Dialog.Instance.Legend();
            Player.Instance.ProducePlayer(2, 9);
        }

        public void Level10()
        {
            for (Rows = 0; Rows < Map.GetLength(0); Rows++)
            {
                for (Cols = 0; Cols < Map.GetLength(1); Cols++)
                {
                    #region OutLine
                    Map[Rows, Cols] = Blank;

                    // build map top
                    Map[0, Cols] = HoriWall;

                    // build map Bottom
                    Map[Map.GetLength(0) - 1, Cols] = HoriWall;

                    // build map left edge
                    Map[Rows, 0] = VertWall;

                    // build map right edge
                    Map[Rows, Map.GetLength(1) - 1] = VertWall;

                    // build top left corner
                    Map[0, 0] = CornerTL;

                    // build top right corner
                    Map[0, Map.GetLength(1) - 1] = CornerTR;

                    // build borrom left corner
                    Map[Map.GetLength(0) - 1, 0] = CornerBL;

                    // build bottom left corner
                    Map[Map.GetLength(0) - 1, Map.GetLength(1) - 1] = CornerBR;

                    #endregion

                    #region Walls

                    #region Wall 10-1
                    // print corners
                    ProduceCornerBR(19, 26);
                    ProduceCornerBL(19, 27);
                    ProduceCornerTL(2, 26);
                    ProduceCornerTR(2, 27);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 2, 19, 26);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 2, 19, 27);

                    #endregion

                    #region Wall 10-2
                    // print corners
                    ProduceCornerTR(0, 53);
                    ProduceCornerTL(0, 54);
                    ProduceCornerBL(17, 53);
                    ProduceCornerBR(17, 54);

                    // print left edge
                    ProduceVerticalWall(Rows, Cols, 0, 17, 53);

                    // print right edge
                    ProduceVerticalWall(Rows, Cols, 0, 17, 54);

                    #endregion

                    #endregion

                    Console.Write(Map[Rows, Cols]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ClearCash();

            TrapChest tC1 = new TrapChest(4, 2);
            RewardChest rC1 = new RewardChest(2, 2);
            RewardChest rC2 = new RewardChest(6, 2);
            RewardChest rC3 = new RewardChest(8, 2);
            RewardChest rC4 = new RewardChest(10, 2);

            Enemy boss = new Enemy(40, 9, "Nature");

            EntranceAndExit Exit2 = new EntranceAndExit(2, 18, 77, 1);
            System.Threading.Thread.Sleep(10);
            Dialog.Instance.Legend();
            Player.Instance.ProducePlayer(2, 9);
        }

        public void Finish()
        {
            for (Rows = 0; Rows < Map.GetLength(0); Rows++)
            {
                for (Cols = 0; Cols < Map.GetLength(1); Cols++)
                {
                    #region OutLine

                    Map[Rows, Cols] = Blank;

                    // build map top
                    Map[0, Cols] = HoriWall;

                    // build map Bottom
                    Map[Map.GetLength(0) - 1, Cols] = HoriWall;

                    // build map left edge
                    Map[Rows, 0] = VertWall;

                    // build map right edge
                    Map[Rows, Map.GetLength(1) - 1] = VertWall;

                    // build top left corner
                    Map[0, 0] = CornerTL;

                    // build top right corner
                    Map[0, Map.GetLength(1) - 1] = CornerTR;

                    // build borrom left corner
                    Map[Map.GetLength(0) - 1, 0] = CornerBL;

                    // build bottom left corner
                    Map[Map.GetLength(0) - 1, Map.GetLength(1) - 1] = CornerBR;

                    #endregion

                    Map[9, 24] = "C";
                    Map[9, 26] = "o";
                    Map[9, 28] = "n";
                    Map[9, 30] = "g";
                    Map[9, 32] = "r";
                    Map[9, 34] = "a";
                    Map[9, 36] = "t";
                    Map[9, 38] = "u";
                    Map[9, 40] = "l";
                    Map[9, 42] = "a";
                    Map[9, 44] = "t";
                    Map[9, 46] = "i";
                    Map[9, 48] = "o";
                    Map[9, 50] = "n";
                    Map[9, 52] = "s";
                    Map[9, 54] = "!";

                    Console.Write(Map[Rows, Cols]);
                }

                Console.WriteLine();
            }

            ClearCash();

            Console.ReadKey();
        }

        public void ClearCash()
        {
            PotionStore.potionStoreList.Clear();
            Enemy.enemyList.Clear();
            Enemy.bossList.Clear();
            Gold.GoldList.Clear();
            TrapChest.TChestList.Clear();
            RewardChest.RChestList.Clear();
        }

        #region WallProduction

        // Produce Long Wall
        private void ProduceVerticalWall(int rows, int cols, int from, int to, int col)
        {
            if (rows > from && rows < to)
            {
                if (cols == col)
                {
                    Map[rows, cols] = VertWall;
                }
            }
        }

        // Produce Custom wall
        private void ProduceVerticalWall(int rows, int cols, int row, int col)
        {
            if (rows == row && cols == col)
            {
                MapGenerator.Instance.Map[rows, cols] = MapGenerator.Instance.VertWall;
            }
        }

        // Produce Long Wall
        private void ProduceHorizontalWall(int rows, int cols, int from, int to, int row)
        {
            if (cols > from && cols < to)
            {
                if (rows == row)
                {
                    MapGenerator.Instance.Map[rows, cols] = MapGenerator.Instance.HoriWall;
                }
            }
        }

        // Produce Custom wall
        private void ProduceHorizontalWall(int rows, int cols, int row, int col)
        {
            if (rows == row && cols == col)
            {
                MapGenerator.Instance.Map[rows, cols] = MapGenerator.Instance.HoriWall;
            }
        }

        private void BlankSpot(int row, int col)
        {
            MapGenerator.Instance.Map[row, col] = MapGenerator.Instance.Blank;
        }

        private void ProduceCornerTL(int row, int col)
        {
            MapGenerator.Instance.Map[row, col] = MapGenerator.Instance.CornerTL;
        }

        private void ProduceCornerTR(int row, int col)
        {
            MapGenerator.Instance.Map[row, col] = MapGenerator.Instance.CornerTR;
        }

        private void ProduceCornerBL(int row, int col)
        {
            MapGenerator.Instance.Map[row, col] = MapGenerator.Instance.CornerBL;
        }

        private void ProduceCornerBR(int row, int col)
        {
            MapGenerator.Instance.Map[row, col] = MapGenerator.Instance.CornerBR;
        }

        private void DoorwayTop(int row, int col)
        {
            MapGenerator.Instance.Map[row, col++] = MapGenerator.Instance.CornerBR;
            MapGenerator.Instance.Map[row, col++] = MapGenerator.Instance.Blank;
            MapGenerator.Instance.Map[row, col++] = MapGenerator.Instance.CornerBL;
        }

        private void DoorwayBot(int row, int col)
        {
            MapGenerator.Instance.Map[row, col++] = MapGenerator.Instance.CornerTR;
            MapGenerator.Instance.Map[row, col++] = MapGenerator.Instance.Blank;
            MapGenerator.Instance.Map[row, col++] = MapGenerator.Instance.CornerTL;
        }

        private void DoorwayLeft(int row, int col)
        {
            MapGenerator.Instance.Map[row++, col] = MapGenerator.Instance.CornerBR;
            MapGenerator.Instance.Map[row++, col] = MapGenerator.Instance.Blank;
            MapGenerator.Instance.Map[row++, col] = MapGenerator.Instance.CornerTR;
        }

        private void DoorwayRight(int row, int col)
        {
            MapGenerator.Instance.Map[row++, col] = MapGenerator.Instance.CornerBL;
            MapGenerator.Instance.Map[row++, col] = MapGenerator.Instance.Blank;
            MapGenerator.Instance.Map[row++, col] = MapGenerator.Instance.CornerTL;
        }

        private void CustomVerticalDoorway(int row, int col, string firstShape, string secondShape)
        {
            MapGenerator.Instance.Map[row++, col] = firstShape;
            MapGenerator.Instance.Map[row++, col] = MapGenerator.Instance.Blank;
            MapGenerator.Instance.Map[row++, col] = secondShape;
        }

        private void CustomHorizontalDoorway(int row, int col, string firstShape, string secondShape)
        {
            MapGenerator.Instance.Map[row, col++] = firstShape;
            MapGenerator.Instance.Map[row, col++] = MapGenerator.Instance.Blank;
            MapGenerator.Instance.Map[row, col++] = secondShape;
        }

        #endregion
    }
}
