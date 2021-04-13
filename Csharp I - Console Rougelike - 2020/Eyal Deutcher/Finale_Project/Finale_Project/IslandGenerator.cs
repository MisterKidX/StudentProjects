using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    class IslandGenerator
    {
        Position position = new Position();
        Random random = new Random();
        int _islandHight;
        int _islandLength;
        public IslandGenerator(int mapHight, int mapLength)
        {
            float islandsHightFloat = mapHight / 10;
            _islandHight = (int)islandsHightFloat;
            if (_islandHight == 0)
            {
                _islandHight = 1;
            }
            float islandsLengthFloat = mapLength / 10;
            _islandLength = (int)islandsLengthFloat;
            if (_islandLength == 0)
            {
                _islandLength = 1;
            }
        }
        public void CreateIslands(int islandsToCreate, Map map)
        {
            int thisMapHightStart = map.hightStart;
            thisMapHightStart++;
            int thisMapHightEnd = map.hightEnd;
            thisMapHightEnd -= _islandHight;
            int thisMapLengthStart = map.lengthStart;
            thisMapLengthStart++;
            int thisMapLengthEnd = map.lengthEnd;
            thisMapLengthEnd -= _islandLength;
            while (islandsToCreate != 0)
            {
                //map.PrintMap(); //for Debuging
                int randomI = random.Next(thisMapHightStart, thisMapHightEnd);
                int randomJ = random.Next(thisMapLengthStart, thisMapLengthEnd);
                int thisIslandHight = _islandHight;
                thisIslandHight += randomI;
                int thisIslandLength = _islandLength;
                thisIslandLength += randomJ;
                for (int i = randomI; i < thisIslandHight; i++)
                {
                    int lastI = i;
                    lastI--;
                    int secondLastI = lastI;
                    secondLastI--;
                    int nextI = i;
                    nextI++;
                    int secondNextI = nextI;
                    secondNextI++;
                    for (int j = randomJ; j < thisIslandLength; j++)
                    {
                        int lastJ = j;
                        lastJ--;
                        int secondLastJ = lastJ;
                        secondLastJ--;
                        int nextJ = j;
                        nextJ++;
                        int secondNextJ = nextJ;
                        secondNextJ++;
                        int iEdge = thisIslandHight;
                        iEdge--;
                        int jEdge = thisIslandLength;
                        jEdge--;
                        //if top line
                        if (i == randomI)
                        {
                            //if on left corner
                            if (j == randomJ)
                            {
                                //if upper block is empty or last block is empty
                                if (map.mapArray[lastI, j].type == Type.Empty || map.mapArray[i, lastJ].type == Type.Empty)
                                {
                                    map.mapArray[i, j].type = Type.IslandWall;//make wall
                                }
                                //if both are walls 
                                else if(map.mapArray[lastI, j].type == Type.IslandWall && map.mapArray[i, lastJ].type == Type.IslandWall)
                                {
                                    map.mapArray[i, j].type = Type.IslandCenter;//make center
                                }
                                //if both are centers
                                else if(map.mapArray[lastI, j].type == Type.IslandCenter && map.mapArray[i, lastJ].type == Type.IslandCenter)
                                {
                                    map.mapArray[i, j].type = Type.IslandCenter;//make center
                                }
                                //if one of them is a a wall and the other is a center
                                else if((map.mapArray[lastI, j].type == Type.IslandCenter && map.mapArray[i, lastJ].type == Type.IslandWall) || (map.mapArray[lastI, j].type == Type.IslandWall && map.mapArray[i, lastJ].type == Type.IslandCenter))
                                {
                                    map.mapArray[i, j].type = Type.IslandCenter;//make center
                                }
                                else
                                {
                                    map.mapArray[i, j].type = Type.IslandWall;//make wall
                                }
                            }
                            //if on right corner
                            else if(j == jEdge)
                            {
                                //if upper block is empty or next block is empty
                                if (map.mapArray[lastI,j].type == Type.Empty || map.mapArray[i,nextJ].type == Type.Empty)
                                {
                                    map.mapArray[i, j].type = Type.IslandWall; //make wall
                                }
                                //if both are walls
                                else if (map.mapArray[lastI, j].type == Type.IslandWall && map.mapArray[i, nextJ].type == Type.IslandWall)
                                {
                                    map.mapArray[i, j].type = Type.IslandCenter; //make center
                                }
                                //if both are centers
                                else if (map.mapArray[lastI, j].type == Type.IslandCenter && map.mapArray[i, nextJ].type == Type.IslandCenter)
                                {
                                    map.mapArray[i, j].type = Type.IslandCenter; //make center
                                }
                                //if one of them is a a wall and the other is a center
                                else if ((map.mapArray[lastI, j].type == Type.IslandCenter && map.mapArray[i, nextJ].type == Type.IslandWall) || (map.mapArray[lastI, j].type == Type.IslandWall && map.mapArray[i, nextJ].type == Type.IslandCenter))
                                {
                                    map.mapArray[i, j].type = Type.IslandCenter; //make Center
                                }
                                else
                                {
                                    map.mapArray[i, j].type = Type.IslandWall; //make wall
                                }
                            }
                            //if on middle blocks
                            else
                            {
                                //if upper block is empty
                                if(map.mapArray[lastI,j].type == Type.Empty)
                                {
                                    map.mapArray[i, j].type = Type.IslandWall; //make wall
                                }
                                // if upper block is a wall or a center
                                else if (map.mapArray[lastI, j].type == Type.IslandWall || map.mapArray[lastI, j].type == Type.IslandCenter)
                                {
                                    //if last upper block is not empty and next upper block is not empty
                                    if (map.mapArray[lastI, lastJ].type != Type.Empty && map.mapArray[lastI, nextJ].type != Type.Empty)
                                    {
                                        //if second upper block is a center or wall 
                                        if ((map.mapArray[secondLastI, j].type == Type.IslandWall || map.mapArray[secondLastI, j].type == Type.IslandCenter))
                                        {
                                            //if last second upper block is not empty and next upper second block is not empty
                                            if (map.mapArray[secondLastI, lastJ].type != Type.Empty && map.mapArray[secondLastI, nextJ].type != Type.Empty)
                                            {
                                                //change upper block to center
                                                map.mapArray[lastI, j].type = Type.IslandCenter;
                                            }
                                        }
                                        map.mapArray[i, j].type = Type.IslandCenter; //make center
                                    }
                                    else
                                    {
                                        map.mapArray[i, j].type = Type.IslandWall; //make Wall
                                    }
                                }
                            }
                        }
                        //if on left edge
                        else if(j == randomJ && i != iEdge)
                        {
                            //if middle blocks
                            //if last block is empty
                            if (map.mapArray[i, lastJ].type == Type.Empty)
                            {
                                map.mapArray[i, j].type = Type.IslandWall; //make wall
                            }
                            // if last block is a wall or a center
                            else if(map.mapArray[i, lastJ].type == Type.IslandWall || map.mapArray[i, lastJ].type == Type.IslandCenter)
                            {
                                //upper last block is not empty and bottom last block is not empty
                                if (map.mapArray[lastI, lastJ].type != Type.Empty && map.mapArray[nextI, lastJ].type != Type.Empty)
                                {
                                    //if second last block is a center or wall and 
                                    if (map.mapArray[i, secondLastJ].type == Type.IslandWall || map.mapArray[i, secondLastJ].type == Type.IslandCenter)
                                    {
                                        //upper second last block is not empty and bottom last second block is not empty
                                        if (map.mapArray[lastI, secondLastJ].type != Type.Empty && map.mapArray[nextI, secondLastJ].type != Type.Empty)
                                        {
                                            //change upper block to center
                                            map.mapArray[i, lastJ].type = Type.IslandCenter;
                                        }
                                    }
                                    map.mapArray[i, j].type = Type.IslandCenter;//make center
                                }
                                else
                                {
                                    map.mapArray[i, j].type = Type.IslandWall;//make wall
                                }
                                
                            }
                        }
                        // if on right edge
                        else if(j == jEdge && i != iEdge)
                        {
                            //if on middle blocks
                            //if next block is empty
                            if (map.mapArray[i, nextJ].type == Type.Empty)
                            {
                                map.mapArray[i, j].type = Type.IslandWall; //make wall
                            }
                            // if right block is a wall or a center
                            else if(map.mapArray[i, nextJ].type == Type.IslandWall|| map.mapArray[i, nextJ].type == Type.IslandCenter)
                            {
                                //if upper next block is not empty and bottom next block is not empty
                                if (map.mapArray[lastI, nextJ].type != Type.Empty && map.mapArray[nextI, nextJ].type != Type.Empty)
                                {
                                    //if second next block is a center or wall 
                                    if (map.mapArray[i, secondNextJ].type == Type.IslandWall || map.mapArray[i, secondNextJ].type == Type.IslandCenter)
                                    {
                                        //if upper second next block is not empty and bottom second next block is not empty
                                        if (map.mapArray[lastI, secondNextJ].type != Type.Empty && map.mapArray[nextI, secondNextJ].type != Type.Empty)
                                        {
                                            //change next block to center
                                            map.mapArray[i, nextJ].type = Type.IslandCenter;
                                        }
                                    }
                                    map.mapArray[i, j].type = Type.IslandCenter;//make center
                                }
                                //if there are empty blocks to the side of next block
                                else
                                {
                                    map.mapArray[i, j].type = Type.IslandWall;//make wall
                                }
                                
                            }
                        }
                        //if on bottom edge
                        else if (i == iEdge)
                        {
                            //if left corner
                            if (j == randomJ)
                            {
                                //if bottom block is empty or last block is empty
                                if (map.mapArray[i, lastJ].type == Type.Empty || map.mapArray[nextI, j].type == Type.Empty)
                                {
                                    map.mapArray[i, j].type = Type.IslandWall;//make wall
                                }
                                //if both are walls
                                else if (map.mapArray[i, lastJ].type == Type.IslandWall && map.mapArray[nextI, j].type == Type.IslandWall)
                                {
                                    map.mapArray[i, j].type = Type.IslandCenter;//make center
                                }
                                //if both are centers
                                else if (map.mapArray[i, lastJ].type == Type.IslandCenter && map.mapArray[nextI, j].type == Type.IslandCenter)
                                {
                                    map.mapArray[i, j].type = Type.IslandCenter;//make center
                                }
                                //if one of them is a a wall and the other is a center
                                else if ((map.mapArray[i, lastJ].type == Type.IslandCenter && map.mapArray[nextI, j].type == Type.IslandWall) || (map.mapArray[i, lastJ].type == Type.IslandWall && map.mapArray[nextI, j].type == Type.IslandCenter))
                                {
                                    map.mapArray[i, j].type = Type.IslandCenter;//make center
                                }
                                //else make wall
                                else
                                {
                                    map.mapArray[i, j].type = Type.IslandWall;//make wall
                                }
                            }
                            //if right corner
                            else if (j == jEdge)
                            {
                                //if bottom block is empty or next block is empty
                                if (map.mapArray[nextI, j].type == Type.Empty || map.mapArray[i, nextJ].type == Type.Empty)
                                {
                                    map.mapArray[i, j].type = Type.IslandWall; //make wall
                                }
                                //if both are walls
                                else if (map.mapArray[nextI, j].type == Type.IslandWall && map.mapArray[i, nextJ].type == Type.IslandWall)
                                {
                                    map.mapArray[i, j].type = Type.IslandCenter; //make center
                                }
                                //if both are centers
                                else if (map.mapArray[nextI, j].type == Type.IslandCenter && map.mapArray[i, nextJ].type == Type.IslandCenter)
                                {
                                    map.mapArray[i, j].type = Type.IslandCenter; //make center
                                }
                                //if one of them is a a wall and the other is a center
                                else if ((map.mapArray[nextI, j].type == Type.IslandWall && map.mapArray[i, nextJ].type == Type.IslandCenter) || (map.mapArray[nextI, j].type == Type.IslandCenter && map.mapArray[i, nextJ].type == Type.IslandWall))
                                {
                                    map.mapArray[i, j].type = Type.IslandCenter; //make center
                                }
                                //else make wall
                                else
                                {
                                    map.mapArray[i, j].type = Type.IslandWall; //make wall
                                }
                            }
                            //if middle blocks
                            //if bottom block is empty
                            else if (map.mapArray[nextI, j].type == Type.Empty)
                            {
                                map.mapArray[i, j].type = Type.IslandWall; //make wall
                            }
                            // if bottom block is a wall or a center
                            else if(map.mapArray[nextI, j].type == Type.IslandWall || map.mapArray[nextI, j].type == Type.IslandCenter)
                            {
                                //if bottom last block is not empty and next bottom block is not empty
                                if (map.mapArray[nextI, lastJ].type != Type.Empty && map.mapArray[nextI, nextJ].type != Type.Empty)
                                {
                                    //if second bottom block is a center or wall
                                    if (map.mapArray[secondNextI, j].type == Type.IslandWall || map.mapArray[secondNextI, j].type == Type.IslandCenter)
                                    {
                                        //if second bottom block is not empty and next bottom second block is not empty
                                        if (map.mapArray[secondNextI, lastJ].type != Type.Empty && map.mapArray[secondNextI, nextJ].type != Type.Empty)
                                        {
                                            //change bottom block to center
                                            map.mapArray[nextI, j].type = Type.IslandCenter;
                                        }
                                    }
                                    map.mapArray[i, j].type = Type.IslandCenter;//make center
                                }
                                else
                                {
                                    map.mapArray[i, j].type = Type.IslandWall;//make Wall
                                }
                            }
                        }
                        else//should put center
                        {
                            map.mapArray[i, j].type = Type.IslandCenter;
                        }
                    }
                }
                islandsToCreate--;
            }
        }
    }
}
