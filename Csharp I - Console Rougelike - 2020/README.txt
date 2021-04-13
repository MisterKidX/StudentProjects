These are the works of my students studying C#.
These brilliant and talented learners only began working on this project when they only
began to code 1.5 month before. The results are tremendous.

Take a look at their brief to learn more about what they were assigned to do.
In short, they created a rougelike game straight from the console. Amazing!

## C# 101 Project Brief ##
Create a Roguelike RPG game on the console! Here are the requirements:

Levels: each level is represented by a map that has an entry and an exit.
Maps\Levels: each map has walkable area, walls, the player's avatar, enemies, traps and interactables. Use the different ASCII characters to build the map graphics to the console. The map’s boundaries must be symmetrical. The player can move about the map and interact with its elements.
Input: Movement should be instantaneous -  the player presses a button and his avatar moves.
Example Map:

Where E is the Entrance
X is the Exit
| is a vertical wall
- is an horizontal wall
@ is the player1
M is an enemy
# is a treasure chest
Blank Space is walkable

You can use your own symbol system.
Entries & Exit: Entries don’t do anything, just show where the player started the level. Exits lead to a new level.
Progression: each level is harder to play but is more rewarding.
Procedural Maps: the maps in the game are created procedurally, implement an algorithm that will generate the maps at runtime.
Data: Print to the player game events and data to the bottom of the map. E.g., “You advanced to maze 3!”, “You found a broad sword which grants you 5 damage”, “The Goblin hits you for 3 damage, you now have 20 hp”. Keep this log section at least 5 entries tall
Attributes: Decide on some attributes the player character has. You must have representation for Damage and HP, but you can create a more complex system if you want (with strength, agility etc.).

Interactables:
Traps: traps are invisible to the player until he steps on them.
Monsters: monsters can be fought. Monsters move towards the player once in range
Treasure Chests: treasure chests reward the player (with attributes, money etc.)

Choose at least four extra credit

Create an options menu that can set the map generation algorithm parameters, console logs count and other aspects of gameplay
Create a HUD to present the player important data such as HP, armor, etc.
Create an inventory system
Create enemies bigger than one tile
Add a save and load system
Create a more elaborate AI for enemies
Make the maps asymmetrical
Make an elaborate combat system that uses damage reduction, evasion, critical hits etc.
Use colors within the console to denote different entities
Create shops that sell items and currency that can be dropped
Add various sound effects
Evaluation
Core: the core of the game at runtime, per described in the assignment
Encapsulation: good uses of classes and methods to break your code into components. 
Data Structures: use of suitable data structures to represent collections of data in your game
Code Organization: your code structure, organization (spacing, tabbing, etc.) and naming conventions
Extra features: any extra features implemented properly, will grant bonus score
