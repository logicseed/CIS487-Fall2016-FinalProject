// Marc King - mjking@umich.edu

using UnityEngine;
using UnityEngine.Networking;

public class LobbyHook : Prototype.NetworkLobby.LobbyHook
{
    public override void OnLobbyServerSceneLoadedForPlayer(
        NetworkManager manager,
        GameObject lobbyPlayer,
        GameObject gamePlayer)
    {
        var agent = gamePlayer.GetComponent<AgentManager>();
        var player = lobbyPlayer.GetComponent<Prototype.NetworkLobby.LobbyPlayer>();
        var team = (TeamType)player.playerNumber + 1;

        agent.team = team;
        // Debug.Log(GameManager.Instance);
        agent.game = GameManager.Instance;
        agent.game.teamNames[team] = player.playerName;
        agent.game.teamColors[team] = player.playerColor;

        agent.name = player.playerName;
        agent.Setup();
    }
}
