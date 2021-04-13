using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_RoguelikeRPG
{
    static class GameDefinitions
    {

        #region Symbol Definitions

        public const char PlayerSymbol = 'H';
        public const char EnemySymbol = 'M';
        public const char ShopSymbol = '$';
        public const char CritShrineSymbol = 'c';
        public const char EvasionShrineSymbol = 'e';
        public const char MaxHPShrineSymbol = '+';
        public const char CurrentHPShrineSymbol = '*';
        public const char TrapSymbol = '#';
        public const char EntranceSymbol = 'E';
        public const char ExitSymbol = 'X';
        public const char WallSymbol = 'O';
        public const char FreeSymbol = ' ';
        public const char MapFillerSymbol = '.';

        #endregion

        #region Color Definitions

        public const ConsoleColor WallColor = ConsoleColor.DarkGray;
        public const ConsoleColor EnemyColor = ConsoleColor.Red;
        public const ConsoleColor ShopColor = ConsoleColor.DarkGreen;
        public const ConsoleColor FillerColor = ConsoleColor.DarkGray;
        public const ConsoleColor CritShrineColor = ConsoleColor.Green;
        public const ConsoleColor EvasionShrineColor = ConsoleColor.Yellow;
        public const ConsoleColor MaxHPShrineColor = ConsoleColor.Magenta;
        public const ConsoleColor CurrentHPShrineColor = ConsoleColor.Magenta;
        public const ConsoleColor ExitColor = ConsoleColor.White;
        public const ConsoleColor EntranceColor = ConsoleColor.DarkGray;
        public const ConsoleColor PlayerColor = ConsoleColor.Cyan;
        public const ConsoleColor TrapColor = ConsoleColor.DarkRed;

        #endregion

        #region Map Size Definitions

        public const int MapMaxWidth = 42;
        public const int MapMaxHeight = 15;
        public const int MapMinWidth = 26; 
        public const int MapMinHeight = 12; 

        #endregion

        #region Obstacle Generation Definitions

        public const int ObstableMinWidth = 2;
        public const int ObstableMinHeight = 1;
        public const int ObstacleMapFactor = 4;
        public const int MaxObstacleNum = 6;

        #endregion

        #region Reward Definitions

        public enum RewardType
        {
            MaxHP,
            Damage,
            Armor,
            CritChance,
            EvasionChance,
            CurrentHP
        }

        public const int MaxHpBaseReward = 5;
        public const int DamageBaseReward = 1;
        public const float CurrentHpReward = 0.3f;
        public const float CritChanceBaseReward = 0.05f;
        public const float EvasionChanceBaseReward = 0.05f;
    
        public const int TreasureAmoutModifier = 2;

        #endregion

        #region Traps

        public const int TrapAmountModifier = 1;

        #endregion

        #region Player Stats

        public const int BaseHealth = 50;
        public const int StartingDamage = 1;
        public const int BaseArmor = 0;
        public const float BaseEvasion = 0.05f;
        public const float BaseCritChance = 0.05f;
        public const int BaseGold = 0;

        public const float MaxCrit = 0.7f;
        public const float MaxEvasion = 0.7f;

        #endregion

        #region Shop Definitions

        public const int ArmorCostModifier = 10;
        public const int WeaponCostModifier = 5;
        public const int ShopHealingCost = 10;
        public const float ShopHealingAmount = 0.5f;

        #endregion

        #region Enemy Stats

        public const int EnemyDamageModifier = 2;
        public const int EnemyChaseRadius = 4;

        #endregion

        #region Movement
        public enum GameDirection
        {
            Up, Down, Right, Left
        }


        #endregion

        #region Input Settings

        public const ConsoleKey ReloadLevelKey = ConsoleKey.R;

        public const ConsoleKey MoveUpKey = ConsoleKey.W;
        public const ConsoleKey MoveDownKey = ConsoleKey.S;
        public const ConsoleKey MoveLeftKey = ConsoleKey.A;
        public const ConsoleKey MoveRightKey = ConsoleKey.D;

        public const ConsoleKey AttackUpKey = ConsoleKey.UpArrow;
        public const ConsoleKey AttackDownKey = ConsoleKey.DownArrow;
        public const ConsoleKey AttackLeftKey = ConsoleKey.LeftArrow;
        public const ConsoleKey AttackRightKey = ConsoleKey.RightArrow;

        #endregion

        #region Event Log Definitions

        public const int MaxEventLogLength = 5;

        #endregion

        #region Game Ending

        public const int FinalLevel = 11;

        #endregion

    }
}
