using UnityEngine;
using System.Collections;

public class ContactBehavior : MonoBehaviour
{
    [HideInInspector]
    public GameObject abilityObject;

    public Transform abilitySpawnLoc;
    AgentManager agent;
    AgentManager objectAgent;

    void Start()
    {
        agent = GetComponent<AgentManager>();
    }

    public void cast ()
    {
        GameObject instantiatedObject = (GameObject)Instantiate(abilityObject, abilitySpawnLoc.transform.position, transform.rotation);
        instantiatedObject.transform.parent = transform;
        objectAgent = instantiatedObject.GetComponent<AgentManager>();
        objectAgent.SendMessage("Start");
        objectAgent.team = agent.team;
        objectAgent.type = AgentType.AbilityEffect;
    }
}
