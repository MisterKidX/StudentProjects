using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    class DataBoard
    {
        private static DataBoard _dataInstance = null;
        public static DataBoard GetDataInstance
        {
            get
            {
                if (_dataInstance == null)
                {
                    _dataInstance = new DataBoard();
                }
                return _dataInstance;
            }
        }

        string[,] data = new string[5, 60];
        public void PrintData()
        {
            Console.SetCursorPosition(0,30);
            Console.WriteLine();
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    data[i,j] = " ";
                    data[0, j] = "-";
                    data[data.GetLength(0) - 1, j] = "-";
                    data[0, 0] = "|";
                    data[0, data.GetLength(1) - 1] = "|";
                    data[data.GetLength(0) - 1,0] = "|";
                    data[data.GetLength(0)-1, data.GetLength(1) - 1] = "|";
                    DataCalling(i,j);
                    Console.Write(data[i, j]);
                }
                Console.WriteLine("");
            }            
            
        }
        private void DataCalling(int i, int j)
        {
           data[1,1] = "HP " + Player.GetPlayerInstance.PlayerHP;
           data[2,1] = "Level: " + Player.GetPlayerInstance.Level;
           data[3,1] = "Coins: " + Player.GetPlayerInstance.Coins;                       
        }
    }
}
