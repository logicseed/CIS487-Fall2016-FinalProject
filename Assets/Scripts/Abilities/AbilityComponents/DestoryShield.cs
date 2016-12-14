using UnityEngine;

/// <summary>
/// Instantly destory an player agent shield.
/// </summary>
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
        foreach (Collider hit in hitColliders)
        {
            agent = hit.GetComponent<AgentManager>();
            if (agent.team != objectAgent.team && agent.type == AgentType.Player)
                agent.shields = 0;
        }
    }
}
