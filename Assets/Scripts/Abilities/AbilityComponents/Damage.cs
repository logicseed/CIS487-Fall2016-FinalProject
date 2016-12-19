using UnityEngine;
using System;
/// <summary>
/// Damage on collide ability component. Once DestroyOnCollide is triggered, the damage
/// is applied in a given radius.
/// </summary>
public class Damage : AbilityComponent
{
    void Start()
    {
        if(GetComponent<DestoryOnCollide>() != null)
            collide = GetComponent<DestoryOnCollide>();
        objectAgent = GetComponent<AgentManager>();
    }

    void Update()
    {
        if (collide.triggered == true)
            damage();
    }

    void damage()
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radius);
        foreach (Collider hit in hitColliders)
        {
            agent = hit.GetComponent<AgentManager>();
            if (agent.team != objectAgent.team)
            {
                if (agent.shields >= (int)magnitude)
                    agent.shields = agent.shields - (int)magnitude;
                else
                {
                    int DamagePassedShields = Math.Abs(agent.shields - (int)magnitude);
                    agent.shields = 0;
                    agent.health = agent.health - DamagePassedShields;
                    //Debug.Log("You've been hit for: " + magnitude);
                }
            }
        }
    }
}
