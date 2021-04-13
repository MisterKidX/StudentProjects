using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int level = 1;
            GameMechanic game1 = new GameMechanic();
            game1.moveplayer();

            while (true)
            {
                if(level != game1.level)
                {
                    GameMechanic game = new GameMechanic();
                    game.moveplayer();
                    level = game.level;
                }
            } 
        }
    }
}
