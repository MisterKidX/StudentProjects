// ---- C# 101 (Dor Ben Dor) ----
//         Alla Makarov
//          01/03/2021
// ------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RPGgame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            gameManager.ShowMainMenu();
        }
    }
}
