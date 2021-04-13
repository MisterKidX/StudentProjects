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
    class Map
    {
        private char[,] _fullMap;
        private int _colomnSize;
        private int _rowSize;
        private Player _player;
        private List<Coordinate> _enemiesPosition;
        private List<Coordinate> _trapsPosition;
        private List<Coordinate> _treasuresPosition;

        public Map(int level, Player player)
        {
            Random rand = new Random();
            _rowSize = level + 5;
            _colomnSize = _rowSize * 2;

            _fullMap = new char[_colomnSize, _rowSize];
            _player = player;
            _enemiesPosition = new List<Coordinate>();
            _trapsPosition = new List<Coordinate>();
            _treasuresPosition = new List<Coordinate>();

            for (int i = 0; i < level - 4; i++)
            {
                bool again = true;

                // Add enemies
                while (again)
                {
                    int colE = rand.Next(1, _colomnSize - 2);
                    Thread.Sleep(1);
                    int rowE = rand.Next(1, _rowSize - 1);
                    Thread.Sleep(1);
                    Coordinate enemyCoordinate = new Coordinate(colE, rowE);
                    if (_fullMap[colE, rowE] == 0 &&
                        CoordinateFree(enemyCoordinate, _enemiesPosition) &&
                        CoordinateFree(enemyCoordinate, _trapsPosition) &&
                        CoordinateFree(enemyCoordinate, _treasuresPosition))
                    {
                        _enemiesPosition.Add(enemyCoordinate);
                        again = false;
                    }
                }

                again = true;

                // Add trap
                while (again)
                {
                    int colTp = rand.Next(1, _colomnSize - 2);
                    Thread.Sleep(1);
                    int rowTp = rand.Next(1, _rowSize - 1);
                    Thread.Sleep(1);
                    Coordinate trapCoordinate = new Coordinate(colTp, rowTp);
                    if (_fullMap[colTp, rowTp] == 0 &&
                        CoordinateFree(trapCoordinate, _enemiesPosition) &&
                        CoordinateFree(trapCoordinate, _trapsPosition) &&
                        CoordinateFree(trapCoordinate, _treasuresPosition))
                    {
                        _trapsPosition.Add(trapCoordinate);
                        again = false;
                    }
                }

                again = true;
                // Add treasure
                while (again)
                {
                    int colTr = rand.Next(1, _colomnSize - 2);
                    Thread.Sleep(1);
                    int rowTr = rand.Next(1, _rowSize - 1);
                    Thread.Sleep(1);
                    Coordinate treasureCoordinate = new Coordinate(colTr, rowTr);
                    if (_fullMap[colTr, rowTr] == 0 &&
                        CoordinateFree(treasureCoordinate, _enemiesPosition) &&
                        CoordinateFree(treasureCoordinate, _trapsPosition) &&
                        CoordinateFree(treasureCoordinate, _treasuresPosition))
                    {
                        _treasuresPosition.Add(treasureCoordinate);
                        again = false;
                    }
                }
            }

            BuildMap();
        }
        public void PrintMap()
        {
            _fullMap[1, 1] = 'S';
            for (int i = 0; i < _rowSize; i++)
            {
                for (int j = 0; j < _colomnSize; j++)
                {
                    Console.Write(_fullMap[j, i]);
                }
                Console.WriteLine();
            }
        }
        private bool CoordinateFree(Coordinate coordinate, List<Coordinate> tocheck)
        {
            foreach (var item in tocheck)
            {
                if (item.Colomn == coordinate.Colomn && item.Row == coordinate.Row)
                {
                    return false;
                }
            }

            return true;
        }
        private void BuildMap()
        {
            // Draw map border
            for (int i = 0; i < _colomnSize; i++)
            {
                _fullMap[i, 0] = '-';
                _fullMap[i, _rowSize - 1] = '-';
            }
            for (int i = 0; i < _rowSize; i++)
            {
                _fullMap[0, i] = '|';
                _fullMap[_colomnSize - 1, i] = '|';
            }

            // Exit
            bool again = true;
            Random rand = new Random();
            while (again)
            {
                int colX = rand.Next(1, _colomnSize - 2);
                Thread.Sleep(1);
                int rowX = rand.Next(1, _rowSize - 1);
                Thread.Sleep(1);
                Coordinate exitCoordinate = new Coordinate(colX, rowX);
                if (_fullMap[colX, rowX] == 0 &&
                    CoordinateFree(exitCoordinate, _enemiesPosition) &&
                    CoordinateFree(exitCoordinate, _trapsPosition) &&
                    CoordinateFree(exitCoordinate, _treasuresPosition))
                {
                    _fullMap[colX, rowX] = 'X';
                    again = false;
                }

                // Player position
                Coordinate playerPositon = _player.GetPlayerPosition();
                _fullMap[playerPositon.Row, playerPositon.Colomn] = '@';

                foreach (var enemy in _enemiesPosition)
                {
                    _fullMap[enemy.Colomn, enemy.Row] = 'E';
                }

                foreach (var treasure in _treasuresPosition)
                {
                    _fullMap[treasure.Colomn, treasure.Row] = 'T';
                }
            }
        }
        public char PlayerMove(int addToRow, int addToCol)
        {
            Coordinate playerPos = _player.GetPlayerPosition();
            Coordinate nextPosition = new Coordinate(playerPos.Colomn + addToCol, playerPos.Row + addToRow);
            if (playerPos.Row + addToRow < _rowSize - 1 &&
                playerPos.Row + addToRow >= 1 &&
                playerPos.Colomn + addToCol < _colomnSize - 1 &&
                playerPos.Colomn + addToCol >= 1)
            {
                char whatToReturn = _fullMap[nextPosition.Colomn, nextPosition.Row];
                _fullMap[playerPos.Colomn, playerPos.Row] = ' ';
                _player.UpdatePlayerPosition(nextPosition);
                _fullMap[nextPosition.Colomn, nextPosition.Row] = '@';
                if (!CoordinateFree(nextPosition, _trapsPosition))
                {
                    _fullMap[nextPosition.Colomn, nextPosition.Row] = 'R';
                    return 'R';
                }

                return whatToReturn;
            }
            else
            {
                return '9';
            }
        }

    }
}
