using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_RoguelikeRPG
{
    class Trap
    {

        #region Class Members

        bool wasSteppedOn;
        int level;
        int posRow;
        int posCol;

        #endregion

        #region Class Properties

        public bool WasSteppedOn { get => wasSteppedOn; set => wasSteppedOn = value; }
        public int Level { get => level; set => level = value; }
        public int PosRow { get => posRow; set => posRow = value; }
        public int PosCol { get => posCol; set => posCol = value; }

        #endregion

        public Trap(int level)
        {
            wasSteppedOn = false;
            this.level = level;
        }
    }
}
