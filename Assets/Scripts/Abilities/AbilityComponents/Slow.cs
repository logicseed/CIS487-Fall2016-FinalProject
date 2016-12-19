using UnityEngine;
using System.Collections;

public class Slow : AbilityComponent
{
    public float duration;

	void Start ()
    {
        objectAgent = GetComponent<AgentManager>();
    }

    void Update ()
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radius);
        foreach (Collider hit in hitColliders)
        {
            agent = hit.GetComponent<AgentManager>();
            if (agent.team != objectAgent.team)
                StartCoroutine("applySlow");
        }
    }

    IEnumerator applySlow()
    {
        float maxSpeedTemp = agent.mover.maxSpeed;
        float maxSteeringTemp = agent.mover.maxAccel;
        agent.mover.maxSpeed = agent.mover.maxSpeed * magnitude;
        agent.mover.maxSpeed = agent.mover.maxAccel * magnitude;
        yield return new WaitForSeconds(duration);
        agent.mover.maxSpeed = maxSpeedTemp;
        agent.mover.maxSpeed = maxSteeringTemp;       
    }
}
