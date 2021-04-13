using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryFinal
{
    class Player
    {
        char player;
        public string name;
        public int currentHP;
        public int baseHP;
        public int dmg = 0;
        public int maxDmg;
        int redo = 0;
        int col;
        int row;
        int cShield;
        int coin;
        int bShield = 3;
        public int trap = 5;
        MapGenerator map;
        Enemies enemy = new Enemies(10, 5);

        Game game;
        
        // Enemies e = new Enemies('m',5,6);
        public Player(char player, int col, int raw, int hp, int damage, int coin, MapGenerator map)
        {
            this.player = player;
            this.col = col;
            this.row = raw;
            this.map = map;
            this.coin = coin;
            baseHP = hp;
            currentHP = hp;
            dmg = damage;
            maxDmg = 15;                
        }
        public Player(int hp)
        {
            this.currentHP = hp;
            this.baseHP = hp;
        }

        public int getRow()
        {
            return this.row;
        }

        public int getCol()
        {
            return this.col;
        }

        //public char Location()
        //{
        //    Console.SetCursorPosition(col, row);
        //    return Location();
        //}

        public void movePlayer(int level)
        {
            //SET the Row AND COL OF PLAYER
            do
            {

                ConsoleKeyInfo keyinfo;
                keyinfo = Console.ReadKey(true);
                Console.BackgroundColor = ConsoleColor.Black;

                switch (keyinfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (map.getValue(row, col + 1) != '#' && map.getValue(row, col + 1) != '*' && map.getValue(row, col + 1) != 'M')
                        {
                            Console.Write("");
                            col++;
                            Interactable(row, col, level);
                        }


                        DrawPlayer(col - 1, row);
                        break;

                    case ConsoleKey.LeftArrow:
                        if (map.getValue(row, col - 1) != '#' && map.getValue(row, col - 1) != '*' && map.getValue(row, col - 1) != 'M')
                        {
                            col--;
                            Interactable(row, col, level);

                        }

                        DrawPlayer(col + 1, row);
                        break;

                    case ConsoleKey.UpArrow:
                        if (map.getValue(row - 1, col) != '#' && map.getValue(row - 1, col) != '*' && map.getValue(row - 1, col) != 'M')
                        {
                            row--;
                            Interactable(row, col, level);

                        }

                        DrawPlayer(col, row + 1);
                        break;

                    case ConsoleKey.DownArrow:
                        if (map.getValue(row + 1, col) != '#' && map.getValue(row + 1, col) != '*' && map.getValue(row + 1, col) != 'M')
                        {
                            row++;
                            Interactable(row, col, level);
                        }


                        DrawPlayer(col, row - 1);
                        break;



                }
            } while (redo == 0);
            Console.ReadLine();
        }
        public void DrawPlayer(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(" ");           
            colorCul();

            if (map.getValue(y, x) == 'E')
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine('E');
            }

            else if (map.getValue(y, x) == '#')
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine('#');
            }
            else if (map.getValue(y, x) == '*')
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine('*');
            }

            Console.SetCursorPosition(this.col, this.row);
            Console.Write(this.player);
        }

        public void Interactable(int x, int y, int level)
        {
            if (map.getValue(x, y) == '$')
            {
                Rewards();
                clearLine();
                Console.WriteLine(playerStats());
                map.clearObject(x, y);
            }
            else if (map.getValue(x, y) == ' ')
            {
                this.currentHP -= trap;
                Console.SetCursorPosition(0, 25);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Write("You Fell Into A TRAP , - 5 HP!!!");
                clearLine();
                Console.WriteLine(playerStats());
                colorCul();
            }
            else if (map.getValue(x, y) == 'M' || map.getValue(x, y + 1) == 'M' || map.getValue(x, y - 1) == 'M' || map.getValue(x + 1, y) == 'M' || map.getValue(x - 1, y) == 'M')
            {
                               
                if (enemy.HP >= 0)
                {
                    enemy.HP -= dmg;
                    this.currentHP -= enemy.dmg;
                    //   clearEnemyLog(50, 0);
                    clearLog(0, 23);
                    Console.SetCursorPosition(0, 25);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Enemy Bite You, -" + enemy.dmg  + " HP!!!");
                    Console.Write("RUN AWAY!!!");
                    clearLine();
                    Console.WriteLine(playerStats());
                    // enemy.enemiesStats(map.level);
                    Console.WriteLine(enemy.enemyStats());
                    colorCul();

                }
                else if (enemy.HP <= 0)
                {
                    map.clearObject(x, y);
                    map.clearObject(x, y + 1);
                    map.clearObject(x, y - 1);
                    map.clearObject(x + 1, y);
                    map.clearObject(x - 1, y);
                    Console.SetCursorPosition(0, 22);
                    Console.Write(new string(' ', Console.BufferWidth - Console.CursorLeft));
                }
            }
            else if (map.getValue(x, y) == 'X')
            {
                GameGen game = new GameGen();
                Console.Clear();
                level++;
                Game gamee = game.creatGame(level);
            }
        }

     //   public void LevelUP(int level)
     //   {
           // Interactable(this.row, this.col);
     //       level++;


    //    }


        public void Rewards()
        {
            Random rand = new Random();
            int reward;
            reward = rand.Next(0, 6);
            int bonus = 3;
            int swordAttack = 7;
            // string sword;
            int num = 25;

            switch (reward)
            {

                case 0:
                    if (currentHP >= baseHP)
                    {
                        clearLog(0, num);
                        currentHP = baseHP;
                        Console.SetCursorPosition(0, num);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write("Your HP is Full!");
                    }

                    else
                    {
                        clearLog(0, num);
                        this.currentHP += bonus;
                        Console.SetCursorPosition(0, num);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write("You Got +3 HP!");
                    }


                    break;

                case 1:
                    if (dmg >= maxDmg - 3)
                    {
                        bonus = maxDmg - dmg;
                        dmg = maxDmg;
                        clearLog(0, num);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("You Got " + bonus + " DMG!");
                        Console.Write("You Have Max DMG");
                    }
                    else
                    {
                        clearLog(0, num);
                        this.dmg += bonus;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write("You Got " + "+" + bonus + " DMG!");
                    }

                    break;

                case 2:
                    if (dmg >= maxDmg - 7)
                    {
                        swordAttack = maxDmg - dmg;
                        dmg = maxDmg;
                        clearLog(0, num);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("You Found A Titan Sword Which Grant You " + swordAttack + " DMG!");
                        Console.Write("You Have Max DMG");
                    }
                    else
                    {
                        clearLog(0, num);
                        this.dmg += swordAttack;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write("You Found A Titan Sword Which Grant You " + swordAttack + " DMG!");
                    }

                    break;

                case 3:

                    if (cShield >= bShield)
                    {
                        clearLog(0, num);
                        cShield = bShield;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write("You Shield Is FULL!");
                    }
                    else
                    {
                        clearLog(0, num);
                        cShield += bonus;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write("You Got +3 Shield!");
                    }

                    break;
                case 4:
                    {
                        clearLog(0, num);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write("This Treasure Is Empty :(");
                    }
                    break;
                case 5:
                    clearLog(0, num);
                    coin += bonus;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("You Got Some GOLD! +3G");

                    break;

            }
        }

        public string playerStats()
        {            //Console.WriteLine("\u2794");
            Console.SetCursorPosition(0, 21);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            return  "HP = " + currentHP + "/" + baseHP + "    " + "Dmg = " + dmg + "    " + "Shield = " + cShield + "/" + bShield + "    " + "Gold = " + coin + "G";
        }

        public string PlayerName()
        {
            Console.SetCursorPosition(0, 20);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Red;
            return name;
        }

        public void colorCul()
        {
            Console.SetCursorPosition(getCol(), getRow());
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static void clearLine()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 21);
            Console.Write(new string(' ', Console.BufferWidth - Console.CursorLeft));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 22);
            Console.Write(new string(' ', Console.BufferWidth - Console.CursorLeft));
        }

        public static void clearLog(int x, int y)
        {
            
            Console.SetCursorPosition(x, y);
            Console.Write(new string(' ', Console.BufferWidth - Console.CursorLeft));
            Console.SetCursorPosition(x, y + 1);
            Console.Write(new string(' ', Console.BufferWidth - Console.CursorLeft));
            Console.SetCursorPosition(x, y);           
        }
        public static void clearEnemyLog(int x, int y)
        {

            Console.SetCursorPosition(x, y);
            Console.Write(new string(' ', Console.BufferWidth - Console.CursorLeft));
            Console.SetCursorPosition(x, y + 1);
            Console.Write(new string(' ', Console.BufferWidth - Console.CursorLeft));
            Console.SetCursorPosition(x, y + 2);
            Console.Write(new string(' ', Console.BufferWidth - Console.CursorLeft));
            Console.SetCursorPosition(x, y + 3);
            Console.Write(new string(' ', Console.BufferWidth - Console.CursorLeft));
            Console.SetCursorPosition(x, y + 4);
            Console.Write(new string(' ', Console.BufferWidth - Console.CursorLeft));
            Console.SetCursorPosition(x, y + 5);
            Console.Write(new string(' ', Console.BufferWidth - Console.CursorLeft));
            Console.SetCursorPosition(x, y + 6);
            Console.Write(new string(' ', Console.BufferWidth - Console.CursorLeft));
            Console.SetCursorPosition(x, y + 7);
            Console.Write(new string(' ', Console.BufferWidth - Console.CursorLeft));
        }

        //public static void enemyCreator(MapGenerator map , int level)
        //{
        //    Enemies enemy = map.drawEnemy('M', level);
        //    Player player = map.drawPlayer('@', level); //retruns enemy
        //}

    }
}
