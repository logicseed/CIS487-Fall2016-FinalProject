// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

public class RandomAgent : MonoBehaviour
{
    private AgentManager agent;

    private void Awake()
    {
        agent = gameObject.GetComponent<AgentManager>();
    }

    private void Start()
    {
        //Debug.Log(agent);
        agent.team = (TeamType)Random.Range(0, 4);
       // Debug.Log();
        agent.species = (SpeciesType)Random.Range(0,5);
        //Debug.Log();
        agent.ship = (ShipType)Random.Range(0,5);
        //Debug.Log();
        agent.createGraphics = true;
        //Debug.Log(agent.graphics);
        Destroy(agent.graphics.graphicsGameObject);
        agent.graphics.CreateGraphicsGameObject();
        agent.graphics.ApplyTeamColors();
    }

}
