using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject101_RonBandel
{
    class Treasure
    {
        private static Treasure instance;
        Random rand = new Random();

        static readonly int numberOfPotionTypes = 6;   // Healing, Strength, Sniper, Assassin, Fortify and Powerfull!
        public int potionStatistic = (100 / numberOfPotionTypes) + 1;

        static readonly int numberOfWeaponTypes = 6;   // BattleAxe, Sabre, Dagger, Jagged Sword, Bow and Shield!!!
        public int weaponStatistic = (100 / numberOfWeaponTypes) + 1;

        private Treasure()
        { }

        public static Treasure Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Treasure();
                }
                return instance;
            }
        }

        public void GenerateSeededTreasure(int seed)    // seed determines treasure
        {
            if ( seed <= (50 - Player.Instance.luck) )
            {
                AddSeededPotionToPouch(rand.Next(1, 101));
            }
            else
            {
                seed = rand.Next(1, 101);
                GetSeededWeapon(seed);
            }
        }

        // ---- Potions ------
        public void AddSeededPotionToPouch(int seed)
        {
            for (int i = 0; i < 5; i++)
            {
                if (Player.Instance.potionPouch[i] == null)
                {
                    Player.Instance.potionPouch[i] = GetSeededPotion(seed);
                    Player.Instance.PrintPlayerPotions();
                    HUD.NewHUDEntry("You found a " + Player.Instance.potionPouch[i].potionName);
                    break;
                }
            }
            // scrapper
        }

        Potion GetSeededPotion(int seed)
        {            
            if (seed <= potionStatistic*1)
            {
                return new HealingPotion();
            }
            else if (seed > potionStatistic * 1 && seed <= potionStatistic * 2)
            {
                return new StrengthPotion();
            }
            else if (seed > potionStatistic * 2 && seed <= potionStatistic * 3)
            {
                return new SniperPotion();
            }
            else if (seed > potionStatistic * 3 && seed <= potionStatistic * 4)
            {
                return new AssassinPotion();
            }
            else if (seed > potionStatistic * 4 && seed <= potionStatistic * 5)
            {
                return new FortifyPotion();
            }
            else
            {
                return new PowerfullPotion();
            }
        }

        // ---- Weapons ------

        public void GetSeededWeapon(int seed)
        {
            if (seed <= weaponStatistic * 1)
            {
                FindBattleAxe();
            }
            else if (seed > weaponStatistic * 1 && seed <= weaponStatistic * 2)
            {
                FindDagger();
            }
            else if (seed > weaponStatistic * 2 && seed <= weaponStatistic * 3)
            {
                FindBowAndArrow();
            }
            else if (seed > weaponStatistic * 3 && seed <= weaponStatistic * 4)
            {
                FindSabre();
            }
            else if (seed > weaponStatistic * 4 && seed <= weaponStatistic * 5)
            {
                FindShield();
            }
            else
            {
                FindJaggedSword();
            }
        }

        void FindBattleAxe()
        {
            Player.Instance.baseJabDamage++;
            HUD.NewHUDEntry("You Found a Battle Axe! Dmg Up!");
        }

        void FindDagger()
        {
            Player.Instance.baseJabCD -= 5;
            HUD.NewHUDEntry("You Found a Dagger! Attack Speed Up!");
        }

        void FindBowAndArrow()
        {
            Player.Instance.baseJabRange++;
            HUD.NewHUDEntry("You Found a Bow! Range Up!");
        }

        void FindSabre()
        {
            Player.Instance.baseCritChance += 5;
            HUD.NewHUDEntry("You Found a Sabre! Crit Chance Up!");
        }

        void FindShield()
        {
            Player.Instance.armor += 20;
            Player.Instance.baseEvadeChance += 2;
            Player.Instance.PrintPlayerHPAndArmor();
            HUD.NewHUDEntry("You Found a Shield! Armor & Evasion Up!");
        }

        void FindJaggedSword()
        {
            Player.Instance.baseCritMultiplier += 1;
            HUD.NewHUDEntry("You Found a Jagged Sword! Crit Dmg Up!");
        }
    }
}