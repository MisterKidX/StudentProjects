using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media; // sound stuff

namespace FinalProject101_RonBandel
{
    class SoundManager  // https://stackoverflow.com/questions/3502311/how-to-play-a-sound-in-c-net used this for help
    {
        private static SoundManager instance;

        public static SoundManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SoundManager();
                }
                return instance;
            }
        }

        static string GetSoundFolderLocation()
        {
            return Environment.CurrentDirectory;
        }

        SoundPlayer enemyDeathSound = new SoundPlayer(GetSoundFolderLocation() + @"\sounds\enemy_death.wav");
        SoundPlayer buySound = new SoundPlayer(GetSoundFolderLocation() + @"\sounds\buy.wav");
        SoundPlayer gainGoldSound = new SoundPlayer(GetSoundFolderLocation() + @"\sounds\gain_gold.wav");
        SoundPlayer bossDeathSound = new SoundPlayer(GetSoundFolderLocation() + @"\sounds\boss_death.wav");
        SoundPlayer takeDamageSound = new SoundPlayer(GetSoundFolderLocation() + @"\sounds\take_damage.wav");

        private bool muteAll = false;
        private bool muteAnnoyingSounds = false;

        public void PlayTakeDamagehSound()
        {
            if (!muteAnnoyingSounds && !muteAll)
            {
                takeDamageSound.Play();
            }
        }

        public void PlayEnemyDeathSound()
        {
            if (!muteAnnoyingSounds && !muteAll)
            {
                enemyDeathSound.Play();
            }
        }

        public void PlayBossDeathSound()
        {
            bool mute = false;
            if (!mute && !muteAll)
            {
                bossDeathSound.Play();
            }
        }

        public void PlayBuySound()
        {
            bool mute = false;
            if (!mute && !muteAll)
            {
                buySound.Play();
            }
        }

        public void PlayGainGoldSound()
        {
            bool mute = false;
            if (!mute && !muteAll)
            {
                gainGoldSound.Play();
            }
        }

        public void PlayMerchantSound()
        {
            bool mute = false;
            if (!mute && !muteAll)
            {
                Random rand = new Random();
                Console.Beep(rand.Next(200, 251), 70);
            }
        }

        public void ChangeMuteMode()
        {
            muteAll = !muteAll;
        }

        public void ChangeEnemyDeathSoundMuteMode()
        {
            muteAnnoyingSounds = !muteAnnoyingSounds;
        }
    }
}
