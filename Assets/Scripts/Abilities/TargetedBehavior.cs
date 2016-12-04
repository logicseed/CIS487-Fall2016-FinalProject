using UnityEngine;
using System.Collections;

public class TargetedBehavior : MonoBehaviour
{
    [HideInInspector]
    public GameObject abilityObject;
    [HideInInspector]
    public float maxRange;

    public Transform abilitySpawnLoc;
    AgentManager agent;
    AgentManager objectAgent;

    void Start()
    {
        agent = gameObject.GetComponent<AgentManager>();
    }

    public void cast()
    {
        if (Vector3.Distance(gameObject.transform.position, agent.target.direct.position) <= maxRange)
        {
            GameObject instantiatedObject = (GameObject)Instantiate(abilityObject, abilitySpawnLoc);
            objectAgent = instantiatedObject.GetComponent<AgentManager>();
            objectAgent.SendMessage("Start");
            objectAgent.team = agent.team;
            objectAgent.type = AgentType.AbilityEffect;

            MovementBehaviour behaviour = new PursueBehaviour(agent.target.agent, true);
            objectAgent.mover.AddBehaviour(behaviour);
        }
    }
}
