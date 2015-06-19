# WindowedWerewolf
A C# version of the Mafia / Wakkerdam game. Add players and roles on a configuration screen, shuffles the roles then displays a game on screen where the game ref can reveal roles or just peek at them. 

## Features
- You can select the display for the actual game display. Suggested use case is to configure on a laptop screen, then display the game on a projector. 
- Roles are freeform, ie. the game has no actual notion on what a Werewolf / Mafia member is. 
- Configuration is saved between games, but shuffle order is not. 

## Suggested game order
The game referee configures the game (for role suggestions: https://en.wikipedia.org/wiki/Mafia_%28party_game%29). Whenever the players "go to sleep", the ref can peek in different roles. Suggested is that he taps players in the first round to give them their role, ie: "In this first round I will walk around you players and gently tap the Werewolf players on their head. After that, I will call them out to handle their turn."

## Requirements
- Microsoft .NET Framework 4.5, so it should just run on any default Windows desktop setup


