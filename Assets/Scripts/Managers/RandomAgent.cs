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
        agent.team = (TeamType)Random.Range(0, 4);
        agent.species = (SpeciesType)Random.Range(0,5);
        agent.ship = (ShipType)Random.Range(0,5);

        //agent.Setup();
    }

}
