// Marc King - mjking@umich.edu

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public delegate void ColorChangeHandler();

public class GameManager : MonoBehaviour
{
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
    public Dictionary<TeamType, string> teamNames;
    public Dictionary<TeamType, Color> teamColors;

    [HideInInspector]
    public readonly float lightIntensity = 5.0f;

    [Header("Character Prefabs")]
    public GameObject[] characters;

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
        teamColors = new Dictionary<TeamType, Color>();
        teamColors.Add(TeamType.Team1, Color.red);
        teamColors.Add(TeamType.Team2, Color.blue);
        teamColors.Add(TeamType.Team3, Color.green);
        teamColors.Add(TeamType.Team4, Color.yellow);
        teamColors.Add(TeamType.World, Color.white);
    }

    private void InitNames()
    {
        teamNames = new Dictionary<TeamType, string>();
        teamNames.Add(TeamType.Team1, "Team 1");
        teamNames.Add(TeamType.Team2, "Team 2");
        teamNames.Add(TeamType.Team3, "Team 3");
        teamNames.Add(TeamType.Team4, "Team 4");
        teamNames.Add(TeamType.World, "World");
    }

    public void SetTeamColor(TeamType team, Color color)
    {
        teamColors[team] = color;
        OnColorChange();
    }

    public Color GetTeamColor(TeamType team)
    {
        return teamColors[team];
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
}
