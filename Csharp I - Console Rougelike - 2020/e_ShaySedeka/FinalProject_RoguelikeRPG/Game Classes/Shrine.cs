using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinalProject_RoguelikeRPG.GameDefinitions;

namespace FinalProject_RoguelikeRPG
{
    class Shrine
    {
        #region Class Members

        RewardType rewardType;
        int posRow, posColumn;

        #endregion

        #region Class Properties

        internal RewardType RewardType { get => rewardType; set => rewardType = value; }
        public int PosRow { get => posRow; set => posRow = value; }
        public int PosColumn { get => posColumn; set => posColumn = value; }

        #endregion

        #region Methods

        public Shrine()
        {
            this.RewardType = GetRandomRewardType();
            System.Threading.Thread.Sleep(20);
            PosRow = -1;
            PosColumn = -1;
        }

        private RewardType GetRandomRewardType()
        {
            //return a random reward type based on pre-determined distribution;

            Random rand = new Random();
            int rewardTypeSeed = rand.Next(0, 100);

            if(rewardTypeSeed <= 10)
            {
                return RewardType.MaxHP;
            }
            else if (rewardTypeSeed <= 30)
            {
                return RewardType.CritChance;
            }
            else if (rewardTypeSeed <= 50)
            {
                return RewardType.EvasionChance;
            }
            else
            {
                return RewardType.CurrentHP;
            }
        }

        public void AssignPosition(int posRow, int posColumn)
        {
            this.PosColumn = posColumn;
            this.PosRow = posRow;
        }

        #endregion

    }
}
