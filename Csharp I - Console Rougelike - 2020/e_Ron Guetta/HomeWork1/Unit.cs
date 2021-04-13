using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork1
{
    class Unit
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public float MaxHealth { get; set; }
        public float Health { get; set; }
        public float Damage { get; set; }
        public int Defence { get; set; }
        public int Cost { get; set; }
        public int KillCount { get; set; }
        public Job job { get; set; }
        public Unit(Game g, string Name, float Health, float Damage,int Defence, int Cost, Job job = null)
        {
            this.Name = Name; this.Health = Health; this.MaxHealth = Health; this.Damage = Damage; this.Defence=Defence; this.Cost = Cost; this.job = job; this.KillCount = 0;
            Random rnd = new Random();
            int n = rnd.Next(g.Names.Length);
            FirstName = g.Names[n];
        }
    }
}
