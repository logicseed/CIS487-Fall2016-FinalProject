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
                agent.ApplyDamage((int)magnitude);
        }
    }
}
