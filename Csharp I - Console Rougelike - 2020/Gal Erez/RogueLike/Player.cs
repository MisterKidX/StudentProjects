using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace RogueLike
{
    class Player
    {
        private static Player _instance = null;
        public static Player Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Player();
                }

                return _instance;
            }
        }

        Random rand = new Random();

        // Location
        public Position playerLoc;

        // Avatar Appearance
        private string _playerSymbol;
        private ConsoleColor _playerColor;

        // HUD elements
        public int Lvl = 1;
        public int Hp = 100;
        public int Mp = 50;

        public int CurrentHp;
        public int CurrentMp;

        // Current Stage
        public int CurrentStage = 1;

        // Attributes
        public int Str; // Physical Dmg
        public int Dex;
        public int Int; // Magic Dmg
        public float Luk; // drop precantage

        // Equipment
        public string Weapon;
        public string Earrings;

        // Currency
        public int GoldAmount;

        // Exp
        public int Exp;

        // Dead or Alive
        public bool isAlive;

        public bool playerAttack;
        public bool SkillAttack;

        // playerType
        public bool isWizard = false;

        // Is Game Running
        public bool gameIsRunning;

        public Player()
        {
            // Player Avatar
            _playerSymbol = "δ";

            // HUD elements
            CurrentHp = Hp;
            CurrentMp = Mp;

            // Attributes
            Str = 4;
            Dex = 4;
            Int = 4;
            Luk = 4;

            // Equipment
            Weapon = "None";
            Earrings = "None";

            // Currency
            GoldAmount = 0;

            // Exp
            Exp = 0;

            // Dead or Alive
            isAlive = true;
        }

        public void ProducePlayer(int x, int y)
        {
            ForegroundColor = _playerColor;
            int move = 0;
            ConsoleKeyInfo input;

            while (move == 0)
            {
                ChooseCharacter();
                playerLoc = new Position(x, y);
                ForegroundColor = _playerColor;
                SetCursorPosition(x, y);
                Write(_playerSymbol);

                Weapons.Instance.EquipWeapon(Weapon);
                CollectGold();
                OpenRewardChest();
                OpenTrapChest();
                BuyPotions();
                EnemyHit();
                NextLvl(CurrentStage);
                PlayerDie();

                Hud.Instance.ShowHud();

                input = ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.A:
                        if (MapGenerator.Instance.Map[y, x - 1] == MapGenerator.Instance.VertWall || MapGenerator.Instance.Map[y, x - 1] == MapGenerator.Instance.HoriWall)
                        {
                            continue;
                        }

                        if (MapGenerator.Instance.Map[y, x - 1] == MapGenerator.Instance.CornerTL || MapGenerator.Instance.Map[y, x - 1] == MapGenerator.Instance.CornerTR)
                        {
                            continue;
                        }

                        if (MapGenerator.Instance.Map[y, x - 1] == MapGenerator.Instance.CornerBL || MapGenerator.Instance.Map[y, x - 1] == MapGenerator.Instance.CornerBR)
                        {
                            continue;
                        }

                        SetCursorPosition(x, y);
                        Write(MapGenerator.Instance.Blank);

                        x--;
                        SetCursorPosition(x, y);
                        Write(_playerSymbol);
                        break;

                    case ConsoleKey.D:
                        if (MapGenerator.Instance.Map[y, x + 1] == MapGenerator.Instance.VertWall || MapGenerator.Instance.Map[y, x + 1] == MapGenerator.Instance.HoriWall)
                        {
                            continue;
                        }

                        if (MapGenerator.Instance.Map[y, x + 1] == MapGenerator.Instance.CornerTL || MapGenerator.Instance.Map[y, x + 1] == MapGenerator.Instance.CornerTR)
                        {
                            continue;
                        }

                        if (MapGenerator.Instance.Map[y, x + 1] == MapGenerator.Instance.CornerBL || MapGenerator.Instance.Map[y, x + 1] == MapGenerator.Instance.CornerBR)
                        {
                            continue;
                        }

                        SetCursorPosition(x, y);
                        Write(MapGenerator.Instance.Blank);

                        x++;
                        SetCursorPosition(x, y);
                        Write(_playerSymbol);
                        break;


                    case ConsoleKey.W:
                        if (MapGenerator.Instance.Map[y - 1, x] == MapGenerator.Instance.HoriWall || MapGenerator.Instance.Map[y - 1, x] == MapGenerator.Instance.VertWall)
                        {
                            continue;
                        }

                        if (MapGenerator.Instance.Map[y - 1, x] == MapGenerator.Instance.CornerTL || MapGenerator.Instance.Map[y - 1, x] == MapGenerator.Instance.CornerTR)
                        {
                            continue;
                        }

                        if (MapGenerator.Instance.Map[y - 1, x] == MapGenerator.Instance.CornerBL || MapGenerator.Instance.Map[y - 1, x] == MapGenerator.Instance.CornerBR)
                        {
                            continue;
                        }

                        SetCursorPosition(x, y);
                        Write(MapGenerator.Instance.Blank);

                        y--;
                        SetCursorPosition(x, y);
                        Write(_playerSymbol);
                        break;


                    case ConsoleKey.S:
                        if (MapGenerator.Instance.Map[y + 1, x] == MapGenerator.Instance.HoriWall || MapGenerator.Instance.Map[y + 1, x] == MapGenerator.Instance.VertWall)
                        {
                            continue;
                        }

                        if (MapGenerator.Instance.Map[y + 1, x] == MapGenerator.Instance.CornerTL || MapGenerator.Instance.Map[y + 1, x] == MapGenerator.Instance.CornerTR)
                        {
                            continue;
                        }

                        if (MapGenerator.Instance.Map[y + 1, x] == MapGenerator.Instance.CornerBL || MapGenerator.Instance.Map[y + 1, x] == MapGenerator.Instance.CornerBR)
                        {
                            continue;
                        }

                        SetCursorPosition(x, y);
                        Write(MapGenerator.Instance.Blank);

                        y++;
                        SetCursorPosition(x, y);
                        Write(_playerSymbol);
                        break;

                    case ConsoleKey.NumPad1:
                        playerAttack = true;
                        PlayerAtk();
                        playerAttack = false;
                        break;

                    case ConsoleKey.NumPad3:
                        SkillAttack = true;
                        Skill();
                        SkillAttack = false;
                        break;



                    default:
                        break;

                }

                SetCursorPosition(0, 20);
            }

            ResetColor();
        }

        public void ChooseCharacter()
        {
            if (isWizard == true)
            {
                _playerColor = ConsoleColor.Magenta;
            }
            else
            {
                _playerColor = ConsoleColor.Cyan;
            }
        }

        private void PlayerAtk()
        {
            for (int i = 0; i < Enemy.enemyList.Count; i++)
            {
                if (playerLoc.X == Enemy.enemyList[i].enemyPos.X || playerLoc.X == Enemy.enemyList[i].enemyPos.X - 1 || playerLoc.X == Enemy.enemyList[i].enemyPos.X + 1)
                {
                    if (playerLoc.Y == Enemy.enemyList[i].enemyPos.Y || playerLoc.Y == Enemy.enemyList[i].enemyPos.Y - 1 || playerLoc.Y == Enemy.enemyList[i].enemyPos.Y + 1)
                    {
                        if (playerAttack == true && isWizard == false)
                        {
                            Enemy.enemyList[i].CurrentHp -= Modifiers.Instance.PlayerAtkRange();
                            if (Enemy.enemyList[i].CurrentHp <= 0)
                            {
                                SetCursorPosition(Enemy.enemyList[i].enemyPos.X, Enemy.enemyList[i].enemyPos.Y);
                                Write(MapGenerator.Instance.Blank);
                                Enemy.enemyList.RemoveAt(i);
                            }
                        }

                        if (playerAttack == true && isWizard == true)
                        {
                            Enemy.enemyList[i].CurrentHp -= Modifiers.Instance.PlayerMAtkRange();
                            if (Enemy.enemyList[i].CurrentHp <= 0)
                            {
                                SetCursorPosition(Enemy.enemyList[i].enemyPos.X, Enemy.enemyList[i].enemyPos.Y);
                                Write(MapGenerator.Instance.Blank);
                                Enemy.enemyList.RemoveAt(i);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < Enemy.bossList.Count; i++)
            {
                if (playerLoc.X == Enemy.bossList[i].bossPosUp.X || playerLoc.X == Enemy.bossList[i].bossPosUp.X - 1 || playerLoc.X == Enemy.bossList[i].bossPosUp.X + 1)
                {
                    if (playerLoc.Y == Enemy.bossList[i].bossPosUp.Y || playerLoc.Y == Enemy.bossList[i].bossPosUp.Y - 1 || playerLoc.Y == Enemy.bossList[i].bossPosUp.Y + 1)
                    {
                        if (playerLoc.X == Enemy.bossList[i].bossPosDown.X || playerLoc.X == Enemy.bossList[i].bossPosDown.X - 1 || playerLoc.X == Enemy.bossList[i].bossPosDown.X + 1)
                        {
                            if (playerLoc.Y == Enemy.bossList[i].bossPosDown.Y || playerLoc.Y == Enemy.bossList[i].bossPosDown.Y - 1 || playerLoc.Y == Enemy.bossList[i].bossPosDown.Y + 1)
                            {
                                if (playerAttack == true && isWizard == false)
                                {
                                    Enemy.bossList[i].CurrentHp -= Modifiers.Instance.PlayerAtkRange();
                                    if (Enemy.bossList[i].CurrentHp <= 0)
                                    {
                                        SetCursorPosition(Enemy.bossList[i].bossPosUp.X, Enemy.bossList[i].bossPosUp.Y);
                                        Write(MapGenerator.Instance.Blank);
                                        SetCursorPosition(Enemy.bossList[i].bossPosDown.X, Enemy.bossList[i].bossPosDown.Y);
                                        Write(MapGenerator.Instance.Blank);
                                        Enemy.bossList.RemoveAt(i);
                                    }
                                }

                                if (playerAttack == true && isWizard == true)
                                {
                                    Enemy.bossList[i].CurrentHp -= Modifiers.Instance.PlayerMAtkRange();
                                    if (Enemy.bossList[i].CurrentHp <= 0)
                                    {
                                        SetCursorPosition(Enemy.bossList[i].bossPosUp.X, Enemy.bossList[i].bossPosUp.Y);
                                        Write(MapGenerator.Instance.Blank);
                                        SetCursorPosition(Enemy.bossList[i].bossPosDown.X, Enemy.bossList[i].bossPosDown.Y);
                                        Write(MapGenerator.Instance.Blank);
                                        Enemy.bossList.RemoveAt(i);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Skill()
        {
            for (int i = 0; i < Enemy.enemyList.Count; i++)
            {
                if (playerLoc.X == Enemy.enemyList[i].enemyPos.X || playerLoc.X == Enemy.enemyList[i].enemyPos.X - 1 || playerLoc.X == Enemy.enemyList[i].enemyPos.X + 1)
                {
                    if (playerLoc.Y == Enemy.enemyList[i].enemyPos.Y || playerLoc.Y == Enemy.enemyList[i].enemyPos.Y - 1 || playerLoc.Y == Enemy.enemyList[i].enemyPos.Y + 1)
                    {
                        if (SkillAttack == true && Earrings == "Azure")
                        {
                            Enemy.enemyList[i].CurrentHp -= Modifiers.Instance.AzureSkillRange();
                            if (Enemy.enemyList[i].CurrentHp <= 0)
                            {
                                SetCursorPosition(Enemy.enemyList[i].enemyPos.X, Enemy.enemyList[i].enemyPos.Y);
                                Write(MapGenerator.Instance.Blank);
                                Enemy.enemyList.RemoveAt(i);
                            }
                        }
                        else if (SkillAttack == true && Earrings == "Malachite")
                        {
                            Enemy.enemyList[i].CurrentHp -= Modifiers.Instance.MalachiteSkillRange();
                            if (Enemy.enemyList[i].CurrentHp <= 0)
                            {
                                SetCursorPosition(Enemy.enemyList[i].enemyPos.X, Enemy.enemyList[i].enemyPos.Y);
                                Write(MapGenerator.Instance.Blank);
                                Enemy.enemyList.RemoveAt(i);
                            }
                        }
                        else if (SkillAttack == true && Earrings == "Amethyst")
                        {
                            Enemy.enemyList[i].CurrentHp -= Modifiers.Instance.AmethystSkillRange();
                            if (Enemy.enemyList[i].CurrentHp <= 0)
                            {
                                SetCursorPosition(Enemy.enemyList[i].enemyPos.X, Enemy.enemyList[i].enemyPos.Y);
                                Write(MapGenerator.Instance.Blank);
                                Enemy.enemyList.RemoveAt(i);
                            }
                        }
                        else if (SkillAttack == true && Earrings == "Quartz")
                        {
                            Enemy.enemyList[i].CurrentHp -= Modifiers.Instance.QuartzSkillRange();
                            if (Enemy.enemyList[i].CurrentHp <= 0)
                            {
                                SetCursorPosition(Enemy.enemyList[i].enemyPos.X, Enemy.enemyList[i].enemyPos.Y);
                                Write(MapGenerator.Instance.Blank);
                                Enemy.enemyList.RemoveAt(i);
                            }
                        }
                        else if (SkillAttack == true && Earrings == "None")
                        {
                            Dialog.Instance.TextLog("Skill is locked.");
                        }
                    }
                }
            }

            for (int i = 0; i < Enemy.bossList.Count; i++)
            {
                if (playerLoc.X == Enemy.bossList[i].bossPosUp.X || playerLoc.X == Enemy.bossList[i].bossPosUp.X - 1 || playerLoc.X == Enemy.bossList[i].bossPosUp.X + 1)
                {
                    if (playerLoc.Y == Enemy.bossList[i].bossPosUp.Y || playerLoc.Y == Enemy.bossList[i].bossPosUp.Y - 1 || playerLoc.Y == Enemy.bossList[i].bossPosUp.Y + 1)
                    {
                        if (playerLoc.X == Enemy.bossList[i].bossPosDown.X || playerLoc.X == Enemy.bossList[i].bossPosDown.X - 1 || playerLoc.X == Enemy.bossList[i].bossPosDown.X + 1)
                        {
                            if (playerLoc.Y == Enemy.bossList[i].bossPosDown.Y || playerLoc.Y == Enemy.bossList[i].bossPosDown.Y - 1 || playerLoc.Y == Enemy.bossList[i].bossPosDown.Y + 1)
                            {
                                if (SkillAttack == true && Earrings == "Azure")
                                {
                                    Enemy.bossList[i].CurrentHp -= Modifiers.Instance.AzureSkillRange();
                                    if (Enemy.bossList[i].CurrentHp <= 0)
                                    {
                                        SetCursorPosition(Enemy.bossList[i].bossPosUp.X, Enemy.bossList[i].bossPosUp.Y);
                                        Write(MapGenerator.Instance.Blank);
                                        SetCursorPosition(Enemy.bossList[i].bossPosDown.X, Enemy.bossList[i].bossPosDown.Y);
                                        Write(MapGenerator.Instance.Blank);
                                        Enemy.bossList.RemoveAt(i);
                                    }
                                }
                                else if (SkillAttack == true && Earrings == "Malachite")
                                {
                                    Enemy.bossList[i].CurrentHp -= Modifiers.Instance.MalachiteSkillRange();
                                    if (Enemy.bossList[i].CurrentHp <= 0)
                                    {
                                        SetCursorPosition(Enemy.bossList[i].bossPosUp.X, Enemy.bossList[i].bossPosUp.Y);
                                        Write(MapGenerator.Instance.Blank);
                                        SetCursorPosition(Enemy.bossList[i].bossPosDown.X, Enemy.bossList[i].bossPosDown.Y);
                                        Write(MapGenerator.Instance.Blank);
                                        Enemy.bossList.RemoveAt(i);
                                    }
                                }
                                else if (SkillAttack == true && Earrings == "Amethyst")
                                {
                                    Enemy.bossList[i].CurrentHp -= Modifiers.Instance.AmethystSkillRange();
                                    if (Enemy.bossList[i].CurrentHp <= 0)
                                    {
                                        SetCursorPosition(Enemy.bossList[i].bossPosUp.X, Enemy.bossList[i].bossPosUp.Y);
                                        Write(MapGenerator.Instance.Blank);
                                        SetCursorPosition(Enemy.bossList[i].bossPosDown.X, Enemy.bossList[i].bossPosDown.Y);
                                        Write(MapGenerator.Instance.Blank);
                                        Enemy.bossList.RemoveAt(i);
                                    }
                                }
                                else if (SkillAttack == true && Earrings == "Quartz")
                                {
                                    Enemy.bossList[i].CurrentHp -= Modifiers.Instance.QuartzSkillRange();
                                    if (Enemy.bossList[i].CurrentHp <= 0)
                                    {
                                        SetCursorPosition(Enemy.bossList[i].bossPosUp.X, Enemy.bossList[i].bossPosUp.Y);
                                        Write(MapGenerator.Instance.Blank);
                                        SetCursorPosition(Enemy.bossList[i].bossPosDown.X, Enemy.bossList[i].bossPosDown.Y);
                                        Write(MapGenerator.Instance.Blank);
                                        Enemy.bossList.RemoveAt(i);
                                    }
                                }
                                else if (SkillAttack == true && Earrings == "None")
                                {
                                    Dialog.Instance.TextLog("Skill is locked.");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void CollectGold()
        {
            for (int i = 0; i < Gold.GoldList.Count; i++)
            {
                if (Position.ComparePos(playerLoc, Gold.GoldList[i].GoldPos))
                {
                    ForegroundColor = ConsoleColor.Yellow;
                    GoldAmount += Gold.GoldList[i].Amount;
                    Dialog.Instance.TextLog("You've gained " + Gold.GoldList[i].Amount + " Gold.");
                    Gold.GoldList.RemoveAt(i);
                }
            }
        }

        private void OpenRewardChest()
        {
            for (int i = 0; i < RewardChest.RChestList.Count; i++)
            {
                if (Position.ComparePos(playerLoc, RewardChest.RChestList[i].RChestPos))
                {
                    int reward = rand.Next(1, 5);
                    System.Threading.Thread.Sleep(1);

                    switch (reward)
                    {
                        case 1:
                            EarringsItem.Instance.EquipEarring("Azure");
                            break;

                        case 2:
                            EarringsItem.Instance.EquipEarring("Malachite");
                            break;

                        case 3:
                            EarringsItem.Instance.EquipEarring("Amethyst");
                            break;

                        case 4:
                            EarringsItem.Instance.EquipEarring("Quartz");
                            break;

                        default:
                            EarringsItem.Instance.EquipEarring("None");
                            break;
                    }

                    RewardChest.RChestList.RemoveAt(i);
                }
            }
        }

        private void OpenTrapChest()
        {
            for (int i = 0; i < TrapChest.TChestList.Count; i++)
            {
                if (Position.ComparePos(playerLoc, TrapChest.TChestList[i].TChestPos))
                {
                    CurrentHp -= (int)TrapChest.TChestList[i].Damage;
                    TrapChest.TChestList.RemoveAt(i);
                }
            }
        }

        private void BuyPotions()
        {
            for (int i = 0; i < PotionStore.potionStoreList.Count; i++)
            {
                if (Position.ComparePos(playerLoc, PotionStore.potionStoreList[i].potionStorePos))
                {
                    Dialog.Instance.TextLog("Welcom to the potion store!");
                    Dialog.Instance.TextLog("What would you like to purchase?");
                    Dialog.Instance.TextLog("───────────────────────────────────");
                    ForegroundColor = ConsoleColor.Green;
                    Dialog.Instance.TextLog("H - 50 Hp Potion | M - 50 Mp Potion");
                    SetCursorPosition(20, 24);

                    ConsoleKeyInfo buy = ReadKey();

                    Dialog.Instance.ClearLog();

                    if (buy.Key == ConsoleKey.H && GoldAmount >= 2)
                    {
                        CurrentHp += 50;
                        GoldAmount -= 2;

                        if (CurrentHp > Hp)
                        {
                            CurrentHp = Hp;
                        }
                    }
                    else if (buy.Key == ConsoleKey.M && GoldAmount >= 2)
                    {
                        CurrentMp += 50;
                        GoldAmount -= 2;

                        if (CurrentMp > Mp)
                        {
                            CurrentMp = Mp;
                        }
                    }
                    else
                    {
                        break;
                    }
                }


                ForegroundColor = ConsoleColor.DarkMagenta;
                SetCursorPosition(PotionStore.potionStoreList[i].potionStorePos.X, PotionStore.potionStoreList[i].potionStorePos.Y);
                Write(PotionStore.potionStoreList[i].PotionStoreSymbol);
                SetCursorPosition(PotionStore.potionStoreList[i].potionStorePos.X + 1, PotionStore.potionStoreList[i].potionStorePos.Y);
                Write(MapGenerator.Instance.Blank);
            }
        }

        private void NextLvl(int stageNum)
        {
            for (int i = 0; i < EntranceAndExit.ExitList.Count; i++)
            {
                if (Position.ComparePos(playerLoc, EntranceAndExit.ExitList[i].ExitLoc))
                {
                    Clear();
                    ResetColor();

                    Hp += stageNum * 2;
                    Mp += stageNum * 2;
                    Lvl++;
                    CurrentStage++;

                    if (isWizard == true)
                    {
                        Int += stageNum * 2;
                    }
                    else
                    {
                        Str += stageNum * 2;
                    }

                    Dex += stageNum * 3;

                    MapGenerator.Instance.SetLvl(CurrentStage);
                }
            }
        }

        private void EnemyHit()
        {
            for (int i = 0; i < Enemy.enemyList.Count; i++)
            {
                Enemy.enemyList[i].MoveEnemy();

                if (Position.ComparePos(playerLoc, Enemy.enemyList[i].enemyPos))
                {
                    CurrentHp -= Enemy.enemyList[i].Damage;

                    ForegroundColor = ConsoleColor.Red;
                    Dialog.Instance.TextLog("Recieved " + Enemy.enemyList[i].Damage + " Damage!");

                    if (Enemy.enemyList[i].CurrentHp <= 0)
                    {
                        Enemy.enemyList.RemoveAt(i);
                    }
                }

                if (Enemy.enemyList[i].CurrentHp > 0)
                {
                    ForegroundColor = ConsoleColor.Red;
                    SetCursorPosition(Enemy.enemyList[i].enemyPos.X, Enemy.enemyList[i].enemyPos.Y);
                    Write(Enemy.enemyList[i].EnemySymbol);
                    ResetColor();
                }
                else
                {
                    SetCursorPosition(Enemy.enemyList[i].enemyPos.X, Enemy.enemyList[i].enemyPos.Y);
                    Write(MapGenerator.Instance.Blank);
                }
            }

            for (int i = 0; i < Enemy.bossList.Count; i++)
            {
                if (playerLoc.X == Enemy.bossList[i].bossPosUp.X || playerLoc.X - 1 == Enemy.bossList[i].bossPosUp.X || playerLoc.X + 1 == Enemy.bossList[i].bossPosUp.X)
                {
                    if (playerLoc.Y == Enemy.bossList[i].bossPosUp.Y || playerLoc.Y - 1 == Enemy.bossList[i].bossPosUp.Y || playerLoc.Y + 1 == Enemy.bossList[i].bossPosUp.Y)
                    {
                        if (playerLoc.X == Enemy.bossList[i].bossPosDown.X || playerLoc.X - 1 == Enemy.bossList[i].bossPosDown.X || playerLoc.X + 1 == Enemy.bossList[i].bossPosDown.X )
                        {
                            if (playerLoc.Y == Enemy.bossList[i].bossPosDown.Y || playerLoc.Y - 1 == Enemy.bossList[i].bossPosDown.Y || playerLoc.Y + 1 == Enemy.bossList[i].bossPosDown.Y )
                            {
                                Enemy.bossList[i].BossAtkCdRng++;

                                if (Enemy.bossList[i].BossAtkCdRng > 10)
                                {
                                    Enemy.bossList[i].BossAtkCdRng = 0;
                                }

                                if (Enemy.bossList[i].BossType == "Water")
                                {
                                    if (Enemy.bossList[i].BossAtkCdRng == 0 || Enemy.bossList[i].BossAtkCdRng == 2 || Enemy.bossList[i].BossAtkCdRng == 4 || Enemy.bossList[i].BossAtkCdRng == 6 || Enemy.bossList[i].BossAtkCdRng == 8)
                                    {
                                        CurrentHp -= Enemy.bossList[i].Damage;
                                    }
                                }

                                if (Enemy.bossList[i].BossType == "Steel")
                                {
                                    if (Enemy.bossList[i].BossAtkCdRng == 0 || Enemy.bossList[i].BossAtkCdRng == 1 || Enemy.bossList[i].BossAtkCdRng == 4 || Enemy.bossList[i].BossAtkCdRng == 5 || Enemy.bossList[i].BossAtkCdRng == 8 || Enemy.bossList[i].BossAtkCdRng == 9)
                                    {
                                        CurrentHp -= Enemy.bossList[i].Damage;
                                    }
                                }

                                if (Enemy.bossList[i].BossType == "Fire")
                                {
                                    if (Enemy.bossList[i].BossAtkCdRng == 3 || Enemy.bossList[i].BossAtkCdRng == 4 || Enemy.bossList[i].BossAtkCdRng == 6 || Enemy.bossList[i].BossAtkCdRng == 8 || Enemy.bossList[i].BossAtkCdRng == 9 || Enemy.bossList[i].BossAtkCdRng == 10)
                                    {
                                        CurrentHp -= Enemy.bossList[i].Damage;
                                    }
                                }

                                if (Enemy.bossList[i].BossType == "Nature")
                                {
                                    if (Enemy.bossList[i].BossAtkCdRng == 3 || Enemy.bossList[i].BossAtkCdRng == 6 || Enemy.bossList[i].BossAtkCdRng == 9)
                                    {
                                        CurrentHp -= Enemy.bossList[i].Damage;
                                    }
                                }
                            }
                        }
                    }
                }

                if (Enemy.bossList[i].CurrentHp > 0)
                {
                    ForegroundColor = Enemy.bossList[i].BossColor;
                    SetCursorPosition(Enemy.bossList[i].bossPosUp.X, Enemy.bossList[i].bossPosUp.Y);
                    Write(Enemy.bossList[i].BossUpperSymbol);

                    SetCursorPosition(Enemy.bossList[i].bossPosDown.X, Enemy.bossList[i].bossPosDown.Y);
                    Write(Enemy.bossList[i].BossUnderSymbol);
                    ResetColor();
                }
                else
                {
                    SetCursorPosition(Enemy.bossList[i].bossPosUp.X, Enemy.bossList[i].bossPosUp.Y);
                    Write(MapGenerator.Instance.Blank);

                    SetCursorPosition(Enemy.bossList[i].bossPosDown.X, Enemy.bossList[i].bossPosDown.Y);
                    Write(MapGenerator.Instance.Blank);
                }
            }

            /*
            for (int i = 0; i < Enemy.bossList.Count; i++)
            {
                if (Position.ComparePos(playerLoc, Enemy.bossList[i].bossPosUp) || Position.ComparePos(playerLoc, Enemy.bossList[i].bossPosDown))
                {
                    CurrentHp -= Enemy.bossList[i].Damage;

                    if (Enemy.bossList[i].CurrentHp <= 0)
                    {
                        Enemy.bossList.RemoveAt(i);
                    }
                }

                if (Enemy.bossList[i].CurrentHp > 0)
                {
                    ForegroundColor = ConsoleColor.Red;
                    SetCursorPosition(Enemy.bossList[i].bossPosUp.x, Enemy.bossList[i].bossPosUp.y);
                    Write(Enemy.bossList[i].BossUpperSymbol);
                    SetCursorPosition(Enemy.bossList[i].bossPosDown.x, Enemy.bossList[i].bossPosDown.y);
                    Write(Enemy.bossList[i].BossUnderSymbol);
                    ResetColor();
                }
                else
                {
                    SetCursorPosition(Enemy.bossList[i].bossPosUp.x, Enemy.bossList[i].bossPosUp.y);
                    Write(MapGenerator.Instance.Blank);
                    SetCursorPosition(Enemy.bossList[i].bossPosDown.x, Enemy.bossList[i].bossPosDown.y);
                    Write(MapGenerator.Instance.Blank);
                }
            }*/
        }

        private void PlayerDie()
        {
            if (CurrentHp <= 0)
            {
                gameIsRunning = false;
                Clear();
                Dialog.Instance.DeathMenu();
            }
        }
    }
}
