using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject101_RonBandel
{
    public abstract class Potion
    {
        public Random rand = new Random();
        public string potionName;
        public abstract void Drink();        
    }   

    [Serializable]
    public class HealingPotion : Potion
    {
        public HealingPotion()
        {
            potionName = "Healing Potion";
        }
        
        public override void Drink()
        {
            Player.Instance.Heal(rand.Next(1, 6)*Player.Instance.tempPotionPower);
            HUD.NewHUDEntry("You drank the healing potion! HP up!");
        }
    }

    [Serializable]
    public class StrengthPotion : Potion
    {
        public StrengthPotion()
        {
            potionName = "Strength Potion";
        }

        public override void Drink()
        {
            Player.Instance.tempDamageBonus += 3;
            HUD.NewHUDEntry("You drank the Strength Potion! Dmg up!");
            
        }
    }

    [Serializable]
    public class SniperPotion : Potion
    {
        public SniperPotion()
        {
            potionName = "Sniper Potion";
        }

        public override void Drink()
        {
            Player.Instance.tempJabRangeBonus += 2;
            HUD.NewHUDEntry("You drank the Sniper Potion! Range up!");
        }
    }

    [Serializable]
    public class AssassinPotion : Potion
    {
        public AssassinPotion()
        {
            potionName = "Assassin Potion";
        }

        public override void Drink()
        {
            Player.Instance.tempAttackSpeedBonus += 5;
            Player.Instance.tempCritChanceBonus += 5;
            Player.Instance.tempCritMultiplier += 1;
            HUD.NewHUDEntry("You drank the Assassin Potion!");
            HUD.NewHUDEntry("Attack Speed, Crit Dmg and Chance up!");
        }
    }

    [Serializable]
    public class FortifyPotion : Potion
    {
        public FortifyPotion()
        {
            potionName = "Fortify Potion";
        }

        public override void Drink()
        {
            Player.Instance.armor += (10*Player.Instance.tempPotionPower);
            Player.Instance.tempEvadeChance += 10;
            Player.Instance.PrintPlayerHPAndArmor();
            HUD.NewHUDEntry("You drank the Fortify Potion!");
            HUD.NewHUDEntry("Armor and Evasion chance up!");
        }
    }

    [Serializable]
    public class PowerfullPotion : Potion
    {
        public PowerfullPotion()
        {
            potionName = "Powerfull Potion!";
        }

        public override void Drink()
        {
            Player.Instance.luck++;
            Player.Instance.tempPotionPower++;
            HUD.NewHUDEntry("This Potion is too strong for you!");
        }
    }
}