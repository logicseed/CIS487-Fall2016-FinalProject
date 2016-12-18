// Marc King - mjking@umich.edu

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using UnityEngine.Networking;
using System.Collections;

public delegate void ColorChangeHandler();

[Serializable]
public class Character
{
    public GameObject model;
    public GameObject cruiserModel;
    public GameObject fighterModel;
}

public class GameManager : NetworkBehaviour
{
    public Character[] characters;
    public Color[] colors;
    public GameObject[] players;
    
    public event ColorChangeHandler ColorChange;

    public Dictionary<int, int> characterSelections;

    // Singleton
    [HideInInspector]
    public static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                var gameManagerGO = Instantiate(Resources.Load("GameManager")) as GameObject;
                instance = gameManagerGO.GetComponent<GameManager>();
            }
            return instance;
        }
    }

    [Header("Team Settings")]
    //public Dictionary<TeamType, string> teamNames;
    //public Dictionary<TeamType, Color> teamColors;
    public string[] teamNames = new string[5];
    public Color[] teamColors = new Color[5];
    public int[] teamCharacters = new int[4];

    [HideInInspector]
    public readonly float lightIntensity = 5.0f;

    private void Awake ()
    {
        // Singleton
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        InitColors();
        InitNames();
        //teamNames = 
    }

    private void Start()
    {
        StartCoroutine(SetupPlayers());
    }

    private void InitColors()
    {
        // teamColors = new Dictionary<TeamType, Color>();
        // teamColors.Add(TeamType.Team1, Color.red);
        // teamColors.Add(TeamType.Team2, Color.blue);
        // teamColors.Add(TeamType.Team3, Color.green);
        // teamColors.Add(TeamType.Team4, Color.yellow);
        // teamColors.Add(TeamType.World, Color.white);

        teamColors[(int)TeamType.Team1] = Color.red;
        teamColors[(int)TeamType.Team2] = Color.blue;
        teamColors[(int)TeamType.Team3] = Color.green;
        teamColors[(int)TeamType.Team4] = Color.yellow;
        teamColors[(int)TeamType.World] = Color.white;
    }

    private void InitNames()
    {
        // teamNames = new Dictionary<TeamType, string>();
        // teamNames.Add(TeamType.Team1, "Team 1");
        // teamNames.Add(TeamType.Team2, "Team 2");
        // teamNames.Add(TeamType.Team3, "Team 3");
        // teamNames.Add(TeamType.Team4, "Team 4");
        // teamNames.Add(TeamType.World, "World");

        teamNames[(int)TeamType.Team1] = "Team 1";
        teamNames[(int)TeamType.Team2] = "Team 2";
        teamNames[(int)TeamType.Team3] = "Team 3";
        teamNames[(int)TeamType.Team4] = "Team 4";
        teamNames[(int)TeamType.World] = "World";
    }

    public void SetTeamColor(TeamType team, Color color)
    {
        teamColors[(int)team] = color;
        OnColorChange();
    }

    public Color GetTeamColor(TeamType team)
    {
        return teamColors[(int)team];
    }

    public void SetTeamName(TeamType team, string name)
    {
        teamNames[(int)team] = name;

    }

    public string GetTeamName(TeamType team)
    {
        return teamNames[(int)team];
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    /// <summary>
    /// Invokes the DeletingBehaviour event.
    /// </summary>
    public void OnColorChange()
    {
        if (ColorChange != null) ColorChange();
    }

    public IEnumerator SetupPlayers()
    {
        //Debug.Log("Starting player setup");
        yield return new WaitForFixedUpdate();
        players = GameObject.FindGameObjectsWithTag("Player");

        Debug.Log("Players Found: " + players.Length);
        foreach (var player in players)
        {
            var agent = player.GetComponent<PlayerAgentManager>();
            agent.Setup(characters[teamCharacters[(int)agent.team]].model);
            //agent.graphics.Setup(agent, characters[teamCharacters[(int)agent.team]].model);
        }
    }
}
