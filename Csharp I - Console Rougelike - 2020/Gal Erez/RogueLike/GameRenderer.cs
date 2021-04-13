using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    class GameRenderer
    {
        Audio audio = new Audio();
        public GameRenderer()
        {
            audio.PlayMusic();
            Console.CursorVisible = false;
            Dialog.Instance.Intro();
            MapGenerator.Instance.SetLvl(1);
            //Shop.Instance.ProduceShop();
            Hud.Instance.ShowHud();
            Dialog.Instance.Legend();
        }
    }
}
