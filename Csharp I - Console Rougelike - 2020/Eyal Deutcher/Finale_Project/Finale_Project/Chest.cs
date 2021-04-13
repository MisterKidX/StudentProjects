using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    public class Chest: GameObject
    {
        Random random = new Random();
        public int GetGold()
        {
            SoundManager.ChestSound();
            int gold = random.Next(1, 5);
            Hud.InfoText2 = "You Found " + gold + " Gold In the Chest";
            return gold;
        }
    }
}
