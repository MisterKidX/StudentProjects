using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media;

namespace EndOfSemester_Project
{
class Sounds
{
    MediaPlayer backGround,soulPickup,potionPickup,exitLvl,enemyHit,trapHit,ending,gameovr;
        
    public Sounds()
    {
        backGround = new MediaPlayer();
        soulPickup = new MediaPlayer();
        potionPickup = new MediaPlayer();
        exitLvl = new MediaPlayer();
        enemyHit = new MediaPlayer();
        trapHit = new MediaPlayer();
         ending = new MediaPlayer();
            gameovr = new MediaPlayer();

    }
    private string GetSoundDirectoryPath()
    {
        return Environment.CurrentDirectory + @"\Sounds";
    }
    public void BackgroundMusic()
    {

        backGround.Open(new System.Uri(GetSoundDirectoryPath() + @"\Great Fairy Fountain.mp3"));
        backGround.Play();
        

    }
    public void SoulPickUp()
    {
        soulPickup.Open(new System.Uri(GetSoundDirectoryPath() + @"\SoulPickup.mp3"));
        soulPickup.Play();


    }
    public void PotionPickUp()
    {

        potionPickup.Open(new System.Uri(GetSoundDirectoryPath() + @"\PotionPickUp.mp3"));
        potionPickup.Play();
    }
    public void EnemyHit()
    {

        enemyHit.Open(new System.Uri(GetSoundDirectoryPath() + @"\EnemyHit.wav"));
        enemyHit.Play();

    }
    public void LvlUp()
    {


        exitLvl.Open(new System.Uri(GetSoundDirectoryPath() + @"\NextLvl.mp3"));
        exitLvl.Play();

    }
    public void TrapHit()
    {


        trapHit.Open(new System.Uri(GetSoundDirectoryPath() + @"\Trap.mp3"));
        trapHit.Play();

    }
        public void Ending()
        {

            ending.Open(new System.Uri(GetSoundDirectoryPath() + @"\Loop.mp3"));
            ending.Play();

        }
        public void StopBckgrnd()
        {
            backGround.Stop();


        }
        public void GameOver()
        {

            gameovr.Open(new System.Uri(GetSoundDirectoryPath() + @"\GameOver.mp3"));
            gameovr.Play();

        }
    }
}
