using UnityEngine;
using System.Collections;

public class Disorient : AbilityComponent
{
    MovementBehaviour behaviour;
    public float duration;

    void Start()
    {
        behaviour = new WanderBehaviour();
        objectAgent = GetComponent<AgentManager>();
    }

    void Update()
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
        InvokeRepeating("disorient", 1, 1);
        yield return new WaitForSeconds(duration);
        CancelInvoke("disorient");
    }

    void disorient()
    {
        agent.mover.AddBehaviour(behaviour);
    }
   
}
