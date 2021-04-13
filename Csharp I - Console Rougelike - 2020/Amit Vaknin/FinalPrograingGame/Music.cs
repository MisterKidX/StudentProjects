using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FinalPrograingGame
{
    class Music
    {
        MediaPlayer bgmusic;
     public Music()
        {
            bgmusic = new MediaPlayer();
        }
        private string GetSoundDirectoryPath()
        {
            return Environment.CurrentDirectory + @"\music";
        }
        public void bgfmusic()
        {
            bgmusic.Open(new System.Uri(GetSoundDirectoryPath() + @"\Rise Against - Savior (Official Video).mp3"));
            bgmusic.Play();
        }
    }
    
}
