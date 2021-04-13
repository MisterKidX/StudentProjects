using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoughLite
{
    class Player
    {

        public int HP { get; set; }
        public int Armor { get; set; }
        public int Power { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        private string _playerMarker;
        public Dictionary<ItemType, Item> Items { get; set; }

        private ConsoleColor _playerColor;
        public Player(int startingX, int startingY)
        {
            Items = new Dictionary<ItemType, Item>();
            X = startingX;
            Y = startingY;
            HP = 3;
            Armor = 0;
            Power = 1;
            _playerMarker = "P";
            _playerColor = ConsoleColor.Green;
        }
        public void DrawPlayer()
        {
            Console.ForegroundColor = _playerColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(_playerMarker);
            Console.ResetColor();
        }

        private List<ItemType> defensiveItems = new List<ItemType> { ItemType.Halmet, ItemType.Shield, ItemType.Boots,ItemType.Tunic};
        private List<ItemType> offensive = new List<ItemType> { ItemType.Sword };
        public int GetArmor()
        {
            return Armor + Items.Values.Where(item => defensiveItems.Contains(item.Type)).Select(item => item.Stat).Sum();
            
        }
        public int GetPower()
        {
            return Power + Items.Values.Where(item => offensive.Contains(item.Type)).Select(item => item.Stat).Sum();
        }
        
    }
}
