using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace HomeWork1
{
    class Game
    {
        public int StartingMoney { get; set; }
        public float MaxCapacity { get; set; }
        public string[] Names { get; set; }
        public int LC { get; set; }
        public int UC { get; set; }
        public int Selection { get; set; }
        public ConsoleColor LivingColor { get; set; }
        public ConsoleColor UndeadColor { get; set; }
        public Unit[] AllUnits { get; set; }
        public Resource[] AllResources { get; set; }


        public void MainMenu() // Im Not Proud of This Menu Code.
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            MainMenuText(0);
            Selection = 0;
            while (true)
            {
                if (MenuControlls(2))
                {
                    if (Selection == 0) { Play(); break; }
                    else if (Selection == 1) { Options(); break; }
                    else if (Selection == 2) { Environment.Exit(1); }
                }
                else { MainMenuText(Selection); }
            }

        }

        public void MainMenuText(int s)
        {
            Console.SetCursorPosition(2, 1);
            Check(s, 0);
            Console.Write("[Play]");
            Console.SetCursorPosition(1, 2);
            Check(s, 1);
            Console.Write("[Options]");
            Console.SetCursorPosition(2, 3);
            Check(s, 2);
            Console.Write("[Quit]");
        }
        public void Options()
        {
            OptionsText(0);
            Selection = 0;
            while (true)
            {
                if (MenuControlls(5))
                {
                    if (Selection == 0) { ChangeColor(true); OptionsText(Selection); }
                    else if (Selection == 1) { ChangeColor(false); OptionsText(Selection); }
                    else if (Selection == 2) { ChangeStat(true); OptionsText(Selection); }
                    else if (Selection == 3) { ChangeStat(false); OptionsText(Selection); }
                    else if (Selection == 4) { ResetToDefault(); OptionsText(Selection); }
                    else if (Selection == 5) { MainMenu(); break; }
                }
                else { OptionsText(Selection); }

            }
        }
        public void OptionsText(int s)
        {
            Console.SetCursorPosition(1, 1);
            Check(s, 0);
            Console.Write("[Living Color]");
            Console.ForegroundColor = LivingColor;
            Console.Write("\t@");
            Console.SetCursorPosition(1, 2);
            Check(s, 1);
            Console.Write("[Undead Color]");
            Console.ForegroundColor = UndeadColor;
            Console.Write("\t@");
            Console.SetCursorPosition(1, 3);
            Check(s, 2);
            Console.Write("[Start Money For Units]  (" + StartingMoney + ")");
            Console.SetCursorPosition(1, 4);
            Check(s, 3);
            Console.Write("[Max Resources Capacity] (" + MaxCapacity + ")");
            Console.SetCursorPosition(1, 5);
            Check(s, 4);
            Console.Write("[Reset To Default]");
            Console.SetCursorPosition(1, 6);
            Check(s, 5);
            Console.Write("[Back]");
        }
        public bool MenuControlls(int Max)
        {
            ConsoleKey key;
            while (true)
            {
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.Enter || key == ConsoleKey.Spacebar || key == ConsoleKey.W || key == ConsoleKey.S) { break; }
            }
            if (key == ConsoleKey.UpArrow || key == ConsoleKey.W) { Selection--; if (Selection < 0) Selection = Max; }
            else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S) { Selection++; if (Selection > Max) Selection = 0; }
            else if (key == ConsoleKey.Enter || key == ConsoleKey.Spacebar) { return true; }
            return false;
        }

        public void Check(int S, int line)
        {
            if (S == line) { Console.ForegroundColor = ConsoleColor.Yellow; }
            else { Console.ForegroundColor = ConsoleColor.White; }
        }
        public void ChangeColor(bool Living)
        {
            if (Living)
            {
                ConsoleColor[] c = new ConsoleColor[] { ConsoleColor.Cyan, ConsoleColor.Blue, ConsoleColor.DarkYellow, ConsoleColor.DarkCyan };
                LC++;
                if (LC > c.Length - 1) LC = 0;
                LivingColor = c[LC];
            }
            else
            {
                ConsoleColor[] c = new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Green, ConsoleColor.DarkRed };
                UC++;
                if (UC > c.Length - 1) UC = 0;
                UndeadColor = c[UC];
            }
        }
        public void ChangeStat(bool StartMoney)
        {
            Console.Clear();
            Console.WriteLine("\n Write a Number.");
            Console.SetCursorPosition(2, 2);
            
            string s = Console.ReadLine();

            if (StartMoney)
            {                          
                if (int.TryParse(s, out int j))
                {
                    if (j >= 100 && j <= 10000) { StartingMoney = j; }
                }

            }

            else
            {                            
                if (float.TryParse(s, out float j))
                {
                    if (j >= 0 && j < 1000000) { MaxCapacity = j; }
                }

            }

            Console.Clear();
        }
        public void ResetToDefault()
        {
            Console.Clear();
            StartingMoney = 500;
            MaxCapacity = 100;
            LC = 10;
            ChangeColor(true);
            UC = 10;
            ChangeColor(false);
        }
        
        
        
        public void Play()
        {
            Console.Clear();
            Console.WriteLine("\n How Many Players? 0/1/2");
            ConsoleKey key;
            while (true)
            {
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.D0 || key == ConsoleKey.D1 || key == ConsoleKey.D2) { break; }
            }
            if (key == ConsoleKey.D0)
                StartGame(0);
            else if (key == ConsoleKey.D1)
                StartGame(1);
            else if (key == ConsoleKey.D2)
                StartGame(2);
            Console.ForegroundColor = ConsoleColor.White;
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
            MainMenu();
        }

        public void StartGame(int PlayerAmount)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n The Battle Started!");

            Names = new string[] {"Ben","Moti Loohim","Shani","Albert","Moshiko","Lotem","Banana","Flots","Lukas","Baruh","Roni","Dor","Ofir","Saat","Afik","Mohamad",
            "Jesus","Moshe","Bin Laden","PizzaGirl69","Minecraft Steve","Beyonce","Kim Kardashian","Kelly Jenner","Shira","Samara","Spongebob","Patrick","Sandy","Squiduid",
            "Mr Krab","Doggy Dog","Pika","Hatula","Ron","Creeper","Sakura","Lucy","Nataly","Itshak","Sonia","Ivgeny","Vlad","Ahmed","Mr Bin"};

            Resource Berries = new Resource("Berries", 1, 30, 0.1f, 0, 1, Resource.resourceType.Food);
            Resource Bread = new Resource("Bread", 4, 10, 0.5f, 1, 5, Resource.resourceType.Food);
            Resource Pumpkin = new Resource("Pumpkin", 30, 3, 1f, 2, 20, Resource.resourceType.Food);
            Resource MeatBalls = new Resource("Meat-Balls", 2, 30, 0.2f, 0, 2, Resource.resourceType.Food);
            Resource HotDogs = new Resource("Hot-Dogs", 10, 10, 1f, 1, 7, Resource.resourceType.Food);
            Resource Steak = new Resource("Giant-Steak", 40, 3, 2f, 2, 25, Resource.resourceType.Food);
            Resource Cake = new Resource("Cake", 300, 1, 1f, 3, 35, Resource.resourceType.Food);
            Resource Sticks = new Resource("Sticks", 1, 20, 0.1f, 0, 1, Resource.resourceType.Material);
            Resource Wood = new Resource("Wood", 4, 15, 0.5f, 1, 2, Resource.resourceType.Material);
            Resource Stone = new Resource("Stone", 5, 12, 1f, 1, 3, Resource.resourceType.Material);
            Resource Iron = new Resource("Iron", 10, 5, 2f, 2, 10, Resource.resourceType.Material);

            AllResources = new Resource[] { Berries, Bread, Pumpkin, MeatBalls, HotDogs, Steak, Cake, Sticks, Wood, Stone, Iron };

            Job Farming = new Job(new Resource[] { Berries, Bread, Pumpkin });
            Job Butchering = new Job(new Resource[] { MeatBalls, HotDogs, Steak });
            Job Cooking = new Job(new Resource[] { Berries, Bread, Pumpkin, MeatBalls, HotDogs, Steak, Cake });
            Job WoodCutting = new Job(new Resource[] { Sticks, Wood });
            Job Mining = new Job(new Resource[] { Stone, Iron });

            Unit Farmer = new Unit(this, "Farmer", 10, 2,1, 80, Farming);
            Unit Butcher = new Unit(this, "Butcher", 10, 4,2, 100, Butchering);
            Unit Chef = new Unit(this, "Chef", 20, 1, 1, 150, Cooking);
            Unit LumberJack = new Unit(this, "LumberJack", 20, 5, 2, 100, WoodCutting);
            Unit Miner = new Unit(this, "Miner", 20, 4, 1, 120, Mining);
            Unit Goblin = new Unit(this, "Goblin", 10, 3, 3, 30);
            Unit Warrior = new Unit(this, "Warrior", 20, 6, 4, 50);
            Unit Troll = new Unit(this, "Troll", 40, 4, 5, 120);
            AllUnits = new Unit[] { Farmer, Butcher, Chef, LumberJack, Miner, Goblin, Warrior, Troll };



            Side Living = new Side(this, "Living", StartingMoney, LivingColor);

            Side Undead = new Side(this, "Undead", StartingMoney, UndeadColor);

            if (PlayerAmount == 0)
            {
                SimulatedBattle(Living, Undead);
            }
            else if (PlayerAmount == 1)
            {
                SinglePlayer(Living, Undead);
            }
            else { Multiplayer(Living, Undead); }

        }


        public void SimulatedBattle(Side Side1, Side Side2)
        {
            while (true)
            {
                if (AutoTurn(Side1, Side2)) break;
                Thread.Sleep(1000);
                if (AutoTurn(Side2, Side1)) break;
                Thread.Sleep(1000);
            }
        }
        public void SinglePlayer(Side Side1, Side Side2)
        {
            while (true)
            {
                if (PlayerTurn(Side1, Side2)) break;
                Thread.Sleep(1000);
                if (AutoTurn(Side2, Side1)) break;
            }
        }
        public void Multiplayer(Side Side1, Side Side2)
        {
            while (true)
            {
                if (PlayerTurn(Side1, Side2)) break;
                if (PlayerTurn(Side2, Side1)) break;
            }
        }

        public bool PlayerTurn(Side Side1, Side Side2)
        {
            Console.ForegroundColor = Side1.color;
            Console.WriteLine($"\n [{Side1.Name} Player] What are you going to do?\n\n F = Fight\tW = Work\tS = Sell\tR = Recruit\tE = Eat\t   D = Defend\tT = Thievery\tQ = Question?");

            ConsoleKey key;
            while (true)
            {
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Q) { Question(Side1, Side2); }
                if (key == ConsoleKey.F || key == ConsoleKey.W || key == ConsoleKey.S || key == ConsoleKey.R || key == ConsoleKey.E || key == ConsoleKey.D || key == ConsoleKey.T) { break; }
            }
            if (key == ConsoleKey.S) { Sell(Side1); }
            else if (key == ConsoleKey.W) { Work(Side1); }
            else if (key == ConsoleKey.R) { HireReqruits(Side1); }
            else if (key == ConsoleKey.E) { Eat(Side1); }
            else if (key == ConsoleKey.D) { BuildDefence(Side1); }
            else if (key == ConsoleKey.T) { Thief(Side1,Side2); }
            else if (key == ConsoleKey.F) { if (Attack(Side1, Side2)) return true; }

            return false;
        }

        public bool AutoTurn(Side Side1, Side Side2)
        {
            Console.ForegroundColor = Side1.color;

            Random rnd = new Random();
            int MaxRandom = 7;
            if (Side1.Capacity > 20) { MaxRandom = 10; }
            int n = rnd.Next(0, MaxRandom);

            if (Side1.Money > 200) { HireReqruits(Side1); }
            else
            {
                if (n == 9)
                {
                    BuildDefence(Side1);
                }
                else if(n == 8)
                {
                    Eat(Side1);
                }
                else if(n == 7)
                {
                    Sell(Side1);
                }
                else if (n == 6)
                {
                    Thief(Side1, Side2);
                }
                else if (n == 5)
                {
                    Work(Side1);
                }
                else if (n < 4)
                {
                    if (Attack(Side1, Side2)) return true;
                }
            }
            return false;
        }

        public void Question(Side Side1, Side Side2)
        {
            Console.WriteLine($"\n You Got a Question About Your Side? Here is All The Data:");
            Side1.Units.ForEach(delegate (Unit u)
            {
                Console.WriteLine($" [{Side1.Name} Unit] {u.Name} {u.FirstName} \t[{u.Health}/{u.MaxHealth} Hp|{u.Damage} Damage|{u.Defence} Defence|{u.KillCount} Kills|{u.Cost}$ Carries]");
            });
            Side1.Resources.ForEach(delegate (Resource r)
            {
                if (r.Amount > 0)
                {
                    Console.Write($"\n [Resource] {r.Amount} {r.Name} [Value] {r.Value}|{r.Value * r.Amount}");
                    if (r.ResourceType == Resource.resourceType.Food) { Console.Write($" [Heal+] {r.Effect}|{r.Effect * r.Amount}"); }
                    else if (r.ResourceType == Resource.resourceType.Material) { Console.Write($" [Defence+] {r.Effect}|{r.Effect * r.Amount}"); }
                } 
            });
            if (Side1.Defence > 0) { Console.WriteLine($" [Defences] {Side1.Defence}"); }
            Console.WriteLine($"\n [Storange] {Side1.Capacity.ToString("0")}/{MaxCapacity.ToString("0")}\n [Money] {Side1.Money}$\n [Kills] {Side2.DeadUnits}\n [Deaths] {Side1.DeadUnits}");
            Console.WriteLine($"\n [{Side1.Name} Player] What are you going to do?\n\n F = Fight\tW = Work\tS = Sell\tR = Recruit\tE = Eat\t   D = Defend\tQ = Question?");
        }

        public bool Attack(Side Side1, Side Side2)
        {
            Console.WriteLine($"\n The {Side1.Name} Attacking The {Side2.Name}!!!");
            float EarnedMoney = 0;
            Side1.Units.ForEach(delegate (Unit u)
            {
                bool Blocked = false;
                if (Side2.Defence <= 0)
                {
                    var random = new Random();
                    var list = Side2.Units;
                    if (list.Count > 0)
                    {
                        int index = random.Next(list.Count);
                        if (list[index].Defence > 0)
                        {
                            int d = random.Next(0, list[index].Defence + 10);
                            if (d > 9)
                            {
                                Blocked = true;
                                Console.WriteLine($" [Fail] {Side1.Name} {u.Name} {u.FirstName} Tried To Attack {Side2.Name} {list[index].Name} {list[index].FirstName} But {list[index].FirstName} Blocked");
                            }
                        }
                        if (Blocked == false)
                        {
                            float beforeHp = list[index].Health;
                            list[index].Health -= u.Damage;
                            if (list[index].Health <= 0)
                            {
                                Console.WriteLine($" [KILL] {Side1.Name} {u.Name} {u.FirstName} killed {Side2.Name} {list[index].Name} {list[index].FirstName} ({beforeHp}->[DEAD]) +{list[index].Cost}$");
                                Side1.Money += list[index].Cost; EarnedMoney += list[index].Cost; Side2.DeadUnits++; Side2.Units.RemoveAt(index); u.KillCount++;
                                u.Cost++; //Bounty :3
                            }
                            else { Console.WriteLine($" [Attack] {Side1.Name} {u.Name} {u.FirstName} Attacked {Side2.Name} {list[index].Name} {list[index].FirstName} ({beforeHp}->{list[index].Health})"); }
                        }
                    }
                }
                else
                {
                    float DefenceBefore = Side2.Defence;
                    Side2.Defence -= u.Damage;
                    if (Side2.Defence <= 0)
                    {
                        Side2.Defence = 0;
                        Console.WriteLine($" [Destroy] {Side1.Name} {u.Name} {u.FirstName} Destroyed The {Side2.Name}'s Defences ({DefenceBefore}->[DESTROYED])");
                    }
                    else
                    {
                        Console.WriteLine($" [Attack] {Side1.Name} {u.Name} {u.FirstName} Attacked The {Side2.Name}'s Defences ({DefenceBefore}->{Side2.Defence})");
                    }
                }
            });

            if (EarnedMoney > 0) { Console.WriteLine($" The {Side1.Name} Loot The Fallen and Earned {EarnedMoney}$ ({Side1.Money - EarnedMoney}$->{Side1.Money}$)"); }

            if (Side2.Units.Count <= 0)
            {
                Console.WriteLine($"\n [End] The Side of the {Side1.Name} Slained {Side2.DeadUnits} of the {Side2.Name} and Won!\n (Press Enter To Continue!)"); return true;
            }
            return false;
        }
        public void HireReqruits(Side side)
        {
            int howmany = 0;
            int Times = 0;
            List<Unit> newUnits = new List<Unit>();
            while (side.Money > 0)
            {
                Thread.Sleep(20);

                Random rnd = new Random();

                int num = rnd.Next(0, AllUnits.Length);
                if (side.Money > AllUnits[num].Cost)
                {
                    Times = 0;
                    Unit NewUnit = new Unit(this, AllUnits[num].Name, AllUnits[num].Health, AllUnits[num].Damage, AllUnits[num].Defence, AllUnits[num].Cost, AllUnits[num].job);
                    side.Units.Add(NewUnit);
                    newUnits.Add(NewUnit);
                    howmany++;
                    side.Money -= AllUnits[num].Cost;
                }
                else
                {
                    if (Times < 10) { Times++; }
                    else
                    {
                        if (howmany > 0)
                        {
                            Console.WriteLine("\n [Adding Units] The " + side.Name + " has Recruted " + howmany + " Recruits:");
                            newUnits.ForEach(delegate (Unit u)
                            {
                                Console.Write(" " + u.Name + " " + u.FirstName + ",");
                            });

                            Console.WriteLine();
                        }
                        else { Console.WriteLine($"\n [Fail] The {side.Name} Dont Have Enough Money For New Units"); }
                        break;
                    }
                }
            }
        }
        public void Work(Side side)
        {
            Console.WriteLine($"\n The {side.Name} decided To Work!");
            if (side.Capacity < MaxCapacity)
            {
                int HowManyWorked = 0;
                Random rnd = new Random();
                side.Units.ForEach(delegate (Unit u)
                {
                    if (u.job != null && side.Capacity < MaxCapacity) // I wont Remove Their Work Efforts Just Because we are full... I'll just wont let them work anymore.
                    {
                        HowManyWorked++;
                        Resource R;
                        while (true)
                        {
                            int n = rnd.Next(0, u.job.MakingResources.Length);
                            R = u.job.MakingResources[n];
                            int luck = rnd.Next(0, R.Rarity + 1);
                            if (luck == R.Rarity)
                            {
                                break;
                            }
                        }
                        side.Resources.ForEach(delegate (Resource r)
                        {
                            if (r.Name == R.Name)
                            {
                                int howmuch = rnd.Next(0, r.FarmingAmounts + 1);
                                int howmanyBefore = r.Amount;
                                r.Amount += howmuch;
                                if (howmuch > 0)
                                {
                                    Console.WriteLine($" [Work] The {side.Name} {u.Name} {u.FirstName} Worked and Earned {howmuch} {r.Name} ({howmanyBefore}->{r.Amount})");
                                    side.Capacity += howmuch * r.Size;
                                }
                                else
                                {
                                    Console.WriteLine($" [Fail] The {side.Name} {u.Name} {u.FirstName} fell asleep and didnt work at all");
                                }
                            }
                        });
                    }
                });
                if (HowManyWorked == 0) { Console.WriteLine(" But They Had No Workers..."); }
            }
            else { Console.WriteLine(" But They Had No Space Left..."); }
        }
        public void Sell(Side side)
        {
            Console.WriteLine($"\n The {side.Name} decided To Sell All of their Resources For Money!");
            int MoneyBefore = side.Money;
            int HowManyTimes = 0;
            side.Resources.ForEach(delegate (Resource r)
            {
                side.Money += r.Amount * r.Value;
                if (r.Amount > 0)
                {
                    HowManyTimes++;
                    Console.WriteLine($" [SELL] The Side of the {side.Name} sold {r.Amount} {r.Name} for {r.Amount * r.Value}$ ({side.Money - r.Amount * r.Value}$->{side.Money}$)");
                    r.Amount = 0; side.Capacity = 0;
                }
            });
            if (HowManyTimes == 0) { Console.WriteLine(" But They Had No Resources..."); }
            else if (HowManyTimes > 1)
            {
                Console.WriteLine($" The {side.Name} Earned in Total {side.Money - MoneyBefore}$ ({MoneyBefore}$->{side.Money}$)");
            }
        }
        public void Eat(Side side)
        {
            Console.WriteLine($"\n The {side.Name} decided To Eat their Resources To Heal!");
            int didTheyEat = 0;
            Random rnd = new Random();
            var list = side.Units;
            side.Resources.ForEach(delegate (Resource r)
            {
                if (r.ResourceType == Resource.resourceType.Food)
                {
                    int Times = 0;
                    float Heal = 0;
                    int Tries = 0;
                    while (r.Amount > 0)
                    {
                        if (Tries > 10) { break; }
                        int n = rnd.Next(0, side.Units.Count);
                        float HealthMissing = list[n].MaxHealth - list[n].Health;
                        if (HealthMissing >= r.Effect) { list[n].Health += r.Effect; r.Amount--; side.Capacity -= r.Size; Tries = 0; Times++; Heal += r.Effect; didTheyEat++; } //Managed To Eat
                        else { Tries++; } //Counting Fails To Eat...
                    }
                    if (Times > 0) Console.WriteLine($" [Eat] The {side.Name} Ate {Times} {r.Name} and Healed a Total of {Heal} Hp!");
                }
            });
            if (didTheyEat == 0) { Console.WriteLine($" [Fail] But They did not Eat Anything at The End..."); }
        }
        public void BuildDefence(Side side)
        {
            Console.WriteLine($"\n The {side.Name} decided To Build Defences!");
            float DefenceBefore = side.Defence;
            float TotalDefenceAdded = 0;
            side.Resources.ForEach(delegate (Resource r) {

                if (r.ResourceType == Resource.resourceType.Material)
                {
                    if (r.Amount > 0) { side.Defence += r.Amount * r.Effect; TotalDefenceAdded += r.Amount * r.Effect; r.Amount = 0; }
                }

            });
            if (TotalDefenceAdded > 0)
            {
                Console.WriteLine($" [Defence] The {side.Name} Built Up Defences and Added a Total of {TotalDefenceAdded} Hp To their Defence! ({DefenceBefore}->{side.Defence})");
            }
            else
            {
                Console.WriteLine($" [Fail] But They Had Nothing To Build With!");
            }

        }
        public void Thief(Side side1, Side side2)
        {
            bool PassedWall = true;
            Console.WriteLine($"\n The {side1.Name} decided To Steal The {side2.Name}'s Resources!");
            if (side2.Capacity > 0)
            {
                Random rnd = new Random();
                int s;
                int d = 2;
                if (side2.Defence > 0)
                {
                    if (side2.Defence > 500) { d = 5; }
                    else if (side2.Defence > 300) { d = 4; }
                    else if (side2.Defence > 100) { d = 3; }
                    
                    s = rnd.Next(0, d);
                    if (s == 0) { Console.WriteLine($" [Success] The {side1.Name} Managed To Sneak Through The {side2.Name}'s Defences"); }
                    else { PassedWall = false; Console.WriteLine($" [Fail] The {side1.Name} didnt Manage To Pass The {side2.Name}'s Defences"); }
                }

                if (PassedWall)
                {
                    s = rnd.Next(0, 2);
                    if (s == 0)
                    {
                        Console.WriteLine($" [Success] The {side1.Name} Managed To Get their Hands on The {side2.Name}'s Resources...");
                        StealAllResources(side1,side2);
                    }
                    else
                    {
                        Console.WriteLine($" [Fail] The {side1.Name} Were Spotted and Ran away...");
                    }
                }
            }
            else
            {
                Console.WriteLine($" But The {side2.Name} had no Resources To Steal...");
            }
        }
        public void StealAllResources(Side side1, Side side2)
        {
            if (side1.Capacity < MaxCapacity)
            {
                float SpaceLeftForStealing = MaxCapacity - side1.Capacity;
                side2.Resources.ForEach(delegate (Resource r)
                {
                    int Count = 0;
                    Resource side1resource=null;
                    while (r.Amount > 0)
                    {
                        if (SpaceLeftForStealing >= r.Size)
                        {
                            Count++;
                            r.Amount--;
                            side2.Capacity -= r.Size;
                            SpaceLeftForStealing -= r.Size;
                            side1.Capacity += r.Size;
                            side1.Resources.ForEach(delegate (Resource R)
                            {
                                if (R.Name == r.Name)
                                {
                                    side1resource = R;
                                    R.Amount++;
                                }
                            });
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (Count > 0)
                    {
                        Console.WriteLine($" [Steal] The {side1.Name} Stole {Count} {r.Name} from the {side2.Name} ({side1resource.Amount-Count}->{side1resource.Amount})");
                    }                  
                });
            }
            else { Console.WriteLine($" But The {side1.Name} got no Space for more Resources..."); }
        }
    }
}
