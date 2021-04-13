using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Combat
    {
        Player player;
        Enemy enemy;
        int phpmax;
        int ehpmax;
        int phpcur;
        int ehpcur;
        Random rnd = new Random();
        public Combat(Player player, Enemy enemy)
        {
            this.player = player;
            this.enemy = enemy;
            phpmax = player.currenthp;
            phpcur = phpmax;
            ehpmax = enemy.HP;
            ehpcur = ehpmax;
        }
        public void StartCombat()
        {
            string Title = @"
                    _____ ___ ____ _   _ _____ 
                   |  ___|_ _/ ___| | | |_   _|
                   | |_   | | |  _| |_| | | |  
                   |  _|  | | |_| |  _  | | |  
                   |_|   |___\____|_| |_| |_|  
                                               
";
            string[] Options = { "Attack", "Special Ability", "Run" };
            Menu CombatMenu = new Menu(Title, Options);
            while (enemy.HP > 0 && player.currenthp > 0)
            {
                int SelectedIndexCombat = CombatMenu.Run();
                switch (SelectedIndexCombat)
                {
                    case 0:
                        Attack();
                        break;
                    case 1:
                        SpecialAttack();
                        break;
                    case 2:
                        if (TryRun() == true)
                        {
                            enemy.HP = 0;
                        }
                        //try to run(need to add a speed stat /just use dex/ and use randomness to decide if it works based on your hp stat?)
                        break;
                }
            }


        }

        //add complex muffs (remember to use defensive stats in calcs), need to check if player is dealing phys or mag dmg first
        void Attack()
        {
            if (player.Dexterity >= enemy.Dexterity)
            {
                DealDamage();
                takeDmg();
                Console.ReadKey(true);
                Console.Clear();
            }
            else
            {
                takeDmg();
                DealDamage();
                Console.ReadKey(true);
                Console.Clear();
            }
        }

        void SpecialAttack()
        {
            int CheckStat = 0;
            int deftype = 0;
            string FlavorText = " ";
            switch (player.ClassType)
            {
                case "Rogue":
                    CheckStat = player.Dexterity;
                    deftype = enemy.Armor;
                    FlavorText = "Sa Shing Godamn";
                    break;
                case "Mage":
                    CheckStat = player.intelligence;
                    deftype = enemy.MagRes;
                    FlavorText = "poof";
                    break;
                case "Warrior":
                    CheckStat = player.Armor;
                    deftype = enemy.Armor;
                    FlavorText = "Bonk";
                    break;
            }

            if (rnd.Next(CheckStat, CheckStat + 10) >= enemy.HP * 2)
            {
                enemy.HP -= (CheckStat * 2) - deftype;
                Console.SetCursorPosition(52, 2);
                Console.WriteLine(FlavorText);
                if (enemy.HP <= 0)
                {
                    player.kills++;
                    Console.SetCursorPosition(52, 4);
                    Console.WriteLine("Enemy Dies");
                    player.XP += enemy.XPValue;
                    if (player.XP >= player.xptonext)
                    {
                        player.LevelUp();
                        Console.SetCursorPosition(52, 5);
                        Console.WriteLine("you gain a level");

                    }
                    if (enemy.hassaki == true)
                    {
                        player.keys++;
                        Console.SetCursorPosition(52, 6);
                        Console.WriteLine("you find a key");
                    }
                }
            }
            else
            {
                Console.SetCursorPosition(52, 4);
                Console.WriteLine("pfff lol geh");
                takeDmg();
            }
                
            Console.ReadKey(true);
        }

        void ExitGame()
        {
            Environment.Exit(0);
        }

        void DealDamage()//subtruct hp from enemy / check if enemy is still alive
        {
            int dmgtype = 0;
            int deftype = 0;
            switch (player.ClassType)
            {
                case "Rogue":
                    dmgtype = player.Dexterity;
                    deftype = enemy.Armor;
                    break;
                case "Mage":
                    dmgtype = player.intelligence;
                    deftype = enemy.MagRes;
                    break;
                case "Warrior":
                    dmgtype = player.strength;
                    deftype = enemy.Armor;
                    break;
            }
            if ((dmgtype - deftype) < 0)
            {
                enemy.HP -= 0;
                Console.SetCursorPosition(52, 2);
                Console.WriteLine("the enemy blocked the attack");
            }
            else
            {
                enemy.HP -= (dmgtype - deftype);
                Console.SetCursorPosition(52, 2);
                Console.WriteLine("you Deal " + (dmgtype - deftype) + " dmg");
            }
            //check if the enemy is alive 
            //if it isnt chck if dropped key  && leveled up
            if (enemy.HP <= 0)
            {
                player.kills++;
                Console.SetCursorPosition(52, 4);
                Console.WriteLine("Enemy Dies");
                player.XP += enemy.XPValue;
                if (player.XP >= player.xptonext)
                {
                    player.LevelUp();
                    Console.SetCursorPosition(52, 5);
                    Console.WriteLine("you gain a level");

                }
                if (enemy.hassaki == true)
                {
                    player.keys++;
                    Console.SetCursorPosition(52, 6);
                    Console.WriteLine("you find a key");
                }
            }

        }

        void takeDmg()
        {
            int dmgtype = 0;
            int deftype = 0;
            switch (enemy.ClassType)
            {
                case "Magical_enemy":
                    dmgtype = enemy.intelligence;
                    deftype = player.MagRes;
                    break;
                case "Physical_enemy":
                    dmgtype = enemy.strength;
                    deftype = player.Armor;
                    break;
            }

            if ((dmgtype - deftype) <=0)
            {
                player.currenthp -= 0;
                Console.SetCursorPosition(52, 3);
                Console.WriteLine("you blocked the attack");
            }
            else
            {
                player.currenthp -= (dmgtype - deftype);
                Console.SetCursorPosition(52, 3);
                Console.WriteLine("you take " + (dmgtype - deftype) + " dmg");
            }

            if (player.currenthp <= 0 )
            {
                Console.SetCursorPosition(52, 8);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Game Over :(");
                Console.ResetColor();
                Console.ReadKey(true);
                ExitGame();
            }

           
        }

        bool TryRun()
        {
            if (player.HP > enemy.HP || player.level > enemy.EnemyLevel)
            {
                return true;
            }
            return false;
        }
        
        


    }
}
