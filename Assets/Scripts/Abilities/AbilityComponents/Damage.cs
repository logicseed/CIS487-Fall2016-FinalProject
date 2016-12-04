using UnityEngine;
using System.Collections;

public class Damage : AbilityComponent
{
    DestoryOnCollide collide;

    void Start()
    {
        collide = GetComponent<DestoryOnCollide>();
        objectAgent = GetComponent<AgentManager>();
    }

    void Update()
    {
        if (collide.triggered == true)
            activate();   
    }

    void activate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radius);
        foreach (Collider hit in hitColliders)
        {
            agent = GetComponent<AgentManager>();
            if (agent.team != objectAgent.team)
                agent.health = agent.health - (int)magnitude;
            //Debug.Log("You've been hit for: " + magnitude);
        }
    }
}
