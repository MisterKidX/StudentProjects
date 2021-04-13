using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork1
{
    class Resource
    {
        public enum resourceType { Food, Material }
        public resourceType ResourceType { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int FarmingAmounts { get; set; }
        public float Size { get; set; }
        public int Rarity { get; set; }
        public float Effect { get; set; }
        public int Amount { get; set; }

        public Resource(string Name, int Value, int FarmingAmounts, float Size, int Rarity, float Effect, resourceType ResourceType)
        {
            Amount = 0;
            this.Name = Name;
            this.Value = Value;
            this.FarmingAmounts = FarmingAmounts;
            this.Size = Size;
            this.Rarity = Rarity;
            this.Effect = Effect;
            this.ResourceType = ResourceType;
        }
    }
}
