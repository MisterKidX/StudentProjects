using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_RoguelikeRPG
{
    class Obstacle
    {

        public int originRow, originColumn, width, height;

        public Obstacle(int originRow, int originColumn, int width, int height)
        {
            this.originRow = originRow;
            this.originColumn = originColumn;
            this.width = width;
            this.height = height;
        }

        public override string ToString()
        {
            return "Obstacle - originRow: " + originRow + " originColumn: " + originColumn + " height: " + height + " width: " + width;
        }


    }
}
