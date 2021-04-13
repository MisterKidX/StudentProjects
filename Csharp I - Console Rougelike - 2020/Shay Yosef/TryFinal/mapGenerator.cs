using System;

namespace TryFinal
{
    class MapGenerator
    {
        char[,] map;
        int height;
        int width;
        Player player;
        Enemies enemy;
        public int level;

        public MapGenerator(int height, int width , int level)
        {
            /**
             @param height - the height of the map
             @param width - the width of the map
             */
            map = new char[height, width];
            this.height = height;
            this.width = width;
            this.player = null;
            Random rand = new Random();
            // Divide the to two regions
            generateIslands(level);
            generatMap(level);
            this.level = level;

        }

        public void generatIsland(Random rand, int start, int end , int startup , int enddown )
        {
            /**
             * generatisland on the map randomly in the region of the map
             * start - starting point of the region
             * end - end point of the region
             * 
             * 
             */

            // Generate randomly the size of the island
            int height = rand.Next(3, 6);
            int width = rand.Next(5, 8);

            // Get location of the island
            int x = rand.Next(startup , enddown - height);  // this.height - height
            int y = rand.Next(start, end - width);

            

            // Draw the island
            while (true)
            {

                if (x > 1 && x + height < 17 && y > 1 && y + width < 44)
                {
                    break;
                }
                else
                {
                    x = rand.Next(startup, enddown - height);
                    y = rand.Next(start, end - width);
                }
            }

            for (int i = x; i < x + height + 1; i++)
            {
                for (int j = y; j < y + width; j++)
                {
                    if (i == x || i == x + height || j == y + width - 1 || j == y)
                    {
                        map[i, j] = '*';
                    }
                    else
                    {
                        map[i, j] = '^';
                    }
                    //map[height + x, j] = '*';
                    //map[i, y] = '*';
                    //map[i, width + y] = '*';
                }
            }
        }

        internal Player drawPlayer(char pplayer , int level)
        {
            // Player player = null;
            // decide where to put the enemy

            int x_start, x_end;
            x_start = 1;
            x_end = this.width;
            Random rand = new Random();


            int x = rand.Next(x_start, x_end);
            int y = rand.Next(1, this.height);

            while (true)
            {
                if (this.map[y, x] == 'E')
                {
                    //this.map[y, x] = pplayer;
                    break;
                }
                else
                {
                    x = rand.Next(x_start, x_end);
                    y = rand.Next(1, this.height);
                }
            }


            player = new Player('@', x, y, 10 * level , 0 , 0 , this);
            
            return player;
            
        }

        public Enemies drawEnemy(char cenemy , int level)
        {
            // Enemies enemy = null;
            //decide where to put the enemy

            int x_start, x_end;
            x_start = 1;
            x_end = this.width;
            Random rand = new Random();
            

            int x = rand.Next(x_start, x_end);
            int y = rand.Next(1, this.height);

            while (true)
            {
                if (this.map[y, x] == 0)
                {
                    this.map[y, x] = cenemy;
                    break;
                }
                else
                {
                    x = rand.Next(x_start, x_end);
                    y = rand.Next(1, this.height);
                }
            }


            enemy = new Enemies(cenemy, x, y, 10 * level , 5 * level );

            return enemy;
        }

        public char getValue(int row, int col)
        {
            return this.map[row, col];
        }

