using System;

namespace ArrayRogLike
{
    class Program
    {
        static void Main(string[] args)
        {
            Map board = new Map();
            Console.Clear();
            board.NewLevel();
            board.PrintUI();
            while (!board.key.Equals('Q') && board.player.life > 0)
            {
                if (board.key.Equals('N'))
                {
                    Console.Clear();
                    board.NewLevel();
                }
                else
                if (board.key.Equals('W') || board.key.Equals(ConsoleKey.UpArrow))
                {
                    board.MoveUp();
                }
                else
                if (board.key.Equals('S') || board.key.Equals(ConsoleKey.DownArrow))
                {
                    board.MoveDown();
                }
                else
                if (board.key.Equals('D') || board.key.Equals(ConsoleKey.RightArrow))
                {
                    board.MoveRight();
                }
                else
                if (board.key.Equals('A') || board.key.Equals(ConsoleKey.LeftArrow))
                {
                    board.MoveLeft();
                }
                board.PrintUI();
            }

            Console.Clear();
            Console.Write("Thank you for playing! Your LEVEL is: " + board.level.level + "! and your SCORE is: " + board.player.money + "!");
            Console.ReadKey(true);


        }

    }
}
