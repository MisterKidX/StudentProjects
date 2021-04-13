using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    class PlayerAttack
    {

        //enter sctipt when pressing a to attack
        //if player has only one wapon he attacks with that weapon, else he need to choose what wapon he will use
        //
        static Player player;
        static Map map;
        static string _itemName;
        static string _attackDirection;
        static string _monsterName;
        static int _attackDamage;
        public static void Attack(Player myPlayer, Map myMap, Item item)
        {
            player = myPlayer;
            map = myMap;
            if(item == ItemManager.Sword)
            {
                _itemName = item.name;
                AttackType(ItemManager.Sword.id);
            }
            else if (item == ItemManager.Bow)
            {
                _itemName = item.name;
                AttackType(ItemManager.Bow.id);
            }
        }
        static void AttackType(int type)
        {
            if(type == ItemManager.Sword.id)
            {
                AttackPosition(ItemManager.Sword.range, ItemManager.Sword);
            }
            else if(type == ItemManager.Bow.id)
            {
                AttackPosition(ItemManager.Bow.range, ItemManager.Bow);
            }
        }
        static void AttackPosition(int range, Item item)
        {
            Hud.InfoText = "Please Insert Direction";
            ScreenManager.PrintScreen();
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    bool bigEnemyOnTop = EnemyManager.TypeOfBigEnemy(player.position.y - range, player.position.x);
                    _attackDirection = "Upper Block";
                    if (map.mapArray[player.position.y - range, player.position.x].type == Type.SmallEnemy || bigEnemyOnTop)
                    {
                        Position enemyPos = new Position(player.position.x, player.position.y - range);

                        if (map.mapArray[player.position.y - range, player.position.x].type == Type.SmallEnemy)
                        {
                            //grab and remove instance of speshiphic positions
                            _monsterName = "Small Enemy";
                            CheckSmallEnemy(enemyPos, item);
                        }
                        else if(bigEnemyOnTop)
                        {

                            _monsterName = "Big Enemy";
                            CheckBigEnemy(enemyPos, item);

                            //reduce health of big enemy
                            //if health is 0 get rewards
                        }
                    }
                    else
                    {

                        Hud.InfoText = "Attacked with " + _itemName + " At " + _attackDirection + " But No Enemy Found";
                    }
                    break;
                case ConsoleKey.DownArrow:
                    bool bigEnemyOnBottom = EnemyManager.TypeOfBigEnemy(player.position.y + range, player.position.x);
                    _attackDirection = "Bottom Block";
                    if (map.mapArray[player.position.y + range, player.position.x].type == Type.SmallEnemy || bigEnemyOnBottom)
                    {
                        Position enemyPos = new Position(player.position.x, player.position.y + range);

                        if (map.mapArray[player.position.y + range, player.position.x].type == Type.SmallEnemy)
                        {
                            //grab and remove instance of speshiphic positions
                            _monsterName = "Small Enemy";
                            CheckSmallEnemy(enemyPos, item);
                        }
                        else if (bigEnemyOnBottom)
                        {

                            _monsterName = "Big Enemy";
                            CheckBigEnemy(enemyPos, item);

                            //reduce health of big enemy
                            //if health is 0 get rewards
                        }
                    }
                    else
                    {
                        Hud.InfoText = "Attacked with " + _itemName + " At " + _attackDirection + " But No Enemy Found";
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    bool bigEnemyOnLeft = EnemyManager.TypeOfBigEnemy(player.position.y, player.position.x - range);
                    _attackDirection = "Left Block";
                    if (map.mapArray[player.position.y ,player.position.x - range].type == Type.SmallEnemy || bigEnemyOnLeft)
                    {
                        Position enemyPos = new Position(player.position.x - range, player.position.y);

                        if (map.mapArray[player.position.y, player.position.x - range].type == Type.SmallEnemy)
                        {
                            //grab and remove instance of speshiphic positions
                            _monsterName = "Small Enemy";
                            CheckSmallEnemy(enemyPos, item);
                        }
                        else if (bigEnemyOnLeft)
                        {
                            _monsterName = "Big Enemy";
                            CheckBigEnemy(enemyPos, item);

                            //reduce health of big enemy
                            //if health is 0 get rewards
                        }
                    }
                    else
                    {
                        Hud.InfoText = "Attacked with " + _itemName + " At " + _attackDirection + " But No Enemy Found";
                    }
                    break;
                case ConsoleKey.RightArrow:
                    bool bigEnemyOnRight = EnemyManager.TypeOfBigEnemy(player.position.y, player.position.x + range);
                    _attackDirection = "Right Block";
                    if (map.mapArray[player.position.y, player.position.x + range].type == Type.SmallEnemy || bigEnemyOnRight)
                    {
                        Position enemyPos = new Position(player.position.x + range, player.position.y);

                        if (map.mapArray[player.position.y, player.position.x + range].type == Type.SmallEnemy)
                        {
                            //grab and remove instance of speshiphic positions
                            _monsterName = "Small Enemy";
                            CheckSmallEnemy(enemyPos, item);
                        }
                        else if (bigEnemyOnRight)
                        {
                            _monsterName = "Big Enemy";
                            CheckBigEnemy(enemyPos,item);
                            //reduce health of big enemy
                            //if health is 0 get rewards
                        }
                    }
                    else
                    {
                        Hud.InfoText = "Attacked with " + _itemName + " At " + _attackDirection + " But No Enemy Found";
                        Hud.InfoText2 = " ";
                    }
                    break;
            }
        }
        public static void CheckSmallEnemy(Position attackPosition, Item item)
        {
            for (int i = 0; i < EnemyManager.smallEnemyList.Count; i++)
            {
                if (EnemyManager.smallEnemyList[i] != null && Position.PositionCheck(attackPosition, EnemyManager.smallEnemyList[i].position))
                {
                    if(PlayerStats.hasGuntlet == true)
                    {
                        int totalAttack = item.attack + ItemManager.Guntlet.attack;
                        EnemyManager.smallEnemyList[i].ReciveDamage(totalAttack, attackPosition);
                        _attackDamage = totalAttack;
                    }
                    else
                    {
                        EnemyManager.smallEnemyList[i].ReciveDamage(item.attack, attackPosition);
                        _attackDamage = item.attack;
                    }
                    Hud.InfoText = "Attacked " + _monsterName + " With " + _itemName + " At " +  _attackDirection + " For " + _attackDamage + " Damage";
                    if(item.name == "Sword")
                    {
                        SoundManager.SwordSound();
                    }
                    else
                    {
                        SoundManager.BowSound();
                    }
                }
            }
        }
        public static void CheckBigEnemy(Position attackPosition, Item item)
        {
            for (int i = 0; i < EnemyManager.bigEnemyList.Count; i++)
            {
                if(EnemyManager.bigEnemyList[i] != null && EnemyManager.TypeOfBigEnemy(attackPosition.y, attackPosition.x))
                {
                    if(PlayerStats.hasGuntlet)
                    {
                        int totalAttack = item.attack + ItemManager.Guntlet.attack;
                        EnemyManager.bigEnemyList[i].ReciveDamage(attackPosition, totalAttack);
                        _attackDamage = totalAttack;
                    }
                    else
                    {
                        EnemyManager.bigEnemyList[i].ReciveDamage(attackPosition, item.attack);
                        _attackDamage = item.attack;
                    }
                    Hud.InfoText = "Attacked " + _monsterName + " With " + _itemName + " At " + _attackDirection + " For " + _attackDamage + " Damage";
                    if (item.name == "Sword")
                    {
                        SoundManager.SwordSound();
                    }
                    else
                    {
                        SoundManager.BowSound();
                    }
                }
            }
        }
    }
}