        public void generatMap(int level)
        {
            // Map boundaries
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {                  
                    map[0, j] = '#';
                    map[this.height - 1, j] = '#';
                    map[i, 0] = '#';
                    map[i, this.width - 1] = '#';
                }
            }
            // Draw the map 
            DrawObjLevel(level);
        }
        public void drawMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);                  
                }
                Console.WriteLine("");
            }
            Console.SetCursorPosition(player.getCol(), player.getRow());           
            Console.WriteLine('@');
            Console.WriteLine(player.PlayerName());
            Console.WriteLine(player.playerStats());
            Console.WriteLine(enemy.enemyStats());
            // enemy.enemiesStats(level);

        }
        public void DrawObjects(char obj)
        {

            int x_start, x_end;
            x_start = 1;
            x_end = this.width;           
            Random rand = new Random();
            if (obj == 'E')
            {
                x_start = 1;
                x_end = this.width / 4;
                //int x = rand.Next(1, this.width / 2);
            }
            else if(obj == 'X')
            {
                x_start = this.width / 2;
                x_end = this.width; 
                // int x = rand.Next(this.width / 2, this.width);
            }

            int x = rand.Next(x_start, x_end);
            int y = rand.Next(1, this.height);
  
            while (true)
            {
                if (this.map[y, x] == 0)
                {
                    this.map[y, x] = obj;
                    break;
                }
                else
                {
                    x = rand.Next(x_start, x_end);
                    y = rand.Next(1, this.height);
                }
            }

        }

        public void clearObject(int x,int y)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            this.map[x, y] = '\0';
        }

        public void generateIslands(int level)
        {
            Random rand = new Random();           
            if (level == 1)
            {
                generatIsland(rand, 0, this.width , 0 , this.height);
            }
            else if (level == 2)
            {
                generatIsland(rand, 0 , this.width , 0 , this.height);
            }
            else if (level == 3)
            {
                generatIsland(rand, 0, this.width / 2 , 0, this.height);
                generatIsland(rand, this.width / 2, this.width , 0, this.height);
            }
            else if (level == 4)
            {
                generatIsland(rand, 0, this.width - 35 , 0, this.height);
                generatIsland(rand, this.width - 34, this.width - 20 , 0, this.height);
                generatIsland(rand, this.width - 19, this.width , 0, this.height);
            }
            else if (level == 5)
            {
                generatIsland(rand, 0 , this.width - 25 , 0 , this.height - 10 );
                generatIsland(rand, 0 , this.width - 25 , this.height - 10 , this.height);
                generatIsland(rand, this.width - 25, this.width , 0, this.height - 10);
                generatIsland(rand, this.width - 25, this.width, this.height - 10 , this.height);
            }
        }


        public void DrawObjLevel(int level)
        {
            if(level == 1)
            {
                DrawObjects('E');
                DrawObjects('X');
                DrawObjects('$');
                DrawObjects(' ');
            }
            else if(level == 2)
            {
                DrawObjects('E');
                DrawObjects('X');
                DrawObjects('$');
                DrawObjects('$');
                DrawObjects(' ');
                DrawObjects(' ');
            }
            else if(level == 3)
            {
                DrawObjects('E');
                DrawObjects('X');
                DrawObjects('$');
                DrawObjects('$');
                DrawObjects('$');
                DrawObjects(' ');
                DrawObjects(' ');
                DrawObjects(' ');
            }
            else if(level == 4)
            {
                DrawObjects('E');
                DrawObjects('X');
                DrawObjects('$');
                DrawObjects('$');
                DrawObjects('$');
                DrawObjects('$');
                DrawObjects('$');
                DrawObjects(' ');
                DrawObjects(' ');
                DrawObjects(' ');
                DrawObjects(' ');
            }
            else if(level == 5)
            {
                DrawObjects('E');
                DrawObjects('X');
                DrawObjects('$');
                DrawObjects('$');
                DrawObjects('$');
                DrawObjects('$');
                DrawObjects('$');
                DrawObjects('$');
                DrawObjects('$');
                DrawObjects(' ');
                DrawObjects(' ');
                DrawObjects(' ');
                DrawObjects(' ');
                DrawObjects(' ');
                DrawObjects(' ');
                DrawObjects(' ');
            }
        }

        public void CreatEnemy(int level)
        {
            if (level == 1)
            {
                drawEnemy('M', level);
            }
            else if (level == 2)
            {
                drawEnemy('M', level);
                drawEnemy('M', level);
            }
            else if(level == 3)
            {
                drawEnemy('M', level);
                drawEnemy('M', level);
                drawEnemy('M', level);
            }
            else if(level == 4)
            {
                drawEnemy('M', level);
                drawEnemy('M', level);
                drawEnemy('M', level);
                drawEnemy('M', level);
                drawEnemy('M', level);
            }
            else if(level == 5)
            {
                drawEnemy('M', level);
                drawEnemy('M', level);
                drawEnemy('M', level);
                drawEnemy('M', level);
                drawEnemy('M', level);
                drawEnemy('M', level);
                drawEnemy('M', level);
                drawEnemy('M', level);
            }

        }
        /**
         DRAW SET PLAYER NEW LOCATION AND UPDATE PLAYER ONE MAP
        WHILE PROGRAM IS WAITING MOVE ENEM,Y

       
         * **/
    }
}
