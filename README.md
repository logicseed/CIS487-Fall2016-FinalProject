:warning: | __The content of this repository is explicitly NOT LICENSED for use, modification, or sharing. Per GitHub's terms of service it may only be viewed. See [No License] for more information.__ | :warning:
--------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ---------

[No License]: https://choosealicense.com/no-permission/

Game Design I - CIS487 Fall 2016
======
>After introducing the class to the basics of the Unity engine with the midterm project, we separated
>into teams of four to work on a larger project. For this project we chose to create a simple multiplayer
>battle arena that takes place in space. The players would assume the role of different planets that
>would do battle for the resources of nearby moons.

### Details

__Students:__ Marc King, Rodney Lewis, Harrison Telfer, Jeff Wright

__Professor:__ Dr. Bruce Maxim

__School:__ University of Michigan - Dearborn

__My Contributions:__ Design, implementation, logo, UI, networking, movement

__Timeline:__ 6 weeks

### Technologies

* .NET Framework 3.5
* Unity 5.4.2

### Screenshots

*The main menu exists in 3D space and switching between sub-menus rotates the camera to view the
different menus.*

[![MainMenu](Screenshots/MainMenu.gif?raw=true "MainMenu")](Screenshots/MainMenu.gif?raw=true)

*The networking lobby allows players to switch ships, change their team color, and await other players.
The lobby code was the only existing code used in this project, but it was modified to allow for
players to change their ships and team colors, and to fit the aesthetic of the rest of the menus.*

[![Lobby](Screenshots/Lobby.gif?raw=true "Lobby")](Screenshots/Lobby.gif?raw=true)

*Custom movement code allows the player to click to move their ship. It uses the same movement code
used by the AI ships but is under control of the player.*

[![Movement](Screenshots/Movement.gif?raw=true "Movement")](Screenshots/Movement.gif?raw=true)

*The camera allows the player to change their perspective to provide a better view of the map, but
it is under heavy constraints to limit the amount of information provided to a player.*

[![Camera](Screenshots/Camera.gif?raw=true "Camera")](Screenshots/Camera.gif?raw=true)

*The following animation shows a selected moon being drained of its resources. The player then travels
to a nearby moon and attracts the attention of an opposing team.*

[![Capture](Screenshots/Capture.gif?raw=true "Capture")](Screenshots/Capture.gif?raw=true)

*Early testing indicated that many players found it challenging to maintain their orientation in the
relatively empty space. To assist with orientation a grid can be overlayed onto the map.*

[![Grid](Screenshots/Grid.gif?raw=true "Grid")](Screenshots/Grid.gif?raw=true)

*Since the maps are boundless, a warning graphic will indicate when a player has traveled
too far from the main arena area. The warning graphic always points toward the center of the map.*

[![Boundary](Screenshots/Boundary.gif?raw=true "Boundary")](Screenshots/Boundary.gif?raw=true)

### Development

*Knowing the map would have many entities acting simultaneously, the animation below is an early
stress test to check for bottlenecks in the movement code.*

[![StressTest](Screenshots/StressTest.gif?raw=true "StressTest")](Screenshots/StressTest.gif?raw=true)

*Below is an early demonstration of the ship and color selection being mirrored across the networking
code.*

[![NetworkedLobby](Screenshots/NetworkedLobby.gif?raw=true "NetworkedLobby")](Screenshots/NetworkedLobby.gif?raw=true)
