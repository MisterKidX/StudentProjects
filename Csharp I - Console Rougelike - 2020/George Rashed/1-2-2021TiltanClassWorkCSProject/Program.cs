using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_2_2021TiltanClassWorkCSProject
{
    class Program
    {
        // --------------- C# 101 (Dor Ben Dor) ---------------
        //                     George Rashed
        //                 Due Date: 1/3/2021
        // ----------------------------------------------------

        // ----------------------CS Project--------------------



        static void Main(string[] args)
        {
            bool gameInit = true;
            while (gameInit) 
            {
                EventController game = new EventController();

                game.RunningTheGame();
                gameInit = true;

            } // Game Init While Loop Closer

        } // Main Closer
    }
}
