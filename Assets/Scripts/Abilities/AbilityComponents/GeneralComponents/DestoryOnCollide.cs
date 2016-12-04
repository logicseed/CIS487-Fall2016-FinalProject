using UnityEngine;
using System.Collections;

public class DestoryOnCollide : MonoBehaviour
{
    [HideInInspector]
    public bool triggered;

    public float radius;
    AgentManager agent;
    AgentManager objectAgent;

    void Start ()
    {
        objectAgent = GetComponent<AgentManager>();
	}
	
	void Update ()
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radius);
        foreach (Collider hit in hitColliders)
        {
            agent = hit.gameObject.GetComponent<AgentManager>();
            if(agent.team != objectAgent.team)
            {
                triggered = true;
                Destroy(gameObject);
            }     
        }
    }
}
