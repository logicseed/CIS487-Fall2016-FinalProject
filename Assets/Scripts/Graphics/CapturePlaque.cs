// Marc King - mjking@umich.edu

using UnityEngine;
using UnityEngine.UI;

public class CapturePlaque : MonoBehaviour
{
    private AgentManager agent;
    public RectTransform container;
    public RectTransform team1Bar;
    public RectTransform team2Bar;
    public RectTransform team3Bar;
    public RectTransform team4Bar;
    public Text teamName;

    private void Start()
    {
        agent = transform.parent.gameObject.GetComponent<AgentManager>();
        var image = team1Bar.GetComponent<Image>();
        image.color = GameManager.Instance.teamColors[(int)TeamType.Team1];
    }

    private void Update()
    {
        //Debug.Log(agent);
        //Debug.Log(agent.capture);
        // Update health and shields
        // team1Bar.sizeDelta = new Vector2(4.0f * ((float)agent.capture.influences[TeamType.Team1] / 1000.0f), 0.25f);
        // team2Bar.sizeDelta = new Vector2(4.0f * ((float)agent.capture.influences[TeamType.Team2] / 1000.0f), 0.25f);
        // team3Bar.sizeDelta = new Vector2(4.0f * ((float)agent.capture.influences[TeamType.Team3] / 1000.0f), 0.25f);
        // team4Bar.sizeDelta = new Vector2(4.0f * ((float)agent.capture.influences[TeamType.Team4] / 1000.0f), 0.25f);

        if (agent.team == TeamType.World)
        {
            teamName.text = "";
        }
        else
        {
            teamName.text = GameManager.Instance.teamNames[(int)agent.team];
        }

        team1Bar.sizeDelta = new Vector2(4.0f * ((float)agent.capture.influences[(int)TeamType.Team1] / 1000.0f), 0.25f);
        team2Bar.sizeDelta = new Vector2(4.0f * ((float)agent.capture.influences[(int)TeamType.Team2] / 1000.0f), 0.25f);
        team3Bar.sizeDelta = new Vector2(4.0f * ((float)agent.capture.influences[(int)TeamType.Team3] / 1000.0f), 0.25f);
        team4Bar.sizeDelta = new Vector2(4.0f * ((float)agent.capture.influences[(int)TeamType.Team4] / 1000.0f), 0.25f);

        // Update facing
        //container.localPosition = new Vector3(0.0f, agent.sphere.radius + 0.25f, 0.0f);
        container.LookAt(Camera.main.transform.position);
    }
}
