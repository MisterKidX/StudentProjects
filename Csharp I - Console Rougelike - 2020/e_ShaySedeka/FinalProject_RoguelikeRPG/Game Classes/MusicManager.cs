using FinalProject_RoguelikeRPG.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FinalProject_RoguelikeRPG
{
    public class MusicManager
    {

        MediaPlayer bgPlayer, walkPlayer, swingPlayer, dyingPlayer, exitPlayer, shrinePlayer;

        public MusicManager()
        {
            bgPlayer = new MediaPlayer();
            walkPlayer = new MediaPlayer();
            swingPlayer = new MediaPlayer();
            dyingPlayer = new MediaPlayer();
            exitPlayer = new MediaPlayer();
            shrinePlayer = new MediaPlayer();
        }

        private string GetSoundDirectoryPath()
        {
            return Environment.CurrentDirectory  + @"\sounds";
        }

        public  void PlayAmbientMusic()
        {
            bgPlayer.Open(new System.Uri(GetSoundDirectoryPath() + @"\background_music_lowered3.mp3"));
            bgPlayer.Play();

        }

        public void PlaySwingSound()
        {
            swingPlayer.Open(new System.Uri(GetSoundDirectoryPath() + @"\swing.wav"));
            swingPlayer.Play();
        }

        public void PlayWalkSound()
        {
            walkPlayer.Open(new System.Uri(GetSoundDirectoryPath() + @"\walk2.mp3"));
            walkPlayer.Play();
        }

        public void PlayShrineSound()
        {
            shrinePlayer.Open(new System.Uri(GetSoundDirectoryPath() + @"\shrine.wav"));
            shrinePlayer.Play();
        }

        public void PlayDyingSound()
        {
            dyingPlayer.Open(new System.Uri(GetSoundDirectoryPath() + @"\die.wav"));
            dyingPlayer.Play();
        }

        public void PlayExitSound()
        {
            exitPlayer.Open(new System.Uri(GetSoundDirectoryPath() + @"\exit.wav"));
            exitPlayer.Play();
        }
    }
}
