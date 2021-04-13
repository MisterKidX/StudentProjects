using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject101_RonBandel
{
    class TemplateFunctions
    {
        public TemplateFunctions()
        { }

        public void PrintDetails()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("1.a - ");
            Console.WriteLine("1.b - ");
            Console.WriteLine("1.c - ");
            Console.WriteLine("1.d - ");
            Console.WriteLine("1.e - ");


            return;
        }

        public void DrawQuestionLine(string question, string option)
        {
            int stringLength = question.Length;
            int numberOfLines = 37;

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            switch (option)
            {
                case "Beginning":
                    for (int i = 0; i < numberOfLines; i++)
                    {
                        Console.Write("-");
                    }
                    Console.Write("( " + question + " )");
                    for (int i = 0; i < numberOfLines; i++)
                    {
                        Console.Write("-");
                    }
                    break;

                case "End":
                    for (int i = 0; i < ((2 * numberOfLines) + stringLength + 4); i++) // 4 = "( " + " )"
                    {
                        Console.Write("-");
                    }
                    break;
            }
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Gray;


        }

        public void DrawErrorLine()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-------------------------------------( Error )-------------------------------------");
            Console.WriteLine();

            Console.WriteLine("Invalid question number!");

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n");
        }
    }
}
