using UnityEngine;
using System.Collections;

public class DestoryShield : AbilityComponent
{
    void Start ()
    {
        objectAgent = GetComponent<AgentManager>();
        destroyShield();
	}

    void destroyShield()
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radius);
        foreach (Collider other in hitColliders)
        {
            agent = other.GetComponent<AgentManager>();
            if (agent.team != objectAgent.team && agent.type == AgentType.Player)
                agent.shields = 0;
        }
    }
}
