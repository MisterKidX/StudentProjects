using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Media;
using System.IO;
namespace Final_Project
{
    class SoundManager
    {
        MediaPlayer coin , background, heal, levelEnd, getHit;
        public SoundManager()
        {
            coin = new MediaPlayer();
            background = new MediaPlayer();
            heal = new MediaPlayer();
            levelEnd = new MediaPlayer();
            getHit = new MediaPlayer();            
        }
        private string GetSoundDirectoryPath()
        {
            return Environment.CurrentDirectory + @"\audio";
        }
        public bool Paused = false;
        public void BackGroundMusic()
        {
            
            background.Open(new System.Uri(GetSoundDirectoryPath() + @"\Super Mario Bros. Soundtrack.mp3"));
            if (!Paused)
            {
                background.Play();
            }
            else
            {
                background.Pause();
            }
        }
        public void CoinSoundEffect()
        {
            coin.Open(new System.Uri(GetSoundDirectoryPath() + @"\[ONTIVA.COM]-Cash Register (Kaching) - Sound Effect (HD)-HQ.wav"));
            coin.Play();           
        }
        public void HealingSoundEffect()
        {
            heal.Open(new System.Uri(GetSoundDirectoryPath() + @"\fortnite shield sound FX (HD).mp3"));
            heal.Play();
        }
        public void LevelEndingSoundEffect()
        {
            levelEnd.Open(new System.Uri(GetSoundDirectoryPath() + @"\Super Mario Bros. Music - Level Complete.mp3"));
            levelEnd.Play();
        }
        public void GetHitSoundEffect()
        {
            getHit.Open(new System.Uri(GetSoundDirectoryPath() + @"\Minecraft Damage (Oof) - Sound Effect (HD).mp3"));
            getHit.Play();
        }        
    }
}
