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

    #region MonoBehavior Methods
    private void Awake() { }
    private void Start()
    {
        agent = gameObject.GetComponent<AgentManager>();

        if (isServer)
        {
            foreach (var position in fighterPositions)
            {
                var fighter = Instantiate(Resources.Load("Fighter")) as GameObject;
                var fighterAgent = fighter.GetComponent<AgentManager>();
                fighterAgent.team = agent.team;
                fighterAgent.species = agent.species;
                fighterAgent.mover.AddBehaviour(new SeekBehaviour(position.GetComponent<AgentManager>()));
                NetworkServer.Spawn(fighter);
            }
        }
    }
    private void FixedUpdate()
    {

        if (refillFighters && fighterGOs.Count < fighterPositions.Length)
        {

        }
    }
    private void Update()
    {

    }
    private void LateUpdate() { }
    private void OnDestroy() { }
    #endregion MonoBehaviour Methods



}
