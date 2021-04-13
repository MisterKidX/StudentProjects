using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


namespace RogueLike
{
    class Audio
    {
        MediaPlayer BGMusic;
        public Audio()
        {
            BGMusic = new MediaPlayer();
        }
        private string GetSoundDirectoryPath()
        {
            return Environment.CurrentDirectory + @"\Music";
        }
        public void PlayMusic()
        {
            BGMusic.Open(new System.Uri(GetSoundDirectoryPath() + @"\BGMusic.mp3"));
            BGMusic.Play();
        }
    }
}
