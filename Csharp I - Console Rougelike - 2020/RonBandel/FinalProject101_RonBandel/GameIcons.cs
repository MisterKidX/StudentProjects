using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject101_RonBandel
{
    class GameIcons
    {
        static GameIcons()
        { }

        static public readonly string player = "@";
        static public readonly string entry = "E";
        static public readonly string exit = "X";
        static public readonly string enemy = "G";
        static public readonly string mine = "M";
        static public readonly string invisibleMine = "m";
        static public readonly string apple = "o";
        static public readonly string merchant = "☺";
        static public readonly string shelf = "╫";
        static public readonly string treasureChest = "T";
        static public readonly string emptySpace = " ";
        static public readonly string verticalWall = "|";
        static public readonly string horizontalWall = "-";
        static public readonly string heart = "♥";
        static public readonly string gold = "$";
        static public readonly string codexPage = "▒";


        static public readonly string bossPartEar = "▲";
        static public readonly string bossPartFlat = "_";
        static public readonly string bossPartFaceSide = "\\";
        static public readonly string bossPartWaist = "/";
        static public readonly string bossPartMouth = "O";
        static public readonly string bossPartEye = "°";
        static public readonly string bossPartRightShoulder = "╠";
        static public readonly string bossPartLimb1 = "╝";
        static public readonly string bossPartLeftShoulder = "╣";
        static public readonly string bossPartLimb2 = "╚";
        static public readonly string bossPartWhole = "  ▲___▲  \n" +
                                                      " /° O °\\ \n" +
                                                      " \\     / \n" +
                                                      "╚╣  ♥  ╠╝\n" +
                                                      "  \\___/  \n" +
                                                      "   ╝ ╚   ";
    }
}