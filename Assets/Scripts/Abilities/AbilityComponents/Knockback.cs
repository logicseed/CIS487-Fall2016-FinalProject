using UnityEngine;

/// <summary>
/// Knock back (add force to) agent when gameobject collider is trigger.
/// </summary>
public class Knockback : AbilityComponent
{
    Rigidbody hitRigidBody;

    void Start ()
    {
        objectAgent = GetComponent<AgentManager>();
    }

    void TriggerOnEnter(Collider hit)
    {
        agent = hit.GetComponent<AgentManager>();
        if(agent.team != objectAgent.team)
        {
            hitRigidBody = hit.GetComponent<Rigidbody>();
            hitRigidBody.AddForce((hit.transform.position - gameObject.transform.position) * magnitude);
        }

    }
}
