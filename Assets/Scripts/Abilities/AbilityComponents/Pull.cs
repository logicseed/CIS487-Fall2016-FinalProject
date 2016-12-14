using UnityEngine;

/// <summary>
/// Pulls agents to the instantiated gameobject. 
/// </summary>
public class Pull : AbilityComponent
{
    void Start()
    {
        objectAgent = GetComponent<AgentManager>();
    }

    void Update()
    {
        pullObject();
    }

    void pullObject()
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radius);
        foreach(Collider hit in hitColliders)
        {
            agent = hit.GetComponent<AgentManager>();
            if (agent.team != objectAgent.team && agent.type == AgentType.Player)
                hit.transform.position = Vector3.MoveTowards(hit.transform.position, gameObject.transform.position, Time.deltaTime * magnitude);
        }
    }
}
