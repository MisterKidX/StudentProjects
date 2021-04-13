using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    public class Narrative
    {
        string playerName;
        public void EnterNameStart()
        {
            Console.WriteLine("Welcome, welcome to la dungeon!!!");
            Console.WriteLine("Would you be kind to write your name here?");
            Console.Write("Name: ");
        }
        public void EnterNameEnd(string name)
        {
            playerName = name;
            Console.WriteLine("Thank you very much " + playerName);
            KeyPress();
            Console.WriteLine("We are open 24/7 so if you need something feel free to scream and someone will come for you");
            Console.WriteLine();
            Console.WriteLine("---distant shouting---  aaaaaaaaaaaa");
            Console.WriteLine();
            Console.WriteLine("---Shouting back --- Coming");
            Console.WriteLine();
            Console.WriteLine("We are so busy");
            Console.WriteLine();
            Console.WriteLine("well my name is jermont and it was nice to meet you for the last time");
            Console.WriteLine();
            Console.WriteLine("salu");
            KeyPress();
        }
        public void StoryOfPlayer()
        {
            Console.WriteLine("---" + playerName+ " Shouting--- aaaaaaaaaa");
            Console.WriteLine();
            Console.WriteLine("---after a minute, jermont is coming back---");
            Console.WriteLine();
            Console.WriteLine("You ask for some backstory about... LA DUNGEON");
            Console.WriteLine();
            Console.WriteLine("Jermont walkes closer and tells you:");
            Console.WriteLine();
            Console.WriteLine("In this dungeon you will have one and only goal...");
            Console.WriteLine();
            Console.WriteLine("To SURVIVE");
            Console.WriteLine();
            Console.WriteLine("It is very difficult but maybe possible, to become immortal");
            Console.WriteLine();
            Console.WriteLine("How, you ask?, to become so strong that no one can hurt you");
            Console.WriteLine();
            Console.WriteLine("The rumor say that if you gain enough armor, you can be untoutchable");
            Console.WriteLine();
            Console.WriteLine("No one has made it yet, do you think you can do it?");
            Console.WriteLine();
            Console.WriteLine("If you do, come back here, I am not going to bring you back if you die, that is on you");
            Console.WriteLine();
            Console.WriteLine("If you want you can read the guide book to LA DUNGEON");
            Console.WriteLine();
            Console.WriteLine("There are only the basic of things because of no one has ever returnd from there, well, gool luck!");
            Console.WriteLine();
            KeyPress();

        }
        public void Tutorial()
        {
            Console.WriteLine();
            Console.WriteLine("---Readin the guide book of La Dungeon---");
            Console.WriteLine();
            Console.WriteLine("Hello Scrub");
            Console.WriteLine();
            Console.WriteLine("If you came here you are probably new");
            Console.WriteLine();
            Console.Write("The goal is to get to 100");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Armor");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.Write("Why? for each ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("armor ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("gained, you will have a chance to block damage, if you have a 100, you are immune");
            Console.WriteLine();
            Console.Write("When");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" enemies ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("step on you, you will recive damage");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enemies ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("(marked with ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("M ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("for monsters) have ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("HP ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("that will be desplayed on HUD, but for all of the ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("enemies ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("on the level ");
            Console.WriteLine();
            Console.WriteLine("If you do not kill them with one attack learn to count on your own");
            Console.WriteLine();
            Console.Write("When they die, you will be able to recive ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Gold ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" and ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Leather");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.Write("Both will help you advance with the help of the lovely ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("vendor ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("marked on the map with ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("V");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.Write("You can find ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Gold ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("with the mark of ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("$ ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(", there is probably only one per level, at least that is what I heard");
            Console.WriteLine();
            Console.WriteLine("On every Weapon you have a key in order to use it");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("X ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("marks the spot, or at least the door to the ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("next level");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("E ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("is the ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("entrance ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("door and it wont do much");
            Console.WriteLine();
            Console.Write("You are the ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(", like the pie");
            Console.WriteLine();
            Console.WriteLine("I hope you brought your weapon because you will not get one from here");
            Console.WriteLine();
            Console.WriteLine("Good Luck " + playerName +" and we will see if you ever come back");
            Console.WriteLine();
            Console.Write("Ho and if you ever want to kill yourself just press the ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("X ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("button and you can finish yourself off");
            Console.WriteLine();
            KeyPress();
        }
        public void Death()
        {
            Console.WriteLine("You " + playerName + " the hero fall to the ground, covered in your blood");
            Console.WriteLine();
            Console.WriteLine("Hoping that someone will save you, but no one is coming");
            Console.WriteLine();
            Console.WriteLine("You undrstand that this is the END as you close your eyes");
            Console.WriteLine();
            KeyPress();
        }
        public void Win()
        {
            Console.WriteLine("You upgrade the last part of your armor as you gain 100 armor");
            Console.WriteLine();
            Console.WriteLine("You start to go back as monsters try to hurt you but they just can't");
            Console.WriteLine();
            Console.WriteLine("The feeling is awesome and you are laghing");
            Console.WriteLine();
            Console.WriteLine("Suddenly you see people start to surround you");
            Console.WriteLine();
            Console.WriteLine("Scared and confused you try to grasp the situation");
            Console.WriteLine();
            Console.WriteLine("You decide that if you are immune you should attack them");
            Console.WriteLine();
            Console.WriteLine("You hit the man closest to you but you do not seem to deal damage");
            Console.WriteLine();
            Console.WriteLine("He tells you that it is no use, and there is no point in having a weapon anymore");
            Console.WriteLine();
            Console.WriteLine("You lower your sword and walk with them confused");
            Console.WriteLine();
            Console.WriteLine("All of you enter a crack in the wall, there is sound of laghter");
            Console.WriteLine();
            Console.WriteLine("Pepole are driking and having fun");
            Console.WriteLine();
            Console.WriteLine("They tell you that they all got a 100 armor and there is no point in going back");
            Console.WriteLine();
            Console.WriteLine("Going up is boring, why dont you stay with us?");
            Console.WriteLine();
            KeyPress();
            //give the player the option to play again or finish the game
        }
        public void PlayAgainQuestion()
        {
            Console.WriteLine("Wanna play again?");
            Console.WriteLine("Y for YES");
            Console.WriteLine("X for NO");
        }
        public void KeyPress()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Press ENTER to continue");
            Console.WriteLine("-----------------------");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
