// Marc King - mjking@umich.edu

using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class CaptureManager : NetworkBehaviour
{
    public AgentManager agent;
    //public Dictionary<TeamType, float> influences;
    public float[] influences = new float[5];
    
    public bool hasStarted = false;
    public void Start()
    {
        if (hasStarted) return;
        hasStarted = true;

        //Debug.Log("CaptureManager Start");
        agent = gameObject.GetComponent<AgentManager>();
        // influences = new Dictionary<TeamType, float>();
        // influences.Add(TeamType.Team1, 0.0f);
        // influences.Add(TeamType.Team2, 0.0f);
        // influences.Add(TeamType.Team3, 0.0f);
        // influences.Add(TeamType.Team4, 0.0f);
        // influences.Add(TeamType.World, 0.0f);

        


        var go = Instantiate(Resources.Load("CapturePlaque"), Vector3.zero, Quaternion.identity, gameObject.transform) as GameObject;
        go.transform.localPosition = new Vector3(0.0f, 13.0f, 0.0f);
    }

    public void FixedUpdate()
    {
        if (agent.team != TeamType.World)
        {
            GameManager.Instance.teamScores[(int)agent.team] += Time.fixedDeltaTime * GameManager.Instance.scoreRate;
        }
    }

    public void ApplyInfluence(TeamType team, float amount)
    {
        // foreach (var influence in influences)
        // {
        //     if (influence.Key == team)
        //     {
        //         influences[team] += amount;
        //         if (influences[team] >= 1000.0f)
        //         {
        //             influences[team] = 1500.0f;
        //             agent.team = team;
        //         }
        //     }
        //     else if (influence.Key != TeamType.World)
        //     {
        //         influences[team] -= amount;
        //         if (agent.team == influence.Key && influences[agent.team] < 1000.0f)
        //         {
        //             agent.team = TeamType.World;
        //         }
        //     }
        // }
        for (int i = 0; i < influences.Length; i++)
        {
            if (i == (int)team)
            {
                influences[i] += amount;
                if (influences[i] >= 1000.0f && agent.team == TeamType.World)
                {
                    influences[i] = 1500.0f;
                    agent.team = team;
                }
            }
            else
            {
                influences[i] -= amount;
                if (influences[i] < 0.0f) influences[i] = 0.0f;
                
                if ((int)agent.team == i && influences[(int)agent.team] < 1000.0f)
                {
                    agent.team = TeamType.World;
                }
            }
        }
    }

}
