// Marc King - mjking@umich.edu

using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class FleetManager : NetworkBehaviour
{
    [SerializeField]
    private GameObject[] fighterPositions;

    public bool refillFighters;
    public float refillTime;

    private List<GameObject> fighterGOs;
    private AgentManager agent;

    private void Start()
    {
        agent = gameObject.GetComponent<AgentManager>();

        if (isServer)
        {
            foreach (var position in fighterPositions)
            {
                SpawnFighter(position);
            }
        }
    }

    private void SpawnFighter(GameObject fighterPosition)
    {
        var fighter = Instantiate(GameManager.Instance.characters[(int)agent.team].fighterPrefab, fighterPosition.transform.position, Quaternion.identity) as GameObject;
        var fighterAgent = fighter.GetComponent<AgentManager>();
        fighterAgent.team = agent.team;
        fighterAgent.Start();

        var behaviour = new FighterBehaviour();
        behaviour.target = fighterPosition;

        fighterAgent.mover.AddBehaviour(behaviour);
        NetworkServer.Spawn(fighter);
    }

}
