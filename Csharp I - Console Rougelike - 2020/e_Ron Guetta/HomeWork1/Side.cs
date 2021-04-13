using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork1
{
    class Side
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public List<Resource> Resources { get; set; }
        public List<Unit> Units { get; set; }
        public int DeadUnits { get; set; }
        public ConsoleColor color { get; set; }
        public float Capacity { get; set; }
        public float Defence { get; set; }
        public Side(Game g, string Name, int Money, ConsoleColor color)
        {
            this.Name = Name;
            this.Money = Money;
            this.color = color;
            Capacity = 0;
            Units = new List<Unit>();
            Console.ForegroundColor = color;
            Resources = new List<Resource>();
            foreach (Resource r in g.AllResources)
            {
                Resources.Add(new Resource(r.Name, r.Value, r.FarmingAmounts, r.Size, r.Rarity, r.Effect, r.ResourceType));
            }
            g.HireReqruits(this);
        }
    }
}
