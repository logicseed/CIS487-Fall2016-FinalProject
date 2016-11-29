// Marc King - mjking@umich.edu

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Singleton
    [HideInInspector]
    public static GameManager instance = null;

    [Header("Team 1 Settings")]
    public string team1Name = "Team 1";
    public Color team1Paint = MaterialColor.Red;
    public Color team1Lights = MaterialColor.Amber;

    [Header("Team 2 Settings")]
    public string team2Name = "Team 2";
    public Color team2Paint = MaterialColor.Blue;
    public Color team2Lights = MaterialColor.Purple;

    [Header("Team 3 Settings")]
    public string team3Name = "Team 3";
    public Color team3Paint = MaterialColor.Orange;
    public Color team3Lights = MaterialColor.Pink;

    [Header("Team 4 Settings")]
    public string team4Name = "Team 4";
    public Color team4Paint = MaterialColor.Green;
    public Color team4Lights = MaterialColor.Lime;

    [HideInInspector]
    public readonly float lightIntensity = 5.0f;

    public AgentManager capturePoint1;
    public AgentManager capturePoint2;
    public AgentManager capturePoint3;
    public AgentManager capturePoint4;

    private void Awake ()
    {
        // Singleton
        if (instance == null) instance = this; 
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
