using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Destory object when another agent that is not a part of your own team enters 
/// the overlap sphere. 
/// </summary>
/// <remarks>
/// The collison overlap sphere may have a smaller radius than the actual effect 
/// sphere, the collsion overlap sphere should never be larger than the effect radius. 
/// These two variables are independant of each other.
/// </remarks>
public class DestoryOnCollide : NetworkBehaviour
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
        if (hitColliders != null)
        {
            foreach (Collider hit in hitColliders)
            {
                agent = hit.gameObject.GetComponent<AgentManager>();
                if (agent.team != objectAgent.team)
                {
                    triggered = true;
                    StartCoroutine("trigger");
                }
            }
        }
    }

    IEnumerator trigger()
    {
        yield return new WaitForSeconds(0);
    }

    void destroyObject()
    {
        NetworkServer.Destroy(gameObject);
    }
}
