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
    class Logger
    {
        private int _limit;
        private Queue<string> _loggs;

        public Logger()
        {
            _limit = 5;
            _loggs = new Queue<string>();
            for (int i = 0; i < _limit; i++)
            {
                _loggs.Enqueue(" ");
            }
        }
        public void AddToLog(string strToAdd)
        {
            if(_loggs.Count()<_limit)
            {
                _loggs.Enqueue(DateTime.Now.ToString() + ":" + strToAdd);
            }
            else
            {
                _loggs.Dequeue();
                _loggs.Enqueue(DateTime.Now.ToString() + ":" + strToAdd);
            }
        }
        public void PrintLog()
        {
            Console.WriteLine("********************************************************");
            foreach (var log in _loggs)
            {
                Console.WriteLine("* " + log );
            }
            Console.WriteLine("********************************************************");
        }
        public void ChangeLoggerLimit()
        {
            Console.Clear();
            Console.WriteLine("What limit do you want for your log?");
            int newLimit = int.Parse(Console.ReadLine());
            _limit = newLimit;
        }
    }
}
