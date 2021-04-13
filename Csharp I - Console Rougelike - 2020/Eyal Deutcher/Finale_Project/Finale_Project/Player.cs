using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    public class Player: GameObject
    {
        Random random = new Random();
        public void Movement(Map map, Entrance entrance, Vendor vendor)
        {
            //if position is empty move change player position
            //if chest get stuff
            //if enemy//big enemy fight
            //if exit leaves
            //if vendor show me what to buy
            //if wall of any kind do not move and let me re choose a movement
            bool needToMove = true;
            while (needToMove)
            {
               switch(Console.ReadKey().Key)
               {
                    case ConsoleKey.UpArrow:
                        if (map.mapArray[position.y-1,position.x].type != Type.Wall && map.mapArray[position.y - 1, position.x].type != Type.IslandWall)
                        {
                            // if vendor
                            //if chest
                            //if enemy
                            SoundManager.WalkSound();
                            map.mapArray[position.y, position.x].type = Type.Empty;
                            position.y -= 1;
                            map.mapArray[position.y, position.x].type = Type.Player;
                            needToMove = false;
                            Hud.InfoText = "Moved UP";
                            Hud.InfoText2 = " ";
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (map.mapArray[position.y + 1, position.x].type != Type.Wall && map.mapArray[position.y + 1, position.x].type != Type.IslandWall)
                        {
                            SoundManager.WalkSound();
                            map.mapArray[position.y, position.x].type = Type.Empty;
                            position.y += 1;
                            map.mapArray[position.y, position.x].type = Type.Player;
                            needToMove = false;
                            Hud.InfoText = "Moved Down";
                            Hud.InfoText2 = " ";
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (map.mapArray[position.y ,position.x - 1].type != Type.Wall && map.mapArray[position.y , position.x - 1].type != Type.IslandWall)
                        {
                            SoundManager.WalkSound();
                            map.mapArray[position.y, position.x].type = Type.Empty;
                            position.x -= 1;
                            map.mapArray[position.y, position.x].type = Type.Player;
                            needToMove = false;
                            Hud.InfoText = "Moved Left";
                            Hud.InfoText2 = " ";
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (map.mapArray[position.y , position.x + 1].type != Type.Wall && map.mapArray[position.y , position.x + 1].type != Type.IslandWall)
                        {
                            SoundManager.WalkSound();
                            map.mapArray[position.y, position.x].type = Type.Empty;
                            position.x += 1;
                            map.mapArray[position.y, position.x].type = Type.Player;
                            needToMove = false;
                            Hud.InfoText = "Moved Right";
                            Hud.InfoText2 = " ";
                        }
                        break;
                    case ConsoleKey.Q://bow
                        if (PlayerStats.hasBow == true)
                        {
                            PlayerAttack.Attack(this, map, ItemManager.Bow);
                            needToMove = false;
                        }
                        else
                        {
                            needToMove = false;
                            Hud.InfoText = "Tried To Attack With Bow But You Have No Bow";
                            Hud.InfoText2 = " ";
                        }
                        break;
                    case ConsoleKey.E://sword
                        if(PlayerStats.hasSword == true)
                        {
                            PlayerAttack.Attack(this, map, ItemManager.Sword);
                            needToMove = false;
                        }
                        else
                        {
                            needToMove = false;
                            Hud.InfoText = "Tried To Attack With Sword But You Have No Sword";
                            Hud.InfoText2 = " ";
                        }

                        break;
                    case ConsoleKey.X:
                        EndLevelQuestion.EndLevel();
                        ScreenManager.PrintScreen();
                        //ask if sure, if so finish
                        //if not clear and print map
                        break;
               }
            }
        }
        //public Position GetPosition()
        //{
        //    return position;
        //}
        public void PlayerPositionCheck(Map map, Entrance entrance, Vendor vendor)
        {
            //show stuff on map
            //monsters and chests need to be assigned a cenerio
            if(map.mapArray[position.y, position.x] == map.mapArray[vendor.position.y, vendor.position.x])
            {
                VendorManager.EnterShop();
                Hud.InfoText = "Visited Vendor";
                //hud 2 on shop buy
            }
            //check for chests
            for (int i = 0; i < ChestManager.chestList.Count; i++)
            {
                if (ChestManager.chestList[i] != null && Position.PositionCheck(position, ChestManager.chestList[i].position))
                {
                    PlayerStats.ReciveGold(ChestManager.chestList[i].GetGold());
                    ChestManager.chestList.RemoveAt(i);//can be used to get a lot of gold to check stuff
                }
            }
            //check for small enemies
            for (int i = 0; i < EnemyManager.smallEnemyList.Count; i++)
            {
                if (EnemyManager.smallEnemyList[i] != null && Position.PositionCheck(position, EnemyManager.smallEnemyList[i].position))
                {
                    EnemyManager.StepOnSmallEnemy();
                    EnemyManager.smallEnemyList.RemoveAt(i);
                }
            }
            //check for big enemy
            for (int i = 0; i < EnemyManager.bigEnemyList.Count; i++)
            {
                if (EnemyManager.bigEnemyList[i] != null && EnemyManager.bigEnemyList[i].CheckPositions(position))
                {
                    EnemyManager.bigEnemyList[i].CollideWithPlayer(position);
                }
            }
            //check for traps
            for (int i = 0; i < EnemyManager.trapList.Count; i++)
            {
                if(EnemyManager.trapList[i] != null && Position.PositionCheck(position, EnemyManager.trapList[i].position))
                {
                    EnemyManager.StepOnTrap();
                    EnemyManager.trapList.RemoveAt(i);
                }
            }
        }
    }
}
