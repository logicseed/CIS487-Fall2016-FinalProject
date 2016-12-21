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
    public GameObject characterPrefab;
    public GameObject cruiserPrefab;
    public GameObject fighterPrefab;
}

public class GameManager : NetworkBehaviour
{
    public Character[] characters;
    public Color[] colors;
    public GameObject[] spawnPositions;


    public GameObject[] players;

    public GameObject[] capturePlanets;
    public GameObject[] spaceStations;

    public float[] teamScores = new float[5];
    public float scoreRate = 10.0f;

    public float gameLength = 10.0f;
    public float gameStartTime = 0.0f;
    public float gameTimeElapsed = 0.0f;
	public bool gameRunning = false;

    public void FixedUpdate()
    {
		if (gameRunning) {
			gameTimeElapsed = Time.time - gameStartTime;

			if (gameTimeElapsed >= gameLength * 60.0f) {
				gameRunning = false;
                Destroy(Prototype.NetworkLobby.LobbyManager.s_Singleton.gameObject);
				SceneManager.LoadScene ("Scoreboard");

			}
		}
    }

    public void StartGame()
    {
        gameTimeElapsed = 0.0f;
        gameStartTime = Time.time;
		gameRunning = true;
    }
    
    public event ColorChangeHandler ColorChange;

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

    private void InitColors()
    {
        // teamColors = new Dictionary<TeamType, Color>();
        // teamColors.Add(TeamType.Team1, Color.red);
        // teamColors.Add(TeamType.Team2, Color.blue);
        // teamColors.Add(TeamType.Team3, Color.green);
        // teamColors.Add(TeamType.Team4, Color.yellow);
        // teamColors.Add(TeamType.World, Color.white);

        teamColors[(int)TeamType.Team1] = Color.red;
        teamColors[(int)TeamType.Team2] = Color.yellow;
        teamColors[(int)TeamType.Team3] = Color.cyan;
        teamColors[(int)TeamType.Team4] = Color.magenta;
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

    public void ResetScores()
    {
        for (int i = 0; i < teamScores.Length; i++)
        {
            teamScores[i] = 0.0f;
        }
    }

    public void SetTeamColor(TeamType team, Color color)
    {
        teamColors[(int)team] = color;
        OnColorChange();
    }

    [ClientRpc]
    public void RpcSetTeamColor(TeamType team, Color color)
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

    [ClientRpc]
    public void RpcSetTeamName(TeamType team, string name)
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


    public void SetTeamCharacter(TeamType team, int character)
    {
        teamCharacters[(int)team] = character;
    }

    public int GetTeamCharacter(TeamType team)
    {
        return teamCharacters[(int)team];
    }

    [ClientRpc]
    public void RpcSetTeamCharacter(TeamType team, int character)
    {
        teamCharacters[(int)team] = character;
    }

    /// <summary>
    /// Invokes the DeletingBehaviour event.
    /// </summary>
    public void OnColorChange()
    {
        if (ColorChange != null) ColorChange();
    }
}
