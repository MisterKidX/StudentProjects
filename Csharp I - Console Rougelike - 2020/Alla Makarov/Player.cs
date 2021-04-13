// ---- C# 101 (Dor Ben Dor) ----
//         Alla Makarov
//          01/03/2021
// ------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame
{
    class Player
    {
        private int _maxHp;
        private int _curHp;
        private int _playerDmg;
        private int _minDmg;
        private Coordinate _position;

        public Player(int level)
        {
            _maxHp = 100 + level;
            _curHp = _maxHp;
            _playerDmg = 100 + level;
            _minDmg = 0;
            _position = new Coordinate(1, 1);
        }
        
        public void UpdatePlayerPosition(Coordinate newPosition)
        {
            _position = newPosition;
        }

        public Coordinate GetPlayerPosition()
        {
            return _position;
        }
        public bool FightEnemy()
        {
            Random rand = new Random();
            int enemyHealth = 100;
            int enemyDmg = 50;

            while(enemyHealth>0&&_curHp>0)
            {
                enemyHealth -= rand.Next(_minDmg, _playerDmg);
                _curHp -= rand.Next(0, enemyDmg);
            }

            if (enemyHealth<=0&&_curHp>0)
            {
                return true;
            }

            return false;
        }

        public void PrintPlayerStats()
        {
            Console.WriteLine("Your remaining HP: " + _curHp);
            Console.WriteLine("Max Dmg you can deal:" + _playerDmg);
        }

        public bool LoseHealthInTrap()
        {
            Random rand = new Random();

            _curHp -= rand.Next(0,20);
            if(_curHp<=0)
            {
                return true;
            }

            return false;
        }
        public string TreasureBonus()
        {
            Random rand = new Random();
            int bonus;
            bonus = rand.Next(1, 10);
            switch (rand.Next(1, 3))
            {
                case 1:
                    {
                        _curHp += bonus;
                        return "You were healed by " + bonus + ", say thank you to the gods!";
                    }
                case 2:
                    {
                        _playerDmg += bonus;
                        return "You found a good equipment, and got bonus " + bonus + " to your max damage";
                    }
                case 3:
                    {
                        if (_minDmg < _playerDmg)
                        {
                            _minDmg += bonus;
                            return "You min damge got " + bonus + "point, let the force be with you";
                        }
                        else
                        {
                            _playerDmg += bonus;
                            return "You founda a good equipment, and got bonus " + bonus + " to your max damage";
                        }
                    }
            }

            return "";
        }
        public void LevelUp()
        {
            if (_curHp<_maxHp)
            {
                _curHp = _maxHp;
            }
            _maxHp++;
            _playerDmg++;
            _minDmg++;
        }
    }
}
