using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    public class MainMenu
    {
        //enter name
        //tell story from nerrative
        //start game
        //ask if player can start with a big map or a small map
        //tutorial
        Narrative narrative = new Narrative();
        SaveManager _saveManager = new SaveManager();
        public static string playerName;
        public static bool replayGame = false;
        public void EnterName()
        {
            if(!GameManager.loadInfo)
            {
                narrative.EnterNameStart();
                playerName = Console.ReadLine();
                narrative.EnterNameEnd(playerName);
                Console.Clear();
            }
        }
        public void Story()
        {
            if (!GameManager.loadInfo)
            {
                bool wantToSeeStory = true;
                while (wantToSeeStory)
                {
                    Console.WriteLine("Do you want to learn the story of the mighty " + playerName + "?");
                    Console.WriteLine("Y to learn your story");
                    Console.WriteLine("X to skip");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.X:
                            wantToSeeStory = false;
                            break;
                        case ConsoleKey.Y:
                            wantToSeeStory = false;
                            Console.Clear();
                            narrative.StoryOfPlayer();
                            break;
                    }
                }
                Console.Clear();
            }

            //choice to see story or to skip
            //choice to see tutorial or to skip
        }
        public void Tutorial()
        {
            if (!GameManager.loadInfo)
            {
                bool wantToDoTutorial = true;
                while (wantToDoTutorial)
                {
                    Console.WriteLine("Is it your first time and you want to learn the basics or do you want to charge into battle?");
                    Console.WriteLine("Y to 'learn' how to play");
                    Console.WriteLine("X to Charge into Battle");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.X:
                            wantToDoTutorial = false;
                            break;
                        case ConsoleKey.Y:
                            Console.Clear();
                            narrative.Tutorial();
                            wantToDoTutorial = false;
                            break;
                    }
                }
                Console.Clear();
            }
        }
        public void SoundActivation()
        {
            bool wantToHearSound = true;
            while (wantToHearSound)
            {
                Console.WriteLine("Do you want to hear sounds when you play the game?");
                Console.WriteLine("Y I want To Hear " + playerName + " Dance!");
                Console.WriteLine("X NO Sounds");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.X:
                        wantToHearSound = false;
                        SoundManager.soundOn = false;
                        break;
                    case ConsoleKey.Y:
                        wantToHearSound = false;
                        SoundManager.soundOn = true;
                        break;
                }
            }
            Console.Clear();

            //choice to see story or to skip
            //choice to see tutorial or to skip
        }
        public void LoadGame()
        {
            //_saveManager.SaveFileAndFolderCheck();
            bool wantToLoadGame;
            if (replayGame)
            {
                wantToLoadGame = false;
                replayGame = false;
            }
            else
            {
            wantToLoadGame = _saveManager.SaveFileAndFolderCheck();
            }
            while (wantToLoadGame)
            {
                Console.WriteLine("Do you want load game?");
                Console.WriteLine("Y I want To load last game?");
                Console.WriteLine("X I want to start a new game");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.X:
                        wantToLoadGame = false;
                        break;
                    case ConsoleKey.Y:
                        wantToLoadGame = false;
                        GameManager.loadInfo = true;
                        _saveManager.Load();
                        break;
                }
            }
            Console.Clear();
        }
        public void SaveGame()
        {
            _saveManager.SaveFileAndFolderCheck();
            System.Threading.Thread.Sleep(100);
            _saveManager.Save();
        }
    }
}
