using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    class Player
    {
        private static Player _playerInstance = null;
        public static Player GetPlayerInstance
        {
            get
            {
                if (_playerInstance == null)
                {
                    _playerInstance = new Player();
                }
                return _playerInstance;
            }
        }
       
        public int PlayerHP = 100;
        public int PlayerMaxHP = 100;
        public int EnemyDMG = 18;
        public int HealPickup = 6;
        public int Level = 1;
        public int Coins = 0;       
        
    }
}
