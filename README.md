# Robit
Capstone Project - Robit brief 

Concept:
In the distant future, the world as we know it has been destroyed by an alien invasion. The only remaining hope for humanity is a lone robot named Robit, who has been tasked with scouring the galaxy to find any surviving humans and defeat the alien threat. The game will be a fast-paced action game, similar to the rogue-like dungeon genre, where players must navigate through levels while battling hordes of alien enemies.
Gameplay mechanics will include weapons and abilities for Robit, such as a laser gun, a plasma sword, and the ability to double jump and dash. If the player dies, they will be sent back to the beginning of the game, with progress saved only for the upgrades they have obtained for Robit.

MVP:
- Robit can move Left/Right/Up/Down and jump to navigate around levels(3 levels)
- Robit can interact with enemies to fight 
- Enemies can move around level randomly while interacting with Robit
- Robit can collect in game material/currencies which are saved in a currency/material bar
- Create 3 levels/different planets with various missions and material/currency
- Shop/inventory/upgradable items which are also saved onto progression bars
- In game currency
- Robit can save people/ return them to spaceship
- Health/life bar 
- Player can a pick up/ have a weapon 
- Player is able to operate weapon and aim 
- Pause/Play 
- Main Menu option with information 
- Level 1 is platformer
- 

Extensions:
- Different level styles (platforms)
- Boss fights at a certain level 
- Different character/skins for variation 
- More planets/levels to increase gameplay
- Space station hub for more in game variation 
- Collectables/Rewards (Trophies and acheivments)
- Animations to make the game more visually appealing
- Increase weapon variations to guns etc



Game Layout:

First level is crash landing on moon
To complete level we need to collect in game material (organic metal) to repair ship to move onto the next plant/level.

After first level you can choose a planet to go to (in order to search for survivors).
You can only visit planets in your current solar system. Once you have explored enough and collected in game collectables you can upgrade your ship to move further.
Survivors walk around the ship.

Life system
Like a 3D printer when you die a new body gets printed at the ship and you have to start the level at the beginning.
Every time you visit the ship your mind gets uploaded to the ship which is a saving point.

Combat
At first you use a head butt as you have no weapons until you find a sword then onto guns.

Enemies
The enemies are random walking until they see Robit and they come attack.
Enemies have guns and or swords.


Target Audience:
The game's target audience is primarily action game enthusiasts, with a focus on players who enjoy challenging, fast-paced gameplay. The game will be suitable for players of all ages and genders, but will be particularly appealing to those who have experience.

Platform:
The game will be developed for PC initially, with the intention of expanding to mobile platforms in the future. The game will be optimized for a wide range of hardware specifications to ensure that it can be played on a variety of devices.

Technical:
The game will be developed using the Unity game engine, using C# as the primary programming language. The game will feature 2D graphics with a pixel art aesthetic, and will include sound effects and music. Initially the game is based on 2D but with the intention to make a 3d level.

Timeline:
The timeline for the project will be approximately 12 days. The planning phase will take up the first day, where the team will brainstorm ideas for the game's mechanics, story, and art style. The development phase will take up the next nine days, where the team will work on developing the game mechanics and programming the game's functionality. The final two days will be dedicated to testing and polishing the game, as well as preparing for a final presentation.




BUGS/ERRORS/ISSUES FOUND WHILE BUILDING.

1.Enemy has developed a bug where it doesnt follow on the right hand side but it does on the left.
- Chase distance rectified (chase distance was 0 so it wouldnt chase the player until the distance was changed.)
2.Enemy has decided to stop shooting.
- Trigger was ticked 
- object was deleting instanctly (needed and if statement added back in).
- bullets werent deleting as functoin name has to be "OnCollisionEnter2D" for collioson functions.