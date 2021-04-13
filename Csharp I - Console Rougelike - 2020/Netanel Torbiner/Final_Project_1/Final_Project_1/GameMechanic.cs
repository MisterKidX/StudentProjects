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
    class GameMechanic
    {
        private Player player;
        private mapGenerator map;
        private Treasure treasure;
        private Enemy enemy;
        private Traps traps;
        private SupriseQ supriseQ;
        private Sounds sounds;
        public int level;
        ConsoleKeyInfo keyinfo;
        System.Timers.Timer EnemyTimer = new System.Timers.Timer();
        System.Timers.Timer EnemyTimer1 = new System.Timers.Timer();
        System.Timers.Timer EnemyTimer2 = new System.Timers.Timer();


        public GameMechanic()
        {
            player = new Player();
            map = new mapGenerator(20, 50);
            treasure = new Treasure();
            enemy = new Enemy();
            traps = new Traps();
            sounds = new Sounds();
            supriseQ = new SupriseQ();
            level = 1;
            GenerateLevel();

        }
        public void moveplayer()
        {
            GeneratePlayer(player.getplayersynbol(), player.getWidth(), player.getlength());
            ConsoleKeyInfo keyinfo; 
            while (true)
            {
                keyinfo = Console.ReadKey(true);
                setnewposition(' ', player.getWidth(), player.getlength());

                switch (keyinfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        player.setWidth(player.getWidth() + 1);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        GeneratePlayer(player.getplayersynbol(), player.getWidth(), player.getlength());
                        Console.ResetColor();
                        break;

                    case ConsoleKey.LeftArrow:
                        player.setWidth(player.getWidth() - 1);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        GeneratePlayer(player.getplayersynbol(), player.getWidth(), player.getlength());
                        Console.ResetColor();
                        break;

                    case ConsoleKey.UpArrow:
                        player.setlength(player.getlength() - 1);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        GeneratePlayer(player.getplayersynbol(), player.getWidth(), player.getlength());
                        Console.ResetColor();
                        break;

                    case ConsoleKey.DownArrow:
                        player.setlength(player.getlength() + 1);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        GeneratePlayer(player.getplayersynbol(), player.getWidth(), player.getlength());
                        Console.ResetColor();
                        break;
                    default:
                        GeneratePlayer(player.getplayersynbol(), player.getWidth(), player.getlength());
                        break;
                }

                if (player.getlength() == 0 && keyinfo.Key == ConsoleKey.UpArrow)
                {
                    sounds.HitBorderS.Play();
                    setnewposition('-', player.getWidth(), player.getlength());
                    HitBorder();
                    player.setlength(player.getlength() + 1);
                    GeneratePlayer(player.getplayersynbol(), player.getWidth(), player.getlength());
                }
                if (player.getlength() == 19 && keyinfo.Key == ConsoleKey.DownArrow)
                {
                    sounds.HitBorderS.Play();
                    setnewposition('-', player.getWidth(), player.getlength());
                    HitBorder();
                    player.setlength(player.getlength() - 1);
                    GeneratePlayer(player.getplayersynbol(), player.getWidth(), player.getlength());
                }
                if (player.getWidth() == 0 && keyinfo.Key == ConsoleKey.LeftArrow)
                {
                    sounds.HitBorderS.Play();
                    setnewposition('|', player.getWidth(), player.getlength());
                    HitBorder();
                    player.setWidth(player.getWidth() + 1);
                    GeneratePlayer(player.getplayersynbol(), player.getWidth(), player.getlength());
                }
                if (player.getWidth() == 49 && keyinfo.Key == ConsoleKey.RightArrow)
                {
                    sounds.HitBorderS.Play();
                    setnewposition('|', player.getWidth(), player.getlength());
                    HitBorder();
                    player.setWidth(player.getWidth() - 1);
                    GeneratePlayer(player.getplayersynbol(), player.getWidth(), player.getlength());
                }
                if (player.getlength() == 0 && keyinfo.Key == ConsoleKey.UpArrow)
                {
                    sounds.HitBorderS.Play();
                    setnewposition('-', player.getWidth(), player.getlength());
                    HitBorder();
                    player.setlength(player.getlength() + 1);
                    GeneratePlayer(player.getplayersynbol(), player.getWidth(), player.getlength());
                }
                if (player.getWidth() == 1 && player.getlength() == 1 && keyinfo.Key == ConsoleKey.LeftArrow)
                {
                    sounds.HitBorderS.Play();
                    GenerateEntrance('E', 1, 1);
                    HitBorder();
                    player.setWidth(player.getWidth() + 1);
                    GeneratePlayer(player.getplayersynbol(), player.getWidth(), player.getlength());
                }
                if (player.getWidth() == 1 && player.getlength() == 1 && keyinfo.Key == ConsoleKey.UpArrow)
                {
                    sounds.HitBorderS.Play();
                    GenerateEntrance('E', 1, 1);
                    HitBorder();
                    player.setlength(player.getlength() + 1);
                    GeneratePlayer(player.getplayersynbol(), player.getWidth(), player.getlength());
                }
                if (map.getMap()[18, 48] == '♥' && keyinfo.Key == ConsoleKey.DownArrow)
                {
                    sounds.HitBorderS.Play();
                    GenerateExit('X', 48, 18);
                    Console.SetCursorPosition(50, 8);
                    Console.WriteLine("Collect All Treasures to Proceed to next level                  ");
                    player.setlength(player.getlength() - 1);
                    GeneratePlayer(player.getplayersynbol(), player.getWidth(), player.getlength());
                }
                if (map.getMap()[18, 48] == '♥' && keyinfo.Key == ConsoleKey.RightArrow)
                {
                    sounds.HitBorderS.Play();
                    GenerateExit('X', 48, 18);
                    Console.SetCursorPosition(50, 8);
                    Console.WriteLine("Collect All Treasures to Proceed to next level                  ");
                    player.setWidth(player.getWidth() - 1);
                    GeneratePlayer(player.getplayersynbol(), player.getWidth(), player.getlength());
                }
                EnemyPosMechanic();
                ExitLevel();
                CollectTreasure();
                StepOnTrap();
                StepOnSupriseQ();
                WonEnemy();
                PlayerDead();

            }
        }
        //public void SwitchfromLeftToRight()
        //{
        //    if (enemy.width == 0)
        //    {
        //        setnewpositionborder('|', enemy.width, enemy.length);
        //        newTimer1.Stop();
        //        newTimer.Interval = 1000;
        //        newTimer.Start();
        //        newTimer.Elapsed += new ElapsedEventHandler(EnemyRight);
        //    }
        //}
        //public void SwitchfromRighToLeft()
        //{
        //    if (enemy.width == 49)
        //    {
        //        setnewpositionborder('|', enemy.width, enemy.length);
        //        enemy.setWidth(enemy.width-1);
        //        setnewpositionEnemy(enemy.playersymbol, enemy.width, enemy.length);
        //        newTimer.Stop();
        //        newTimer1.Interval = 1000;
        //        newTimer1.Start();
        //        newTimer1.Elapsed += new ElapsedEventHandler(EnemyLeft);
        //    }
        //}
        public void setnewposition(char c, int row, int col)
        {
            map.insertomap(c, row, col);
            Console.SetCursorPosition(row, col);
            Console.Write(c);
        }
        public void GenerateEntrance(char c, int row, int col)
        {
            map.insertomap(c, row, col);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(row, col);
            Console.Write(c);
            Console.ResetColor();
        }
        public void GenerateExit(char c, int row, int col)
        {
            map.insertomap(c, row, col);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(row, col);
            Console.Write(c);
            Console.ResetColor();
        }
        public void HitBorder()
        {
            //OneSecTimer();
            Console.SetCursorPosition(50, 7);
            Console.WriteLine("You Hit the border                              ");
        }
        public void GenerateUI()
        {
            Console.SetCursorPosition(0, 21);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("E = Entrance ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("X = Exit ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("♥ = Player ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("M = Guards ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("☻ = Attacking Monster ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("# = Treasure \n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Level:{0} || Score:{1} || HP:{2} || Enemy Damage:{3} || Monster Damage:{4} || Good Luck !", level, player.score, player.health, enemy.damage, enemy.MonsterDamage);
            Console.ResetColor();
        }
        public void GeneratePlayer(char c, int row, int col)
        {
            map.insertomap(c, row, col);
            Console.SetCursorPosition(row, col);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(c);
            Console.ResetColor();
        }
        public void GenerateSupriseQ(char c, int row, int col)
        {
            map.insertomap(c, row, col);
            Console.SetCursorPosition(row, col);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(c);
        }
        public void GenerateTreasure(char c, int row, int col)
        {
            map.insertomap(c, row, col);
            Console.SetCursorPosition(row, col);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(c);
        }
        public void GenerateMonster(char c, int row, int col)
        {
            map.insertomap(c, row, col);
            Console.SetCursorPosition(row, col);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(c);
            Console.ResetColor();
        }
        public void GenerateEnemy(char c, int row, int col)
        {
            map.insertomap(c, row, col);
            Console.SetCursorPosition(row, col);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(c);
        }
        public void GenerateTraps(char c, int row, int col)
        {
            map.insertomap(c, row, col);
            Console.SetCursorPosition(row, col);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(c);
        }
        public bool ExitLevel()
        {
            if (map.getMap()[17, 48] == '♥' || map.getMap()[18, 47] == '♥')
            {
                sounds.LevelAdvanced.Play();
                EnemyTimer.Stop();
                EnemyTimer1.Stop();
                EnemyTimer2.Stop();
                level += 1;
                Console.SetCursorPosition(50, 7);
                Console.WriteLine("You advanced to next level                                   ");
                Thread.Sleep(2000);
                GenerateUI();
                GenerateLevel();
                return true;
            }
            return false;
        }
        public void CollectTreasure()
        {
            if (player.getWidth() == treasure.width && player.getlength() == treasure.length)
            {
                sounds.TreasureSound.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You collect a treasure (+25 Points)                              ");
                player.score += 25;
                treasure.setWidth(0);
                treasure.setlength(0);
                GenerateUI();
            }
            if (player.getWidth() == treasure.width1 && player.getlength() == treasure.length1)
            {
                sounds.TreasureSound.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You collect a treasure (+25 Points)                              ");
                player.score += 25;
                treasure.setWidth1(0);
                treasure.setlength1(0);
                GenerateUI();
            }
            if (player.getWidth() == treasure.width2 && player.getlength() == treasure.length2)
            {
                sounds.TreasureSound.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You collect a treasure (+25 Points)                              ");
                player.score += 25;
                treasure.setWidth2(0);
                treasure.setlength2(0);
                GenerateUI();
            }
            if (player.getWidth() == treasure.width3 && player.getlength() == treasure.length3)
            {
                sounds.TreasureSound.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You collect a treasure (+25 Points)                              ");
                player.score += 25;
                treasure.setWidth3(0);
                treasure.setlength3(0);
                GenerateUI();
            }
            if (player.getWidth() == treasure.width4 && player.getlength() == treasure.length4)
            {
                sounds.TreasureSound.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You collect a treasure (+25 Points)                              ");
                player.score += 25;
                treasure.setWidth4(0);
                treasure.setlength4(0);
                GenerateUI();
            }
            if (treasure.width == 0 && treasure.width1 == 0 && treasure.width2 == 0 && treasure.width3 == 0 && treasure.width4 == 0 &&
                treasure.length == 0 && treasure.length1 == 0 && treasure.length2 == 0 && treasure.length3 == 0 && treasure.length4 == 0)
            {
                Console.SetCursorPosition(50, 8);
                Console.Write("You Have Collected all Treasures");
            }
        }
        public void StepOnSupriseQ()
        {
            if (player.getWidth() == supriseQ.width && player.getlength() == supriseQ.length)
            {
                //OneSecTimer();
                sounds.TreasureSound.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You Recieve 15 Points Bonus                          ");
                player.score += 15;
                supriseQ.setWidth(0);
                supriseQ.setlength(0);
                GenerateUI();
            }
            if (player.getWidth() == supriseQ.width1 && player.getlength() == supriseQ.length1)
            {
                sounds.TreasureSound.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You Recieve 25 HP                                  ");
                player.health += 25;
                supriseQ.setWidth1(0);
                supriseQ.setlength1(0);
                if (player.health > 100)
                {
                    player.health = 100;
                    GenerateUI();
                }
                GenerateUI();
            }
            if (player.getWidth() == supriseQ.width2 && player.getlength() == supriseQ.length2)
            {
                sounds.FoughtEnemy.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You Lost 10 HP                                    ");
                player.health -= 10;
                supriseQ.setWidth2(0);
                supriseQ.setlength2(0);
                GenerateUI();
            }
            if (player.getWidth() == supriseQ.width3 && player.getlength() == supriseQ.length3)
            {
                sounds.TreasureSound.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You Recieve Mega-Bonus of 100 Points              ");
                player.score += 100;
                supriseQ.setWidth3(0);
                supriseQ.setlength3(0);
                GenerateUI();
            }
            if (player.getWidth() == supriseQ.width4 && player.getlength() == supriseQ.length4)
            {
                sounds.FoughtEnemy.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You Lost 30 HP                                    ");
                player.health -= 30;
                supriseQ.setWidth4(0);
                supriseQ.setlength4(0);
            }
        }
        public void StepOnTrap()
        {
            if (player.getWidth() == traps.width && player.getlength() == traps.length)
            {
                sounds.TrapSound.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You Step On Trap (-20 Health)          ");
                player.health -= 20;
                traps.setWidth(0);
                traps.setlength(0);
                GenerateUI();
            }
            if (player.getWidth() == traps.width1 && player.getlength() == traps.length1)
            {
                sounds.TrapSound.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You Step On Trap (-20 Health)           ");
                player.health -= 20;
                traps.setWidth1(0);
                traps.setlength1(0);
                GenerateUI();
            }
            if (player.getWidth() == traps.width2 && player.getlength() == traps.length2)
            {
                sounds.TrapSound.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You Step On Trap (-20 Health)           ");
                player.health -= 20;
                traps.setWidth2(0);
                traps.setlength2(0);
                GenerateUI();
            }
            if (player.getWidth() == traps.width3 && player.getlength() == traps.length3)
            {
                sounds.TrapSound.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You Step On Trap (-20 Health)           ");
                player.health -= 20;
                traps.setWidth3(0);
                traps.setlength3(0);
                GenerateUI();
            }
            if (player.getWidth() == traps.width4 && player.getlength() == traps.length4 && (level == 2 || level == 3))
            {
                sounds.TrapSound.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You Step On Trap (-20 Health)           ");
                player.health -= 20;
                traps.setWidth4(0);
                traps.setlength4(0);
                GenerateUI();
            }
            if (player.getWidth() == traps.width5 && player.getlength() == traps.length5 && (level == 2 || level == 3))
            {
                sounds.TrapSound.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You Step On Trap (-20 Health)           ");
                player.health -= 20;
                traps.setWidth5(0);
                traps.setlength5(0);
                GenerateUI();
            }
            if (player.getWidth() == traps.width6 && player.getlength() == traps.length6 && (level == 2 || level == 3))
            {
                sounds.TrapSound.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You Step On Trap (-20 Health)           ");
                player.health -= 20;
                traps.setWidth6(0);
                traps.setlength6(0);
                GenerateUI();
            }
            if (player.getWidth() == traps.width7 && player.getlength() == traps.length7 && (level == 2 || level == 3))
            {
                sounds.TrapSound.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You Step On Trap (-20 Health)           ");
                player.health -= 20;
                traps.setWidth7(0);
                traps.setlength7(0);
                GenerateUI();
            }
            if (player.getWidth() == traps.width8 && player.getlength() == traps.length8 && level == 3)
            {
                sounds.TrapSound.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You Step On Trap (-20 Health)           ");
                player.health -= 20;
                traps.setWidth8(0);
                traps.setlength8(0);
                GenerateUI();
            }
            if (player.getWidth() == traps.width9 && player.getlength() == traps.length9 && level == 3)
            {
                sounds.TrapSound.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You Step On Trap (-20 Health)           ");
                player.health -= 20;
                traps.setWidth9(0);
                traps.setlength9(0);
                GenerateUI();
            }
        }
        public bool WonEnemy()
        {
            if (player.getWidth() == enemy.width && player.getlength() == enemy.length)
            {
                EnemyTimer.Stop();
                EnemyTimer1.Stop();
                EnemyTimer2.Stop();
                sounds.FoughtEnemy.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You fought Monster Catch you (-{0} Health)  ", enemy.MonsterDamage);
                player.health -= enemy.MonsterDamage;
                player.score += 50;
                GeneratePlayer('♥', player.width, player.length);
                enemy.setWidth(0);
                enemy.setlength(0);
                GenerateUI();
                return true;
            }
            if (player.getWidth() == enemy.width1 && player.getlength() == enemy.length1)
            {
                sounds.FoughtEnemy.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You fought Guard and wins (-{0} Health)  ", enemy.damage);
                player.health -= enemy.damage;
                player.score += 20;
                enemy.setWidth1(0);
                enemy.setlength1(0);
                GenerateUI();
                return true;
            }
            if (player.getWidth() == enemy.width2 && player.getlength() == enemy.length2)
            {
                //OneSecTimer();
                sounds.FoughtEnemy.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You fought Guard and wins (-{0} Health)  ", enemy.damage);
                player.health -= enemy.damage;
                player.score += 20;
                enemy.setWidth2(0);
                enemy.setlength2(0);
                GenerateUI();
                return true;
            }
            if (player.getWidth() == enemy.width3 && player.getlength() == enemy.length3 && (level == 2 || level == 3))
            {
                sounds.FoughtEnemy.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You fought Guard and wins (-{0} Health)  ", enemy.damage);
                player.health -= enemy.damage;
                player.score += 20;
                enemy.setWidth3(0);
                enemy.setlength3(0);
                GenerateUI();
                return true;
            }
            if (player.getWidth() == enemy.width4 && player.getlength() == enemy.length4 && (level == 2 || level == 3))
            {
                //OneSecTimer();
                sounds.FoughtEnemy.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You fought Guard and wins (-{0} Health)  ", enemy.damage);
                player.health -= enemy.damage;
                player.score += 20;
                enemy.setWidth4(0);
                enemy.setlength4(0);
                GenerateUI();
                return true;
            }
            if (player.getWidth() == enemy.width5 && player.getlength() == enemy.length5 && level == 3)
            {
                //OneSecTimer();
                sounds.FoughtEnemy.Play();
                Console.SetCursorPosition(50, 7);
                Console.Write("You fought Guard and wins (-{0} Health)  ", enemy.damage);
                player.health -= enemy.damage;
                player.score += 20;
                enemy.setWidth5(0);
                enemy.setlength5(0);
                GenerateUI();
                return true;
            }
            return false;
        }
        public void EnemyPosMechanic()
        {
            //Monster On Treasure - Generate Treasure Again
            if ((enemy.width == treasure.width  + 2 || enemy.width == treasure.width  - 2) && (enemy.length == treasure.length || enemy.length == treasure.length - 2 || enemy.length == treasure.length + 2))
            {
                //EnemyTimer1.Interval = (100);
                //EnemyTimer1.Start();
                //EnemyTimer1.AutoReset = false;
                //EnemyTimer.Elapsed += new ElapsedEventHandler(GenerateTreasure);
                GenerateTreasure('#', treasure.width, treasure.length);
            }
            if ((enemy.width == treasure.width1 + 2 || enemy.width == treasure.width1 - 2) && (enemy.length == treasure.length1 || enemy.length == treasure.length1 - 2 || enemy.length == treasure.length1 + 2))
            {
                //EnemyTimer1.Interval = (100);
                //EnemyTimer1.Start();
                //EnemyTimer1.AutoReset = false;
                //EnemyTimer.Elapsed += new ElapsedEventHandler(GenerateTreasure1);
                GenerateTreasure('#', treasure.width1, treasure.length1);
            }
            if ((enemy.width == treasure.width2 + 2 || enemy.width == treasure.width2 - 2) && (enemy.length == treasure.length2 || enemy.length == treasure.length2 - 2 || enemy.length == treasure.length2 + 2))
            {
                //EnemyTimer1.Interval = (100);
                //EnemyTimer1.Start();
                //EnemyTimer1.AutoReset = false;
                //EnemyTimer.Elapsed += new ElapsedEventHandler(GenerateTreasure2);
                GenerateTreasure('#', treasure.width2, treasure.length2);
            }
            if ((enemy.width == treasure.width3 + 2 || enemy.width == treasure.width3 - 2) && (enemy.length == treasure.length3 || enemy.length == treasure.length3 - 2 || enemy.length == treasure.length3 + 2))
            {
                //EnemyTimer1.Interval = (100);
                //EnemyTimer1.Start();
                //EnemyTimer1.AutoReset = false;
                //EnemyTimer.Elapsed += new ElapsedEventHandler(GenerateTreasure3);
                GenerateTreasure('#', treasure.width3, treasure.length3);
            }
            if ((enemy.width == treasure.width4 + 2 || enemy.width == treasure.width4 - 2) && (enemy.length == treasure.length4 || enemy.length == treasure.length4 - 2 || enemy.length == treasure.length4 + 2))
            {
                //EnemyTimer1.Interval = (100);
                //EnemyTimer1.Start();
                //EnemyTimer1.AutoReset = false;
                //EnemyTimer.Elapsed += new ElapsedEventHandler(GenerateTreasure4);
                GenerateTreasure('#', treasure.width4, treasure.length4);
            }
            if ((enemy.width == treasure.width || enemy.width == treasure.width + 2 || enemy.width == treasure.width - 2) && (enemy.length == treasure.length  - 2 || enemy.length == treasure.length  + 2))
            {
                //EnemyTimer1.Interval = (100);
                //EnemyTimer1.Start();
                //EnemyTimer1.AutoReset = false;
                //EnemyTimer.Elapsed += new ElapsedEventHandler(GenerateTreasure);
                GenerateTreasure('#', treasure.width, treasure.length);
            }
            if ((enemy.width == treasure.width1 || enemy.width == treasure.width1 + 2 || enemy.width == treasure.width1 - 2) && (enemy.length == treasure.length1 - 2 || enemy.length == treasure.length1 + 2))
            {
                //EnemyTimer1.Interval = (100);
                //EnemyTimer1.Start();
                //EnemyTimer1.AutoReset = false;
                //EnemyTimer.Elapsed += new ElapsedEventHandler(GenerateTreasure1);
                GenerateTreasure('#', treasure.width1, treasure.length1);
            }
            if ((enemy.width == treasure.width2 || enemy.width == treasure.width2 + 2 || enemy.width == treasure.width2 - 2) && (enemy.length == treasure.length2 - 2 || enemy.length == treasure.length2 + 2))
            {
                //EnemyTimer1.Interval = (100);
                //EnemyTimer1.Start();
                //EnemyTimer1.AutoReset = false;
                //EnemyTimer.Elapsed += new ElapsedEventHandler(GenerateTreasure2);
                GenerateTreasure('#', treasure.width2, treasure.length2);
            }
            if ((enemy.width == treasure.width3 || enemy.width == treasure.width3 + 2 || enemy.width == treasure.width3 - 2) && (enemy.length == treasure.length3 - 2 || enemy.length == treasure.length3 + 2))
            {
                GenerateTreasure('#', treasure.width3, treasure.length3);
            }
            if ((enemy.width == treasure.width4 || enemy.width == treasure.width4 + 2 || enemy.width == treasure.width4 - 2) && (enemy.length == treasure.length4 - 2 || enemy.length == treasure.length4 + 2))
            {
                //EnemyTimer1.Interval = (100);
                //EnemyTimer1.Start();
                //EnemyTimer1.AutoReset = false;
                //EnemyTimer.Elapsed += new ElapsedEventHandler(GenerateTreasure4);
                GenerateTreasure('#', treasure.width4, treasure.length4);
            }
            //Monster On Suprise Q - Generate Suprise Q Again
            if ((enemy.width == supriseQ.width + 2 || enemy.width == supriseQ.width - 2) && (enemy.length == supriseQ.length || enemy.length == supriseQ.length - 2 || enemy.length == supriseQ.length + 2))
            {
                GenerateSupriseQ('?', supriseQ.width, supriseQ.length);
            }
            if ((enemy.width == supriseQ.width1 + 2 || enemy.width == supriseQ.width1 - 2) && (enemy.length == supriseQ.length1 || enemy.length == supriseQ.length1 - 2 || enemy.length == supriseQ.length1 + 2))
            {
                GenerateSupriseQ('?', supriseQ.width1, supriseQ.length1);
            }
            if ((enemy.width == supriseQ.width2 + 2 || enemy.width == supriseQ.width2 - 2) && (enemy.length == supriseQ.length2 || enemy.length == supriseQ.length2 - 2 || enemy.length == supriseQ.length2 + 2))
            {
                GenerateSupriseQ('?', supriseQ.width2, supriseQ.length2);
            }
            if ((enemy.width == supriseQ.width3 + 2 || enemy.width == supriseQ.width3 - 2) && (enemy.length == supriseQ.length3 || enemy.length == supriseQ.length3 - 2 || enemy.length == supriseQ.length3 + 2))
            {
                GenerateSupriseQ('?', supriseQ.width3, supriseQ.length3);
            }
            if ((enemy.width == supriseQ.width4 + 2 || enemy.width == supriseQ.width4 - 2) && (enemy.length == supriseQ.length4 || enemy.length == supriseQ.length4 - 2 || enemy.length == supriseQ.length4 + 2))
            {
                GenerateSupriseQ('?', supriseQ.width4, supriseQ.length4);
            }
            if ((enemy.width == supriseQ.width || enemy.width == supriseQ.width + 2 || enemy.width == supriseQ.width - 2) && (enemy.length == supriseQ.length - 2 || enemy.length == supriseQ.length + 2))
            {
                GenerateSupriseQ('?', supriseQ.width, supriseQ.length);
            }
            if ((enemy.width == supriseQ.width1 || enemy.width == supriseQ.width1 + 2 || enemy.width == supriseQ.width1 - 2) && (enemy.length == supriseQ.length1 - 2 || enemy.length == supriseQ.length1 + 2))
            {
                GenerateSupriseQ('?', supriseQ.width1, supriseQ.length1);
            }
            if ((enemy.width == supriseQ.width2 || enemy.width == supriseQ.width2 + 2 || enemy.width == supriseQ.width2 - 2) && (enemy.length == supriseQ.length2 - 2 || enemy.length == supriseQ.length2 + 2))
            {
                GenerateSupriseQ('?', supriseQ.width2, supriseQ.length2);
            }
            if ((enemy.width == supriseQ.width3 || enemy.width == supriseQ.width3 + 2 || enemy.width == supriseQ.width3 - 2) && (enemy.length == supriseQ.length3 - 2 || enemy.length == supriseQ.length3 + 2))
            {
                GenerateSupriseQ('?', supriseQ.width3, supriseQ.length3);
            }
            if ((enemy.width == supriseQ.width4 || enemy.width == supriseQ.width4 + 2 || enemy.width == supriseQ.width4 - 2) && (enemy.length == supriseQ.length4 - 2 || enemy.length == supriseQ.length4 + 2))
            {
                GenerateSupriseQ('?', supriseQ.width4, supriseQ.length4);
            }
        }
        public void PlayerDead()
        {
            if (player.health <= 0)
            {
                Console.Clear();
                sounds.LostSound.Play();
                Console.SetCursorPosition(5, 5);
                Console.WriteLine("Game Over");
                Console.WriteLine("Press 'R' to Restart");
                keyinfo = Console.ReadKey(true);
                RestartGame();
            }
        }
        public bool TimerDiposed()
        {
            if (player.health <= 0)
            {
                EnemyTimer.Dispose();
                EnemyTimer1.Dispose();
                EnemyTimer2.Dispose();
                return true;
            }
            return false;
        }
        public void GenerateLevel()
        {
            if (level == 1)
            {
                Console.Clear();
                player.health = 100;
                player.score = 0;
                enemy.damage = 20;
                enemy.MonsterDamage = 35;
                map.insertIslandToMap();
                map.insertIsland2ToMap();
                map.insertIsland3ToMap();
                map.generateMap();
                setnewposition(' ', player.getWidth(), player.getlength());
                GenerateElementsRandom();
                player.setWidth(2);
                player.setlength(1);
                GeneratePlayer(player.getplayersynbol(), player.width, player.length);
                GenerateSupriseQ(supriseQ.playersymbol, supriseQ.width, supriseQ.length);
                GenerateSupriseQ(supriseQ.playersymbol, supriseQ.width1, supriseQ.length1);
                GenerateSupriseQ(supriseQ.playersymbol, supriseQ.width2, supriseQ.length2);
                GenerateSupriseQ(supriseQ.playersymbol, supriseQ.width3, supriseQ.length3);
                GenerateSupriseQ(supriseQ.playersymbol, supriseQ.width4, supriseQ.length4);
                GenerateTreasure(treasure.playersymbol, treasure.width, treasure.length);
                GenerateTreasure(treasure.playersymbol, treasure.width1, treasure.length1);
                GenerateTreasure(treasure.playersymbol, treasure.width2, treasure.length2);
                GenerateTreasure(treasure.playersymbol, treasure.width3, treasure.length3);
                GenerateTreasure(treasure.playersymbol, treasure.width4, treasure.length4);
                GenerateMonster('☻', enemy.width, enemy.length);
                GenerateEnemy(enemy.playersymbol, enemy.width1, enemy.length1);
                GenerateEnemy(enemy.playersymbol, enemy.width2, enemy.length2);
                GenerateTraps(traps.playersymbol, traps.width, traps.length);
                GenerateTraps(traps.playersymbol, traps.width1, traps.length1);
                GenerateTraps(traps.playersymbol, traps.width2, traps.length2);
                GenerateTraps(traps.playersymbol, traps.width3, traps.length3);
                GenerateTraps(traps.playersymbol, traps.width4, traps.length4);
                GenerateTraps(traps.playersymbol, traps.width5, traps.length5);
                GenerateTraps(traps.playersymbol, traps.width6, traps.length6);
                GenerateTraps(traps.playersymbol, traps.width7, traps.length7);
                EnemyTimer.Interval = 700;
                EnemyTimer.Start();
                EnemyTimer.Elapsed += new ElapsedEventHandler(MoveEnemy);
                GenerateUI();
            }
            if (level == 2)
            {
                Console.Clear();
                EnemyTimer.Dispose();
                enemy.damage = 40;
                enemy.MonsterDamage = 60;
                map.insertIslandToMap();
                map.insertIsland2ToMap();
                map.insertIsland3ToMap();
                map.generateMap();
                setnewposition(' ', player.getWidth(), player.getlength());
                GenerateElementsRandom();
                player.setWidth(2);
                player.setlength(1);
                GeneratePlayer(player.getplayersynbol(), player.width, player.length);
                GenerateSupriseQ(supriseQ.playersymbol, supriseQ.width, supriseQ.length);
                GenerateSupriseQ(supriseQ.playersymbol, supriseQ.width1, supriseQ.length1);
                GenerateSupriseQ(supriseQ.playersymbol, supriseQ.width2, supriseQ.length2);
                GenerateSupriseQ(supriseQ.playersymbol, supriseQ.width3, supriseQ.length3);
                GenerateSupriseQ(supriseQ.playersymbol, supriseQ.width4, supriseQ.length4);
                GenerateTreasure(treasure.playersymbol, treasure.width, treasure.length);
                GenerateTreasure(treasure.playersymbol, treasure.width1, treasure.length1);
                GenerateTreasure(treasure.playersymbol, treasure.width2, treasure.length2);
                GenerateTreasure(treasure.playersymbol, treasure.width3, treasure.length3);
                GenerateTreasure(treasure.playersymbol, treasure.width4, treasure.length4);
                GenerateMonster('☻', enemy.width, enemy.length);
                GenerateEnemy(enemy.playersymbol, enemy.width1, enemy.length1);
                GenerateEnemy(enemy.playersymbol, enemy.width2, enemy.length2);
                GenerateEnemy(enemy.playersymbol, enemy.width3, enemy.length3);
                GenerateEnemy(enemy.playersymbol, enemy.width4, enemy.length4);
                GenerateTraps(traps.playersymbol, traps.width, traps.length);
                GenerateTraps(traps.playersymbol, traps.width1, traps.length1);
                GenerateTraps(traps.playersymbol, traps.width2, traps.length2);
                GenerateTraps(traps.playersymbol, traps.width3, traps.length3);
                GenerateTraps(traps.playersymbol, traps.width4, traps.length4);
                GenerateTraps(traps.playersymbol, traps.width5, traps.length5);
                GenerateTraps(traps.playersymbol, traps.width6, traps.length6);
                GenerateTraps(traps.playersymbol, traps.width7, traps.length7);
                EnemyTimer1.Interval = 600;
                EnemyTimer1.Start();
                EnemyTimer1.Elapsed += new ElapsedEventHandler(MoveEnemy);
                GenerateUI();
            }
            if (level == 3)
            {
                Random rand = new Random();
                EnemyTimer1.Dispose();
                Console.Clear();
                enemy.damage = 60;
                enemy.MonsterDamage = 80;
                map.insertIslandToMap();
                map.insertIsland2ToMap();
                map.generateMap();
                setnewposition(' ', player.getWidth(), player.getlength());
                GenerateElementsRandom();
                player.setWidth(2);
                player.setlength(1);
                GeneratePlayer(player.getplayersynbol(), player.width, player.length);
                GenerateSupriseQ(supriseQ.playersymbol, supriseQ.width, supriseQ.length);
                GenerateSupriseQ(supriseQ.playersymbol, supriseQ.width1, supriseQ.length1);
                GenerateSupriseQ(supriseQ.playersymbol, supriseQ.width2, supriseQ.length2);
                GenerateSupriseQ(supriseQ.playersymbol, supriseQ.width3, supriseQ.length3);
                GenerateSupriseQ(supriseQ.playersymbol, supriseQ.width4, supriseQ.length4);
                GenerateTreasure(treasure.playersymbol, treasure.width, treasure.length);
                GenerateTreasure(treasure.playersymbol, treasure.width1, treasure.length1);
                GenerateTreasure(treasure.playersymbol, treasure.width2, treasure.length2);
                GenerateTreasure(treasure.playersymbol, treasure.width3, treasure.length3);
                GenerateTreasure(treasure.playersymbol, treasure.width4, treasure.length4);
                GenerateMonster('☻', enemy.width, enemy.length);
                GenerateEnemy(enemy.playersymbol, enemy.width1, enemy.length1);
                GenerateEnemy(enemy.playersymbol, enemy.width2, enemy.length2);
                GenerateEnemy(enemy.playersymbol, enemy.width3, enemy.length3);
                GenerateEnemy(enemy.playersymbol, enemy.width4, enemy.length4);
                GenerateEnemy(enemy.playersymbol, enemy.width5, enemy.length5);
                GenerateTraps(traps.playersymbol, traps.width, traps.length);
                GenerateTraps(traps.playersymbol, traps.width1, traps.length1);
                GenerateTraps(traps.playersymbol, traps.width2, traps.length2);
                GenerateTraps(traps.playersymbol, traps.width3, traps.length3);
                GenerateTraps(traps.playersymbol, traps.width4, traps.length4);
                GenerateTraps(traps.playersymbol, traps.width5, traps.length5);
                GenerateTraps(traps.playersymbol, traps.width6, traps.length6);
                GenerateTraps(traps.playersymbol, traps.width7, traps.length7);
                GenerateTraps(traps.playersymbol, traps.width8, traps.length8);
                GenerateTraps(traps.playersymbol, traps.width9, traps.length9);
                EnemyTimer2.Interval = 500;
                EnemyTimer2.Start();
                EnemyTimer2.Elapsed += new ElapsedEventHandler(MoveEnemy);
                GenerateUI();
            }
            if (level == 4)
            {
                EnemyTimer2.Dispose();
                Console.Clear();
                sounds.GameWon.Play();
                Console.SetCursorPosition(5, 5);
                Console.WriteLine("You Have Won The Game!!!");
                Console.SetCursorPosition(5, 6);
                Console.WriteLine("Press 'R' to Restart");
                keyinfo = Console.ReadKey(true);
                RestartGame();
            }
        }
        public void GenerateElementsRandom()
        {
            Random rand = new Random();
            if (treasure.length == 0 && treasure.width == 0)
            {
                treasure.setlength(rand.Next(2, 17));
                treasure.setWidth(rand.Next(2, 47));
            }
            if (treasure.length1 == 0 && treasure.width1 == 0)
            {
                treasure.setlength1(rand.Next(5, 12));
                treasure.setWidth1(rand.Next(6, 28));
            }
            if (treasure.length2 == 0 && treasure.width2 == 0)
            {
                treasure.setlength2(rand.Next(8, 16));
                treasure.setWidth2(rand.Next(30, 44));
            }
            if (treasure.length3 == 0 && treasure.width3 == 0)
            {
                treasure.setlength3(rand.Next(4, 8));
                treasure.setWidth3(rand.Next(9, 27));
            }
            if (treasure.length4 == 0 && treasure.width4 == 0)
            {
                treasure.setlength4(rand.Next(6, 14));
                treasure.setWidth4(rand.Next(5, 30));
            }
            if (supriseQ.length == 0 && supriseQ.width == 0)
            {
                supriseQ.setlength(rand.Next(5, 8));
                supriseQ.setWidth(rand.Next(7, 21));
            }
            if (supriseQ.length1 == 0 && supriseQ.width1 == 0)
            {
                supriseQ.setlength1(rand.Next(2, 7));
                supriseQ.setWidth1(rand.Next(6, 34));
            }
            if (supriseQ.length2 == 0 && supriseQ.width2 == 0)
            {
                supriseQ.setlength2(rand.Next(2, 7));
                supriseQ.setWidth2(rand.Next(8, 29));
            }
            if (supriseQ.length3 == 0 && supriseQ.width3 == 0)
            {
                supriseQ.setlength3(rand.Next(5, 14));
                supriseQ.setWidth3(rand.Next(10, 20));
            }
            if (supriseQ.length4 == 0 && supriseQ.width4 == 0)
            {
                supriseQ.setlength4(rand.Next(4, 13));
                supriseQ.setWidth4(rand.Next(21, 44));
            }
            if (traps.length == 0 && traps.width == 0)
            {
                traps.setlength(rand.Next(3, 7));
                traps.setWidth(rand.Next(4, 38));
            }
            if (traps.length1 == 0 && traps.width1 == 0)
            {
                traps.setlength1(rand.Next(3, 15));
                traps.setWidth1(rand.Next(7, 33));
            }
            if (traps.length2 == 0 && traps.width2 == 0)
            {
                traps.setlength2(rand.Next(6, 14));
                traps.setWidth2(rand.Next(10, 47));
            }
            if (traps.length3 == 0 && traps.width3 == 0)
            {
                traps.setlength3(rand.Next(11, 17));
                traps.setWidth3(rand.Next(5, 40));
            }
            if (traps.length4 == 0 && traps.width4 == 0)
            {
                traps.setlength4(rand.Next(4, 12));
                traps.setWidth4(rand.Next(10, 28));
            }
            if (traps.length5 == 0 && traps.width5 == 0)
            {
                traps.setlength5(rand.Next(2, 10));
                traps.setWidth5(rand.Next(16, 41));
            }
            if (traps.length6 == 0 && traps.width6 == 0)
            {
                traps.setlength6(rand.Next(14, 17));
                traps.setWidth6(rand.Next(2, 37));
            }
            if (traps.length7 == 0 && traps.width7 == 0)
            {
                traps.setlength7(rand.Next(8, 18));
                traps.setWidth7(rand.Next(14, 26));
            }
            if (traps.length8 == 0 && traps.width8 == 0)
            {
                traps.setlength8(rand.Next(5, 13));
                traps.setWidth8(rand.Next(7, 15));
            }
            if (traps.length9 == 0 && traps.width9 == 0)
            {
                traps.setlength9(rand.Next(2, 14));
                traps.setWidth9(rand.Next(16, 40));
            }
            if (enemy.length == 0 && enemy.width == 0)
            {
                enemy.setlength(rand.Next(2, 17));
                enemy.setWidth(rand.Next(2, 47));
            }
            if (enemy.length1 == 0 && enemy.width1 == 0)
            {
                enemy.setlength1(rand.Next(5, 10));
                enemy.setWidth1(rand.Next(11, 37));
            }
            if (enemy.length2 == 0 && enemy.width2 == 0)
            {
                enemy.setlength2(rand.Next(7, 11));
                enemy.setWidth2(rand.Next(6, 41));
            }
            if (enemy.length3 == 0 && enemy.width3 == 0)
            {
                enemy.setlength3(rand.Next(7, 15));
                enemy.setWidth3(rand.Next(23, 44));
            }
            if (enemy.length4 == 0 && enemy.width4 == 0)
            {
                enemy.setlength4(rand.Next(12, 14));
                enemy.setWidth4(rand.Next(8, 40));
            }
            if (enemy.length5 == 0 && enemy.width5 == 0)
            {
                enemy.setlength5(rand.Next(3, 9));
                enemy.setWidth5(rand.Next(14, 27));
            }
        }
        public void MoveEnemy(Object source, ElapsedEventArgs e)
        {
            int num = 0;
            if (player.length == enemy.length && player.width > enemy.width)
            {
                num = 0;
            }
            if (player.length == enemy.length && player.width < enemy.width)
            {
                num = 1;
            }
            if (player.length > enemy.length && player.width != enemy.width)
            {
                num = 2;
            }
            if (player.length < enemy.length && player.width != enemy.width)
            {
                num = 3;
            }
            if (num == 0)//right
            {
                enemy.setWidth(enemy.width + 1);
                setnewposition(' ', enemy.width - 1, enemy.length);
                GenerateMonster('☻', enemy.width, enemy.length);
            }
            if (num == 1)//Left
            {
                enemy.setWidth(enemy.width - 1);
                setnewposition(' ', enemy.width + 1, enemy.length);
                GenerateMonster('☻', enemy.width, enemy.length);
            }
            if (num == 2)//Down
            {
                enemy.setlength(enemy.length + 1);
                setnewposition(' ', enemy.width, enemy.length - 1);
                GenerateMonster('☻', enemy.width, enemy.length);
            }
            if (num == 3)//Up
            {
                enemy.setlength(enemy.length - 1);
                setnewposition(' ', enemy.width, enemy.length + 1);
                GenerateMonster('☻', enemy.width, enemy.length);
            }
            EnemyPosMechanic();
            ExitLevel();
            CollectTreasure();
            StepOnTrap();
            StepOnSupriseQ();
            WonEnemy();
            PlayerDead();
        }
        public void RestartGame()
        {
           if (keyinfo.Key == ConsoleKey.R)
            {
                level = 1;
                GenerateLevel();
            }
        }
    }
}
