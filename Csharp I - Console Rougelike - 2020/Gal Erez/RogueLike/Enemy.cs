using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    class Enemy
    {
        public static List<Enemy> enemyList = new List<Enemy>(100);
        public static List<Enemy> bossList = new List<Enemy>(50);
        public Position enemyPos = new Position();
        public Position bossPosUp = new Position();
        public Position bossPosDown = new Position();

        Random rand = new Random();

        public int Hp;
        public int CurrentHp;
        public int Mp;
        public int CurrentMp;
        public int Damage;
        public float Reward;
        public int Lvl;
        //public string Loot;
        public string EnemySymbol = "Θ";
        public string BossUpperSymbol = "φ";
        public string BossUnderSymbol = "Ω";
        public string BossType;
        //public bool isEquip;
        public bool isAlive;
        //public bool rewardIsWeapon;
        public int BossAtkCdRng = 0;

        public ConsoleColor BossColor;

        public Enemy(int x, int y, int lvl)
        {
            enemyPos = new Position(x, y);
            Reward = rand.Next(0, 1);
            int weaponType = rand.Next(0, 4);
            int weaponName = rand.Next(0, 5);

            switch (lvl)
            {
                case 1:
                    Hp = 2;
                    CurrentHp = Hp;
                    Mp = 0;
                    CurrentMp = Mp;
                    Damage = 7;
                    Lvl = 1;
                    isAlive = true;
                    break;

                case 2:
                    Hp = 2 * 2;
                    CurrentHp = Hp;
                    Mp = 2;
                    CurrentMp = Mp;
                    Damage = 7 * 2;
                    Lvl = 2;
                    isAlive = true;

                    if (Reward > 0.9)
                    {
                        if (Reward > 0.9f && Reward < 0.92f)
                        {
                            EarringsItem.Instance.EquipEarring("Quartz");
                        }
                        else
                        {
                            switch (weaponType)
                            {
                                case 1:
                                    Weapons.Instance.EquipWeapon(Weapons.Instance.swords[weaponName]);
                                    break;

                                case 2:
                                    Weapons.Instance.EquipWeapon(Weapons.Instance.axes[weaponName]);
                                    break;

                                case 3:
                                    Weapons.Instance.EquipWeapon(Weapons.Instance.staffs[weaponName]);
                                    break;

                                case 4:
                                    Weapons.Instance.EquipWeapon(Weapons.Instance.wands[weaponName]);
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                    break;

                case 3:
                    Hp = 2 * 3;
                    CurrentHp = Hp;
                    Mp = 2 * 3;
                    CurrentMp = Mp;
                    Damage = 7 * 3;
                    Lvl = 3;
                    isAlive = true;

                    if (Reward > 0.9)
                    {
                        if (Reward > 0.9f && Reward < 0.92f)
                        {
                            EarringsItem.Instance.EquipEarring("Malachite");
                        }
                        else
                        {
                            switch (weaponType)
                            {
                                case 1:
                                    Weapons.Instance.EquipWeapon(Weapons.Instance.swords[weaponName]);
                                    break;

                                case 2:
                                    Weapons.Instance.EquipWeapon(Weapons.Instance.axes[weaponName]);
                                    break;

                                case 3:
                                    Weapons.Instance.EquipWeapon(Weapons.Instance.staffs[weaponName]);
                                    break;

                                case 4:
                                    Weapons.Instance.EquipWeapon(Weapons.Instance.wands[weaponName]);
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                    break;

                case 4:
                    Hp = 2 * 5;
                    CurrentHp = Hp;
                    Mp = 2 * 5;
                    CurrentMp = Mp;
                    Damage = 7 * 5;
                    Lvl = 4;
                    isAlive = true;

                    if (Reward > 0.9)
                    {
                        if (Reward > 0.9f && Reward < 0.92f)
                        {
                            EarringsItem.Instance.EquipEarring("Azure");
                        }
                        else
                        {
                            switch (weaponType)
                            {
                                case 1:
                                    Weapons.Instance.EquipWeapon(Weapons.Instance.swords[weaponName]);
                                    break;

                                case 2:
                                    Weapons.Instance.EquipWeapon(Weapons.Instance.axes[weaponName]);
                                    break;

                                case 3:
                                    Weapons.Instance.EquipWeapon(Weapons.Instance.staffs[weaponName]);
                                    break;

                                case 4:
                                    Weapons.Instance.EquipWeapon(Weapons.Instance.wands[weaponName]);
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                    break;

                case 5:
                    Hp = 2 * 6;
                    CurrentHp = Hp;
                    Mp = 2 * 6;
                    CurrentMp = Mp;
                    Damage = 7 * 6;
                    Lvl = 5;
                    isAlive = true;

                    if (Reward > 0.9)
                    {
                        if (Reward > 0.9f && Reward < 0.92f)
                        {
                            EarringsItem.Instance.EquipEarring("Amethysy");
                        }
                        else
                        {
                            switch (weaponType)
                            {
                                case 1:
                                    Weapons.Instance.EquipWeapon(Weapons.Instance.swords[weaponName]);
                                    break;

                                case 2:
                                    Weapons.Instance.EquipWeapon(Weapons.Instance.axes[weaponName]);
                                    break;

                                case 3:
                                    Weapons.Instance.EquipWeapon(Weapons.Instance.staffs[weaponName]);
                                    break;

                                case 4:
                                    Weapons.Instance.EquipWeapon(Weapons.Instance.wands[weaponName]);
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                    break;

                default:
                    Hp = 8;
                    CurrentHp = Hp;
                    Mp = 0;
                    CurrentMp = Mp;
                    Damage = 7;
                    Lvl = 1;
                    isAlive = true;
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(x, y);
            Console.Write(EnemySymbol);
            Console.ResetColor();
            enemyList.Add(this);
        }

        public Enemy(int x, int y, string bossType)
        {
            bossPosUp = new Position(x, y);
            bossPosDown = new Position(x, y + 1);

            int dropRate = (int)Player.Instance.Luk + 1;
            switch (bossType)
            {
                case "Water":
                    Hp = 20;
                    CurrentHp = Hp;
                    Mp = 100;
                    CurrentMp = Mp;
                    Damage = 20;
                    BossType = "Water";
                    isAlive = true;

                    BossColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.SetCursorPosition(x, y);
                    Console.Write(BossUpperSymbol);
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write(BossUnderSymbol);
                    Console.ResetColor();
                    break;

                case "Steel":
                    Hp = 20* 2;
                    CurrentHp = Hp;
                    Mp = 300;
                    CurrentMp = Mp;
                    Damage = 20 * 2;
                    BossType = "Steel";
                    isAlive = true;

                    BossColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.SetCursorPosition(x, y);
                    Console.Write(BossUpperSymbol);
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write(BossUnderSymbol);
                    Console.ResetColor();
                    break;

                case "Fire":
                    Hp = 20* 4;
                    CurrentHp = Hp;
                    Mp = 1500;
                    CurrentMp = Mp;
                    Damage = 20 * 4;
                    BossType = "Fire";
                    isAlive = true;

                    BossColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(x, y);
                    Console.Write(BossUpperSymbol);
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write(BossUnderSymbol);
                    Console.ResetColor();
                    break;

                case "Nature":
                    Hp = 20 * 5;
                    CurrentHp = Hp;
                    Mp = 2500;
                    CurrentMp = Mp;
                    Damage = 20 * 5;
                    BossType = "Nature";
                    isAlive = true;

                    BossColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.SetCursorPosition(x, y);
                    Console.Write(BossUpperSymbol);
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write(BossUnderSymbol);
                    Console.ResetColor();
                    break;

                default:
                    Hp = 2;
                    CurrentHp = Hp;
                    Mp = 0;
                    CurrentMp = Mp;
                    Damage = 7;
                    isAlive = true;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(x, y);
                    Console.Write(BossUpperSymbol);
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write(BossUnderSymbol);
                    Console.ResetColor();
                    break;
            }

            bossList.Add(this);
        }

        public void MoveEnemy()
        {
            if (Math.Abs(Player.Instance.playerLoc.X - enemyPos.X) < 7 && Math.Abs(Player.Instance.playerLoc.Y - enemyPos.Y) < 5)
            {
                Console.SetCursorPosition(enemyPos.X, enemyPos.Y);
                Console.Write(MapGenerator.Instance.Blank);
                
                

                int moveX = CheckEnemyX();
                int moveY = CheckEnemyY();

                enemyPos.X += moveX;
                enemyPos.Y += moveY;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(enemyPos.X, enemyPos.Y);
                Console.Write(EnemySymbol);
                Console.ResetColor();
            }
        }

        public void MoveBoss()
        {

        }

        private int CheckEnemyY()
        {
            // if enemy is above player
            if (enemyPos.Y < Player.Instance.playerLoc.Y)
            {
                if (MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X] == MapGenerator.Instance.HoriWall || MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X] == MapGenerator.Instance.VertWall)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X] == MapGenerator.Instance.CornerTL || MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X] == MapGenerator.Instance.CornerTR)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X] == MapGenerator.Instance.CornerBL || MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X] == MapGenerator.Instance.CornerBR)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X - 1] == MapGenerator.Instance.CornerBL || MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X - 1] == MapGenerator.Instance.CornerBR)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X + 1] == MapGenerator.Instance.CornerBL || MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X + 1] == MapGenerator.Instance.CornerBR)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X - 1] == MapGenerator.Instance.CornerTL || MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X - 1] == MapGenerator.Instance.CornerTR)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X + 1] == MapGenerator.Instance.CornerTL || MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X + 1] == MapGenerator.Instance.CornerTR)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X] == EnemySymbol)
                {
                    return 0;
                }

                return 1;
            }
            // if enemy is below player
            else if (enemyPos.Y > Player.Instance.playerLoc.Y)
            {
                if (MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X] == MapGenerator.Instance.HoriWall || MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X] == MapGenerator.Instance.VertWall)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X] == MapGenerator.Instance.CornerTL || MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X] == MapGenerator.Instance.CornerTR)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X] == MapGenerator.Instance.CornerBL || MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X] == MapGenerator.Instance.CornerBR)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X] == EnemySymbol)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X - 1] == MapGenerator.Instance.CornerBL || MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X - 1] == MapGenerator.Instance.CornerBR)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X + 1] == MapGenerator.Instance.CornerBL || MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X + 1] == MapGenerator.Instance.CornerBR)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X - 1] == MapGenerator.Instance.CornerTL || MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X - 1] == MapGenerator.Instance.CornerTR)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X + 1] == MapGenerator.Instance.CornerTL || MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X + 1] == MapGenerator.Instance.CornerTR)
                {
                    return 0;
                }

                return -1;
            }
            else
            {
                return 0;
            }
        }
        private int CheckEnemyX()
        {
            // if enemy is Left of player
            if (enemyPos.X < Player.Instance.playerLoc.X)
            {
                if (MapGenerator.Instance.Map[enemyPos.Y, enemyPos.X + 1] == MapGenerator.Instance.VertWall || MapGenerator.Instance.Map[enemyPos.Y, enemyPos.X + 1] == MapGenerator.Instance.HoriWall)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y, enemyPos.X + 1] == MapGenerator.Instance.CornerTL || MapGenerator.Instance.Map[enemyPos.Y, enemyPos.X + 1] == MapGenerator.Instance.CornerTR)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y, enemyPos.X + 1] == MapGenerator.Instance.CornerBL || MapGenerator.Instance.Map[enemyPos.Y, enemyPos.X + 1] == MapGenerator.Instance.CornerBR)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y, enemyPos.X + 1] == EnemySymbol)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X + 1] == MapGenerator.Instance.CornerBL || MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X + 1] == MapGenerator.Instance.CornerBR)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X + 1] == MapGenerator.Instance.CornerBL || MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X + 1] == MapGenerator.Instance.CornerBR)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X + 1] == MapGenerator.Instance.CornerTL || MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X + 1] == MapGenerator.Instance.CornerTR)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X + 1] == MapGenerator.Instance.CornerTL || MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X + 1] == MapGenerator.Instance.CornerTR)
                {
                    return 0;
                }

                return 1;
            }
            // if enemy is Right of player
            else if (enemyPos.X > Player.Instance.playerLoc.X)
            {
                if (MapGenerator.Instance.Map[enemyPos.Y, enemyPos.X - 1] == MapGenerator.Instance.VertWall || MapGenerator.Instance.Map[enemyPos.Y, enemyPos.X - 1] == MapGenerator.Instance.HoriWall)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y, enemyPos.X - 1] == MapGenerator.Instance.CornerTL || MapGenerator.Instance.Map[enemyPos.Y, enemyPos.X - 1] == MapGenerator.Instance.CornerTR)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y, enemyPos.X - 1] == MapGenerator.Instance.CornerBL || MapGenerator.Instance.Map[enemyPos.Y, enemyPos.X - 1] == MapGenerator.Instance.CornerBR)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X - 1] == MapGenerator.Instance.CornerBL || MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X - 1] == MapGenerator.Instance.CornerBR)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X - 1] == MapGenerator.Instance.CornerBL || MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X - 1] == MapGenerator.Instance.CornerBR)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X - 1] == MapGenerator.Instance.CornerTL || MapGenerator.Instance.Map[enemyPos.Y - 1, enemyPos.X - 1] == MapGenerator.Instance.CornerTR)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X - 1] == MapGenerator.Instance.CornerTL || MapGenerator.Instance.Map[enemyPos.Y + 1, enemyPos.X - 1] == MapGenerator.Instance.CornerTR)
                {
                    return 0;
                }

                if (MapGenerator.Instance.Map[enemyPos.Y, enemyPos.X - 1] == EnemySymbol)
                {
                    return 0;
                }

                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
