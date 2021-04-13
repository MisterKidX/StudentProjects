using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.IO;

namespace _1_2_2021TiltanClassWorkCSProject
{
    class AudioManager
    {
        private static AudioManager audioManagerInstance = null;
        public static AudioManager getAudioManagerInstance
        {
            get
            {
                if (audioManagerInstance == null)
                {
                    audioManagerInstance = new AudioManager();
                }
                return audioManagerInstance;
            }
        }

        MediaPlayer BackGround, GameOver, BossFightBG, EndingBG;

        public AudioManager()
        {
            BackGround = new MediaPlayer();
            GameOver = new MediaPlayer();
            BossFightBG = new MediaPlayer();
            EndingBG = new MediaPlayer();
        }

        private string GetSoundFromDirectory()
        {
            return Environment.CurrentDirectory + @"\Sounds";
        }

        public void RunBackGroundMusic()
        {
            StopAllMusic();
            BackGround.Open(new System.Uri(GetSoundFromDirectory() + @"\Undertale OST - Waterfall Extended.mp3"));
            BackGround.Play();
        }

        public void RunGameOverMusic()
        {
            StopAllMusic();
            GameOver.Open(new System.Uri(GetSoundFromDirectory() + @"\Super Mario World Game Over LoFi Hip Hop Remix.mp3"));
            GameOver.Play();
        }

        public void RunBossFightMusic()
        {
            StopAllMusic();
            BossFightBG.Open(new System.Uri(GetSoundFromDirectory() + @"\Undertale OST 014 - Heartache.mp3"));
            BossFightBG.Play();
        }

        public void RunEndingMusic()
        {
            StopAllMusic();
            EndingBG.Open(new System.Uri(GetSoundFromDirectory() + @"\Undertale OST 049 - It's Showtime!.mp3"));
            EndingBG.Play();
        }

        public void StopAllMusic()
        {
            BackGround.Stop();
            GameOver.Stop();
            BossFightBG.Stop();
            EndingBG.Stop();
        }
    }
}
