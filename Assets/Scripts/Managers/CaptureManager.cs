// Marc King - mjking@umich.edu

using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class CaptureManager : NetworkBehaviour
{
    public AgentManager agent;
    public Dictionary<TeamType, float> influences;
    
    public void Start()
    {
        //Debug.Log("CaptureManager Start");
        agent = gameObject.GetComponent<AgentManager>();
        influences = new Dictionary<TeamType, float>();
        influences.Add(TeamType.Team1, 0.0f);
        influences.Add(TeamType.Team2, 0.0f);
        influences.Add(TeamType.Team3, 0.0f);
        influences.Add(TeamType.Team4, 0.0f);
        influences.Add(TeamType.World, 0.0f);

        var go = Instantiate(Resources.Load("CapturePlaque"), Vector3.zero, Quaternion.identity, gameObject.transform) as GameObject;
        go.transform.localPosition = new Vector3(0.0f, 11.0f, 0.0f);
    }

    public void ApplyInfluence(TeamType team, float amount)
    {
        foreach (var influence in influences)
        {
            if (influence.Key == team)
            {
                influences[team] += amount;
                if (influences[team] >= 1000.0f)
                {
                    influences[team] = 1500.0f;
                    agent.team = team;
                }
            }
            else if (influence.Key != TeamType.World)
            {
                influences[team] -= amount;
                if (agent.team == influence.Key && influences[agent.team] < 1000.0f)
                {
                    agent.team = TeamType.World;
                }
            }
        }
    }

}
