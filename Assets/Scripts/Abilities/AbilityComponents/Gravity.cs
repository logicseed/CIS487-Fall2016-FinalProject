using UnityEngine;
using System.Collections;
using System;

public class Gravity : AbilityComponent
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
        foreach(Collider other in hitColliders)
        {
            agent = GetComponent<AgentManager>();
            if (agent.team != objectAgent.team && agent.type == AgentType.Player)
                other.transform.position = Vector3.MoveTowards(other.transform.position, gameObject.transform.position, Time.deltaTime * magnitude);
        }
    }
}
