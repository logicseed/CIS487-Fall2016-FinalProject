// Marc King - mjking@umich.edu

using UnityEngine;
using UnityEngine.Networking;

public class LobbyHook : Prototype.NetworkLobby.LobbyHook
{
    public override void OnLobbyServerSceneLoadedForPlayer(
        NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {
        // // Setup high-level managers
        // var game = GameManager.Instance;
        // var level = LevelManager.Instance;

        // // Setup agent
        // var agent = gamePlayer.GetComponent<PlayerAgentManager>();
        // agent.game = game;
        // agent.level = level;

        // // Add agent to player list and set team
        // level.players.Add(agent);
        // var team = (TeamType)level.players.IndexOf(agent) + 1;
        // agent.team = team;
        
        // // Setup team
        // var lobby = lobbyPlayer.GetComponent<Prototype.NetworkLobby.LobbyPlayer>();
        // game.teamNames[team] = lobby.playerName;
        // game.teamColors[team] = lobby.playerColor;

        // // Setup player object
        // agent.character = lobby.playerCharacter;
        // agent.name = lobby.playerName;
        // //agent.Setup(game.characters[agent.character].model);
    }
}
