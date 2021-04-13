using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoughLite
{
    class Item
    {
        public ItemType Type { get; set; }
        public int Stat { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        private string _itemMarker;
        
        private ConsoleColor _itemColor;
        
        public Item(int startingX, int startingY, int level, Random r)
        {
            //Items = new HashSet<ItemType>();
            X = startingX;
            Y = startingY;
            Array values = Enum.GetValues(typeof(ItemType));  
            Type =(ItemType)values.GetValue(r.Next(values.Length));
            Stat = r.Next(1, level);
            _itemMarker = "¥";
            _itemColor = ConsoleColor.Cyan;
        }
        public void DrawItems()
        {
            Console.ForegroundColor = _itemColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(_itemMarker);
            Console.ResetColor();
        }
    }
}

