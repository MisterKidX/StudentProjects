using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndOfSemester_Project
{
class GameState
{
    Map Map = new Map();
    public bool GameStart = false;
        
    private static GameState _gameStateInstance = null;
    public static GameState GetGameStateInstance
    {
        get
        {
            if (_gameStateInstance == null)
            {
                _gameStateInstance = new GameState();
            }
            return _gameStateInstance;
        }
    }
    public void MainMenu()
    {

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("--------WELCOME TO ROB'S LAND--------");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("1.START GAME                       2.INFO");
        Console.WriteLine("3.CREDITS                     4.QUIT GAME");
        Console.ForegroundColor = ConsoleColor.White;
        int MenuInput = int.Parse(Console.ReadLine());
        switch (MenuInput)
        {
            case 1:

                Console.Clear();
                    

                Console.WriteLine("The wind howls outside, you're laying on a straw bed.");
                Console.WriteLine("Awakened by a distant voice, You slowly open your eyelids.");
                Console.WriteLine("As you become more aware of your surroundings the voice becomes clearer.");
                Console.WriteLine(";Wake up! Come Find Me!; Calls the mysterious voice.");
                Console.WriteLine("Eager to find out more, You walk out of the Room you're in.");
                Console.WriteLine("You're greeted by a tribe; The StormKeepers.");
                Console.WriteLine("What is your name ? __");
                Player.GetPlayerInstance.Name = Console.ReadLine();
                Player.GetPlayerInstance.CheckName();
                   

                Console.Clear();

                Console.WriteLine(Player.GetPlayerInstance.Name + "...We do not recognize that name from anywhere here.");
                Console.WriteLine("You insist to find out about your past and your identity. You tell the tribe about the voice you heard in your head.");
                Console.WriteLine("They tell you to head to a nearby cave, The Chamber of Secrets.");
                Console.WriteLine("If you reach the end, You will be able to speak to The Watchers, They will be able to tell you about your past and identity.");
                Console.WriteLine("With the few items you have, You head out on your journey in search of answers about your life.");
                Console.ReadLine();

                Console.Clear();
                   

                    

                break;
            case 2:
                Console.Clear();
                Console.WriteLine("This game is a rogue-like RPG game entirely in C#");
                Console.WriteLine("it was made as a final semester A project for my teacher Dor Ben Dor");
                Console.WriteLine("______________________________________________________________________");
                Console.WriteLine("How to Play");
                Console.WriteLine("___________");
                Console.WriteLine("W - Move Up           S - Move Down");
                Console.WriteLine("A - Move Left           D - Move Right");
                Console.WriteLine("________________________________________");
                Console.WriteLine("ICONS");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("@ - Represents The Player");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("M - Represents The Enemy : On touch they will damage you.");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("O - Represents A Potion : Pickup a Potion Press H to use.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("X - Represents Where The Player Must Reach In Order To Win The Level");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("¢ - Represents Lost Souls collected on touch (currency used for purchasing upgrades)");
                Console.WriteLine("UPGRADES");
                Console.WriteLine("The Store opens after level 3 , there you can use the souls you collected to get upgrades");
                Console.WriteLine("__________________________________________________________________________________________");

                Console.ReadLine();
                Console.Clear();
                MainMenu();
                break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Programmed by Robby J. Dibi (A Passionate Zelda Fan Lol SCrub)");
                    Console.WriteLine("Helped by Literally ALL Of the Programming classmates");
                    Console.WriteLine("Teacher Abook : Dor Ben Dor");
                    Console.ReadLine();
                    Console.Clear();
                    MainMenu();
                    break;
                case 4:
                System.Environment.Exit(0);
                break;
            default:
                break;
        }

    }
 

}
}
