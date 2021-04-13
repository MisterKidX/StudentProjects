using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryFinal
{
    class GameGen
    {
        public Game creatGame(int level)
        {
            Game game = new Game(level);
            return game;
        }
    }
}
