using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinalProject_RoguelikeRPG.GameDefinitions;

namespace FinalProject_RoguelikeRPG
{
    class Player
    {
        #region Class Members

        // Player Attributes
        private int currentHealth, maxHealth, baseDamage, armor;
        private float critChance, evasionChance;
        private int gold;

        // Player Position on Map
        private int posRow, posColumn;

        #endregion

        #region Class Properties

        public int PosRow { get => posRow; set => posRow = value; }
        public int PosColumn { get => posColumn; set => posColumn = value; }
        public int BaseDamage { get => baseDamage; set => baseDamage = value; }
        public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
        public int MaxHealth { get => maxHealth; set => maxHealth = value; }
        public float CritChance { get => critChance; set => critChance = value; }
        public float EvasionChance { get => evasionChance; set => evasionChance = value; }
        public int Armor { get => armor; set => armor = value; }
        public int Gold { get => gold; set => gold = value; }

        #endregion

        #region Methods

        public Player()
        {
            CurrentHealth = BaseHealth;
            MaxHealth = BaseHealth;
            BaseDamage = StartingDamage;
            CritChance = BaseCritChance;
            EvasionChance = BaseEvasion;
            Armor = BaseArmor;
            Gold = BaseGold;

            PosRow = -1;
            PosColumn = -2;

        }

        public Player(Player otherPlayer)
        {
            CurrentHealth = otherPlayer.CurrentHealth;
            MaxHealth = otherPlayer.MaxHealth;
            BaseDamage = otherPlayer.BaseDamage;
            CritChance = otherPlayer.CritChance;
            EvasionChance = otherPlayer.EvasionChance;
            Armor = otherPlayer.Armor;
            Gold = otherPlayer.Gold;

            PosRow = otherPlayer.posRow;
            PosColumn = otherPlayer.posColumn;

        }

        public void UpdatePosition(int row, int column)
        {
            this.PosRow = row;
            this.PosColumn = column;
        }

        public void AddShrineBonus(RewardType rewardType)
        {
            switch (rewardType)
            {
                case RewardType.MaxHP:
                    this.MaxHealth += MaxHpBaseReward;
                    break;
                case RewardType.CritChance:

                    float critChanceAfterAddition = this.CritChance += CritChanceBaseReward;
                    if(critChanceAfterAddition > MaxCrit)
                    {
                        this.critChance = MaxCrit;
                    }
                    else
                    {
                        this.critChance = critChanceAfterAddition;
                    }

                    break;
                case RewardType.EvasionChance:

                    float evasionAfterAddition = this.EvasionChance += EvasionChanceBaseReward;
                    if(evasionAfterAddition > MaxEvasion)
                    {
                        this.evasionChance = MaxEvasion;
                    }
                    else
                    {
                        this.evasionChance = evasionAfterAddition;
                    }
                    break;
                case RewardType.CurrentHP:
                    int hpAddition = (int)(maxHealth * CurrentHpReward);
                    if (currentHealth + hpAddition > maxHealth) hpAddition = maxHealth - currentHealth;
                    
                    this.currentHealth += hpAddition;
                    break;
            }
        }

        public int CalculateHitDamage()
        {
            int damageToHit = baseDamage;

            Random r = new Random();
            int critRoll = r.Next(1, 100);

            if (critRoll < (CritChance * 100)) damageToHit *= 2;

            return damageToHit;
        }

        public bool RollForPlayerEvasion()
        {
            Random r = new Random();
            int evasionRoll = r.Next(1, 100);

            if (evasionRoll < EvasionChance * 100) return true;
            else
            {
                return false;
            }
        }

        public int CalculateDamageTaken(int damage)
        {
            return (damage - Armor);
        }

        public override string ToString()
        {
            return "----------------------------------------------------------------------\n\n" +
                "   HP : " + CurrentHealth + "/" + MaxHealth + " | DMG: " + BaseDamage + " | CRIT: " + CritChance*100 + "% | EVA: " + EvasionChance*100 + "% | ARM: " + Armor + " | GOLD: " + Gold + "            \n\n"
                + "----------------------------------------------------------------------"; 
        }


        #endregion

    }
}