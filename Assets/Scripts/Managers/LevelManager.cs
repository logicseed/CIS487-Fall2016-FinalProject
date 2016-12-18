// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class LevelManager : NetworkBehaviour
{
    // Singleton
    public static LevelManager instance = null;
    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                var levelManagerGO = Instantiate(Resources.Load("LevelManager")) as GameObject;
                instance = levelManagerGO.GetComponent<LevelManager>();
            }
            return instance;
        }
    }

    public void Awake()
    {
        // Singleton
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        // Setup all the players after they've loaded
        //StartCoroutine(SetupPlayers());
    }

    public IEnumerator SetupPlayers()
    {
        yield return new WaitForSeconds(3);
        foreach (var player in players)
        {
            //player.Setup(GameManager.Instance.characters[player.character].model);
        }
    }


    [HideInInspector]
    public List<PlayerAgentManager> players = new List<PlayerAgentManager>();

    public List<GameObject> playerSpawnPoints = new List<GameObject>();

    [HideInInspector]
    public List<AgentManager> fleets = new List<AgentManager>();

}
