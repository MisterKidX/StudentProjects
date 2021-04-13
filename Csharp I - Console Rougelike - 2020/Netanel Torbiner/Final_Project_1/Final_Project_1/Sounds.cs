using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Media;

namespace Final_Project_1
{
    class Sounds
    {
        
        public SoundPlayer TrapSound;
        public SoundPlayer TreasureSound;
        public SoundPlayer LostSound;
        public SoundPlayer LevelAdvanced;
        public SoundPlayer GameWon;
        public SoundPlayer HitBorderS;
        public SoundPlayer FoughtEnemy;

        public Sounds()
        {

            TrapSound = new SoundPlayer(Final_Project_1.Properties.Resources.TrapSound);
            TreasureSound = new SoundPlayer(Final_Project_1.Properties.Resources.TreasureSound);
            LostSound = new SoundPlayer(Final_Project_1.Properties.Resources.LostSound);
            LevelAdvanced = new SoundPlayer(Final_Project_1.Properties.Resources.LevelAdvanced);
            GameWon = new SoundPlayer(Final_Project_1.Properties.Resources.GameWon);
            HitBorderS = new SoundPlayer(Final_Project_1.Properties.Resources.HitBorder);
            FoughtEnemy = new SoundPlayer(Final_Project_1.Properties.Resources.FoughtEnemy);
        }
    }
}
